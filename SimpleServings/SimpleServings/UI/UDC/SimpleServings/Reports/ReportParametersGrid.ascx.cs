using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Reports
{
    public partial class ReportParametersGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            if (!IsPostBack)
            {

                ddlMenuID.Enabled = false;
                try
                {
                    SimpleServingsLibrary.SupplierRelationship.Contracts contracts = new SimpleServingsLibrary.SupplierRelationship.Contracts();
                    contracts = SimpleServingsLibrary.SupplierRelationship.Contract.GetContractsByStaffIDAndContractType(staff.StaffID, 0);
                    ddlContractID.DataSource = contracts;
                    ddlContractID.DataTextField = "ContractName";
                    ddlContractID.DataValueField = "ContractID";
                    ddlContractID.DataBind();
                    ddlContractID.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
                }
                catch { }
            }           

        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    //this.ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://rs8areports/ReportServer");
        //    string ReportPath = "/SimpleServings/Menu_by_Calendar_ML";
        //    //this.ReportViewer1.ServerReport.ReportPath = ReportPath;

        //    int MenuID = 0;
        //    //Int32.TryParse(tbMenuID.Text.ToString(), out MenuID);

        //    //Microsoft.Reporting.WebForms.ReportParameter[] RptParameters = new Microsoft.Reporting.WebForms.ReportParameter[1];
        //    //RptParameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("MenuID", MenuID.ToString());
        //    //this.ReportViewer1.ServerReport.SetParameters(RptParameters);
        //    //this.ReportViewer1.ServerReport.Refresh();
        //    //ReportViewer1.Visible = true;
        //    //ReportViewer1.ShowParameterPrompts = false;
        //    //ReportViewer1.Height = 800;
        //    //ReportViewer1.ShowPrintButton = true;

        //}


        public void GetMenubyCalendarParam(out int ContractID, out string Date, out List<int> MenuID, out int MealTypeID)
        {
            int contractID = 0;
            Int32.TryParse(ddlContractID.SelectedValue, out contractID);
            ContractID = contractID;

            Date = tbDate.Text;

            int mealTypeId = 0;
            Int32.TryParse(ddlMealType.SelectedValue, out mealTypeId);
            MealTypeID = mealTypeId;
            MenuID = new List<int>();
            SimpleServingsLibrary.Shared.Reports rpts = new SimpleServingsLibrary.Shared.Reports();
            rpts = (SimpleServingsLibrary.Shared.Reports)Session["cbMenuList"];
            int menuId = 0;
            foreach (ListItem item in cbMenuList.Items)
            {
                if (item.Selected == true)
                {
                    string _MenuID = rpts.Where(x => x.MenuID.ToString() == item.Value).First().MenuID.ToString();
                    Int32.TryParse(_MenuID, out menuId);
                    if (menuId != -1)
                    {
                        MenuID.Add(menuId);
                    }
                }
                
                

            }

        }

        protected void ddlContractID_SelectedIndexChanged(object sender, EventArgs e)
        {            
            int ContractID = 0;
            Int32.TryParse(ddlContractID.SelectedValue, out ContractID);

            SimpleServingsLibrary.Shared.Reports rpts = new SimpleServingsLibrary.Shared.Reports();
            SimpleServingsLibrary.Shared.Report rpt = new SimpleServingsLibrary.Shared.Report();

            rpts = SimpleServingsLibrary.Shared.Report.GetMealServedTypeIDsByContractID(ContractID);

            ddlMealType.DataSource = rpts;
            ddlMealType.DataTextField = "MealServedTypeDesc";
            ddlMealType.DataValueField = "MealServedTypeID";
            ddlMealType.DataBind();
            ddlMealType.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
            ddlMealType.Enabled = true;

            tbDate.Text = "";
            ddlMenuID.Items.Clear();

        }

        protected void ddlMealType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MealTypeID = 0;
            Int32.TryParse(ddlMealType.SelectedValue, out MealTypeID);

            string Date = tbDate.Text;
            lblErrorMsg.Text = "";
            cbMenuList.Items.Clear();
            try
            {
                if (Date == "" || Date == string.Empty)
                    throw new Exception("Please enter Year Month (YYY-MM)!!");

                int ContractID = 0;
                Int32.TryParse(ddlContractID.SelectedValue, out ContractID);
                SimpleServingsLibrary.Shared.Reports rptParams = new SimpleServingsLibrary.Shared.Reports();
                rptParams = SimpleServingsLibrary.Shared.Report.GetMenusForContractIDMealTypeDate(ContractID, Date, MealTypeID);
                Session["cbMenuList"] = rptParams;

                ddlMenuID.DataSource = rptParams;
                ddlMenuID.DataTextField = "MenuName";
                ddlMenuID.DataValueField = "MenuID";
                ddlMenuID.DataBind();
                ddlMenuID.Enabled = true;


                cbMenuList.DataSource = rptParams;
                cbMenuList.Style.Add("font-size","11px;");
                cbMenuList.DataTextField = "MenuName";
                cbMenuList.DataValueField = "MenuID";
                cbMenuList.DataBind();
                

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
                cbMenuList.DataSource = null;
                cbMenuList.DataBind();
            }

        }

        protected void cbMenuList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selMenuItem1 = "";
            string selMenuItem2 = "";
            string fDate = "";
            string lDate = "";
            DateTime menuStartDate;
            DateTime menuLastDate;
            DateTime selectedFirstDate1;
            DateTime selectedLastDate1;
            DateTime selectedFirstDate2;
            DateTime selectedLastDate2;

            SimpleServingsLibrary.Shared.Reports rpts = new SimpleServingsLibrary.Shared.Reports();
            rpts = (SimpleServingsLibrary.Shared.Reports)Session["cbMenuList"];


            try
            {
                var selitemcount = cbMenuList.Items.Cast<ListItem>().Where(x => x.Selected == true);
                if (selitemcount.Count() > 2)
                    throw new Exception("Please select only two menus!!");

                if (tbDate.Text != string.Empty && tbDate.Text != "")
                {
                    string[] selMonthYear = tbDate.Text.Split('-');

                    int year = 0;
                    Int32.TryParse(selMonthYear[0].ToString(), out year);

                    int month = 0;
                    Int32.TryParse(selMonthYear[1].ToString(), out month);

                    int daysinMonth = DateTime.DaysInMonth(year, month);
                    string selLastDayofMonth = month.ToString() + "-" + daysinMonth.ToString() + "-" + year.ToString();
                    string selFirstDayofMonth = selMonthYear[1].ToString() + "-01-" + selMonthYear[0].ToString();


                    // Get selected date range to check the overlap 
                    foreach (ListItem item in cbMenuList.Items)
                    {
                        if (item.Enabled == true && item.Selected == true)
                        {
                            if (selMenuItem1 == "")
                            {
                                selMenuItem1 = item.Value;
                            }
                            else
                            {
                                selMenuItem2 = item.Value;
                                break;
                            }
                        }
                    }

                    // Get the Date range for first selected menu
                    if (selMenuItem1 != "")
                    {
                        fDate = rpts.Where(x => x.MenuID.ToString() == selMenuItem1).First().StartDate.ToString();
                        lDate = rpts.Where(x => x.MenuID.ToString() == selMenuItem1).First().EndDate.ToString();

                        DateTime.TryParse(fDate, out menuStartDate);
                        DateTime.TryParse(lDate, out menuLastDate);

                        // Find the last day of the selected date range 
                        if (menuStartDate.Month.ToString() == month.ToString())
                        {
                            selectedFirstDate1 = menuStartDate;
                            DateTime.TryParse(selLastDayofMonth, out selectedLastDate1);
                        }
                        else if (menuLastDate.Month.ToString() == month.ToString())
                        {
                            DateTime.TryParse(selFirstDayofMonth, out selectedFirstDate1);
                            selectedLastDate1 = menuLastDate;
                        }
                        else
                        {
                            DateTime.TryParse(selFirstDayofMonth, out selectedFirstDate1);
                            DateTime.TryParse(selLastDayofMonth, out selectedLastDate1);
                        }
                    }
                    else
                    {
                        selectedFirstDate1 = DateTime.Now.AddYears(1); 
                        selectedLastDate1 = DateTime.Now.AddYears(2);
                    }

                    // Get the Date range for the second selected menu
                    if (selMenuItem2 != "")
                    {
                        fDate = rpts.Where(x => x.MenuID.ToString() == selMenuItem2).First().StartDate.ToString();
                        lDate = rpts.Where(x => x.MenuID.ToString() == selMenuItem2).First().EndDate.ToString();

                        DateTime.TryParse(fDate, out menuStartDate);
                        DateTime.TryParse(lDate, out menuLastDate);

                        if (menuStartDate.Month.ToString() == month.ToString())
                        {
                            selectedFirstDate2 = menuStartDate;
                            DateTime.TryParse(selLastDayofMonth, out selectedLastDate2);
                        }
                        else if (menuLastDate.Month.ToString() == month.ToString())
                        {
                            DateTime.TryParse(selFirstDayofMonth, out selectedFirstDate2);
                            selectedLastDate2 = menuLastDate;
                        }
                        else
                        {
                            DateTime.TryParse(selFirstDayofMonth, out selectedFirstDate2);
                            DateTime.TryParse(selLastDayofMonth, out selectedLastDate2);
                        }
                    }
                    else
                    {
                        selectedFirstDate2 = DateTime.Now.AddYears(1);
                        selectedLastDate2 = DateTime.Now.AddYears(2);
                    }

                    // Compare selected date range to the menu list date range
                    foreach (ListItem item in cbMenuList.Items)
                    {
                        if(item.Selected == false)                        
                        {
                            DateTime compareMenuStartDate;
                            DateTime compareMenuLastDate;

                            fDate = rpts.Where(x => x.MenuID.ToString() == item.Value).First().StartDate.ToString();
                            lDate = rpts.Where(x => x.MenuID.ToString() == item.Value).First().EndDate.ToString();
                            DateTime.TryParse(fDate, out compareMenuStartDate);
                            DateTime.TryParse(lDate, out compareMenuLastDate);

                            if (compareMenuStartDate <= selectedLastDate1 && selectedFirstDate1 <= compareMenuLastDate)
                            {
                                item.Enabled = false;
                            }
                            else if (compareMenuStartDate <= selectedLastDate2 && selectedFirstDate2 <= compareMenuLastDate)
                            {
                                item.Enabled = false;
                            }
                            else
                            {
                                item.Enabled = true;
                            }
                        }
                    }

                }
                else
                {
                    throw new Exception("Please enter Year Month (YYY-MM)!!");
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message; 
            }
        }

        protected void tbDate_TextChanged(object sender, EventArgs e)
        {
            if (tbDate.Text.Length == 7)
            {
                ddlMealType.ClearSelection();
                ddlMealType.Items[0].Selected = true;
                cbMenuList.Items.Clear();
 
            }
        }
    }
}