using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Recipe
{
    class RecipeStatusHistoryDB
    {
        internal static SqlDataReader GetRecipeStatusHistoryByRecipeID(int recipeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipeStatusHistoryByRecipeID");
            db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Recipe Status History By RecipeID did not return any record!");
            }
        }
    }
}
