using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Menu
{
    public class MenuCycle
    {
        public int MenuCycleID { get; set; }
        public int CycleID { get; set; }
        public string CycleName
        {
            get { return Code.DecodeCode(CycleID); }
        }
        public string CycleStartDate { get; set; }
        public string CycleEndDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveText 
        {
            get
            {
                if (IsActive)
                    return "Yes";
                else
                    return "No";
            }
        }


        #region Private Methods

        private void PopMenuCycle(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    MenuCycleID = Convert.ToInt32(dr["MenuCycleID"]);
                    CycleID = Convert.ToInt32(dr["CycleID"]);
                    CycleStartDate = Convert.ToString(dr["CycleStartDate"]);
                    CycleEndDate = Convert.ToString(dr["CycleEndDate"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                dr.Close();
            }
        }

        private static MenuCycles PopMenuCycles(SqlDataReader dr)
        {
            MenuCycles cycles = new MenuCycles();
            MenuCycle cycle;
            using (dr)
            {
                while (dr.Read())
                {
                    cycle = new MenuCycle();
                    cycle.MenuCycleID = Convert.ToInt32(dr["MenuCycleID"]);
                    cycle.CycleID = Convert.ToInt32(dr["CycleID"]);
                    cycle.CycleStartDate = Convert.ToString(dr["CycleStartDate"]);
                    cycle.CycleEndDate = Convert.ToString(dr["CycleEndDate"]);
                    cycle.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    cycle.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    cycle.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    cycles.Add(cycle);
                }
                dr.Close();
            }

            return cycles;
        }

        private void ValidateMenuCycle()
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] {CycleID,CycleStartDate,CycleEndDate,CreatedBy  });
                ArrayList fieldNames = new ArrayList(new string[] { "Period", "Cycle Start Date", "Cycle End Date", "CreatedBy" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));
                sb.Append(Validation.ValidateDates(CycleStartDate, "Cycle start Date"));
                sb.Append(Validation.ValidateDates(CycleEndDate, "Cycle start Date"));
                sb.Append(Validation.ValidateMonday(CycleStartDate, "Cycle start Date"));
                sb.Append(Validation.ValidateSunday(CycleEndDate, "Cycle End Date "));
                //sb.Append(Validation.ValidateSixWeekCycle(CycleStartDate,CycleEndDate));
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

        public static MenuCycles GetActiveMenuCycles()
        {
            return PopMenuCycles(MenuCycleDB.GetActiveMenuCycles());
        }

        public static MenuCycles GetAllMenuCycles() 
        {
            return PopMenuCycles(MenuCycleDB.GetAllMenuCycles());
        }

        public void GetMenuCycleByCycleId(int cycleId)
        {
            PopMenuCycle(MenuCycleDB.GetMenuCycleByCycleId(cycleId));
        }

        public void GetMenuCycleById(int menuCycleID) 
        {
            PopMenuCycle(MenuCycleDB.GetMenuCyclesByID(menuCycleID));    
        }

        public static bool RemoveMenuCyclesByID(int menuCycleID)
        {
            return MenuCycleDB.RemoveMenuCyclesByID(menuCycleID);
        }

        public  bool AddMenuCycle()
        {
            ValidateMenuCycle();
            return MenuCycleDB.AddMenuCycle(CycleID, CycleStartDate, CycleEndDate, CreatedBy);
        }

        public  bool EditMenuCycle()
        {
            ValidateMenuCycle();
            return MenuCycleDB.EditMenuCycle(MenuCycleID,CycleID, CycleStartDate, CycleEndDate, CreatedBy);
        }

        #endregion
    }
    public class MenuCycles : List<MenuCycle> { }

}