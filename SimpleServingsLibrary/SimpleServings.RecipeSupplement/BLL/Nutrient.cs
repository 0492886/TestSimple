using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.RecipeSupplement
{
    public class Nutrient
    {
        private int _nutrientID;
        public int NutrientID
        {
            get { return _nutrientID; }
            set { _nutrientID = value; }
        }

        private string _nutrientName;
        public string NutrientName
        {
            get { return _nutrientName; }
            set { _nutrientName = value; }
        }

        private int _unit;
        public int Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public string UnitName
        {
            get { return Code.DecodeCode(Unit); }
        }

        private bool _display;
        public bool Display
        {
            get { return _display; }
            set { _display = value; }
        }
        
        private int _orders;
        public int Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        
        private int _createdBy;
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        
        private string _createdOn;
        public string CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
        
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        private static Nutrient PopNutrient(SqlDataReader dr)
        {
            using (dr)
            {
                Nutrient n = new Nutrient();

                if (dr.Read())
                {
                    n.NutrientID = Convert.ToInt32(dr["NutrientID"]);
                    n.NutrientName = dr["NutrientName"].ToString();
                    n.Unit = Convert.ToInt32(dr["Unit"]);
                    n.Display = Convert.ToBoolean(dr["Display"]);
                    n.Orders = Convert.ToInt32(dr["Orders"]);
                    n.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    n.CreatedOn = dr["CreatedOn"].ToString();
                    n.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return n;
            }
        }

        private static Nutrients PopNutrients(SqlDataReader dr)
        {
            using (dr)
            {
                Nutrients ns = new Nutrients();

                while (dr.Read())
                {
                    Nutrient n = new Nutrient();

                    n.NutrientID = Convert.ToInt32(dr["NutrientID"]);
                    n.NutrientName = dr["NutrientName"].ToString();
                    n.Unit = Convert.ToInt32(dr["Unit"]);
                    n.Display = Convert.ToBoolean(dr["Display"]);
                    n.Orders = Convert.ToInt32(dr["Orders"]);
                    n.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    n.CreatedOn = dr["CreatedOn"].ToString();
                    n.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    ns.Add(n);
                }

                return ns;
            }
        }

        public static Nutrients GetNutrientsAll()
        {
            return PopNutrients(NutrientDB.GetNutrientAll());
        }

        public void GetNutrientByNutrientID(int nutrientID)
        {
            PopNutrient(NutrientDB.GetNutrientByNutrientID(nutrientID));
        }
    }

    public class Nutrients : List<Nutrient> { }
}
