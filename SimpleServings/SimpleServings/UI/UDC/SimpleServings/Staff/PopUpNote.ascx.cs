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
    public partial class PopUpNote : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        public void PopNotes(int staffID)
        {
            

            try
            {
                StaffNote staffNote = new StaffNote();
                StaffNoteList staffNotes = SimpleServingsLibrary.Shared.StaffNote.GetNewStaffNotesByStaffID(staffID,false);
                lblSummary.Text = string.Format(" {0} more note(s)", staffNotes.Count);
                
                if (staffNotes.Count > 0)
                {
                    staffNote = (StaffNote)staffNotes[0];
                    lblSender.Text = string.Format("<strong>From : </strong>{0}", staffNote.CreatedByText);
                    lblTime.Text = string.Format("<strong>On : </strong>{0}", staffNote.CreatedOn);
                    lblNote.Text = staffNote.Note;                
                }
            }

            catch 
            {
                lblSummary.Text = "No new notes found";
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Visible = true;
            }
        }

       


        public static bool HasNewNote(int staffID)
        {
            int count = 0;
            try
            {
                StaffNoteList staffNotes = SimpleServingsLibrary.Shared.StaffNote.GetNewStaffNotesByStaffID(staffID,false);
                count = staffNotes.Count;
            }
            catch 
            {
                count = 0;
            }
            return (count > 0);
           
        }

        protected void lnkCloseNote_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.StaffNote.MarkAsRead(HelpClasses.AppHelper.GetCurrentUser().StaffID);
            //SimpleServingsLibrary.Shared.StaffNote.MarkAsRead(((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
                       
        }

        protected void lnkViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/myZone.aspx?Control=MyNotes");
        }

        
       
       
       
    }
}