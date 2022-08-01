using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.SupplierRelationship
{
    internal class MealDB
    {
        internal static int AddMeal(int contractID, int mealServedTypeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_ContractMealServed");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);
                db.AddInParameter(cmd, "@MealServedTypeID", System.Data.DbType.Int32, mealServedTypeID);

                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetMealByContractID(int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_ContractMealServed_By_ContractID");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveMealByContractID(int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_ContractMealServed_By_ContractID");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
