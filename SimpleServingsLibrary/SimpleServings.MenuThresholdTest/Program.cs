using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleServings.MenuThresholdTest
{
    //Console testing for Menu Thresholds
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunMenuThresholdTest(6384, 1);
                RunMenuThresholdTest(6384, 2);
                RunMenuThresholdTest(6384, 3);
                RunMenuThresholdTest(6384, 4);
                RunMenuThresholdTest(6384, 5);
                RunMenuThresholdTest(6384, 6);
                RunMenuThresholdTest(6384, 7);

                //RunGetThresholdsWeeklyTest(6384, 1);
                //RunGetThresholdsWeeklyTest(6384, 2);
                //RunGetThresholdsWeeklyTest(6384, 3);
                //RunGetThresholdsWeeklyTest(6384, 4);
                //RunGetThresholdsWeeklyTest(6384, 5);
                //RunGetThresholdsWeeklyTest(6384, 6);
                //RunGetThresholdsWeeklyTest(6384, 7);

                //RunGetThresholdsDailyTest(6384, 1);
                //RunGetThresholdsDailyTest(6384, 2);
                //RunGetThresholdsDailyTest(6384, 3);
                //RunGetThresholdsDailyTest(6384, 4);
                //RunGetThresholdsDailyTest(6384, 5);
                //RunGetThresholdsDailyTest(6384, 6);
                //RunGetThresholdsDailyTest(6384, 7);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void RunMenuThresholdTest(int menuID, int weekInCycle)
        {
            try
            {
                SimpleServingsLibrary.Menu.Menu.ValidateRequiredItems(menuID, weekInCycle);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                SimpleServingsLibrary.MenuThreshold.MenuThreshold.ValidateThreshold(menuID, weekInCycle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void RunThresholdTest(int menuID, int weekInCycle)
        {
            bool validated = SimpleServingsLibrary.MenuThreshold.MenuThreshold.ValidateThreshold(menuID, weekInCycle);
            if (validated)
            {
                Console.WriteLine("Threshold valid for Menu {0} Week {1}", menuID, weekInCycle);
            }
            else
            {
                Console.WriteLine("Threshold invalid for Menu {0} Week {1}", menuID, weekInCycle);
            }
        }

        private static void RunGetThresholdsWeeklyTest(int menuID, int weekInCycle)
        {
            StringBuilder sb = new StringBuilder();
            SimpleServingsLibrary.MenuThreshold.MenuThresholds thresholds = SimpleServingsLibrary.MenuThreshold.MenuThreshold.GetMenuThresholdsWeekly(menuID, weekInCycle);
            if (thresholds != null && thresholds.Count > 0)
            {
                Console.WriteLine("Thresholds for Menu {0} Week {1}", menuID, weekInCycle);
                sb.AppendLine(string.Format("Thresholds for Menu {0} Week {1}", menuID, weekInCycle));
                Console.WriteLine("Nutrient Name\tLow Threshold\tHigh Threshold\tInequality\tSum\tSum Rounded\tUnit\tPeriodical");
                sb.AppendLine("Nutrient Name,Low Threshold,High Threshold,Inequality,Sum,Sum Rounded,Unit,Periodical");
                foreach (var threshold in thresholds)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", threshold.NutrientName, threshold.LowThreshold, threshold.HighThreshold,
                        threshold.InequalityTypeText, threshold.SumOfNutrition, threshold.SumOfNutriontRoundUp, threshold.NutrientUnit, threshold.PeriodicalText);
                    sb.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", threshold.NutrientName, threshold.LowThreshold, threshold.HighThreshold,
                            threshold.InequalityTypeText.Replace(",", "|"), threshold.SumOfNutrition, threshold.SumOfNutriontRoundUp, threshold.NutrientUnit, threshold.PeriodicalText));
                }

                string outputFilePath = System.IO.Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["TempFolder"], string.Format("Thresholds_for_Menu{0}_Week{1}.csv", menuID, weekInCycle));
                System.IO.File.WriteAllText(outputFilePath, sb.ToString());
            }
        }

        private static void RunGetThresholdsDailyTest(int menuID, int weekInCycle)
        {
            SimpleServingsLibrary.Menu.MenuDays days = SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);

            foreach (var day in days)
            {
                StringBuilder sb = new StringBuilder();
                SimpleServingsLibrary.MenuThreshold.MenuThresholds thresholds = SimpleServingsLibrary.MenuThreshold.MenuThreshold.GetMenuThresholdsDaily(menuID, weekInCycle, day.DayOfWeekID);
                if (thresholds != null && thresholds.Count > 0)
                {
                    Console.WriteLine("Thresholds for Menu {0} Week {1} - {2}", menuID, weekInCycle, day.DayName);
                    sb.AppendLine(string.Format("Thresholds for Menu {0} Week {1} - {2}", menuID, weekInCycle, day.DayName));
                    Console.WriteLine("Nutrient Name\tLow Threshold\tHigh Threshold\tInequality\tSum\tSum Rounded\tUnit\tPeriodical");
                    sb.AppendLine("Nutrient Name,Low Threshold,High Threshold,Inequality,Sum,Sum Rounded,Unit,Periodical");
                    foreach (var threshold in thresholds)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", threshold.NutrientName, threshold.LowThreshold, threshold.HighThreshold,
                            threshold.InequalityTypeText, threshold.SumOfNutrition, threshold.SumOfNutriontRoundUp, threshold.NutrientUnit, threshold.PeriodicalText);
                        sb.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", threshold.NutrientName, threshold.LowThreshold, threshold.HighThreshold,
                            threshold.InequalityTypeText.Replace(",","|"), threshold.SumOfNutrition, threshold.SumOfNutriontRoundUp, threshold.NutrientUnit, threshold.PeriodicalText));
                    }

                    string outputFilePath = System.IO.Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["TempFolder"], string.Format("Thresholds_for_Menu{0}_Week{1}_{2}.csv", menuID, weekInCycle, day.DayName));
                    System.IO.File.WriteAllText(outputFilePath, sb.ToString());

                }
            }
        }

        private static void RunValidationTest()
        {
            //add validation step
        }

    }
}
