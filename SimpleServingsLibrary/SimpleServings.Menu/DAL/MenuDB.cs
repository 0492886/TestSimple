using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.ComponentModel;

namespace SimpleServingsLibrary.Menu
{
    class MenuDB
    {

        internal static int AddSampleMenu(int contractTypeID, int mealServedTypeID, int dietTypeID,
                                          int cycleID, string startDate, string endDate, int createdBy, string menuName, int  MealServedFormatID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddSampleMenu");

                db.AddInParameter(cmd, "@contractTypeID", DbType.Int32, contractTypeID);
                db.AddInParameter(cmd, "@mealServedTypeID", DbType.Int32, mealServedTypeID);
                db.AddInParameter(cmd, "@dietTypeID", DbType.Int32, dietTypeID);
                db.AddInParameter(cmd, "@cycleID", DbType.Int32, cycleID);
                db.AddInParameter(cmd, "@startDate", DbType.String, startDate);
                db.AddInParameter(cmd, "@endDate", DbType.String, endDate);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@menuName", DbType.String, menuName);
                db.AddInParameter(cmd, "@MealServedFormatID", DbType.Int32, MealServedFormatID);

                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
 
        }

        internal static int AddMenuUsingSample(int contractTypeID, int mealServedTypeID, int dietTypeID,
                                          int cycleID, string startDate, string endDate, int createdBy, string menuName, int sampleMenuID, List<int> contractIDs, int MealServedFormatID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddMenuUsingSample");

                db.AddInParameter(cmd, "@contractTypeID", DbType.Int32, contractTypeID);
                db.AddInParameter(cmd, "@mealServedTypeID", DbType.Int32, mealServedTypeID);
                db.AddInParameter(cmd, "@dietTypeID", DbType.Int32, dietTypeID);
                db.AddInParameter(cmd, "@cycleID", DbType.Int32, cycleID);
                db.AddInParameter(cmd, "@startDate", DbType.String, startDate);
                db.AddInParameter(cmd, "@endDate", DbType.String, endDate);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@menuName", DbType.String, menuName);
                db.AddInParameter(cmd, "@sampleMenuID", DbType.Int32, sampleMenuID);
                db.AddInParameter(cmd, "MealServedFormatID", DbType.Int32, MealServedFormatID);

                var table = new DataTable();
                table.Columns.Add("ContractList", typeof(string));

                foreach (int i in contractIDs)
                {
                    table.Rows.Add(i); 
                }

                SqlParameter sp = new SqlParameter();
                sp.SqlDbType = SqlDbType.Structured;
                sp.ParameterName = "@contractIDs";
                sp.Value = table;
                cmd.Parameters.Add(sp);                
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //public static DataTable ToDataTable<T>(List<T> items)
        //{
        //    DataTable dataTable = new DataTable(typeof(T).Name);

        //    //Get all the properties
        //    System.ComponentModel.PropertyDescriptorCollection Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in Props)
        //    {
        //        //Setting column names as Property names
        //        dataTable.Columns.Add(prop.Name);
        //    }
        //    foreach (T item in items)
        //    {
        //        var values = new object[Props.Length];
        //        for (int i = 0; i < Props.Length; i++)
        //        {
        //            //inserting property values to datatable rows
        //            values[i] = Props[i].GetValue(item, null);
        //        }
        //        dataTable.Rows.Add(values);
        //    }
        //    //put a breakpoint here and check datatable
        //    return dataTable;
        //}

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        internal static int AddCuisine(int menuID, int cuisine, int CreatedBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("[Sp_Insert_MenuCuisine]");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@CuisineTypeID", DbType.Int32, cuisine);
                db.AddInParameter(cmd, "@UserId", DbType.Int32, CreatedBy);

                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        internal static int AddMenu(int contractTypeID, int mealServedTypeID, int dietTypeID, List<int> ContractIDs, 
            int cycleID, string startDate, string endDate, int createdBy, string menuName, int MealServedFormatID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddMenu");

                db.AddInParameter(cmd, "@contractTypeID", DbType.Int32, contractTypeID);
                db.AddInParameter(cmd, "@mealServedTypeID", DbType.Int32, mealServedTypeID);
                db.AddInParameter(cmd, "@dietTypeID", DbType.Int32, dietTypeID);
                db.AddInParameter(cmd, "@cycleID", DbType.Int32, cycleID);
                db.AddInParameter(cmd, "@startDate", DbType.String, startDate);
                db.AddInParameter(cmd, "@endDate", DbType.String, endDate);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@menuName", DbType.String, menuName);
                db.AddInParameter(cmd, "@MealServedFormatID", DbType.Int32, MealServedFormatID);


                var table = new DataTable();
                table.Columns.Add("ContractList", typeof(string));

                foreach (int i in ContractIDs)
                {
                    table.Rows.Add(i);
                }

                SqlParameter sp = new SqlParameter();
                sp.SqlDbType = SqlDbType.Structured;
                sp.ParameterName = "@contractIDs";
                sp.Value = table;
                cmd.Parameters.Add(sp); 


                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static bool EditMenu(int menuID, int contractTypeID, int cycleID, string startDate, string endDate, int createdBy, string menuName, int DietTypeID, int MealServedTypeID, List<int> ContractIDs = null )
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_EditMenu");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@contractTypeID", DbType.Int32, contractTypeID);                
                db.AddInParameter(cmd, "@cycleID", DbType.Int32, cycleID);
                db.AddInParameter(cmd, "@startDate", DbType.String, startDate);
                db.AddInParameter(cmd, "@endDate", DbType.String, endDate);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@menuName", DbType.String, menuName);
                db.AddInParameter(cmd, "@DietTypeID", DbType.Int32, DietTypeID);
                db.AddInParameter(cmd, "@MealServedTypeID", DbType.Int32, MealServedTypeID);


                if (ContractIDs != null)
                {
                    var table = new DataTable();
                    table.Columns.Add("ContractList", typeof(string));

                    foreach (int i in ContractIDs)
                    {
                        table.Rows.Add(i);
                    }

                    SqlParameter sp = new SqlParameter();
                    sp.SqlDbType = SqlDbType.Structured;
                    sp.ParameterName = "@contractIDs";
                    sp.Value = table;
                    cmd.Parameters.Add(sp); 
                }

                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }
        internal static bool EditMenuName(int menuID, string menuName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_EditMenuName");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@menuName", DbType.String, menuName);
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static SqlDataReader GetMenuByMenuID(int menuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuByMenuID");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);         
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Menu By MenuID did not return a record!");
            }
        }

        internal static SqlDataReader GetMenuByMenuIDandStaffID(int menuID, int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MenuByMenuIDandStaffID");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
            db.AddInParameter(cmd, "@staffID ", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Menu By MenuID did not return a record!");
            }
        }
        internal static SqlDataReader ValidateRequiredItems(int menuID, int weekInCycle, int dayOfWeekID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_ValidateRequiredMenuItems");
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
            db.AddInParameter(cmd, "@weekInCycle", DbType.Int32, weekInCycle);
            db.AddInParameter(cmd, "@dayOfWeekID", DbType.Int32, dayOfWeekID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            return dr;
        }

        internal static bool SetMenuWeekStatus(int menuID, int weekInCycle, bool isComplete, int staffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_SetMenuWeekStatus");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@weekInCycle", DbType.Int32, weekInCycle);
                db.AddInParameter(cmd, "@isComplete", DbType.Boolean, isComplete);
                db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);

                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }

        internal static bool IsMenuWeekComplete(int menuID, int weekInCycle)
        {
            bool isComplete = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_IsMenuWeekComplete");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@weekInCycle", DbType.Int32, weekInCycle);
                isComplete = Convert.ToBoolean(db.ExecuteScalar(cmd));                
            }
            catch
            {
                
            }
            return isComplete;
        }

        internal static bool AreAllMenuWeeksComplete(int menuID)
        {
            bool complete = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AreAllMenuWeeksComplete");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                complete = Convert.ToBoolean(db.ExecuteScalar(cmd));
            }
            catch
            {

            }
            return complete;
        }

        internal static bool EditMenuStatus(int menuID, int menuStatus, int editedBy, string customMsg)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_EditMenuStatus");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@menuStatus", DbType.Int32, menuStatus);
                db.AddInParameter(cmd, "@customMsg", DbType.String, customMsg);
                db.AddInParameter(cmd, "@editedBy", DbType.Int32, editedBy);
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }

        }

        internal static bool GetMyMenusByUserIDMenuID(int staffID, int menuID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MyMenus_by_UserID_menuID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
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

        internal static SqlDataReader GetMenus(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Menus");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Menus did not return a record!");
            }
        }

        internal static SqlDataReader GetMyMenusByUserID(int staffID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MyMenus_by_UserID");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Menus did not return a record!");
            }
        }

        internal static SqlDataReader GetMyMenusByUserIDContractTypeMenuStatus(int staffID, int contractType, int menuStatus)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MyMenus_by_UserID_contractType_menustatus");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@contractType", DbType.Int32, contractType);
            db.AddInParameter(cmd, "@menuStatus", DbType.Int32, menuStatus);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Sp_Get_MyMenus_by_UserID_contractType_menustatus did not return a record!");
            }
        }

        internal static SqlDataReader GetMyMenusByUserIDContractIDpeMenuStatus(int staffID, int contractID, int menuStatus, int currentMenus, DateTime inputDate)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MyMenus_by_UserID_contractID_menustatus_byDate");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@contractID", DbType.Int32, contractID);
            db.AddInParameter(cmd, "@menuStatus", DbType.Int32, menuStatus);
            db.AddInParameter(cmd, "@currentMenus", DbType.Int32, currentMenus);
            db.AddInParameter(cmd, "@date", DbType.DateTime, inputDate);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Sp_Get_MyMenus_by_UserID_contractID_menustatus did not return a record!");
            }
        }

        internal static SqlDataReader GetMyMenusByUserIDContractIDpeMenuStatus_New(int staffID, int contractID, int menuStatus, int currentMenus, string menuText)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_MyMenus_by_UserID_contractID_menustatus_New");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@contractID", DbType.Int32, contractID);
            db.AddInParameter(cmd, "@menuStatus", DbType.Int32, menuStatus);
            db.AddInParameter(cmd, "@currentMenus", DbType.Int32, currentMenus);
            db.AddInParameter(cmd, "@menuText", DbType.String, menuText);
            
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Sp_Get_MyMenus_by_UserID_contractID_menustatus_New did not return a record!");
            }
        }

        internal static SqlDataReader GetSampleMenusByMenuStatus(int staffID, int menuStatusID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_SampleMenus_by_MenuStatus");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@menuStatus", DbType.Int32, menuStatusID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Sp_Get_SampleMenus_by_MenuStatus did not return a record!");
            }
 
        }


        internal static SqlDataReader GetMenusByCreatedbyAndStatus(int staffID, int statusID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Menus_by_CreatedByandStatus2");
            db.AddInParameter(cmd, "@staffID", DbType.Int32, staffID);
            db.AddInParameter(cmd, "@statusID", DbType.Int32, statusID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Menus did not return a record!");
            }
        }


        internal static SqlDataReader GetDraftMenusByContractIdStaffID(int StaffID, int ContractID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_DraftMenus_by_ContractID_CreatedBy");
            db.AddInParameter(cmd, "@StaffID", DbType.Int32, StaffID);
            db.AddInParameter(cmd, "@ContractID", DbType.Int32, ContractID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Menus did not return a record!");
            }

 
        }

        internal static bool DeactivateMenu(int menuID,int removeBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_RemoveMenu");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@removeBy", DbType.Int32, removeBy);
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }

        internal static void ReAciveMenu(int MenuID)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_ReActiveMenu");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, MenuID);

                db.ExecuteNonQuery(cmd);
            }
            catch { }
        }


        internal static bool UpdateMenu(int menuID, int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_UpdateMenu");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
                db.AddInParameter(cmd, "@contractID", DbType.Int32, contractID);
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }

        }

        internal static void SubmitToMultipleContracts(int OriginalMenuID, List<int> ContractIDs, int StaffID, string customMsg, int Menustatus)
        {
            try 
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("SP_SubmitMultipleContracts");

                db.AddInParameter(cmd, "@originalMenuID", DbType.Int32, OriginalMenuID);
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, StaffID);
                db.AddInParameter(cmd, "@Message ", DbType.String, customMsg);
                db.AddInParameter(cmd, "@MenuStatus", DbType.Int32, Menustatus);

                var table = new DataTable();
                table.Columns.Add("ContractList", typeof(string));

                foreach (int i in ContractIDs)
                {
                    table.Rows.Add(i);
                }

                SqlParameter sp = new SqlParameter();
                sp.SqlDbType = SqlDbType.Structured;
                sp.ParameterName = "@Contracts";
                sp.Value = table;
                cmd.Parameters.Add(sp); 


                db.ExecuteScalar(cmd); 
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        internal static int DuplicateMenu(int originalMenuID, int contractID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_DuplicateMenu");

                db.AddInParameter(cmd, "@originalMenuID", DbType.Int32, originalMenuID);
                db.AddInParameter(cmd, "@contractID", DbType.Int32, contractID);
               

                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int ReplicateMenu(int originalMenuID, string menuName, int cycleID, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_ReplicateMenu");

                db.AddInParameter(cmd, "@originalMenuID", DbType.Int32, originalMenuID);
                db.AddInParameter(cmd, "@menuName", DbType.String, menuName);
                db.AddInParameter(cmd, "@cycleID", DbType.Int32, cycleID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);


                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        internal static void SwapWeeksForMenu(int MenuId, string NewWeekOrder)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("SP_SwapWeeksForMenu");

                db.AddInParameter(cmd, "@MenuID", DbType.Int32, MenuId);
                db.AddInParameter(cmd, "@NewWeekOrder", DbType.String, NewWeekOrder);

                db.ExecuteScalar(cmd);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        internal static bool UndoAlternates(int menuID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_UndoAlternates");
                db.AddInParameter(cmd, "@menuID", DbType.Int32, menuID);
               
                db.ExecuteNonQuery(cmd);
                return true;

            }
            catch
            {
                return false;
            }
        }

        internal static int ReplicateMenu(int originalMenuID, int contractTypeID, int mealServedTypeID,int DietTypeID, int cycleID,
            string startDate, string endDate, int createdBy, string menuName, List<int> ContractIDs, int MealServedFormatID )
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_ReplicateMenuNew");

                db.AddInParameter(cmd, "@originalMenuID", DbType.Int32, originalMenuID);
                db.AddInParameter(cmd, "@contractTypeID", DbType.Int32, contractTypeID);
                db.AddInParameter(cmd, "@mealServedTypeID", DbType.Int32, mealServedTypeID);
                db.AddInParameter(cmd, "@dietTypeID", DbType.Int32, DietTypeID);
                db.AddInParameter(cmd, "@cycleID", DbType.Int32, cycleID);
                db.AddInParameter(cmd, "@startDate", DbType.String, startDate);
                db.AddInParameter(cmd, "@endDate", DbType.String, endDate);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@menuName", DbType.String, menuName);
                db.AddInParameter(cmd, "@MealServedFormatID", DbType.Int32, MealServedFormatID);

                if (ContractIDs != null)
                {
                    var table = new DataTable();
                    table.Columns.Add("ContractList", typeof(string));

                    foreach (int i in ContractIDs)
                    {
                        table.Rows.Add(i);
                    }

                    SqlParameter sp = new SqlParameter();
                    sp.SqlDbType = SqlDbType.Structured;
                    sp.ParameterName = "@contractIDs";
                    sp.Value = table;
                    cmd.Parameters.Add(sp);
                }

                return Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
               
        }

      
    }
}
