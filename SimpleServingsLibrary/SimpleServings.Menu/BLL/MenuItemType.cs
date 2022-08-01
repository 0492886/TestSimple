using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Menu
{
    public class MenuItemType
    {
        public int MenuItemTypeID { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public string Comment { get; set; }
        public string IsRequiredText { get; set; }
        public int MealServedTypeID { get; set; }


        private static MenuItemTypes PopMenuItemTypes(SqlDataReader dr)
        {
            MenuItemTypes types = new MenuItemTypes();
            MenuItemType type;
            using (dr)
            {
                while (dr.Read())
                {
                    type = new MenuItemType();
                    type.MenuItemTypeID = Convert.ToInt32(dr["MenuItemTypeID"]);
                    type.Description = Convert.ToString(dr["Description"]);
                    type.IsRequired = Convert.ToBoolean(dr["IsRequired"]);
                    type.Comment =Convert.ToString(dr["Comment"]);
                    type.IsRequiredText = Convert.ToString(dr["IsRequiredText"]) ;
                    type.MealServedTypeID = Convert.ToInt32(dr["MealServedTypeID"]);
                    types.Add(type);
                }
            }
            return types;

        }

       

        #region Public Methods


        public static MenuItemTypes GetAllMenuItemTypes(int mealServedTypeID)
        {
            return PopMenuItemTypes(MenuItemTypeDB.GetAllMenuItemTypes(mealServedTypeID));
        }


        #endregion

    }
    public class MenuItemTypes : List<MenuItemType> { }
}



 