using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SimpleServings.UI.Page.SimpleServings.Menu
{
    public partial class AddMenuItemTest : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {

                if (Request["MenuID"] != null)
                {
                    int menuID = 0;
                    Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                    lblMenuID.Text = menuID.ToString();
                }
            }

        }

        public MenuInfos getMenuInfo() {

            MenuInfos menuInfos = new MenuInfos();
            string Id = MenuItemsId.Value;
            string[] menuItemId = Id.Split(',');
            int[] menuItemIds = new int[menuItemId.Length];
            
            for(int i=0; i<menuItemId.Length; i++){
                if(SimpleServingsLibrary.Shared.Validation.IsNumber(menuItemId[i]))
                    menuItemIds[i] = Convert.ToInt32(menuItemId[i]);
            }

            getAllInfo(menuInfos, menuItemIds);
            return menuInfos;
        }

        private void getAllInfo(MenuInfos menuInfos, int[] menuItemIds)
        {
            MenuInfo mondayMenu;
            int week = Convert.ToInt32(WeekNumber.Value);
            int menuID=0;
            int dayID=0;
            int valK = 1;
            Int32.TryParse(lblMenuID.Text,out menuID);
            SimpleServingsLibrary.Menu.MenuDays menuDays=
            SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
            foreach (SimpleServingsLibrary.Menu.MenuDay menuDay in menuDays)
            {
                dayID = menuDay.DayOfWeekID;
            

                for (int i = 0; i < menuItemIds.Length; i++)
                {
                    string meanuId = (string)Request["Row" + (i + 1) + "Col" + valK];
                    if (meanuId != "")
                    {
                        mondayMenu = new MenuInfo();
                        mondayMenu.Day = dayID;
                        mondayMenu.MenuItemId = menuItemIds[i];
                        mondayMenu.Week = week;
                        string[] meanuIds = meanuId.Split(',');
                        
                        for (int j = 0; j < meanuIds.Length; j++)
                        {

                            string result = Regex.Match(meanuIds[j], @"\d+").Value;
                            if (mondayMenu.RecipeID == null || mondayMenu.RecipeID == "")
                            {
                                mondayMenu.RecipeID += result;
                            }
                            else 
                            {
                                mondayMenu.RecipeID = mondayMenu.RecipeID +","+result;
                            }

                        }
                        menuInfos.Add(mondayMenu);
                    }
                }
                valK++;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            MenuInfos menuInfos = getMenuInfo();



            bool added = false;
            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            try
            {
                
                SimpleServingsLibrary.Menu.MenuItem menuItem = new SimpleServingsLibrary.Menu.MenuItem();
                foreach (MenuInfo menuInfo in menuInfos)
                {
                    
                    menuItem.MenuID = menuID;
                    menuItem.DayOfWeekID = menuInfo.Day;
                    menuItem.WeekInCycle = (short)menuInfo.Week;
                    menuItem.MenuItemTypeID = menuInfo.MenuItemId;
                    menuItem.CreatedBy = staff.StaffID;
                    int recipeID = 0;
                    foreach (string recipeIDText in menuInfo.RecipeID.Split(','))
                    {
                        Int32.TryParse(recipeIDText, out recipeID);
                        menuItem.RecipeID = recipeID;
                        //remove try catch after debugging
                        try
                        {
                            menuItem.AddMenuItem();
                        }
                        catch { }
                    }
                }
                
                added = true;
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;

            }
            if (added)
            {
                Response.Redirect("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID=" + menuID);
            }
        }
         

    }

    
}