using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;


namespace SimpleServingsLibrary.Shared
{
    public class ReportInclude
    {
        #region Private Fields
        private int reportIncludeID;
        private int reportID;
        private int userGroupID;
        private int createdBy;
        private string createdOn;

        #endregion

        #region Public Properties
       public int ReportIncludeID
        {
            get { return reportIncludeID; }
            set { reportIncludeID = value; }
        }
       public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
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
       private void PopReportInclude(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    ReportIncludeID = Convert.ToInt32(dr["ReportIncludeID"]);
                    ReportID = Convert.ToInt32(dr["ReportID"]);
                    UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = dr["CreatedOn"].ToString();
                }
            }
        }
       private static ReportIncludes PopReportIncludes(SqlDataReader dr)
        {
            ReportIncludes reportIncludes = new ReportIncludes();
            ReportInclude reportInclude;
            using (dr)
            {
                while (dr.Read())
                {
                    reportInclude = new ReportInclude();
                    reportInclude.ReportIncludeID = Convert.ToInt32(dr["ReportIncludeID"]);
                    reportInclude.ReportID = Convert.ToInt32(dr["ReportID"]);
                    reportInclude.UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                    reportInclude.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    reportInclude.CreatedOn = dr["CreatedOn"].ToString();
                    reportIncludes.Add(reportInclude);
                }
            }
            return reportIncludes;
        }
       private void ValidateReportInclude()
        {
            StringBuilder sb = new StringBuilder();
            if (ReportIncludeID.ToString() != "" && ReportIncludeID.ToString() != null)
                sb.Append(Validation.ValidateNumber(ReportIncludeID.ToString(), "Report Include ID"));
            sb.Append(Validation.ValidateRequired(ReportID.ToString(), "Report ID", true));
            if (ReportID.ToString() != "" && ReportID.ToString() != null)
                sb.Append(Validation.ValidateNumber(ReportID.ToString(), "Report ID"));
            sb.Append(Validation.ValidateRequired(UserGroupID.ToString(), "UserGroup ID", true));
            if (UserGroupID.ToString() != "" && UserGroupID.ToString() != null)
                sb.Append(Validation.ValidateNumber(UserGroupID.ToString(), "UserGroup ID"));
            sb.Append(Validation.ValidateNumber(CreatedBy.ToString(), "Created By"));
            if (sb.ToString() != "")
                throw new Exception(sb.ToString());
        }
        #endregion

        #region Public Methods
        public static bool DeleteReportIncludesByUserGroup(int userGroupID)
        {
            return ReportIncludeDB.DeleteReportIncludesByUserGroup(userGroupID);
        }
        public static bool DeleteReportIncludesByReportID(int reportID)
        {
            return ReportIncludeDB.DeleteReportIncludesByReportID(reportID);
        }
        public bool AddReportInlcude()
        {
            ValidateReportInclude();
            return ReportIncludeDB.AddReportInlcude(ReportID, UserGroupID, CreatedBy);
        }
        public void FillReportIncludeByID(int reportIncludeID)
        {
            PopReportIncludes(ReportIncludeDB.GetReportIncludeByID(reportIncludeID));
        }
       public static ReportIncludes GetReportIncludeByReportID(int reportID)
        {
            return PopReportIncludes(ReportIncludeDB.GetReportIncludeByReportID(reportID));
        }
       public static ReportIncludes GetReportIncludeByUserGroup(int userGroupID)
        {
            return PopReportIncludes(ReportIncludeDB.GetReportIncludeByUserGroup(userGroupID));
        }
        #endregion
    }
     public class ReportIncludes : ArrayList { }
}
