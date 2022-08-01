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
    internal class SponsorDB
    {
        internal static int AddSponsor(string sponsorName, string sponsorAddress, int contactPersonID, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Sponsor");

                db.AddInParameter(cmd, "@SponsorName", System.Data.DbType.String, sponsorName);
                db.AddInParameter(cmd, "@SponsorAddress", System.Data.DbType.String, sponsorAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);

                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static int AddSponsorTemp(string sponsorName, string sponsorAddress, int contactPersonID, int createdBy, string phoneNumber, string sponsorCode)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Sponsor_temp");

                db.AddInParameter(cmd, "@SponsorName", System.Data.DbType.String, sponsorName);
                db.AddInParameter(cmd, "@SponsorAddress", System.Data.DbType.String, sponsorAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@phoneNumber", System.Data.DbType.String, phoneNumber);
                db.AddInParameter(cmd, "@sponsorCode", System.Data.DbType.String, sponsorCode);

                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void EditSponsorByID(int sponsorID, string sponsorName, string sponsorAddress, int contactPersonID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Sponsor_By_ID");

                db.AddInParameter(cmd, "@SponsorID", System.Data.DbType.Int32, sponsorID);
                db.AddInParameter(cmd, "@SponsorName", System.Data.DbType.String, sponsorName);
                db.AddInParameter(cmd, "@SponsorAddress", System.Data.DbType.String, sponsorAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void AutoEditSponsorByID(int sponsorID, string sponsorName, string sponsorAddress, int contactPersonID, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AutoUpdate_Sponsor_By_ID");

                db.AddInParameter(cmd, "@SponsorID", System.Data.DbType.Int32, sponsorID);
                db.AddInParameter(cmd, "@SponsorName", System.Data.DbType.String, sponsorName);
                db.AddInParameter(cmd, "@SponsorAddress", System.Data.DbType.String, sponsorAddress);
                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveSponsorByID(int sponsorID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_Sponsor_By_ID");

                db.AddInParameter(cmd, "@SponsorID", System.Data.DbType.Int32, sponsorID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetSponsorAll()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Sponsor_All");

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetSponsorByID(int sponsorID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_Sponsor_By_ID");

                db.AddInParameter(cmd, "@SponsorID", System.Data.DbType.Int32, sponsorID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
