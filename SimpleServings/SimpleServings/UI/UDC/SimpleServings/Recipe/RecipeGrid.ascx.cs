using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;
using SimpleServingsLibrary.Recipe;
using AjaxControlToolkit;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class RecipeGrid : System.Web.UI.UserControl
    {

        public void PopGrid(SimpleServingsLibrary.Recipe.Recipes recipes, SimpleServingsLibrary.Recipe.Recipe.SortType type)
        {
            if (recipes != null)
            {
                ApplyPermissions();

                if (Session["SortComparer"] != null)
                {
                    IComparer<SimpleServingsLibrary.Recipe.Recipe> comparer = (IComparer<SimpleServingsLibrary.Recipe.Recipe>)Session["SortComparer"];
                    recipes.Sort(comparer);
                }

                this.gvRecipes.DataSource = recipes;
                this.gvRecipes.DataBind();

                CacheRecipeList(recipes, type);
            }
            else
            {
                this.gvRecipes.DataSource = null;
                this.gvRecipes.DataBind();
            }
        }

        public void PopGrid(SimpleServingsLibrary.Recipe.Recipes recipes)
        {
            if (recipes != null)
            {
                ApplyPermissions();
                this.gvRecipes.DataSource = recipes;
                this.gvRecipes.DataBind();

                //CacheRecipeList(recipes);
            }
            else
            {
                this.gvRecipes.DataSource = null;
                this.gvRecipes.DataBind();                
            }
        }

        public void PopGridForRecipeHome(SimpleServingsLibrary.Recipe.Recipes recipes)
        {
            PopGrid(recipes, SimpleServingsLibrary.Recipe.Recipe.SortType.RegularList);

            gvRecipes.Columns[3].Visible = false;
            gvRecipes.Columns[2].Visible = false;
            gvRecipes.Columns[8].Visible = false;
 
        }


        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                //gvRecipes.Columns[6].Visible = false;
                gvRecipes.Columns[8].Visible = false;
                gvRecipes.Columns[2].Visible = false;
            }
        }

        private SortDirection GetSortDirection()
        {
            if (ViewState["SortDirection"] != null)
            {
                SortDirection previousDirection = (SortDirection)ViewState["SortDirection"];

                if (previousDirection == SortDirection.Ascending)
                {
                    ViewState["SortDirection"] = SortDirection.Descending;
                    return SortDirection.Descending;
                }
                else
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
            }
            else
            {
                //return default SortDirection
                ViewState["SortDirection"] = SortDirection.Ascending;
                return SortDirection.Ascending;
            }

        }

        private bool IsSortExpressionChanged(string sortExpression)
        {
            if (ViewState["SortExpression"] != null)
            {
                if ((string)ViewState["SortExpression"] == sortExpression)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private static IComparer<SimpleServingsLibrary.Recipe.Recipe> GetSortComparer(string sortExpression, SimpleServingsLibrary.Recipe.Recipe.SortDirection direction)
        {
            #region old logic
            //if (sortExpression == "RecipeName")
            //{
            //    return SimpleServingsLibrary.Recipe.Recipe.GetRecipNameSortHelper(direction);
            //}
            //else if (sortExpression == "RecipeStatus")
            //{
            //    return SimpleServingsLibrary.Recipe.Recipe.GetRecipStatusSortHelper(direction);
            //}
            //else if (sortExpression == "RecipeView")
            //{
            //    return SimpleServingsLibrary.Recipe.Recipe.GetRecipViewSortHelper(direction);
            //}
            //else if (sortExpression == "ContributedBy")
            //{
            //    return SimpleServingsLibrary.Recipe.Recipe.GetContributedBySortHelper(direction);
            //}
            //else if (sortExpression == "CreatedOn")
            //{
            //    return SimpleServingsLibrary.Recipe.Recipe.GetCreatedOnSortHelper(direction);
            //}
            //else if (sortExpression == "RecipeRating")
            //{
            //    return SimpleServingsLibrary.Recipe.Recipe.GetRecipeRatingSortHelper(direction);
            //}
            #endregion

            switch (sortExpression)
            {
                case "RecipeName":
                    return SimpleServingsLibrary.Recipe.Recipe.GetRecipNameSortHelper(direction);
                case "RecipeStatus":
                    return SimpleServingsLibrary.Recipe.Recipe.GetRecipStatusSortHelper(direction);
                case "RecipeView":
                    return SimpleServingsLibrary.Recipe.Recipe.GetRecipViewSortHelper(direction);
                case "ContributedBy":
                    return SimpleServingsLibrary.Recipe.Recipe.GetContributedBySortHelper(direction);
                case "CreatedOn":
                    return SimpleServingsLibrary.Recipe.Recipe.GetCreatedOnSortHelper(direction);
                case "RecipeRating":
                    return SimpleServingsLibrary.Recipe.Recipe.GetRecipeRatingSortHelper(direction);
                default:
                    break;
            }

            return null;
        }

        private void SortGridView(string sortExpression, SortDirection direction)
        {
            IComparer <SimpleServingsLibrary.Recipe.Recipe> comparer;

            if (direction == SortDirection.Ascending)
            {
                comparer = GetSortComparer(sortExpression, SimpleServingsLibrary.Recipe.Recipe.SortDirection.Ascending);
            }
            else
            {
                comparer = GetSortComparer(sortExpression, SimpleServingsLibrary.Recipe.Recipe.SortDirection.Descending);
            }

            SimpleServingsLibrary.Recipe.Recipes recipeList = GetRecipeListFromCache();
            recipeList.Sort(comparer);
            PopGrid(recipeList);

            //save sort comparer to cache
            Session["SortComparer"] = comparer;
        }

        private void CacheRecipeList(SimpleServingsLibrary.Recipe.Recipes recipeList, SimpleServingsLibrary.Recipe.Recipe.SortType type)
        {
            ViewState["SortType"] = type;
            Session[type.ToString()] = recipeList;
        }

        private void CacheRecipeList(SimpleServingsLibrary.Recipe.Recipes recipeList)
        {
            
            Session["SortRecipeList"] = recipeList;
        }

        private SimpleServingsLibrary.Recipe.Recipes GetRecipeListFromCache()
        {
            SimpleServingsLibrary.Recipe.Recipe.SortType type = (SimpleServingsLibrary.Recipe.Recipe.SortType)ViewState["SortType"];
            return (SimpleServingsLibrary.Recipe.Recipes)Session[type.ToString()];
        }

        protected void gvRecipes_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (IsSortExpressionChanged(e.SortExpression) == true)
            {
                SortGridView(e.SortExpression, SortDirection.Ascending);

                ViewState["SortDirection"] = SortDirection.Ascending;
            }
            else
            {
                SortGridView(e.SortExpression, GetSortDirection());
            }

            ViewState["SortExpression"] = e.SortExpression;
        }

        protected void gvRecipes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRecipes.PageIndex = e.NewPageIndex;
            PopGrid(GetRecipeListFromCache());
        }


        #region rating prototype
        //7-7-2016
        //protected void gvRecipes_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Rating rtRecipe = (Rating)e.Row.FindControl("rtRecipe");
        //        rtRecipe.MaxRating = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RecipeMaxRating"]);

        //        try
        //        {
        //            int recipeId = Convert.ToInt32(((Label)e.Row.FindControl("lblRecipeID")).Text);
        //            rtRecipe.CurrentRating = (int)Math.Round(SimpleServingsLibrary.Recipe.Recipe.GetRecipeAvgRatingByRecipeID(recipeId), 0);
        //            rtRecipe.ToolTip = string.Format("{0} user(s) rated this recipe", SimpleServingsLibrary.Recipe.Recipe.GetTotalRecipeRatings(recipeId));

        //        }
        //        catch
        //        {
        //            rtRecipe.CurrentRating = 0;
        //            rtRecipe.ToolTip = "0 user(s) have rated this recipe";
        //        }

        //        rtRecipe.ReadOnly = true;
        //    }
        //}
        #endregion

    }
}