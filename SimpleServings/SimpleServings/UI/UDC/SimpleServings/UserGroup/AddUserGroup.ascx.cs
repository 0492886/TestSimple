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
using System.Drawing;

namespace SimpleServings.UI.UDC.SimpleServings.UserGroup
{
    public partial class AddUserGroup : System.Web.UI.UserControl
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

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        public void InitializeControl() 
        {
            
                GroupPermissions.PopAllModules();
                LinkRepeater.PopRepeater(SimpleServingsLibrary.Shared.Link.GetAllLinks());

                LinkRepeater.ShowSelectAllButtons = true;
                LinkRepeater.ShowCheckBoxes = true;
               
                ClearBoxes();
           
        }
        private void ClearBoxes()
        {
            SimpleServingsLibrary.Shared.Staff staff = HelpClasses.AppHelper.GetCurrentUser();  //(SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            this.txtComments.Text = "";
            this.txtUserGroupName.Text = "";
            lblCreatedBy.Text = staff.StaffID.ToString();
            try
            {
                lblCreatedByText.Text = SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(staff.StaffID);
            }
            catch { }
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlAccessLevel, Code.CodeTypes.AccessLevel,staff.UserGroup, "");
        }
       
        public string Msg
        {
            set {lblMsg.Text=value; }
        }
       

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
             try
             {
                 SimpleServingsLibrary.Shared.UserGroup userGroup = new SimpleServingsLibrary.Shared.UserGroup();
                 userGroup.UserGroupName = txtUserGroupName.Text;
                 userGroup.Description = txtComments.Text;
                 int accessLevel = 0;
                 Int32.TryParse(ddlAccessLevel.SelectedValue, out accessLevel);
                 userGroup.AccessLevel = accessLevel;                  
                 userGroup.CreatedBy = staff.StaffID;
                 try
                 {
                     lblCreatedByText.Text = SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(Convert.ToInt32(lblCreatedBy.Text));
                 }
                 catch { }
                 int groupID = userGroup.AddUserGroup();
                 if (groupID == 0)
                 {
                     lblMsg.ForeColor = Color.Red;
                     lblMsg.Text = string.Format("{0} group already exists!", txtUserGroupName.Text);
                 }
                 else
                 {
                     GroupPermissions.Save(groupID, ModulePermission.PermissionType.Group);
                     LinkRepeater.Save(groupID);
                     //AssessmentPermission1.Save(groupID);
                     lblMsg.ForeColor = Color.Green;
                     lblMsg.Text = "User Group added successfully";
                 }                 
             }
             catch (Exception ex)
             {
                 lblMsg.ForeColor = Color.Red;
                 lblMsg.Text = ex.Message;
             }
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=UserGroup");
        }

        
    }
}