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
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.UserGroup
{
    public partial class EditUserGroup : System.Web.UI.UserControl
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

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        
        public string Msg
        {
            set { lblMsg.Text = value; }
        }
        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debugger.Launch();
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");


            try
                {
                    SimpleServingsLibrary.Shared.UserGroup userGroup = new SimpleServingsLibrary.Shared.UserGroup();
                    userGroup.UserGroupID = Convert.ToInt32(lblUserGroupID.Text);
                    userGroup.UserGroupName = txtUserGroupName.Text;
                    userGroup.Description = txtComments.Text;
                    int accessLevel = 0;
                    Int32.TryParse(ddlAccessLevel.SelectedValue, out accessLevel);
                    userGroup.AccessLevel = accessLevel;
                    userGroup.CreatedBy = staff.StaffID;
                    int groupID = userGroup.UpdateUserGroup();
                    GroupPermissions.Save(groupID, ModulePermission.PermissionType.Group);
                    LinkRepeater.Save(groupID);

                    //AssessmentPermission1.Save(groupID);
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "Your changes have been saved";
                    //Response.Redirect("~/UI/Page/myzone.aspx?Control=UserGroup");
                }

                catch (Exception ex)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = ex.Message;
                }
            
        }
        public void PopUserGroup(int userGroupID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            lblUserGroupID.Text = userGroupID.ToString();
            //hlnkUserList.NavigateUrl= string.Format("~/UI/Page/Faces/Staff/StaffList.aspx?UserGroupID={0}",userGroupID);
            SimpleServingsLibrary.Shared.UserGroup userGroup = new SimpleServingsLibrary.Shared.UserGroup();
            userGroup.FillUserGroupByID(userGroupID);
            txtUserGroupName.Text = userGroup.UserGroupName;
            txtComments.Text = userGroup.Description;
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlAccessLevel, Code.CodeTypes.AccessLevel, staff.UserGroup, "");
            try
            {
                ddlAccessLevel.ClearSelection();
                ddlAccessLevel.Items.FindByValue(userGroup.AccessLevel.ToString()).Selected = true;
            }
            catch { }
            lblCreatedBy.Text = userGroup.CreatedBy.ToString();
            lblCreatedByText.Text = userGroup.CreatedByText;
            GroupPermissions.PopAllModules();
            GroupPermissions.PopGroupPermissions(userGroupID);
            
            LinkRepeater.PopRepeater(userGroupID);
            LinkRepeater.ShowSelectAllButtons = true;
            LinkRepeater.ShowCheckBoxes = true;

            //AssessmentPermission1.PopAssessmentPermission(userGroupID);
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=UserGroup");
        }

             


    }
}