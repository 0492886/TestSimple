using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class AddEditMenuThreshold : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    PopDropdown();                    
                }

                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }
        }

        private void PopDropdown()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            try
            {
                SimpleServingsLibrary.RecipeSupplement.Nutrients nutruents =
                SimpleServingsLibrary.RecipeSupplement.Nutrient.GetNutrientsAll();
                ddlNutrient.DataSource = nutruents;
                ddlNutrient.DataTextField = "NutrientName";
                ddlNutrient.DataValueField = "NutrientID";
                ddlNutrient.DataBind();
                ddlNutrient.Items.Insert(0, new ListItem("[Select]", "0"));
                
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlMealType, Code.CodeTypes.MealServedType, staff.UserGroup, "");
                ddlMealType.Items.Insert(0, new ListItem("[Select]", "0"));
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlContractType, Code.CodeTypes.ContractType, staff.UserGroup,"");
                ddlContractType.Items.Insert(0, new ListItem("[Select]", "0"));
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlPeriodicalType, Code.CodeTypes.PeriodicalType, staff.UserGroup, "");
                ddlPeriodicalType.Items.Insert(0, new ListItem("[Select]", "0"));
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlInequality, Code.CodeTypes.InequalityType, staff.UserGroup, "");
                ddlInequality.Items.Insert(0, new ListItem("[Select]", "0"));

                //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddldietType, Code.CodeTypes.DietType, staff.UserGroup, "");
                SimpleServingsLibrary.Shared.Utility.GetDietTypeCodesByStaffID(ddldietType, staff.StaffID, "");
                ddldietType.Items.Insert(0, new ListItem("[Select]", "0"));
                if (Request["MenuThresholdID"] != null)
                {                    
                    PopMenuThreshold(Convert.ToInt32(Request["MenuThresholdID"].ToString()));
                } 
            }
            catch { }           
        }

        private void PopMenuThreshold(int menuThresholdID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            
            if (menuThresholdID != 0)
            {
                SimpleServingsLibrary.MenuThreshold.MenuThreshold menuthreshold = new SimpleServingsLibrary.MenuThreshold.MenuThreshold();
                menuthreshold = SimpleServingsLibrary.MenuThreshold.MenuThreshold.GetMenuThresholdsByID(menuThresholdID);
                ddlNutrient.ClearSelection();
                ddlNutrient.Items.FindByValue(menuthreshold.NutrientID.ToString()).Selected = true;
                ddlMealType.ClearSelection();
                ddlMealType.Items.FindByValue(menuthreshold.MealServedTypeID.ToString()).Selected = true;
                ddlContractType.ClearSelection();
                ddlContractType.Items.FindByValue(menuthreshold.ContractTypeID.ToString()).Selected = true;
                ddlPeriodicalType.ClearSelection();
                ddlPeriodicalType.Items.FindByValue(menuthreshold.PeriodicalTypeID.ToString()).Selected = true;
                ddlInequality.ClearSelection();
                ddlInequality.Items.FindByValue(menuthreshold.InequalityTypeID.ToString()).Selected = true;

                //changes for DietType 
                ddldietType.ClearSelection();
                ddldietType.Items.FindByValue(menuthreshold.DietTypeID.ToString()).Selected = true;

                txtHighThreshold.Text = menuthreshold.HighThreshold.ToString();
                txtLowThreshold.Text = menuthreshold.LowThreshold.ToString();
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

        private void GetValuesFromControls(ref SimpleServingsLibrary.MenuThreshold.MenuThreshold menuthreshold)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            int nutrientID = 0;
            Int32.TryParse(ddlNutrient.SelectedValue, out nutrientID);
            menuthreshold.NutrientID = nutrientID;

            int contractTypeID = 0;
            Int32.TryParse(ddlContractType.SelectedValue, out contractTypeID);
            menuthreshold.ContractTypeID = contractTypeID;
            
            int mealServedType = 0;
            Int32.TryParse(ddlMealType.SelectedValue, out mealServedType);
            menuthreshold.MealServedTypeID = mealServedType;

            int dietTypeID = 0;
            Int32.TryParse(ddldietType.SelectedValue, out dietTypeID);
            menuthreshold.DietTypeID = dietTypeID;

            int periodicalTypeID = 0;
            Int32.TryParse(ddlPeriodicalType.SelectedValue, out periodicalTypeID);
            menuthreshold.PeriodicalTypeID = periodicalTypeID;

            int ineuilityID = 0;
            Int32.TryParse(ddlInequality.SelectedValue, out ineuilityID);
            menuthreshold.InequalityTypeID = ineuilityID;
            
            double lowThresholdID = 0;
            Double.TryParse(txtLowThreshold.Text, out lowThresholdID);
            menuthreshold.LowThreshold = lowThresholdID;
            double highThresholdID = 0;
            Double.TryParse(txtHighThreshold.Text, out highThresholdID);
            menuthreshold.HighThreshold = highThresholdID;                      
            menuthreshold.CreatedBy = staff.StaffID;
            menuthreshold.DependsOnThresholdID = 0;            
        }
        
        
        protected void btnAddMenuThreshold_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLowThreshold.Text) || !Validation.IsFloat(txtLowThreshold.Text))
                    throw new Exception("A valid Low threshold is required");
                if (string.IsNullOrEmpty(txtHighThreshold.Text) || !Validation.IsFloat(txtHighThreshold.Text))
                    throw new Exception("A valid High threshold is required");

                SimpleServingsLibrary.MenuThreshold.MenuThreshold menuthreshold = new SimpleServingsLibrary.MenuThreshold.MenuThreshold();
                GetValuesFromControls(ref menuthreshold);
                int thresholdID = 0;
                
                if (Request["MenuThresholdID"] != null)
                {                                   
                    Int32.TryParse(Convert.ToString(Request["MenuThresholdID"]), out thresholdID);
                    menuthreshold.ThresholdID = thresholdID;    
                    bool edited = menuthreshold.EditMenuThreshold();
                    if (edited) {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Visible = true;
                        lblMsg.Text = "Edited Successfully";
                    }
                } else {
                    thresholdID = menuthreshold.AddMenuThreshold();
                    if (thresholdID > 0) {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Visible = true;
                        lblMsg.Text = "Added Successfully";
                    }
                }
                Response.Redirect("~/UI/Page/MyZone.aspx?Control=NutritionalAnalysis");
            }
            catch (Exception Ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = Ex.Message;
                lblMsg.Visible = true;
            }
        }       
    }
}