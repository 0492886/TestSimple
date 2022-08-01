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
    public partial class UserGroupList : System.Web.UI.UserControl
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

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        
        public void PopUserGroups()
        {
            try
            {
                SimpleServingsLibrary.Shared.UserGroups userGroups = SimpleServingsLibrary.Shared.UserGroup.GetAllUserGroup();
                gvUserGroups.DataSource = userGroups;
                gvUserGroups.DataBind();
            }
            catch
            {
                gvUserGroups.DataSource = null;
                gvUserGroups.DataBind();
            }
        }     
       

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=AddUserGroup");

        }

        protected void lnkEdit_Command(object sender, CommandEventArgs e)
        {
            int groupID = Convert.ToInt32(e.CommandArgument);
            
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=EditUserGroup&UserGroupID=" + groupID);
        }
        protected void gvUserGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int groupID;
            if (e.CommandName == "Remove")
            {
                groupID = Convert.ToInt32(e.CommandArgument);
                try
                {
                    Response.Redirect("~/UI/Page/MyZone.aspx?Control=RemoveUserGroup&UserGroupID=" + groupID);
                }
                catch { }
            }
            else if (e.CommandName == "UserList")
            {
                groupID = Convert.ToInt32(e.CommandArgument);
                try
                {
                    Response.Redirect("~/UI/Page/MyZone.aspx?Control=UserList&UserGroupID=" + groupID);
                }
                catch { }
            }
        }
        protected bool CanDelete()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            return SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Delete);
        }

        protected bool CanAdd()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            return SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add);
        }
        protected bool CanEdit()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            return SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit);
        }
    }
}