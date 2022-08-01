using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;


namespace SimpleServingsLibrary.Shared
{
    [Serializable]
    public class UserGroup
    {
        
        public const int ADMIN = 1;
        public const int DFTASUP = 8;
        public const int SPONSOR = 4;
        public const int CATERER = 5;
        public const int CONTRACT = 6;
        public const int DFTAUSER = 7;
        


        public UserGroup() { }
        public UserGroup(int userGroupID)
        {
            FillUserGroupByID(userGroupID);
        }
        

        #region Private Fields
        private int userGroupID;
        private string userGroupName;
        private int accessLevel;
        private string description;        
        private int createdBy;
        private string createdOn;
        private bool isActive;
        #endregion

        #region Public Properties
        public int UserGroupID
        {
            get { return userGroupID; }
            set { userGroupID = value; }
        }
        public string UserGroupName
        {
            get { return userGroupName; }
            set { userGroupName = value; }
        }
        public int AccessLevel
        {
            get { return accessLevel; }
            set { accessLevel = value; }
        }
        public string AccessLevelText
        {
            get { return Code.DecodeCode(AccessLevel); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        public string CreatedByText
        {
            get { return Staff.GetStaffNameByStaffID(Convert.ToInt32(CreatedBy)); }
        }  
        public string CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        #endregion

        #region Private Functions
        private void PopUserGroup(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                    UserGroupName = dr["UserGroupName"].ToString();
                    AccessLevel = Convert.ToInt32(dr["AccessLevel"]);
                    Description = dr["Description"].ToString();
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = dr["CreatedOn"].ToString();
                    IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                }
            }
        }
        private static UserGroups PopUserGroups(SqlDataReader dr)
        {
            UserGroups userGroups = new UserGroups();
            UserGroup userGroup;
            using (dr)
            {
                while (dr.Read())
                {
                    userGroup = new UserGroup();
                    userGroup.UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                    userGroup.UserGroupName = dr["UserGroupName"].ToString();
                    userGroup.AccessLevel = Convert.ToInt32(dr["AccessLevel"]);
                    userGroup.Description = dr["Description"].ToString();
                    userGroup.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    userGroup.CreatedOn = dr["CreatedOn"].ToString();
                    userGroup.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                    userGroups.Add(userGroup);
                }
            }
            return userGroups;
        }
        private void ValidateUserGroup()
        {
            StringBuilder sb = new StringBuilder();
            if (UserGroupID != 0)
                sb.Append(Validation.ValidateNumber(UserGroupID.ToString(), "UserGroup ID"));
            sb.Append(Validation.ValidateRequired(UserGroupName, "User group name", true));
            sb.Append(Validation.ValidateRequired(AccessLevel.ToString(), "Access level", false));
            if (AccessLevel!= 0)
                sb.Append(Validation.ValidateNumber(AccessLevel.ToString(), "Access level"));
            sb.Append(Validation.ValidateIntegerRequired(CreatedBy, "Created By"));
            sb.Append(Validation.ValidateNumber(CreatedBy.ToString(), "Created By"));
            if (sb.ToString() != "")
                throw new Exception(sb.ToString());
        }
        #endregion

        #region Public Methods

        public int AddUserGroup()
        {
            ValidateUserGroup();
            int userGroupID = UserGroupDB.AddUserGroup(UserGroupName, AccessLevel, Description, CreatedBy);
            //if (userGroupID != 0)
            //    Logger.AddLog(0, userGroupID, GlobalEnum.UserGroupModule, "Added User Group", CreatedBy);
            return userGroupID;
        }
        public void FillUserGroupByID(int userGroupID)
        {
            PopUserGroup(UserGroupDB.GetUserGroupByID(userGroupID));
        }

        public static UserGroups GetAllUserGroup()
        {
            return PopUserGroups(UserGroupDB.GetAllUserGroup());
        }

     

       

        public static UserGroups GetUserGroupByUserGroupID(int userGroupID)
        {
          return PopUserGroups(UserGroupDB.GetUserGroupByID(userGroupID));
        }
       
        public int UpdateUserGroup()
        {
            ValidateUserGroup();
            int groupID = UserGroupDB.UpdateUserGroup(UserGroupID, UserGroupName, AccessLevel, Description, CreatedBy);
            //if (groupID != 0)
              // Logger.AddLog( 0, UserGroupID, GlobalEnum.UserGroupModule, "Edited User Group", CreatedBy);
            return groupID;
        }
        public static bool DeactivateUserGroup(int userGroupID, int removeBy)
        {
            bool removed = UserGroupDB.DeactivateUserGroup(userGroupID, removeBy);
            //if (removed == true)
            //   Logger.AddLog( 0, userGroupID, GlobalEnum.UserGroupModule, "Removed User Group", removeBy);
            return removed;
        }
        public static string GetUserGroupNameByID(int userGroupID)
        {
            return UserGroupDB.GetUserGroupNameByID(userGroupID);
        }
        
       

        #endregion
    }
    [Serializable]
    public class UserGroups : ArrayList { }
}
