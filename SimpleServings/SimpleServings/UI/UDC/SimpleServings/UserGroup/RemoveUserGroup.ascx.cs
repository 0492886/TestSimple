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
    public partial class RemoveUserGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
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

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Delete))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        public void InitializeControl(int userGroupID)
        {
            lblUserGroupID.Text = userGroupID.ToString();
            //hlnkUserList.NavigateUrl = string.Format("~/UI/Page/Faces/Staff/StaffList.aspx?UserGroupID={0}", userGroupID);
            SimpleServingsLibrary.Shared.UserGroup userGroup = new SimpleServingsLibrary.Shared.UserGroup();
            userGroup.FillUserGroupByID(userGroupID);
            lblGroupName.Text = userGroup.UserGroupName;
            try
            {
                SimpleServingsLibrary.Shared.Staffs staffList = SimpleServingsLibrary.Shared.Staff.GetStaffByUserGroup(userGroupID);
                lblMsgRemove.Text = string.Format("There are {0} active staff members associated with this user group [{1}]" +
                    "<br> You must either reassign these members to another user group or remove them if they are no longer active.", staffList.Count, this.lblGroupName.Text);
                btnRemove.Visible = false;
                btnCancel.Visible = false;

            }
            catch
            {
                lblMsgRemove.Text = string.Format("There are no staff members associated with this group [{0}]" +
                    "<br> Are you sure you want to remove this group", lblGroupName.Text);
                btnRemove.Visible = true;
                btnCancel.Visible = true;
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            int userGroupID = Convert.ToInt32(lblUserGroupID.Text);
            //if (SimpleServingsLibrary.Shared.UserGroup.DeactivateUserGroup(userGroupID, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID))
            if (SimpleServingsLibrary.Shared.UserGroup.DeactivateUserGroup(userGroupID, HelpClasses.AppHelper.GetCurrentUser().StaffID))
            {
                Response.Redirect("~/UI/Page/myzone.aspx?Control=UserGroup");
            }
        }
        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=UserGroup");
        }

        protected void btnUserList_Click(object sender, EventArgs e)
        {        
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=UserList&UserGroupID=" + Convert.ToInt32(lblUserGroupID.Text));
        }
    }
}