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

namespace SimpleServings.UI.Page.SimpleServings.Staff
{
    public partial class StaffList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["UserGroupID"] != null && Request["UserGroupID"] != "")
                {
                    try
                    {
                        SimpleServingsLibrary.Shared.Staffs staffList = SimpleServingsLibrary.Shared.Staff.GetStaffByUserGroup(Convert.ToInt32(Request["UserGroupID"].ToString()));
                        StaffGrid1.PopGrid(staffList);
                    }
                    catch
                    {
                        StaffGrid1.PopGrid(null);
                    }
                }

            }
        }

        
    }
}
