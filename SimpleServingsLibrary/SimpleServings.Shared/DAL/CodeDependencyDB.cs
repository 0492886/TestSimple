using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace SimpleServingsLibrary.Shared
{
    class CodeDependencyDB
    {

        internal static int AddCodeDependency(int codeID, int dependsOnCodeID, int createdBy, string comment)
        {
            int codeDependecyID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_CodeDependency");
                db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);
                db.AddInParameter(cmd, "@dependsOnCodeID", DbType.Int32, dependsOnCodeID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@comment", DbType.String, comment);

                codeDependecyID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return codeDependecyID;
        }

        internal static SqlDataReader GetCodeDependencyByCodeDependencyID(int codeDependencyID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeDependencyByCodeDependencyID");
            db.AddInParameter(cmd, "@codeDependencyID", DbType.Int32, codeDependencyID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Code Dependency By CodeDependencyID did not return any record!");
            }
        }

        internal static SqlDataReader GetCodeDependenciesByCodeID(int codeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeDependenciesByCodeID");
            db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get CodeDependencies By CodeID did not return any record!");
            }
        }

        internal static bool RemoveCodeDependenciesByCodeID(int codeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Remove_CodeDependenciesByCodeID");
            db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);
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
    }
}
