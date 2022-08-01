using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;
using System.Configuration;


namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class ViewMenu : System.Web.UI.UserControl
    {

        SimpleServingsLibrary.Menu.Menu menu;
        private int menutypeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 

                lblValidationMsg.Text = string.Empty;
                lblNutritionValidation.Text = string.Empty;
                pnValidation.Visible = false;
                pnSuccess.Visible = false;
                lblSuccess.Text = string.Empty;
               
                if (!Page.IsPostBack)
                {
                ApplyPermissions();
                }
                int menuID = 0;
                lblMsg.Text = String.Empty;
                
                    if (Request["MenuID"] != null)
                    {
                        lnkBtnCreateNewMenuUsingSample.NavigateUrl = "~/UI/Page/SimpleServings/Menu/AddMenu.aspx?MenuType=AddMenuUsingSample&MenuID=" + Request["MenuID"] ;
                        Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                        SetLink(menuID);
                        PopMenu(menuID);
                        PopMenuWeekStatus(menuID);
                        PopMenuStatusHistory(menuID);
                        MenuAccessRestriction(menuID);
                        PopMenuStatusActionPanel(menuID);
     
                        //If its a sample Menu
                        if (menutypeId == GlobalEnum.SampleMenu)
                        {
                            ViewSampleMenu();
                        }
                        else
                        {
                            // If it's a regular menu show Menu Item change Log
                            PopMenuItemGirdHistory(menuID, staff);
                        }                     

                    }
                    //int selectedWeek = 0;
                    //Int32.TryParse(MenuItemGrid1.SelectedWeek, out selectedWeek);
                   // btnComplete.Visible = (SimpleServingsLibrary.Menu.Menu.IsMenuWeekComplete(menuID, selectedWeek));

               
            }
            catch (ApplicationException ex)
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                lblErrorMsg.Text = ex.Message;
            }


        }

        private void SetLink(int menuID)
        {
            //string path = ConfigurationManager.AppSettings["PrintMenuURL"] + "MenuID=" + menuID;
            //lnkPrintMenu.HRef = path; 
        }

        private void MenuAccessRestriction(int menuID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserIDMenuID(staff.StaffID, menuID))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You dont have access to this menu");
            }
        }

        private void PopMenuStatusHistory(int menuID)
        {
            try
            {
                SimpleServingsLibrary.Menu.MenuStatusHistories menustatushistories = new SimpleServingsLibrary.Menu.MenuStatusHistories();
                menustatushistories = SimpleServingsLibrary.Menu.MenuStatusHistory.GetMenuStatusHistoryByMenuID(menuID);
                MenuStatusHistoryGrid1.PopMenuStatusGrid(menustatushistories);            
            }
            catch { }
        }

        private void PopMenuWeekStatus(int menuID)
        {
            ViewMenuWeekStatus1.PopStatus(menuID);
        }
       
        private void PopMenuStatusActionPanel(int menuID)
        {
            MenuStatusChangeActionPanel1.Initialization(menuID, SimpleServingsLibrary.Shared.Code.CodeTypes.MenuStatus);            
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
            else if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                lnkBAddMenuItem.Visible = false;
            }

        }


        private void ViewSampleMenu()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
           
            divContractName.Visible = false;
            divCycleSection.Visible = false;
            lnkBEditMenuName.Visible = false;
            lblViewMenu.Text = "View Sample Menu";
            
            lnkBtnCreateNewMenuUsingSample.Visible = (menu.MenuStatus == GlobalEnum.MenuStatus_SampleMenuComplete);
            if (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN || staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.DFTAUSER || staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.DFTASUP)
            {
                lnkBReplicate.Visible = (menu.MenuStatus == GlobalEnum.MenuStatus_SampleMenuComplete);
                lnkBEditMenu.Visible = (menu.MenuStatus == GlobalEnum.MenuStatus_SampleMenuIncomplete);
            }
            else
            {
                pnActionsPanel.Visible = false;
                lnkBAddMenuItem.Visible = false; // If user is not Admin/ DFTA Supervisor/ DFTA User Disable Edit Menu Link
                
            }

        }

        private void PopMenu(int menuID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
           if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
             menu = new SimpleServingsLibrary.Menu.Menu();
            try
            {
                menu.GetMenuByMenuID(menuID);
                menutypeId = menu.MenuTypeID;

                dlContracts.DataSource = menu.ContractNames;
                dlContracts.DataBind();

                lblMenuID.Text = menuID.ToString();
                lblContract.Text = menu.ContractTypeName;
                lblMealType.Text = menu.MealServedTypeIDText;
                lblDietType.Text = menu.DietTypeIDText;
                lblMealTypeFormat.Text = menu.MealServedFormatText;                
                lblCycle.Text = menu.CycleIDText;
                lblStartDate.Text = menu.StartDate;
                lblEndDate.Text = menu.EndDate;
                lblMenuStatus.Text = menu.MenuStatusText;
                lblMenuName.Text = menu.MenuName;
                lblContractName.Text = menu.ContractName;

                if(menu.OriginalMenuTypeID == GlobalEnum.SampleMenu && (menu.OriginalMenuName != string.Empty || menu.OriginalMenuName != null))
                {
                    lblSampleMenuName.Visible = true;
                    lblSampleMenuName.Text = menu.OriginalMenuName;
                    divSampleMenuName.Visible = true;
                   
                }

                SimpleServingsLibrary.Menu.MenuDays days = 
                SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
                rptDays.DataSource = days;
                rptDays.DataBind();
                int menuStatus = menu.MenuStatus;
                lnkBReplicate.Visible = (menuStatus == GlobalEnum.MenuStatus_Approved);
                lnkBEditMenu.Visible = (menuStatus == GlobalEnum.MenuStatus_Draft);

                //The only users who should be able to edit menus when they are submitted to DFTA are DFTA users and admin. 
                var allowedUserGroups = new[] {SimpleServingsLibrary.Shared.UserGroup.ADMIN,
                                                SimpleServingsLibrary.Shared.UserGroup.DFTASUP,
                                                SimpleServingsLibrary.Shared.UserGroup.DFTAUSER};

                lnkBEditMenuName.Visible = (menuStatus != GlobalEnum.MenuStatus_Approved && menuStatus != GlobalEnum.MenuStatus_Draft) &&
                    (menuStatus != GlobalEnum.MenuStatus_SubmittedToDFTA || allowedUserGroups.Contains(staff.UserGroup));
                
                lnkBAddMenuItem.Visible = (menuStatus != GlobalEnum.MenuStatus_SubmittedToDFTA || allowedUserGroups.Contains(staff.UserGroup));

                //For Draft Status Menus get all contracts
                // Added for Contract Association for all new Menus
                if (menu.MenuStatus == GlobalEnum.MenuStatus_Draft)
                {
                    lblContractName.Visible = false;
                    dlContracts.Visible = true;
 
                }

                //if (SimpleServingsLibrary.Menu.Menu.AreAllMenuWeeksComplete(menuID))
                //   btnSubmit.Enabled = true;
                
                

            }
            catch
            { }
        }


        private void PopMenuItemGirdHistory(int menuID, SimpleServingsLibrary.Shared.Staff staff)
        {
            if (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN || staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.DFTAUSER
                            || staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.DFTASUP)
            {
                divMenuItemLog.Visible = true;
                MenuItemGridChangeHistory1.PopMenuItemHistory(menuID);
            }
        }




        protected void lnkBAddMenuItem_Click(object sender, EventArgs e)
        {
            int menuID=0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);  
            string url = String.Format("~/UI/Page/SimpleServings/Menu/AddMenuItem.aspx?MenuID={0}&WeekSelected={1}", menuID, MenuItemGrid1.SelectedWeek);
            Response.Redirect(ResolveUrl(url));
        }
        protected void lnkBReplicate_Click(object sender, EventArgs e)
        {
            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);
            
            string url = String.Format("~/UI/Page/SimpleServings/Menu/ReplicateMenu.aspx?MenuID={0}", menuID);
            Response.Redirect(ResolveUrl(url));
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            pnValidation.Visible = false;
            pnSuccess.Visible = false;
            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);
            short weekInCycle = MenuItemGrid1.SelectedWeek;

            try
            {
                SimpleServingsLibrary.Menu.Menu.ValidateRequiredItems(menuID, weekInCycle);

            }
            catch (Exception ex)
            {
                lblValidationMsg.Text = ex.Message;
            }
            try
            {
                SimpleServingsLibrary.MenuThreshold.MenuThreshold.ValidateThreshold(menuID, weekInCycle);
            }
            catch (Exception ex2)
            {
                lblNutritionValidation.Text = ex2.Message;
            }
            if (string.IsNullOrEmpty(lblValidationMsg.Text) && string.IsNullOrEmpty(lblNutritionValidation.Text))
            {
                pnValidation.Visible = false;
                pnSuccess.Visible = true;
                lblSuccess.Text = "Congratulations, this week of your menu is ready for submission!";
            }
            //else pnValidation.Visible = true;

        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            pnValidation.Visible = false;
            pnSuccess.Visible = false;
            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);
            short weekInCycle = MenuItemGrid1.SelectedWeek;
            try
            {
                SimpleServingsLibrary.Menu.Menu.ValidateRequiredItems(menuID, Convert.ToInt32(MenuItemGrid1.SelectedWeek));
            }
            catch (Exception ex)
            {
                lblValidationMsg.Text = ex.Message;
                return;
            }

            try
            {
                SimpleServingsLibrary.MenuThreshold.MenuThreshold.ValidateThreshold(menuID, weekInCycle);
            }
            catch (Exception ex2)
            {
                lblNutritionValidation.Text = ex2.Message;
                return;
            }
            if (string.IsNullOrEmpty(lblValidationMsg.Text) && string.IsNullOrEmpty(lblNutritionValidation.Text))
            {
                pnValidation.Visible = false;
                pnSuccess.Visible = true;
                lblSuccess.Text = "Congratulations, this week of your menu is ready for submission!";
            }
            //else pnValidation.Visible = true;
            try
            {
                SimpleServingsLibrary.Menu.Menu.SetMenuWeekStatus(menuID, weekInCycle, true, staff.StaffID);
                PopMenuWeekStatus(menuID);
                MenuItemGrid1.PopGrid(menuID);
                //if (SimpleServingsLibrary.Menu.Menu.AreAllMenuWeeksComplete(menuID))
                //    btnSubmit.Enabled = true;

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
             int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);
            Response.Redirect("~/UI/Page/SimpleServings/Menu/SubmitMenuToContracts.aspx?MenuID=" + menuID);
        }

        protected void lnkBEditMenu_Click(object sender, EventArgs e)
        {
            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);
            Response.Redirect("~/UI/Page/SimpleServings/Menu/EditMenu.aspx?MenuID=" + menuID);
        }

        protected void lnkBEditMenuName_Click(object sender, EventArgs e)
        {
            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);
            Response.Redirect("~/UI/Page/SimpleServings/Menu/EditMenuName.aspx?MenuID=" + menuID);
        }


        protected void lnkMenuPrint_Click(object sender, EventArgs e)
        {
            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);


            Response.Redirect("~/UI/Page/SimpleServings/Reports/ViewMenuReport.aspx?MenuID=" + menuID);
        }

    }
}