using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using SimpleServingsLibrary.Shared;


namespace SimpleServings.UI.UDC.SimpleServings.Reports
{
    public partial class ReportGrid : System.Web.UI.UserControl
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

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void PopGrid()
        {
            try {     
                SimpleServingsLibrary.Shared.Reports reports = SimpleServingsLibrary.Shared.Report.GetAllReports();                           
                gvReport.DataSource = reports;
                gvReport.DataBind();

                lblMsg.ForeColor = Color.Green;
                lblMsg.Text = reports.Count + " Record(s) found";
            }
            catch {
                gvReport.DataSource = null;
                gvReport.DataBind();
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No Record found";
            }
        }
    }
}