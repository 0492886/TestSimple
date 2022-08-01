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
    class MenuDayDB
    {
        internal static int AddMenuDay( int menuID, int dayOfWeekID, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddMenuDay");

                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@dayOfWeekID", DbType.Int32, dayOfWeekID);                
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static SqlDataReader GetMenuDayByMenuDayID(int menuDayID)
        {
            throw new NotImplementedException();
        }

        internal static SqlDataReader GetMenuDaysByMenuID(int menuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuDaysByMenuID");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetMenuDaysByMenuID did not return a record!");
            }
        }
    }
}
