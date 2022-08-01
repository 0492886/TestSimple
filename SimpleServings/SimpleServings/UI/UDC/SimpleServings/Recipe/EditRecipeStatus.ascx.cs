using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class EditRecipeStatus : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
                int recipeID = 0;
                lblMsg.Text = String.Empty;
                if (!Page.IsPostBack)
                {

                    if (Request["RecipeID"] != null)
                    {
                        Int32.TryParse(Request["RecipeID"].ToString(), out recipeID);
                        lblRecipeID.Text = recipeID.ToString();
                        PopRecipe(recipeID);
                        PopIngredients(recipeID);
                        PopRecipeSupplements(recipeID);
                        //PopRecipeNutrition(recipeID);
                        //PopRecipeStatus(recipeID);
                        PopRecipeStatusHistory(recipeID);
                        PopRecipeStatusActionPanel(recipeID);
                        
                    }

                }
            }
            catch (ApplicationException ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }

        }

        private void PopRecipeStatusActionPanel(int recipeID)
        {
            StatusChangeActionPanel1.Initialization(recipeID, SimpleServingsLibrary.Shared.Code.CodeTypes.RecipeStatus);
        }

        private void PopRecipeStatusHistory(int recipeID)
        {
            RecipeStatusHistory1.PopGrid(recipeID);
        }

        /*private void PopRecipeStatus(int recipeID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            if (staff == null) Response.Redirect("~/UI/Page/login.aspx"); 
            SimpleServingsLibrary.Recipe.Recipe recipe = new SimpleServingsLibrary.Recipe.Recipe();
            try
            {
                recipe.GetRecipeByRecipeID(recipeID);
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlRecipeStatus, Code.CodeTypes.RecipeStatus, staff.UserGroup, recipe.RecipeStatus.ToString());
            }
            catch{}
        }*/

        //private void PopRecipeNutrition(int recipeID)
        //{
        //    ViewRecipeNutrition1.PopDisplayNutrition(recipeID);
        //}
        private void PopIngredients(int recipeID)
        {
            ViewRecipeIngredient1.PopGrid(recipeID);
        }

        private void PopRecipeSupplements(int recipeID)
        {
            ViewRecipeSupplement1.PopGrid(recipeID);
        }



        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }

        }

        private void PopRecipe(int recipeID)
        {
            SimpleServingsLibrary.Recipe.Recipe recipe = new SimpleServingsLibrary.Recipe.Recipe();
            try
            {
                recipe.GetRecipeByRecipeID(recipeID);
                lblRecipeName.Text = recipe.RecipeName;                               
            }
            catch { }
        }

        

    }
}