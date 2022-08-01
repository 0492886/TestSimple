using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class AddMenuItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    if (Request["MenuID"] != null)
                    {
                        int menuID = 0;
                        Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                        MenuAccessRestriction(menuID);
                        lblMenuID.Text = menuID.ToString();
                        string weekSelected = string.Empty;
                        if (Request["WeekSelected"] != null)
                        {
                           weekSelected= Request["WeekSelected"].ToString();
                        }
                        SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                        
                        menu.GetMenuByMenuID(menuID);
                        lblContract.Text = menu.ContractTypeName;                       
                        PopDropDowns(menuID, weekSelected,menu.MealServedTypeID);
                    }
                }

                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }

        }

        private void MenuAccessRestriction(int menuID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (!SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserIDMenuID(staff.StaffID, menuID))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You dont have access to this menu");
            }
        }


        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void PopDropDowns(int menuID, string weekSelected, int mealServedTypeID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            for (int i = 1; i <= 6; i++)
            {
                ddlWeek.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlWeek.DataBind();
            try
            {
                ddlWeek.Items.FindByValue(weekSelected).Selected = true;
            }
            catch { }
            try
            {
                SimpleServingsLibrary.Menu.MenuDays days =
                SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
                ddlDays.DataSource = days;
                ddlDays.DataValueField = "DayOfWeekID";
                ddlDays.DataTextField = "DayName";
                ddlDays.DataBind();
            }
            catch 
            {
                ddlDays.DataSource = null;
                ddlDays.DataBind();            
            }
            
            try
            {
                SimpleServingsLibrary.Menu.MenuItemTypes menuTypes = 
                    SimpleServingsLibrary.Menu.MenuItemType.GetAllMenuItemTypes(mealServedTypeID);
                ddlMenuItemType.DataSource = menuTypes;
                ddlMenuItemType.DataValueField = "MenuItemTypeID";
                ddlMenuItemType.DataTextField = "Description";
                ddlMenuItemType.DataBind();
            }
            catch
            {
                ddlMenuItemType.DataSource = null;
                ddlMenuItemType.DataBind();
            }


        }




        private void GetValuesFromControls(ref SimpleServingsLibrary.Menu.MenuItem menuItem)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            menuItem.MenuID = menuID;
            int dayOfWeekID = 0;
            Int32.TryParse(ddlDays.SelectedValue, out dayOfWeekID);
            menuItem.DayOfWeekID = dayOfWeekID;
            short week = 0;
            short.TryParse(ddlWeek.SelectedValue, out week);
            menuItem.WeekInCycle = week;
            int menuItemTypeID = 0;
            Int32.TryParse(ddlMenuItemType.SelectedValue, out menuItemTypeID);
            menuItem.MenuItemTypeID = menuItemTypeID;
            menuItem.CreatedBy = staff.StaffID;
            
        }

        private int SaveMenuItem()
        {
            int menuItemID = 0;            
            //try
            //{
            //    foreach (int recipeID in RecipeSearchList1.GetSelectedRecipeIDs())
            //    {
            //        SimpleServingsLibrary.Menu.MenuItem menuItem =
            //            new SimpleServingsLibrary.Menu.MenuItem();
            //        GetValuesFromControls(ref menuItem);
            //        menuItem.RecipeID = recipeID;
            //        menuItemID = menuItem.AddMenuItem();
            //    }
                              
            //    lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
            //    lblMsg.Text = "Menu Item successfully saved";
            //    lblMsg.Visible = true;
            //}
            //catch (Exception ex)
            //{
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //    lblMsg.Text = ex.Message;
            //    lblMsg.Visible = true;
            //}
            return menuItemID;
        }       
      
    

        protected void btnAddMenuItem_Click(object sender, EventArgs e)
        {
            int menuItemID = 0;
            menuItemID = SaveMenuItem();
            if (menuItemID > 0)
            {
                string url = ResolveUrl(String.Format("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID={0}&WeekSelected={1}" , lblMenuID.Text,ddlWeek.SelectedValue));
                Response.Redirect(url);
            }

        }
    }
}