using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class RecipeSearchList : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    PopDropDowns();
                    PopRepeater();
                }
                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }
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
        private void PopDropDowns()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlRecipeView, Code.CodeTypes.RecipeView, staff.UserGroup, GlobalEnum.RecipeView_Public.ToString());
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(ddlRecipeTag, Code.CodeTypes.Tag, staff.UserGroup, "");
        }
        




        private void PopRepeater()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            int staffID = staff.StaffID;
            int recipeView = 0;
            Int32.TryParse(ddlRecipeView.SelectedValue, out recipeView);
            int recipeTag = 0;
            Int32.TryParse(ddlRecipeTag.SelectedValue, out recipeTag);

            string searchText = "";
            //searchText = txtName.Value;
            searchText = txtName.Text.ToString();
            //searchText = searchText.Replace("\n", "").Replace("\r", "").Trim();

            SimpleServingsLibrary.Recipe.Recipes recipes = new SimpleServingsLibrary.Recipe.Recipes();
            try
            {
                //show only approved recipes
               // recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staffID, recipeView, txtName.Text.Trim(), GlobalEnum.RecipeStatus_Approved, recipeTag,1);
                recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staffID, recipeView, searchText, GlobalEnum.RecipeStatus_Approved, recipeTag, 1);

            }
            catch { }
            RecipeSearchRepeater1.PopRepeater(recipes);

        }
        private void PopFavorites()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            int staffID = staff.StaffID;
      

            SimpleServingsLibrary.Recipe.Recipes recipes = new SimpleServingsLibrary.Recipe.Recipes();
            try
            {
                recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipeByFavorite(staffID);
            }
            catch { }
            RecipeSearchRepeater1.PopRepeater(recipes);
        }

        protected void ddlRecipeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlRecipeView.Attributes.Add("onChange", "checkUpdating();"); 
            PopRepeater();
        }
               
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopRepeater();
        }

        protected void ddlRecipeTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopRepeater();
        }

        protected void lnkBFavorites_Click(object sender, EventArgs e)
        {
            PopFavorites();
        }

        

        
    }
}