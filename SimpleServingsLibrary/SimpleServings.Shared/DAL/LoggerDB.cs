using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;


namespace SimpleServingsLibrary.Shared
{
    public class LoggerDB
    {

        internal static bool AddLog(int fhID, int referenceID, int moduleID, string actionTaken, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Add_Log");
                db.AddInParameter(cmd, "@fhID", DbType.Int32, fhID);
                //db.AddInParameter(cmd, "@clientID", DbType.Int32, clientID);
                db.AddInParameter(cmd, "@referenceID", DbType.Int32, referenceID);
                db.AddInParameter(cmd, "@moduleID", DbType.Int32, moduleID);
                db.AddInParameter(cmd, "@actionTaken", DbType.String, actionTaken);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static SqlDataReader GetLogsByStaffID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Logs_ByStaffID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetLogsByStaffID did not return a record!");
            }
        }
        internal static SqlDataReader GetTodaysLogsByStaffIDAndLogsType(int staffID, int logsType)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_TodaysLogs_ByStaffIDAndLogsType");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@logsType", DbType.Int32, logsType);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetTodaysLogsByStaffIDAndLogsType did not return a record!");
            }
        }
        internal static SqlDataReader GetLogsByStaffIDAndLogsType(int staffID, int logsType)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Logs_ByStaffIDAndLogsType");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@logsType", DbType.Int32, logsType);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetLogsByStaffIDAndLogsType did not return a record!");
            }
        }
        internal static SqlDataReader GetTodaysLogsByStaffIDAndLogsTypeAndCaseID(int staffID, int logsType, int fhID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_TodaysLogs_ByStaffIDAndLogsTypeAndCaseID");
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@LogsType", DbType.Int32, logsType);
            db.AddInParameter(cmd, "@fhID", DbType.Int32, fhID);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetTodaysLogsByStaffIDAndLogsTypeAndCaseID did not return a record!");
            }
        }
        internal static SqlDataReader GetLogsByStaffIDAndLogsTypeAndCaseID(int staffID, int logsType, int fhID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Logs_ByStaffIDAndLogsTypeAndCaseID");
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@LogsType", DbType.Int32, logsType);
            db.AddInParameter(cmd, "@fhID", DbType.Int32, fhID);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetLogsByStaffIDAndLogsTypeAndCaseID did not return a record!");
            }
        }

        internal static SqlDataReader GetLogsForLast(int days)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Logs_ByDays");
            db.AddInParameter(cmd, "@Days", DbType.Int32, days);
         
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetLogsForLast did not return a record!");
            }
        }
        internal static SqlDataReader GetLogsForLastAndCaseID(int days, int fhID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Logs_ByDaysAndCaseID");
            db.AddInParameter(cmd, "@Days", DbType.Int32, days);
            db.AddInParameter(cmd, "@fhID", DbType.Int32, fhID);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetLogsForLastAndCaseID did not return a record!");
            }
        }

    }
}
