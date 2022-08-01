using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

using System.Configuration;
using SimpleServingsLibrary.SupplierRelationship;
using System.Data;

namespace SimpleServingsLibrary.Shared
{
    public class Code
    {
        #region public Enum
        public enum CodeTypes
        {
            
            State,
            NoteType,
            UserGroup,
            SiteCode,
            Module,
            PermissionRole,
            PermissionType,
            ModuleViewURL,
            CasesAllowedToView,
            InternalLink,
            ExternalLink,
            LinkType,
            LinkCategory,
            Universal,
            Tag,
            ReviewType,
            IngredientMeasureUnit,
            NutrientMeasureUnit,
            RecipeView,
            RecipeStatus,
            AccessLevel,
            ContractType,
            MealServedType,
            Cycle,
            DayOfWeek,
            MenuStatus,
            RecipeSupplementRecommendations,
            RecipeSupplementRequirements,
            PeriodicalType,
            InequalityType,
            ReportType,
            ContributorType,
            ReportCategory,
            ResourceType,
            DFTAStaffTitle,
            DietType,
            MenuType,
            Categories,
            MealServedFormat //add Mandy
        }        
        #endregion

        #region Constructors
        public Code() { }
        public Code(int codeID)
        {
            GetCodeByCodeID(codeID);
        }
        #endregion

        #region private fields
        private int codeID;
        private string codeType;
        private string codeDescription;
        private string comment;
        private bool isActive;
        private int dependsOnCodeID;
        private int createdBy;
        private string createdOn;
        private string removedBy;
        private string removedOn;
        private int codeOrder;
        #endregion

        #region public properties
        public int CodeID
        {
            get { return codeID; }
            set { codeID = value; }
        }
        public int CodeOrder
        {
            get { return codeOrder; }
            set { codeOrder = value; }
        }
        public string CodeType
        {
            get { return codeType; }
            set { codeType = value; }
        }
        public string CodeDescription
        {
            get { return codeDescription; }
            set { codeDescription = value; }
        }
        public string DependsOnCodeIDText
        {
            get {
                try { return Code.DecodeCode(DependsOnCodeID); }
                catch { return ""; }
            }
        }
        public string CodeDescriptionAndDependsOn
        {
            get
            {
                try
                {
                    if (dependsOnCodeID == 0)
                        return CodeDescription;
                    else
                        return Code.DecodeCode(DependsOnCodeID) + "/" + CodeDescription;
                }
                catch { return ""; }
            }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public int DependsOnCodeID
        {
            get { return dependsOnCodeID; }
            set { dependsOnCodeID = value; }
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
        public string RemovedBy
        {
            get { return removedBy; }
            set { removedBy = value; }
        }
        public string RemovedOn
        {
            get { return removedOn; }
            set { removedOn = value; }
        }
        public static Hashtable codes = Code.GetAllCodes();
        
        public static DateTime CodeHashDate;
        
        #endregion

        #region private functions
      
        private static Codes PopCodes(SqlDataReader dr)
        {
            Codes codesList = new Codes();
            Code code;
            using (dr)
            {
                while (dr.Read())
                {
                    code = new Code();
                    code.CodeID = Convert.ToInt32(dr["CodeID"].ToString());
                    code.CodeType = dr["CodeType"].ToString();
                    code.CodeDescription = dr["CodeDescription"].ToString();
                    code.Comment = dr["Comment"].ToString();
                    code.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                    code.DependsOnCodeID = Convert.ToInt32(dr["DependsOnCodeID"].ToString());
                    code.CreatedBy = Convert.ToInt32(dr["CreatedBy"].ToString());
                    code.CreatedOn = dr["CreatedOn"].ToString();
                    code.RemovedBy = dr["RemovedBy"].ToString();
                    code.RemovedOn = dr["RemovedOn"].ToString();
                    code.CodeOrder = Convert.ToInt32(dr["CodeOrder"].ToString());
                    codesList.Add(code);
                }
            }
            return codesList;
        }
        private void PopCode(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    CodeID = Convert.ToInt32(dr["CodeID"].ToString());
                    CodeType = dr["CodeType"].ToString();
                    CodeDescription = dr["CodeDescription"].ToString();
                    Comment = dr["Comment"].ToString();
                    IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                    DependsOnCodeID = Convert.ToInt32(dr["DependsOnCodeID"].ToString());
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"].ToString());
                    CreatedOn = dr["CreatedOn"].ToString();
                    RemovedBy = dr["RemovedBy"].ToString();
                    RemovedOn = dr["RemovedOn"].ToString();
                    CodeOrder = Convert.ToInt32(dr["CodeOrder"].ToString());
                }
            }
        }
        private static Alist PopAlist(SqlDataReader dr)
        {
            Alist alist = new Alist();
            Code code;
            using (dr)
            {
                while (dr.Read())
                {
                    code = new Code();
                    code.CodeType = dr["CodeType"].ToString();
                    alist.Add(code);
                }
            }
            return alist;
        }
        private static void ValidateCode(Code.CodeTypes type, string description)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Validation.ValidateRequired(type.ToString(), "Code Type", true));
            sb.Append(Validation.ValidateRequired(description, "Code Value", true));
            if (sb.ToString() != "")
                throw new Exception(sb.ToString());
        }
        #endregion

        #region public methods
        public static Alist GetAllCodeType()
        {
            return PopAlist(CodeDB.GetAllCodeType());
        }
        public static Hashtable GetAllCodes()
        {
           
                Hashtable ht = new Hashtable();
                try
                {
                    SqlDataReader dr = CodeDB.GetAllCodes();
                    using (dr)
                    {
                        while (dr.Read())
                        {
                            ht.Add(dr["CodeID"], dr["CodeDescription"].ToString());
                        }
                        dr.Close();
                    }
                    CodeHashDate = DateTime.Now;
                }
                catch { }
                return ht;
            
        }

       
        public static Codes GetCodesByType(CodeTypes codeType)
        {
            return PopCodes(CodeDB.GetCodesByCodeType(codeType.ToString()));
        }

        public static Codes GetCodesByType_Tag(int Category, bool isActive)
        {
            return PopCodes(CodeDB.GetCodesByCodeType_Tag(Category, isActive));
        }


        public static Codes GetCodesByTypeMenu(CodeTypes codeType)
        {
            return PopCodes(CodeDB.GetCodesByCodeTypeMenu(codeType.ToString()));
        }



        public static Codes GetCodesByType(CodeTypes codeType, bool isActive)
        {
            return PopCodes(CodeDB.GetCodesByCodeType(codeType.ToString(),isActive));
        }

        public static Codes GetCodesByTypeAndUserGroup(CodeTypes codeType,int userGroup)
        {
            return PopCodes(CodeDB.GetCodesByTypeAndUserGroup(codeType.ToString(), userGroup));
        }

        public static Codes GetDietTypeCodesByStaffID(int staffID)
        {
            return PopCodes(CodeDB.GetDietTypeCodesByStaffID(staffID));
 
        }

         public static Codes GetMenuCycles(CodeTypes codeType,int userGroup)
        {
            return PopCodes(CodeDB.GetMenuCycles(codeType.ToString(), userGroup));
        }

        public static Codes GetCodesByTypeAndContext(CodeTypes codeType,string context)
        {
            return PopCodes(CodeDB.GetCodesByTypeAndContext(codeType.ToString(), context));
        }
        public static Codes GetCodesByUserGroup()
        {
            return PopCodes(CodeDB.GetCodesByUserGroup());
        }
        public static Codes GetCodesByUserGroupCodes()
        {
            return PopCodes(CodeDB.GetCodesByUserGroupCodes());
        }

        public static Codes GetCodesByTypeAndDependsOn(CodeTypes codeType,int dependsOn)
        {
            return PopCodes(CodeDB.GetCodesByCodeTypeAndDependsOn(codeType.ToString(), dependsOn));
        }
        public static string GetModuleHelpURL(int moduleID)
        {
            return CodeDB.GetModuleHelpURL(moduleID);
        }
        public static Codes GetCodesByTypeAndDependsOnAndUserGroup(CodeTypes codeType, int dependsOn, int userGroupID)
        {
            return PopCodes(CodeDB.GetCodesByTypeAndDependsOnAndUserGroup(codeType.ToString(), dependsOn, userGroupID));
        }

        public void GetCodeByCodeID(int codeID)
        {
            PopCode(CodeDB.GetCodeByCodeID(codeID));
        }
        
        public static string DecodeCode(int codeID)
        {
            try
            {
                if  (codeID == GlobalEnum.EmptyCode)
                    return "";
                else
                {
                    //check if hashtable has expired
                    TimeSpan span = DateTime.Now.Subtract(CodeHashDate);
                    int refreshTime=Convert.ToInt32(ConfigurationManager.AppSettings["HashSpanInHours"]);
                    TimeSpan refreshTimeSpan = new TimeSpan(refreshTime, 0, 0);// new TimeSpan(h,mn,s)

                    if (span > refreshTimeSpan)
                    { codes = Code.GetAllCodes(); }
                    return codes[codeID].ToString();
                }
            }
            catch 
            {
                return "";
            }
        }

        //public static string DecodeCode(int codeID)
        //{
        //    try
        //    {
        //        if (codeID == GlobalEnum.EmptyCode)
        //            return "";
        //        else
        //        {
        //            //check if hashtable has expired
        //            TimeSpan span = DateTime.Now.Subtract(CodeHashDate);
        //            int refreshTime = Convert.ToInt32(ConfigurationManager.AppSettings["HashSpanInHours"]);
        //            TimeSpan refreshTimeSpan = new TimeSpan(refreshTime, 0, 0);// new TimeSpan(h,mn,s)

        //            if (span > refreshTimeSpan)

        //                return new Code(codeID).CodeDescription;
        //        }
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}

        public static int GetCodeIDByDescriptionAndType(string codeDescription, CodeTypes codeType)
        {
            return CodeDB.GetCodeIDByDescriptionAndType(codeDescription, codeType.ToString());
        }
        public static int AddCode(CodeTypes type, string description,string comments,int dependsOn,int codeOrder, int staffID)
        {
            ValidateCode(type, description);
            int codeID = CodeDB.AddCode(type, description, comments, dependsOn, codeOrder, staffID);
            //add to HashTable
            codes.Add(codeID.ToString(), description);
            //ValidHashTableDB.SetValid("Code", false);
            if (codeID!=0)
                Logger.AddLog(0, codeID, GlobalEnum.CodeModule, "Added Code", staffID);

            return codeID;
        }
        public static bool UpdateCode(int codeID, string description, string comments, int dependsOn, int codeOrder, int staffID)
        {
            bool updated =  CodeDB.UpdateCode(codeID, description, comments, dependsOn, codeOrder);
            if (updated)
            {
                Logger.AddLog(0, codeID, GlobalEnum.CodeModule, "Edited Code", staffID);

                codes.Remove(codeID.ToString());
                codes.Add(codeID.ToString(), description);
            }
            return updated;

        }
        public static bool DeactivateCode(int codeID, int removeBy)
        {
            bool removed = CodeDB.DeactivateCode(codeID, removeBy);
            if (removed)
            {
                Logger.AddLog(0, codeID, GlobalEnum.CodeModule, "Removed Code", removeBy);
                codes.Remove(codeID.ToString());
            }
            return removed;

        }
        public static bool ActivateCode(int codeID, int createdBy)
        {
            bool activated = CodeDB.ActivateCode(codeID, createdBy);
            if (activated)
                Logger.AddLog(0, codeID, GlobalEnum.CodeModule, "Reinstated Code", createdBy);
            return activated;

        }
        public static bool SaveCodeValueOrderList(CodeTypes codeType, int codeID, int orderList)
        {
            return CodeDB.SaveCodeValueOrderList(codeType, codeID, orderList);
        }

        public static String GetCatererByContractID(int contractId, int staffId)
        {
            SqlDataReader dr = CodeDB.GetCatererByContractID(contractId, staffId);
            using (dr)
            {
                while (dr.Read())
                {
                    return dr["CatererName"].ToString();
                }
            }
            return null;
        }



        public static string GetCatererNameByMenuID(int MenuID)
        {
            SqlDataReader dr = CodeDB.GetCatererNameByMenuID(MenuID);
            using (dr)
            {
                while (dr.Read())
                {
                    return dr["CatererName"].ToString();
                }
            }
            return null;
        }

        public static bool IsCatererByMenuID(int MenuID)
        {
            return CodeDB.IsCatererByMenuID(MenuID);
        }





        #region DecodeCodeTpe
        public static object DecodeCodeTpe(Type t, string codeTypeValue)
        {
            foreach (System.Reflection.FieldInfo fi in t.GetFields())
            {
                if (fi.Name == codeTypeValue)
                    return fi.GetValue(null);
            }
            throw new Exception(string.Format("Can't convert {0} to {1}", codeTypeValue, t.ToString()));

        }           
        #endregion
        #endregion
    }
    public class Codes : ArrayList { }
    public class Alist : ArrayList { }
}
