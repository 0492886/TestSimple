using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.Page.SimpleServings.Menu
{
    public partial class AddMenuItem : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            DragMenuItems1.BubbledRemoveButtonClick += new EventHandler(DragMenuItems1_BubbledRemoveButtonClick);
            DragMenuItems1.BubbledCompleteButtonClick += new EventHandler(DragMenuItems1_BubbledCompleteButtonClick);

                if (Request["MenuID"] != null)
                {
                    int menuID = 0;
                    Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                    lblMenuID.Text = menuID.ToString();
                    short week = 0;
                    //on 1st visit read week from request, otherwise from drop down
                    if (!Page.IsPostBack)
                    {
                        short.TryParse(Request["WeekSelected"], out week);
                    }
                    else week = DragMenuItems1.SelectedWeek;
                    //PopMeter(menuID, week);


                    try
                    {
                        SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                        menu.GetMenuByMenuID(menuID);
                        bool completed = (SimpleServingsLibrary.Menu.Menu.IsMenuWeekComplete(menuID, week) || menu.MenuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_Approved); 
                        if (completed) lblIsComplete.Text = "1";
                        else lblIsComplete.Text = "0";

                        //The only users who should be able to edit menus when they are submitted to DFTA are DFTA users and admin. 
                        var allowedUserGroups = new[] {SimpleServingsLibrary.Shared.UserGroup.ADMIN,
                                                SimpleServingsLibrary.Shared.UserGroup.DFTASUP,
                                                SimpleServingsLibrary.Shared.UserGroup.DFTAUSER};


                        if (!(menu.MenuStatus != GlobalEnum.MenuStatus_SubmittedToDFTA || allowedUserGroups.Contains(staff.UserGroup)))
                        {
                            pnPage.Visible = false;
                            lblpnMsg.ForeColor = System.Drawing.Color.Red;
                            lblpnMsg.Text = "You are not allowed to access this page!";
                        }
                        else
                        {
                            //07-27-2016
                            lblMsg.CssClass = "informNote"; //"warnNote";
                            lblMsg.Text = "Instructions: <br />&nbsp;&nbsp;&nbsp; * Hold the Ctrl key while drag-dropping menu items within the grid to copy and paste. <br/>&nbsp;&nbsp;&nbsp; * Click on Done when you are finished.";
                        }
                    }
                    catch { }
                    
                }
                   
                
            }
        protected void DragMenuItems1_BubbledCompleteButtonClick(object sender, EventArgs e)
        {
            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            short week = DragMenuItems1.SelectedWeek;
            try
            {
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                menu.GetMenuByMenuID(menuID);
                bool completed = (SimpleServingsLibrary.Menu.Menu.IsMenuWeekComplete(menuID, week) || menu.MenuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_Approved); 
                if (completed) lblIsComplete.Text = "1";
                else lblIsComplete.Text = "0";
            }
            catch { }
              
        }
        protected void DragMenuItems1_BubbledRemoveButtonClick(object sender, EventArgs e)
        {
            //int menuID = 0;
            //Int32.TryParse(lblMenuID.Text, out menuID);
            //PopMeter(menuID, DragMenuItems1.SelectedWeek);         
        }

        //public void PopMeter(int menuID, short weekInCycle)
        //{
        //    lblMeterLow.Text = string.Empty;
        //    lblMeterNormal.Text = string.Empty;
        //    lblMeterHigh.Text = string.Empty;

        //    SimpleServingsLibrary.MenuThreshold.MenuThresholds ts =
        //   SimpleServingsLibrary.MenuThreshold.MenuThreshold.GetMenuThresholdsWeekly(menuID, weekInCycle);

        //    foreach (SimpleServingsLibrary.MenuThreshold.MenuThreshold t in ts)
        //    {
        //        if (t.MeterColor.ToLower().Contains("low"))
        //        {
        //            lblMeterLow.Text += " <span class=\"bulletArrow\"></span> " + t.NutrientName ;                   
        //        }
        //        else if (t.MeterColor.ToLower().Contains("high"))
        //        {
        //            lblMeterHigh.Text += " <span class=\"bulletArrow\"></span> " + t.NutrientName;               
        //        }
        //        else if (t.MeterColor.ToLower().Contains("range"))
        //        {
        //            lblMeterNormal.Text += " <span class=\"bulletArrow\"></span> " + t.NutrientName;             
        //        }
               
        //    }
            
        //}

        //[System.Web.Services.WebMethod]
        //public static SimpleServingsLibrary.MenuThreshold.MenuThresholds UpdateMenuMeter(string menuID, string weekSelected)
        //{
        //    int menuIDInt = 0;
        //    Int32.TryParse(menuID, out menuIDInt);
        //    Int16 weekInCycle = 0;
        //    Int16.TryParse(weekSelected, out weekInCycle);

        //    SimpleServingsLibrary.MenuThreshold.MenuThresholds ts =
        //   SimpleServingsLibrary.MenuThreshold.MenuThreshold.GetMenuThresholdsWeekly(menuIDInt, weekInCycle);
        //    return ts;
        //}

        


        [System.Web.Services.WebMethod]
        public static void RemoveMenuItem(string removeId)
        {

            int menuItemID = 0;
            Int32.TryParse(removeId, out menuItemID);
            if (menuItemID != 0)
            {
                try
                {
                    SimpleServingsLibrary.Menu.MenuItem menuItem = new SimpleServingsLibrary.Menu.MenuItem();
                    menuItem.GetMenuItemByMenuItemID(menuItemID);
                    menuItem.RemoveMenuItem();
                }
                catch
                {
                    
                }
            }
            
        }
        
        [System.Web.Services.WebMethod]
        public static SimpleServingsLibrary.Menu.MenuItem GetUserInfo(string menuID, string menuItemTypeIDText, string weekSelected, string DayOfWeekID, string recipeIdText, string removeId, string IsSampleMenuItem, string originalId)
        {
            SimpleServingsLibrary.Menu.MenuItem newMenuItem = new SimpleServingsLibrary.Menu.MenuItem();
            SimpleServingsLibrary.Menu.MenuItem initialMenuItem = new SimpleServingsLibrary.Menu.MenuItem();
            try
            {
                int menuItemID = 0;
                Int32.TryParse(removeId, out menuItemID);
                if (menuItemID != 0)
                {
                    
                    initialMenuItem.GetMenuItemByMenuItemID(menuItemID);  //get original menu Mandy
                    if (menuItemTypeIDText == initialMenuItem.MenuItemTypeID.ToString() && DayOfWeekID == initialMenuItem.DayOfWeekID.ToString() && recipeIdText == initialMenuItem.RecipeID.ToString())
                        return initialMenuItem;
                    initialMenuItem.RemoveMenuItem();   //not complete can modify, otherwise can't Mandy
                }
                
                int menuIDInt = 0, menuItemTypeID = 0;

                Int32.TryParse(menuID, out menuIDInt);
                newMenuItem.MenuID = menuIDInt;

                Int32.TryParse(menuItemTypeIDText, out menuItemTypeID);
                newMenuItem.MenuItemTypeID = menuItemTypeID;
                
                Int16 weekInCycle = 0;
                Int16.TryParse(weekSelected, out weekInCycle);
                newMenuItem.WeekInCycle = weekInCycle;

                int dayOfWeekID = 0;
                Int32.TryParse(DayOfWeekID, out dayOfWeekID);
                newMenuItem.DayOfWeekID = dayOfWeekID;

                int recipeId = 0;
                Int32.TryParse(recipeIdText, out recipeId);
                newMenuItem.RecipeID = recipeId;

                bool _isSampleMenuItem;
                bool.TryParse(IsSampleMenuItem, out _isSampleMenuItem);
                newMenuItem.IsSampleMenuItem = _isSampleMenuItem;

                
                newMenuItem.MenuItemID = SaveMenuItem(newMenuItem);

                if (_isSampleMenuItem)
                updateMenuItemChanges(menuIDInt, removeId, originalId, initialMenuItem, newMenuItem);

            }
            catch (Exception ex)
            {
                if (ex.Message == "SessionEnded")
                    newMenuItem.MenuItemID = -1;
            }
            
            return newMenuItem;
        }

        [System.Web.Services.WebMethod]
        public static void ToggleIsAlternate(string menuItemIDText)
        {
            int menuItemID = 0;
            Int32.TryParse(menuItemIDText, out menuItemID);
            try
            {
                SimpleServingsLibrary.Menu.MenuItem menuItem = new SimpleServingsLibrary.Menu.MenuItem();
                menuItem.GetMenuItemByMenuItemID(menuItemID);

                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)HttpContext.Current.Session["UserObject"];
                if (staff == null)
                {
                    HttpContext.Current.Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                }
                menuItem.CreatedBy = staff.StaffID;


                menuItem.ToggleIsAlternate();
                
            }
            catch { }
        }


        [System.Web.Services.WebMethod]
        public static void CopyMenuItems(string selWeek_day, string MenuItemID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)HttpContext.Current.Session["UserObject"];

            int menuID = 0;
            SimpleServingsLibrary.Menu.Menu _menu = new SimpleServingsLibrary.Menu.Menu();
            SimpleServingsLibrary.Menu.MenuItem menuitem = new SimpleServingsLibrary.Menu.MenuItem();

            int menuitemID = 0;
            Int32.TryParse(MenuItemID, out menuitemID);
            menuitem.GetMenuItemByMenuItemID(menuitemID);
            
            menuID = menuitem.MenuID;
            _menu.GetMenuByMenuID(menuID);

            try
            {
                string[] strarray = selWeek_day.Split(',');


                for (int i = 0; i < strarray.Length - 1; i++)
                {
                    short week = 0;
                    int day = 0;

                    string Week = strarray[i].Substring(0, 1);
                    string Day = "7" + strarray[i].Substring(2, 1);
                    short.TryParse(Week, out week);
                    Int32.TryParse(Day, out day);
                    
                    menuitem.WeekInCycle = week;
                    menuitem.DayOfWeekID = day;
                    menuitem.CreatedBy = staff.StaffID;
                    
                    if (_menu.MenuTypeID != GlobalEnum.SampleMenu)
                    {
                        menuitem.IsSampleMenuItem = false; 
                    }
                    menuitem.AddMenuItem();
                }

            }
            catch (Exception ex)
            {
 
            }        
        }



        private static int SaveMenuItem(SimpleServingsLibrary.Menu.MenuItem menuItem)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)HttpContext.Current.Session["UserObject"];
            int resultId = 0;
            if (staff == null)
            {
                //throw new Exception("SessionEnded");
                HttpContext.Current.Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            }
                menuItem.CreatedBy = staff.StaffID;
            try
            {
                resultId = menuItem.AddMenuItem();   
            }
            catch 
            {
                
            }
            return resultId;
            
        }

        //(int MenuID, int RecipeID, int WeekInCycle, int OriginalDayOfWeekID, int OriginalMenuItemTypeID,
        //int NewDayOfWeekID, int NewMenuItemTypeID, string CreatedOn, int CreatedBy, string Action)
        public static void updateMenuItemChanges(int MenuID, string removeId, string originalId, SimpleServingsLibrary.Menu.MenuItem InitialMenuItem, SimpleServingsLibrary.Menu.MenuItem NewMenuITem)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)HttpContext.Current.Session["UserObject"];
            if (staff == null)
                HttpContext.Current.Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //{
            //    throw new Exception("SessionEnded");
            //}
            
            string Action = "";
            int removeID = 0;
            Int32.TryParse(removeId, out removeID);
            int originalID = 0;
            Int32.TryParse(originalId, out originalID);


            Action = originalID == 0 ? "Move" : "Copy";


            SimpleServingsLibrary.Menu.MenuItemGridChangeHistory.AddMenuItemGridChangeHistory(MenuID, InitialMenuItem.RecipeID, InitialMenuItem.WeekInCycle, InitialMenuItem.DayOfWeekID, InitialMenuItem.MenuItemTypeID,
            NewMenuITem.DayOfWeekID, NewMenuITem.MenuItemTypeID, NewMenuITem.CreatedBy, Action);

            
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
          //  Response.Redirect(String.Format("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID={0}&WeekSelected={1}", menuID, DragMenuItems1.SelectedWeek));

            Response.Redirect(String.Format("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID={0}&WeekSelected={1}", menuID, 1));  //go to the first week

        }


    }

    public class MenuInfo 
    {
        public int MenuID { set; get; }
        public int Week { set; get; }
        public int Day {set; get;}
        public int MenuItemId { set; get; }
        public string RecipeID {set; get; } 
    }

    public class MenuInfos : List<MenuInfo> { }
}