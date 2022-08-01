using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.MenuThreshold
{
    internal class MenuThresholdDB
    {
        internal static SqlDataReader GetMenuThresholdByTypes(int mealServedTypeID, int contractTypeID, int periodicalTypeID, int dietTypeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_MenuThreshold_By_MealServedType_ContracType_PeriodicalType");

                db.AddInParameter(cmd, "@MealServedTypeID", System.Data.DbType.Int32, mealServedTypeID);
                db.AddInParameter(cmd, "@ContractTypeID", System.Data.DbType.Int32, contractTypeID);
                db.AddInParameter(cmd, "@PeriodicalTypeID", System.Data.DbType.Int32, periodicalTypeID);
                db.AddInParameter(cmd, "@DietTypeID", System.Data.DbType.Int32, dietTypeID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetMenuThresholdByMealServedType(int mealServedTypeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_MenuThreshold_By_MealServedType");

                db.AddInParameter(cmd, "@MealServedTypeID", System.Data.DbType.Int32, mealServedTypeID);
                

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static int AddMenuThreshold(int nutrientID,int mealServedTypeID,int DietTypeID, int contractTypeID,int inequalityTypeID,
            int periodicalTypeID,double lowThreshold,double highThreshold,int dependsOnThresholdID,int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddMenuThreshold");
                db.AddInParameter(cmd, "@nutrientID", DbType.Int32, nutrientID);
                db.AddInParameter(cmd, "@mealServedTypeID", DbType.Int32, mealServedTypeID);
                db.AddInParameter(cmd, "@dietTypeID", DbType.Int32, DietTypeID);
                db.AddInParameter(cmd, "@contractTypeID", DbType.Int32, contractTypeID);
                db.AddInParameter(cmd, "@inequalityTypeID", DbType.Int32, inequalityTypeID);
                db.AddInParameter(cmd, "@periodicalTypeID", DbType.Int32, periodicalTypeID);
                db.AddInParameter(cmd, "@lowThreshold", DbType.Double, lowThreshold);
                db.AddInParameter(cmd, "@highThreshold", DbType.Double, highThreshold);
                db.AddInParameter(cmd, "@dependsOnThresholdID", DbType.Int32, dependsOnThresholdID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal static bool EditMenuThreshold(int thresholdID, int nutrientID, int mealServedTypeID, int DietTypeID, int contractTypeID, int inequalityTypeID,
            int periodicalTypeID,double lowThreshold,double highThreshold,int dependsOnThresholdID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_EditMenuThreshold");
                db.AddInParameter(cmd, "@thresholdID", DbType.Int32, thresholdID);
                db.AddInParameter(cmd, "@nutrientID", DbType.Int32, nutrientID);
                db.AddInParameter(cmd, "@mealServedTypeID", DbType.Int32, mealServedTypeID);
                db.AddInParameter(cmd, "@dietTypeID", DbType.Int32, DietTypeID);
                db.AddInParameter(cmd, "@contractTypeID", DbType.Int32, contractTypeID);
                db.AddInParameter(cmd, "@inequalityTypeID", DbType.Int32, inequalityTypeID);
                db.AddInParameter(cmd, "@periodicalTypeID", DbType.Int32, periodicalTypeID);
                db.AddInParameter(cmd, "@lowThreshold", DbType.Double, lowThreshold);
                db.AddInParameter(cmd, "@highThreshold", DbType.Double, highThreshold);
                db.AddInParameter(cmd, "@dependsOnThresholdID", DbType.Int32, dependsOnThresholdID);             

                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }

        }


        internal static bool DeactivateMenuThreshold(int thresholdID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_DeactivateMenuThreshold");
                db.AddInParameter(cmd, "@ThresholdID", DbType.Int32, thresholdID);
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }





        internal static SqlDataReader GetMenuThresholdByID(int thresholdID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_MenuThreshold_By_ID");

                db.AddInParameter(cmd, "@ThresholdID", System.Data.DbType.Int32, thresholdID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetMenuThresholdValidationDaily(int menuID, int weekInCycle, int dayOfWeekID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_MenuThreshold_Validation_Daily");

                db.AddInParameter(cmd, "@MenuID", System.Data.DbType.Int32, menuID);
                db.AddInParameter(cmd, "@WeekInCycle", System.Data.DbType.Int32, weekInCycle);
                db.AddInParameter(cmd, "@DayOfWeekID", System.Data.DbType.Int32, dayOfWeekID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetMenuThresholdValidationWeekly(int menuID, int weekInCycle)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_MenuThreshold_Validation_Weekly");

                db.AddInParameter(cmd, "@MenuID", System.Data.DbType.Int32, menuID);
                db.AddInParameter(cmd, "@WeekInCycle", System.Data.DbType.Int32, weekInCycle);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
