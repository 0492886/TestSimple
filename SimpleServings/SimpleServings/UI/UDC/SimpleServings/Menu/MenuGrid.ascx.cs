using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using SimpleServingsLibrary.Menu;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuGrid : System.Web.UI.UserControl
    {

        public void PopGrid(SimpleServingsLibrary.Menu.Menus menus)
        {
            if (menus != null)
            {
                this.lblErrorMsg.Text = "";
                this.gvMenus.DataSource = menus;
                this.gvMenus.DataBind();

                CacheMenuList(menus);
                lblCount.ForeColor = Color.Green;
                lblCount.Text = menus.Count + " Record(s) found";
            }
            else
            {
                this.gvMenus.DataSource = null;
                this.gvMenus.DataBind();
                lblCount.ForeColor = Color.Red;
                lblCount.Text = "No Record(s) found";
            }
        }

        protected void gvMenus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)(e.Row.FindControl("lblIsActive"));
                if (lbl.Text == "True")
                {
                    LinkButton l1 = (LinkButton)(e.Row.FindControl("lnkBtnRemove"));
                    l1.Text = "Delete";
                }
                else
                {
                    LinkButton l1 = (LinkButton)(e.Row.FindControl("lnkBtnRemove"));
                    l1.Text = "Restore";
                }
            }

        }
        public void ShowDeleteButton(bool showHide)
        {
            gvMenus.Columns[12].Visible = showHide;
        }

        // return the current selected sample menu for AddMenuUsignSampleMenu page
        public int getSelectedSampleMenu()
        {
            int selectedMenuID =0;
            if (gvMenus.Rows.Count > 0)
            {
                Int32.TryParse((gvMenus.Rows[0].FindControl("lblMenuID") as Label).Text, out selectedMenuID);
            }
            return selectedMenuID;

        }


        public void setCurrentSampleMenu(int menuID)
        {
            foreach (GridViewRow row in gvMenus.Rows)
            {
                if ((row.FindControl("lblMenuID") as Label).Text == menuID.ToString())
                {
                    (row.FindControl("rbSelectItem") as RadioButton).Checked = true;
 
                }
            }
 
        }

        public void HideRadioButtonColumn()
        {
            gvMenus.Columns[0].Visible = false;
 
        }

        protected void lnkBtnRemove_Click(object sender, EventArgs e)
        {

            int menuID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                menu.GetMenuByMenuID(menuID);
                bool isActive = menu.IsActive;

                if (menu.CreatedBy == staff.StaffID || staff.UserGroup == SimpleServingsLibrary.Shared.GlobalEnum.UserGroup_Addministrator) {
                    this.lblErrorMsg.Text = "";
                    if (isActive)
                    {
                            SimpleServingsLibrary.Menu.Menu.DeactivateMenu(menuID, HelpClasses.AppHelper.GetCurrentUser().StaffID);
                    }                                      
                    else
                        {
                            SimpleServingsLibrary.Menu.Menu.ReActiveMenu(menuID);
                        }

                    //SimpleServingsLibrary.Menu.Menu.DeactivateMenu(menuID,((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
                    if (Request.QueryString["MenuType"].ToString() !=null)
                        Response.Redirect("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=" + Request.QueryString["MenuType"].ToString());
                    else
                        Response.Redirect("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyMenus");
                    //if (Request["MenuType"].ToString().Trim() == "MyDrafts")
                    //    Response.Redirect("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyDrafts");
                    //else Response.Redirect("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyMenus");
                }
                else {
                    this.lblErrorMsg.ForeColor = Color.Red;
                    this.lblErrorMsg.Text = "You are not allowed to delete this menu";
                }
            }
            catch { }


        }


       private void PopMenuGrid(SimpleServingsLibrary.Menu.Menus menus)
        {
            if (menus != null)
            {
                this.gvMenus.DataSource = menus;
                this.gvMenus.DataBind();
                lblCount.ForeColor = Color.Green;
                lblCount.Text = menus.Count + " Record(s) found";
            }
            else
            {
                this.gvMenus.DataSource = null;
                this.gvMenus.DataBind();
                lblCount.ForeColor = Color.Red;
                lblCount.Text = "No Record(s) found";
            }
        }

        #region menu list sorting
        private SortDirection GetSortDirection()
        {
            if (ViewState["SortDirection"] != null)
            {
                SortDirection previousDirection = (SortDirection)ViewState["SortDirection"];

                if (previousDirection == SortDirection.Ascending)
                {
                    ViewState["SortDirection"] = SortDirection.Descending;
                    return SortDirection.Descending;
                }
                else
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
            }
            else
            {
                //return default SortDirection
                ViewState["SortDirection"] = SortDirection.Ascending;
                return SortDirection.Ascending;
            }

        }

        private bool IsSortExpressionChanged(string sortExpression)
        {
            if (ViewState["SortExpression"] != null)
            {
                if ((string)ViewState["SortExpression"] == sortExpression)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private static IComparer<SimpleServingsLibrary.Menu.Menu> GetSortComparer(string sortExpression, SimpleServingsLibrary.Menu.Menu.SortDirection direction)
        {
            if (sortExpression == "ContractType")
            {
                return SimpleServingsLibrary.Menu.Menu.GetContractTypeSortHelper(direction);
            }

            if (sortExpression == "ContractName")
            {
                return SimpleServingsLibrary.Menu.Menu.GetContractNameSortHelper(direction);
            }

            if (sortExpression == "MealType")
            {
                return SimpleServingsLibrary.Menu.Menu.GetMealTypeSortHelper(direction);
            }

            if (sortExpression == "Cycle")
            {
                return SimpleServingsLibrary.Menu.Menu.GetCycleSortHelper(direction);
            }

            if (sortExpression == "MenuStatus")
            {
                return SimpleServingsLibrary.Menu.Menu.GetMenuStatusSortHelper(direction);
            }

            if (sortExpression == "CreatedOn")
            {
                return SimpleServingsLibrary.Menu.Menu.GetCreatedOnSortHelper(direction);
            }

            if (sortExpression == "MenuName")
            {
                return SimpleServingsLibrary.Menu.Menu.GetMenuNameSortHelper(direction);
            }
            if (sortExpression == "SubmittedToDFTA")
            {
                return SimpleServingsLibrary.Menu.Menu.GetSubmittedToDFTASortHelper(direction);
            }


            return null;
        }

        private void SortGridView(string sortExpression, SortDirection direction)
        {
            IComparer<SimpleServingsLibrary.Menu.Menu> comparer;

            if (direction == SortDirection.Ascending)
            {
                comparer = GetSortComparer(sortExpression, SimpleServingsLibrary.Menu.Menu.SortDirection.Ascending);
            }
            else
            {
                comparer = GetSortComparer(sortExpression, SimpleServingsLibrary.Menu.Menu.SortDirection.Descending);
            }

            SimpleServingsLibrary.Menu.Menus menuList = GetMenuListFromCache();
            menuList.Sort(comparer);
            PopGrid(menuList);
        }

        private void CacheMenuList(SimpleServingsLibrary.Menu.Menus menuList)
        {
            Session["SortMenuList"] = menuList;
        }

        private SimpleServingsLibrary.Menu.Menus GetMenuListFromCache()
        {
            return (SimpleServingsLibrary.Menu.Menus)Session["SortMenuList"];
        }

        protected void gvMenus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMenus.PageIndex = e.NewPageIndex;
            PopMenuGrid(GetMenuListFromCache());
        }

        protected void gvMenus_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (IsSortExpressionChanged(e.SortExpression) == true)
            {
                SortGridView(e.SortExpression, SortDirection.Ascending);

                ViewState["SortDirection"] = SortDirection.Ascending;
            }
            else
            {
                SortGridView(e.SortExpression, GetSortDirection());
            }

            ViewState["SortExpression"] = e.SortExpression;
        }
        #endregion sorting


#region ViewSampleMenuGrid

        public void ViewSampleMenuGrid(bool ShowSampleMenuGrid, int userGroup, bool IsAddMenu)
        {
            if (ShowSampleMenuGrid)
            {

                gvMenus.Columns[1].Visible = false;
               // gvMenus.Columns[3].Visible = false;  //Program Type, need show
                gvMenus.Columns[4].Visible = false;
                gvMenus.Columns[6].Visible = false;   //Diet Type, don't show
                gvMenus.Columns[7].Visible = false;
                gvMenus.Columns[8].Visible = false;
                gvMenus.Columns[9].Visible = false;
                //gvMenus.Columns[10].Visible = false;
                
                if (!IsAddMenu)
                {
                    gvMenus.Columns[11].Visible = (userGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN || userGroup == SimpleServingsLibrary.Shared.UserGroup.DFTAUSER || userGroup == SimpleServingsLibrary.Shared.UserGroup.DFTASUP ? true : false);
                    
                }
                else
                {
                    gvMenus.Columns[12].Visible = false; // Delete Link
                    gvMenus.Columns[11].Visible = false; // Edit Link
                    gvMenus.Columns[0].Visible = true;   // Radio Button
                    lblCount.Visible = false;
                }

            }
    
        }
        
        public int getSelectedSampleMenuItem()
        {
            int selectedItem = 0;

            foreach (GridViewRow row in gvMenus.Rows)
            {
                if ((row.FindControl("rbSelectItem") as RadioButton).Checked)
                {
                    string id = (row.FindControl("lblMenuID") as Label).Text;

                    Int32.TryParse(id, out selectedItem);

                    //selectedItem = Convert.ToInt32(id);
 
                }
            }

            return selectedItem;
        }
#endregion






        protected void lnkBtnEdit_Click(object sender, EventArgs e)
        {
            int menuID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/UI/Page/SimpleServings/Menu/AddMenuItem.aspx?MenuID=" + menuID + "&WeekSelected=1");  

        }






    }
}