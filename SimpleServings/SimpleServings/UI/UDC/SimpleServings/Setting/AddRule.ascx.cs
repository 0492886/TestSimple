using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.CaseClient
{
    public partial class AddRule : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                }

                catch (ApplicationException ex)
                {

                    lblMsg.ForeColor = System.Drawing.Color.Red;

                    lblMsg.Text = ex.Message;

                }
            }
           
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }


        protected void btnAddRule_Click(object sender, EventArgs e)
        {
            SaveRule();
        }

        private void GetValuesFromControls(ref SimpleServingsLibrary.Shared.Rule rule)
        {
            rule.RuleDescription = txtRuleDescription.Text;
            rule.CustomMessage = txtCustomMessage.Text;
            rule.IsStaffSpecific = cbStaffSpecific.Checked;
            rule.SqlStatement = txtSqlStatement.Text;
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            rule.CreatedBy = staff.StaffID;
        }

        private int SaveRule()
        {
            int ruleID = 0;
            try
            {
                SimpleServingsLibrary.Shared.Rule rule = new SimpleServingsLibrary.Shared.Rule();
                GetValuesFromControls(ref rule);
                ruleID = rule.AddRule();
                lblSummary.ForeColor = System.Drawing.Color.SteelBlue;
                lblSummary.Text = "Rule successfully added";
                lblSummary.Visible = true;
            }
            catch (Exception ex)
            {
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Text = ex.Message;
                lblSummary.Visible = true;
            }
            return ruleID;
        }
    }
}