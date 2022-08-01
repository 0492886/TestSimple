using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.Page.SimpleServings.Menu
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                int menuID = 0;
                int option = 0;
                if (Request["option"] != null) Int32.TryParse(Request["option"].ToString(), out option);
                if (Request["MenuID"] != null)
                {
                    Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                    lblMenuID.Text = menuID.ToString();                    
                    ConvertToExcelOrWord(menuID,option);                    
                }         
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        public void PopGrid(GridView gv,int menuID, int week)
        {
            try
            {
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                menu.GetMenuByMenuID(menuID);
                
                SimpleServingsLibrary.Menu.MenuItemTypes menuITypes =
                    SimpleServingsLibrary.Menu.MenuItemType.GetAllMenuItemTypes(menu.MealServedTypeID);
                gv.DataSource = menuITypes;
                gv.DataBind();
                PopDays(gv);
            }
            catch
            {
                gv.DataSource = null;
                gv.DataBind();
            }
            PopRepeaters(gv,week);
        }

        private void PopDays(GridView gv)
        {
            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            SimpleServingsLibrary.Menu.MenuDays menuDays = new SimpleServingsLibrary.Menu.MenuDays();
            try
            {
                menuDays = SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
            }
            catch { }
            if (menuDays != null && menuDays.Count > 0)
            {
                for (int i = 0; i < menuDays.Count; i++)
                {
                    gv.HeaderRow.Cells[i + 2].Text = menuDays[i].DayName;

                }
                if (menuDays.Count < 7)
                {
                    for (int i = menuDays.Count; i < 7; i++)
                    {
                        gv.Columns[i + 2].Visible = false;
                    }
                }
            }
        }
        private void PopRepeaters(GridView gv, int week)
        {
            int menuID = 0;
            Int32.TryParse(lblMenuID.Text, out menuID);
            SimpleServingsLibrary.Menu.MenuDays menuDays = new SimpleServingsLibrary.Menu.MenuDays();
            try
            {
                menuDays = SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);
            }
            catch { }
            
            foreach (GridViewRow row in gv.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label lblMenuItemTypeID = row.FindControl("lblMenuItemTypeID") as Label;
                    int menuItemTypeID = 0;
                    Int32.TryParse(lblMenuItemTypeID.Text, out menuItemTypeID);

                    for (int i = 0; i < menuDays.Count; i++)
                    {
                        Repeater rp = new Repeater();
                        try
                        {
                            string rpName = "rpDay" + (i + 1);
                            rp = row.FindControl(rpName) as Repeater;
                            SimpleServingsLibrary.Menu.MenuItems menuItems = new SimpleServingsLibrary.Menu.MenuItems();

                            menuItems = SimpleServingsLibrary.Menu.MenuItem.GetMenuItemsByMenuAndItemTypeAndWeekAndDay(menuID, menuItemTypeID, week, menuDays[i].DayOfWeekID);
                            rp.DataSource = menuItems;
                            rp.DataBind();

                        }
                        catch
                        {
                            rp.DataSource = null;
                            rp.DataBind();
                        }
                       
                    }
                }
            }
        }

        private void ConvertToExcelOrWord(int menuID, int option)
        {
            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            String menuName = "", programType = "", mealType = "", cycle = "", startDate = "", endDate = "", contractName="";
            try
            {
                menu.GetMenuByMenuID(menuID);
                menuName = menu.MenuName;
                programType = menu.ContractTypeName;
                mealType = menu.MealServedTypeIDText; 
                cycle = menu.CycleIDText; 
                startDate = menu.StartDate; 
                endDate = menu.EndDate;
                contractName = menu.ContractName;
            }
            catch { }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            if (option == 1)
            {
                Response.AddHeader("content-disposition", "attachment;filename=" + menuName + ".doc");
                Response.ContentType = "application/vnd.ms-word ";
            }
            else
            {
                Response.AddHeader("content-disposition", "attachment;filename=" + menuName + ".xls");                
                Response.ContentType = "application/vnd.ms-excel";
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }

            Response.ContentEncoding = System.Text.Encoding.Default;   
            this.EnableViewState = false;

            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            Table tb = new Table();

            for (int week = 1; week <= 6; week++)
            {
                string gvName = "gvMenuItems" + week;
                GridView gv = FindControl(gvName) as GridView;
                PopGrid(gv,menuID, week);

                TableRow trHeader = new TableRow();
                TableCell cellHeader = new TableCell();
                cellHeader.Text = menuName + " | " + contractName + " | " + programType + " | " + mealType + " | " + cycle + " | From: " + startDate + "  To: " + endDate;
                //cellHeader.ForeColor = System.Drawing.Color.Orange;
                cellHeader.Font.Bold = true;
                trHeader.Cells.Add(cellHeader);

                TableRow trWeek = new TableRow();
                TableCell cellWeek = new TableCell();
                cellWeek.Text = "Week: " + week;
                cellWeek.Font.Bold = true;
                trWeek.Cells.Add(cellWeek);

                TableRow trGrid = new TableRow();
                TableCell cellGrid = new TableCell();
                cellGrid.Controls.Add(gv);
                trGrid.Cells.Add(cellGrid);
                trGrid.Height = Unit.Pixel(50);
                trGrid.Width = Unit.Pixel(65);
                for (int i = 1; i <= 4; i++)
                {
                    TableRow trLineBrk = new TableRow();
                    TableCell cellLineBrk = new TableCell();
                    cellLineBrk.Text = Environment.NewLine;
                    trLineBrk.Cells.Add(cellLineBrk);
                    tb.Rows.Add(trLineBrk);
                }

                tb.Rows.Add(trHeader);
                tb.Rows.Add(trWeek);
                tb.Rows.Add(trGrid);
        
            }

            tb.RenderControl(oHtmlTextWriter);   
                
            Response.Output.Write(oStringWriter.ToString());
            Response.Flush();
            Response.End();
             
        }

    }
}