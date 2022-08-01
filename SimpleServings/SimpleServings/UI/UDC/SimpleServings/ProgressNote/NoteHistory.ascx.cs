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
    public partial class NoteHistory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        }
        public void PopProgressNotes(int referenceID, int noteType, int noteLength)
        {
            lblRefID.Text = referenceID.ToString();
            lblNoteTypeID.Text = noteType.ToString();
            try
            {
                ProgressNotes progressNotes;
                progressNotes = SimpleServingsLibrary.Shared.ProgressNote.GetProgressNotesByReferenceIDNoteType(referenceID, noteType, noteLength);
                dlProgressNotes.DataSource = progressNotes;
                dlProgressNotes.DataBind();
                //this.lblCount.ForeColor = System.Drawing.Color.SteelBlue;
                //this.lblCount.Text = string.Format("{0} Record(s) found", progressNotes.Count);                
            }
            catch
            {
                dlProgressNotes.DataSource = null;
                dlProgressNotes.DataBind();
                //lblCount.ForeColor = Color.Red;
                //lblCount.Text = "No Record(s) found";
            }
        }

        protected void dlProgressNotes_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Remove")
                {
                    int noteID = Convert.ToInt32(((Label)e.Item.FindControl("lblNoteID")).Text);
                    int removeBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
                    SimpleServingsLibrary.Shared.ProgressNote.RemoveNoteByNoteID(Convert.ToInt32(noteID), removeBy);
                    PopProgressNotes(Convert.ToInt32(lblRefID.Text),Convert.ToInt32(lblNoteTypeID.Text),90);                   
                }
            }
            catch { }
        }
        protected bool CanDelete()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            return SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit);
        }
    }
}