using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Menu
{
    public class MenuDay
    {
        public int MenuDayID { get; set; }
        public int MenuID { get; set; }
        public int DayOfWeekID { get; set; }
        public string DayName { get; set; }

        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int RemovedBy { get; set; }
        public string RemovedOn { get; set; }

        

        

        #region Private Methods

        private void PopMenuDay(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    MenuDayID = Convert.ToInt32(dr["MenuDayID"]);
                    MenuID = Convert.ToInt32(dr["MenuID"]);
                    DayOfWeekID = Convert.ToInt32(dr["DayOfWeekID"]);
                    DayName = Convert.ToString(dr["DayName"]);
                    

                }
            }
        }

        private static MenuDays PopMenuDays(SqlDataReader dr)
        {
            MenuDays days = new MenuDays();
            MenuDay day;
            using (dr)
            {
                while (dr.Read())
                {
                    day = new MenuDay();
                    day.MenuDayID = Convert.ToInt32(dr["MenuDayID"]);
                    day.MenuID = Convert.ToInt32(dr["MenuID"]);                   
                    day.DayOfWeekID = Convert.ToInt32(dr["DayOfWeekID"]);
                    day.DayName = Convert.ToString(dr["DayName"]);
                    

                    days.Add(day);
                }
            }
            return days;

        }

        private void ValidateMenuDay()
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] { });
                ArrayList fieldNames = new ArrayList(new string[] { });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));

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

        public int AddMenuDay()
        {
            ValidateMenuDay();
            return MenuDayDB.AddMenuDay(MenuID, DayOfWeekID, CreatedBy);
        }




        public void GetMenuDayByMenuDayID(int menuDayID)
        {
            PopMenuDay(MenuDayDB.GetMenuDayByMenuDayID(menuDayID));
        }
        public static MenuDays GetMenuDaysByMenuID(int menuID)
        {
            return PopMenuDays(MenuDayDB.GetMenuDaysByMenuID(menuID));
        }


        #endregion

    }
    public class MenuDays : List<MenuDay> { }
}


