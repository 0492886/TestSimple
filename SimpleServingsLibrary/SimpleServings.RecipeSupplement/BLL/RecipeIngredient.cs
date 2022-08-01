using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;
using System.Text.RegularExpressions;


namespace SimpleServingsLibrary.RecipeSupplement
{
    public class RecipeIngredient
    {
        private int _ingredientID;
        public int IngredientID
        {
            get { return _ingredientID; }
            set { _ingredientID = value; }
        }
        
        private int _recipeID;
        public int RecipeID
        {
            get { return _recipeID; }
            set { _recipeID = value; }
        }
        
        private double _quantity;
        public double Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string QuantityText
        {
            get
            {
                return GetQuantityText();
            }
        }

        private int _numerator;
        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }
        
        private int _denominator;
        public int Denominator
        {
            get { return _denominator; }
            set { _denominator = value; }
        }

        private int _measureUnit;
        public int MeasureUnit
        {
            get { return _measureUnit; }
            set { _measureUnit = value; }
        }
        
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string DescriptionSyntax
        {
            get { return Symbol.FormatToSyntax(Description); }
        }

        public string DesriptionHtml
        {
            get { return Symbol.FormatToHtml(Description); }
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

        public string MeasureUnitText
        {
            get 
            { 
                string unit = Code.DecodeCode(MeasureUnit);
                if (unit.ToLower() == "item")
                {
                    return string.Empty;
                }
                else
                {
                    return unit;
                }
            }
        }

        public string IngredientDescription
        { 
            get
            {
                if (Quantity != 0)
                {
                    return string.Format("{0} {1} {2}", GetFormattedQuantity(), MeasureUnitText, DesriptionHtml);
                }
                else
                {
                    return DesriptionHtml;
                }
            }
        }

        private string GetFormattedQuantity()
        {
            if (Numerator % Denominator == 0)
            {
                return (Numerator / Denominator).ToString();
            }
            else
            {
                string moduler = string.Empty;
                if ((Numerator / Denominator) >= 1)
                {
                    moduler = ((int)(Numerator / Denominator)).ToString();
                }
                return string.Format("{0}<sup style=\"font-size: 70%; vertical-align: 0.7ex;\">{1}</sup>/<sub style=\"font-size: 70%; vertical-align: -0.3ex;\">{2}</sub>", moduler, (Numerator % Denominator), Denominator);
            }
        }

        private string GetQuantityText()
        {
            if (Numerator % Denominator == 0)
            {
                return (Numerator / Denominator).ToString();
            }
            else
            {
                string moduler = string.Empty;
                if ((Numerator / Denominator) >= 1)
                {
                    moduler = ((int)(Numerator / Denominator)).ToString();
                }
                return string.Format("{0} {1}/{2}", moduler, (Numerator % Denominator), Denominator);
            }
        }

        public RecipeIngredient() { }

        public RecipeIngredient(int ingredientID, double quantity, int measureUnit, string description, int createdBy)
        {
            _ingredientID = ingredientID;
            _quantity = quantity;
            _measureUnit = measureUnit;
            _description = description;
            _createdBy = createdBy;
        }

        public RecipeIngredient(int ingredientID, string quantity, int measureUnit, string description, int createdBy)
        {
            _ingredientID = ingredientID;
            _measureUnit = measureUnit;
            _description = description;
            _createdBy = createdBy;
            Init(quantity);
        }

        private static RecipeIngredient PopRecipeIngredient(SqlDataReader dr)
        {
            using (dr)
            {
                RecipeIngredient ri = new RecipeIngredient();

                if (dr.Read())
                {
                    ri.IngredientID = Convert.ToInt32(dr["IngredientID"]);
                    ri.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    ri.Quantity = Convert.ToDouble(dr["Quantity"]);
                    ri.Numerator = Convert.ToInt32(dr["Numerator"]);
                    ri.Denominator = Convert.ToInt32(dr["Denominator"]);
                    ri.MeasureUnit = Convert.ToInt32(dr["MeasureUnit"]);
                    ri.Description = dr["Description"].ToString();
                    ri.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    ri.CreatedOn = dr["CreatedOn"].ToString();
                    ri.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return ri;
            }
        }

        private static RecipeIngredients PopRecipeIngredientList(SqlDataReader dr)
        {
            using (dr)
            {
                RecipeIngredients riList = new RecipeIngredients();

                while (dr.Read())
                {
                    RecipeIngredient ri = new RecipeIngredient();

                    ri.IngredientID = Convert.ToInt32(dr["IngredientID"]);
                    ri.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    ri.Quantity = Convert.ToDouble(dr["Quantity"]);
                    ri.Numerator = Convert.ToInt32(dr["Numerator"]);
                    ri.Denominator = Convert.ToInt32(dr["Denominator"]);
                    ri.MeasureUnit = Convert.ToInt32(dr["MeasureUnit"]);
                    ri.Description = dr["Description"].ToString();
                    ri.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    ri.CreatedOn = dr["CreatedOn"].ToString();
                    ri.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    riList.Add(ri);
                }

                return riList;
            }
        }

        private static string ReadString(SqlDataReader dr)
        {
            return dr["Result"].ToString();
        }

        private bool IsFraction(string value)
        {
            if (value.Contains(@"/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Init(string quantity)
        {
            if (IsFraction(quantity) == true)
            {
                if (quantity.Trim().Contains(" ") == true)
                {
                    string[] quantityArray = quantity.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    int multiply = Convert.ToInt32(quantityArray[0]);
                    Fraction f = new Fraction(quantityArray[1].Trim());
                    Denominator = (int)f.Denominator;
                    Numerator = (int)f.Numerator + (multiply * Denominator);
                    Quantity = (double)Numerator / Denominator;
                }
                else
                {
                    Fraction f = new Fraction(quantity);
                    Numerator = (int)f.Numerator;
                    Denominator = (int)f.Denominator;
                    Quantity = f.ToDouble();
                }
            }
            else
            {
                Quantity = Convert.ToDouble(quantity);
                Fraction f = new Fraction(Quantity);
                Numerator = (int)f.Numerator;
                Denominator = (int)f.Denominator;
            }
        }

        public void AddRecipeIngredient(int recipeID)
        {
            AddRecipeIngredient(recipeID, Quantity, Numerator, Denominator, MeasureUnit, DescriptionSyntax, CreatedBy);
        }

        public static void AddRecipeIngredient(int recipeID, double quantity, int numerator, int denominator, int measureUnit, string description, int createdBy)
        {

            RecipeIngredientDB.AddRecipeIngredient(recipeID, quantity, numerator, denominator, measureUnit, description, createdBy);
        }

        public static RecipeIngredients GetRecipeIngredientByRecipeID(int recipeID)
        {
            return PopRecipeIngredientList(RecipeIngredientDB.GetRecipeIngredientByRecipeID(recipeID));
        }

        public static void EditRecipeIngredientByID(int ingredientID, double quantity, int numerator, int denominator, int measureUnit, string description)
        {
            RecipeIngredientDB.EditRecipeIngredientByID(ingredientID, quantity, numerator, denominator, measureUnit, description);
        }

        public static void RemoveRecipeIngredientByRecipeID(int recipeID)
        {
            RecipeIngredientDB.RemoveRecipeIngredientByRecipeID(recipeID);
        }

        public void RemoveRecipeIngredientByID(int ingredientID)
        {
            RecipeIngredientDB.RemoveRecipeIngredientByID(ingredientID);
        }

        public void UpdateTest()
        {
            Fraction f = new Fraction(Quantity);
            string frac = f.ToString();
            Numerator = (int)f.Numerator;
            Denominator = (int)f.Denominator;
            RecipeIngredientDB.EditRecipeIngredientByIDTest(IngredientID, Numerator, Denominator);
        }
    }

    public class RecipeIngredients : List<RecipeIngredient> 
    {
        public bool Exists(RecipeIngredient ri)
        {
            foreach (RecipeIngredient thisRi in this)
            {
                if (thisRi.IngredientID == ri.IngredientID)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
