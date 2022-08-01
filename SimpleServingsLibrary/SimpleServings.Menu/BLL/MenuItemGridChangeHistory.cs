using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace SimpleServingsLibrary.Menu
{
    /// <summary>
    /// MenuItemGrid History Log Business logic
    /// </summary>
   public class MenuItemGridChangeHistory
    {
        public int LogID { get; set; }
        public int MenuID { get; set; }
        public int RecipeID { get; set; }
        public int WeekInCycle { get; set; }
        public int OriginalDayOfWeekID { get; set; }
        public int OriginalMenuItemTypeID { get; set; }
        public int NewDayOfWeekID { get; set; }
        public int NewMenuItemTypeID { get; set; }
        public string CreatedOn { get; set; }
        public string Action { get; set; }
        public int CreatedBy { get; set; }
        public string RecipeNameText { get; set; }
        public string OriginalDayOfWeekText { get; set; }
        public string OriginalMenuItemTypeText { get; set; }
        public string NewDayOfWeekText { get; set; }
        public string NewMenuItemTypeText { get; set; }
        public string CreatedByText { get; set; }

        private static MenuItemGridChangeHistorys PopMenuStatusHistories(SqlDataReader dr)
        {
            MenuItemGridChangeHistorys hisrtoyLog = new MenuItemGridChangeHistorys();
            MenuItemGridChangeHistory menuItemGridLog;
            while (dr.Read())
            {
                menuItemGridLog = new MenuItemGridChangeHistory();
                menuItemGridLog.LogID = Convert.ToInt32(dr["LogID"]);
                menuItemGridLog.MenuID = Convert.ToInt32(dr["MenuID"]);
                menuItemGridLog.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                menuItemGridLog.WeekInCycle = Convert.ToInt32(dr["WeekInCycle"]);
                menuItemGridLog.OriginalDayOfWeekID = Convert.ToInt32(dr["OriginalDayOfWeekID"]);
                menuItemGridLog.OriginalMenuItemTypeID = Convert.ToInt32(dr["OriginalMenuItemTypeID"]);
                menuItemGridLog.NewDayOfWeekID = Convert.ToInt32(dr["NewDayOfWeekID"]);
                menuItemGridLog.NewMenuItemTypeID = Convert.ToInt32(dr["NewMenuItemTypeID"]);
                menuItemGridLog.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                menuItemGridLog.Action = Convert.ToString(dr["Action"]);
                menuItemGridLog.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                menuItemGridLog.RecipeNameText = Convert.ToString(dr["RecipeNameText"]);
                menuItemGridLog.OriginalDayOfWeekText = Convert.ToString(dr["OriginalDayOfWeekText"]);
                menuItemGridLog.OriginalMenuItemTypeText = Convert.ToString(dr["OriginalMenuItemTypeText"]);
                menuItemGridLog.NewDayOfWeekText = Convert.ToString(dr["NewDayOfWeekText"]);                
                menuItemGridLog.NewMenuItemTypeText = Convert.ToString(dr["NewMenuItemTypeText"]);
                menuItemGridLog.CreatedByText = Convert.ToString(dr["CreatedByText"]);
                hisrtoyLog.Add(menuItemGridLog);
            }
            dr.Close();
            return hisrtoyLog;
        }

       /// <summary>
       /// Get MenuItem (Recipe) history log if any original Sample Menu Item is moved/ removed
       /// </summary>
       /// <param name="menuID"></param>
       /// <returns></returns>
       public static MenuItemGridChangeHistorys GetMenuItemGridChangeHistorysByMenuID(int menuID)
       {
           return PopMenuStatusHistories(MenuItemGridChangeHistoryDB.GetMenuItemGridChangeHistorysByMenuID(menuID));
       }

       /// <summary>
       /// Insert Item in History table for Regular Menus if any Original Sample Menu Item moved
       /// </summary>
       /// <param name="MenuID"></param>
       /// <param name="RecipeID"></param>
       /// <param name="WeekInCycle"></param>
       /// <param name="OriginalDayOfWeekID"></param>
       /// <param name="OriginalMenuItemTypeID"></param>
       /// <param name="NewDayOfWeekID"></param>
       /// <param name="NewMenuItemTypeID"></param>
       /// <param name="CreatedBy"></param>
       /// <param name="Action"></param>
       public static void AddMenuItemGridChangeHistory(int MenuID, int RecipeID, int WeekInCycle, int OriginalDayOfWeekID, int OriginalMenuItemTypeID,
            int NewDayOfWeekID, int NewMenuItemTypeID, int CreatedBy, string Action)
       {
           MenuItemGridChangeHistoryDB.AddMenuItemGridChangeHistory(MenuID, RecipeID, WeekInCycle, OriginalDayOfWeekID, OriginalMenuItemTypeID,
            CreatedBy, Action, NewDayOfWeekID, NewMenuItemTypeID);
       }


       /// <summary>
       /// Insert Item in History table for Regular Menus if any Original Sample Menu Item removed
       /// </summary>
       /// <param name="MenuID"></param>
       /// <param name="RecipeID"></param>
       /// <param name="WeekInCycle"></param>
       /// <param name="OriginalDayOfWeekID"></param>
       /// <param name="OriginalMenuItemTypeID"></param>
       /// <param name="CreatedBy"></param>
       /// <param name="Action"></param>
       public static void AddMenuItemGridChangeHistory(int MenuID, int RecipeID, int WeekInCycle, int OriginalDayOfWeekID, int OriginalMenuItemTypeID,
        int CreatedBy, string Action)
       {
           MenuItemGridChangeHistoryDB.AddMenuItemGridChangeHistory(MenuID, RecipeID, WeekInCycle, OriginalDayOfWeekID, OriginalMenuItemTypeID,
            CreatedBy, Action);
       }

    }

    /// <summary>
   /// List of MenuItemGridChangeHistory
    /// </summary>
   public class MenuItemGridChangeHistorys : List<MenuItemGridChangeHistory> {   }
}
