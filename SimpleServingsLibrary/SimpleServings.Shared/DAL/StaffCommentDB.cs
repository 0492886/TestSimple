using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace SimpleServingsLibrary.Shared
{
    class StaffCommentDB
    {
        internal static int AddComment(int staffID, string staffComment, int createdBy)
        {
            int commentID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Comment");
                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
                db.AddInParameter(cmd, "@comment", DbType.String, staffComment);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                commentID = Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return commentID;
        }

        internal static SqlDataReader GetCommentsByStaffID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CommentsByStaffID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get StaffComments By StaffID did not return any record!");
            }
        }
    }
}