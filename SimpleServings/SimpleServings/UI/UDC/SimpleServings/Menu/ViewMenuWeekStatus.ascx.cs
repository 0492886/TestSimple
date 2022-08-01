using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Menu;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class ViewMenuWeekStatus : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopStatus(int menuID)
        {
            MenuWeekStatusList mwsList = MenuWeekStatus.GetMenuWeekStatusByMenuID(menuID);
            PopGrid(mwsList);
        }

        private void PopGrid(MenuWeekStatusList mwsList)
        {
            dlMenuWeekStatus.DataSource = mwsList;
            dlMenuWeekStatus.DataBind();
       }
    }
}