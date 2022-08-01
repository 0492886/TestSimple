using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace SimpleServingsLibrary.Menu
{
    class MenuStatusHistoryDB
    {
        internal static SqlDataReader GetMenuStatusHistoryByRecipeID(int menuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuStatusHistoryByMenuID");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Menu Status History By MenuID did not return any record!");
            }
        }
    }
}
