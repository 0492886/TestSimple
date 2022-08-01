using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace SimpleServingsLibrary.Shared
{
    class LinkDB
    {
        internal static int AddLink(string hyperlink, int linkType, int category, string description, int createdBy, string comment, string iconLink)
        {
            int linkID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Add_Link");
                db.AddInParameter(cmd, "@hyperlink", DbType.String, hyperlink);
                db.AddInParameter(cmd, "@linkType", DbType.Int32, linkType);
                db.AddInParameter(cmd, "@category", DbType.Int32, category);
                db.AddInParameter(cmd, "@description", DbType.String, description);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@comment", DbType.String, comment);
                db.AddInParameter(cmd, "@iconLink", DbType.String, iconLink);

                linkID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return linkID;
        }

        internal static bool EditLink(int linkID, string hyperlink, int linkType, int category, string description, int createdBy, string comment, string iconLink)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Edit_Link");
                db.AddInParameter(cmd, "@linkID", DbType.Int32, linkID);
                db.AddInParameter(cmd, "@hyperlink", DbType.String, hyperlink);
                db.AddInParameter(cmd, "@linkType", DbType.Int32, linkType);
                db.AddInParameter(cmd, "@category", DbType.Int32, category);
                db.AddInParameter(cmd, "@description", DbType.String, description);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@comment", DbType.String, comment);
                db.AddInParameter(cmd, "@iconLink", DbType.String, iconLink);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        internal static SqlDataReader GetLinkByLinkID(int linkID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_LinkByLinkID");
            db.AddInParameter(cmd, "@linkID", DbType.Int32, linkID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Link By Link ID did not return any record!");
            }
        }

        internal static SqlDataReader GetAllLinks()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllLinks");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get All Links did not return any record!");
            }
        }

        internal static SqlDataReader GetLinksByUserGroup(int userGroupID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_LinksByUserGroup");
            
            db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Links By UserGroup did not return any record!");
            }
        }

        internal static SqlDataReader GetLinksByLinkType(int linkType)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_LinksByLinkType");
            db.AddInParameter(cmd, "@linkType", DbType.Int32, linkType);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Links By Link Type did not return any record!");
            }
        }

        internal static SqlDataReader GetLinksByCategory(int category)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_LinksByCategory");
            db.AddInParameter(cmd, "@category", DbType.Int32, category);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Links By Category did not return any record!");
            }
        }

        internal static SqlDataReader GetLinksByLinkTypeAndUserGroup(int linkType, int userGroupID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_LinksByLinkTypeAndUserGroup");
            db.AddInParameter(cmd, "@linkType", DbType.Int32, linkType);
            db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Links By Link Type and UserGroup did not return any record!");
            }
        }

        internal static SqlDataReader GetLinksByCategoryAndUserGroup(int category, int userGroupID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_LinksByCategoryAndUserGroup");
            db.AddInParameter(cmd, "@category", DbType.Int32, category);
            db.AddInParameter(cmd, "@userGroupID", DbType.Int32, userGroupID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Links By Category and UserGroup did not return any record!");
            }
        }

        
    }
}
