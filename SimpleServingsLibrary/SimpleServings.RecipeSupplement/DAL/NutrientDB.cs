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
    internal class NutrientDB
    {
        internal static SqlDataReader GetNutrientAll()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Nutrient_All");
                 
                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetNutrientByNutrientID(int nutrientID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_NutrientByNutrientID");
            db.AddInParameter(cmd, "@nutrientID", DbType.Int32, nutrientID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Menu By MenuID did not return a record!");
            }
        }
    }
}
