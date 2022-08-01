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
    class MenuItemGridChangeHistoryDB
    {

        internal static SqlDataReader GetMenuItemGridChangeHistorysByMenuID(int menuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuItemGridHistoryByMenuID");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("No Records Found!");
            }
        }


        internal static void AddMenuItemGridChangeHistory(int MenuID, int RecipeID, int WeekInCycle , int OriginalDayOfWeekID, int OriginalMenuItemTypeID,
            int CreatedBy, string Action, int NewDayOfWeekID =0, int NewMenuItemTypeID = 0)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddMenuItemGridChangeHistory");
                db.AddInParameter(cmd, "@MenuID", DbType.Int32, MenuID);
                db.AddInParameter(cmd, "@RecipeID", DbType.Int32, RecipeID);
                db.AddInParameter(cmd, "@WeekInCycle", DbType.Int32, WeekInCycle);
                db.AddInParameter(cmd, "@OriginalDayOfWeekID", DbType.Int32, OriginalDayOfWeekID);
                db.AddInParameter(cmd, "@OriginalMenuItemTypeID", DbType.Int32, OriginalMenuItemTypeID);
                db.AddInParameter(cmd, "@NewDayOfWeekID", DbType.Int32, NewDayOfWeekID);
                db.AddInParameter(cmd, "@NewMenuItemTypeID", DbType.Int32, NewMenuItemTypeID);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, CreatedBy);
                db.AddInParameter(cmd, "@Action", DbType.String, Action);

                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
 
            }

            //if (dr.HasRows)
            //{
            //    return dr;
            //}
            //else
            //{
            //    throw new Exception("Sp_AddMenuItemGridChangeHistory ");
            //}
        }
    }
}
