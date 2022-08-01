using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.RecipeSupplement
{
     internal class RecipeNutritionDB
    {
         internal static void AddRecipeNutrition(int nutrientID, int recipeID, string value, int percentage, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_RecipeNutrition");

                db.AddInParameter(cmd, "@NutrientID", System.Data.DbType.Int32, nutrientID);
                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@Value", System.Data.DbType.String, value);
                db.AddInParameter(cmd, "@Percentage", System.Data.DbType.Int32, percentage);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         internal static void EditRecipeNutritionByID(int nutritionID, string value, int percentage)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_RecipeNutrition_By_NutritionID");

                db.AddInParameter(cmd, "@NutritionID", System.Data.DbType.Int32, nutritionID);
                db.AddInParameter(cmd, "@Value", System.Data.DbType.String, value);
                db.AddInParameter(cmd, "@Percentage", System.Data.DbType.Int32, percentage);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         internal static void EditRecipeNutritionByNutrientIDAndRecipeID(int nutrientID, int recipeID, string value, int percentage)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_RecipeNutrition_By_NutrientID_And_RecipeID");

                db.AddInParameter(cmd, "@NutrientID", System.Data.DbType.Int32, nutrientID);
                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@Value", System.Data.DbType.String, value);
                db.AddInParameter(cmd, "@Percentage", System.Data.DbType.Int32, percentage);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetRecipeNutritionByRecipeID(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeNutrition_By_RecipeID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal static SqlDataReader GetRecipeNutritionFactsByRecipeID(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeNutrition_Facts_By_RecipeID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetRecipeNutritionFactsMoreByRecipeID(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeNutrition_Facts_More_By_RecipeID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetRecipeNutritionDisplayByRecipeID(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeNutrition_By_RecipeID_Display");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetRecipeNutritionMainByRecipeID(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeNutrition_Main_By_RecipeID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
