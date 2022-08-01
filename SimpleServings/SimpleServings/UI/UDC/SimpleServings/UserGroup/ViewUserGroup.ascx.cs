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

namespace SimpleServings.UI.UDC.SimpleServings.UserGroup
{
    public partial class ViewUserGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
                if (!Page.IsPostBack)
                {
                    if (Request["UserGroupID"] != null && Request["UserGroupID"].ToString() != "")
                    {
                        int userGroupID = Convert.ToInt32(Request["UserGroupID"].ToString());
                        lblUserGroupID.Text = userGroupID.ToString();
                        PopUserGroup(userGroupID);
                    }
                }
            }
            catch (ApplicationException ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
            

        }
        
        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        private void PopUserGroup(int userGroupID)
        {
            lblUserGroupID.Text = userGroupID.ToString();
            SimpleServingsLibrary.Shared.UserGroup userGroup = new SimpleServingsLibrary.Shared.UserGroup();
            userGroup.FillUserGroupByID(userGroupID);
            lblUserGroupName.Text = userGroup.UserGroupName;
            lblComments.Text = userGroup.Description;
            //lblCasePermission.Text = userGroup.CasePermissionText;
            
            lblCreatedBy.Text = userGroup.CreatedBy.ToString();
            lblCreatedByText.Text = userGroup.CreatedByText;
            
        }
    }

}