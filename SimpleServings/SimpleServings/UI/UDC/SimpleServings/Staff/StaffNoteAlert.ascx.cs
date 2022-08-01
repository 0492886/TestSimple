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



namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class StaffNoteAlert : System.Web.UI.UserControl
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
                lblSummary.Text = string.Format("{0} new note(s) received", staffNotes.Count);
                if (staffNotes.Count > 0)
                {
                    staffNote = (StaffNote)staffNotes[0];
                    lblSender.Text = string.Format("last note is sent by {0}", SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(staffNote.CreatedBy));
                    lblTime.Text = string.Format(" on {0}", staffNote.CreatedOn);
                    lblNote.Text = staffNote.Note;
                }
            }
            catch (Exception)
            {
                lblSummary.Text = "No notes found";
                lblSummary.ForeColor = Color.Red;
                lblSummary.Visible = true;
            }
        }
    }
}