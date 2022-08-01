using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.MenuThreshold;

namespace SimpleServings.UI.Page.SimpleServings.Menu
{
    public partial class MenuThresholdTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            int menuID = Convert.ToInt32(txtMenuID.Text);
            int weekCycleID = Convert.ToInt32(txtWeekCycle.Text);

            try
            {
                ViewMenuWeekStatus1.PopStatus(menuID);
                MenuThreshold.ValidateThreshold(menuID, weekCycleID);
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
        }
    }
}