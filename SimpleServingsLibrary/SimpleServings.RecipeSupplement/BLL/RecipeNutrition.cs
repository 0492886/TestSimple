using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.RecipeSupplement
{
    public class RecipeNutrition
    {
        private int _nutritionID;
        public int NutritionID
        {
            get { return _nutritionID; }
            set { _nutritionID = value; }
        }

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

        private int _recipeID;
        public int RecipeID
        {
            get { return _recipeID; }
            set { _recipeID = value; }
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

        public string DiplayIndicator
        {
            get 
            {
                if (Display)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }

        private int _orders;
        public int Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        private int _nutritionFactsOrder;
        public int NutritionFactsOrder
        {
            get { return _nutritionFactsOrder; }
            set { _nutritionFactsOrder = value; }
        }

        //private double _value;
        //public double Value
        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private string _valueRounding;
        public string ValueRounding
        {
            get 
            {
                return Value.ToString();
                //return Math.Round(Value, MidpointRounding.AwayFromZero).ToString();
            }
            set { _valueRounding = value; }
        }

        private int _percentage;
        public int Percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }

        private string _percentageText;
        public string PercentageText
        {
            get
            {
                if (NutritionFactsOrder > 0)
                {
                    //total Sugar, Protein, Trans Fat don't show percentage number
                    if (Orders == 89 || Orders == 3 || Orders == 16)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0}%", Percentage);
                }
                else
                {
                    if (Percentage > 0)
                    {
                        _percentageText = string.Format("{0}%", Percentage);
                        return _percentageText;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

            set { _percentageText = value; }
        }

        public string NutritionFactName
        {
            get 
            {
                switch (Orders)
                { 
                    case 2:
                        //return string.Format("<span class=\"labelBold\" STYLE=\"font-size:18px\">{0}</span>", "Calories");
                        return string.Format("<span class=\"labelBold\" >{0}</span>", "Calories");
                        break;
                    case 5:
                        return string.Format("<span class=\"labelBold\">{0}</span>", "Total Fat");
                        break;
                    case 16:
                        return string.Format("<span class=\"sub\">{0}</span>", "Trans Fat");
                        break;
                    case 4:
                        return string.Format("<span class=\"labelBold\">{0}</span>", "Total Carbohydrate"); 
                        break;
                    case 55:
                        return string.Format("<span class=\"sub\">{0}</span>", "Dietary Fiber");
                    case 59:
                        // return string.Format("<span class=\"sub\">{0}</span>", "Sugars");
                        return string.Format("<span class=\"sub\"> &nbsp;&nbsp; {0}</span>", "Includes Added Sugars");
                        break;
                    case 89:
                        return string.Format("<span class=\"sub\">{0}</span>", "Total Sugars");
                        break;
                    case 20:
                        return "Vitamin A";
                        break;
                    case 7:
                    case 17:
                    case 3:
                        return string.Format("<span class=\"labelBold\">{0}</span>", NutrientName);
                        break;
                    case 8:
                        return string.Format("<span class=\"sub\">{0}</span>", NutrientName);
                    default:
                        return NutrientName;
                        break;
                }
            }
        }

        private string _nutritionFactInfo;
        public string NutritionFactInfo
        {
            get { return _nutritionFactInfo; }
            set { _nutritionFactInfo = value; }
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

        public string NutrientInfo
        {
            get { return string.Format("{0} {1} {2}", NutrientName, Value, UnitName);}
        }

        private static RecipeNutrition PopRecipeNutrition(SqlDataReader dr)
        {
            using (dr)
            {
                RecipeNutrition rn = new RecipeNutrition();

                if (dr.Read())
                {
                    rn.NutrientID = Convert.ToInt32(dr["NutrientID"]);
                    rn.NutrientName = dr["NutrientName"].ToString();
                    rn.Unit = Convert.ToInt32(dr["Unit"]);
                    rn.Display = Convert.ToBoolean(dr["Display"]);
                    rn.Orders = Convert.ToInt32(dr["Orders"]);
                    rn.NutritionFactsOrder = Convert.ToInt32(dr["NutritionFactsOrder"]);

                    if (dr["NutritionID"] != System.DBNull.Value)
                    {
                        rn.NutritionID = Convert.ToInt32(dr["NutritionID"]);
                    }
                    if (dr["RecipeID"] != System.DBNull.Value)
                    {
                        rn.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    }

                    if (dr["Value"] != System.DBNull.Value)
                    {
                        //rn.Value = Convert.ToDouble(dr["Value"]);
                        rn.Value = Convert.ToString(dr["Value"]);



                    }

                    if (dr["Percentage"] != System.DBNull.Value)
                    {
                        rn.Percentage = Convert.ToInt32(dr["Percentage"]);
                    }
                    else
                    {
                        rn.Percentage = 0;
                    }

                    if (dr["CreatedBy"] != System.DBNull.Value)
                    {
                        rn.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    }
                    if (dr["CreatedOn"] != System.DBNull.Value)
                    {
                        rn.CreatedOn = dr["CreatedOn"].ToString();
                    }
                    if (dr["IsActive"] != System.DBNull.Value)
                    {
                        rn.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                }

                return rn;
            }
        }

        private static RecipeNutritions PopRecipeNutritions(SqlDataReader dr)
        {
            using (dr)
            {
                RecipeNutritions rns = new RecipeNutritions();

                while (dr.Read())
                {
                    RecipeNutrition rn = new RecipeNutrition();
                    rn.NutrientID = Convert.ToInt32(dr["NutrientID"]);
                    rn.NutrientName = dr["NutrientName"].ToString();
                    rn.Unit = Convert.ToInt32(dr["Unit"]);
                    rn.Display = Convert.ToBoolean(dr["Display"]);
                    rn.Orders = Convert.ToInt32(dr["Orders"]);
                    rn.NutritionFactsOrder = Convert.ToInt32(dr["NutritionFactsOrder"]);

                    if (dr["NutritionID"] != System.DBNull.Value)
                    {
                        rn.NutritionID = Convert.ToInt32(dr["NutritionID"]);
                    }
                    if (dr["RecipeID"] != System.DBNull.Value)
                    {
                        rn.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    }

                    if (dr["Value"] != System.DBNull.Value)
                    {
                        rn.Value = Convert.ToString(dr["Value"]); //Convert.ToDouble(dr["Value"]);
                    }

                    if (dr["Percentage"] != System.DBNull.Value)
                    {
                        rn.Percentage = Convert.ToInt32(dr["Percentage"]);
                    }
                    else
                    {
                        rn.Percentage = 0;
                    }

                    if (dr["CreatedBy"] != System.DBNull.Value)
                    {
                        rn.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    }
                    if (dr["CreatedOn"] != System.DBNull.Value)
                    {
                        rn.CreatedOn = dr["CreatedOn"].ToString();
                    }
                    if (dr["IsActive"] != System.DBNull.Value)
                    {
                        rn.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }

                    rns.Add(rn);


                }

                return rns;
            }
        }

        private static RecipeNutritions GetRecipeNutritionFactsMoreByRecipeID(int recipeID)
        {
            return PopRecipeNutritions(RecipeNutritionDB.GetRecipeNutritionFactsMoreByRecipeID(recipeID));
        }

        public static void AddRecipeNutrition(int nutrientID, int recipeID, string value, int percentage, int createdBy)
        {
            RecipeNutritionDB.AddRecipeNutrition(nutrientID, recipeID, value, percentage, createdBy);
        }

        public static void EditRecipeNutritionByID(int nutritionID, string value, int percentage)
        {
            RecipeNutritionDB.EditRecipeNutritionByID(nutritionID, value, percentage);
        }

        public static void EditRecipeNutritionByNutrientIDAndRecipeID(int nutrientID, int recipeID, string value, int percentage)
        {
            RecipeNutritionDB.EditRecipeNutritionByNutrientIDAndRecipeID(nutrientID, recipeID, value, percentage);
        }

        public static RecipeNutritions GetRecipeNutritionByRecipeID(int recipeID)
        {
            return PopRecipeNutritions(RecipeNutritionDB.GetRecipeNutritionByRecipeID(recipeID));
        }

        public static RecipeNutritions GetRecipeNutritionFactsByRecipeID(int recipeID)
        {
            return PopRecipeNutritions(RecipeNutritionDB.GetRecipeNutritionFactsByRecipeID(recipeID));
        }

        public static RecipeNutritions GetRecipeNutritionFactsAllByRecipeID(int recipeID)
        {
            RecipeNutritions rns = GetRecipeNutritionFactsByRecipeID(recipeID);
            rns.AddRange(GetRecipeNutritionFactsMoreByRecipeID(recipeID));
            return rns;
        }

        public static RecipeNutritions GetRecipeNutritionDisplayByRecipeID(int recipeID)
        {
            return PopRecipeNutritions(RecipeNutritionDB.GetRecipeNutritionDisplayByRecipeID(recipeID));
        }

        public static RecipeNutritions GetRecipeNutritionMainByRecipeID(int recipeID)
        {
            return PopRecipeNutritions(RecipeNutritionDB.GetRecipeNutritionMainByRecipeID(recipeID));
        }

    }

    public class RecipeNutritions : List<RecipeNutrition> 
    {
        public void AddCalorieFromFat()
        {
            FormatCalorie();
            //Vitamin's order is 20, Calcium's order is 28
  //          Merge(20, 28);  // here merge 2 item in 1 line.   Mandy add
   //         Merge(27, 29);
        }

        private void FormatCalorie()
        {
            //Calorie's order is 2
            int index = GetIndexByOrder(2);

            RecipeNutrition rn = null;

            //Find the index of Total Fat
            for (int j = 0; j < this.Count; j++)
            {
                if (this[j].Orders == 5)
                {
                    rn = new RecipeNutrition();
                    rn.NutrientName = "Calories from Fat";
                    //rn.Value = Convert.ToInt32(this[j].Value * 9);

                    rn.Value = Convert.ToString( Convert.ToInt32(this[j].Value) * 9);

                    break;
                }
            }

            if (rn != null)
            {
                if (index >= 0)
                {
                    // this[index].NutritionFactInfo = string.Format("<div class=\"servCal\">{0} {1}<span class=\"calsFrom\">{2} {3}</span></div><div class=\"dailyValue\">% Daily Value *</div>", this[index].NutritionFactName, this[index].ValueRounding, rn.NutrientName, rn.Value);
                    
                     this[index].NutritionFactInfo = string.Format("<div class=\"servCal\" style=\"font-size:20px\">{0} <span class=\"calsFrom\" style=\"font-size:20px\">{1} </span></div><div class=\"dailyValue\">% Daily Value *</div>", this[index].NutritionFactName, this[index].ValueRounding);
                    
                }
            }
        }

        private void Merge(int mergeOrder, int removeOrder)
        {
            int mergeIndex = GetIndexByOrder(mergeOrder);
            int removeIndex = GetIndexByOrder(removeOrder);

            if (mergeIndex >= 0 && removeIndex >= 0)
            {
                this[mergeIndex].NutritionFactInfo = "<div class=\"nutrMinRow\">" + ApplyMergeStyle(this[mergeIndex].NutritionFactName, this[mergeIndex].PercentageText)
                    + ApplyMergeStyle(this[removeIndex].NutritionFactName, this[removeIndex].PercentageText) + "</div>";
                this.RemoveAt(removeIndex);
            }
        }

        private int GetIndexByOrder(int order)
        {
            int index = -1;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Orders == order)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void AddStyle()
        {
            //for (int i = 0; i < this.Count; i++)
            //{
            //    if (this[i].Orders == 5 ||
            //        this[i].Orders == 7 ||
            //        this[i].Orders == 17 ||
            //        this[i].Orders == 4 ||
            //        this[i].Orders == 3)
            //    {
            //        this[i].NutrientName = ApplyBold(this[i].NutrientName);
            //    }

            //    if (this[i].Orders == 8 ||
            //        this[i].Orders == 16 ||
            //        this[i].Orders == 55 ||
            //        this[i].Orders == 59)
            //    {
            //        this[i].NutrientName = ApplyIndentation(this[i].NutrientName);
            //    }
            //}
        }

        private string ApplyBold(string value)
        {
            return string.Format("{0}{1}{2}", "<span class=\"labelBold\">", value, "</span>");
        }


        private string ApplyIndentation(string value)
        {
            return string.Format("{0}{1}{2}", "<span class=\"sub\">", value, "</span>");
        }

        private string ApplyMergeStyle(string name, string value)
        {
            return string.Format("<div class=\"nutrMin\"><span class=\"nutrMinName\">{0}</span><span class=\"floatR\">{1}</span></div>", name, value);
        }

    }
}
