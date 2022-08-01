using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Shared
{
    class StaffContractDB
    {
        internal static int AddStaffContract(int staffID, int contractID, int createdBy)
        {
            int staffContractID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddStaffContract");

                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
                db.AddInParameter(cmd, "@contractID", DbType.Int32, contractID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                

                staffContractID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staffContractID;
        }

        internal static SqlDataReader GetStaffContractsByStaffID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffContractsByStaffID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get StaffContracts By StaffID did not return any record!");
            }
        }

        internal static bool RemoveStaffContractsByStaffID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_RemoveStaffContractsByStaffID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        internal static SqlDataReader GetStaffIdsByContractID(int contractID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffIdByContractId");
            db.AddInParameter(cmd, "@ContractID", DbType.Int32, contractID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get StaffId By ContractId did not return any record!");
            }
        }
    }
}
