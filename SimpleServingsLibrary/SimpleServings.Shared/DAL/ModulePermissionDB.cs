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
    public class ModulePermissionDB
    {
        internal static bool RemoveStaffPermissionsByID(int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Remove_StaffPermissions");
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
                
                db.ExecuteNonQuery(cmd); 
                return true;
            }
            catch 
            {
                return false;
            }
        }

        internal static bool RemoveGroupPermissionsByID(int groupID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Remove_GroupPermissions");
                db.AddInParameter(cmd, "@GroupID", DbType.Int32, groupID);

                db.ExecuteNonQuery(cmd); 
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool AddGroupPermission(int groupID,int moduleID, int assignedRole)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Add_GroupPermissions");
                db.AddInParameter(cmd, "@GroupID", DbType.Int32, groupID);
                db.AddInParameter(cmd, "@ModuleID", DbType.Int32, moduleID);
                db.AddInParameter(cmd, "@AssignedRole", DbType.Int32, assignedRole);

                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool AddStaffPermission(int staffID,int moduleID, int assignedRole)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Add_StaffPermissions");
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
                db.AddInParameter(cmd, "@ModuleID", DbType.Int32, moduleID);
                db.AddInParameter(cmd, "@AssignedRole", DbType.Int32, assignedRole);

                db.ExecuteNonQuery(cmd); 
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static int GetModulePermission(int moduleID,int staffID, int groupID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ModulePermission");
                db.AddInParameter(cmd, "@ModuleID", DbType.Int32, moduleID);
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
                db.AddInParameter(cmd, "@GroupID", DbType.Int32, groupID);
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch
            {
                return 0;
            }
        }

        internal static SqlDataReader GetStaffPermissionsByID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffPermissions_ByID");
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetOnlyStaffPermissionsByID did not return a record!");
            }
        }

        internal static SqlDataReader GetGroupPermissionsByID(int groupID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_GroupPermissions_ByID");
            db.AddInParameter(cmd, "@GroupID", DbType.Int32, groupID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd); 
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetGroupPermissionsByID did not return a record!");
            }
        }

        internal static int GetGroupPermission(int groupID, int moduleID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_GroupPermission");
                db.AddInParameter(cmd, "@GroupID", DbType.Int32, groupID);
                db.AddInParameter(cmd, "@ModuleID", DbType.Int32, moduleID);
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch
            {
                return 0;
            }
        }

        internal static int GetStaffPermission(int staffID, int moduleID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffPermission");
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
                db.AddInParameter(cmd, "@ModuleID", DbType.Int32, moduleID);
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch
            {
                return 0;
            }
        }
    }
}
