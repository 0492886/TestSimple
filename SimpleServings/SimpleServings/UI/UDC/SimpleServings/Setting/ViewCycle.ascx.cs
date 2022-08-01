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
using SimpleServingsLibrary.Menu;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class ViewCycle : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                try
                {
                    ApplyPermissions();
                    PopMenuCycle(SimpleServingsLibrary.Menu.MenuCycle.GetActiveMenuCycles());
                }
                catch (ApplicationException ex)
                {
                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                    lblErrorMsg.Text = ex.Message;
                }
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


        private void PopMenuCycle(SimpleServingsLibrary.Menu.MenuCycles menuCycles) 
        {
            try
            {
                this.gvMenuCycles.DataSource = menuCycles;
                this.gvMenuCycles.DataBind();
            }
            catch 
            {
                lblMsg.Text = "There are no menu cycles to display";
            }  
        }

        protected void lnkBtnRemove_Click(object sender, EventArgs e)
        {

            int menuCycleID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            try
            {
                SimpleServingsLibrary.Menu.MenuCycle.RemoveMenuCyclesByID(menuCycleID);
				PopMenuCycle();
            }
            catch { }


        }

		protected void chxAllMenuCycle_CheckedChanged(object sender, EventArgs e)
		{
			PopMenuCycle();
		}

		private void PopMenuCycle()
		{
			if (chxAllMenuCycle.Checked)
			{
				PopMenuCycle(SimpleServingsLibrary.Menu.MenuCycle.GetAllMenuCycles());
			}
			else
			{
				PopMenuCycle(SimpleServingsLibrary.Menu.MenuCycle.GetActiveMenuCycles());
			}
		}
    }
}