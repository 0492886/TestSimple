using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuStatusHistoryGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopMenuStatusGrid(SimpleServingsLibrary.Menu.MenuStatusHistories menustatushistories)
        {
            if (menustatushistories != null)
            {
                this.gvMenusHistory.DataSource = menustatushistories;
                this.gvMenusHistory.DataBind();
                lblCount.ForeColor = Color.Green;
                lblCount.Text = menustatushistories.Count + " Record(s) found";
            }
            else
            {
                this.gvMenusHistory.DataSource = null;
                this.gvMenusHistory.DataBind();
                lblCount.ForeColor = Color.Red;
                lblCount.Text = "No Record(s) found";
            }
        }
    }
}