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
    internal class RecipeSupplementDB
    {
        internal static void AddRecipeSupplement(int recipeID, string description, int recipeSupType, int orders, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_RecipeSupplement");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@Description", System.Data.DbType.String, description);
                db.AddInParameter(cmd, "@RecipeSupType", System.Data.DbType.Int32, recipeSupType);
                db.AddInParameter(cmd, "@Orders", System.Data.DbType.Int32, orders);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetRecipeSupplementsByRecipeIDAndType(int recipeID, int recipeSupType)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeSupplement_By_RecipeID_And_Type");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@RecipeSupType", System.Data.DbType.Int32, recipeSupType);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //added 1-26-2016
        internal static SqlDataReader GetRecipeSuppCodesByRecipeIDAndType(int recipeID, int recipeSupType)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeSupplements_FromCodes");

                db.AddInParameter(cmd, "@RecipeId", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@RecipeSupType", System.Data.DbType.Int32, recipeSupType);

                return (SqlDataReader)db.ExecuteReader(cmd);

                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveRecipeSupplementByID(int recipeSupplementID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_RecipeSupplement_By_ID");

                db.AddInParameter(cmd, "@RecipeSupplementID", System.Data.DbType.Int32, recipeSupplementID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveRecipeSupplementByRecipeIDAndType(int recipeID, int recipeSupType)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_RecipeSupplement_By_RecipeID_And_Type");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@RecipeSupType", System.Data.DbType.Int32, recipeSupType);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void EditRecipeSupplementOrderByID(int recipeSupplementID, int orders)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_RecipeSupplement_By_ID");

                db.AddInParameter(cmd, "@RecipeSupplementID", System.Data.DbType.Int32, recipeSupplementID);
                db.AddInParameter(cmd, "@Orders", System.Data.DbType.Int32, orders);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
