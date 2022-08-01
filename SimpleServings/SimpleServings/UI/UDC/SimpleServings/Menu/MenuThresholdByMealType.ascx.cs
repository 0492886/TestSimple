using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuThresholdByMealType : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    PopDropDown();
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

        private void PopDropDown()
        {
            ListItem _select = new ListItem("[Select]", "0");

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlMealType, Code.CodeTypes.MealServedType, staff.UserGroup, "");
            ddlMealType.Items.Insert(0, _select);
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlContractType, Code.CodeTypes.ContractType, staff.UserGroup,"");
            ddlContractType.Items.Insert(0, _select);
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlPeriodicalType, Code.CodeTypes.PeriodicalType, staff.UserGroup, "");
            ddlPeriodicalType.Items.Insert(0, _select);

            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlDietType, Code.CodeTypes.DietType, staff.UserGroup, "");
            SimpleServingsLibrary.Shared.Utility.GetDietTypeCodesByStaffID(ddlDietType, staff.StaffID, "");
            ddlDietType.Items.Insert(0, _select);

            PopMenuThresholdGrid();
        }


        public void PopMenuThresholdGrid()
        {
            SimpleServingsLibrary.MenuThreshold.MenuThresholds menuthresholds = new SimpleServingsLibrary.MenuThreshold.MenuThresholds();
            menuthresholds = SimpleServingsLibrary.MenuThreshold.MenuThreshold.GetMenuThresholdsByTypes(Convert.ToInt32(ddlMealType.SelectedValue),
                Convert.ToInt32(ddlContractType.SelectedValue),Convert.ToInt32(ddlPeriodicalType.SelectedValue), Convert.ToInt32(ddlDietType.SelectedValue));
            MenuThresholdGrid1.PopGrid(menuthresholds);

            MenuThresholdGrid1.setThresholdParameters(ddlMealType.SelectedValue + "," + ddlContractType.SelectedValue + "," + ddlPeriodicalType.SelectedValue + "," + ddlDietType.SelectedValue); 
        }

       
        protected void lnkBAddMenuThreshold_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/SimpleServings/Menu/AddEditMenuThreshold.aspx");
        }

        private bool Validation()
        {
            if (ddlContractType.SelectedValue.ToString().Trim() == "0")
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Visible = true;
                lblMsg.Text = "Select contract type.";
                return false;
            }
            else if (ddlMealType.SelectedValue.ToString().Trim() == "0")
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Visible = true;
                lblMsg.Text = "Select meal type.";
                return false;
            }
            else if (ddlPeriodicalType.SelectedValue .ToString().Trim() == "0")
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Visible = true;
                lblMsg.Text = "Select period type.";
                return false;
            }
            return true;
        }

        protected void btnSearchMenuuThreshold_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                PopMenuThresholdGrid();
            }
        }
    }
}