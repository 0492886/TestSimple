 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuItemGrid : System.Web.UI.UserControl
    {
        private bool showDeleteButton = true;
        public bool ShowDeleteButton
        {
            set
            {
                showDeleteButton = value;
            }
        }
        public short SelectedWeek
        {
            get {
                    short week = 0;
                    short.TryParse(ddlWeek.SelectedValue, out week);
                    return week;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // if ViewMenu page, the Swap session doesn't show up, Mandy add 
            string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);

            Session["pageName"] = pageName;
            if (pageName == "ViewMenu")
            {
                    divSwap.Visible = false;
                    ddlWeek.Enabled = false;
            }

            else
            {
                    divSwap.Visible = true;
                    ddlWeek.Enabled = true;
            }
      

            //string path = Server.MapPath(Page.AppRelativeVirtualPath);
            ///////////////////////////////////////////////

            if (!Page.IsPostBack)
            {
               
                int menuID = 0;
                if (Request["MenuID"] != null)
                {
                    Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                    lblMenuID.Text = menuID.ToString();
                    string weekSelected = String.Empty;
                    if (Request["WeekSelected"] != null)
                    {
                        weekSelected = Request["WeekSelected"].ToString();
                    }
                    if (!Page.IsPostBack)
                    {
                        PopDropDowns(weekSelected);
                    }
                    PopGrid(menuID);

                    
                }
            }           
        }

        private void PopDropDowns(string weekSelected)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            for (int i = 1; i <= 6; i++)
            {
                ddlWeek.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            try
            {
                ddlWeek.Items.FindByValue(weekSelected).Selected = true;
            }
            catch { }
            ddlWeek.DataBind();
        }
       
        public void PopGrid(int menuID)
        {
            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            SimpleServingsLibrary.Menu.MenuDays menuDays = new SimpleServingsLibrary.Menu.MenuDays();
            menu.GetMenuByMenuID(menuID);    // Menu general info Mandy        
            try
            {
                
                if (menu.MenuStatus == GlobalEnum.MenuStatus_Approved)
                {
                    ShowDeleteButton = false;
                }
                SimpleServingsLibrary.Menu.MenuItemTypes menuITypes =
                    SimpleServingsLibrary.Menu.MenuItemType.GetAllMenuItemTypes(menu.MealServedTypeID);
                gvMenuItems.DataSource = menuITypes;  //Sp_Get_AllMenuItemTypes Mandy
                gvMenuItems.DataBind();
                menuDays = PopDays();
            }
            catch
            {
                gvMenuItems.DataSource = null;
                gvMenuItems.DataBind();
            }

            PopRepeaters(menu.MenuTypeID, menuDays);  //repeater get that MenuType(entree etc in weekdays(Monday, Tusday etc))
            int weekInCycle = 0;
            Int32.TryParse(ddlWeek.SelectedValue, out weekInCycle);
            
            
        }


        private SimpleServingsLibrary.Menu.MenuDays PopDays()
        {
            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            SimpleServingsLibrary.Menu.MenuDays menuDays = new SimpleServingsLibrary.Menu.MenuDays();
            try
            {
                menuDays = SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
            }
            catch { }
            if (menuDays != null && menuDays.Count > 0)
            {
                for(int i=0;i<menuDays.Count;i++)
                {
                    gvMenuItems.HeaderRow.Cells[i+2].Text=menuDays[i].DayName; //add all weekdays (Monday, Tuesday) to gvMenuItems    Mandy
                                 
                }
                if (menuDays.Count < 7)
                {
                    for (int i = menuDays.Count ; i < 7; i++)
                    {
                       gvMenuItems.Columns[i + 2].Visible = false;
                    }
                }
            }

            // Mandy add
            ddlSwapFrom.DataSource = menuDays;
            ddlSwapFrom.DataTextField = "DayName";
            ddlSwapFrom.DataValueField = "DayOfWeekID";
            ddlSwapFrom.DataBind();
            ddlSwapFrom.Items.Insert(0, new ListItem("--Select--", "0"));

            ddlSwapTo.DataSource = menuDays;
            ddlSwapTo.DataTextField = "DayName";
            ddlSwapTo.DataValueField = "DayOfWeekID";
            ddlSwapTo.DataBind();
            ddlSwapTo.Items.Insert(0, new ListItem("--Select--", "0"));
            /////////////// end add

            cblWeek1.DataSource = menuDays;
            cblWeek1.DataTextField = "DayName";
            cblWeek1.DataValueField = "DayOfWeekID";
            cblWeek1.DataBind();

            cblWeek2.DataSource = menuDays;
            cblWeek2.DataTextField = "DayName";
            cblWeek2.DataValueField = "DayOfWeekID";
            cblWeek2.DataBind();

            cblWeek3.DataSource = menuDays;
            cblWeek3.DataTextField = "DayName";
            cblWeek3.DataValueField = "DayOfWeekID";
            cblWeek3.DataBind();

            cblWeek4.DataSource = menuDays;
            cblWeek4.DataTextField = "DayName";
            cblWeek4.DataValueField = "DayOfWeekID";
            cblWeek4.DataBind();

            cblWeek5.DataSource = menuDays;
            cblWeek5.DataTextField = "DayName";
            cblWeek5.DataValueField = "DayOfWeekID";
            cblWeek5.DataBind();

            cblWeek6.DataSource = menuDays;
            cblWeek6.DataTextField = "DayName";
            cblWeek6.DataValueField = "DayOfWeekID";
            cblWeek6.DataBind();




            return menuDays;

        }
        private void PopRepeaters(int menutypeID, SimpleServingsLibrary.Menu.MenuDays menuDays)
        {
            //string pageName = System.IO.Path.GetFileName(Request.CurrentExecutionFilePath);
            bool IsSampleMenuItem = false;
            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            //SimpleServingsLibrary.Menu.MenuDays menuDays = new SimpleServingsLibrary.Menu.MenuDays();
            //try
            //{
            //    menuDays = SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
            //}
            //catch { }
            int weekSelected =0;
           Int32.TryParse(ddlWeek.SelectedValue, out weekSelected);
           lblMenuTypeID.Text = menutypeID.ToString();

            foreach (GridViewRow row in gvMenuItems.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label lblMenuItemTypeID = row.FindControl("lblMenuItemTypeID") as Label;
                    int menuItemTypeID = 0;
                    Int32.TryParse(lblMenuItemTypeID.Text, out menuItemTypeID);

                    for (int i = 0; i < menuDays.Count; i++)
                    {
                        Repeater rp = new Repeater();
                        try
                        {
                        string rpName = "rpDay" + (i + 1);
                        rp = row.FindControl(rpName) as Repeater;
                        SimpleServingsLibrary.Menu.MenuItems menuItems = new SimpleServingsLibrary.Menu.MenuItems();
                        
                            menuItems = SimpleServingsLibrary.Menu.MenuItem.GetMenuItemsByMenuAndItemTypeAndWeekAndDay(menuID, menuItemTypeID, weekSelected, menuDays[i].DayOfWeekID);

                            if (IsSampleMenuItem == false)
                            {
                                 if (menutypeID == GlobalEnum.SampleMenu) // check to see if menu is a sample menu
                                {
                                    IsSampleMenuItem = true;
                                    menuItems[i].IsSampleMenuItem = true;
                                }
                            }
                            rp.DataSource = menuItems;
                            rp.DataBind();

                        }
                        catch
                        {
                            rp.DataSource = null;
                            rp.DataBind();
                        }
                        try
                        {
                            string lblName = "lblMenuItemInfo_" + (i + 1);
                            Label menuInfo = row.FindControl(lblName) as Label;


                            menuInfo.Text = String.Format("{0},{1},{2},{3},{4}", menuID, menuItemTypeID, weekSelected, menuDays[i].DayOfWeekID, IsSampleMenuItem? "true":"false");
                        }
                        catch { }
                    }
                }
            }
        }
                    
        

        //protected void gvMenuItems_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    int menuID = 0;
        //    Int32.TryParse(lblMenuID.Text, out menuID);
        //    SimpleServingsLibrary.Menu.MenuDays menuDays = new SimpleServingsLibrary.Menu.MenuDays();
        //    try
        //    {
        //        menuDays = SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
        //    }
        //    catch { }
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblMenuItemTypeID = e.Row.FindControl("lblMenuItemTypeID") as Label;
        //        int menuItemTypeID = 0;
        //        Int32.TryParse(lblMenuItemTypeID.Text, out menuItemTypeID);
                
        //        for (int i = 0; i < menuDays.Count; i++)
        //        {
        //            string rpName = "rpDay" + (i + 1);
        //            Repeater rp = e.Row.FindControl(rpName) as Repeater;
        //            SimpleServingsLibrary.Menu.MenuItems menuItems = new SimpleServingsLibrary.Menu.MenuItems();
        //            try
        //            {
        //                menuItems = SimpleServingsLibrary.Menu.MenuItem.GetMenuItemsByMenuAndItemTypeAndWeekAndDay(menuID, menuItemTypeID, Convert.ToInt32(ddlWeek.SelectedValue), menuDays[i].DayOfWeekID);
                        
        //                rp.DataSource = menuItems;
        //                rp.DataBind();
        //            }
        //            catch 
        //            {
        //                rp.DataSource = null;
        //                rp.DataBind();
        //            }
                    
        //            //foreach(SimpleServingsLibrary.Menu.MenuItem menuItem in menuItems)
        //            //{
        //             //   e.Row.Cells[i + 2].Text += menuItem.RecipeName+"<br/>";
        //            //}                              
        //        }                
        //    }
            
        //}

        protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            PopGrid(menuID);
        }

        public event EventHandler RemoveButtonClick;
        protected void lnkb_Click(object sender, EventArgs e)
        {
            if (RemoveButtonClick != null)
            {
               
                  int menuItemID = 0;
                  Int32.TryParse((sender as LinkButton).CommandArgument, out menuItemID);
                  int menuID = 0;
                 Int32.TryParse(lblMenuID.Text, out menuID);
                 try
                 {
                     SimpleServingsLibrary.Menu.MenuItem menuItem = new SimpleServingsLibrary.Menu.MenuItem();
                     menuItem.GetMenuItemByMenuItemID(menuItemID);
                     menuItem.RemoveMenuItem();

                     if(menuItem.IsSampleMenuItem == true)
                     SimpleServingsLibrary.Menu.MenuItemGridChangeHistory.AddMenuItemGridChangeHistory(menuID, menuItem.RecipeID, menuItem.WeekInCycle, menuItem.DayOfWeekID, menuItem.MenuItemTypeID, User.StaffID, "Remove");

                     RemoveButtonClick(this, e);
                     ScriptManager.RegisterClientScriptBlock(this,
                            this.GetType(), "", "$(initDragDrop)", true);
                 }
                 catch //(Exception ex)
                 {

                     //SimpleServingsLibrary.Shared.Staff.SaveExceptionMessage(0, menuID, menuItemID, ex.Message);
                 }
                 finally
                 {
                     PopGrid(menuID);
                 }                              
            }          

        }
        protected void lnkbAlternate_Click(object sender, EventArgs e)
        {
            try
            {

                int menuItemID = 0;
                Int32.TryParse((sender as LinkButton).CommandArgument, out menuItemID);
                SimpleServingsLibrary.Menu.MenuItem menuItem = new SimpleServingsLibrary.Menu.MenuItem();
                menuItem.GetMenuItemByMenuItemID(menuItemID);
                menuItem.CreatedBy = User.StaffID;
                menuItem.ToggleIsAlternate();
                int menuID = 0;
                Int32.TryParse(lblMenuID.Text, out menuID);
                PopGrid(menuID);
            }
            catch { }
        }
        protected SimpleServingsLibrary.Shared.Staff User
        {
            get
            {

                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                    return staff;
              
            }
        }

        protected bool CanDelete
        {
            get
            {
                string pageName = Session["pageName"].ToString();           //add
                if (!showDeleteButton) return false;
                else if (IsComplete)  return false;
                else if (pageName == "ViewMenu") return false;              //add
                else
                {

                    if (User == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                    //Response.Redirect("~/UI/Page/login.aspx");
                    else if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, User.StaffID, Convert.ToInt32(User.UserGroup), ModulePermission.ModuleCheckType.Edit))
                    {
                         return false;
                    }
                }

                return true; 
            }
            
        }

        protected bool CanAlternate
        {
            get
            {
                string pageName = Session["pageName"].ToString();           //add
                if (!CanDelete) return false;
                //else if (IsHomeDelivered) return false;
                else if (IsHomeDeliveredOrRegularDietType) return false;
                else if (pageName == "ViewMenu") return false;              //add
                return true;
            }
        }


        //protected bool CanAlternate
        //{
        //    get
        //    {
        //        if (!CanDelete) return false;
        //        //else if (IsHomeDelivered) return false;
        //        else if (IsHomeDeliveredOrRegularDietType) return false;
        //        return true;
        //    }
        //}
        protected bool IsComplete
        {
            get
            {
                int menuID = 0;
                Int32.TryParse(lblMenuID.Text, out menuID);
                int weekInCycle = 0;
                Int32.TryParse(ddlWeek.SelectedValue, out weekInCycle);
                return SimpleServingsLibrary.Menu.Menu.IsMenuWeekComplete(menuID, Convert.ToInt32(ddlWeek.SelectedValue));
            }

        }


        //Home delivered or Congregate/HomeDelivered
        public bool IsHomeDelivered 
        {
            get
            {
                int menuID = 0;
                Int32.TryParse(lblMenuID.Text, out menuID);
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                menu.GetMenuByMenuID(menuID);
                int programType = menu.ContractTypeID;
                return (programType == GlobalEnum.ContractType_CongregateSlashHomeDelivered
                    || programType == GlobalEnum.ContractType_HomeDelivered);
            }
        
        }

        // Property to check if the Diet Type is Regular and Is home delivered meal 
        public bool IsHomeDeliveredOrRegularDietType
        {
            get
            {
                int menuID = 0;
                Int32.TryParse(lblMenuID.Text, out menuID);
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                menu.GetMenuByMenuID(menuID);
                int dietTypeID = menu.DietTypeID;
                int programType = menu.ContractTypeID;
                return (dietTypeID != GlobalEnum.RegularDietType || programType == GlobalEnum.ContractType_CongregateSlashHomeDelivered
                    || programType == GlobalEnum.ContractType_HomeDelivered);
            }
        }

        protected void btnSwap_Click(object sender, EventArgs e) //Mandy Add
       {
    
            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);

            int weekInCycle = 0;
            Int32.TryParse(ddlWeek.SelectedValue, out weekInCycle);

            int initDayOfWeekID = 0;
            Int32.TryParse(ddlSwapFrom.SelectedValue, out initDayOfWeekID);

            int finalDayOfWeekID = 0;
            Int32.TryParse(ddlSwapTo.SelectedValue, out finalDayOfWeekID);

            int CreatedBy = 0;
            CreatedBy = User.StaffID;

            if (initDayOfWeekID != 0 && finalDayOfWeekID != 0 && initDayOfWeekID != finalDayOfWeekID)
            { 

                    SimpleServingsLibrary.Menu.MenuItem.SwapWeekDayMenu(menuID, weekInCycle, initDayOfWeekID, finalDayOfWeekID, CreatedBy);

                    PopGrid(menuID);
                    // keep the select value after postback
                    ddlSwapFrom.SelectedValue = initDayOfWeekID.ToString();
                    ddlSwapTo.SelectedValue = finalDayOfWeekID.ToString();

                    lblSelectWeekDay.Text = "";
             }
            else
            {
                     lblSelectWeekDay.Text = "please select the week days";
            }
        }







    }
}