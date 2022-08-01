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
    internal class ContractDB
    {
        internal static int AddContract(string contractName, string contractNumber, int contractType, int sponsorID, string sponsorAddress, int contactPersonID, int createdBy, int assignedTo)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Contract");

                db.AddInParameter(cmd, "@ContractName", System.Data.DbType.String, contractName);
                db.AddInParameter(cmd, "@ContractNumber", System.Data.DbType.String, contractNumber);
                db.AddInParameter(cmd, "@ContractType", System.Data.DbType.Int32, contractType);
                db.AddInParameter(cmd, "@SponsorID", System.Data.DbType.Int32, sponsorID);
                db.AddInParameter(cmd, "@SponsorAddress", System.Data.DbType.String, sponsorAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@AssignedTo", System.Data.DbType.Int32, assignedTo);
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static int AddContractTemp(string contractName, string contractNumber, int contractType, int sponsorID, string sponsorAddress, int contactPersonID, int createdBy, string phoneNUmber, string sponsorCode, int assignedTo)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_ContractTemp");

                db.AddInParameter(cmd, "@ContractName", System.Data.DbType.String, contractName);
                db.AddInParameter(cmd, "@ContractNumber", System.Data.DbType.String, contractNumber);
                db.AddInParameter(cmd, "@ContractType", System.Data.DbType.Int32, contractType);
                db.AddInParameter(cmd, "@SponsorID", System.Data.DbType.Int32, sponsorID);
                db.AddInParameter(cmd, "@SponsorAddress", System.Data.DbType.String, sponsorAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@phoneNUmber", System.Data.DbType.String, phoneNUmber);
                db.AddInParameter(cmd, "@sponsorCode", System.Data.DbType.String, sponsorCode);
                db.AddInParameter(cmd, "@AssignedTo", System.Data.DbType.Int32, assignedTo);
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void AddContractCaterer(int contractID, int catererID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_ContractCaterer");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);
                db.AddInParameter(cmd, "@CatererID", System.Data.DbType.Int32, catererID);

                db.ExecuteScalar(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetContractByID(int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Contract_By_ID");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetContractByContractNumber(string contractNumber)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Contract_By_ContractNumber");

                db.AddInParameter(cmd, "@ContractNumber", System.Data.DbType.String, contractNumber);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetContractBySponsorID(int sponsorID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Contract_By_SponsorID");

                db.AddInParameter(cmd, "@SponsorID", System.Data.DbType.Int32, sponsorID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetContractByCatererID(int catererID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Contract_By_CatererID");

                db.AddInParameter(cmd, "@CatererID", System.Data.DbType.Int32, catererID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetContractAll()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Contract_All");

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal static void EditContractByID(int contractID, string contractName, string contractNumber, int contractType, int sponsorID, string sponsorAddress, int contactPersonID, int assignedTo)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Contract_By_ID");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);
                db.AddInParameter(cmd, "@ContractName", System.Data.DbType.String, contractName);
                db.AddInParameter(cmd, "@ContractNumber", System.Data.DbType.String, contractNumber);
                db.AddInParameter(cmd, "@ContractType", System.Data.DbType.Int32, contractType);
                db.AddInParameter(cmd, "@SponsorID", System.Data.DbType.Int32, sponsorID);
                db.AddInParameter(cmd, "@SponsorAddress", System.Data.DbType.String, sponsorAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);
                db.AddInParameter(cmd, "@AssignedTo", System.Data.DbType.Int32, assignedTo);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveContractByID(int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_Contract_By_ID");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveContractCatererByContractIDAndCatererID(int contractID, int catererID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_ContractCaterer_By_ContractID_And_CatererID");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);
                db.AddInParameter(cmd, "@CatererID", System.Data.DbType.Int32, catererID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveContractCatererByContractID(int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_ContractCaterer_By_ContractID");

                db.AddInParameter(cmd, "@ContractID", System.Data.DbType.Int32, contractID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetContractsByStaffID(int staffID, int contractType)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetContractsByStaffIDAndContractType");
            db.AddInParameter(cmd, "@staffID", System.Data.DbType.Int32, staffID);
            db.AddInParameter(cmd, "@contractType", System.Data.DbType.Int32, contractType);
            
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Contracts By staff and contract type did not return a record!");
            }
        }

        internal static SqlDataReader GetContractsByStaffIDContractTypeDietType(int staffID, int contractType, int DietTypeID, int MealTypeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetContractsBy_StaffID_ContractType_MealType_DietType");
            db.AddInParameter(cmd, "@staffID", System.Data.DbType.Int32, staffID);
            db.AddInParameter(cmd, "@contractType", System.Data.DbType.Int32, contractType);
            db.AddInParameter(cmd, "@DietTypeID", System.Data.DbType.Int32, DietTypeID);
            db.AddInParameter(cmd, "@MealTypeID", System.Data.DbType.Int32, MealTypeID);

            
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Contracts By staff and contract type did not return a record!");
            }

        }










    }
}
