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

namespace SimpleServings.UI.UDC.SimpleServings.ProgressNote
{
    public partial class ViewProgressNote : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["NoteID"] != null && Request["NoteID"].ToString() != "")
            {
                PopluateControls(Convert.ToInt32(Request["NoteID"]));
                if (Request["Msg"] != null && Request["Msg"].ToString() != "")
                {
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = Request["Msg"].ToString();
                }
            }
        }

        private void PopluateControls(int noteID)
        {
            SimpleServingsLibrary.Shared.ProgressNote note = new SimpleServingsLibrary.Shared.ProgressNote(noteID);
            lblNoteID.Text = note.NoteID.ToString();
            lblNoteType.Text = SimpleServingsLibrary.Shared.Code.DecodeCode(note.NoteType);
            lblCreatedBy.Text = note.CreatedByText;
            lblCreatedOn.Text = note.CreatedOn;
            lblNoteDescription.Text = note.NoteDescription;
        }
    }
}