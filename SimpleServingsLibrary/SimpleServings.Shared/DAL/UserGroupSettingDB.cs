using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace SimpleServingsLibrary.Shared
{
    public class UserGroupSettingDB
    {
        public static bool AddUserGroupSetting(int codeID, int userGroupID,int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_UserGroupSetting");
                db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);
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
        public static SqlDataReader GetUserGroupSettingsByUserGroup(int userGroup)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_UserGroupSettingsByUserGroup");
            db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroup);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetUserGroupSettingsByUserGroup did not return record!");
            }
        }
        public static bool DeleteUserGroupSettingsByUserGroup(int userGroupID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_UserGroupSettingsByUserGroup");
                db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);

                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool DeleteUserGroupSettingsByCodeID(int codeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_UserGroupSettingsByCodeID");
                db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);

                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static SqlDataReader GetUserGroupSettingByID(int userGroupSettingID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_UserGroupSettingByID");
            db.AddInParameter(cmd, "@userGroupSettingID", DbType.Int32, userGroupSettingID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetUserGroupSettingByID did not return record!");
            }
        }
        public static SqlDataReader GetUserGroupSettingsByCodeID(int codeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_UserGroupSettingsByCodeID");
            db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd); 
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetUserGroupSettingsByCodeID did not return record!");
            }
        }
    }
}
