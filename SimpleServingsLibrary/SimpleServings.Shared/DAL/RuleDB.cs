using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace SimpleServingsLibrary.Shared
{
    class RuleDB
    {
        internal static SqlDataReader GetAllRules(bool closedOnly)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllRules");
            db.AddInParameter(cmd, "@closedOnly", DbType.Boolean, closedOnly);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get All Rules did not return any record!");
            }
        }



        internal static int AddRule(string ruleDescription, string customMessage, bool isStaffSpecific, string sqlStatement, int createdBy)
        {
            int ruleID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Rule");
                db.AddInParameter(cmd, "@ruleDescription", DbType.String, ruleDescription);
                db.AddInParameter(cmd, "@customMessage", DbType.String, customMessage);                
                db.AddInParameter(cmd, "@isStaffSpecific", DbType.Boolean, isStaffSpecific);
                db.AddInParameter(cmd, "@sqlStatement", DbType.String, sqlStatement);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);

                ruleID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ruleID;
        }

        internal static bool EditRule(int ruleID, string ruleDescription, string customMessage, bool isStaffSpecific,string sqlStatement, bool isActive, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Edit_Rule");
                db.AddInParameter(cmd, "@ruleID", DbType.Int32, ruleID);
                db.AddInParameter(cmd, "@ruleDescription", DbType.String, ruleDescription);
                db.AddInParameter(cmd, "@customMessage", DbType.String, customMessage);                
                db.AddInParameter(cmd, "@isStaffSpecific", DbType.Boolean, isStaffSpecific);
                db.AddInParameter(cmd, "@sqlStatement", DbType.String, sqlStatement);
                db.AddInParameter(cmd, "@isActive", DbType.Boolean, isActive);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        internal static SqlDataReader GetRuleByRuleID(int ruleID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RuleByRuleID");
            db.AddInParameter(cmd, "@ruleID", DbType.Int32, ruleID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Rule By Rule ID did not return any record!");
            }
        }

        internal static SqlDataReader GetRulesByCodeID(int codeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RulesByCodeID");
            db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Rules By Code ID did not return any record!");
            }
        }
        internal static SqlDataReader GetRulesByAction(string action,int moduleID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RulesByAction");
            db.AddInParameter(cmd, "@action", DbType.String, action);
            db.AddInParameter(cmd, "@moduleID", DbType.Int32, moduleID);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Rules By Action did not return any record!");
            }
        }

        internal static bool IsRuleSatisfied(int caseID, int staffID, string sqlStmt, bool isStaffSpecific)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetSqlStringCommand(sqlStmt);
            db.AddInParameter(cmd, "@caseID", DbType.Int32, caseID);
           
            if (isStaffSpecific)
            {
                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            }
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            return(dr.HasRows);
        }







        internal static bool IsRuleSatisfied(int caseID, int staffID, string sqlStmt, bool isStaffSpecific, int[] parameters)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetSqlStringCommand(sqlStmt);
            db.AddInParameter(cmd, "@caseID", DbType.Int32, caseID);
            
            if (isStaffSpecific)
            {
                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            }
            if (parameters != null)
            {
                if (parameters.Length > 0)
                {
                    db.AddInParameter(cmd, "@ID1", DbType.Int32, parameters[0]);
                }
                if (parameters.Length > 1)
                {
                    db.AddInParameter(cmd, "@ID2", DbType.Int32, parameters[1]);
                }
            }


            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            return (dr.HasRows);
        }
    }
}
