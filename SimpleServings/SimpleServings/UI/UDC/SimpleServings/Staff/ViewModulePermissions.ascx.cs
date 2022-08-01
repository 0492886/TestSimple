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
    public partial class ViewModulePermissions : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool ShowEditCols
        {
            set
            {
                gvPermissions1.Columns[3].Visible = value;
               
            }
        }
        public void PopPermissions(int staffID, int groupID)
        {
            ViewState["StaffID"] = staffID;
            ViewState["GroupID"] = groupID;
            lblUserGroup.Text = SimpleServingsLibrary.Shared.UserGroup.GetUserGroupNameByID(groupID);
            gvPermissions1.DataSource = Code.GetCodesByType(Code.CodeTypes.Module);
            gvPermissions1.DataBind();

        }
        public void PopPermissions(int groupID)
        {
            ViewState["GroupID"] = groupID;
            lblUserGroup.Text = SimpleServingsLibrary.Shared.UserGroup.GetUserGroupNameByID(groupID);
            gvPermissions1.DataSource = Code.GetCodesByType(Code.CodeTypes.Module);
            gvPermissions1.DataBind();

        }

        protected void gvPermissions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int staffID = Convert.ToInt32(ViewState["StaffID"]);
            int groupID = Convert.ToInt32(ViewState["GroupID"]);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "")
                    return;

                int moduleID = Convert.ToInt32(e.Row.Cells[0].Text);
               
                try
                {
                    e.Row.Cells[2].Text = SimpleServingsLibrary.Shared.ModulePermission.GetGroupPermission(groupID, moduleID).ToString();
                }
                catch { }
            }
        }

        protected void gvPermissions_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
                e.Row.Cells[0].Visible = false;
        }

        

      
 

        //public bool ShowEditCols
        //{
        //    set
        //    {
        //        gvPermissions.Columns[5].Visible = value;
        //        gvPermissions.Columns[6].Visible = value;
        //    }
        //}
        //public void PopPermissions(int staffID, int groupID)
        //{
        //    ViewState["StaffID"] = staffID;
        //    ViewState["GroupID"] = groupID;
        //    lblUserGroup.Text = SimpleServingsLibrary.Shared.UserGroup.GetUserGroupNameByID(groupID);
        //    gvPermissions.DataSource = Code.GetCodesByType(Code.CodeTypes.Module);
        //    gvPermissions.DataBind();

        //}

        //protected void gvPermissions_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    int staffID = Convert.ToInt32(ViewState["StaffID"]);
        //    int groupID = Convert.ToInt32(ViewState["GroupID"]);

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        if (e.Row.Cells[0].Text == "")
        //            return;

        //        int moduleID = Convert.ToInt32(e.Row.Cells[0].Text);
        //        try
        //        {
        //            e.Row.Cells[2].Text = SimpleServingsLibrary.Shared.ModulePermission.GetModulePermission(moduleID, staffID, groupID).ToString();
        //        }
        //        catch { }
        //        try
        //        {
        //            e.Row.Cells[3].Text = SimpleServingsLibrary.Shared.ModulePermission.GetStaffPermission(staffID, moduleID).ToString();
        //        }
        //        catch { }
        //        try
        //        {
        //            e.Row.Cells[4].Text = SimpleServingsLibrary.Shared.ModulePermission.GetGroupPermission(groupID, moduleID).ToString();
        //        }
        //        catch { }
        //    }
        //}

        //protected void gvPermissions_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.Cells.Count > 1)
        //        e.Row.Cells[0].Visible = false;
        //}

        //public void ApplyPermissions(SimpleServingsLibrary.Shared.ModulePermissions permissions)
        //{
        //    foreach (GridViewRow itm in gvPermissions.Rows)
        //    {
        //        if (itm.RowType == DataControlRowType.DataRow)
        //        {
        //            int moduleID = Convert.ToInt32(itm.Cells[0].Text);
        //            itm.Cells[3].Text = ModulePermission.GetPermission(-1, moduleID, permissions, ModulePermission.PermissionType.Staff).ToString();

        //            GetModulePermission(itm);

        //        }
        //    }
        //}

        //private static void GetModulePermission(GridViewRow itm)
        //{
        //    string staffPermission = itm.Cells[3].Text;
        //    string groupPermission = itm.Cells[4].Text;

        //    Code code = new Code();
        //    code.GetCodeByCodeID(SimpleServingsLibrary.Shared.Code.GetCodeIDByDescriptionAndType(staffPermission, Code.CodeTypes.PermissionRole));
        //    int staffOrder = code.CodeOrder;
        //    code.GetCodeByCodeID(SimpleServingsLibrary.Shared.Code.GetCodeIDByDescriptionAndType(groupPermission, Code.CodeTypes.PermissionRole));
        //    int groupOrder = code.CodeOrder;

        //    if (staffOrder > groupOrder)
        //        itm.Cells[2].Text = itm.Cells[3].Text;
        //    else
        //        itm.Cells[2].Text = itm.Cells[4].Text;
        //}
 
    }
}