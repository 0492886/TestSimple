using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;
using System.Collections;


namespace SimpleServingsLibrary.Menu
{
    //[Serializable]
    public class Menu
    {
        public int MenuID { get; set; }
        public int MenuTypeID { get; set; }
        public int ContractTypeID { get; set; }
        public int MealServedTypeID { get; set; }
        public int DietTypeID { get; set; }
        public int CycleID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public DateTime CreatedOnDT
        {
            get { return Convert.ToDateTime(CreatedOn); }
        }
        public int RemovedBy { get; set; }
        public string RemovedOn { get; set; }

       
        public string CreatedByText { get; set; }
        public string RemovedByText { get; set; }

        public string MealServedTypeIDText { get; set; }
        public string DietTypeIDText { get; set; }
        public string CycleIDText { get; set; }
        
        public int MenuStatus { get; set; }
        public string MenuStatusText { get; set; }
        public string ContractTypeName { get; set; }
        public int ContractID { get; set; }
        public string ContractName { get; set; }

        public List<int> ContractsIDs { get; set; }
        public List<string> ContractNames { get; set; }
        

        public int OriginalMenuID { get; set; }
        public string OriginalMenuName { get; set; }
        public int OriginalMenuTypeID { get; set; }

        public string MenuName { get; set; }
        public string SubmittedToDFTA { get; set; }
        public DateTime SubmittedToDFTADT
        {
            
            get {
                DateTime result = DateTime.MinValue;
                DateTime.TryParse(SubmittedToDFTA, out result);
                return Convert.ToDateTime(result); }
        }

        public int MealServedFormatID { get; set; }
        public string MealServedFormatText { get; set; }

        #region Private Methods

        private void PopMenu(SqlDataReader dr)
        {
            ContractNames = new List<string>();
            ContractsIDs = new List<int>();
            using (dr)
            {
                if (dr.Read())
                {
                    MenuID = Convert.ToInt32(dr["MenuID"]);
                    ContractTypeID = Convert.ToInt32(dr["ContractTypeID"]);
                    MealServedTypeID = Convert.ToInt32(dr["MealServedTypeID"]);
                    CycleID = Convert.ToInt32(dr["CycleID"]);
                    StartDate = Convert.ToString(dr["StartDate"]);
                    EndDate = Convert.ToString(dr["EndDate"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                    RemovedOn = Convert.ToString(dr["RemovedOn"]);
                    CreatedByText = Convert.ToString(dr["CreatedByText"]);
                    RemovedByText = Convert.ToString(dr["RemovedByText"]);
                    MenuStatus = Convert.ToInt32(dr["MenuStatus"]);
                    MealServedTypeIDText = dr["MealServedTypeIDText"].ToString();
                    CycleIDText = dr["CycleIDText"].ToString();
                    MenuStatusText = Convert.ToString(dr["MenuStatusText"]);
                    ContractTypeName = Convert.ToString(dr["ContractTypeName"]);
                    ContractID = Convert.ToInt32(dr["ContractID"]);
                    ContractName = Convert.ToString(dr["ContractName"]);
                    OriginalMenuID = Convert.ToInt32(dr["OriginalMenuID"]);
                    MenuName = Convert.ToString(dr["MenuName"]);
                    SubmittedToDFTA = Convert.ToString(dr["SubmittedToDFTA"]);
                    DietTypeID = Convert.ToInt32(dr["DietTypeID"]);
                    DietTypeIDText = dr["DietTypeText"].ToString();
                    MenuTypeID = Convert.ToInt32(dr["MenuTypeID"]);
                    OriginalMenuName = dr["SampleMenuName"].ToString();
                    OriginalMenuTypeID = Convert.ToInt32(dr["OriginalMenuTypeID"]);
                    MealServedFormatID = Convert.ToInt32(dr["MealServedFormatID"]);
                    MealServedFormatText = Convert.ToString(dr["MealServedFormatText"]);

                         

                    //try
                    //{
                    //    MenuTypeID = Convert.ToInt32(dr["MenuTypeID"]);
                    //}
                    //catch
                    //{
                    //    MenuTypeID = 182;
                    //}
                }

                if (dr.NextResult())
                {
                    while (dr.Read())
                    {
                        ContractNames.Add(Convert.ToString(dr["ContractName"]));
                        ContractsIDs.Add(Convert.ToInt32(dr["ContractID"]));
                    }
                }

            }
        }

        private static Menus PopMenus(SqlDataReader dr)
        {
            Menus menus = new Menus();
            Menu menu;
            using (dr)
            {
                while (dr.Read())
                {
                    menu = new Menu();
                    menu.MenuID = Convert.ToInt32(dr["MenuID"]);
                    menu.ContractTypeID = Convert.ToInt32(dr["ContractTypeID"]);
                    menu.MealServedTypeID = Convert.ToInt32(dr["MealServedTypeID"]);
                    menu.CycleID = Convert.ToInt32(dr["CycleID"]);
                    menu.StartDate = Convert.ToString(dr["StartDate"]);
                    menu.EndDate = Convert.ToString(dr["EndDate"]);
                    menu.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    menu.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    menu.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    menu.RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                    menu.RemovedOn = Convert.ToString(dr["RemovedOn"]);
                    menu.CreatedByText = Convert.ToString(dr["CreatedByText"]);
                    menu.RemovedByText = Convert.ToString(dr["RemovedByText"]);
                    menu.MenuStatus = Convert.ToInt32(dr["MenuStatus"]);
                    menu.MealServedTypeIDText = dr["MealServedTypeIDText"].ToString();
                    menu.CycleIDText = dr["CycleIDText"].ToString();
                    menu.MenuStatusText = Convert.ToString(dr["MenuStatusText"]);
                    menu.ContractTypeName = Convert.ToString(dr["ContractTypeName"]);
                    menu.ContractID = Convert.ToInt32(dr["ContractID"]);
                    menu.ContractName = Convert.ToString(dr["ContractName"]);
                    menu.OriginalMenuID = Convert.ToInt32(dr["OriginalMenuID"]);
                    menu.MenuName = Convert.ToString(dr["MenuName"]);
                    menu.SubmittedToDFTA = Convert.ToString(dr["SubmittedToDFTA"]);
                    menu.DietTypeID = Convert.ToInt32(dr["DietTypeID"]);
                    menu.DietTypeIDText = dr["DietTypeText"].ToString();

                    menu.MenuTypeID = Convert.ToInt32(dr["MenuTypeID"]);
                   // try
                   // {
                   //     menu.MenuTypeID = Convert.ToInt32(dr["MenuTypeID"]);
                   // }
                   //catch
                   // {
                   //     menu.MenuTypeID = 182;
                   // }
                    menus.Add(menu);
                }
            }
            return menus;

        }


        private static List<int> PopContracts(SqlDataReader dr)
        {
            List<int> contractIDs = new List<int>();

            using (dr)
            {
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr[""]);
                    contractIDs.Add(id); 
                }
            }

            return contractIDs;
        }


        /// <summary>
        /// Check all the required items to build a Menu
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="weekInCycle"></param>
        public static void ValidateRequiredItems(int menuID,int weekInCycle)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbPerDay;
            MenuDays days = new MenuDays();
            try
            {
                days = MenuDay.GetMenuDaysByMenuID(menuID);
            }
            catch
            {}

            foreach (MenuDay day in days)
            {
               SqlDataReader dr =  MenuDB.ValidateRequiredItems(menuID, weekInCycle, day.DayOfWeekID);
               sbPerDay = new StringBuilder();
                using (dr)
               {
                   while (dr.Read())
                   {
                       
                       sbPerDay.Append("<ul class=\"validationErrorList\">");
                       sbPerDay.Append(dr["Description"].ToString()+ " missing.");
                       sbPerDay.Append("</ul>");
                   }

               }
                if (sbPerDay != null && sbPerDay.Length > 0)
               {
                   sb.Append(string.Format("<div class=\"dayWeekTitleMealComponent\">{0}</div>", day.DayName));
                   sb.Append(sbPerDay);
               }


            }
            if (sb.Length > 0)
                throw new Exception(sb.ToString());
        }

        private void ValidateMenu()
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] {MenuName, ContractTypeID,MealServedTypeID,CycleID,StartDate,EndDate  });
                ArrayList fieldNames = new ArrayList(new string[] { "Menu Name", "Program Type", "Meal Type", "Cycle", "Start Date", "End Date" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));
                
                if (sb.Length != 0)
                    throw new Exception(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Validate Menu Name
        /// </summary>
        /// <param name="menuNameInput"></param>
        /// <returns></returns>
        public static string ValidateMenuName(string menuNameInput)
        {
            if (menuNameInput.Contains("&lt;b&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;b&gt;"));
            if (menuNameInput.Contains("<b>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<b>"));
            if (menuNameInput.Contains("\u003Cb\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cb\u003E"));
            if (menuNameInput.Contains("<br>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<br>"));
            if (menuNameInput.Contains("&lt;i&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;i&gt;"));
            if (menuNameInput.Contains("<i>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<i>"));
            if (menuNameInput.Contains("\u003Ci\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ci\u003E"));
            if (menuNameInput.Contains("&lt;script&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;script&gt;"));
            if (menuNameInput.Contains("<script>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<script>"));
            if (menuNameInput.Contains("\u003Cscript\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cscript\u003E"));
            if (menuNameInput.Contains("&lt;iframe&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;iframe&gt;"));
            if (menuNameInput.Contains("<iframe>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<iframe>"));
            if (menuNameInput.Contains("\u003Ciframe\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ciframe\u003E"));
            if (menuNameInput.Contains("&lt;frame&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;frame&gt;"));
            if (menuNameInput.Contains("<frame>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<frame>"));
            if (menuNameInput.Contains("\u003Cframe\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cframe\u003E"));

            if (menuNameInput.Contains("&lt;a&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;a&gt;"));
            if (menuNameInput.Contains("<a>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<a>"));
            if (menuNameInput.Contains("\u003Ca\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ca\u003E"));
            if (menuNameInput.ToLower().Contains("&lt;img&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;img&gt;"));
            if (menuNameInput.ToLower().Contains("<img>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<img>"));
            if (menuNameInput.Contains("\u003Cimg\u003E") || menuNameInput.Contains("\u003CIMG\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cimg\u003E"));

            if (menuNameInput.Contains("&lt;!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;!--#include"));
            if (menuNameInput.Contains("<!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<!--#include"));
            if (menuNameInput.Contains("\u003C!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003C!--#include"));

            if (menuNameInput.ToLower().Contains("&lt;style&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;style&gt;"));
            if (menuNameInput.ToLower().Contains("<style>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<style>"));
            if (menuNameInput.Contains("\u003Cstyle\u003E") || menuNameInput.Contains("\u003CSTYLE\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cstyle\u003E"));

            if (menuNameInput.Contains("|echo"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "|echo"));

            if (menuNameInput.ToLower().Contains("javascript:"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "javascript:"));
            if (menuNameInput.ToLower().Contains("src="))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "src="));
            if (menuNameInput.ToLower().Contains("file="))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "file="));
            if (menuNameInput.ToLower().Contains("@import"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "@import"));

            StringBuilder sb = new StringBuilder(menuNameInput);

            sb.Replace("\u003C", string.Empty);
            sb.Replace("\u003E", string.Empty);
            sb.Replace("\u0028", string.Empty);
            sb.Replace("\u0029", string.Empty);
            sb.Replace("&quot;", string.Empty);
            sb.Replace("&lt;", string.Empty);
            sb.Replace("&gt;", string.Empty);
            sb.Replace(";", string.Empty);

            return sb.ToString();
        }


       

        #endregion

        #region Public Methods

        /// <summary>
        /// Add Sample Menu
        /// </summary>
        /// <returns></returns>
        public int AddSampleMenu()
        {
            ValidateMenu();
            return MenuDB.AddSampleMenu(ContractTypeID, MealServedTypeID, DietTypeID, CycleID, StartDate, EndDate, CreatedBy, MenuName,MealServedFormatID);
        }

        /// <summary>
        /// Add Blank Menu 
        /// </summary>
        /// <returns></returns>
        public int AddMenu()
        {
            ValidateMenu();
            return MenuDB.AddMenu(ContractTypeID, MealServedTypeID, DietTypeID, ContractsIDs,CycleID, StartDate, EndDate, CreatedBy, MenuName, MealServedFormatID);
        }

        /// <summary>
        /// Add Regular Menu using sample menu 
        /// </summary>
        /// <returns></returns>
        public int AddMenuUsingSample()
        {
            ValidateMenu();
            return MenuDB.AddMenuUsingSample(ContractTypeID, MealServedTypeID, DietTypeID, CycleID, StartDate, EndDate, 
                CreatedBy, MenuName, OriginalMenuID, ContractsIDs, MealServedFormatID);
        }

        /// <summary>
        /// Edit Menu Fields ,e.g., Name, Diet Type etc.
        /// </summary>
        /// <returns></returns>
        public bool EditMenu()
        {
            ValidateMenu();
            if (ContractTypeID == GlobalEnum.ContractType_CongregateSlashHomeDelivered ||
                ContractTypeID == GlobalEnum.ContractType_HomeDelivered)
            {
                UndoAlternates(MenuID);
            }
            return MenuDB.EditMenu(MenuID, ContractTypeID, CycleID, StartDate, EndDate, CreatedBy, MenuName, DietTypeID, MealServedTypeID, ContractsIDs);
            
        }
        /// <summary>
        /// Edmit Menu Name
        /// </summary>
        /// <returns></returns>
        public bool EditMenuName()
        {
            return MenuDB.EditMenuName(MenuID, MenuName);
        }

        private bool UndoAlternates(int MenuID)
        {
            return MenuDB.UndoAlternates(MenuID);
        }

        /// <summary>
        /// Add Cuisine
        /// </summary>
        /// <returns></returns>
        public int AddCuisine(int menuID, int cuisine)
        {
            //ValidateMenu();
            return MenuDB.AddCuisine(menuID, cuisine, CreatedBy);
        }

        /// <summary>
        /// Returns single menu for the given MenuID
        /// </summary>
        /// <param name="menuID"></param>
        public void GetMenuByMenuID(int menuID)
        {
            PopMenu(MenuDB.GetMenuByMenuID(menuID));
        }

        public void GetMenuByMenuIDandStaffID(int menuID,int staffID)
        {
            PopMenu(MenuDB.GetMenuByMenuIDandStaffID(menuID, staffID));
        }

        public static bool SetMenuWeekStatus(int menuID, int weekInCycle, bool isComplete, int staffID)
        {
            return MenuDB.SetMenuWeekStatus(menuID, weekInCycle, isComplete, staffID);
        }
        public static bool IsMenuWeekComplete(int menuID, int weekInCycle)
        {
            return MenuDB.IsMenuWeekComplete(menuID, weekInCycle);
        }
        public static bool AreAllMenuWeeksComplete(int menuID)
        {
            return (MenuDB.AreAllMenuWeeksComplete(menuID)); //6 weeks per cycle
        }
        public bool EditMenuStatus(int menuStatus, int editedBy, string customMsg)
        {
            return MenuDB.EditMenuStatus(MenuID, menuStatus, editedBy, customMsg);
        }
        public static Menus GetMenus(int staffID)
        {
            return PopMenus(MenuDB.GetMenus(staffID));
        }
        public static Menus GetMyMenusByUserID(int staffID)
        {
            return PopMenus(MenuDB.GetMyMenusByUserID(staffID));
        }
        public static Menus GetMyMenusByUserIDContractTypeMenuStatus(int staffID, int contractType, int menuStatus)
        {
            return PopMenus(MenuDB.GetMyMenusByUserIDContractTypeMenuStatus(staffID, contractType, menuStatus));
        }
        public static Menus GetMyMenusByUserIDContractIDpeMenuStatus(int staffID, int contractID, int menuStatus, int currentMenus, DateTime inputDate)
        {
            return PopMenus(MenuDB.GetMyMenusByUserIDContractIDpeMenuStatus(staffID, contractID, menuStatus,currentMenus, inputDate));
        }

        public static Menus GetMyMenusByUserIDContractIDpeMenuStatus_New(int staffID, int contractID, int menuStatus, int currentMenus, string menuText)
        {
            return PopMenus(MenuDB.GetMyMenusByUserIDContractIDpeMenuStatus_New(staffID, contractID, menuStatus, currentMenus, menuText));
        }



        /// <summary>
        /// Method to Return Sample Menus in complete or incomplete status 
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="menuStatus"></param>
        /// <returns>Menus</returns>
        public static Menus GetSampleMenusByMenuStatus(int staffID, int menuStatus)
        {
            return PopMenus(MenuDB.GetSampleMenusByMenuStatus(staffID, menuStatus));          
             
        }

        public static bool GetMyMenusByUserIDMenuID(int staffID,int menuID)
        {
            return MenuDB.GetMyMenusByUserIDMenuID(staffID,menuID);
        }
        public static Menus GetMenusByCreatedbyAndStatus(int staffID,int statusID)
        {
            return PopMenus(MenuDB.GetMenusByCreatedbyAndStatus(staffID,statusID));
        }

        public static Menus GetDraftMenusByContractIdStaffID(int StaffID, int ContractID)
        {
            return PopMenus(MenuDB.GetDraftMenusByContractIdStaffID(StaffID, ContractID)); 
        }

        public static bool UpdateMenu(int menuID, int contractID)
        {
            return MenuDB.UpdateMenu(menuID, contractID);
        }

        /// <summary>
        /// If multipe Contracts are being submitted cope all Menu Details, Menu History, Menu Item and Menu Item History 
        /// </summary>
        /// <param name="OriginalMenuID"></param>
        /// <param name="ContractIDs"></param>
        /// <param name="StaffID"></param>
        /// <param name="customMsg"></param>
        /// <param name="Menustatus"></param>
        public static void SubmitToMultipleContracts(int OriginalMenuID, List<int> ContractIDs, int StaffID, string customMsg, int Menustatus)
        {
            MenuDB.SubmitToMultipleContracts(OriginalMenuID, ContractIDs, StaffID, customMsg, Menustatus);
        }

        public static int DuplicateMenu(int originalMenuID, int contractID)
        {
            return MenuDB.DuplicateMenu(originalMenuID, contractID);
        }
        public int ReplicateMenu(int originalMenuID)
        {
            ValidateMenu();
            return MenuDB.ReplicateMenu(originalMenuID, MenuName,CycleID,CreatedBy);
        }
        public int ReplicateMenuNew(int originalMenuID)
        {
            ValidateMenu();
            return MenuDB.ReplicateMenu(originalMenuID,ContractTypeID, MealServedTypeID,DietTypeID, CycleID, StartDate,EndDate, CreatedBy,MenuName, ContractsIDs, MealServedFormatID);
        }

        /// <summary>
        /// Swap Week Order for the replicated Menu 
        /// </summary>
        /// <param name="MenuId"></param>
        /// <param name="NewWeekOrder"></param>
        public static void SwapWeeksForMenu(int MenuId, string NewWeekOrder)
        {
            MenuDB.SwapWeeksForMenu(MenuId, NewWeekOrder); 
        }

        public static bool DeactivateMenu(int codeID, int removeBy)
        {
            bool removed = MenuDB.DeactivateMenu(codeID, removeBy);
            if (removed)
            {
                Logger.AddLog(0, codeID, GlobalEnum.MenuModule, "Removed Menu", removeBy);                
            }
            return removed;

        }

        public static void ReActiveMenu(int MenuID)
        {
            MenuDB.ReAciveMenu(MenuID);
        }




        #endregion

        #region Sortring
        public enum SortDirection
        {
            Ascending,
            Descending
        }

        private class SortContractTypeASC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.ContractTypeName.CompareTo(y.ContractTypeName);
            }
        }

        private class SortContractTypeDESC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.ContractTypeName.CompareTo(y.ContractTypeName) * (-1);
            }
        }

        private class SortContractNameASC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.ContractName.CompareTo(y.ContractName);
            }
        }

        private class SortContractNameDESC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.ContractName.CompareTo(y.ContractName) * (-1);
            }
        }

        private class SortMealTypeASC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.MealServedTypeIDText.CompareTo(y.MealServedTypeIDText);
            }
        }

        private class SortMealTypeDESC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.MealServedTypeIDText.CompareTo(y.MealServedTypeIDText) * (-1);
            }
        }

        private class SortCycleASC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.CycleIDText.CompareTo(y.CycleIDText);
            }
        }

        private class SortCycleDESC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.CycleIDText.CompareTo(y.CycleIDText) * (-1);
            }
        }

        private class SortMenuStatusASC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.MenuStatusText.CompareTo(y.MenuStatusText);
            }
        }

        private class SortMenuStatusDESC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.MenuStatusText.CompareTo(y.MenuStatusText) * (-1);
            }
        }

        private class SortCreatedOnASC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.CreatedOnDT.CompareTo(y.CreatedOnDT);
            }
        }

        private class SortCreatedOnDESC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.CreatedOnDT.CompareTo(y.CreatedOnDT) * (-1);
            }
        }
        private class SortMenuNameASC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.MenuName.CompareTo(y.MenuName);
            }
        }

        private class SortMenuNameDESC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                return x.MenuName.CompareTo(y.MenuName) * (-1);
            }
        }
        private class SortSubmittedToDFTAASC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
                 return x.SubmittedToDFTADT.CompareTo(y.SubmittedToDFTADT);               
            }
        }

        private class SortSubmittedToDFTADESC : IComparer<Menu>
        {
            public int Compare(Menu x, Menu y)
            {
               return x.SubmittedToDFTADT.CompareTo(y.SubmittedToDFTADT) * (-1);                
            }
        }

        public static IComparer<Menu> GetContractTypeSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortContractTypeASC();
            }
            else
            {
                return new SortContractTypeDESC();
            }
        }

        public static IComparer<Menu> GetContractNameSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortContractNameASC();
            }
            else
            {
                return new SortContractNameDESC();
            }
        }

        public static IComparer<Menu> GetMealTypeSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortMealTypeASC();
            }
            else
            {
                return new SortMealTypeDESC();
            }
        }

        public static IComparer<Menu> GetCycleSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortCycleASC();
            }
            else
            {
                return new SortCycleDESC();
            }
        }

        public static IComparer<Menu> GetMenuStatusSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortMenuStatusASC();
            }
            else
            {
                return new SortMenuStatusDESC();
            }
        }

        public static IComparer<Menu> GetCreatedOnSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortCreatedOnASC();
            }
            else
            {
                return new SortCreatedOnDESC();
            }
        }
        public static IComparer<Menu> GetMenuNameSortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortMenuNameASC();
            }
            else
            {
                return new SortMenuNameDESC();
            }
        }
        public static IComparer<Menu> GetSubmittedToDFTASortHelper(SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
            {
                return new SortSubmittedToDFTAASC();
            }
            else
            {
                return new SortSubmittedToDFTADESC();
            }
        }
        #endregion

    }

    //[Serializable]
    public class Menus : List<Menu> { }
}

