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
    public class ReportDB
    {

        public static int AddReport(string reportName, int reportType, int reportCategory, string reportLink, string reportDescription, int createdBy)
        {
            int userGroupID = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Report");
                db.AddInParameter(cmd, "@reportName", DbType.String, reportName);
                db.AddInParameter(cmd, "@reportType", DbType.Int32, reportType);
                db.AddInParameter(cmd, "@reportCategory", DbType.Int32, reportCategory);
                db.AddInParameter(cmd, "@reportLink", DbType.String, reportLink);
                db.AddInParameter(cmd, "@reportDescription", DbType.String, reportDescription);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                userGroupID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userGroupID;
        }

        public static bool EditReport(int reportID, string reportName, int reportType, int reportCategory, string reportLink, string reportDescription, int createdBy)
        {
           
           try
           {
               Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
               DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Report");
               db.AddInParameter(cmd, "@reportID", DbType.Int32, reportID);
               db.AddInParameter(cmd, "@reportName", DbType.String, reportName);
               db.AddInParameter(cmd, "@reportType", DbType.Int32, reportType);
               db.AddInParameter(cmd, "@reportCategory", DbType.Int32, reportCategory);
               db.AddInParameter(cmd, "@reportLink", DbType.String, reportLink);
               db.AddInParameter(cmd, "@reportDescription", DbType.String, reportDescription);
               db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
               db.ExecuteScalar(cmd);
               return true;
           }
           catch 
           {
               return false;
           }           
       }
        internal static SqlDataReader GetAllReports()
        {
           Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
           DbCommand cmd = db.GetStoredProcCommand("Sp_Get_All_Reports");
           
           SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd); 
           if (dr.HasRows)
           {
               return dr;
           }
           else
           {
               throw new Exception("GetAllReports did not return any record!");
           }       
        }

        internal static SqlDataReader GetReportsByUserGroup(int userGroup)
        {
           Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
           DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Reports_by_UserGroup");
           db.AddInParameter(cmd, "@userGroup", DbType.Int32, userGroup);
           SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd); 
           if (dr.HasRows)
           {
               return dr;
           }
           else
           {
               throw new Exception("GetAllReports did not return any record!");
           }       
        }

        internal static SqlDataReader GetReportByReportID(int reportID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ReportByReportID");
            db.AddInParameter(cmd, "@reportID", DbType.Int32, reportID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Sp_Get_ReportByReportID did not return any record!");
            }
        }

        internal static SqlDataReader GetMealServedTypeIDsByContractID(int ContractID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetMealServedTypeIDsbyContractID");
            db.AddInParameter(cmd, "@ContractID", DbType.Int32, ContractID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Procedure did not return any record!");
            }

 
        }


        internal static SqlDataReader GetMenusForContractIDMealTypeDate(int ContractID, string Date, int MealServedTypeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuID_by_MonthYear_ML");
            db.AddInParameter(cmd, "@ContractID", DbType.Int32, ContractID);
            db.AddInParameter(cmd, "@MealServedTypeID", DbType.Int32, MealServedTypeID);
            db.AddInParameter(cmd, "@YearMonth", DbType.String, Date);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Procedure did not return any record!");
            }


 
        }


        internal static SqlDataReader GetRecipesForCountMenusbyCycleRecipeIDReport()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("sp_Get_RecipesForCountMenusby_Cycle_RecipeID_Report");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Procedure did not return any record!");
            }
        }

        internal static SqlDataReader GetRecipeViews(int RecipeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_rptRecipeView");
            db.AddInParameter(cmd, "@RecipeID", DbType.Int32, RecipeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Procedure did not return any record!");
            } 
        }

        internal static SqlDataReader GetCycleIDbyRecipeIDAndRecipeView(int RecipeID, int RecipeView)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_rptCycleID");
            db.AddInParameter(cmd, "@RecipeID", DbType.Int32, RecipeID);
            db.AddInParameter(cmd, "@RecipeView", DbType.Int32, RecipeView);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Procedure did not return any record!");
            }

        }


    }
}
