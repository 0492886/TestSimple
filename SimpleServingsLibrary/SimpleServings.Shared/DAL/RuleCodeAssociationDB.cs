using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SimpleServingsLibrary.Shared
{
    class RuleCodeAssociationDB
    {
        internal static int AddRuleCodeAssociation(int codeID,string relatedAction, int ruleID, int createdBy)
        {
            int ruleCodeID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_RuleCodeAssociation");
                db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);
                db.AddInParameter(cmd, "@relatedAction", DbType.String, relatedAction);
                db.AddInParameter(cmd, "@ruleID", DbType.Int32, ruleID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                ruleCodeID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ruleCodeID;
        }

        internal static SqlDataReader GetRuleCodeByRuleCodeID(int ruleCodeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RuleCodeByRuleCodeID");
            db.AddInParameter(cmd, "@ruleCodeID", DbType.Int32, ruleCodeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get RuleCode By RuleCode ID did not return any record!");
            }
        }

        internal static bool RemoveRuleCodeAssociationsByCodeID(int codeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Remove_RuleCodeAssociationsByCodeID");
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
        internal static bool RemoveRuleCodeAssociationsByAction(string relatedAction)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Remove_RuleCodeAssociationsByAction");
            db.AddInParameter(cmd, "@relatedAction", DbType.String, relatedAction);
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
