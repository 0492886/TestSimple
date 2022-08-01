using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using SimpleServingsLibrary.Menu;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class AddEditCycle : System.Web.UI.UserControl
    {

        int MenuCycleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!IsPostBack) 
            {
                CheckAddOrEditMenuCycle();
            }
        }

        private void CheckAddOrEditMenuCycle()
        {
            string id = Request.QueryString["MenuCycleID"];
            if (id != null) //if in EDIT mode
            {
                btnSave.Visible = true;
                int menuCycleId = Convert.ToInt32(id);
                MenuCycleId = menuCycleId;
                PopEditMenuCycleInfo(menuCycleId);
                ddMenuCycleName.Enabled = false;
                
            }
            else 
            {
                PopCyclesDropDown("");
                btnSubmit.Visible = true;
               
            }
        }

        private void PopEditMenuCycleInfo(int menuCycleId)
        {
            MenuCycle menuCycle = new MenuCycle();
            menuCycle.GetMenuCycleById(menuCycleId);
            txtMenuCycleStartDate.Text = menuCycle.CycleStartDate;
            txtMenuCycleEndDate.Text = menuCycle.CycleEndDate;
            //isActive.Checked = menuCycle.IsActive;
            PopCyclesDropDown(menuCycle.CycleID.ToString());
        }
        private void PopCyclesDropDown(string oldValue)
        {

            int userGroupID = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddMenuCycleName, SimpleServingsLibrary.Shared.Code.CodeTypes.Cycle, userGroupID,oldValue );
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndDependsOnAndUserGroup(ddMenuCycleName, SimpleServingsLibrary.Shared.Code.CodeTypes.Cycle, Convert.ToInt32(ddMenuCycleName.SelectedValue), userGroupID, "0");
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
            
                MenuCycle menuCycle = new MenuCycle();
                menuCycle.CycleID = Convert.ToInt32(ddMenuCycleName.SelectedValue);
                menuCycle.CycleStartDate = txtMenuCycleStartDate.Text;
                menuCycle.CycleEndDate = txtMenuCycleEndDate.Text;
                menuCycle.CreatedBy = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
               // menuCycle.IsActive = isActive.Checked;
                bool added = menuCycle.AddMenuCycle();
                Response.Redirect("~/UI/Page/MyZone.aspx?Control=MenuCycle");
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = ex.Message.ToString();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["MenuCycleID"];                
                Int32.TryParse(id,out MenuCycleId);
                MenuCycle menuCycle = new MenuCycle();
                menuCycle.MenuCycleID = MenuCycleId;
                menuCycle.CycleID = Convert.ToInt32(ddMenuCycleName.SelectedValue);
                menuCycle.CycleStartDate = txtMenuCycleStartDate.Text;
                menuCycle.CycleEndDate = txtMenuCycleEndDate.Text;
                menuCycle.CreatedBy = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
                //menuCycle.IsActive = isActive.Checked;
                bool edited = menuCycle.EditMenuCycle();
                Response.Redirect("~/UI/Page/MyZone.aspx?Control=MenuCycle");
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = ex.Message.ToString();
            }
        }

    }
}