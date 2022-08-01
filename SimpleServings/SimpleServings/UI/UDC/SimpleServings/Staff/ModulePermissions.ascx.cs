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
    public partial class ModulePermissions : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (!IsUsedInWizard)
                {
                    ModulePermissionsList1.PopAllModules();                    
                    PopDropDown(Convert.ToInt32(Request["GroupID"]));
                    this.ViewModulePermissions1.PopPermissions(Convert.ToInt32(Request["StaffID"]), Convert.ToInt32(ddUserGroup.SelectedValue));
                    //this.ViewModulePermissions1.PopPermissions(-1, Convert.ToInt32(ddUserGroup.SelectedValue));
                    try
                    {
                        Session["UserGroup"] = ddUserGroup.SelectedValue;
                    }
                    catch { }
                }
            }
        }
        
        public void SetStaffPermissions(int staffID)
        {        
            SimpleServingsLibrary.Shared.Staff staff=new SimpleServingsLibrary.Shared.Staff(staffID);
            PopDropDown(staff.UserGroup);
            ViewModulePermissions1.PopPermissions(staff.StaffID, staff.UserGroup);
            ModulePermissionsList1.PopStaffPermissions(staff.StaffID);
        }
        public void PopDropDown(int oldValue)
        {
            this.ddUserGroup.DataSource = SimpleServingsLibrary.Shared.UserGroup.GetAllUserGroup();
            this.ddUserGroup.DataTextField = "UserGroupName";
            this.ddUserGroup.DataValueField = "UserGroupID";
            this.ddUserGroup.DataBind();
            //if (oldValue==0)
            //   ddUserGroup.Items.FindByValue("4").Selected = true;

            if (oldValue!=0)
                ddUserGroup.Items.FindByValue(oldValue.ToString()).Selected = true;
        }

        protected void ddUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["UserGroup"] = ddUserGroup.SelectedValue;
            PopDropDown(Convert.ToInt32(ddUserGroup.SelectedValue));
            this.ViewModulePermissions1.PopPermissions(-1, Convert.ToInt32(ddUserGroup.SelectedValue));
            //ViewModulePermissions1.ApplyPermissions(ModulePermissionsList1.GetPermissions(-1, SimpleServingsLibrary.Shared.ModulePermission.PermissionType.Staff));
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
           // ViewModulePermissions1.ApplyPermissions(ModulePermissionsList1.GetPermissions(-1, SimpleServingsLibrary.Shared.ModulePermission.PermissionType.Staff));
        }

        public bool IsUsedInWizard
        {
            //get { return ModulePermissionsList1.IsUsedInWizard; }
            set 
            {
                 //btnPreview.Visible = !value;
                 //BtnSave.Visible = !value;
                 ModulePermissionsList1.IsUsedInWizard = value;
            }
        }

        public int UserGroupID
        {
            get { return Convert.ToInt32(this.ddUserGroup.SelectedValue); }
        }
        
        public void SaveStaffPermissions(int staffID)
        {
            ModulePermissionsList1.Save(staffID, ModulePermission.PermissionType.Staff);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int staffID = Convert.ToInt32(((Label)ModulePermissionsList1.FindControl("lblStaffID")).Text);
            ModulePermissionsList1.Save(staffID, ModulePermission.PermissionType.Staff);
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=ViewStaff&StaffID=" + staffID);
        }
    }
}