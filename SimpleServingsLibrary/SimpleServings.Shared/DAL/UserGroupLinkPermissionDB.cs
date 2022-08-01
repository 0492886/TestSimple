using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace SimpleServingsLibrary.Shared
{
    class UserGroupLinkPermissionDB
    {
        internal static int AddUserGroupLinkPermission(int userGroupID, int linkID, int createdBy)
        {
            int userGroupLPID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_UserGroupLinkPermission");
                db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
                db.AddInParameter(cmd, "@linkID", DbType.Int32, linkID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                userGroupLPID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userGroupLPID;
        }

        internal static bool RemoveUserGroupLinkPermission(int userGroupLinkID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Remove_UserGroupLinkPermissionByUGLPID");
            db.AddInParameter(cmd, "@userGroupLinkID", DbType.Int32, userGroupLinkID);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        internal static bool RemoveUserGroupLinkPermissionsByUserGroup(int userGroup)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Remove_UserGroupLinkPermissionsByUserGroup");
            db.AddInParameter(cmd, "@userGroup", DbType.Int32, userGroup);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
