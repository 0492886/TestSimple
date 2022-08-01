using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Reports
{
    public partial class ucNutritionFactLabelsDailyParameter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetNutritionFactLabelsDailyReportParameter(out int MenuID, out string Date)
        {
            Int32.TryParse(tbMenuID.Text, out MenuID);
            Date = tbDate.Text; 
        }
    }
}