using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.RecipeSupplement
{
    internal class IngredientScaleDB
    {

        internal static SqlDataReader GetDownCastScaleIngredient(int measureUnitId)
        {
            try
             {
                 Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                 DbCommand cmd = db.GetStoredProcCommand("Sp_GetDownCastScaleIngredient");
                 db.AddInParameter(cmd, "@measureUnit", System.Data.DbType.Int32, measureUnitId);
                 return (SqlDataReader)db.ExecuteReader(cmd);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
        }

        internal static SqlDataReader GetYieldByRecipeID(int recipeId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_GetYieldByRecipeID");
                db.AddInParameter(cmd, "@recipeId", System.Data.DbType.Int32, recipeId);
                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetUpCastScaleIngredient(int measureUnitId)
        {
            try 
            { 
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_GetUpCastScaleIngredient");
                db.AddInParameter(cmd, "@measureUnit", System.Data.DbType.Int32, measureUnitId);
                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
