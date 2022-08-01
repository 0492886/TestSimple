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
    public partial class AssignRules : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
            }
            catch (ApplicationException ex)
            {
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Text = ex.Message;
            }
            if (!Page.IsPostBack)
            {
                PopDropDown();
                RuleGrid1.PopGrid(SimpleServingsLibrary.Shared.Rule.GetAllRules(false), "");
                RuleGrid1.ShowCheckBoxes = true;
            }
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void PopDropDown()
        {
            try
            {
                ddlCodeType.DataSource = SimpleServingsLibrary.Shared.Code.GetAllCodeType();
                ddlCodeType.DataTextField = "CodeType";
                ddlCodeType.DataBind();
                ddlCodeType.Items.Insert(0, new ListItem("[Select]", "0"));
                ddlCode.Items.Insert(0, new ListItem("[Select]", "0"));
              
            }
            catch{}
            
        }

        

        private void PopCode(string codeType)
        {
            try
            {
                int userGroup = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
                ddlCode.DataSource = SimpleServingsLibrary.Shared.Code.GetCodesByTypeAndUserGroup((Code.CodeTypes)Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), codeType), userGroup);
                ddlCode.DataValueField = "CodeID";
                ddlCode.DataTextField = "CodeDescription";
                ddlCode.DataBind();
            }
            catch { }
        }

        protected void ddlCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopCode(ddlCodeType.SelectedItem.ToString());
        }

        protected void btnAssignRules_Click(object sender, EventArgs e)
        {
            try
            {
                int codeID = Convert.ToInt32(ddlCode.SelectedValue);
                ArrayList ruleIDs = RuleGrid1.GetSelectedRules();
                if (ruleIDs != null && ruleIDs.Count > 0)
                {
                    SimpleServingsLibrary.Shared.RuleCodeAssociation ruleCode = new SimpleServingsLibrary.Shared.RuleCodeAssociation();
                    foreach (object ruleID in ruleIDs)
                    {
                        ruleCode.CodeID = codeID;
                        ruleCode.RuleID = Convert.ToInt32(ruleID);
                        ruleCode.CreatedBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
                        ruleCode.AddRuleCodeAssociation();
                    }
                }
                lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
                lblMsg.Text = "Rule(s) successfully assigned.";

            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }


        }

        
    }
}