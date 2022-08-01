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

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class UserGroupList : System.Web.UI.UserControl
    {
        public Panel UserGroupPanel
        {
            get { return this.Panel1; }
        }
        public void PopUserGroup(int codeID)
        {
            Panel1.Visible = true;
            PopUserGroupData(codeID);
            lblCodeDescription.Text = SimpleServingsLibrary.Shared.Code.DecodeCode(codeID);
             

        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.Panel1.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        private void PopUserGroupData(int codeID)
        {
            lblCodeID.Text = codeID.ToString();
            try
            {
                SimpleServingsLibrary.Shared.UserGroups userGroups = SimpleServingsLibrary.Shared.UserGroup.GetAllUserGroup();
                cblUserGroup.DataSource = userGroups;
                cblUserGroup.DataValueField = "UserGroupID";
                cblUserGroup.DataTextField = "UserGroupName";
                cblUserGroup.DataBind();
            }
            catch { }
            try
            {
                SimpleServingsLibrary.Shared.UserGroupSettings userGroupSettings = SimpleServingsLibrary.Shared.UserGroupSetting.GetUserGroupSettingsByCodeID(codeID);

                foreach (SimpleServingsLibrary.Shared.UserGroupSetting userGroupSetting in userGroupSettings)
                {
                    cblUserGroup.Items.FindByValue(userGroupSetting.UserGroupID.ToString()).Selected = true;
                }

            }
            catch { }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleServingsLibrary.Shared.UserGroupSetting.DeleteUserGroupSettingsByCodeID(Convert.ToInt32(lblCodeID.Text));
            }
            catch { }
            foreach (ListItem itm in cblUserGroup.Items)
            {
                if (itm.Selected)
                {
                    SimpleServingsLibrary.Shared.UserGroupSetting userGroup = new SimpleServingsLibrary.Shared.UserGroupSetting();
                    userGroup.UserGroupID = Convert.ToInt32(itm.Value);
                    userGroup.CodeID = Convert.ToInt32(lblCodeID.Text);
                    userGroup.CreatedBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
                    userGroup.AddUserGroupSetting();
                }
            }
            
        }
        protected void lnkBtnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cblUserGroup.Items.Count; i++)
            {
                cblUserGroup.Items[i].Selected = true;
            }
            Panel1.Visible = true;
        }

        protected void lnkBtnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cblUserGroup.Items.Count; i++)
            {
                cblUserGroup.Items[i].Selected = false;
            }
            Panel1.Visible = true;
        }
    }
}