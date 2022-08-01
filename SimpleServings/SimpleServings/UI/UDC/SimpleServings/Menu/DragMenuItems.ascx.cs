using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class DragMenuItems : System.Web.UI.UserControl
    {
        
        public short SelectedWeek
        {
            get { return MenuItemGrid1.SelectedWeek; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //while swap and switch menu, don't dashboard layout, Mandy
            MenuItemGrid1.FindControl("MenuItemGridByWeek2").Visible = false;
            MenuItemGrid1.FindControl("MenuItemGridByWeek3").Visible = false;
            MenuItemGrid1.FindControl("MenuItemGridByWeek4").Visible = false;
            MenuItemGrid1.FindControl("MenuItemGridByWeek5").Visible = false;
            MenuItemGrid1.FindControl("MenuItemGridByWeek6").Visible = false;
            ///


            MenuItemGrid1.RemoveButtonClick += new EventHandler(MenuItemGrid1_RemoveButtonClick);
            lblValidationMsg.Text = string.Empty;
            lblNutritionValidation.Text = string.Empty;
            pnValidation.Visible = false;
            pnSuccess.Visible = false;
            lblSuccess.Text = string.Empty;
            try
            {
                if (!Page.IsPostBack)
                {
                    ApplyPermissions();
                } 
                if (Request["MenuID"] != null)
                {
                    int menuID = 0;
                    Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                    lblMenuID.Text = menuID.ToString();
                    string weekSelected = string.Empty;
                    short weekInCycle = SelectedWeek;
                    if (Request["WeekSelected"] != null && weekInCycle == 0)
                    {
                        weekSelected = Request["WeekSelected"].ToString();
                        short.TryParse(weekSelected, out weekInCycle);
                    }                                     
                    PopMenu(menuID);
                    PopMenuWeekStatus(menuID);
                    if (SimpleServingsLibrary.Menu.Menu.IsMenuWeekComplete(menuID, weekInCycle))
                    {
                        btnComplete.Text = "Mark As Incomplete";
                        btnComplete2.Text = "Mark As Incomplete";
                    }
                    else
                    {
                        btnComplete.Text = "Mark As Complete";
                        btnComplete2.Text = "Mark As Complete";
                    }
                }                    
            }

            catch (ApplicationException ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
           

        }
        public event EventHandler BubbledRemoveButtonClick;

         protected void MenuItemGrid1_RemoveButtonClick(object sender, EventArgs e)
         {
             if (BubbledRemoveButtonClick != null)
             {
                 BubbledRemoveButtonClick(this, e);
             }
         }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void PopMenu(int menuID)
        {
            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            try
            {
                menu.GetMenuByMenuID(menuID);

                if (menu.MenuTypeID == GlobalEnum.SampleMenu)
                {
                    divCycle.Visible = false;
                }

                lblContract.Text = menu.ContractTypeName;
                int programType = menu.ContractTypeID;
                if (programType == GlobalEnum.ContractType_CongregateSlashHomeDelivered
                    || programType == GlobalEnum.ContractType_HomeDelivered || menu.DietTypeID != GlobalEnum.RegularDietType)
                    lblCannotAlternate.Text = "1";
                else lblCannotAlternate.Text = string.Empty;
                lblMealType.Text = menu.MealServedTypeIDText;
                lblCycle.Text = menu.CycleIDText;
                lblStartDate.Text = menu.StartDate;
                lblEndDate.Text = menu.EndDate;
                lblMenuStatus.Text = menu.MenuStatusText;
                lblMenuName.Text = menu.MenuName;
                SimpleServingsLibrary.Menu.MenuDays days =
                    SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
                rptDays.DataSource = days;
                rptDays.DataBind();
            }
            catch
            { }
        }


        protected void btnValidate_Click(object sender, EventArgs e)
        {
            pnValidation.Visible = false;
            pnSuccess.Visible = false;
            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);
            //we have to re-populate, otherwise recently dragged items don't appear on grid after validate.
            MenuItemGrid1.PopGrid(menuID);

            short weekInCycle = MenuItemGrid1.SelectedWeek;         
            try
            {
                SimpleServingsLibrary.Menu.Menu.ValidateRequiredItems(menuID,weekInCycle );
                
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
            else pnValidation.Visible = true;
        }

        public event EventHandler BubbledCompleteButtonClick;     
        protected void btnComplete_Click(object sender, EventArgs e)
        {

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            if (BubbledCompleteButtonClick != null)
            {
                pnValidation.Visible = false;
                pnSuccess.Visible = false;
                int menuID = 0;
                Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                //we have to re-populate, otherwise recently dragged items don't appear on grid after validate.
                MenuItemGrid1.PopGrid(menuID);

                short weekInCycle = MenuItemGrid1.SelectedWeek;

                if (SimpleServingsLibrary.Menu.Menu.IsMenuWeekComplete(menuID, weekInCycle))
                {
                    try
                    {


                        SimpleServingsLibrary.Menu.Menu.SetMenuWeekStatus(menuID, weekInCycle,false, staff.StaffID);
                        btnComplete.Text = "Mark As Complete";
                        btnComplete2.Text = "Mark As Complete";
                        PopMenuWeekStatus(menuID);
                        MenuItemGrid1.PopGrid(menuID);
                        lblSuccess.Text = "Marked as Incomplete!";
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = ex.Message;
                    }

                }
                else
                {

                    try
                    {
                        SimpleServingsLibrary.Menu.Menu.ValidateRequiredItems(menuID, Convert.ToInt32(MenuItemGrid1.SelectedWeek));
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
                        try
                        {
                            SimpleServingsLibrary.Menu.Menu.SetMenuWeekStatus(menuID, weekInCycle, true, staff.StaffID);
                            btnComplete.Text = "Mark As Incomplete";
                            btnComplete2.Text = "Mark As Incomplete";
                            PopMenuWeekStatus(menuID);
                            MenuItemGrid1.PopGrid(menuID);
                            lblSuccess.Text = "Marked as complete!";
                        }
                        catch (Exception ex)
                        {
                            lblMsg.Text = ex.Message;
                        }
                    }
                    else pnValidation.Visible = true;
                }
                BubbledCompleteButtonClick(this, e);
            }          
        }
        private void PopMenuWeekStatus(int menuID)
        {
            ViewMenuWeekStatus1.PopStatus(menuID);
        }
       
        
    }
}