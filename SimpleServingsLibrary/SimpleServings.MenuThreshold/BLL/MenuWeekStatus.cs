using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Menu
{
    public class MenuWeekStatus
    {
        private int _menuWeekID;
        public int MenuWeekID
        {
            get { return _menuWeekID; }
            set { _menuWeekID = value; }
        }
        
        private int _menuID;
        public int MenuID
        {
            get { return _menuID; }
            set { _menuID = value; }
        }
        
        private int _weekInCycle;
        public int WeekInCycle
        {
            get { return _weekInCycle; }
            set { _weekInCycle = value; }
        }

        public string WeekInCycleName
        {
            get { return string.Format("Week {0}", WeekInCycle); }
        }

        private bool _isComplete;
        public bool IsComplete
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

        public string Status
        {
            get 
            {
                if (IsComplete)
                {
                    return "Complete";
                }
                else
                {
                    return "Not Complete";
                }
            }
        }

        public MenuWeekStatus(){}

        public MenuWeekStatus(int menuID, int weekInCycle, bool isComplete)
        {
            MenuID = menuID;
            WeekInCycle = weekInCycle;
            IsComplete = isComplete;
        }

        private static MenuWeekStatus PopWeekStatus(SqlDataReader dr)
        {
            using (dr)
            {
                MenuWeekStatus mws = new MenuWeekStatus();

                if (dr.Read())
                {
                    mws.MenuWeekID = Convert.ToInt32(dr["MenuWeekID"]);
                    mws.MenuID = Convert.ToInt32(dr["MenuID"]);
                    mws.WeekInCycle = Convert.ToInt32(dr["WeekInCycle"]);
                    mws.IsComplete = Convert.ToBoolean(dr["IsComplete"]);
                }

                return mws;
            }
        }

        private static MenuWeekStatusList PopWeekStatusList(SqlDataReader dr)
        {
            using (dr)
            {
                MenuWeekStatusList mwsList = new MenuWeekStatusList();

                while (dr.Read())
                {
                    MenuWeekStatus mws = new MenuWeekStatus();

                    mws.MenuWeekID = Convert.ToInt32(dr["MenuWeekID"]);
                    mws.MenuID = Convert.ToInt32(dr["MenuID"]);
                    mws.WeekInCycle = Convert.ToInt32(dr["WeekInCycle"]);
                    mws.IsComplete = Convert.ToBoolean(dr["IsComplete"]);

                    mwsList.Add(mws);
                }

                return mwsList;
            }
        }

        public static MenuWeekStatusList GetMenuWeekStatusByMenuID(int menuID)
        {
            return Replace(GetInCompleteListByMenuID(menuID), PopWeekStatusList(MenuWeekStatusDB.GetMenuWeekStatusByMenuID(menuID)));
        }

        private static MenuWeekStatusList GetInCompleteListByMenuID(int menuID)
        {
            MenuWeekStatusList mwsList = new MenuWeekStatusList();

            for (int i = 1; i <= 6; i++)
            {
                mwsList.Add(new MenuWeekStatus(menuID, i, false));
            }

            return mwsList;
        }

        private static MenuWeekStatusList Replace(MenuWeekStatusList parentList, MenuWeekStatusList childList)
        { 
            for(int i = 0; i < childList.Count; i++)
            {
                for(int j = 0; j < parentList.Count; j++)
                {
                    if (childList[i].WeekInCycle == parentList[j].WeekInCycle)
                    {
                        parentList[j].IsComplete = childList[i].IsComplete;
                        break;
                    }
                }
            }

            return parentList;
        }

    }

    public class MenuWeekStatusList : List<MenuWeekStatus> {}
}
