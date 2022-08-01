using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Shared
{
    public class CodeDependency
    {

        #region Private Fields

        private int codeDependencyID;
        private int codeID;
        private int dependsOnCodeID;
        private bool isActive;
        private int createdBy;
        private string createdOn;
        private int removedBy;
        private string removedOn;
        private string comment;

        #endregion

        #region Public Properties

        public int CodeDependencyID
        {
            get { return codeDependencyID; }
            set { codeDependencyID = value; }
        }

        public int CodeID
        {
            get { return codeID; }
            set { codeID = value; }
        }

        public string CodeIDText
        {
            get
            {
                try { return Code.DecodeCode(CodeID); }
                catch { return ""; }
            }
        }

        public int DependsOnCodeID
        {
            get { return dependsOnCodeID; }
            set { dependsOnCodeID = value; }
        }

        public string DependsOnCodeIDText
        {
            get
            {
                try { return Code.DecodeCode(DependsOnCodeID); }
                catch { return ""; }
            }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        
        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        public string CreatedByText
        {
            get { return Staff.GetStaffNameByStaffID(Convert.ToInt32(CreatedBy)); }
        } 
        public string CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public int RemovedBy
        {
            get { return removedBy; }
            set { removedBy = value; }
        }
        public string RemovedByText
        {
            get { return Staff.GetStaffNameByStaffID(Convert.ToInt32(RemovedBy)); }
        } 
        public string RemovedOn
        {
            get { return removedOn; }
            set { removedOn = value; }
        }

        #endregion


        #region Private Methods

        private static CodeDependencies PopCodes(SqlDataReader dr)
        {
            CodeDependencies codeList = new CodeDependencies();
            CodeDependency code;
            while (dr.Read())
            {
                code = new CodeDependency();
                code.CodeDependencyID = Convert.ToInt32(dr["CodeDependencyID"]);
                code.CodeID           = Convert.ToInt32(dr["CodeID"]);
                code.Comment          = dr["Comment"].ToString();
                code.IsActive         = Convert.ToBoolean(dr["IsActive"]);
                code.DependsOnCodeID  = Convert.ToInt32(dr["DependsOnCodeID"]);
                code.CreatedBy        = Convert.ToInt32(dr["CreatedBy"]);
                code.CreatedOn        = dr["CreatedOn"].ToString();
                code.RemovedBy        = Convert.ToInt32(dr["RemovedBy"]);
                code.RemovedOn        = dr["RemovedOn"].ToString();
                codeList.Add(code);
            }
            dr.Close();
            return codeList;
        }
        private void PopCode(SqlDataReader dr)
        {
            if (dr.Read())
            {
                CodeDependencyID = Convert.ToInt32(dr["CodeDependencyID"]);
                CodeID = Convert.ToInt32(dr["CodeID"]);
                DependsOnCodeID = Convert.ToInt32(dr["DependsOnCodeID"]);
                IsActive = Convert.ToBoolean(dr["IsActive"]);
                CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                CreatedOn = dr["CreatedOn"].ToString();
                RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                RemovedOn = dr["RemovedOn"].ToString();
                Comment = dr["Comment"].ToString();

            }
            dr.Close();
        }

        #endregion

        #region Public methods

        public int AddCodeDependency()
        {
            return CodeDependencyDB.AddCodeDependency(CodeID, DependsOnCodeID, CreatedBy, Comment);
        }

        public void GetCodeDependencyByCodeDependencyID(int codeDependencyID)
        {
            PopCode(CodeDependencyDB.GetCodeDependencyByCodeDependencyID(codeDependencyID));
        }

        public static CodeDependencies GetCodeDependenciesByCodeID(int codeID)
        {
            return PopCodes(CodeDependencyDB.GetCodeDependenciesByCodeID(codeID));
        }

        public static bool RemoveCodeDependenciesByCodeID(int codeID)
        {
            return CodeDependencyDB.RemoveCodeDependenciesByCodeID(codeID);
        }


        #endregion

    }
    public class CodeDependencies : ArrayList { }
}
