using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;


namespace SimpleServingsLibrary.Shared
{
    public class RuleCodeAssociation
    {
        #region Private Fields

        private int ruleCodeID;
        private int ruleID;
        private int codeID;
        private string relatedAction;
        private bool isActive;
        private int createdBy;
        private string createdOn;

        #endregion

        #region Public Properties

        public int RuleCodeID
        {
            get { return ruleCodeID; }
            set { ruleCodeID = value; }
        }
        
        public int RuleID
        {
            get { return ruleID; }
            set { ruleID = value; }
        }

        public int CodeID
        {
            get { return codeID; }
            set { codeID = value; }
        }
        public string RelatedAction
        {
            get { return relatedAction; }
            set { relatedAction = value; }

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

        private void PopRuleCode(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    RuleCodeID = Convert.ToInt32(dr["RuleCodeID"]);
                    RuleID = Convert.ToInt32(dr["RuleID"]);
                    CodeID = Convert.ToInt32(dr["CodeID"]);
                    RelatedAction = Convert.ToString(dr["RelatedAction"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                }
            }
        }

        private static RuleCodeAssociations PopRuleCodes(SqlDataReader dr)
        {
            RuleCodeAssociations ruleCodes = new RuleCodeAssociations();
            RuleCodeAssociation ruleCode;
            using (dr)
            {
                while (dr.Read())
                {
                    ruleCode = new RuleCodeAssociation();
                    ruleCode.RuleCodeID = Convert.ToInt32(dr["RuleCodeID"]);
                    ruleCode.RuleID = Convert.ToInt32(dr["RuleID"]);
                    ruleCode.CodeID = Convert.ToInt32(dr["CodeID"]);
                    ruleCode.RelatedAction = Convert.ToString(dr["RelatedAction"]);
                    ruleCode.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    ruleCode.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    ruleCode.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    ruleCodes.Add(ruleCode);
                }
            }
            return ruleCodes;

        }


        private void ValidateRuleCodeAssociation()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] { CodeID, RuleID, IsActive, CreatedBy });
                ArrayList fieldNames = new ArrayList(new string[] { "Code ID", "Rule ID", "Is Active", "Created By" });
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

        public int AddRuleCodeAssociation()
        {
            ValidateRuleCodeAssociation();
            return RuleCodeAssociationDB.AddRuleCodeAssociation(CodeID,RelatedAction, RuleID, CreatedBy);
        }

        public void GetRuleCodeByRuleCodeID(int ruleCodeID)
        {
            PopRuleCode(RuleCodeAssociationDB.GetRuleCodeByRuleCodeID(ruleCodeID));
        }

        public static bool RemoveRuleCodeAssociationsByCodeID(int codeID)
        {
            return RuleCodeAssociationDB.RemoveRuleCodeAssociationsByCodeID(codeID);
        }

        

        
        #endregion


    }
    public class RuleCodeAssociations : ArrayList { }
}

