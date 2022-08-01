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
    public partial class ActivateStaff : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        public void InitializeControl(int staffID)
        {
            ViewGeneralInfo1.PopGeneralInfo(staffID);
            lblStaffID.Text = staffID.ToString();
            
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {

       
            int staffID = Convert.ToInt32(lblStaffID.Text);
            try
            {
                SimpleServingsLibrary.Shared.Staff.ActivateStaffByStaffID(staffID);
                Response.Redirect("~/UI/Page/MyZone.aspx?Control=ManageStaff");


            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/MyZone.aspx?Control=MyProfile&StaffID={0}",Convert.ToInt32(lblStaffID.Text)));
        }

    }
}

        