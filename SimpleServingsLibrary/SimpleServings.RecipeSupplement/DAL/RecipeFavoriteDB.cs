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
    internal class RecipeFavoriteDB
    {
        internal static void UpdateRecipeFavorite(int recipeID, int staffID, bool isActive)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_RecipeFavorite");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@StaffID", System.Data.DbType.Int32, staffID);
                db.AddInParameter(cmd, "@IsActive", System.Data.DbType.Boolean, isActive);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader SelectRecipeFavoriteByStaffID(int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeFavorite_By_StaffID");

                db.AddInParameter(cmd, "@StaffID", System.Data.DbType.Int32, staffID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader SelectRecipeFavoriteByRecipeIDAndStaffID(int recipeID, int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_RecipeFavorite_By_RecipeID_And_StaffID");

                db.AddInParameter(cmd, "@RecipeID", System.Data.DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@StaffID", System.Data.DbType.Int32, staffID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
