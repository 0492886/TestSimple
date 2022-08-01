using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class RecipeList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    int tagID=0;
                    if (Request["TagID"] != null)
                        Int32.TryParse(Request["TagID"].ToString(), out tagID);
                    //else if (Session["tagID"] != null)
                    //    Int32.TryParse(Session["tagID"].ToString(), out tagID);
                    string searchKeyWord = "";
                    //if (Session["searchKeyWord"] != null)
                    //    searchKeyWord = Session["searchKeyWord"].ToString();
                    PopDropDowns(tagID,searchKeyWord);
                    PopGrid();
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
            cbDeactiveRecipes.Visible = staff.IsAdmin;

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                this.cbDeactiveRecipes.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
            
        }

        private void PopDropDowns(int tagID, string searchKeyWord)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlRecipeView, Code.CodeTypes.RecipeView, staff.UserGroup, GlobalEnum.RecipeView_Public.ToString());
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(ddlRecipeTag, Code.CodeTypes.Tag, staff.UserGroup, tagID.ToString());

            int recipeStatus = 0;
            Int32.TryParse(ddlRecipeStatus.SelectedValue, out recipeStatus);
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(ddlRecipeStatus, Code.CodeTypes.RecipeStatus, staff.UserGroup, recipeStatus.ToString());
            SimpleServingsLibrary.Shared.Utility.GetCodesByType(ddlRecipeStatus, Code.CodeTypes.RecipeStatus, true, recipeStatus.ToString());
            txtName.Text = searchKeyWord;
        }
        
        private void PopGrid()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            //if (staff == null) Response.Redirect("~/UI/Page/login.aspx");
            int staffID = staff.StaffID;
            int recipeView = 0;
            Int32.TryParse(ddlRecipeView.SelectedValue, out recipeView);
            int recipeTag = 0;
            Int32.TryParse(ddlRecipeTag.SelectedValue, out recipeTag);

            int recipeStatus = 0;
            Int32.TryParse(ddlRecipeStatus.SelectedValue, out recipeStatus);

            string searchText = "";
            if (Request["rcpSearch"] != null)
            {
                txtName.Text = Request["rcpSearch"].ToString();
                
            }

            searchText = txtName.Text.ToString();
            searchText = searchText.Replace("\n", "").Replace("\r", "").Trim();
            
            SimpleServingsLibrary.Recipe.Recipes recipes = new SimpleServingsLibrary.Recipe.Recipes();
            try
            {
                if (cbDeactiveRecipes.Visible)
                {
                    //recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staffID, recipeView, txtName.Text.Trim(), 0, recipeTag, 0, !cbDeactiveRecipes.Checked);
                    //recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staffID, recipeView, txtName.Text.Trim(), recipeStatus, recipeTag, 0, !cbDeactiveRecipes.Checked);
                    recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staffID, recipeView, searchText, recipeStatus, recipeTag, 0, !cbDeactiveRecipes.Checked);

                }
                else
                {
                   // recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staffID, recipeView, txtName.Text.Trim(), recipeStatus, recipeTag, 0);
                    recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staffID, recipeView, searchText, recipeStatus, recipeTag, 0);

                }
            }
            catch { }
             //RecipeGrid1.PopGrid(recipes);
             RecipeGrid1.PopGrid(recipes, SimpleServingsLibrary.Recipe.Recipe.SortType.RegularList);                             
        }

        protected void ddlRecipeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            PopGrid();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            int staffID = staff.StaffID;

            int recipeID = 0;
            bool result = false;
            string searchText = "";
            searchText = txtName.Text.ToString();
            searchText = searchText.Replace("\n", "").Replace("\r", "").Trim();

            result = int.TryParse(searchText, out recipeID);

            if (result == true)
            {
                SimpleServingsLibrary.Recipe.Recipes recipes = new SimpleServingsLibrary.Recipe.Recipes();
                recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeID(recipeID,staffID);
                RecipeGrid1.PopGrid(recipes, SimpleServingsLibrary.Recipe.Recipe.SortType.RegularList);
            }
            else
            {
                PopGrid();
            }
        }

        protected void ddlRecipeTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Session["tagID"] = ddlRecipeTag.SelectedValue;
            PopGrid();
        }

        protected void cbDeactiveRecipes_CheckedChanged(object sender, EventArgs e)
        {
            PopGrid();
        }

        protected void ddlRecipeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopGrid();

        }
    }
}