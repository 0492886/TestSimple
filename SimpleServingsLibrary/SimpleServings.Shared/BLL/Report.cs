using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace SimpleServingsLibrary.Shared
{
    public class Report
    {
        #region private variable
        private int reportID;
        private string reportName;
        private string reportDescription;
        private string reportLink;
        private int reportType; 
        private int reportCategory; 
        private bool isActive;
        private int createdBy;
        private string createdOn;
        #endregion 

        #region public variable
        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
        }
        public string ReportName
        {
            get { return reportName; }
            set { reportName = value; }
        }
        public string ReportDescription
        {
            get { return reportDescription; }
            set { reportDescription = value; }
        }
        public string ReportLink
        {
            get { return reportLink; }
            set { reportLink = value; }
        }   
        public int ReportType
        {
            get { return reportType; }
            set { reportType = value; }
        }  
        public int ReportCategory
        {
            get { return reportCategory; }
            set { reportCategory = value; }
        } 
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
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
            get { return Code.DecodeCode(CreatedBy); }
        }
        public string ReportTypeText
        {
            get { return Code.DecodeCode(ReportType); }
        }
        #endregion


#region Report Parameters

        public int MealServedTypeID { get; set; }
        public string MealServedTypeDesc { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public int RecipeID { get; set; }
        public string RecipeIDRecipeName { get; set; }
        public string RecipeName { get; set; }
        public int DisplayOrder { get; set; }
        public int RecipeView { get; set; }
        public string Rec_Viewname { get; set; }
        public int CycleID { get; set;}
        public string season { get; set; }


#endregion

        #region public function
        public int AddReport()
        {
            ValidateReport();
            int userGroupID = ReportDB.AddReport(ReportName, ReportType, ReportCategory, ReportLink, ReportDescription, CreatedBy);
            
            return userGroupID;
        }
        public bool EditReport()
        {
            ValidateReport();
            return ReportDB.EditReport(ReportID,ReportName, ReportType, ReportCategory, ReportLink, ReportDescription, CreatedBy);                        
        }
        public void GetReportByReportID(int reportID)
        {
            PopReport(ReportDB.GetReportByReportID(reportID));
        }
        public static Reports GetAllReports()
        {
            return PopReports(ReportDB.GetAllReports());
        }
        public static Reports GetReportsByUserGroup(int userGroup)
        {
            return PopReports(ReportDB.GetReportsByUserGroup(userGroup));
        }
        #endregion

        public static Reports GetRecipesForCountMenusbyCycleRecipeIDReport()
        {
            Reports rptParams = new Reports();
            Report report;
            SqlDataReader dr = ReportDB.GetRecipesForCountMenusbyCycleRecipeIDReport();
            using (dr)
            {
                while (dr.Read())
                {
                    report = new Report();

                    report.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    report.RecipeIDRecipeName = Convert.ToString(dr["Name"]);
                    report.RecipeName = Convert.ToString(dr["RecipeName"]);
                    report.DisplayOrder = Convert.ToInt32(dr["display_order"]);
                    rptParams.Add(report);
                }

            }
            dr.Close();
            return rptParams; 
        }

        public static Reports GetRecipeViews(int RecipeID)
        {
            Reports rptParams = new Reports();
            Report report;
            SqlDataReader dr = ReportDB.GetRecipeViews(RecipeID);
            using (dr)
            {
                while (dr.Read())
                {
                    report = new Report();

                    report.RecipeView = Convert.ToInt32(dr["RecipeView"]);
                    report.Rec_Viewname = Convert.ToString(dr["Rec_Viewname"]);
                    report.DisplayOrder = Convert.ToInt32(dr["display_order"]);
                    rptParams.Add(report);
                }

            }
            dr.Close();
            return rptParams; 
 
        }


        public static Reports GetCycleIDbyRecipeIDAndRecipeView(int RecipeID, int RecipeView)
        {
            Reports rptParams = new Reports();
            Report report;
            SqlDataReader dr = ReportDB.GetCycleIDbyRecipeIDAndRecipeView(RecipeID, RecipeView);
            using (dr)
            {
                while (dr.Read())
                {
                    report = new Report();

                    report.CycleID = Convert.ToInt32(dr["CycleID"]);
                    report.season= Convert.ToString(dr["season"]);
                    report.DisplayOrder = Convert.ToInt32(dr["display_order"]);
                    rptParams.Add(report);
                }

            }
            dr.Close();
            return rptParams;  
        }


        public static Reports GetMealServedTypeIDsByContractID(int ContractID)
        {
            Reports rptParams = new Reports();
            Report report;
            SqlDataReader dr = ReportDB.GetMealServedTypeIDsByContractID(ContractID);

            using (dr)
            {
                while (dr.Read())
                {
                    report = new Report();

                    report.MealServedTypeID = Convert.ToInt32(dr["MealServedTypeID"]);
                    report.MealServedTypeDesc = Convert.ToString(dr["MealDesc"]);

                    rptParams.Add(report);
                }
 
            }
            dr.Close();
            return rptParams; 
        }

        public static Reports GetMenusForContractIDMealTypeDate(int ContractID, string Date, int MealServedTypeID)
        {
            Reports rptParams = new Reports();

            Report report;
            SqlDataReader dr = ReportDB.GetMenusForContractIDMealTypeDate(ContractID, Date, MealServedTypeID);

            using (dr)
            {
                while (dr.Read())
                {
                    report = new Report();

                    report.MenuID = Convert.ToInt32(dr["MenuID"]);
                    report.MenuName = Convert.ToString(dr["MenuDesc"]);
                    report.StartDate = Convert.ToString(dr["StartDate"]);
                    report.EndDate = Convert.ToString(dr["EndDate"]);
                    rptParams.Add(report);
                }

            }
            dr.Close();


            return rptParams;
 
        }





        #region Constructor
        public Report() { }
        public Report(int reportID)
        {
            GetReportByReportID(reportID);
        }
        #endregion

        #region private function
        private void ValidateReport()
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] {ReportName, ReportType, ReportCategory, ReportLink, ReportDescription });
                ArrayList fieldNames = new ArrayList(new string[] { "Report Name", "Report Type", "Report Category", "Report Link", "Report Description" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));
                if (sb.Length != 0)
                    throw new Exception(sb.ToString());                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        private void PopReport(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    ReportID = Convert.ToInt32(dr["ReportID"]);
                    ReportName = Convert.ToString(dr["ReportName"]);
                    ReportDescription = Convert.ToString(dr["ReportDescription"]);
                    ReportLink = Convert.ToString(dr["ReportLink"]); 
                    ReportType = Convert.ToInt32(dr["ReportType"]); 
                    ReportCategory = Convert.ToInt32(dr["ReportCategory"]); 
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);                    
                    IsActive = Convert.ToBoolean(dr["IsActive"]);                             
                }
            }
            dr.Close();
        }
        private static Reports PopReports(SqlDataReader dr)
        {
            Reports reports = new Reports();
            Report report;
            using (dr)
            {
                while (dr.Read())
                {
                    report = new Report();
                    report.ReportID = Convert.ToInt32(dr["ReportID"]);
                    report.ReportName = Convert.ToString(dr["ReportName"]);
                    report.ReportDescription = Convert.ToString(dr["ReportDescription"]);
                    report.ReportLink = Convert.ToString(dr["ReportLink"]); 
                    report.ReportType = Convert.ToInt32(dr["ReportType"]);   
                    report.ReportCategory= Convert.ToInt32(dr["ReportCategory"]); 
                    report.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    report.CreatedOn = Convert.ToString(dr["CreatedOn"]);                    
                    report.IsActive = Convert.ToBoolean(dr["IsActive"]);                                       
                    reports.Add(report);
                }               
            }
            dr.Close();
            return reports;
        }
        #endregion
    }
    public class Reports : List<Report>
    { 
    
    }
}
