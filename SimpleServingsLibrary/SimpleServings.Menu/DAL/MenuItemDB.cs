using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Menu
{
    class MenuItemDB
    {
        internal static int AddMenuItem(int menuID, int recipeID,
            int dayOfWeekID, int menuItemTypeID, short weekInCycle, int createdBy, bool IsSampleMenuItem)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddMenuItem");


                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@dayOfWeekID", DbType.Int32, dayOfWeekID);
                db.AddInParameter(cmd, "@menuItemTypeID", DbType.Int32, menuItemTypeID);
                db.AddInParameter(cmd, "@weekInCycle", DbType.Int16, weekInCycle);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@IsSampleMenuItem", DbType.Boolean, IsSampleMenuItem);


                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static SqlDataReader GetMenuItemByMenuItemID(int menuItemID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuItemByMenuItemID");
            db.AddInParameter(cmd, "@menuItemID", DbType.Int32, menuItemID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("get Menu Item By MenuItemID did not return a record!");
            }
        }



        internal static List<int> GetDaysOfWeekByMenuID(int menuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_DaysOfWeek_By_MenuID");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
            List<int> _DaysList = new List<int>();
            int day = 0;
            try
            {
                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

                while (dr.Read())
                {
                    day = int.Parse(dr["DayOfWeekID"].ToString());
                    _DaysList.Add(day);
                }

                return _DaysList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //if (dr.HasRows)
            //{

            //}
            //else
            //{
            //    throw new Exception("get Menu Items By MenuID did not return a record!");
            //}
        }


        internal static SqlDataReader GetMenuItemsByMenuID(int menuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuItemsByMenuID");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            //if (dr.HasRows)
            //{
            return dr;
            //}
            //else
            //{
            //    throw new Exception("get Menu Items By MenuID did not return a record!");
            //}
        }


        internal static SqlDataReader GetMenuItemsByMenuAndItemTypeAndWeekAndDay(int menuID, int menuItemTypeID, int weekInCycle, int dayOfWeekID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuItemsByMenuAndItemTypeAndWeekAndDay");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
            db.AddInParameter(cmd, "@menuItemTypeID", DbType.Int32, menuItemTypeID);
            db.AddInParameter(cmd, "@weekInCycle", DbType.Int32, weekInCycle);
            db.AddInParameter(cmd, "@dayOfWeekID", DbType.Int32, dayOfWeekID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            //if (dr.HasRows)
            //{
            return dr;
            //}
            //else
            //{
            //    throw new Exception("GetMenuItemsByMenuAndItemTypeAndDay did not return a record!");
            //}
        }

        internal static bool RemoveMenuItemByMenuItemID(int menuItemID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_RemoveMenuItemByMenuItemID");
                db.AddInParameter(cmd, "@menuItemID", DbType.Int32, menuItemID);

                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }

        internal static void DuplicateMenuItems(int originalMenuID, int newMenuID, bool setWeeekStatus)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_DuplicateMenuItems");

                db.AddInParameter(cmd, "@originalMenuID", DbType.Int32, originalMenuID);
                db.AddInParameter(cmd, "@newMenuID", DbType.Int32, newMenuID);
                db.AddInParameter(cmd, "@setWeeekStatus", DbType.Boolean, setWeeekStatus);
                db.ExecuteNonQuery(cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static bool SetIsAlternate(int menuItemID, bool isAlternate, int StaffID = 0)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_SetMenuItemIsAlternate");
                db.AddInParameter(cmd, "@menuItemID", DbType.Int32, menuItemID);
                db.AddInParameter(cmd, "@isAlternate", DbType.Boolean, isAlternate);
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, StaffID);

                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }
       

        // Mandy Add
        internal static void SwapWeekDayMenu(int MenuID, int WeekInCycle, int initDayOfWeekID, int finalDayOfWeekID, int CreatedBy )
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_SwapWeekDayMenu");

                db.AddInParameter(cmd, "@MenuID", DbType.Int32, MenuID);
                db.AddInParameter(cmd, "@WeekInCycle", DbType.Int32, WeekInCycle);
                db.AddInParameter(cmd, "@initDayOfWeekID", DbType.Int32, initDayOfWeekID);
                db.AddInParameter(cmd, "@finalDayOfWeekID", DbType.Int32, finalDayOfWeekID);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, CreatedBy);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            
										





    }
}
