using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Recipe
{
    public class RecipeTag
    {
        public int RecipeTagID { get; set; }
        public int RecipeID { get; set; }
        public int TagID { get; set; }        
        public string TagName { get; set; }

        public int RecipeCategroyTagID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        #region Private Methods

        private void PopRecipeTag(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    RecipeTagID = Convert.ToInt32(dr["RecipeTagID"]);
                    RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    TagID = Convert.ToInt32(dr["TagID"]);
                    TagName = Convert.ToString(dr["TagName"]);
                }
            }
        }

        private static RecipeTags PopRecipeTags(SqlDataReader dr)
        {
            RecipeTags recipeTags = new RecipeTags();
            RecipeTag recipeTag;
            using (dr)
            {
                while (dr.Read())
                {
                    recipeTag = new RecipeTag();
                    recipeTag.RecipeTagID = Convert.ToInt32(dr["RecipeTagID"]);
                    recipeTag.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    recipeTag.TagID = Convert.ToInt32(dr["TagID"]);
                    recipeTag.TagName = Convert.ToString(dr["TagName"]);
                    recipeTag.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    recipeTag.CategoryName = Convert.ToString(dr["CategoryName"]);
                    recipeTags.Add(recipeTag);
                }
            }
            return recipeTags;

        }


        private static RecipeTags PopRecipeCategoryandTags(SqlDataReader dr)
        {
            RecipeTags recipeTags = new RecipeTags();
            RecipeTag recipeTag;
            using (dr)
            {
                while (dr.Read())
                {
                    recipeTag = new RecipeTag();
                    recipeTag.RecipeCategroyTagID = Convert.ToInt32(dr["RecipeCategroyTagID"]);
                    recipeTag.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    recipeTag.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    recipeTag.TagID = Convert.ToInt32(dr["TagID"]);
                    recipeTag.TagName = Convert.ToString(dr["TagName"]);
                    recipeTag.CategoryName = Convert.ToString(dr["CategoryName"]);
                    recipeTags.Add(recipeTag);
                }
            }
            return recipeTags;

        }
        // mandy add
        private static List<int> PopGetTagIdByRecipeID(SqlDataReader dr)
        {
            List<int> lstTagId = new List<int>();
            using (dr)
            {
                while (dr.Read())
                {
                    int tagId = Convert.ToInt32(dr["tagID"]);
                    lstTagId.Add(tagId);
                }
            }

            return lstTagId;
        }


        private void ValidateRecipeTag()
        {
            //try
            //{
            //    StringBuilder sb = new StringBuilder();
            //    ArrayList values = new ArrayList(new Object[] { RecipeName, Yield, ServingSize, IsPublic, RecipeStatus });
            //    ArrayList fieldNames = new ArrayList(new string[] { "Recipe Name", "Yield", "Serving Size", "Recipe View", "Recipe Status" });
            //    sb.Append(Validation.AreNotEmpty(values, fieldNames));
            //    if (IsPublic)
            //        sb.Append(Validation.ValidateRequired(SKU, "SKU#", true));

            //    if (sb.Length != 0)
            //        throw new Exception(sb.ToString());
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

        }

        #endregion

        #region Public Methods

        public int AddRecipeTag()
        {
            //ValidateRecipeTag();
            return RecipeTagDB.AddRecipeTag(RecipeID, TagID);
        }

        public void AddCategoryandTagForRecipe(int RecipeID, List<int> CategoryIDs, List<int> TagIDs, int StaffID)
        {
            RecipeTagDB.AddCategoryandTagForRecipe(RecipeID, CategoryIDs, TagIDs, StaffID);

        }



        public bool RemoveRecipeTagsByRecipeID(int recipeID)
        {
            return RecipeTagDB.RemoveRecipeTagsByRecipeID(recipeID);
        }

        public void GetRecipeTagByRecipeTagID(int recipeTagID)
        {
            PopRecipeTag(RecipeTagDB.GetRecipeTagByRecipeTagID(recipeTagID));
        }

        public static RecipeTags GetAllRecipeTags()
        {
            return PopRecipeTags(RecipeTagDB.GetAllRecipeTags());
        }
      

        public static RecipeTags GetRecipeTagsByRecipeID(int recipeID)
        {
            return PopRecipeTags(RecipeTagDB.GetRecipeTagsByRecipeID(recipeID));
        }


        public static RecipeTags GetCategoriesandTagsByRecipeID(int recipeID)
        {
            return PopRecipeCategoryandTags(RecipeTagDB.GetCategoriesandTagsByRecipeTID(recipeID));
        }
        //Mandy
        public static List<int> GetTagIdByRecipeID(int recipeID)
        {
            return PopGetTagIdByRecipeID(RecipeTagDB.GetTagIdByRecipeID(recipeID));
        }


        public static void AutoEditRecipeTags(int StaffID)
        {
            RecipeTagDB.AutoUpdateRecipeTags(StaffID);
        }

        #endregion

    }
    public class RecipeTags : List<RecipeTag> { }
}
