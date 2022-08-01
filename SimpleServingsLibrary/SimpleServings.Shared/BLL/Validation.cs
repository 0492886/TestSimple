using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace SimpleServingsLibrary.Shared
{
    public class Validation
    {
        public static bool IsValidZipCode(string zipCode)
        {
            Regex reg = new Regex(@"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$");
            return reg.IsMatch(zipCode);
        }
        public static bool IsValidPhone(string phoneNumber)
        {
            Regex reg = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
            //Regex reg = new Regex(@"^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*[-\/\.]?\s*(\d{3})\s*[-\/\.]?\s*(\d{4})\s*(([xX]|[eE][xX][tT])\.?\s*(\d+))*$");
            return reg.IsMatch(phoneNumber);
        }
        public static bool IsValidEMail(string eMail)
        {
            
            Regex reg = new Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            return reg.IsMatch(eMail);
        }
        public static bool IsValidHRAEMail(string eMail)
        {
            if (!eMail.ToLower().Contains("hra.nyc.gov")) return false;
            return IsValidEMail(eMail);
        }
        public static bool IsValidURL(string uRL)
        {
            Regex reg = new Regex(@"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)|([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return reg.IsMatch(uRL);
        }
        public static bool IsValidDate(string date)
        {
            
            // we only allow dates of the format "MM/DD/YYYY".
            //Regex reg = new System.Text.RegularExpressions.Regex(@"^\d{2}/\d{2}/\d{4}$");

            // We decided to relax the date format
            try
            {
                Convert.ToDateTime(date);
                return true;
            }
            catch
            {
                return false;
            }
            //return reg.IsMatch(date);
        }
        public static bool IsValidPassword(string password)
        {
            if (password.Length < 6) return false;
            if (!ContainsNumber(password)) return false;
            return true;

        }
        private static bool ContainsNumber(string test)
        {

            for (int i = 0; i < test.Length; i++)
            {

                if (char.IsNumber(test[i]))
                {

                    return true;

                }

            }

            return false;

        }


        public static bool IsNotEmpty(string value)
        {
            return (value != null && value.Trim() != ""  && value.Trim() != "0");
        }
        public static string AreNotEmpty(ArrayList values, ArrayList fieldNames)
        {
            StringBuilder sb = new StringBuilder();
            string value;
            for (int i = 0; i < values.Count; i++)
            {
                try
                {
                    value = values[i].ToString();
                }
                catch (Exception)
                {
                    value = null;
                }
                if (value == null || value.Trim() == "" ||  value.Trim() == "0")
                    sb.Append("*" + fieldNames[i] + " is a required field! <br>");
            }
            return sb.ToString();
        }
        public static bool IsInteger(string value)
        {
            try
            {
                Int32.Parse(value);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static bool IsFloat(string value)
        {
            try
            {
                float.Parse(value);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static bool IsValidSSN(string val)
        {
            Regex reg = new Regex(@"\d{3}\-\d{2}\-\d{4}$");
            return reg.IsMatch(val);
        }
        public static string ValidateRequired(string val, string fieldName, bool allowZeroValue)
        {
            //check to see if zero value is allowed
            //if not allowed, raise error
            if (!allowZeroValue)
                if (val.Trim() == "0" )
                    return "*" + fieldName + " is a required field! <br>";

            if (val == null || val.Trim() == "")
                return "*" + fieldName + " is a required field! <br>";
            return "";
        }
        public static string ValidateIntegerRequired(int val, string fieldName)
        {
            if (val == 0)
                return "*" + fieldName + " is a required field! <br>";
            return "";
        }
        public static string ValidateInteger(string val, string fieldName)
        {
            if (!IsInteger(val))
                return "*" + fieldName + " is not a valid number! <br>";
            return "";
        }
        //
        public static string ValidateRequiredInteger(string val, string fieldName)
        {
            if (val.Trim() == "0")
                return "*" + fieldName + " is not a valid number! <br>";
            else
            {
                if (!IsInteger(val))
                    return "*" + fieldName + " is not a valid number! <br>";
                return "";
            }
        }
        public static string ValidateRequiredMoney(string val, string fieldName)
        {
            if (val.Trim() == "0")
                return "*" + fieldName + " is not a valid number! <br>";
            else
            {
                if (!IsFloat(val))
                    return "*" + fieldName + " is not a valid number! <br>";
                return "";
            }
        }
        //
        public static string ValidateMoney(string val, string fieldName)
        {
            if (!IsFloat(val))
                return "*" + fieldName + " is not a valid number! <br>";
            return "";
        }
        public static string ValidateZipCode(string val, string fieldName)
        {
            if (!IsValidZipCode(val))
                return "*" + fieldName + " is not a valid zip code! <br>";
            return "";
        }
        public static string ValidateNumber(string val, string fieldName)
        {
            if (!IsNumber(val))
                return "*" + fieldName + " is not a valid number! <br>";
            return "";
        }
        public static string ValidatePhoneNumber(string val, string fieldName)
        {
            if (!IsValidPhone(val))
                return "*" + fieldName + " is not a valid phone number!<br>";
            return "";
        }
        public static string ValidateSSN(string val, string fieldName)
        {
            if (!IsValidSSN(val))
                return "*" + fieldName + " is not a valid SSN!<br>";
            return "";
        }
        public static string ValidateEmail(string val, string fieldName)
        {
            if (!IsValidEMail(val))
                return "*" + fieldName + " is not a valid Email!<br>";
            return "";
        }
        public static string ValidateURL(string val, string fieldName)
        {
            if (!IsValidURL(val))
                return "*" + fieldName + " is not a valid URL!<br>";
            return "";
        }
        public static string ValidateDates(string date, string dateName)
        {
            if (date == null || date.Trim() == "")
                return "";
            else
            {
                try
                {
                    if (!IsValidDate(date))
                        return "* " + dateName.ToUpper() + " is not a valid date!<br>";
                }
                catch
                {
                    return "* " + dateName.ToUpper() + " is not a valid date!<br>";
                }
            }
            return "";
        }
        public static string ValidateMonday(string startDate, string dateName)
        {
            if (startDate == null || startDate.Trim() == "")
                return "";
            
            DateTime dt = Convert.ToDateTime(startDate);
            int dayofweek = (int)dt.DayOfWeek;
            if (dayofweek != 1)
                return "* " + dateName.ToUpper() + " should be Monday<br>";
            return "";
        }
        public static string ValidateSunday(string startDate, string dateName)
        {
            if (startDate == null || startDate.Trim() == "")
                return "";

            DateTime dt = Convert.ToDateTime(startDate);
            int dayofweek = (int)dt.DayOfWeek;
            if (dayofweek != 0)
                return "* " + dateName.ToUpper() + " should be Sunday<br>";
            return "";
        }
        public static string ValidateSixWeekCycle(string startDate, string endDate)
        {
            if (startDate == null || startDate.Trim() == "")
                return "";
            if (endDate == null || endDate.Trim() == "")
                return "";

            DateTime dt1 = Convert.ToDateTime(startDate);
            DateTime dt2 = Convert.ToDateTime(endDate);
            int dayDifference = (int)((dt2 - dt1).TotalDays);
            if (((dayDifference+1) % 42) != 0)
                return "* The cycle must be multiplier of six weeks<br>";
            return "";
        }
        public static string ValidateDatesSameMonth(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                return "";
           
            if (Convert.ToDateTime(endDate).Month != Convert.ToDateTime(startDate).Month)
            {
                return "* End Date and Start Date should be within the same month!";              
            }

            return "";
        }
        public static string ValidateDatesProperOrder(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                return "";
            if (Convert.ToDateTime(endDate) < Convert.ToDateTime(startDate))
            {
                return "* End Date should be greater than Start Date!";
            }
            return "";
        }
        public static bool IsNumber(string val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                if (!char.IsDigit(val[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static string IsInt32(string value, string fieldName)
        {
            StringBuilder sb = new StringBuilder();
           
                try
                {
                   Convert.ToInt32( value );
                }
                catch (Exception)
                {
                    sb.Append("*" + fieldName + " is not a valid number! <br>");
                }
                
            return sb.ToString();
        }

        //8-8-2016
        public static bool IsImageFile(string fileName)
        {
            Regex regex = new Regex("(.*\\.([Jj][Pp][Gg])|.*\\.([Jj][Pp][Ee][Gg])|.*\\.([Pp][Nn][Gg])|.*\\.([Gg][Ii][Ff])$)");
            return regex.IsMatch(fileName);
        }
        public static bool IsPdfFile(string fileName)
        {
            Regex regex = new Regex("(.*\\.([Pp][Dd][Ff])$)");
            return regex.IsMatch(fileName);
        }

        public static bool IsDirty(string fileName)
        {
            Regex regex = new Regex(@"(<[a-z][\s\S]*>$)");
            return regex.IsMatch(fileName);
        }
    }
}
