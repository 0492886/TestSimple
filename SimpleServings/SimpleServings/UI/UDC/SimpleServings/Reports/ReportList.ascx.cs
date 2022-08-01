using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Reports
{
    public partial class ReportList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (!IsPostBack) 
            {
                try
                {
                    ApplyPermissions();
                    PopGrid();
                }
                catch (ApplicationException ex)
                {
                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
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


        private void PopGrid()
        {
            try {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();

                SimpleServingsLibrary.Shared.Reports reports = SimpleServingsLibrary.Shared.Report.GetReportsByUserGroup(staff.UserGroup);
                
                //SimpleServingsLibrary.Shared.Reports reports = SimpleServingsLibrary.Shared.Report.GetAllReports();
                #region conditional logic for admin related reports
                //rpReport.DataSource = (!staff.IsAdmin) ? reports.Where(r => r.ReportType != GlobalEnum.ReportType_Admin_Related) : reports; 
                #endregion

                rpReport.DataSource = reports;
                rpReport.DataBind();

                lblMsg.ForeColor = Color.Green;
                lblMsg.Text = reports.Count + " Record(s) found";
                if (SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ReportModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
                {
                    ShowEditButton = true;
                    lnkBAddReport.Visible = true;
                }
            }
            catch {
                rpReport.DataSource = null;
                rpReport.DataBind();
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No Record found";
            }
        }
       
        private bool ShowEditButton
        {
            set
            {
                foreach (RepeaterItem item in rpReport.Items)
                    (item.FindControl("lnkbEdit")).Visible = value;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {           
            Response.Redirect("~/UI/Page/SimpleServings/Reports/AddEditReport.aspx?ReportID=" + ((LinkButton)sender).CommandArgument);            
        }

        protected void rpReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label categoryLabel = (Label)e.Item.FindControl("lblReportCategory");
            string strval = categoryLabel.Text;
            string category = (string)ViewState["category"];
            if (category == strval)
            {
                categoryLabel.Visible = false;
                categoryLabel.Text = string.Empty;
            }
            else
            {
                category = strval;
                ViewState["category"] = category;
                categoryLabel.Visible = true;
                categoryLabel.Text = category;
            }
        }

        protected void lnkbHyperlink_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            
            int reportID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            SimpleServingsLibrary.Shared.Report report = new SimpleServingsLibrary.Shared.Report(reportID);
            string url="";
            //if requires staff id do the following
            if (report.ReportCategory == GlobalEnum.ReportCategory_Staff_Related)
                url = string.Format("{0}&staffID={1}",report.ReportLink, staff.StaffID);
            else url = string.Format("{0}",report.ReportLink);
            //otherwise
            //url = ((LinkButton)sender).CommandArgument;


            //if (reportID == 22)
            //{
            //    Response.Redirect(url);                
            //}
            //else
            //{
                Response.Redirect("~/UI/Page/SimpleServings/Reports/ViewReport.aspx?reportID=" + reportID.ToString());
            //}
            
           
        }


        protected void lnkBAddReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/SimpleServings/Reports/AddEditReport.aspx");
        }

       
    }
}