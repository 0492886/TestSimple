using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleServingsLibrary.RecipeSupplement
{
    public class Symbol
    {
        private const string degreeHtml = "&#176;";
        private const string lessOrEqualHtml = "&#8804;";
        private const string greaterOrEqualHtml = "&#8805;";

        private const string lessOrEqualSymbol = "≤";
        private const string greaterOrEqualSymbol = "≥";

        private const string lessOrEqualSyntax = "<=";
        private const string greaterOrEqualSyntax = ">=";


        public static string FormatToSyntax(string value)
        {
            return value.Replace(lessOrEqualSymbol, lessOrEqualSyntax).Replace(greaterOrEqualSymbol, greaterOrEqualSyntax);
        }

        public static string FormatToHtml(string value)
        {
            return FormatToSyntax(value).Replace(lessOrEqualSyntax, lessOrEqualHtml).Replace(greaterOrEqualSyntax, greaterOrEqualHtml);
        }
    }
}
