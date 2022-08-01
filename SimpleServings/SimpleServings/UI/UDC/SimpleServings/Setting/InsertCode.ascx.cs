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
    public partial class InsertCode : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = String.Empty;
            try
            {
                ApplyPermissions();
            }
            catch (ApplicationException ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
            if (!Page.IsPostBack)
            {
                if (Request["CodeType"] != null)
                {
                    PopCodeData(Request["CodeType"].ToString());
                    if (Request["CodeType"] == "Tag")  //Mandy add
                    {
                        ddlDependsOnType.SelectedValue = "Categories";
                        PopDependsOn("Categories");
                    }
                }
                PopRules();
            }
        }

        private void PopRules()
        {
            try
            {
                SimpleServingsLibrary.Shared.Rules rules = SimpleServingsLibrary.Shared.Rule.GetAllRules(false);
                RuleGrid1.PopGrid(rules, "");
                RuleGrid1.ShowCheckBoxes = true;
            }
            catch
            {
                RuleGrid1.PopGrid(null, "");
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
        #region public properties
        public string Msg
        {
            get { return lblMsg.Text; }
            set { lblMsg.Text = value; }
        }
        public string CodeValue
        {
            get { return txtCodeValue.Text; }
            set { txtCodeValue.Text = value; }
        }
        public string Comment
        {
            get { return txtComment.Text; }
            set { txtComment.Text = value; }
        }
        public ArrayList DependsOn
        {
            get 
            {
                ArrayList codes = new ArrayList();
                foreach (ListItem item in cbDependsOnCode.Items)
                {
                    if (item.Selected == true) codes.Add(item.Value);
                }
               return codes; 
            }
        }
        public string DependsOnType
        { get { return ddlDependsOnType.SelectedItem.ToString(); } }
        public string CodeType
        { get { return ddlCodeType.SelectedItem.ToString(); } }
        public int CreatedBy
        { get { return Convert.ToInt32(lblCreatedBy.Text); } }
        #endregion
        public void PopCodeData(string codeType)
        {
            lblMsg.Text = "";
            txtComment.Text = "";
            txtCodeValue.Text = "";
            lblCreatedBy.Text = HelpClasses.AppHelper.GetCurrentUser().StaffID.ToString(); //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID.ToString();
            try
            {
                lblCreatedByText.Text = SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(Convert.ToInt32(lblCreatedBy.Text));
            }
            catch { }
            try
            {
                ddlCodeType.DataSource = SimpleServingsLibrary.Shared.Code.GetAllCodeType();
                ddlCodeType.DataTextField = "CodeType";
                ddlCodeType.DataBind();
                ddlCodeType.Items.FindByValue(codeType).Selected = true;
            }
            catch { }

            try
            {
                ddlDependsOnType.DataSource = SimpleServingsLibrary.Shared.Code.GetAllCodeType();
                ddlDependsOnType.DataTextField = "CodeType";
                ddlDependsOnType.DataBind();
                ddlDependsOnType.Items.Insert(0, new ListItem("[Select]", "0"));
            }
            catch { }
            //PopDependsOn();
        }

        private void PopDependsOn()
        {
            try
            {
                SimpleServingsLibrary.Shared.Code.CodeTypes deCodeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), ddlCodeType.SelectedItem.ToString());
                cbDependsOnCode.DataSource = SimpleServingsLibrary.Shared.Code.GetCodesByUserGroupCodes();
                cbDependsOnCode.DataValueField = "CodeID";
                cbDependsOnCode.DataTextField = "CodeDescription";
                cbDependsOnCode.DataBind();
            }
            catch { }
        }

        protected void ddlCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codeType = ddlCodeType.SelectedValue.ToString();
            if (codeType == "Tag")
            {
                ddlDependsOnType.SelectedValue = "Categories";
                PopDependsOn("Categories");
            }
            
        }

        protected void ddlDependsOnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopDependsOn(ddlDependsOnType.SelectedItem.ToString());
        }

        private void PopDependsOn(string codeType)
        {
            try
            {
                int userGroup = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
                cbDependsOnCode.DataSource = SimpleServingsLibrary.Shared.Code.GetCodesByTypeAndUserGroup((Code.CodeTypes)Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes),codeType), userGroup);
                cbDependsOnCode.DataValueField = "CodeID";
                cbDependsOnCode.DataTextField = "CodeDescription";
                cbDependsOnCode.DataBind();
            }
            catch { }
        }

        protected void btnAddCode_Click(object sender, EventArgs e)
        {
            int dependsOn = 0;
            string commentVal = null;
            try
            {
                SimpleServingsLibrary.Shared.Code.CodeTypes codeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), CodeType);
                if (DependsOn != null && DependsOn.Count > 0)
                {
                    dependsOn = Convert.ToInt32(DependsOn[0]);  //etc 191, Categories
                }
                if (codeType == SimpleServingsLibrary.Shared.Code.CodeTypes.Tag && dependsOn == 191)
                {
                    commentVal = CodeValue.Substring(0, CodeValue.IndexOf(" Cuisine"));
                }
                else
                {
                    commentVal = Comment;
                }
                int codeID = SimpleServingsLibrary.Shared.Code.AddCode(codeType, CodeValue, commentVal, dependsOn, 0, CreatedBy); //create a new CodeID, max CodeID

                if (codeID != 0)
                {
                    SimpleServingsLibrary.Shared.CodeDependency codeDependency = new CodeDependency();
                    foreach (object dependsOnCode in DependsOn)
                    {
                        codeDependency.CodeID = codeID;
                        codeDependency.Comment = Comment;
                        codeDependency.DependsOnCodeID = Convert.ToInt32(dependsOnCode);
                        codeDependency.CreatedBy = CreatedBy;
                        //  codeDependency.AddCodeDependency();
                    }


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
                    lblMsg.Text = "Code successfully added.";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "The code already exists in the code table";
                }

            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                //lblMsg.Text = ex.Message;

                lblMsg.Text = "If you add a Cuisine, you need the add word 'Cuisines' following it" ;
            }
        }
    }
}