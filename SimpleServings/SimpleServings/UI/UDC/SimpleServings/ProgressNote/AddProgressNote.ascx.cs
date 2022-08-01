using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.ProgressNote
{
    public partial class AddProgressNote : System.Web.UI.UserControl
    {
       
        public bool IsUsedInWizard
        {
            set
            {
                btnSubmit.Visible = !value;
                           
                this.ViewState["_IsUsedInWizard"] = value;
            }
            get
            {
                object o = this.ViewState["_IsUsedInWizard"];
                if (o == null)
                
                    return false;
                

                else
                    return (bool)o;
            }
        }
       
        public string Summary
        {
            get { return lblError.Text; }
        }
        public string TxtNote
        {
            get { return txtNote.Text; }
            set { txtNote.Text = value; }
        }
        public int FairHearingID
        {
            get
            {
                object o = this.ViewState["_FairHearingID"];
                if (o == null)
                    return 0; // 
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_FairHearingID"] = value;
            }
        }
        
        public int ReferenceID
        {
            get
            {

                object o = this.ViewState["_ReferenceID"];
                if (o == null)
                {
                    try
                    {
                        int referenceID = Convert.ToInt32(lblReferenceID.Text);
                        return referenceID;
                    }
                    catch { return 0; }
                }

                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_ReferenceID"] = value;
            }
        }
       
        public int NoteType
        {
            get
            {

                object o = this.ViewState["_NoteType"];
                if (o == null)
                {
                    return SimpleServingsLibrary.Shared.GlobalEnum.NoteType_General;
                }

                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_NoteType"] = value;
            }
        }
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();

                    lblCreatedBy.Text = HelpClasses.AppHelper.GetCurrentUser().StaffID.ToString(); //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID.ToString();
                    lblError.Text = "";
                    PopDropDowns();
                    //initialize add general note 
                    if (NoteType == SimpleServingsLibrary.Shared.GlobalEnum.NoteType_General)
                    {
                        if (Request["FairHearingID"] != null)
                        {
                            int fairHearingID = 0;
                            Int32.TryParse(Request["FairHearingID"].ToString(), out fairHearingID);
                            FairHearingID = fairHearingID;
                            ReferenceID = FairHearingID;
                        }
                    }
                    InitializeControl(ReferenceID, NoteType);

                }
                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }
        }

       

        public void InitializeControl(int referenceID, int noteType)
        {
            
            lblReferenceID.Text = referenceID.ToString();
            ReferenceID = referenceID;
            NoteType = noteType;
            PopDropDowns();           
            ddlNoteType.Enabled = false;
            
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            //if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProgressNoteModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            //{
            //    this.btnSubmit.Visible = false;
            //    //this.btnSaveDraft.Visible = false;
            //}
            //if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProgressNoteModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            //{
            //    this.pnPage.Visible = false;
            //    throw new ApplicationException("You are not allowed to access this page");
            //}
        }
        public void PopDropDowns()
        {
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlNoteType, SimpleServingsLibrary.Shared.Code.CodeTypes.NoteType, HelpClasses.AppHelper.GetCurrentUser().UserGroup, NoteType.ToString());            
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlNoteType, SimpleServingsLibrary.Shared.Code.CodeTypes.NoteType, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup,NoteType.ToString());            
        }

     

        private void AddNote(bool isDraft)
        {
            SimpleServingsLibrary.Shared.ProgressNote note = new SimpleServingsLibrary.Shared.ProgressNote();

            
            note.NoteReferenceID = ReferenceID;
            note.CreatedBy = Convert.ToInt32(lblCreatedBy.Text);
            note.NoteType = Convert.ToInt32(ddlNoteType.SelectedValue);
            note.IsDraft = isDraft;
            note.IsActive = true;//this line was omitted and caused updated drafts to be inactive.
            note.NoteDescription = txtNote.Text.Replace(Environment.NewLine, "<br />");

            if (lblNoteID.Text != null && lblNoteID.Text != "")
            {
                note.NoteID = Convert.ToInt32(lblNoteID.Text);
            }
            int noteID=0;
            if (isDraft)
                noteID = note.SaveDraft();
            else
            {
                noteID = note.AddNote();
                
            }

            lblNoteID.Text = noteID.ToString();
            
        }

        private void EditDraft(int noteID)
        {
            SimpleServingsLibrary.Shared.ProgressNote note = new SimpleServingsLibrary.Shared.ProgressNote(noteID);
            lblNoteID.Text = noteID.ToString();
            lblCreatedBy.Text = note.CreatedBy.ToString();
            ddlNoteType.ClearSelection();
            try
            {
                ddlNoteType.Items.FindByValue(note.NoteType.ToString()).Selected = true;
            }
            catch { }
            txtNote.Text = note.NoteDescription;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (AddNote())
            {
                 if (!IsUsedInWizard)
                {
                    Response.Redirect("~/UI/Page/SimpleServings/ProgressNote/ViewProgressNote.aspx?NoteID=" + lblNoteID.Text + "&Msg=Saved successfully");
                }
            }
        }

        public void AddNote(int referenceID)
        {
            lblReferenceID.Text = referenceID.ToString();
            if (AddNote() && !IsUsedInWizard)
            {
                    Response.Redirect("~/UI/Page/SimpleServings/ProgressNote/ViewProgressNote.aspx?NoteID=" + lblNoteID.Text + "&Msg=Saved successfully");
            }

        }

        public bool AddNote()
        {
            if (String.IsNullOrEmpty(txtNote.Text)) return false;
            bool isDraft = false;
            bool added = false;
            try
            {
                //CheckNoteLength();
                //remove draft before submitting note
                if (!String.IsNullOrEmpty(lblNoteID.Text))
                    SimpleServingsLibrary.Shared.ProgressNote.RemoveNoteByNoteID(Convert.ToInt32(lblNoteID.Text), Convert.ToInt32(lblCreatedBy.Text));
                //
                AddNote(isDraft);
                added = true;

            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = ex.Message;
                added = false;
            }
            return added;
        }

        protected void btnSaveDraft_ServerClick(object sender, EventArgs e)
        {

            bool isDraft = true;
            try
            {
                CheckNoteLength();
                AddNote(isDraft);
                //lblSaveTime.ForeColor = System.Drawing.Color.Red;
                //lblSaveTime.Text = "Last draft saved at " + System.DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = ex.Message;
            }
        }

        private void CheckNoteLength()
        {
            int len = txtNote.Text.Length;
            if (len > 7500)
                throw new Exception("This note exceeds the maximum size and cannot be saved in full.<br/>Please get rid of any unnecessary formatting.");
        }

    }
}