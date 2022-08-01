using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;


namespace SimpleServingsLibrary.Shared
{
    public class UserGroupLinkPermission
    {
        # region Private Fields

        private int userGroupLinkID;
        private int userGroupID;
        private int linkID;
        private bool isActive;
        private int createdBy;
        private string createdOn;

        #endregion

        # region Public Properties

        public int UserGroupLinkID
        {
            get { return userGroupLinkID; }
            set { userGroupLinkID = value; }
        }

        public int UserGroupID
        {
            get { return userGroupID; }
            set { userGroupID = value; }
        }

        public int LinkID
        {
            get { return linkID; }
            set { linkID = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

         public string IsActiveText
        {
            get
            {
                if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "true")
                    return "Yes";
                else if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "false")
                    return "No";
                else
                    return isActive.ToString();
            }
        }

        public string CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        public string CreatedByText
        {
            get { return Staff.GetStaffNameByStaffID(CreatedBy); }
        }

#endregion

        #region Private Functions

        private void PopUserGroupLinkPermission(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    UserGroupLinkID = Convert.ToInt32(dr["UserGroupLinkID"]);
                    LinkID = Convert.ToInt32(dr["LinkID"]);
                    UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);
                }
            }
        }
        private static UserGroupLinkPermissions PopUserGroupLinkPermissions(SqlDataReader dr)
        {
            UserGroupLinkPermissions userGroupLPs = new UserGroupLinkPermissions();
            UserGroupLinkPermission userGroupLP;
            using (dr)
            {
                while (dr.Read())
                {
                    userGroupLP = new UserGroupLinkPermission();
                    userGroupLP.UserGroupLinkID = Convert.ToInt32(dr["UserGroupLinkID"]);
                    userGroupLP.LinkID = Convert.ToInt32(dr["LinkID"]);
                    userGroupLP.UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                    userGroupLP.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    userGroupLP.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    userGroupLP.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    userGroupLPs.Add(userGroupLP);
                }
            }
            return userGroupLPs;
        }
        private void ValidateUserGroupLinkPermission()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] { UserGroupID, LinkID, CreatedBy });
                ArrayList fieldNames = new ArrayList(new string[] { "UserGroupID", "LinkID", "Created By" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));

                if (sb.Length != 0)
                    throw new Exception(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Public Methods

        public int AddUserGroupLinkPermission()
        {
            ValidateUserGroupLinkPermission();
            return UserGroupLinkPermissionDB.AddUserGroupLinkPermission(UserGroupID, LinkID, CreatedBy);
        }

        public static bool RemoveUserGroupLinkPermission(int userGroupLinkID)
        {
            return UserGroupLinkPermissionDB.RemoveUserGroupLinkPermission(userGroupLinkID);
        }

        public static bool RemoveUserGroupLinkPermissionsByUserGroup(int userGroup)
        {
            return UserGroupLinkPermissionDB.RemoveUserGroupLinkPermissionsByUserGroup(userGroup);
        }

        #endregion

    }
    public class UserGroupLinkPermissions : ArrayList { }
}
