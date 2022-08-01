using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Menu;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuItemGridChangeHistory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopMenuItemHistory(int menuID)
        {
            MenuItemGridChangeHistorys MenuItemLog = new MenuItemGridChangeHistorys();
            try
            {
                MenuItemLog = SimpleServingsLibrary.Menu.MenuItemGridChangeHistory.GetMenuItemGridChangeHistorysByMenuID(menuID);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                gvMenuItemGridHistory.DataSource = null;
                gvMenuItemGridHistory.DataBind();

 
            }
            if (MenuItemLog.Count > 0)
            {
                gvMenuItemGridHistory.DataSource = MenuItemLog;
                gvMenuItemGridHistory.DataBind();
                lblMsg.Text = MenuItemLog.Count.ToString() + " Record(s) found";
            }
            else
            {
                gvMenuItemGridHistory.DataSource = null;
                gvMenuItemGridHistory.DataBind();


            }

 
        }



    }
}