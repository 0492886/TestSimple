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

namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class ViewComments : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void PopComments(int staffID)
        {
            try
            {
                SimpleServingsLibrary.Shared.StaffComments staffComments;
                staffComments = SimpleServingsLibrary.Shared.StaffComment.GetCommentsByStaffID(staffID);

                dlComments.DataSource = staffComments;
                dlComments.DataBind();
                lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
                lblMsg.Text = staffComments.Count + " Comment(s) found";

            }
            catch
            {
                dlComments.DataSource = null;
                dlComments.DataBind();
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "No Comments found";
            }
        }
    }
}