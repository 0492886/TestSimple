using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Recipe
{
    class RecipeDB
    {
        internal static int AddRecipe(string recipeName, int yield, string servingSize, 
            string portionSize,string sku, int recipeView, int createdBy,
            int supplierID, int contributorID, string recipeImageName, int contributorTypeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddRecipe");
                db.AddInParameter(cmd, "@recipeName", DbType.String, recipeName);
                db.AddInParameter(cmd, "@yield", DbType.Int32, yield);
                db.AddInParameter(cmd, "@servingSize", DbType.String, servingSize);
                db.AddInParameter(cmd, "@portionSize", DbType.String, portionSize);
                db.AddInParameter(cmd, "@sku", DbType.String, sku);
                db.AddInParameter(cmd, "@recipeView", DbType.Int32, recipeView);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@supplierID", DbType.Int32, supplierID);
                db.AddInParameter(cmd, "@contributorID", DbType.Int32, contributorID);
                db.AddInParameter(cmd, "@recipeImageName", DbType.String, recipeImageName);
                db.AddInParameter(cmd, "@contributorTypeID", DbType.Int32, contributorTypeID);
                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal static bool EditRecipe(int recipeID,string recipeName, int yield,
            string servingSize,string portionSize, string sku, int recipeView, int supplierID, 
            int contributorID, int editedBy, string recipeImageName, int contributorTypeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_EditRecipe");
                db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@recipeName", DbType.String, recipeName);
                db.AddInParameter(cmd, "@yield", DbType.Int32, yield);
                db.AddInParameter(cmd, "@servingSize", DbType.String, servingSize);
                db.AddInParameter(cmd, "@portionSize", DbType.String, portionSize);
                db.AddInParameter(cmd, "@sku", DbType.String, sku);
                db.AddInParameter(cmd, "@recipeView", DbType.Int32, recipeView);
                db.AddInParameter(cmd, "@supplierID", DbType.Int32, supplierID);
                db.AddInParameter(cmd, "@contributorID", DbType.Int32, contributorID);
                db.AddInParameter(cmd, "@editedBy", DbType.Int32, editedBy);
                db.AddInParameter(cmd, "@recipeImageName", DbType.String, recipeImageName);
                db.AddInParameter(cmd, "@contributorTypeID", DbType.Int32, contributorTypeID);
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }

        }

        internal static SqlDataReader GetRecipeByRecipeID(int recipeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipeByRecipeID");
            db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Recipe By RecipeID did not return a record!");
            }
        }

        internal static SqlDataReader GetAllRecipes(bool publicOnly)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllRecipes");
            db.AddInParameter(cmd, "@publicOnly", DbType.Boolean, publicOnly);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get All Recipes did not return a record!");
            }
        }
        internal static SqlDataReader GetRecipesforTagsSearch(List<int> TagIDs, string RecipeSearchText , int StaffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("SP_SearchRecipesForTags_New");

            db.AddInParameter(cmd, "@RecipeSearchText", DbType.String, RecipeSearchText);
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, StaffID);
            var table = new DataTable();
            table.Columns.Add("TagIDs", typeof(string));

            foreach (int i in TagIDs)
            {
                table.Rows.Add(i);

            }

            SqlParameter sp = new SqlParameter();
            sp.SqlDbType = SqlDbType.Structured;
            sp.ParameterName = "@Tags";
            sp.Value = table;
            cmd.Parameters.Add(sp);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("No Records found!");
            }
            
 
        }

        internal static bool IsRecipeNameTaken(string recipeName,int recipeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_IsRecipeNameTaken");
            db.AddInParameter(cmd, "@recipeName", DbType.String, recipeName);
            db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static bool EditRecipeStatus(int recipeID,int recipeStatus, int editedBy, string customMsg)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_EditRecipeStatus");
                db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID); 
                db.AddInParameter(cmd, "@recipeStatus", DbType.Int32, recipeStatus);
                db.AddInParameter(cmd, "@customMsg", DbType.String, customMsg);
                db.AddInParameter(cmd, "@editedBy", DbType.Int32, editedBy);                
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }

        }

        internal static SqlDataReader GetRecipesByStaffID(int staffID, int recipeView)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipesByStaffID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@recipeView", DbType.Int32, recipeView);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get RecipesByStaffID did not return a record!");
            }
        }

        internal static SqlDataReader GetRecipesByStaffIDAndRecipeID(int recipeID, int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipesByStaffIDAndRecipeID");
            db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                return null;
                //throw new Exception("Get RecipesByStaffIDAndRecipeName did not return a record!");
            }
        }

        //5-16-2016
        internal static SqlDataReader GetRecipesByStaffIDAndRecipeName(int staffID, int recipeView, string name, 
            int recipeStatus, int recipeTag, int count, bool isActive)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipesByStaffIDAndRecipeName");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@recipeView", DbType.Int32, recipeView);
            db.AddInParameter(cmd, "@recipeName", DbType.String, name);
            db.AddInParameter(cmd, "@recipeStatus", DbType.Int32, recipeStatus);
            db.AddInParameter(cmd, "@recipeTag", DbType.Int32, recipeTag);
            db.AddInParameter(cmd, "@count", DbType.Int32, count);
            db.AddInParameter(cmd, "@isActive", DbType.String, isActive);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get RecipesByStaffIDAndRecipeName did not return a record!");
            }
        }

        internal static SqlDataReader GetRecipesForRepeaterByStaffIDAndRecipeName(int staffID, int recipeView, string name,
           int recipeStatus, int recipeTag, int count)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipesForRepeaterByStaffIDAndRecipeName");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@recipeView", DbType.Int32, recipeView);
            db.AddInParameter(cmd, "@recipeName", DbType.String, name);
            db.AddInParameter(cmd, "@recipeStatus", DbType.Int32, recipeStatus);
            db.AddInParameter(cmd, "@recipeTag", DbType.Int32, recipeTag);
            db.AddInParameter(cmd, "@count", DbType.Int32, count);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get RecipesForRepeaterByStaffIDAndRecipeName did not return a record!");
            }
        }

        internal static string GetRecipeNameByRecipeID(int recipeID)
        {
            string recipeName = string.Empty;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipeNameByRecipeID");
                db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
                recipeName = db.ExecuteScalar(cmd).ToString();
            }
            catch { }

            return recipeName;
        }

        internal static SqlDataReader GetRecipeByFavorite(int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Recipe_By_Favorite");
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        internal static void UpdateRecipeSetInactive(int recipeID, int staffID = 0)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Recipe_Set_Inactive");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                if (staffID > 0)
                {
                    db.AddInParameter(cmd, "@StaffID", System.Data.DbType.Int32, staffID);
                }

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //7-20-2016
        internal static void UpdateRecipeSetActive(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Recipe_Set_Active");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region recipe rating data access
        //7-8-2016
        internal static void AddRecipeRating(int recipeID, int staffID, int rating)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_RecipeRating");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@StaffID", System.Data.DbType.Int32, staffID);
                db.AddInParameter(cmd, "@Rating", System.Data.DbType.Int32, rating);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static int GetRecipeRatingByID(int recipeID, int staffID)
        {
            //int rating = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipeRatingByID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@StaffID", System.Data.DbType.Int32, staffID);

                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        internal static float GetRecipeRatingByRecipeID(int recipeID)
        {
            float rating = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipeRatingByRecipeID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                DataSet ds = db.ExecuteDataSet(cmd);

                float.TryParse(ds.Tables[0].Rows[0]["AvgRating"].ToString(),  out rating);
                return rating;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static int GetTotalRecipeRatingsByID(int recipeID)
        {
            int count = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipeRatingByRecipeID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                DataSet ds = db.ExecuteDataSet(cmd);

                count = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCnt"]);
            }
            catch (Exception ex)
            {
                count = 0;
            }

            return count;
        }
        #endregion recipe rating data access

        #region featured recipe data access
        //8-4-2016
        internal static int AddFeaturedRecipe(int recipeID, string recipeImage, string recipePrint, int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_FeaturedRecipe");
                db.AddInParameter(cmd, "@RecipeId", DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@FeaturedRecipeImage", DbType.String, recipeImage);
                db.AddInParameter(cmd, "@FeaturedRecipePrint", DbType.String, recipePrint);
                db.AddInParameter(cmd, "@StaffId", DbType.Int32, staffID);
                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static string GetFeaturedRecipeImage()
        {
            string featuredRecipeImage = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_FeaturedRecipeImg");
                featuredRecipeImage = Convert.ToString(db.ExecuteScalar(cmd));
            }
            catch { }

            return featuredRecipeImage;
        }
        //8-2-2016
        internal static bool UpdateFeaturedRecipe(int recipeID, string recipePrint, int staffID)
        {
            bool returnVal = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_FeaturedRecipe");
                db.AddInParameter(cmd, "@RecipeId", DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@FeaturedRecipePrint", DbType.String, recipePrint);
                db.AddInParameter(cmd, "@StaffId", DbType.Int32, staffID);
                db.ExecuteNonQuery(cmd);

                returnVal = true;
            }
            catch { returnVal = false; }

            return returnVal;
        }
        internal static string GetFeaturedRecipePF()
        {
            string featuredRecipePF = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_FeaturedRecipePF");
                featuredRecipePF = Convert.ToString(db.ExecuteScalar(cmd));
            }
            catch { }

            return featuredRecipePF;
        }
        internal static string GetFeaturedRecipeName()
        {
            string featuredRecipeName = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_FeaturedRecipeName");
                featuredRecipeName = Convert.ToString(db.ExecuteScalar(cmd));
            }
            catch { }

            return featuredRecipeName;
        }
        //8-4-2016
        internal static SqlDataReader GetFeaturedRecipe()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_FeaturedRecipe");

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion featured recipe data access

    }

}
