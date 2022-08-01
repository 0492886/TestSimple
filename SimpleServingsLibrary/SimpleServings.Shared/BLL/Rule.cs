using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;


namespace SimpleServingsLibrary.Shared
{
    public class Rule
    {
        #region Constructors
        public Rule()
        {}
        public Rule(int ruleID)
        {
            GetRuleByRuleID(ruleID);
        }
        #endregion

        
        #region Private Fields

        private int ruleID;
        
        private string ruleDescription;
        private string customMessage;        
        private bool isStaffSpecific;
        private string sqlStatement;
        private bool isActive;
        
        private int createdBy;
        private string createdOn;

        #endregion

        #region Public Properties

        public int RuleID
        {
            get { return ruleID; }
            set { ruleID = value; }
        }

        public string RuleDescription
        {
            get { return ruleDescription; }
            set { ruleDescription = value; }
        }

        public string CustomMessage
        {
            get { return customMessage; }
            set { customMessage = value; }
        }
       

        public bool IsStaffSpecific
        {
            get { return isStaffSpecific; }
            set { isStaffSpecific = value; }
        }
        public string IsStaffSpecificText
        {
            get
            {
                if (isStaffSpecific.ToString() != null && isStaffSpecific.ToString().Trim().ToLower() == "true")
                    return "Yes";
                else if (isStaffSpecific.ToString() != null && isStaffSpecific.ToString().Trim().ToLower() == "false")
                    return "No";
                else
                    return isStaffSpecific.ToString();
            }
        }

        public string SqlStatement
        {
            get { return sqlStatement; }
            set { sqlStatement = value; }
        }
        
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public string IsActiveText
        {
            get
            {
                if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "true")
                    return "Yes";
                else if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "false")
                    return "No";
                else
                    return isActive.ToString();
            }
        }
       
        

        public string CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        public string CreatedByText
        {
            get { return Staff.GetStaffNameByStaffID(CreatedBy); }
        }

#endregion

        #region Private Methods

        private void PopRule(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    RuleID = Convert.ToInt32(dr["RuleID"]);
                    CustomMessage = Convert.ToString(dr["CustomMessage"]);
                    RuleDescription = Convert.ToString(dr["RuleDescription"]);                    
                    IsStaffSpecific = Convert.ToBoolean(dr["StaffSpecific"]);
                    SqlStatement = Convert.ToString(dr["SQLStatement"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                }
            }
        }

        private static Rules PopRules(SqlDataReader dr)
        {
            Rules rules = new Rules(); 
            Rule rule;
            using (dr)
            {
                while (dr.Read())
                {
                    rule = new Rule();
                    rule.RuleID = Convert.ToInt32(dr["RuleID"]);
                    rule.RuleDescription = Convert.ToString(dr["RuleDescription"]);
                    rule.CustomMessage = Convert.ToString(dr["CustomMessage"]);                    
                    rule.IsStaffSpecific = Convert.ToBoolean(dr["StaffSpecific"]);
                    rule.SqlStatement = Convert.ToString(dr["SQLStatement"]);
                    rule.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    rule.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    rule.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    rules.Add(rule);
                }
            }
            return rules;

        }

       
        private void ValidateRule()
        {
            try
            {
                string tempStatement = SqlStatement;
                tempStatement = tempStatement.Replace("@ID1","1");
                // Verify sql statment
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetSqlStringCommand(tempStatement);
                db.AddInParameter(cmd, "@caseID", DbType.Int32, 1);
                if (isStaffSpecific)
                {
                    db.AddInParameter(cmd, "@staffID", DbType.Int32, 1);
                }
                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

                //
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] { IsActive, IsStaffSpecific, SqlStatement, CreatedBy });
                ArrayList fieldNames = new ArrayList(new string[] { "Is Active", "IsStaffSpecific", "SQL Statement", "Created By" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));
                
                
                if (sb.Length != 0)
                    throw new Exception(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region Public Methods

        public int AddRule()
        {
            ValidateRule();
            return RuleDB.AddRule(RuleDescription, CustomMessage, IsStaffSpecific, SqlStatement, CreatedBy);
        }

        public bool EditRule()
        {
            ValidateRule();
            return RuleDB.EditRule(RuleID, RuleDescription, CustomMessage, IsStaffSpecific, SqlStatement, IsActive, CreatedBy);
        }

        public void GetRuleByRuleID(int ruleID)
        {
            PopRule(RuleDB.GetRuleByRuleID(ruleID));
        }

        public static Rules GetAllRules(bool closedOnly)
        {
            return PopRules(RuleDB.GetAllRules(closedOnly));
        }

        public static bool SatisfyRules(int codeID, int caseID, int clientID, int staffID, ref string msg)
        {
            bool satisfy = true;
            StringBuilder sb = new StringBuilder(msg);
            try
            {
                Rules rules = GetRulesByCodeID(codeID);
                if (rules != null)
                {
                    foreach (Rule rule in rules)
                    {
                        if (!RuleDB.IsRuleSatisfied(caseID, staffID, rule.SqlStatement, rule.IsStaffSpecific))
                        {
                            satisfy = false;
                            sb.Append(rule.CustomMessage + "</br>");
                        }
                    }
                }
                msg = sb.ToString();
            }
            catch (Exception) { }

            return satisfy;
        }

        
        //pass up to 2 params (beside caseID, clientID and staffID)
        public static bool SatisfyRules(int codeID, int caseID, int staffID, ref string msg,params int[] parameters)
        {
            bool satisfy = true;
            StringBuilder sb = new StringBuilder(msg);
            try
            {
                Rules rules = GetRulesByCodeID(codeID);
                if (rules != null)
                {
                    foreach (Rule rule in rules)
                    {
                        if (!RuleDB.IsRuleSatisfied(caseID, staffID, rule.SqlStatement, rule.IsStaffSpecific,parameters))
                        {
                            satisfy = false;
                            sb.Append(rule.CustomMessage + "</br>");
                        }
                    }
                }
                msg = sb.ToString();
            }
            catch (Exception ) {  }

            return satisfy;
        }

      
        public static bool SatisfyActionRules(string action, int caseID, int staffID,int moduleID, ref string msg)
        {
            bool satisfy = true;
            StringBuilder sb = new StringBuilder(msg);
            try
            {
                Rules rules = GetRulesByAction(action,moduleID);
                if (rules != null)
                {
                    foreach (Rule rule in rules)
                    {
                        if (!RuleDB.IsRuleSatisfied(caseID, staffID,rule.SqlStatement, rule.IsStaffSpecific))
                        {
                            satisfy = false;
                            sb.Append(rule.CustomMessage + "</br>");
                        }
                    }
                }
                msg = sb.ToString();
            }
            catch (Exception) { }

            return satisfy;
        }

        public static bool SatisfyRules(int caseID, int staffID, ref string msg, params int[] parameters)
        {
            bool satisfy = true;
            foreach (int parameter in parameters)
            {
                if (! SatisfyRules(parameter, caseID, staffID, ref msg))
                    satisfy= false;
            }
            return satisfy;
        }
        

      
        public static bool SatisfyActionRules(int caseID,  int staffID,int moduleID, ref string msg, params string[] actions)
        {
            bool satisfy = true;
            foreach (string action in actions)
            {
                if (!SatisfyActionRules(action, caseID, staffID,moduleID, ref msg))
                    satisfy = false;
            }
            return satisfy;
        }

        public static Rules GetRulesByCodeID(int codeID)
        {
            return PopRules(RuleDB.GetRulesByCodeID(codeID));
        }
        public static Rules GetRulesByAction(string action,int moduleID)
        {
            return PopRules(RuleDB.GetRulesByAction(action,moduleID));
        }


        
        #endregion


    }
    public class Rules : ArrayList { }
}
