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
    public partial class MyStaff : System.Web.UI.UserControl
    {

        internal void InitializeControl()
        {

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");
            else PopGrid(staff.StaffID);

        }

       

        private void PopGrid(int staffID)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staffs staffList = SimpleServingsLibrary.Shared.Staff.GetStaffHierarchyByStaffID(staffID);

                StaffGrid1.PopGrid(staffList);
            }
            catch
            {
                StaffGrid1.PopGrid(null);
            }
        }

       
    }
}