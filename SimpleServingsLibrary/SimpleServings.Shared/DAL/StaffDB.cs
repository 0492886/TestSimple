using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;

namespace SimpleServingsLibrary.Shared
{
    class StaffDB
    {
        internal static int AddStaff(string firstName, string lastName, 
            string homePhone, string workPhone, string streetAddress1, 
            string streetAddress2, string city, string zipCode, int siteCode, 
            string staffCode, string fax, int managedBy, int userGroup, 
            int programCD, string userName, string password,  
            string iPAddress, string email, int createdBy, 
            int supplierID, int state)
        {

            int staffID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_Staff");
                db.AddInParameter(cmd, "@firstName", DbType.String, firstName);
                db.AddInParameter(cmd, "@lastName", DbType.String, lastName);
                db.AddInParameter(cmd, "@homePhone", DbType.String, homePhone);
                db.AddInParameter(cmd, "@workPhone", DbType.String, workPhone);
                db.AddInParameter(cmd, "@streetAddress1", DbType.String, streetAddress1);
                db.AddInParameter(cmd, "@streetAddress2", DbType.String, streetAddress2);
                db.AddInParameter(cmd, "@city", DbType.String, city);
                db.AddInParameter(cmd, "@zipCode", DbType.String, zipCode);
                db.AddInParameter(cmd, "@siteCode", DbType.String, siteCode);
                db.AddInParameter(cmd, "@staffCode", DbType.String, staffCode);
                db.AddInParameter(cmd, "@fax", DbType.String, fax);
                db.AddInParameter(cmd, "@managedBy", DbType.Int32, managedBy);
                db.AddInParameter(cmd, "@userGroup", DbType.String, userGroup);
                db.AddInParameter(cmd, "@programCD", DbType.Int32, programCD);
                db.AddInParameter(cmd, "@userName", DbType.String, userName);
                db.AddInParameter(cmd, "@password", DbType.String, password);
                db.AddInParameter(cmd, "@iPAddress", DbType.String, iPAddress);
                db.AddInParameter(cmd, "@email", DbType.String, email);
                db.AddInParameter(cmd, "@createdBy", DbType.String, createdBy);
                //db.AddInParameter(cmd, "@accessLevel", DbType.Int32, accessLevel);
                db.AddInParameter(cmd, "@supplierID", DbType.Int32, supplierID);
                db.AddInParameter(cmd, "@state", DbType.Int32, state);


                staffID = Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staffID;
        }



        internal static SqlDataReader GetStaffByStaffID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffByStaffID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetStaffByStaffID did not return any record!");
            }
        }
        internal static SqlDataReader GetStaffByEmail(string email)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffByEmail");
            db.AddInParameter(cmd, "@Email", DbType.String, email);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetStaffByEmail did not return any record!");
            }
        }
       

       

        internal static bool EditStaff(int staffID, string firstName, 
            string lastName, string homePhone, string workPhone, 
            string streetAddress1, string streetAddress2, string city, 
            string zipCode, int siteCode, string staffCode, string fax, 
            int managedBy, int userGroup, int programCD, string userName, 
            string password, string iPAddress, string email, 
            int supplierID, int state, bool forcePasswordChange)
        {

            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Staff");

                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
                db.AddInParameter(cmd, "@firstName", DbType.String, firstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, lastName);
                db.AddInParameter(cmd, "@homePhone", DbType.String, homePhone);
                db.AddInParameter(cmd, "@workPhone", DbType.String, workPhone);
                db.AddInParameter(cmd, "@streetAddress1", DbType.String, streetAddress1);
                db.AddInParameter(cmd, "@streetAddress2", DbType.String, streetAddress2);
                db.AddInParameter(cmd, "@city", DbType.String, city);
                db.AddInParameter(cmd, "@zipCode", DbType.String, zipCode);
                db.AddInParameter(cmd, "@siteCode", DbType.String, siteCode);
                db.AddInParameter(cmd, "@staffCode", DbType.String, staffCode);
                db.AddInParameter(cmd, "@fax", DbType.String, fax);
                db.AddInParameter(cmd, "@managedBy", DbType.Int32, managedBy);
                db.AddInParameter(cmd, "@userGroup", DbType.String, userGroup);
                db.AddInParameter(cmd, "@programCD", DbType.Int32, programCD);
                db.AddInParameter(cmd, "@userName", DbType.String, userName);
                db.AddInParameter(cmd, "@password", DbType.String, password);
                db.AddInParameter(cmd, "@iPAddress", DbType.String, iPAddress);
                db.AddInParameter(cmd, "@email", DbType.String, email);
                //db.AddInParameter(cmd, "@accessLevel", DbType.Int32, accessLevel);
                db.AddInParameter(cmd, "@supplierID", DbType.Int32, supplierID);
                db.AddInParameter(cmd, "@state", DbType.Int32, state);
                db.AddInParameter(cmd, "@forcePasswordChange", DbType.Boolean, forcePasswordChange);


                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        internal static SqlDataReader GetStaffsByManagedBy(string managedBy)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffsByManagedBy");
            db.AddInParameter(cmd, "@managedBy", DbType.String, managedBy);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Staffs By ManagedBy did not return any record!");
            }
        }

        internal static SqlDataReader GetStaffsByName(string name)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffsByName");
            db.AddInParameter(cmd, "@Name", DbType.String, name);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Staffs By Full Name did not return any record!");
            }
        }
        internal static SqlDataReader GetStaffsBySearchName(string firstName, string lastName, bool isActive)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Search_StaffsByName");
            db.AddInParameter(cmd, "@lastName", DbType.String, lastName);
            db.AddInParameter(cmd, "@firstName", DbType.String, firstName);
            db.AddInParameter(cmd, "@isActive", DbType.Boolean, isActive);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Staffs By Name did not return any record!");
            }
        }

        internal static bool IsInStaffList(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Is_InStaffList");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);


            try
            {
                int isFound = (int)db.ExecuteScalar(cmd);
                if (isFound > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        internal static string GetStaffNameByStaffID(int staffID)
        {

            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffNameByStaffID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            try
            {
                return (string)db.ExecuteScalar(cmd);

            }
            catch
            {
                return "";
            }
        }

        internal static string GeneratePassword()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Generate_Password");

            try
            {
                return (string)db.ExecuteScalar(cmd);

            }
            catch
            {
                return "";
            }
        }

        internal static SqlDataReader GetAllStaff(bool activeOnly)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllStaff");
            db.AddInParameter(cmd, "@IsActive", DbType.Boolean, activeOnly);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetAllStaff did not return any record!");
            }
        }
        

        internal static SqlDataReader GetStaffByIsActive(bool isActive)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffByIsActive");
            db.AddInParameter(cmd, "@IsActive", DbType.Boolean, isActive);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Staff By isActive did not return any record!");
            }
        }
      
        internal static SqlDataReader GetStaffByUserGroup(int userGroup)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffByUserGroup");
            db.AddInParameter(cmd, "@UserGroup", DbType.Int32, userGroup);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetStaffByUserGroup did not return any record!");
            }
        }

        internal static SqlDataReader GetAllDFTAUser()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_All_DFTA_User");            
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetStaffByUserGroup did not return any record!");
            }
        }

        internal static SqlDataReader GetAllDFTAUserAndAdmin()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_All_DFTA_User_And_Admin");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetStaffByUserGroup did not return any record!");
            }
        }

       


        internal static bool UpdateUserGroup(int staffID, int userGroupID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Staff_UserGroup");
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@UserGroupID", DbType.Int32, userGroupID);

            try
            {
                int isFound = (int)db.ExecuteScalar(cmd);
                if (isFound > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        

 
        internal static bool IsUserNameTaken(string userName)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Is_Staff_AlreadyAdded");
            db.AddInParameter(cmd, "@UserName", DbType.String, userName.Trim());

            try
            {
                int isFound = (int)db.ExecuteScalar(cmd);
                if (isFound > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        internal static bool Authenticate(string userName, string password)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffByUserNameAndPassword");
            db.AddInParameter(cmd, "@userName", DbType.String, userName);
            db.AddInParameter(cmd, "@password", DbType.String, password);
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

        internal static bool Authenticate(string userName)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffByUserName");
            db.AddInParameter(cmd, "@userName", DbType.String, userName);
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

        internal static SqlDataReader GetStaffByUserNameAndPassword(string userName, string password)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffByUserNameAndPassword");
            db.AddInParameter(cmd, "@userName", DbType.String, userName);
            db.AddInParameter(cmd, "@password", DbType.String, password);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetStaff By UserName and password did not return any record!");
            }
        }

        internal static SqlDataReader GetStaffByUserName(string userName)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffByUserName");
            db.AddInParameter(cmd, "@userName", DbType.String, userName);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetStaff By UserName did not return any record!");
            }
        }




       

        public static bool SetForcePasswordChange(bool value, int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Set_ForcePasswordChange");
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@value", DbType.Boolean, value);
            try
            {
                db.ExecuteNonQuery(cmd);
                return true;               
            }
            catch
            {
                return false;
            }
        }

        internal static SqlDataReader GetRecentlyAddedStaff(int number)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecentlyAddedStaff");
            db.AddInParameter(cmd, "@number", DbType.Int32, number);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Recently Added Staff did not return any record!");
            }
        }

        internal static bool DeactivateStaffByStaffID(int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_DeactivateStaffByStaffID");

                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
                

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
        internal static bool ActivateStaffByStaffID(int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_ActivateStaffByStaffID");

                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);


                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        internal static SqlDataReader GetStaffHierarchyByStaffID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffHierarchyByStaffID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get StaffHierarchyByStaffID did not return any record!");
            }
        }

        internal static SqlDataReader GetStaffEmailByStaffId(int staffId)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffEmailByStaffId");
            db.AddInParameter(cmd, "@StaffId", DbType.Int32, staffId);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Email by StaffId did not return any record!");
            }
        }

        internal static bool IsUserLocked(string userName)
        {
            bool returnVal = false;
            SqlDataReader dr = null;
            try
            {
                dr = GetStaffByUserName(userName);
            }
            catch { throw new Exception("UserName does not exist or is inactive"); }

            if (dr != null && dr.HasRows)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        returnVal = (dr["IsLocked"] != null) ? Convert.ToBoolean(dr["IsLocked"]) : false;
                    }
                }
            }

            return returnVal;
        }

        internal static bool LockStaffByStaffID(int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_LockStaffByStaffID");

                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);


                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
        internal static bool UnlockStaffByStaffID(int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_UnlockStaffByStaffID");

                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);


                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        //7-26-2106: log user last login
        internal static bool SetLoginDate(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Staff_LoginDate");
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, staffID);
            try
            {
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //10-06-2016
        internal static SqlDataReader GetDFTAStaffContactList()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_StaffContactList");
            //db.AddInParameter(cmd, "@number", DbType.Int32, number);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Staff Contact List did not return any record!");
            }

        }
        //10-24-2016
        internal static int AddDFTAStaffContact(string firstName, string lastName, string title, string workPhone, string email, int createdBy, int staffID = -1)
        {
            int id;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_DFTAContact");
                db.AddInParameter(cmd, "@firstName", DbType.String, firstName);
                db.AddInParameter(cmd, "@lastName", DbType.String, lastName);
                db.AddInParameter(cmd, "@workPhone", DbType.String, workPhone);
                db.AddInParameter(cmd, "@title", DbType.String, title);
                db.AddInParameter(cmd, "@email", DbType.String, email);
                db.AddInParameter(cmd, "@createdBy", DbType.String, createdBy);
                if (staffID > 0)
                {
                    db.AddInParameter(cmd, "@staffID", DbType.String, staffID);
                }
                //db.AddInParameter(cmd, "@accessLevel", DbType.Int32, accessLevel);


                id = Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;
        }
        //11-03-2016
        internal static int AddDFTAStaffContact(string firstName, string lastName, int titleCode, string workPhone, string email, int createdBy, int staffID = -1)
        {
            int id;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_DFTAContact");
                db.AddInParameter(cmd, "@firstName", DbType.String, firstName);
                db.AddInParameter(cmd, "@lastName", DbType.String, lastName);
                db.AddInParameter(cmd, "@workPhone", DbType.String, workPhone);
                db.AddInParameter(cmd, "@title", DbType.String, String.Empty);
                db.AddInParameter(cmd, "@titleCode", DbType.Int32, titleCode);
                db.AddInParameter(cmd, "@email", DbType.String, email);
                db.AddInParameter(cmd, "@createdBy", DbType.String, createdBy);
                if (staffID > 0)
                {
                    db.AddInParameter(cmd, "@staffID", DbType.String, staffID);
                }
                //db.AddInParameter(cmd, "@accessLevel", DbType.Int32, accessLevel);


                id = Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;
        }
        //10-25-2016
        internal static bool RemoveDFTAStaffContactByID(int contactID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_DFTAContact_By_ID");

                db.AddInParameter(cmd, "@ID", DbType.Int32, contactID);


                db.ExecuteNonQuery(cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }
        internal static bool EditDFTAStaffContact(string firstName, string lastName, 
            string workPhone, string title, string email, int contactID, int? order = null)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_DFTAContact_By_ID");

                db.AddInParameter(cmd, "@firstName", DbType.String, firstName);
                db.AddInParameter(cmd, "@lastName", DbType.String, lastName);
                db.AddInParameter(cmd, "@workPhone", DbType.String, workPhone);
                db.AddInParameter(cmd, "@title", DbType.String, title);
                db.AddInParameter(cmd, "@email", DbType.String, email);
                //db.AddInParameter(cmd, "@accessLevel", DbType.Int32, accessLevel);
                db.AddInParameter(cmd, "@ID", DbType.Int32, contactID);
                if (order != null)
                {
                    db.AddInParameter(cmd, "@order", DbType.Int32, (int)order);
                }

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
        //11-03-2016
        internal static bool EditDFTAStaffContact(string firstName, string lastName,
            string workPhone, int titleCode, string email, int contactID, int? order = null)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_DFTAContact_By_ID");

                db.AddInParameter(cmd, "@firstName", DbType.String, firstName);
                db.AddInParameter(cmd, "@lastName", DbType.String, lastName);
                db.AddInParameter(cmd, "@workPhone", DbType.String, workPhone);
                db.AddInParameter(cmd, "@title", DbType.String, string.Empty);
                db.AddInParameter(cmd, "@titleCode", DbType.Int32, titleCode);
                db.AddInParameter(cmd, "@email", DbType.String, email);
                //db.AddInParameter(cmd, "@accessLevel", DbType.Int32, accessLevel);
                db.AddInParameter(cmd, "@ID", DbType.Int32, contactID);
                if (order != null)
                {
                    db.AddInParameter(cmd, "@order", DbType.Int32, (int)order);
                }

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
