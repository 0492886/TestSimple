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
    public class ReportIncludeDB
    {
        public static bool AddReportInlcude(int reportID, int userGroupID, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_ReportInclude");
                db.AddInParameter(cmd, "@reportID", DbType.Int32, reportID);
                db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static SqlDataReader GetReportIncludeByUserGroup(int userGroup)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ReportIncludeByUserGroup");
            db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroup);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetReportIncludeByUserGroup did not return record!");
            }
        }
        public static bool DeleteReportIncludesByUserGroup(int userGroupID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_ReportIncludesByUserGroup");
                db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);

                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool DeleteReportIncludesByReportID(int reportID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_ReportIncludeByReportID");
                db.AddInParameter(cmd, "@reportID", DbType.Int32, reportID);

                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static SqlDataReader GetReportIncludeByID(int reportIncludeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ReportIncludeByID");
            db.AddInParameter(cmd, "@reportIncludeID", DbType.Int32, reportIncludeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetReportIncludeByID did not return record!");
            }
        }
        public static SqlDataReader GetReportIncludeByReportID(int reportID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ReportIncludeByReportID");
            db.AddInParameter(cmd, "@reportID", DbType.Int32, reportID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetReportIncludeByCodeID did not return record!");
            }
        }
    }
}
