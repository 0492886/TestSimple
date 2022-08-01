using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Menu
{
    internal class MenuWeekStatusDB
    {
        internal static SqlDataReader GetMenuWeekStatusByMenuID(int menuID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_MenuWeekStatus_By_MenuID");

                db.AddInParameter(cmd, "@MenuID", System.Data.DbType.Int32, menuID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
