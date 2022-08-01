using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using SimpleServingsLibrary.Shared;
using SimpleServingsLibrary.Menu;
using System.Web.UI.WebControls;

namespace SimpleServingsLibrary.MenuThreshold
{
    public class MenuThreshold
    {
        private int _thresholdID;
        public int ThresholdID
        {
            get { return _thresholdID; }
            set { _thresholdID = value; }
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

        private string _nutrientUnit;
        public string NutrientUnit
        {
            get { return _nutrientUnit; }
            set { _nutrientUnit = value; }
        }

        private int _mealServedTypeID;
        public int MealServedTypeID
        {
            get { return _mealServedTypeID; }
            set { _mealServedTypeID = value; }
        }

        private int _dietTypeID;
        public int DietTypeID
        {
            get { return _dietTypeID; }
            set { _dietTypeID = value; }
        }


        private int _contractTypeID;
        public int ContractTypeID
        {
            get { return _contractTypeID; }
            set { _contractTypeID = value; }
        }

        private int _inequalityTypeID;
        public int InequalityTypeID
        {
            get { return _inequalityTypeID; }
            set { _inequalityTypeID = value; }
        }

        private int _periodicalTypeID;
        public int PeriodicalTypeID
        {
            get { return _periodicalTypeID; }
            set { _periodicalTypeID = value; }
        }

        public string PeriodicalText
        {
            get { return Code.DecodeCode(PeriodicalTypeID); }
        }

        public string ContractTypeText
        {
            get { return Code.DecodeCode(ContractTypeID); }
        }

        public string InequalityTypeText
        {
            get { return Code.DecodeCode(InequalityTypeID); }
        }

        private double _lowThreshold;
        public double LowThreshold
        {
            get { return _lowThreshold; }
            set { _lowThreshold = value; }
        }

        private double _highThreshold;
        public double HighThreshold
        {
            get { return _highThreshold; }
            set { _highThreshold = value; }
        }

        private double _sumOfNutrition;
        public double SumOfNutrition
        {
            get { return _sumOfNutrition; }
            set { _sumOfNutrition = value; }
        }

        public double SumOfNutriontRoundUp
        {
            get
            {
                return Math.Round(SumOfNutrition, 0);
            }
        }

        private int _dependsOnThresholdID;
        public int DependsOnThresholdID
        {
            get { return _dependsOnThresholdID; }
            set { _dependsOnThresholdID = value; }
        }

        private bool IsDependent
        {
            get { return Convert.ToBoolean(DependsOnThresholdID); }
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

        private Measurement Meter
        {
            get
            {
                string result = ValidateThreshold(this);

                if (result.Contains("too low"))
                {
                    return Measurement.Low;
                }
                else if (result.Contains("too high"))
                {
                    return Measurement.High;
                }
                else
                {
                    return Measurement.WithinRange;
                }
            }
        }

        public string MeterColor
        { 
            get
            {
                if (Meter == Measurement.Low)
                {
                    return "nutritionAlertLow";
                }
                else if (Meter == Measurement.High)
                {
                    return "nutritionAlertHigh";
                }
                else
                {
                    return "nutritionAlertRange";
                }
            }
        }

        private Comparison ComparisonSymbol
        {
            get { return (Comparison)Enum.Parse(typeof(Comparison), InequalityTypeID.ToString(), true); }
        }

        private enum Comparison
        { 
            WithinRange = GlobalEnum.Equation_Between,
            GreaterOrEqual = GlobalEnum.Equation_GreaterOrEqual,
            LessOrEqual = GlobalEnum.Equation_LessOrEqual
        }

        private enum Periodic
        { 
            Daily = GlobalEnum.Periodic_Daily,
            Weekly = GlobalEnum.Periodic_Weekly
        }

        private enum Measurement
        {
            Low,
            WithinRange,
            High
        }

        private static MenuThreshold PopThreshold(SqlDataReader dr)
        {
            using (dr)
            {
                MenuThreshold mh = new MenuThreshold();

                if (dr.Read())
                {
                    mh.ThresholdID = Convert.ToInt32(dr["ThresholdID"]);
                    mh.NutrientID = Convert.ToInt32(dr["NutrientID"]);
                    mh.NutrientName = dr["NutrientName"].ToString();
                    mh.MealServedTypeID = Convert.ToInt32(dr["MealServedTypeID"]);
                    mh.DietTypeID = Convert.ToInt32(dr["DietTypeID"]);
                    mh.ContractTypeID = Convert.ToInt32(dr["ContractTypeID"]);
                    mh.InequalityTypeID = Convert.ToInt32(dr["InequalityTypeID"]);
                    mh.PeriodicalTypeID = Convert.ToInt32(dr["PeriodicalTypeID"]);
                    mh.LowThreshold = Convert.ToDouble(dr["LowThreshold"]);
                    mh.HighThreshold = Convert.ToDouble(dr["HighThreshold"]);
                    mh.DependsOnThresholdID = Convert.ToInt32(dr["DependsOnThresholdID"]);
                    mh.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    mh.CreatedOn = dr["CreatedOn"].ToString();
                    mh.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return mh;
            }
        }

        private static MenuThresholds PopThresholds(SqlDataReader dr)
        {
            using (dr)
            {
                MenuThresholds mhs = new MenuThresholds();

                while (dr.Read())
                {
                    MenuThreshold mh = new MenuThreshold();

                    mh.ThresholdID = Convert.ToInt32(dr["ThresholdID"]);
                    mh.NutrientID = Convert.ToInt32(dr["NutrientID"]);
                    mh.NutrientName = dr["NutrientName"].ToString();
                    mh.MealServedTypeID = Convert.ToInt32(dr["MealServedTypeID"]);
                    mh.ContractTypeID = Convert.ToInt32(dr["ContractTypeID"]);
                    mh.InequalityTypeID = Convert.ToInt32(dr["InequalityTypeID"]);
                    mh.PeriodicalTypeID = Convert.ToInt32(dr["PeriodicalTypeID"]);
                    mh.LowThreshold = Convert.ToDouble(dr["LowThreshold"]);
                    mh.HighThreshold = Convert.ToDouble(dr["HighThreshold"]);
                    mh.DependsOnThresholdID = Convert.ToInt32(dr["DependsOnThresholdID"]);
                    mh.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    mh.CreatedOn = dr["CreatedOn"].ToString();
                    mh.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    mhs.Add(mh);
                }

                return mhs;
            }
        }

        private static MenuThresholds PopThresholdValidation(SqlDataReader dr)
        {
            using (dr)
            {
                MenuThresholds mhs = new MenuThresholds();

                while (dr.Read())
                {
                    MenuThreshold mh = new MenuThreshold();

                    mh.ThresholdID = Convert.ToInt32(dr["ThresholdID"]);
                    mh.NutrientID = Convert.ToInt32(dr["NutrientID"]);
                    mh.NutrientName = dr["NutrientName"].ToString();
                    mh.NutrientUnit = dr["NutrientUnit"].ToString();
                    mh.InequalityTypeID = Convert.ToInt32(dr["InequalityTypeID"]);
                    mh.LowThreshold = Convert.ToDouble(dr["LowThreshold"]);
                    mh.HighThreshold = Convert.ToDouble(dr["HighThreshold"]);
                    mh.SumOfNutrition = Convert.ToDouble(dr["SumOfNutrition"]);
                    mh.DependsOnThresholdID = Convert.ToInt32(dr["DependsOnThresholdID"]);

                    mhs.Add(mh);
                }

                return mhs;
            }
        }

        public int AddMenuThreshold()
        {
            ValidateAddMenuThreshold();
            return MenuThresholdDB.AddMenuThreshold(NutrientID, MealServedTypeID, DietTypeID, ContractTypeID, InequalityTypeID, PeriodicalTypeID, LowThreshold, HighThreshold, DependsOnThresholdID, CreatedBy);
        }

        public bool EditMenuThreshold()
        {
            ValidateAddMenuThreshold();
            return MenuThresholdDB.EditMenuThreshold(ThresholdID, NutrientID, MealServedTypeID, DietTypeID, ContractTypeID, InequalityTypeID, PeriodicalTypeID, LowThreshold, HighThreshold, DependsOnThresholdID);
        }

        public static bool DeactivateMenuThreshold(int ThresholdID)
        {
            return MenuThresholdDB.DeactivateMenuThreshold(ThresholdID);
        }


        public static MenuThresholds GetMenuThresholdsByTypes(int mealServedTypeID, int contractTypeID, int periodicalTypeID, int dietTypeID)
        {
            return PopThresholds(MenuThresholdDB.GetMenuThresholdByTypes(mealServedTypeID, contractTypeID, periodicalTypeID, dietTypeID));
        }

        public static MenuThresholds GetMenuThresholdByMealServedType(int mealServedTypeID)
        {
            return PopThresholds(MenuThresholdDB.GetMenuThresholdByMealServedType(mealServedTypeID));
        }

        public static MenuThreshold GetMenuThresholdsByID(int thresholdID)
        {
            return PopThreshold(MenuThresholdDB.GetMenuThresholdByID(thresholdID));
        }

        public static MenuThresholds GetMenuThresholdsDaily(int menuID, int weekInCycle, int dayOfWeekID)
        {
            return PopThresholdValidation(MenuThresholdDB.GetMenuThresholdValidationDaily(menuID, weekInCycle, dayOfWeekID));
        }

        public static MenuThresholds GetMenuThresholdsWeekly(int menuID, int weekInCycle)
        {
            return PopThresholdValidation(MenuThresholdDB.GetMenuThresholdValidationWeekly(menuID, weekInCycle));
        }

        public static bool ValidateThreshold(int menuID, int weekInCycle)
        {
            StringBuilder sb = new StringBuilder();

            MenuThresholds mtsWeekly = GetMenuThresholdsWeekly(menuID, weekInCycle);

            //If weekly validation passed, return true, otherwise validate daily and throw exception
            List<int> listNutrientID = ValidateThresholdWeekly(mtsWeekly);

            //if (listNutrientID.Count == mtsWeekly.Count)
            //{
            //    return true;
            //}

            sb.AppendLine(ValidateThresholdDaily(menuID, weekInCycle, listNutrientID));

            if (sb.ToString().Trim() != string.Empty)
            {
                throw new Exception(sb.ToString());
            }

            return true;
        }

        //this method will return a list of nutrientID which fail the validation
        private static List<int> ValidateThresholdWeekly(MenuThresholds mtsWeekly)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < mtsWeekly.Count; i++)
            {
                int nutrientID = GetWeeklyPassedNutrientID(mtsWeekly[i]);
                if (nutrientID > 0)
                {
                    list.Add(nutrientID);
                }
            }

            return list;
        }

        private void ValidateAddMenuThreshold()
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] {NutrientID,MealServedTypeID,PeriodicalTypeID,ContractTypeID,InequalityTypeID  });
                ArrayList fieldNames = new ArrayList(new string[] { "Nutrient", "Meal Type", "Periodical Type", "Contract Type", "Inequality Type" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));
                
                if (sb.Length != 0)
                    throw new Exception(sb.ToString());
                if (!Validation.IsFloat(HighThreshold.ToString()))
                {
                    throw new Exception("Valid number for High Threshold value is requires");
                }
                if (!Validation.IsFloat(LowThreshold.ToString()))
                {
                    throw new Exception("Valid number for Low Threshold value is requires");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private static string ValidateThresholdDaily(int menuID, int weekInCycle, List<int> listNutrientID)
        {
            StringBuilder sb = new StringBuilder();

            MenuDays days = MenuDay.GetMenuDaysByMenuID(menuID);

            foreach (MenuDay day in days)
            {
                StringBuilder daySb = new StringBuilder();

                MenuThresholds mtsDaily = GetMenuThresholdsDaily(menuID, weekInCycle, day.DayOfWeekID);
                mtsDaily.RemoveAt(listNutrientID);

                for (int i = 0; i < mtsDaily.Count; i++)
                {
                    daySb.AppendLine(ValidateThreshold(mtsDaily[i]));
                }

                if (daySb.ToString().Trim() != string.Empty)
                {
                    sb.AppendLine(string.Format("<div class=\"dayWeekTitle\">{0}</div>",day.DayName));
                    sb.AppendLine("<ul class=\"validationErrorList\">");
                    sb.AppendLine(daySb.ToString());
                    sb.AppendLine("</ul>");
                }
            }

            return sb.ToString();
        }

        //This method is return the NutrientID which pass the nutrition analysis
        private static int GetWeeklyPassedNutrientID(MenuThreshold threshold)
        {
            StringBuilder sb = new StringBuilder();

            if (threshold.ComparisonSymbol == Comparison.WithinRange)
            {
                if (IsWithinRange(threshold) == false)
                {
                    return 0;
                }
            }

            if (threshold.ComparisonSymbol == Comparison.GreaterOrEqual)
            {
                if (IsGreaterOrEqual(threshold) == false)
                {
                    return 0;
                }
            }

            if (threshold.ComparisonSymbol == Comparison.LessOrEqual)
            {
                if (IsLessOrEqual(threshold) == false)
                {
                    return 0;
                }
            }

            return threshold.NutrientID;
        }

        //This method is return the validation message 
        private static string ValidateThreshold(MenuThreshold threshold)
        {
            StringBuilder sb = new StringBuilder();

            if (threshold.ComparisonSymbol == Comparison.WithinRange)
            {
                if (IsWithinRange(threshold) == false)
                {
                    sb.AppendLine(GetMessage(threshold));
                }
            }

            if (threshold.ComparisonSymbol == Comparison.GreaterOrEqual)
            {
                if (IsGreaterOrEqual(threshold) == false)
                {
                    sb.AppendLine(GetMessage(threshold));
                }
            }

            if (threshold.ComparisonSymbol == Comparison.LessOrEqual)
            {
                if (IsLessOrEqual(threshold) == false)
                {
                    sb.AppendLine(GetMessage(threshold));
                }
            }

            return sb.ToString();
        }

        private static bool IsWithinRange(MenuThreshold threshold)
        {
            if (threshold.DependsOnThresholdID > 0)
            {
                MenuThreshold dmt = GetMenuThresholdsByID(threshold.DependsOnThresholdID);
                double lowerValue = (threshold.LowThreshold / 100) * dmt.LowThreshold;
                double upperValue = (threshold.HighThreshold / 100) * dmt.HighThreshold;

               
                return IsWithinRange(lowerValue, upperValue, threshold.GetDependentValue());
            }
            else
            {
                return IsWithinRange(threshold.LowThreshold, threshold.HighThreshold, threshold.SumOfNutriontRoundUp);
            }
        }

        private static bool IsWithinRange(double lowerValue, double upperValue, double value)
        {
            if (value >= lowerValue && value <= upperValue)
            {
                return true;
            }

            return false;
        }

        private static bool IsGreaterOrEqual(MenuThreshold threshold)
        {
            if (threshold.DependsOnThresholdID > 0)
            {
                MenuThreshold dmt = GetMenuThresholdsByID(threshold.DependsOnThresholdID);
                double minValue = (threshold.LowThreshold / 100) * dmt.LowThreshold;

                return IsGreaterOrEqual(minValue, threshold.GetDependentValue());
            }
            else 
            {
                return IsGreaterOrEqual(threshold.LowThreshold, threshold.SumOfNutriontRoundUp);
            }
        }

        private static bool IsGreaterOrEqual(double minValue, double value)
        {
            if (value >= minValue)
            {
                return true;
            }

            return false;
        }

        private static bool IsLessOrEqual(MenuThreshold threshold)
        {
            if (threshold.DependsOnThresholdID > 0)
            {
                MenuThreshold dmt = GetMenuThresholdsByID(threshold.DependsOnThresholdID);
                double maxValue = (threshold.HighThreshold / 100) * dmt.HighThreshold;

                return IsLessOrEqual(maxValue, threshold.GetDependentValue());
            }
            else
            {
                return IsLessOrEqual(threshold.HighThreshold, threshold.SumOfNutriontRoundUp);
            }
        }

        private static bool IsLessOrEqual(double maxValue, double value)
        {
            if (value <= maxValue)
            {
                return true;
            }

            return false;
        }

        private double GetDependentValue()
        {
            //temp formular to caluate calories from fat
            return Math.Round(SumOfNutrition * 9, 0);
        }

        private static string GetMessage(MenuThreshold threshold)
        {
            if (threshold.ComparisonSymbol == Comparison.WithinRange)
            {
                if (threshold.DependsOnThresholdID > 0)
                {
                    if (threshold.GetDependentValue() < threshold.LowThreshold)
                    {
                        return GetMessage(threshold, Measurement.Low);
                    }
                    else
                    {
                        return GetMessage(threshold, Measurement.High);
                    }
                }
                else
                {
                    if (threshold.SumOfNutriontRoundUp < threshold.LowThreshold)
                    {
                        return GetMessage(threshold, Measurement.Low);
                    }
                    else
                    {
                        return GetMessage(threshold, Measurement.High);
                    }
                }
            }

            if (threshold.ComparisonSymbol == Comparison.GreaterOrEqual)
            {
                return GetMessage(threshold, Measurement.Low);
            }

            if (threshold.ComparisonSymbol == Comparison.LessOrEqual)
            {
                return GetMessage(threshold, Measurement.High);
            }

            return string.Empty;
        }

        private static string GetMessage(MenuThreshold threshold, Measurement measure)
        {
            if (measure == Measurement.Low)
            {
                return string.Format("<li>{0} too low </li>", threshold.NutrientName);
            }
            else
            {
                return string.Format("<li>{0} too high </li>", threshold.NutrientName);
            }
        }

        public static void PopNutrientMeter(int menuID, int weekInCycle, Repeater rpt)
        {
            MenuThresholds menuThresholds = MenuThreshold.GetMenuThresholdsWeekly(menuID, weekInCycle);

            rpt.DataSource = menuThresholds;
            rpt.DataBind();
        }
        
    }

    public class MenuThresholds : List<MenuThreshold> 
    {
        public void RemoveAt(List<int> listNuritentID)
        {
            foreach(int nutrientID in listNuritentID)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (nutrientID == this[i].NutrientID)
                    {
                        this.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
