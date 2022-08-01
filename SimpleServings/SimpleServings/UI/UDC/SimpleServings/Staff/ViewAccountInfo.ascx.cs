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
    public partial class ViewAccountInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void PopAccounInfo(int staffID)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                staff.GetStaffByStaffID(staffID);
                PopStaff(staff);
            }
            catch
            {
                lblMsg.Text = string.Format("Could not load staff with staffID {0}", staffID);

            }
        }
        private void PopStaff(SimpleServingsLibrary.Shared.Staff staff)
        {
            lblUserName.Text = staff.UserName;
            lblEmail.Text = staff.Email;
            //lblTheme.Text = staff.ThemeName;
        }
 
    }
}