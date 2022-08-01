using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Reports
{
    public partial class AddEditReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    PopDropDowns();
                    PopUserGroupData();
                    if (Request["ReportID"] != null)
                    {
                        PopReportData(Convert.ToInt32(Request["ReportID"]));                        
                    }
                }
                catch (ApplicationException ex)
                {

                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }
        }
        

        private void PopReportData(int reportID)
        {
            SimpleServingsLibrary.Shared.Report report = new SimpleServingsLibrary.Shared.Report(reportID);
            txtReportLink.Text = report.ReportLink;
            txtReportdescription.Text = report.ReportDescription;
            txtReportName.Text = report.ReportName;
        }

        private void PopDropDowns()
        {

            int userGroupID = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //(SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;                       
            if (Request["ReportID"] != null)
            {
                SimpleServingsLibrary.Shared.Report report = new SimpleServingsLibrary.Shared.Report(Convert.ToInt32(Request["ReportID"]));
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddReportType, SimpleServingsLibrary.Shared.Code.CodeTypes.ReportType, userGroupID, report.ReportType.ToString()); 
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlReportCategory, SimpleServingsLibrary.Shared.Code.CodeTypes.ReportCategory, userGroupID, report.ReportCategory.ToString()); 
            }
            else { 
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddReportType, SimpleServingsLibrary.Shared.Code.CodeTypes.ReportType, userGroupID, "0"); 
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlReportCategory, SimpleServingsLibrary.Shared.Code.CodeTypes.ReportCategory, userGroupID, "0"); 
            }
        }

        private void PopUserGroupData()
        {
            try
            {
                SimpleServingsLibrary.Shared.UserGroups userGroups = SimpleServingsLibrary.Shared.UserGroup.GetAllUserGroup();
                cblUserGroup.DataSource = userGroups;
                cblUserGroup.DataValueField = "UserGroupID";
                cblUserGroup.DataTextField = "UserGroupName";
                cblUserGroup.DataBind();
            }
            catch { }
            try
            {
                if (Request["ReportID"] != null)
                {
                    SimpleServingsLibrary.Shared.ReportIncludes reportIncludes = SimpleServingsLibrary.Shared.ReportInclude.GetReportIncludeByReportID(Convert.ToInt32(Request["ReportID"]));

                    foreach (SimpleServingsLibrary.Shared.ReportInclude reportInclude in reportIncludes)
                    {
                        cblUserGroup.Items.FindByValue(reportInclude.UserGroupID.ToString()).Selected = true;
                    }
                }
            }
            catch {
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

        private void GetValuesFromControls(ref SimpleServingsLibrary.Shared.Report report)
        {
            
            report.ReportType = Convert.ToInt32(ddReportType.SelectedValue);
            report.ReportCategory = Convert.ToInt32(ddlReportCategory.SelectedValue);
            report.ReportLink = txtReportLink.Text;
            report.ReportDescription = txtReportdescription.Text;
            report.ReportName = txtReportName.Text;
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            report.CreatedBy = staff.StaffID;
        }

       
        protected void lnkBtnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cblUserGroup.Items.Count; i++)
            {
                cblUserGroup.Items[i].Selected = true;
            }
        }

        protected void lnkBtnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cblUserGroup.Items.Count; i++)
            {
                cblUserGroup.Items[i].Selected = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isItemSelected())
            {
                if (Request["ReportID"] != null)
                {
                    EditReport();
                }
                else 
                {
                    int reportID = AddReport();
                }
            }
            else {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "You need to select at least one usergroup";
                lblMsg.Visible = true;
            }
        }
        private bool isItemSelected()
        {
            foreach (ListItem itm in cblUserGroup.Items)
            {
                if (itm.Selected)
                {
                    return true;
                }
            }
            return false;
        }
        private void EditReport()
        {
            try
            {
                int reportID = Convert.ToInt32(Request["ReportID"]);
                SimpleServingsLibrary.Shared.Report report = new SimpleServingsLibrary.Shared.Report(reportID);
                GetValuesFromControls(ref report);
                bool edited = report.EditReport();
                if (edited)
                {
                    try
                    {
                        SimpleServingsLibrary.Shared.ReportInclude.DeleteReportIncludesByReportID(reportID);
                    }
                    catch { }
                    foreach (ListItem itm in cblUserGroup.Items)
                    {
                        if (itm.Selected)
                        {
                            SimpleServingsLibrary.Shared.ReportInclude reportInclude = new SimpleServingsLibrary.Shared.ReportInclude();
                            reportInclude.UserGroupID = Convert.ToInt32(itm.Value);
                            reportInclude.ReportID = reportID;
                            reportInclude.CreatedBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
                            reportInclude.AddReportInlcude();
                        }
                    }
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "changes successfully saved";
                    lblMsg.Visible = true;
                    Response.Redirect("~/UI/Page/SimpleServings/Reports/reports.aspx");
                }
                else {
                }
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
        }

        private int AddReport()
        {
            int reportID = 0;
            try
            {
                SimpleServingsLibrary.Shared.Report report = new SimpleServingsLibrary.Shared.Report();
                GetValuesFromControls(ref report);
                reportID = report.AddReport();

                try
                {
                    SimpleServingsLibrary.Shared.ReportInclude.DeleteReportIncludesByReportID(reportID);
                }
                catch { }
                foreach (ListItem itm in cblUserGroup.Items)
                {
                    if (itm.Selected)
                    {
                        SimpleServingsLibrary.Shared.ReportInclude reportInclude = new SimpleServingsLibrary.Shared.ReportInclude();
                        reportInclude.UserGroupID = Convert.ToInt32(itm.Value);
                        reportInclude.ReportID = reportID;
                        reportInclude.CreatedBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
                        reportInclude.AddReportInlcude();
                    }
                }
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Report successfully saved";
                lblMsg.Visible = true;
                Response.Redirect("~/UI/Page/SimpleServings/Reports/reports.aspx");
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
            return reportID;
        }

    }
}