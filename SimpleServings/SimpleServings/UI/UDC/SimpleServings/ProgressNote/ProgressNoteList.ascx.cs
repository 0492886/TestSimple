
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
using System.Drawing;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.ProgressNote
{
    public partial class ProgressNoteList : System.Web.UI.UserControl
    {
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
        
       public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0; // default page index of 1
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

        public bool DraftsOnly
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_DraftsOnly"];
                if (o == null)
                    return false;
                else
                    return (bool)o;
            }

            set
            {
                this.ViewState["_DraftsOnly"] = value;
            }
        }

        public int NoteLength
        {
            get
            {
                if (chxShowEntire.Checked == true)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["NoteDescriptionLength"]);
                }
            }
        }

        public int PageSize
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["DataListPageSize"]); }
        }

        public int LastPage
        {
            get
            {
                // look for total count in ViewState
                object o = this.ViewState["_LastPage"];
                if (o == null)
                    return 0; // default count of 0
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_LastPage"] = value;
            }
        }

        public void InitializeControl(int fairHearingID)
        {
            try
            {
                ApplyPermissions();
                PopDropDowns();
                FairHearingID = fairHearingID;
                PopulateNoteList();
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
        
        }
        protected void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            this.hlAddProgressNote.Visible = SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProgressNoteModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add);

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProgressNoteModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        private void PopDropDowns()
        {
            //SimpleServingsLibrary.Shared.Utility.GetClientsByCaseID(ddlLimitToClientID, caseID, "");

            Utility.GetCodesByTypeAndUserGroup(ddlNoteType, SimpleServingsLibrary.Shared.Code.CodeTypes.NoteType, HelpClasses.AppHelper.GetCurrentUser().UserGroup, "");
            //Utility.GetCodesByTypeAndUserGroup(ddlNoteType, SimpleServingsLibrary.Shared.Code.CodeTypes.NoteType, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup, "");
        }

        public void PopulateNoteList()
        {
            //ApplyPermissions();
            //lblCaseID.Text = FairHearingID.ToString();
            lblMsg.Text = String.Empty;
            this.hlAddProgressNote.NavigateUrl = string.Format("~/UI/Page/ContractTab.aspx?FairHearingID={0}&Control=AddGeneralNote" , FairHearingID);
            try
            {
                BindNoteList(NoteLength);
            }
            catch
            {
                pnPaging.Controls.Clear();
                lstNotes.DataSource = null;
                lstNotes.DataBind();
                cmdPrev.Visible = false;
                cmdNext.Visible = false;
                cmdLast.Visible = false;
                cmdFirst.Visible = false;
                lblCurrentPage.Text = String.Empty;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "No notes listed";
            }
        }

        private void BindNoteList(int noteLength)
        {
            DraftsOnly = false;
            int noteType = Convert.ToInt32(ddlNoteType.SelectedValue);
            
            SimpleServingsLibrary.Shared.ProgressNotes notes = new ProgressNotes();
        
            //if (lnkBtnViewDraft.Visible == true)
            //{
                notes = SimpleServingsLibrary.Shared.ProgressNote.GetProgressNotesByReferenceIDNoteType(FairHearingID, noteType,noteLength); // noteLength, CurrentPage, PageSize, ref totalCount);
                
            //}

            //if (lnkBtnViewNote.Visible == true)
            //{
            //    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"]; if (staff==null ) Response.Redirect("~/UI/Page/login.aspx");
            //    notes = SimpleServingsLibrary.Shared.ProgressNote.GetDraftsByCreatedBy(staff.StaffID,0); //, CurrentPage, PageSize, ref totalCount);
                
            //}
           

            //
            PagedDataSource pgitems = new PagedDataSource();

            pgitems.DataSource = notes;
            pgitems.AllowPaging = true;
            pgitems.PageSize = PageSize; // Sets the number of records to display per page
            pgitems.CurrentPageIndex = CurrentPage;
            LastPage = notes.Count / PageSize + (notes.Count % PageSize > 0 ? 1 : 0);
            cmdPrev.Visible = !pgitems.IsFirstPage;
            cmdNext.Visible = !pgitems.IsLastPage;
            cmdLast.Visible = (pgitems.PageCount > 1) && !pgitems.IsLastPage;
            cmdFirst.Visible = (pgitems.PageCount > 1) && !pgitems.IsFirstPage;
            lblCurrentPage.Text = CurrentPage + 1 + " of " + (notes.Count / PageSize + (notes.Count % PageSize > 0 ? 1 : 0));
           
            if (pgitems.PageCount > 0)
            {
                GeneratePaging(LastPage, CurrentPage);
                lstNotes.DataSource = pgitems;
                lstNotes.DataBind();

                lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
                lblMsg.Text = string.Format("{0} notes found", notes.Count);
            }
            else
            {
                pnPaging.Controls.Clear();
                lstNotes.DataSource = null;
                lstNotes.DataBind();
                cmdPrev.Visible = false;
                cmdNext.Visible = false;
                lblCurrentPage.Text = String.Empty;
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No record found!";
            }


            //




        }

        protected void ddlNoteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = 0;
            PopulateNoteList();
        }

        protected void ddlLimitToClientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = 0;
            PopulateNoteList();
        }

        protected void lstNotes_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int noteTypeID = 0;
                Int32.TryParse(((Label)e.Item.FindControl("lblNoteType")).Text, out noteTypeID);
                if (noteTypeID <= 0)
                {
                    ((Label)e.Item.FindControl("lblNoteType")).Text = "Unknown";

                }
                else
                {
                    ((Label)e.Item.FindControl("lblNoteType")).Text = SimpleServingsLibrary.Shared.Code.DecodeCode(noteTypeID);
                }

                //if (lnkBtnViewNote.Visible == true)
                //{
                //    ((HyperLink)e.Item.FindControl("lnkViewNote")).Visible = false;
                //    ((HyperLink)e.Item.FindControl("lnkEditDraft")).Visible = true;
                //}
                //else
                //{
                    ((HyperLink)e.Item.FindControl("lnkViewNote")).Visible = true;
                    ((HyperLink)e.Item.FindControl("lnkEditDraft")).Visible = false;
                //}
                //when showing drafts only as in MyDrafts
                //if (lnkBtnViewNote.Visible == false && lnkBtnViewDraft.Visible == false)
                //{
                //    ((HyperLink)e.Item.FindControl("lnkEditDraft")).Visible = true;
                //    ((HyperLink)e.Item.FindControl("lnkViewNote")).Visible = false;
                //    int noteID = Convert.ToInt32(((Label)e.Item.FindControl("lblNoteID")).Text);
                    
                    

                //}
            }
        }

        protected void chxShowEntire_CheckedChanged(object sender, EventArgs e)
        {
            PopulateNoteList();
        }

       

       


       
            //



      

        protected void cmdPrev_Click(object sender, System.EventArgs e)
        {
            
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            BindNoteList(NoteLength);                         
        }

        protected void cmdNext_Click(object sender, System.EventArgs e)
        {
           
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            BindNoteList(NoteLength);          
        }

        protected void cmdLast_Click(object sender, EventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage = LastPage-1;

            // Reload control
            BindNoteList(NoteLength);          

        }

        protected void cmdFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;

            // Reload control
            BindNoteList(NoteLength);          
        }
        //private void GeneratePaging(int p, int currentPage)
        //{
        //    pnPaging.Controls.Clear();

        //    int begin = GetBeginningPage(currentPage);
        //    int last = Math.Min(p, begin + 10);
        //    LinkButton lnk;
        //    for (int i = begin; i < last; i++)
        //    {
        //        lnk = new LinkButton();
        //        lnk.ID = "Page" + (i + 1);
        //        lnk.Click += new EventHandler(lnk_Click);
        //        lnk.CommandArgument = i.ToString();
        //        lnk.Text = (i + 1).ToString();

        //        //if (lnk.Text == (currentPage + 1).ToString())
        //        //{
        //        //    lnk.ForeColor = Color.HotPink;
        //        //    lnk.BorderStyle = BorderStyle.Solid;
        //        //    lnk.BorderColor = Color.Teal;
        //        //    lnk.BorderWidth = Unit.Pixel(1);
        //        //    //lnk.Attributes.["class"] = "currentpage";
        //        //}

        //        pnPaging.Controls.Add(lnk);
        //        Label lbl = new Label();
        //        lbl.Text = " ";
        //        pnPaging.Controls.Add(lbl);

        //    }


        //}
        private void GeneratePaging(int p, int currentPage)
        {
            pnPaging.Controls.Clear();

            int begin = GetBeginningPage(currentPage);
            int last = Math.Min(p, begin + 10);
            LinkButton lnk;
            LinkButton Previous10 = new LinkButton();
            Previous10.ID = "Previous10";
            Previous10.Click += new EventHandler(Previous10_Click);
            Previous10.Text = "...";
            pnPaging.Controls.Add(Previous10);
            Previous10.Visible = HasPrevious();
            for (int i = begin; i < last; i++)
            {
                lnk = new LinkButton();
                lnk.ID = "Page" + (i + 1);
                lnk.Click += new EventHandler(lnk_Click);
                lnk.CommandArgument = i.ToString();
                lnk.Text = (i + 1).ToString();
                if (lnk.Text == (currentPage + 1).ToString())
                {
                    lnk.ForeColor = Color.HotPink;
                    lnk.BorderStyle = BorderStyle.Solid;
                    lnk.BorderColor = Color.LightBlue;
                    lnk.BorderWidth = Unit.Pixel(1);
                    //lnk.Attributes.["class"] = "currentpage";
                }
                pnPaging.Controls.Add(lnk);

            }
            LinkButton Next10 = new LinkButton();
            Next10.ID = "Next10";
            Next10.Click += new EventHandler(Next10_Click);
            Next10.Text = "...";
            Next10.Visible = HasNext();
            pnPaging.Controls.Add(Next10);

        }

        private int GetBeginningPage(int currentPage)
        {
            return (currentPage / 10 * 10);

        }
        protected void lnk_Click(object sender, EventArgs e)
        {
            
            CurrentPage = Convert.ToInt32(((LinkButton)sender).CommandArgument);

                         
            BindNoteList(NoteLength);        
        }
        protected void Previous10_Click(object sender, EventArgs e)
        {
            CurrentPage = (CurrentPage / 10 * 10) - 10;
            if (CurrentPage < 0) CurrentPage = 0;
            BindNoteList(NoteLength);  
        }

        protected void Next10_Click(object sender, EventArgs e)
        {
            CurrentPage = (CurrentPage / 10 * 10) + 10;
            if (CurrentPage > LastPage - 1) CurrentPage = LastPage - 1;
            BindNoteList(NoteLength);  
        }
        private bool HasPrevious()
        {
            return (CurrentPage > 9);
        }
        private bool HasNext()
        {
            return ((CurrentPage / 10 * 10) < LastPage - 10);
        }




    }
}
