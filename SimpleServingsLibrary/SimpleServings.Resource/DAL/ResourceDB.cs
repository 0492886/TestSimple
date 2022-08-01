using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleServingsLibrary.Shared;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Resource
{
    class ResourceDB
    {
        internal static int AddResource(string resourceText, string resourceUrl, int resourceType)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddResource");

                db.AddInParameter(cmd, "@resourceText", DbType.String, resourceText);
                db.AddInParameter(cmd, "@resourceUrl", DbType.String, resourceUrl);
                db.AddInParameter(cmd, "@resourceType", DbType.Int32, resourceType);
                

                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal static bool RemoveResource(int id)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_RemoveResource");
                db.AddInParameter(cmd, "@id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }

        internal static SqlDataReader GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllResources");
           
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Resources did not return any record!");
            }
        }

        internal static SqlDataReader GetResourceById(int id)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ResourceById");
            db.AddInParameter(cmd, "@id", DbType.Int32, id);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Resource By Id did not return any record!");
            }
        }

        internal static SqlDataReader GetResourcesByType(int resourceType)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ResourcesByType");
            db.AddInParameter(cmd, "@resourceType", DbType.Int32, resourceType);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Resources By Type did not return any record!");
            }
        }

        #region methods for homepage content

        #region nutritional message
        internal static int AddNutritionalMessage(string nutrMsgTitle, string nutrMsgFile, string nutrMsgContent, int staffId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Add_NutritionalMessage");

                db.AddInParameter(cmd, "@name", DbType.String, nutrMsgTitle);
                db.AddInParameter(cmd, "@nutrPrint", DbType.String, nutrMsgFile);
                db.AddInParameter(cmd, "@nutrContent", DbType.String, nutrMsgContent);
                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffId);


                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static SqlDataReader GetNutritionalMessage()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_NutritionalMessage");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get nutritional message did not return any record!");
            }
        }
        #endregion

        #region welcome message
        internal static int AddWelcomeMessage(string imageFile, string message, int staffId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Add_WelcomeMessage");

                db.AddInParameter(cmd, "@ImageFile", DbType.String, imageFile);
                db.AddInParameter(cmd, "@Message", DbType.String, message);
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffId);


                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static SqlDataReader GetWelcomeMessage()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_WelcomeMessage");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get welcome message did not return any record!");
            }
        }
        #endregion

        #endregion
    }
}
