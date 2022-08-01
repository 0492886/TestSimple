using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace SimpleServingsLibrary.Shared
{
    public class ModulePermission
    {
        public enum PermissionType
        {
            Group,
            Staff
        }
        public enum Permissions
        { 
                ViewOnly,
                AddOnly,
                EditOnly,
                AddEdit,
                AddEditDelete,
                NoPermission
        }
        public enum ModuleCheckType
        { 
            View,
            Add,
            Edit,
            Delete
        }
        #region private fields
        private int _permissionID;
        private int _moduleID;
        private int _assginedRole;
        private string _comments;
        private int _groupID;
        private int _staffID;
        #endregion

        #region public properties

        public int PermissionID
        {
            get {return _permissionID;}
            set { _permissionID = value; }
        }
         public int ModuleID
        {
            get {return _moduleID;}
            set { _moduleID = value; }
        }
         public int AssginedRole
        {
            get {return _assginedRole;}
            set { _assginedRole = value; }
        }
         public string Comments
        {
            get {return _comments;}
            set { _comments = value; }
        }
         public int GroupID
        {
            get {return _groupID;}
            set { _groupID = value; }
        }
         public int StaffID
        {
            get {return _staffID;}
            set { _staffID = value; }
        }
        #endregion

        #region private methods
        private void PopPermission(SqlDataReader dr,PermissionType type)
        {
            using (dr)
            {
                dr.Read();
                PermissionID = Convert.ToInt32(dr["ModulePermissionID"]);
                ModuleID = Convert.ToInt32(dr["ModuleID"]);
                AssginedRole = Convert.ToInt32(dr["AssignedRole"]);
                Comments = dr["Comments"].ToString();

                if (type == PermissionType.Group)
                    GroupID = Convert.ToInt32(dr["UserGroupID"]);
                else if (type == PermissionType.Staff)
                    StaffID = Convert.ToInt32(dr["StaffID"]);
            }
        }
        private static ModulePermissions PopPermissions(SqlDataReader dr, PermissionType type)
        {
            ModulePermissions permissions = new ModulePermissions();
            ModulePermission permission;
            using (dr)
            {
                while (dr.Read())
                {
                    permission = new ModulePermission();
                    permission.PermissionID = Convert.ToInt32(dr["ModulePermissionID"]);
                    permission.ModuleID = Convert.ToInt32(dr["ModuleID"]);
                    permission.AssginedRole = Convert.ToInt32(dr["AssignedRole"]);
                    permission.Comments = dr["Comments"].ToString();

                    if (type == PermissionType.Group)
                        permission.GroupID = Convert.ToInt32(dr["UserGroupID"]);
                    else if (type == PermissionType.Staff)
                        permission.StaffID = Convert.ToInt32(dr["StaffID"]);
                    permissions.Add(permission);
                }
            }
            return permissions;
        }

        private static Permissions GetPermission(int PermissionID)
        {
            switch (PermissionID)
            {
                case GlobalEnum.ViewOnlyRole:
                    return Permissions.ViewOnly;

                case GlobalEnum.AddOnlyRole:
                    return Permissions.AddOnly;

                case GlobalEnum.EditOnlyRole:
                    return Permissions.EditOnly;

                case GlobalEnum.AddEditRole:
                    return Permissions.AddEdit;

                case GlobalEnum.AddEditDeleteRole:
                    return Permissions.AddEditDelete;

                default:
                    return Permissions.NoPermission;
            }
        }
       
        #endregion

        #region public methods
       
       
        public static ModulePermissions GetStaffPermissionsByID(int staffID)
        {
            return PopPermissions(ModulePermissionDB.GetStaffPermissionsByID(staffID),PermissionType.Staff);
        }
        public static Permissions GetStaffPermission(int staffID,int moduleID)
        {
            return GetPermission(ModulePermissionDB.GetStaffPermission(staffID, moduleID));
        }

        public static Permissions GetModulePermission(int moduleID,int staffID,int groupID)
        {
            return GetPermission(ModulePermissionDB.GetModulePermission(moduleID,staffID, groupID));
        }
        public static int GetModulePermissionID(int moduleID, int staffID, int groupID)
        {
            return ModulePermissionDB.GetModulePermission(moduleID, staffID, groupID);
        }

        public static ModulePermissions GetGroupPermissionsByID(int groupID)
        {
            return PopPermissions(ModulePermissionDB.GetGroupPermissionsByID(groupID),PermissionType.Group);
        }
        public static Permissions GetGroupPermission(int groupID, int moduleID)
        {
            return GetPermission(ModulePermissionDB.GetGroupPermission(groupID, moduleID));
        }

        public static bool RemoveGroupPermissionsByID(int groupID)
        {
            return ModulePermissionDB.RemoveGroupPermissionsByID(groupID);
        }

        public static bool RemoveStaffPermissionsByID(int staffID)
        {
            return ModulePermissionDB.RemoveStaffPermissionsByID(staffID);
        }

        public static bool AddGroupPermission(int groupID,int moduleID,int assignedRole)
        {
            return ModulePermissionDB.AddGroupPermission(groupID,moduleID, assignedRole);
        }

        public static bool AddStaffPermission(int staffID, int moduleID, int assignedRole)
        {
            return ModulePermissionDB.AddStaffPermission(staffID,moduleID, assignedRole);
        }

        public static Permissions GetPermission(int id, int moduleID,ModulePermissions permissions,PermissionType type)
        {
            foreach (ModulePermission permission in permissions)
            { 
                if(type==PermissionType.Group && permission.GroupID==id && permission.ModuleID==moduleID )
                    return GetPermission(permission.PermissionID);
                if(type== PermissionType.Staff && permission.StaffID==id && permission.ModuleID==moduleID)
                    return GetPermission(permission.PermissionID);
            }
            return Permissions.NoPermission;
        }

        #endregion
    }

    public class ModulePermissions : ArrayList
    {

    }
}
