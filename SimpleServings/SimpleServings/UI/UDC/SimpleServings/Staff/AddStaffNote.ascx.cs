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


namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class AddStaffNote : System.Web.UI.UserControl
    {
        public int FairHearingID
        {
            get
            {
                object o = this.ViewState["_FairHearingID"];
                if (o == null)
                    return 0; 
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_FairHearingID"] = value;
                
            }
        }
        public void InitializeControl(int fairHearingID)
        {
            FairHearingID = fairHearingID;
        }

        protected void lnkAddNote_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
           if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            StaffNote note = new StaffNote();
            //note. = FairHearingID;
            
            note.CreatedBy = staff.StaffID;
            note.CreatedOn = System.DateTime.Today.ToShortDateString();
            note.IsRead = false;
            note.IsActive = true;
            note.Note = txtNote.Text;
            //note.TargetStaffID = .AssignedTo;
            try
            {
                

                    if (!string.IsNullOrEmpty(txtNote.Text))
                    {
                        if (note.AddStaffNote() > 0)
                        {
                            txtNote.Text = "";
                        }
                        else
                            lblMsg.Text = "error: could not add note";
                    }
                
            }
            catch 
            {
                lblMsg.Text = "error: could not send note";
            }
        }

        protected void lnkClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;

        }
    }
}