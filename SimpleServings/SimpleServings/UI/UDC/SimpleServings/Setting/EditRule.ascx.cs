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

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class EditRule : System.Web.UI.UserControl
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
                if (Request["RuleID"] != null)
                {
                    int ruleID = Convert.ToInt32(Request["RuleID"].ToString());
                    PopRule(ruleID);
                }

            }
            

        }

     
        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void PopRule(int ruleID)
        {
            try
            {
                SimpleServingsLibrary.Shared.Rule rule = new SimpleServingsLibrary.Shared.Rule(ruleID);
                lblRuleID.Text = ruleID.ToString();
                txtRuleDescription.Text = rule.RuleDescription;
                txtCustomMessage.Text = rule.CustomMessage;
                //cbClientSpecific.Checked = rule.IsClientSpecific;
                cbStaffSpecific.Checked = rule.IsStaffSpecific;
                txtSqlStatement.Text = rule.SqlStatement;
                cbActive.Checked = rule.IsActive;
            }
            catch (Exception ex)
            {
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Text = ex.Message;
                lblSummary.Visible = true;
            }


        }

        protected void btnAddRule_Click(object sender, EventArgs e)
        {
            UpdateRule();
        }

        private void GetValuesFromControls(ref SimpleServingsLibrary.Shared.Rule rule)
        {
            rule.RuleDescription = txtRuleDescription.Text;
            rule.CustomMessage = txtCustomMessage.Text;
            //rule.IsClientSpecific = cbClientSpecific.Checked;
            rule.IsStaffSpecific = cbStaffSpecific.Checked;
            rule.SqlStatement = txtSqlStatement.Text;
            rule.IsActive = cbActive.Checked;
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            rule.CreatedBy = staff.StaffID;
        }

        private int UpdateRule()
        {
            int ruleID = 0;
            try
            {
                SimpleServingsLibrary.Shared.Rule rule = new SimpleServingsLibrary.Shared.Rule(Convert.ToInt32(Request["RuleID"].ToString()));
                GetValuesFromControls(ref rule);
                rule.EditRule();
                lblSummary.ForeColor = System.Drawing.Color.SteelBlue;
                lblSummary.Text = "Rule successfully updated";
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