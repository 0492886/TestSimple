using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using SimpleServingsLibrary.Shared;
using System.Data;

namespace SimpleServingsLibrary.Menu
{
    class MenuCycleDB
    {

        internal static SqlDataReader GetActiveMenuCycles() 
        {

            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetActivityMenuCycle");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

            if (dr.HasRows)
            { 
                return dr;
            }
            else 
            {

                throw new Exception("GetActiveMenuCycles did not return a record!");
            }
        }

        internal static SqlDataReader GetAllMenuCycles() {

            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetAllMenuCycles");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

            if (dr.HasRows)
            {
                return dr;
            }
            else
            {

                throw new Exception("GetAllMenuCycles did not return a record!");
            }
        }

        internal static SqlDataReader GetMenuCyclesByID(int menuCycleID)
        {

            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetMenuCycleByID");
            db.AddInParameter(cmd, "@MenuCycleID", DbType.Int32, menuCycleID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetAllMenuCycles did not return a record!");
            }
        }

        internal static SqlDataReader GetMenuCycleByCycleId(int cycleId)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetMenuCycleByCycleID");
            db.AddInParameter(cmd, "@CycleID", DbType.Int32, cycleId);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetMenuCycleByCycleId did not return a record!");
            }
        }

        internal static bool RemoveMenuCyclesByID(int menuCycleID) 
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_RemoveMenuCyclesByID");
                db.AddInParameter(cmd, "@MenuCycleID", DbType.Int32, menuCycleID);
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool AddMenuCycle(int cycleID, string cycleStartDate, string cycleEndDate, int createdBy)
        {
            try{

                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddMenuCycle");
                db.AddInParameter(cmd, "@CycleID", DbType.Int32, cycleID);
                db.AddInParameter(cmd, "@CycleStartDate", DbType.Date, cycleStartDate);
                db.AddInParameter(cmd, "@CycleEndDate", DbType.Date, cycleEndDate);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, createdBy);
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool EditMenuCycle(int menuCycleID, int cycleID, string cycleStartDate, string cycleEndDate, int createdBy)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_EditMenuCycle");
                db.AddInParameter(cmd, "@MenuCycleID", DbType.Int32, menuCycleID);
                db.AddInParameter(cmd, "@CycleID", DbType.Int32, cycleID);
                db.AddInParameter(cmd, "@CycleStartDate", DbType.Date, cycleStartDate);
                db.AddInParameter(cmd, "@CycleEndDate", DbType.Date, cycleEndDate);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, createdBy);
               
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
