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
    public partial class RuleGrid : System.Web.UI.UserControl
    {
        public bool ShowCheckBoxes
        {
            set { gvRules.Columns[0].Visible = value; }
        }

       
       
        protected void Page_Load(object sender, EventArgs e)
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

        public void PopGrid(SimpleServingsLibrary.Shared.Rules rules, string msg)
        {
           
             if (rules != null)
             {
                this.gvRules.DataSource = rules;
                this.gvRules.DataBind();
                this.lblCount.ForeColor = System.Drawing.Color.SteelBlue;
                this.lblCount.Text = string.Format("{0} rule(s) found", rules.Count);
                lblMsg.Text = msg;
            }
            else
            {
                this.gvRules.DataSource = null;
                this.gvRules.DataBind();
                this.lblCount.ForeColor = System.Drawing.Color.Red;
                this.lblCount.Text = "No rules found";
            }
        }

        public ArrayList GetSelectedRules()
        {
            ArrayList ruleIDs = new ArrayList();
            string ruleID;
            foreach (GridViewRow row in this.gvRules.Rows)
            {
                if (row.FindControl("cbSelected") != null)
                {
                    if (((CheckBox)row.FindControl("cbSelected")).Checked)
                    {
                        ruleID = ((Label)row.FindControl("lblRuleID")).Text;
                        if (!ruleIDs.Contains(ruleID))
                            ruleIDs.Add(ruleID);
                    }
                }
            }
            return ruleIDs;
        }

        public void SelectRules(SimpleServingsLibrary.Shared.Rules rules)
        {
            foreach (SimpleServingsLibrary.Shared.Rule rule in rules)
            {
                foreach (GridViewRow row in this.gvRules.Rows)
                {
                    if (rule.RuleID == Convert.ToInt32(((Label)row.FindControl("lblRuleID")).Text))
                    {
                        ((CheckBox)row.FindControl("cbSelected")).Checked = true;
                        break;
                    }
                    
                }
            }

        }
    }
}