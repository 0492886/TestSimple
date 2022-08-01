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
    public partial class ModulePermissionsList : System.Web.UI.UserControl
    {
        public bool IsUsedInWizard
        {
            //get { return btnSave.Visible; }
            set { btnSave.Visible = !value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void PopAllModules()
        {
            this.rpModules.DataSource = Code.GetCodesByType(Code.CodeTypes.Module);
            this.rpModules.DataBind();

        }
        public void PopStaffPermissions(int staffID)
        {
            lblStaffID.Text = staffID.ToString();
            ApplyPermissions(staffID, ModulePermission.PermissionType.Staff);
        }
        public void PopGroupPermissions(int groupID)
        {
            ApplyPermissions(groupID, ModulePermission.PermissionType.Group);
        }


        private void ApplyPermissions(int id, ModulePermission.PermissionType type)
        {
            PopAllModules();
            int moduleID = 0;
            foreach (RepeaterItem itm in rpModules.Items)
            {
                if (itm.ItemType == ListItemType.Item || itm.ItemType == ListItemType.AlternatingItem)
                {
                    moduleID = Convert.ToInt32(((Label)itm.FindControl("lblModuleID")).Text);
                    RadioButtonList list = (RadioButtonList)itm.FindControl("rbAssignedRole");
                    try
                    {
                        if (type == ModulePermission.PermissionType.Staff)
                            list.Items.FindByText(ModulePermission.GetStaffPermission(id, moduleID).ToString()).Selected = true;
                        else if (type == ModulePermission.PermissionType.Group)
                            list.Items.FindByText(ModulePermission.GetGroupPermission(id, moduleID).ToString()).Selected = true;

                    }
                    catch { }
                }
            }
        }

        protected void rpModules_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    RadioButtonList list = (RadioButtonList)e.Item.FindControl("rbAssignedRole");
                    list.DataSource = Code.GetCodesByType(Code.CodeTypes.PermissionRole);
                    list.DataTextField = "CodeDescription";
                    list.DataValueField = "CodeID";
                    list.DataBind();
                    list.Items.FindByValue(SimpleServingsLibrary.Shared.GlobalEnum.NoPermission.ToString()).Selected = true;
                }
                catch (Exception ex)
                {
                    Label lbl = (Label)e.Item.FindControl("lblMsg");
                    lbl.Text = "no roles found" + ex.Message;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff.UpdateUserGroup(Convert.ToInt32(lblStaffID.Text), Convert.ToInt32(Session["UserGroup"]));
            }
            catch { }
            Save(Convert.ToInt32(lblStaffID.Text), ModulePermission.PermissionType.Staff);
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=ViewStaff&StaffID=" + Convert.ToInt32(lblStaffID.Text));
        }

        public void Save(int id, SimpleServingsLibrary.Shared.ModulePermission.PermissionType type)
        {
            if (type == ModulePermission.PermissionType.Staff)
            {
                ModulePermission.RemoveStaffPermissionsByID(id);
                SavePermissions(id, type);
            }
            else if (type == ModulePermission.PermissionType.Group)
            {
                ModulePermission.RemoveGroupPermissionsByID(id);
                SavePermissions(id, type);
            }
        }
        private void SavePermissions(int id, ModulePermission.PermissionType type)
        {
            int moduleID = 0;
            int permissionID = 0;
            foreach (RepeaterItem itm in rpModules.Items)
            {
                if (itm.ItemType == ListItemType.Item || itm.ItemType == ListItemType.AlternatingItem)
                {
                    moduleID = Convert.ToInt32(((Label)itm.FindControl("lblModuleID")).Text);

                    RadioButtonList list = (RadioButtonList)itm.FindControl("rbAssignedRole");

                    try
                    {
                        permissionID = Convert.ToInt32(list.SelectedValue);
                        if (type == ModulePermission.PermissionType.Staff)
                            ModulePermission.AddStaffPermission(id, moduleID, permissionID);
                        else if (type == ModulePermission.PermissionType.Group)
                            ModulePermission.AddGroupPermission(id, moduleID, permissionID);
                    }
                    catch { }
                }
            }
        }



        public SimpleServingsLibrary.Shared.ModulePermissions GetPermissions(int id, ModulePermission.PermissionType type)
        {
            SimpleServingsLibrary.Shared.ModulePermissions permissions = new SimpleServingsLibrary.Shared.ModulePermissions();
            ModulePermission permission;
            int moduleID = 0;
            int permissionID = 0;
            foreach (RepeaterItem itm in rpModules.Items)
            {
                permission = new ModulePermission();
                if (itm.ItemType == ListItemType.Item || itm.ItemType == ListItemType.AlternatingItem)
                {
                    moduleID = Convert.ToInt32(((Label)itm.FindControl("lblModuleID")).Text);

                    RadioButtonList list = (RadioButtonList)itm.FindControl("rbAssignedRole");

                    try
                    {
                        permissionID = Convert.ToInt32(list.SelectedValue);
                        if (type == ModulePermission.PermissionType.Staff)
                        {
                            permission.StaffID = id;
                            permission.ModuleID = moduleID;
                            permission.PermissionID = permissionID;
                            permissions.Add(permission);
                        }
                        else if (type == ModulePermission.PermissionType.Group)
                        {
                            permission.GroupID = id;
                            permission.ModuleID = moduleID;
                            permission.PermissionID = permissionID;
                            permissions.Add(permission);
                        }
                    }
                    catch { }
                }
            }
            return permissions;
        }
 
    }
}