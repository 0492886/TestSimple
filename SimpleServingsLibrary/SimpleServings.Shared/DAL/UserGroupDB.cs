using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace SimpleServingsLibrary.Shared
{
   public class UserGroupDB
    {
        public static int AddUserGroup(string userGroupName, int accessLevel, string description, int createdBy)
        {
            int userGroupID = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_UserGroup");
                db.AddInParameter(cmd, "@userGroupName", DbType.String, userGroupName);
                db.AddInParameter(cmd, "@accessLevel", DbType.Int32, accessLevel);
                db.AddInParameter(cmd, "@description", DbType.String, description);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                userGroupID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userGroupID;
        }
       public static SqlDataReader GetUserGroupByID(int userGroupID)
       {
           Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
           DbCommand cmd = db.GetStoredProcCommand("Sp_Get_UserGroupByID");
           db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
           SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd); 
           if (dr.HasRows)
           {
               return dr;
           }
           else
           {
               throw new Exception("GetUserGroupByID did not return record!");
           }
       }
       public static SqlDataReader GetAllUserGroup()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllUserGroup");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd); 
           if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetAllUserGroup did not return record!");
            }
        }





       public static int UpdateUserGroup(int userGroupID, string userGroupName, int accessLevel, string description, int createdBy)
       {
           int groupID = 0;
           try
           {
               Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
               DbCommand cmd = db.GetStoredProcCommand("Sp_Update_UserGroup");
               db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
               db.AddInParameter(cmd, "@userGroupName", DbType.String, userGroupName);
               db.AddInParameter(cmd, "@accessLevel", DbType.Int32, accessLevel);
               db.AddInParameter(cmd, "@description", DbType.String, description);
               db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

               groupID = Convert.ToInt32(db.ExecuteScalar(cmd));
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
           return groupID;
       }

       public static bool DeactivateUserGroup(int userGroupID, int removeBy)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
               DbCommand cmd = db.GetStoredProcCommand("Sp_RemoveUserGroup");
               db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
               db.AddInParameter(cmd, "@removeBy", DbType.Int32, removeBy);
               db.ExecuteNonQuery(cmd);
               return true;

           }
           catch
           {
               return false;
           }
       }
       

       public static string GetUserGroupNameByID(int userGroupID)
       {
           string groupName;
           try
           {
               Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
               DbCommand cmd = db.GetStoredProcCommand("Sp_Get_UserGroupNameByID");
               db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
               groupName = (string)db.ExecuteScalar(cmd);
           }
           catch
           {
               groupName = "Unknown";
           }
           return groupName;
           
       }

      
   }
}
