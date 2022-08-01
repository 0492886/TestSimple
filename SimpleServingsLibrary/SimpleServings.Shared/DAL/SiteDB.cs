using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace SimpleServingsLibrary.Shared
{
    class SiteDB
    {
        internal static int AddSite(string siteName, int siteCode, string factorsSiteCode, string streetAddress, string city,
            string zip, int state, string phone, string fax, int boroID, int createdBy)
        {
            int siteID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Site");
                db.AddInParameter(cmd, "@siteName", DbType.String, siteName);
                db.AddInParameter(cmd, "@siteCode", DbType.Int32, siteCode);
                db.AddInParameter(cmd, "@factorsSiteCode", DbType.String, factorsSiteCode);
                db.AddInParameter(cmd, "@streetAddress", DbType.String, streetAddress);
                db.AddInParameter(cmd, "@city", DbType.String, city);
                db.AddInParameter(cmd, "@zip", DbType.String, zip);
                db.AddInParameter(cmd, "@state", DbType.Int32, state);
                db.AddInParameter(cmd, "@phone", DbType.String, phone);
                db.AddInParameter(cmd, "@fax", DbType.String, fax);
                db.AddInParameter(cmd, "@boroID", DbType.Int32, boroID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                siteID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return siteID;
        }

        internal static SqlDataReader GetSiteBySiteID(int siteID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_SiteBySiteID");
            db.AddInParameter(cmd, "@siteID", DbType.Int32, siteID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Site by Site ID did not return any record!");
            }
        }

        internal static SqlDataReader GetSiteBySiteCode(int siteCode)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_SiteBySiteCode");
            db.AddInParameter(cmd, "@siteCode", DbType.Int32, siteCode);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Site by Site Code did not return any record!");
            }
        }

        internal static string GetSiteByFactorsSiteCode(string siteCode)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_SiteByFactorsSiteCode");
                db.AddInParameter(cmd, "@siteCode", DbType.String, siteCode);
                return db.ExecuteScalar(cmd).ToString();
            }
            catch { return ""; }
        }

        internal static int GetTransferSiteCodeByZipCode(string zipCode)
        {
            int siteCode = 0;
            try
            {

                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_TransferSiteCodeByZipCode");
                db.AddInParameter(cmd, "@zipCode", DbType.String, zipCode);
                siteCode = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return siteCode;
        }

        internal static string GetZipCodeBySiteCode(string siteCode)
        {
            string zipCode = "0";
            try
            {

                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ZipCodeBySiteCode");
                db.AddInParameter(cmd, "@siteCode", DbType.Int32, siteCode);
                zipCode = db.ExecuteScalar(cmd).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return zipCode;
        }

        internal static SqlDataReader GetAllSites()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllSites");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get All Sites did not return any record!");
            }
        }

        internal static bool EditSite(int siteID, string siteName, int siteCode, string factorsSiteCode,
            string streetAddress, string city, string zip, int state, string phone, string fax, bool isActive, int boroID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Edit_Site");
                db.AddInParameter(cmd, "@siteID", DbType.Int32, siteID);
                db.AddInParameter(cmd, "@siteName", DbType.String, siteName);
                db.AddInParameter(cmd, "@siteCode", DbType.Int32, siteCode);
                db.AddInParameter(cmd, "@factorsSiteCode", DbType.String, factorsSiteCode);
                db.AddInParameter(cmd, "@streetAddress", DbType.String, streetAddress);
                db.AddInParameter(cmd, "@city", DbType.String, city);
                db.AddInParameter(cmd, "@zip", DbType.String, zip);
                db.AddInParameter(cmd, "@state", DbType.Int32, state);
                db.AddInParameter(cmd, "@phone", DbType.String, phone);
                db.AddInParameter(cmd, "@fax", DbType.String, fax);
                db.AddInParameter(cmd, "@isActive", DbType.Boolean, isActive);
                db.AddInParameter(cmd, "@boroID", DbType.Int32, boroID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        internal static string GetSiteNameBySiteCode(int siteCode)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_SiteNameBySiteCode");
                db.AddInParameter(cmd, "@siteCode", DbType.Int32, siteCode);
               
                return Convert.ToString(db.ExecuteScalar(cmd));
            }
            catch (Exception)
            {
                return String.Empty;
            }

            
        }
    }
}
