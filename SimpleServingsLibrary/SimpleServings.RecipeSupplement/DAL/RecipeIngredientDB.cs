using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;
using System.Data;

namespace SimpleServingsLibrary.RecipeSupplement
{
    internal class RecipeIngredientDB
    {
        internal static void AddRecipeIngredient(int recipeID, double quantity, int numerator, int denominator, int measureUnit, string description, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_RecipeIngredient");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@Quantity", System.Data.DbType.Double, quantity);
                db.AddInParameter(cmd, "@Numerator", System.Data.DbType.Int32, numerator);
                db.AddInParameter(cmd, "@Denominator", System.Data.DbType.Int32, denominator);
                db.AddInParameter(cmd, "@MeasureUnit", System.Data.DbType.Int32, measureUnit);
                db.AddInParameter(cmd, "@Description", System.Data.DbType.String, description);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetRecipeIngredientByRecipeID(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeIngredient_By_RecipeID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void EditRecipeIngredientByID(int ingredientID, double quantity, int numerator, int denominator, int measureUnit, string description)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_RecipeIngredient_By_ID");

                db.AddInParameter(cmd, "@IngredientID", System.Data.DbType.Int32, ingredientID);
                db.AddInParameter(cmd, "@Quantity", System.Data.DbType.Double, quantity);
                db.AddInParameter(cmd, "@Numerator", System.Data.DbType.Int32, numerator);
                db.AddInParameter(cmd, "@Denominator", System.Data.DbType.Int32, denominator);
                db.AddInParameter(cmd, "@MeasureUnit", System.Data.DbType.Int32, measureUnit);
                db.AddInParameter(cmd, "@Description", System.Data.DbType.String, description);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveRecipeIngredientByRecipeID(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_RecipeIngredient_By_RecipeID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal static void RemoveRecipeIngredientByID(int ingredientID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_RecipeIngredient_ByID");

                db.AddInParameter(cmd, "@IngredientID", System.Data.DbType.Int32, ingredientID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void EditRecipeIngredientByIDTest(int ingredientID, int numerator, int denominator)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_RecipeIngredient_By_ID_Test");

                db.AddInParameter(cmd, "@IngredientID", System.Data.DbType.Int32, ingredientID);
                db.AddInParameter(cmd, "@Numerator", System.Data.DbType.Int32, numerator);
                db.AddInParameter(cmd, "@Denominator", System.Data.DbType.Int32, denominator);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
