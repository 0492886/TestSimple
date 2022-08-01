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
    internal class CatererDB
    {
        internal static int AddCaterer(string catererName, string catererAddress, int contactPersonID, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Caterer");

                db.AddInParameter(cmd, "@CatererName", System.Data.DbType.String, catererName);
                db.AddInParameter(cmd, "@CatererAddress", System.Data.DbType.String, catererAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);

                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        internal static SqlDataReader GetCatererByID(int catererID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Caterer_By_ID");

                db.AddInParameter(cmd, "@CatererID", System.Data.DbType.Int32, catererID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetCatererByContractID(int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Caterer_By_ContractID");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetCatererAll()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Caterer_All");

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void EditCatererByID(int catererID, string catererName, string catererAddress, int contactPersonID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Caterer_By_ID");

                db.AddInParameter(cmd, "@CatererID", System.Data.DbType.Int32, catererID);
                db.AddInParameter(cmd, "@CatererName", System.Data.DbType.String, catererName);
                db.AddInParameter(cmd, "@CatererAddress", System.Data.DbType.String, catererAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveCatererByID(int catererID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_Caterer_By_ID");

                db.AddInParameter(cmd, "@CatererID", System.Data.DbType.Int32, catererID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
