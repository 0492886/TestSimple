using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class ViewMenuItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             try
            {
                ApplyPermissions();
                int menuItemID = 0;
                lblMsg.Text = String.Empty;
                if (!Page.IsPostBack)
                {

                    if (Request["MenuItemID"] != null)
                    {
                        Int32.TryParse(Request["MenuItemID"].ToString(), out menuItemID);
                        
                        PopMenuItem(menuItemID);
                       
                    }

                }
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
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }

        }

        


        private void PopMenuItem(int menuItemID)
        {
            SimpleServingsLibrary.Menu.MenuItem menuItem = new SimpleServingsLibrary.Menu.MenuItem();
            try
            {
                menuItem.GetMenuItemByMenuItemID(menuItemID);
                lblWeek.Text = menuItem.WeekInCycle.ToString();
                lblDay.Text = menuItem.DayOfWeekIDText;
                lblMenuItemType.Text = menuItem.MenuItemTypeIDText;
                lblRecipeName.Text = menuItem.RecipeName;              
                
            }
            catch
            { }
        }

        
    }
}

 