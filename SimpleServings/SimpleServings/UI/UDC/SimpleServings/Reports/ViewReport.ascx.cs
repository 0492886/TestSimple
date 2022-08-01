using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Reports
{
    public partial class ViewReport : System.Web.UI.UserControl
    {

        string reportID;
        protected void Page_Load(object sender, EventArgs e)
        {

            ApplyPermissions();

            lblErrorMsg.Text = "";
            if (!IsPostBack)
            {
                try
                {
                    reportID = Request["reportID"].ToString();
                    lblErrorMsg.Text = "";
                    int rptID = 0;
                    Int32.TryParse(reportID, out rptID);

                    SimpleServingsLibrary.Shared.Report report = new SimpleServingsLibrary.Shared.Report(rptID);
                    lblReportName.Text = report.ReportName;

                    if (reportID == "6")
                    {
                        uc1ReportParameter.Visible = true;

                    }
                    else if (reportID == "8")
                    {
                        divreportID6.Visible = true;
                    }
                    else if (reportID == "10" || reportID == "12" || reportID == "13" || reportID == "16" || reportID == "17" || reportID == "18" || reportID == "19")
                    {
                        ucDailyMenuParameter.Visible = true; 
 
                    }
                    else if(reportID == "11")
                    {
                        ucNutritionFactLabelsDailyParameter.Visible = true;

                    }
                    else if (reportID == "22")
                    {
                        ucCountMenusWithCycleIdByRecipeIDParameter.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.Message;
                }
            }
        }
        
        
        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ReportModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int ContractID = 0;
            string Date;
            int MenuID = 0;
            string ReportPath = "";
            Microsoft.Reporting.WebForms.ReportParameter[] RptParameters = null;
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                string acctUserName = "SSRSuser";
                string acctPassword = "Aging@123";
                string acctDomain = "DFTA";
                IReportServerCredentials irsc = new CustomReportCredentials(acctUserName, acctPassword, acctDomain);
                ReportViewer1.ServerReport.ReportServerCredentials = irsc;



                this.ReportViewer1.ServerReport.ReportServerUrl =  new Uri(System.Configuration.ConfigurationManager.AppSettings["ReportServerURL"]);

                reportID = Request["reportID"].ToString();
                

                if (reportID == "8")
                {

                    ReportPath = "/SimpleServings/Menu_Item_by_MenuID_ML";
                    this.ReportViewer1.ServerReport.ReportPath = ReportPath;

                    
                    Int32.TryParse(tbMenuID.Text.ToString(), out MenuID);

                    RptParameters = new Microsoft.Reporting.WebForms.ReportParameter[1];
                    RptParameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("MenuID", MenuID.ToString());
                    this.ReportViewer1.ServerReport.SetParameters(RptParameters);

                }
                else if (reportID == "6")
                {

                    ReportPath = "/SimpleServings/Menu_by_Calendar_ML_Dev_WithMenuID";
                    this.ReportViewer1.ServerReport.ReportPath = ReportPath;


                    List<int> ListMenuID = new List<int>();
                    int MealTypeID = 0;

                    uc1ReportParameter.GetMenubyCalendarParam(out ContractID, out Date, out ListMenuID, out MealTypeID);

                    if (Date == null || Date == string.Empty || ContractID == 0 || ListMenuID.Count == 0 || MealTypeID == 0)
                    {
                        throw new Exception("Please submit all parameters to generate then report!!");                        
                    }

                    System.Text.StringBuilder str = new System.Text.StringBuilder();

                    foreach (int i in ListMenuID)
                    {
                        str.Append(i.ToString());
                        str.Append(",");
                    }
                    str.Remove(str.Length - 1, 1);

                    RptParameters = new Microsoft.Reporting.WebForms.ReportParameter[5]; 
                    RptParameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("staffID", staff.StaffID.ToString());
                    RptParameters[1] = new Microsoft.Reporting.WebForms.ReportParameter("ContractID", ContractID.ToString());
                    RptParameters[2] = new Microsoft.Reporting.WebForms.ReportParameter("YearMonth", Date.ToString());                    
                    RptParameters[3] = new Microsoft.Reporting.WebForms.ReportParameter("MealServedTypeID", MealTypeID.ToString());                    
                    RptParameters[4] = new Microsoft.Reporting.WebForms.ReportParameter("MenuID", str.ToString());
                    this.ReportViewer1.ServerReport.SetParameters(RptParameters);
                }
                else if (reportID == "10" || reportID == "12" || reportID == "13" || reportID == "16" || reportID == "17" || reportID == "19")
                {
                    if (reportID == "10")
                    {
                        ReportPath = "/SimpleServings/Menu_Today_ML_NEW";
                    }
                    else if (reportID == "12")
                    {
                        ReportPath = "/SimpleServings/Nutrient_By_Day_NP_NEW";
                    }
                    else if (reportID == "13")
                    {
                        ReportPath = "/SimpleServings/Nutrient_By_Week_NP_NEW";
                    }
                    else if (reportID == "16")
                    {
                        ReportPath = "/SimpleServings/Menu_Today_Recipe_ML_NEW";
 
                    }
                    else if (reportID == "17")
                    {
                        ReportPath = "/SimpleServings/Menu_by_Week_ML_NEW"; 
                    }
                    else if (reportID == "19")
                    {
                        ReportPath = "/SimpleServings/Menu_label_by_staffID_Inputdate_ML_NEW";  
                    }
                    
                    this.ReportViewer1.ServerReport.ReportPath = ReportPath;
                    ucDailyMenuParameter.GetDailyMenuReportParameters(out ContractID, out MenuID,out Date);

                    RptParameters = new Microsoft.Reporting.WebForms.ReportParameter[4];
                    RptParameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("staffID", staff.StaffID.ToString());
                    RptParameters[1] = new Microsoft.Reporting.WebForms.ReportParameter("ContractID", ContractID.ToString());
                    RptParameters[2] = new Microsoft.Reporting.WebForms.ReportParameter("MenuID", MenuID.ToString());
                    RptParameters[3] = new Microsoft.Reporting.WebForms.ReportParameter("InputDte", Date);
                    
                }
                else if (reportID == "18")
                {
                    ReportPath = "/SimpleServings/Menu_Cycle_by_StaffID_ML_NEW";
                    this.ReportViewer1.ServerReport.ReportPath = ReportPath;
                    ucDailyMenuParameter.GetDailyMenuReportParameters(out ContractID, out MenuID, out Date);

                    RptParameters = new Microsoft.Reporting.WebForms.ReportParameter[3];
                    RptParameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("staffID", staff.StaffID.ToString());
                    RptParameters[1] = new Microsoft.Reporting.WebForms.ReportParameter("ContractID", ContractID.ToString());
                    RptParameters[2] = new Microsoft.Reporting.WebForms.ReportParameter("MenuID", MenuID.ToString());
 
                }
                else if (reportID == "11")
                {
                    ReportPath = "/SimpleServings/Menu_label_by_Inputdate_ML";
                    this.ReportViewer1.ServerReport.ReportPath = ReportPath;
                    ucNutritionFactLabelsDailyParameter.GetNutritionFactLabelsDailyReportParameter(out MenuID, out Date);
                    RptParameters = new Microsoft.Reporting.WebForms.ReportParameter[2];
                    RptParameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("MenuID", MenuID.ToString());
                    RptParameters[1] = new Microsoft.Reporting.WebForms.ReportParameter("InputDte", Date);
                }
                else if (reportID == "22")
                {
                    int RecipeID =0;
                    int RecipeView = 0;
                    int CycleID = 0;
                    DateTime StartDate;
                    DateTime EndDate;
                    ReportPath = "/SimpleServings/CountMenusWithCycleId_By_RecipeID_NEW";
                    this.ReportViewer1.ServerReport.ReportPath = ReportPath;
                    ucCountMenusWithCycleIdByRecipeIDParameter.GetReportParameters(out RecipeID, out RecipeView, out CycleID, out StartDate, out EndDate);
                    RptParameters = new Microsoft.Reporting.WebForms.ReportParameter[5];
                    RptParameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("RecipeID", RecipeID.ToString());
                    RptParameters[1] = new Microsoft.Reporting.WebForms.ReportParameter("RecipeView", RecipeView.ToString());
                    RptParameters[2] = new Microsoft.Reporting.WebForms.ReportParameter("CycleID", CycleID.ToString());
                    RptParameters[3] = new Microsoft.Reporting.WebForms.ReportParameter("StartDate", StartDate.ToString());
                    RptParameters[4] = new Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate.ToString());


                }
                

                this.ReportViewer1.ServerReport.SetParameters(RptParameters);
                ReportViewer1.Visible = true;
                //ReportViewer1.Height = 800;
                ReportViewer1.ShowPrintButton = true;
                this.ReportViewer1.ServerReport.Refresh();

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message; 
            }
        }
    }
}