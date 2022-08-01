using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuItems : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopDropDowns();
                int menuID = 0;
                if (Request["MenuID"] != null)
                {
                    Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                    lblMenuID.Text = menuID.ToString();
                }
                PopRepeater();
            }
        }
        private void PopDropDowns()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            for (int i = 1; i <= 6; i++)
            {
                ddlWeek.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlWeek.DataBind();
        }
        public void PopRepeater()
        {
            SimpleServingsLibrary.Menu.MenuItemTypes menuItemTypes = GetMenuItemTypes();
            if (menuItemTypes != null)
            {
                this.rptMenuItemTypes.DataSource = menuItemTypes;
                this.rptMenuItemTypes.DataBind();

            }
            else
            {
                this.rptMenuItemTypes.DataSource = null;
                this.rptMenuItemTypes.DataBind();
                
            }
        }
        protected SimpleServingsLibrary.Menu.MenuItemTypes GetMenuItemTypes()
        {
            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            SimpleServingsLibrary.Menu.MenuItemTypes menuItemTypes = new SimpleServingsLibrary.Menu.MenuItemTypes();
            try
            {
                menu.GetMenuByMenuID(Convert.ToInt32(lblMenuID.Text));
                menuItemTypes = SimpleServingsLibrary.Menu.MenuItemType.GetAllMenuItemTypes(menu.MealServedTypeID);
            }
            catch { }
            return menuItemTypes;
        }
        protected SimpleServingsLibrary.Menu.MenuDays GetDaysOfWeekByMenuID()
        {
            int menuID=0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            SimpleServingsLibrary.Menu.MenuDays menuDays = new SimpleServingsLibrary.Menu.MenuDays();
            try
            {
                menuDays = SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
            }
            catch { }
            return menuDays;
        }
        protected SimpleServingsLibrary.Menu.MenuItems GetMenuItemsByMenuAndItemTypeAndDayAndWeek(object menuIDObj, object menuItemTypeIDObj, object dayOfWeekIDObj)
        {
            int menuID = 0;
            Int32.TryParse(menuIDObj.ToString(), out menuID);
            int menuItemTypeID = 0;
            Int32.TryParse(menuItemTypeIDObj.ToString(), out menuItemTypeID);
            int dayOfWeekID = 0;
            Int32.TryParse(dayOfWeekIDObj.ToString(), out dayOfWeekID);
            int weekInCycle = 0;
            Int32.TryParse(ddlWeek.SelectedValue, out weekInCycle);

            SimpleServingsLibrary.Menu.MenuItems menuItems = new SimpleServingsLibrary.Menu.MenuItems();
            try
            {
                menuItems = SimpleServingsLibrary.Menu.MenuItem.GetMenuItemsByMenuAndItemTypeAndWeekAndDay(menuID, menuItemTypeID, weekInCycle, dayOfWeekID);
            }
            catch { }
            return menuItems;
        }

        protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopRepeater();
        }
    }
}