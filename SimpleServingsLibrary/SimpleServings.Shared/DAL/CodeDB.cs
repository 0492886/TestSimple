using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace SimpleServingsLibrary.Shared
{
    public class CodeDB
    {
        public static SqlDataReader GetAllCodes()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
           
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllCode");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetAllCodes did not return a record!");
            }
        }
        public static SqlDataReader GetAllCodeType()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllCodeType");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetAllCodeType did not return a record!");
            }
        }
        public static SqlDataReader GetCodesByCodeType(string codeType)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            //DbCommand cmd = db.GetStoredProcCommand("Sp_GetMenuCycleByCycleID");
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeType");
            db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByCodeType did not return a record!");
            }
        }

        public static SqlDataReader GetCodesByCodeTypeMenu(string codeType)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeTypeMenu");
            db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByCodeType did not return a record!");
            }
        }




        public static SqlDataReader GetCodesByTypeAndUserGroup(string codeType, int userGroup)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeTypeAndUserGroup");
            db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            db.AddInParameter(cmd, "@userGroup", DbType.Int32, userGroup);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByTypeAndUserGroup did not return a record!");
            }
        }

        public static SqlDataReader GetDietTypeCodesByStaffID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_DieTypeCodesBystaffID");
            //db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByTypeAndUserGroup did not return a record!");
            }

 
        }


        public static SqlDataReader GetMenuCycles(string codeType, int userGroup)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenyCycles");
            db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            db.AddInParameter(cmd, "@userGroup", DbType.Int32, userGroup);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByTypeAndUserGroup did not return a record!");
            }
        }
        public static SqlDataReader GetCodesByTypeAndContext(string codeType, string context)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeTypeAndContext");
            db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            db.AddInParameter(cmd, "@context", DbType.String, context);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByTypeAndUserGroup did not return a record!");
            }
        }
        public static SqlDataReader GetCodesByUserGroup()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByUserGroup");
            
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByUserGroup did not return a record!");
            }
        }
        public static SqlDataReader GetCodesByUserGroupCodes()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByUserGroupCodes");

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd); 
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByUserGroupCodes did not return a record!");
            }
        }

        public static SqlDataReader GetCodesByCodeTypeAndDependsOn(string codeType, int dependsOn)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeTypeAndDependsOn");
            db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            db.AddInParameter(cmd, "@dependsOn", DbType.Int32, dependsOn);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByCodeTypeAndDependsOn did not return any record!");
            }
        }
        public static SqlDataReader GetCodesByTypeAndDependsOnAndUserGroup(string codeType, int dependsOn, int userGroupID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeTypeAndDependsOnAndUserGroup");
            db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            db.AddInParameter(cmd, "@dependsOn", DbType.Int32, dependsOn);
            db.AddInParameter(cmd, "@userGroup", DbType.Int32, userGroupID);


            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByTypeAndDependsOnAndUserGroup did not return any record!");
            }
        }
        public static bool SaveCodeValueOrderList(Code.CodeTypes codeType, int codeID, int orderList)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_CodeOrderList");
                db.AddInParameter(cmd, "@CodeType", DbType.String, codeType.ToString());
                db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);
                db.AddInParameter(cmd, "@orderList", DbType.Int32, orderList);
                db.ExecuteNonQuery(cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
        internal static int AddCode(Code.CodeTypes type, string description, string comments, int dependsOn, int codeOrder, int staffID)
        {

            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AddCode");
                db.AddInParameter(cmd, "@CodeType", DbType.String, type.ToString());
                db.AddInParameter(cmd, "@CodeDescription", DbType.String, description);
                db.AddInParameter(cmd, "@Comment", DbType.String, comments);
                db.AddInParameter(cmd, "@DependsOn", DbType.Int32, dependsOn);
                db.AddInParameter(cmd, "@CodeOrder", DbType.Int32, codeOrder);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, staffID);

               
                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal static bool UpdateCode(int codeID, string description, string comments, int dependsOn, int codeOrder)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Get_UpdateCode");
                db.AddInParameter(cmd, "@CodeID", DbType.Int32, codeID);
                db.AddInParameter(cmd, "@CodeDescription", DbType.String, description);
                db.AddInParameter(cmd, "@Comment", DbType.String, comments);
                db.AddInParameter(cmd, "@DependsOn", DbType.Int32, dependsOn);
                db.AddInParameter(cmd, "@CodeOrder", DbType.Int32, codeOrder);

                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }

        }

        internal static SqlDataReader GetCodeByCodeID(int codeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeID");
            db.AddInParameter(cmd, "@codeID", DbType.Int32, codeID);


            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCodeByCodeID did not return a record!");
            }
        }

        internal static bool DeactivateCode(int codeID,int removeBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_RemoveCode");
                db.AddInParameter(cmd, "@CodeID", DbType.Int32, codeID);
                db.AddInParameter(cmd, "@removeBy", DbType.Int32, removeBy);
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }
        internal static bool ActivateCode(int codeID, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_ReActivateCode");
                db.AddInParameter(cmd, "@CodeID", DbType.Int32, codeID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }

        internal static int GetCodeIDByDescriptionAndType(string codeDescription, string codeType)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_GetCodeID_ByDescriptionAndType");
                db.AddInParameter(cmd, "@CodeDescription", DbType.String, codeDescription);
                db.AddInParameter(cmd, "@CodeType", DbType.String, codeType);
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch
            {
                return 0;
            }
        }

        internal static SqlDataReader GetCodesByCodeType(string codeType, bool isActive)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeTypeAndIsActive");
            db.AddInParameter(cmd, "@codetype", DbType.String, codeType);
            db.AddInParameter(cmd, "@isActive", DbType.String, isActive);
           

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            
            if (dr.HasRows)
            {
                
                return dr;
            }
            else
            {
                throw new Exception("GetCodesByCodeTypeAndIsActive did not return a record!");
            }

            
        }


        internal static SqlDataReader GetCodesByCodeType_Tag(int Category, bool isActive)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CodeByCodeTypeAndIsActive_Tag");
            db.AddInParameter(cmd, "@Category", DbType.Int32, Category);
            db.AddInParameter(cmd, "@isActive", DbType.String, isActive);


            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

            if (dr.HasRows)
            {

                return dr;
            }
            else
            {
                throw new Exception("GetCodesByCodeTypeAndIsActive_Tag did not return a record!");
            }


        }

        internal static string GetModuleHelpURL(int moduleID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_GetModuleHelpURL");
                db.AddInParameter(cmd, "@moduleID", DbType.Int32, moduleID);
                return Convert.ToString(db.ExecuteScalar(cmd));
            }
            catch
            {
                return "";
            }
        }

        internal static SqlDataReader GetWoltNumbers()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_WoltNumbers");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetWoltNumbers did not return a record!");
            }
        }

        internal static SqlDataReader GetCatererByContractID(int contractId,int staffId)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Caterer_By_ContractID");
            db.AddInParameter(cmd, "@ContractID", DbType.Int32, contractId);
            db.AddInParameter(cmd, "@StaffID", DbType.Int32,staffId);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetCatererByContractID did not return a record!");
            }
        }




        internal static SqlDataReader GetCatererNameByMenuID(int MenuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetCatererNameByMenuID");
            db.AddInParameter(cmd, "@MenuID", DbType.Int32, MenuID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        internal static bool IsCatererByMenuID(int MenuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_GetCatererNameByMenuID");
            db.AddInParameter(cmd, "@MenuID", DbType.Int32, MenuID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





    }
}
