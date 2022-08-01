using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Menu
{
    public class MenuItem
    {
        public int MenuItemID { get; set; }
        public int MenuID { get; set; }
        public int RecipeID { get; set; }
        public int DayOfWeekID { get; set; }
        public int MenuItemTypeID { get; set; }
        public string MenuItemTypeIDText { get; set; }
        public short WeekInCycle { get; set; } //1 to 6
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int RemovedBy { get; set; }
        public string RemovedOn { get; set; }

        
        public string RecipeName {get; set;}
        public string DayOfWeekIDText{get ;set;}
        public bool IsAlternate { get; set; }
        public bool IsSampleMenuItem { get; set; }

        public string RecipeViewText { get; set; }
        public string ContributedBy { get; set; }
        

        public string ClassName
        {
            get
            {
               // return "draggable" + (IsAlternate? " alternate" : "");

                if (IsAlternate && IsSampleMenuItem)
                {
                    return "draggable alternate";
 
                }
                else if(IsAlternate) 
                {
                    return "draggable alternate"; 
 
                }
                else if (IsSampleMenuItem)
                {
                    return "draggable sampleMenuItem";

                }
                else
                {
                    return "draggable";
                }

            }
        }
        
        
        
        #region Private Methods

        private void PopMenuItem(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    MenuItemID = Convert.ToInt32(dr["MenuItemID"]);
                    MenuID = Convert.ToInt32(dr["MenuID"]);
                    RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    DayOfWeekID = Convert.ToInt32(dr["DayOfWeekID"]);
                    MenuItemTypeID = Convert.ToInt32(dr["MenuItemTypeID"]);
                    WeekInCycle = Convert.ToInt16(dr["WeekInCycle"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                    RemovedOn = Convert.ToString(dr["RemovedOn"]);
                    MenuItemTypeIDText = Convert.ToString(dr["MenuItemTypeIDText"]);
                    RecipeName = dr["RecipeName"].ToString();
                    DayOfWeekIDText = dr["DayOfWeekIDText"].ToString();
                    IsAlternate = Convert.ToBoolean(dr["IsAlternate"]);
                    RecipeViewText = dr["RecipeViewText"].ToString();
                    ContributedBy = dr["ContributedBy"].ToString();
                    IsSampleMenuItem = Convert.ToBoolean(dr["IsSampleMenuItem"]);

                }
            }
        }

        private static MenuItems PopMenuItems(SqlDataReader dr)
        {
            MenuItems items = new MenuItems();
            MenuItem item;
            using (dr)
            {
                while (dr.Read())
                {
                    item = new MenuItem();
                    item.MenuItemID = Convert.ToInt32(dr["MenuItemID"]);
                    item.MenuID = Convert.ToInt32(dr["MenuID"]);
                    item.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    item.DayOfWeekID = Convert.ToInt32(dr["DayOfWeekID"]);
                    item.MenuItemTypeID = Convert.ToInt32(dr["MenuItemTypeID"]);
                    item.WeekInCycle = Convert.ToInt16(dr["WeekInCycle"]);
                    item.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    item.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    item.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    item.RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                    item.RemovedOn = Convert.ToString(dr["RemovedOn"]);
                    item.MenuItemTypeIDText = Convert.ToString(dr["MenuItemTypeIDText"]);
                    item.RecipeName = dr["RecipeName"].ToString();
                    item.DayOfWeekIDText = dr["DayOfWeekIDText"].ToString();
                    item.IsAlternate = Convert.ToBoolean(dr["IsAlternate"]);
                    item.RecipeViewText = dr["RecipeViewText"].ToString();
                    item.ContributedBy = dr["ContributedBy"].ToString();

                    //changes for SampleMenu
                    item.IsSampleMenuItem = Convert.ToBoolean(dr["IsSampleMenuItem"]);

                    items.Add(item);
                }
            }
            return items;

        }

        private void ValidateMenuItem()
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] {MenuID,RecipeID,DayOfWeekID,MenuItemTypeID,WeekInCycle });
                ArrayList fieldNames = new ArrayList(new string[] { "MenuID", "RecipeID", "DayOfWeekID", "MenuItemTypeID", "WeekInCycle" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));
                if (Menu.IsMenuWeekComplete(MenuID, WeekInCycle))
                    sb.Append("Cannot edit a Complete Menu! <br>");

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

        public int AddMenuItem()
        {
            ValidateMenuItem();
            return MenuItemDB.AddMenuItem(MenuID,RecipeID,DayOfWeekID,MenuItemTypeID, 
         WeekInCycle, CreatedBy, IsSampleMenuItem);
        }


        public static List<int> GetDaysOfWeekByMenuID(int menuID)
        {
            return MenuItemDB.GetDaysOfWeekByMenuID(menuID);
        }

        public void GetMenuItemByMenuItemID(int menuItemID)
        {
            PopMenuItem(MenuItemDB.GetMenuItemByMenuItemID(menuItemID));
        }
        public static MenuItems GetMenuItemsByMenuID(int menuID)
        {
            return PopMenuItems(MenuItemDB.GetMenuItemsByMenuID(menuID));
        }
        public static MenuItems GetMenuItemsByMenuAndItemTypeAndWeekAndDay(int menuID, int menuItemTypeID,int weekInCycle, int dayOfWeekID)
        {
            return PopMenuItems(MenuItemDB.GetMenuItemsByMenuAndItemTypeAndWeekAndDay(menuID, menuItemTypeID, weekInCycle, dayOfWeekID));
        }
        //public static bool RemoveMenuItemByMenuItemID(int menuItemID)
        //{
            
        //    return MenuItemDB.RemoveMenuItemByMenuItemID(menuItemID);1
        //}
        public bool RemoveMenuItem()
        {
            if (Menu.IsMenuWeekComplete(MenuID, WeekInCycle)) //should be false
                throw new Exception("Cannot edit a Complete Menu! <br>");
            return MenuItemDB.RemoveMenuItemByMenuItemID(MenuItemID);
        }
        public static void DuplicateMenuItems(int originalMenuID, int newMenuID, bool setWeekStatus)
        {
            MenuItemDB.DuplicateMenuItems(originalMenuID, newMenuID, setWeekStatus);
        }
        public static bool SetIsAlternate(int menuItemID, bool isAlternate)
        {
            return MenuItemDB.SetIsAlternate(menuItemID,isAlternate);
        }
        public bool ToggleIsAlternate()
        {
            if (Menu.IsMenuWeekComplete(MenuID, WeekInCycle))
                throw new Exception("Cannot edit a Complete Menu! <br>");
            return MenuItemDB.SetIsAlternate(MenuItemID, !IsAlternate, CreatedBy);
        }


        //Mandy Add
        public static void SwapWeekDayMenu(int MenuID, int WeekInCycle, int initDayOfWeekID, int finalDayOfWeekID, int CreatedBy)
        {
             MenuItemDB.SwapWeekDayMenu(MenuID, WeekInCycle, initDayOfWeekID, finalDayOfWeekID, CreatedBy);
        }

        #endregion

    }
    public class MenuItems : List<MenuItem> { }
}


