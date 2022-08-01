using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;
using System.Data.Common;
using System.Data;

namespace SimpleServingsLibrary.Menu
{
    class MenuItemTypeDB
    {

        internal static SqlDataReader GetAllMenuItemTypes(int mealServedTypeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllMenuItemTypes");
            db.AddInParameter(cmd, "@mealServedTypeID", DbType.Int32, mealServedTypeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetAllMenuItemTypes did not return a record!");
            }
        }
    }
}
