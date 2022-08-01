using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.SupplierRelationship
{
    public class DietTypeDB
    {

        internal static SqlDataReader GetDietTypeByContractID(int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_DietType_By_ContractID");
                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal static void AddDietType(int contractID, int dietTypeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_ContractDietType");
                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);
                db.AddInParameter(cmd, "@DietTypeID", System.Data.DbType.Int32, dietTypeID);
                db.ExecuteScalar(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        internal static void DeleteDietTypesByContractID(int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_ContractDietType");
                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);
                db.ExecuteScalar(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
 

        }



    }
}
