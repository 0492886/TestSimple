using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.SupplierRelationship
{
    public class Meal
    {
        private int _mealServedID;
        public int MealServedID
        {
            get { return _mealServedID; }
            set { _mealServedID = value; }
        }

        private int _contractID;
        public int ContractID
        {
            get { return _contractID; }
            set { _contractID = value; }
        }

        private int _mealServedTypeID;
        public int MealServedTypeID
        {
            get { return _mealServedTypeID; }
            set { _mealServedTypeID = value; }
        }

        public string MealServedTypeName
        {
            get { return Code.DecodeCode(MealServedTypeID); }
        }

        public Meal() { }

        public Meal(int mealServedTypeID)
        {
            _mealServedTypeID = mealServedTypeID;
        }

        private static Meal PopMeal(SqlDataReader dr)
        {
            using (dr)
            {
                Meal m = new Meal();

                if (dr.Read())
                {
                    m.MealServedID = Convert.ToInt32(dr["MealServedID"]);
                    m.ContractID = Convert.ToInt32(dr["ContractID"]);
                    m.MealServedTypeID = Convert.ToInt32(dr["MealServedTypeID"]);
                } 

                return m;
            }
        }

        private static Meals PopMeals(SqlDataReader dr)
        {
            using (dr)
            {
                Meals ms = new Meals();

                while (dr.Read())
                {
                    Meal m = new Meal();

                    m.MealServedID = Convert.ToInt32(dr["MealServedID"]);
                    m.ContractID = Convert.ToInt32(dr["ContractID"]);
                    m.MealServedTypeID = Convert.ToInt32(dr["MealServedTypeID"]);

                    ms.Add(m);
                }

                return ms;
            }
        }

        public void AddMeal(int contractID)
        {
            AddMeal(contractID, MealServedTypeID);
        }

        public static void AddMeal(int contractID, int mealServedTypeID)
        {
            MealDB.AddMeal(contractID, mealServedTypeID);
        }

        public static Meals GetMealByContractID(int contractID)
        {
            return PopMeals(MealDB.GetMealByContractID(contractID));
        }

        public static void RemoveMealByContractID(int contractID)
        {
            MealDB.RemoveMealByContractID(contractID);
        }

    }

    public class Meals : List<Meal> { }
}
