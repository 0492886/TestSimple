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
    public partial class StaffNotesList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopAllNotes(int staffID)
        {
            lblSummary.Text = String.Empty;
            SimpleServingsLibrary.Shared.StaffNoteList staffNotes;
            try
            {
                if (chxShowNew.Checked)
                {
                    staffNotes = SimpleServingsLibrary.Shared.StaffNote.GetNewStaffNotesByStaffID(staffID, chxShowEntire.Checked);
                }
                else
                    staffNotes = SimpleServingsLibrary.Shared.StaffNote.GetAllStaffNotesByStaffID(staffID, chxShowEntire.Checked);

                dlStaffNotes.DataSource = staffNotes;
                dlStaffNotes.DataBind();

                lblSummary.Text = string.Format("{0} note(s) received", staffNotes.Count);
                lblSummary.ForeColor = System.Drawing.Color.SteelBlue;
                lblSummary.Visible = true;
            }

            catch 
            {
                lblSummary.Text = "No notes found";
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Visible = true;
            }
        }





        protected void chxShowEntire_CheckedChanged(object sender, EventArgs e)
        {
            PopAllNotes(HelpClasses.AppHelper.GetCurrentUser().StaffID);
            //PopAllNotes(((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
        }

        protected void chxShowNew_CheckedChanged(object sender, EventArgs e)
        {
            PopAllNotes(HelpClasses.AppHelper.GetCurrentUser().StaffID);
            //PopAllNotes(((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
        }

        protected void lnkMarkAsRead_Click(object sender, EventArgs e)
        {
            int noteID = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
            SimpleServingsLibrary.Shared.StaffNote.MarkNoteAsRead(noteID);
            PopAllNotes(HelpClasses.AppHelper.GetCurrentUser().StaffID);
            //PopAllNotes(((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);


        }

        

        
        

        

        


        

       

       

    }
}

