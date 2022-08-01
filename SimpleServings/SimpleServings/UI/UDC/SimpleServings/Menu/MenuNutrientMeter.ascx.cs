using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.MenuThreshold;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuNutrientMeter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopContent(int menuID, int weekInCycle)
        {
            MenuThresholds menuThresholds = MenuThreshold.GetMenuThresholdsWeekly(menuID, weekInCycle);

            rptNutrient.DataSource = menuThresholds;
            rptNutrient.DataBind();
        }
    }
}