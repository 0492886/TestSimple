using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Shared
{
    public class UserGroupSetting
    {
        #region Private Fields
        private int userGroupSettingID;
        private int codeID;
        private int userGroupID;
        private int createdBy;
        private string createdOn;

        #endregion

        #region Public Properties
        public int UserGroupSettingID
        {
            get { return userGroupSettingID; }
            set { userGroupSettingID = value; }
        }
        public int CodeID
        {
            get { return codeID; }
            set { codeID = value; }
        }
        public int UserGroupID
        {
            get { return userGroupID; }
            set { userGroupID = value; }
        }
        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        public string CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        #endregion

        #region Private Functions
        private void PopUserGroupSetting(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    UserGroupSettingID = Convert.ToInt32(dr["UserGroupSettingID"]);
                    CodeID = Convert.ToInt32(dr["CodeID"]);
                    UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = dr["CreatedOn"].ToString();
                }
            }
        }
        private static UserGroupSettings PopUserGroupSettings(SqlDataReader dr)
        {
            UserGroupSettings userGroupSettings = new UserGroupSettings();
            UserGroupSetting userGroupSetting;
            using (dr)
            {
                while (dr.Read())
                {
                    userGroupSetting = new UserGroupSetting();
                    userGroupSetting.UserGroupSettingID = Convert.ToInt32(dr["UserGroupSettingID"]);
                    userGroupSetting.CodeID = Convert.ToInt32(dr["CodeID"]);
                    userGroupSetting.UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                    userGroupSetting.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    userGroupSetting.CreatedOn = dr["CreatedOn"].ToString();
                    userGroupSettings.Add(userGroupSetting);
                }
            }
            return userGroupSettings;
        }
        private void ValidateUserGroupSetting()
        {
            StringBuilder sb = new StringBuilder();
            if (UserGroupSettingID.ToString() != "" && UserGroupSettingID.ToString() != null)
                sb.Append(Validation.ValidateNumber(UserGroupSettingID.ToString(), "UserGroup Setting ID"));
            sb.Append(Validation.ValidateRequired(CodeID.ToString(), "Code ID", true));
            if (CodeID.ToString() != "" && CodeID.ToString() != null)
                sb.Append(Validation.ValidateNumber(CodeID.ToString(), "Code ID"));
            sb.Append(Validation.ValidateRequired(UserGroupID.ToString(), "UserGroup ID", true));
            if (UserGroupID.ToString() != "" && UserGroupID.ToString() != null)
                sb.Append(Validation.ValidateNumber(UserGroupID.ToString(), "UserGroup ID"));
            sb.Append(Validation.ValidateNumber(CreatedBy.ToString(), "Created By"));
            if (sb.ToString() != "")
                throw new Exception(sb.ToString());
        }
        #endregion

        #region Public Methods
        public static bool DeleteUserGroupSettingsByUserGroup(int userGroupID)
        {
            return UserGroupSettingDB.DeleteUserGroupSettingsByUserGroup(userGroupID);
        }
        public static bool DeleteUserGroupSettingsByCodeID(int codeID)
        {
            return UserGroupSettingDB.DeleteUserGroupSettingsByCodeID(codeID);
        }
        public bool AddUserGroupSetting()
        {
            ValidateUserGroupSetting();
            return UserGroupSettingDB.AddUserGroupSetting(CodeID, UserGroupID,CreatedBy);
        }
        public void FillUserGroupSettingByID(int userGroupSettingID)
        {
            PopUserGroupSetting(UserGroupSettingDB.GetUserGroupSettingByID(userGroupSettingID));
        }
        public static UserGroupSettings GetUserGroupSettingsByCodeID(int codeID)
        {
            return PopUserGroupSettings(UserGroupSettingDB.GetUserGroupSettingsByCodeID(codeID));
        }
        public static UserGroupSettings GetUserGroupSettingsByUserGroup(int userGroupID)
        {
            return PopUserGroupSettings(UserGroupSettingDB.GetUserGroupSettingsByUserGroup(userGroupID));
        }
        #endregion
    }
    public class UserGroupSettings : ArrayList { }
}
