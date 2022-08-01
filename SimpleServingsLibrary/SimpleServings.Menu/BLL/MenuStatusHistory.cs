using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Menu
{
   public class MenuStatusHistory
    {
        #region Public Properties

        public int MenuStatusHistoryID  {get; set;}
        public int MenuID{get; set;}
        public int StatusID{get; set;}
        public string StatusText
        {
            get { return SimpleServingsLibrary.Shared.Code.DecodeCode(StatusID); }
        }
        public string StatusDate{get; set;}
        public string Comments{get; set;}      
        public string CreatedOn{get; set;}
        public int CreatedBy{get; set;}     
        public string CreatedByText
        {
            get { return SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(CreatedBy); }
        }



        #endregion

        #region Private Methods

        private void PopMenuStatusHistory(SqlDataReader dr)
        {
            if (dr.Read())
            {
                MenuStatusHistoryID = Convert.ToInt32(dr["MenuStatusHistoryID"]);
                MenuID = Convert.ToInt32(dr["MenuID"]);
                StatusID = Convert.ToInt32(dr["StatusID"]);
                StatusDate = Convert.ToString(dr["StatusDate"]);
                Comments = Convert.ToString(dr["Comments"]);
                CreatedOn = Convert.ToString(dr["CreatedOn"]);
                CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            }
            dr.Close();
        }

        private static MenuStatusHistories PopMenuStatusHistories(SqlDataReader dr)
        {
            MenuStatusHistories statuses = new MenuStatusHistories();
            MenuStatusHistory menuStatus;
            while (dr.Read())
            {
                menuStatus = new MenuStatusHistory();
                menuStatus.MenuStatusHistoryID = Convert.ToInt32(dr["MenuStatusHistoryID"]);
                menuStatus.MenuID = Convert.ToInt32(dr["MenuID"]);
                menuStatus.StatusID = Convert.ToInt32(dr["StatusID"]);
                menuStatus.StatusDate = Convert.ToString(dr["StatusDate"]);
                menuStatus.Comments = Convert.ToString(dr["Comments"]);
                menuStatus.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                menuStatus.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                statuses.Add(menuStatus);
            }
            dr.Close();
            return statuses;
        }
        #endregion

        # region Public Methods

        public static MenuStatusHistories GetMenuStatusHistoryByMenuID(int menuID)
        {
            return PopMenuStatusHistories(MenuStatusHistoryDB.GetMenuStatusHistoryByRecipeID(menuID));
        }

        #endregion


    }
    public class MenuStatusHistories : List<MenuStatusHistory> { }
}
