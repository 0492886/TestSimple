using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleServingsLibrary.Shared;
using System.Data.SqlClient;
using System.Collections;

namespace SimpleServingsLibrary.Recipe
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string Yield { get; set; }
        public string ServingSize { get; set; }
        public string SKU { get; set; }
        public int RecipeView { get; set; }
        public int RecipeStatus { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public DateTime CreatedOnDT
        {
            get { return Convert.ToDateTime(CreatedOn); }
        }
        public int RemovedBy { get; set; }
        public string LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public string RemovedOn { get; set; }
        public int SupplierID { get; set; }
        public int ContributorID { get; set; }
        public string CreatedByText { get; set; }
        public string LastUpdatedByText { get; set; }
        public string RemovedByText { get; set; }
        public string RecipeStatusText { get; set; }
        public string RecipeViewText { get; set; }
        public string PortionSize { get; set; }
        public string ContributedBy { get; set; }
        public string RecipeImageName { get; set; }
        public string ActiveStatus
        {
            get 
            {
                if (IsActive)
                {
                    return "Active";
                }
                else
                {
                    return "Not Active";
                }
            }
        }
        public int ContributorTypeID { get; set; }
        public string ContributorTypeIDText { get; set; }

        //7-11-2016
        public int AvgRecipeRating
        {
            //get
            //{
            //    float rating = 0;
            //    if (this.RecipeID > 0)
            //    {
            //        try
            //        {
            //            rating = RecipeDB.GetRecipeRatingByRecipeID(this.RecipeID);
            //        }
            //        catch { rating = 0; }
            //    }
            //    return rating;
            //}
            get;
            set;
        }
        public int NumTimesRated
        {
            //get
            //{
            //    int count = 0;
            //    if (this.RecipeID > 0)
            //    {
            //        try
            //        {
            //            count = RecipeDB.GetTotalRecipeRatingsByID(this.RecipeID);
            //        }
            //        catch { count = 0; }
            //    }
            //    return count;
            //}
            get;
            set;
        }

        #region Private Methods

        private void PopRecipe(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    RecipeName = Convert.ToString(dr["RecipeName"]);
                    Yield = Convert.ToString(dr["Yield"]);
                    ServingSize = Convert.ToString(dr["ServingSize"]);
                    SKU = Convert.ToString(dr["SKU"]);
                    RecipeView = Convert.ToInt32(dr["RecipeView"]);
                    RecipeStatus = Convert.ToInt32(dr["RecipeStatus"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    LastUpdatedBy = Convert.ToInt32(dr["LastUpdatedBy"]);
                    LastUpdatedOn = Convert.ToString(dr["LastUpdatedOn"]);
                    RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                    RemovedOn = Convert.ToString(dr["RemovedOn"]);
                    SupplierID = Convert.ToInt32(dr["SupplierID"]);
                    ContributorID = Convert.ToInt32(dr["ContributorID"]);
                    CreatedByText = Convert.ToString(dr["CreatedByText"]);
                    LastUpdatedByText = Convert.ToString(dr["LastUpdatedByText"]);
                    RemovedByText = Convert.ToString(dr["RemovedByText"]);
                    RecipeStatusText = Convert.ToString(dr["RecipeStatusText"]);
                    RecipeViewText = Convert.ToString(dr["RecipeViewText"]);
                    PortionSize = Convert.ToString(dr["PortionSize"]);
                    ContributedBy = Convert.ToString(dr["ContributedBy"]);
                    RecipeImageName = Convert.ToString(dr["RecipeImageName"]);
                    ContributorTypeID = Convert.ToInt32(dr["ContributorTypeID"]);
                    ContributorTypeIDText = Convert.ToString(dr["ContributorTypeIDText"]);

                    //7-12-2016
                    try
                    {
                        //AvgRecipeRating = GetRecipeAvgRatingByRecipeID(RecipeID);
                        //NumTimesRated = GetTotalRecipeRatings(RecipeID);

                        AvgRecipeRating = Convert.ToInt32(dr["AvgRating"]);
                        NumTimesRated = Convert.ToInt32(dr["NumRatings"]);
                    }
                    catch
                    {
                        AvgRecipeRating = 0;
                        NumTimesRated = 0;
                    }
                }
            }
        }

        private static Recipes PopRecipes(SqlDataReader dr)
        {
            Recipes recipes = new Recipes();
            Recipe recipe;
            using (dr)
            {
                while (dr.Read())
                {
                    recipe = new Recipe();
                    recipe.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    recipe.RecipeName = Convert.ToString(dr["RecipeName"]);
                    recipe.Yield = Convert.ToString(dr["Yield"]);
                    recipe.ServingSize = Convert.ToString(dr["ServingSize"]);
                    recipe.SKU = Convert.ToString(dr["SKU"]);
                    recipe.RecipeView = Convert.ToInt32(dr["RecipeView"]);
                    recipe.RecipeStatus = Convert.ToInt32(dr["RecipeStatus"]);
                    recipe.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    recipe.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    recipe.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    recipe.LastUpdatedBy = Convert.ToInt32(dr["LastUpdatedBy"]);
                    recipe.LastUpdatedOn = Convert.ToString(dr["LastUpdatedOn"]);
                    recipe.RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                    recipe.RemovedOn = Convert.ToString(dr["RemovedOn"]);
                    recipe.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                    recipe.ContributorID = Convert.ToInt32(dr["ContributorID"]);
                    recipe.CreatedByText = Convert.ToString(dr["CreatedByText"]);
                    recipe.LastUpdatedByText = Convert.ToString(dr["LastUpdatedByText"]);
                    recipe.RemovedByText = Convert.ToString(dr["RemovedByText"]);
                    recipe.RecipeStatusText = Convert.ToString(dr["RecipeStatusText"]);
                    recipe.RecipeViewText = Convert.ToString(dr["RecipeViewText"]);
                    recipe.PortionSize = Convert.ToString(dr["PortionSize"]);
                    recipe.ContributedBy = Convert.ToString(dr["ContributedBy"]);
                    recipe.RecipeImageName = Convert.ToString(dr["RecipeImageName"]);
                    recipe.ContributorTypeID = Convert.ToInt32(dr["ContributorTypeID"]);
                    recipe.ContributorTypeIDText = Convert.ToString(dr["ContributorTypeIDText"]);

                    //7-12-2016
                    try
                    {
                        //recipe.AvgRecipeRating = GetRecipeAvgRatingByRecipeID(recipe.RecipeID);
                        //recipe.NumTimesRated = GetTotalRecipeRatings(recipe.RecipeID);

                        recipe.AvgRecipeRating = Convert.ToInt32(dr["AvgRating"]);
                        recipe.NumTimesRated = Convert.ToInt32(dr["NumRatings"]);
                    }
                    catch
                    {
                        recipe.AvgRecipeRating = 0;
                        recipe.NumTimesRated = 0;
                    }

                    recipes.Add(recipe);
                }
            }
            return recipes;

        }

        private static Recipes PopRecipesForRepeater(SqlDataReader dr)
        {
            Recipes recipes = new Recipes();
            Recipe recipe;
            using (dr)
            {
                while (dr.Read())
                {
                    recipe = new Recipe();
                    recipe.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    recipe.RecipeName = Convert.ToString(dr["RecipeName"]);
                    recipe.ContributedBy = Convert.ToString(dr["ContributedBy"]);
                    if (Convert.ToString(dr["CreatedOn"]) != null)
                    {
                        recipe.CreatedOn = Convert.ToString(dr["CreatedOn"]); 
                    }
                    
                    recipes.Add(recipe);
                }
            }
            return recipes;

        }

        private void ValidateRecipe()
        {
            
            try
            {
                //if (RecipeStatus == GlobalEnum.RecipeStatus_Approved)
                //    throw new Exception("A recipe cannot be modified once it is approved!");

                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] { RecipeName, Yield, ServingSize,RecipeView });
                ArrayList fieldNames = new ArrayList(new string[] { "Recipe Name", "Yield", "Serving Size", "Recipe View" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));
                sb.Append(Validation.IsInt32(Yield, "Yield"));
                //if (RecipeView == GlobalEnum.RecipeView_Public)
                //    sb.Append(Validation.ValidateRequired(SKU,"SKU #", true));
                if (RecipeView == GlobalEnum.RecipeView_SponsorPrivate)
                    sb.Append(Validation.ValidateRequired(SupplierID.ToString(), "Sponsor", false));
                if (RecipeView == GlobalEnum.RecipeView_CatererPrivate)
                    sb.Append(Validation.ValidateRequired(SupplierID.ToString(), "Caterer", false));
               // if(IsRecipeNameTaken(RecipeName,RecipeID))
                //    sb.Append("Recipe Name is already taken, please provide a different name!<br>");

                if (sb.Length != 0)
                    throw new Exception(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        private bool IsRecipeNameTaken(string recipeName,int recipeID)
        {
            return RecipeDB.IsRecipeNameTaken(recipeName,recipeID);
        }

        #endregion

        #region Public Methods
        
        public int AddRecipe()
        {
            ValidateRecipe();
            return RecipeDB.AddRecipe(RecipeName, Convert.ToInt32(Yield), ServingSize,PortionSize, SKU,
                RecipeView, CreatedBy,SupplierID,ContributorID,RecipeImageName,ContributorTypeID );
        }

        public bool EditRecipe(int editedBy)
        {
            ValidateRecipe();
            return RecipeDB.EditRecipe(RecipeID, RecipeName, Convert.ToInt32(Yield), ServingSize, PortionSize, SKU,
                RecipeView, SupplierID,ContributorID,editedBy,RecipeImageName,ContributorTypeID);
        }
        public bool EditRecipeStatus(int recipeStatus,int editedBy, string customMsg)
        {            
            return RecipeDB.EditRecipeStatus(RecipeID,recipeStatus,editedBy, customMsg);
        }

        public static Recipes GetRecipesforTagsSearch(List<int> TagIDs, string RecipeSearchText, int StaffID)
        {
            return PopRecipesForRepeater(RecipeDB.GetRecipesforTagsSearch(TagIDs, RecipeSearchText, StaffID));
 
        }

        public void GetRecipeByRecipeID(int recipeID)
        {
            PopRecipe(RecipeDB.GetRecipeByRecipeID(recipeID));
        }
        //returns all recipes
        public static Recipes GetAllRecipes(bool publicOnly)
        {
            return PopRecipes(RecipeDB.GetAllRecipes(publicOnly));
        }
        public static Recipes GetRecipesByStaffID(int staffID, int recipeView)
        {
            return PopRecipes(RecipeDB.GetRecipesByStaffID(staffID,recipeView));
        }


        public static Recipes GetRecipesByStaffIDAndRecipeID(int recipeID, int staffID)
        {
            if (RecipeDB.GetRecipesByStaffIDAndRecipeID(recipeID, staffID) != null)
            {
                return PopRecipes(RecipeDB.GetRecipesByStaffIDAndRecipeID(recipeID,staffID));
            }

            else
            {
                return null;
            }
            
        }

        //5-16-2016
        public static Recipes GetRecipesByStaffIDAndRecipeName(int staffID, int recipeView, string name, int recipeStatus, int recipeTag,int count, bool isActive = true)
        {
            return PopRecipes(RecipeDB.GetRecipesByStaffIDAndRecipeName(staffID, recipeView,name, recipeStatus, recipeTag, count, isActive));
        }
      
        public static string GetRecipeNameByRecipeID(int recipeID)
        {
            return RecipeDB.GetRecipeNameByRecipeID(recipeID);
        }

        public static Recipes GetRecipeByFavorite(int staffID)
        {
            return PopRecipes(RecipeDB.GetRecipeByFavorite(staffID));
        }

        public static void Deactivate(int recipeID, int staffID = 0)
        {
            RecipeDB.UpdateRecipeSetInactive(recipeID, staffID);
        }
        //reactivate recipe
        public static void Activate(int recipeID)
        {
            RecipeDB.UpdateRecipeSetActive(recipeID);
        }

        #region recipe rating
        //7-8-2016
        public static void AddRecipeRating(int recipeID, int staffID, int rating)
        {
            RecipeDB.AddRecipeRating(recipeID, staffID, rating);
        }
        public static int GetRecipeRatingByID(int recipeID, int staffID)
        {
            return RecipeDB.GetRecipeRatingByID(recipeID, staffID);
        }
        public static float GetRecipeAvgRatingByRecipeID(int recipeID)
        {
            return RecipeDB.GetRecipeRatingByRecipeID(recipeID);
        }
        public static int GetTotalRecipeRatings(int recipeID)
        {
            return RecipeDB.GetTotalRecipeRatingsByID(recipeID);
        }

        //07-14-2016
        public void AddRecipeRating(int staffID, int rating)
        {
            RecipeDB.AddRecipeRating(this.RecipeID, staffID, rating);
            this.AvgRecipeRating = RecipeDB.GetTotalRecipeRatingsByID(this.RecipeID);
        }
        #endregion recipe rating

        #region featured recipe
        //08-04-2016
        public static void AddFeaturedRecipe(int recipeID, string recipeImage, string recipePrint, int staffID)
        {
            RecipeDB.AddFeaturedRecipe(recipeID, recipeImage, recipePrint, staffID);
        }
        public static string GetFeaturedRecipeImage()
        {
            return RecipeDB.GetFeaturedRecipeImage();
        }
        //08-02-2016
        public static void UpdateFeaturedRecipe(int recipeID, string recipePrint, int staffID)
        {
            if (!RecipeDB.UpdateFeaturedRecipe(recipeID, recipePrint, staffID))
                throw new Exception("unable to update featured recipe");

        }
        public static string GetFeaturedRecipePrintFile()
        {
            return RecipeDB.GetFeaturedRecipePF();
        }
        public static string GetFeaturedRecipeName()
        {
            return RecipeDB.GetFeaturedRecipeName();
        }
        //08-04-2016
        public void GetFeaturedRecipe()
        {
            PopRecipe(RecipeDB.GetFeaturedRecipe());
        }
        #endregion featured recipe

        #endregion

        #region Sorting
        public enum SortType
        {   
            RegularList,
            FavoriteList
        }

        public enum SortDirection
        {
            Ascending,
            Descending
        }

        private class SortRecipeNameASC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.RecipeName.CompareTo(y.RecipeName);
            }
        }

        private class SortRecipeNameDESC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.RecipeName.CompareTo(y.RecipeName) * (-1);
            }
        }

        private class SortRecipeStatusASC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.RecipeStatus.CompareTo(y.RecipeStatus);
            }
        }

        private class SortRecipeStatusDESC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.RecipeStatus.CompareTo(y.RecipeStatus) * (-1);
            }
        }

        //multi-level sort by recipe view and name
        private class SortRecipeViewASC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                int result = x.RecipeView.CompareTo(y.RecipeView);
                if (result == 0)
                    result = x.RecipeName.CompareTo(y.RecipeName);
                return result;
            }
        }
        //multi-level sort by recipe view and name
        private class SortRecipeViewDESC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                int result = x.RecipeView.CompareTo(y.RecipeView) * (-1);
                if (result == 0)
                    result = x.RecipeName.CompareTo(y.RecipeName);
                return result;
            }
        }

        private class SortContributedByASC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.ContributedBy.CompareTo(y.ContributedBy);
            }
        }

        private class SortContributedByDESC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.ContributedBy.CompareTo(y.ContributedBy) * (-1);
            }
        }

        private class SortCreatedOnASC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.CreatedOnDT.CompareTo(y.CreatedOnDT);
            }
        }

        private class SortCreatedOnDESC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.CreatedOnDT.CompareTo(y.CreatedOnDT) * (-1);
            }
        }

        //sort by recipe rating
        private class SortRecipeRatingASC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.AvgRecipeRating.CompareTo(y.AvgRecipeRating);
            }
        }
        private class SortRecipeRatingDESC : IComparer<Recipe>
        {
            public int Compare(Recipe x, Recipe y)
            {
                return x.AvgRecipeRating.CompareTo(y.AvgRecipeRating) * (-1);
            }
        }

        public static IComparer<Recipe> GetRecipNameSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortRecipeNameASC();
            }
            else
            {
                return new SortRecipeNameDESC();
            }
        }

        public static IComparer<Recipe> GetRecipStatusSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortRecipeStatusASC();
            }
            else
            {
                return new SortRecipeStatusDESC();
            }
        }

        public static IComparer<Recipe> GetRecipViewSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortRecipeViewASC();
            }
            else
            {
                return new SortRecipeViewDESC();
            }
        }

        public static IComparer<Recipe> GetContributedBySortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortContributedByASC();
            }
            else
            {
                return new SortContributedByDESC();
            }
        }

        public static IComparer<Recipe> GetCreatedOnSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortCreatedOnASC();
            }
            else
            {
                return new SortCreatedOnDESC();
            }
        }
        //sort by recipe rating
        public static IComparer<Recipe> GetRecipeRatingSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortRecipeRatingASC();
            }
            else
            {
                return new SortRecipeRatingDESC();
            }
        }
        #endregion


    }
    public class Recipes : List<Recipe> { }
}
