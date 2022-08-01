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
    public partial class EditCode : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = String.Empty;
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    PopRules();
                    


                    if (Request["CodeID"] != null)
                    {
                        int codeID = Convert.ToInt32(Request["CodeID"].ToString());

                        //only way to get dependsOnCodeType for now
                        //maybe we should store this value in tblCode

                        try
                        {
                            SimpleServingsLibrary.Shared.CodeDependencies cds = SimpleServingsLibrary.Shared.CodeDependency.GetCodeDependenciesByCodeID(codeID);
                            int dependsOnCodeID = ((CodeDependency)cds[0]).DependsOnCodeID;
                            Code dependsOnCode = new Code(dependsOnCodeID);
                            string dependsOnCodeType = dependsOnCode.CodeType;
                            lblDependsOnCodeType.Text = dependsOnCodeType;
                        }
                        catch { }

                        PopCode(codeID);
                        CheckGrid(codeID);

                         //if Code Type = 'Tag', then Depends On Type = 'Categories', Mandy add
                        //string codeType = ddlCodeType.SelectedValue.ToString();
                        //if (codeType == "Tag")
                        //{
                        //    ddlDependsOnType.SelectedValue = "Categories";
                        //    PopDependsOn("Categories");
                        //}
                    }
                }

                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }


               
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
            
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        

        private void CheckGrid(int codeID)
        {
            try
            {
                SimpleServingsLibrary.Shared.Rules rules = SimpleServingsLibrary.Shared.Rule.GetRulesByCodeID(codeID);

                RuleGrid1.SelectRules(rules);
            }
            catch { }
            
        }


        private void PopCode(int codeID)
        {
            Code code = new Code(codeID);
            lblCodeValue.Text = code.CodeDescription;
            txtComment.Text = code.Comment;
            txtCodeValue.Text = code.CodeDescription;
            lblCreatedBy.Text = code.CreatedByText;
            string codeType = code.CodeType;
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
                ddlDependsOnType.Items.Insert(0, new ListItem("Select", GlobalEnum.EmptyCode.ToString()));
                ddlDependsOnType.Items.FindByValue(DependsOnType).Selected = true;
            }
            catch { }
            PopDependsOn(DependsOnType);
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
        { get { return lblDependsOnCodeType.Text; } }
        public string CodeType
        { get { return ddlCodeType.SelectedItem.ToString(); } }
        //public int CreatedBy
        //{ get { return Convert.ToInt32(lblCreatedBy.Text); } }
        #endregion
        public void PopCodeData(string codeType)
        {
           
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
            //Populate CheckBox list
            try
            {
                int userGroup = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
                cbDependsOnCode.DataSource = SimpleServingsLibrary.Shared.Code.GetCodesByTypeAndUserGroup((Code.CodeTypes)Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), codeType), userGroup);
                cbDependsOnCode.DataValueField = "CodeID";
                cbDependsOnCode.DataTextField = "CodeDescription";
                cbDependsOnCode.DataBind();
            }
            catch { }

            //Check appropriate check Boxes
            int codeID = Convert.ToInt32(Request["CodeID"].ToString());

            try
            {
                SimpleServingsLibrary.Shared.CodeDependencies cds = SimpleServingsLibrary.Shared.CodeDependency.GetCodeDependenciesByCodeID(codeID);

                foreach (SimpleServingsLibrary.Shared.CodeDependency cd in cds)
                {
                    cbDependsOnCode.Items.FindByValue(cd.DependsOnCodeID.ToString()).Selected = true;
                    // get the select index of cbDependsOnCode, Mandy add
                    int index = cbDependsOnCode.Items.IndexOf(cbDependsOnCode.Items.FindByValue(cd.DependsOnCodeID.ToString()));
                    Session["indexOfL"] = index;
                }
            }
            catch { }
        }

        protected void btnAddCode_Click(object sender, EventArgs e)
        {
            int dependsOn = 0;
            int codeID = Convert.ToInt32(Request["CodeID"].ToString());
            int staffID = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
            SimpleServingsLibrary.Shared.Code code = new SimpleServingsLibrary.Shared.Code(codeID);
            string commentVal = null;
            try
            {
                SimpleServingsLibrary.Shared.Code.CodeTypes codeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), CodeType);
                if (DependsOn != null && DependsOn.Count > 0)
                {
                    dependsOn = Convert.ToInt32(DependsOn[0]);
                }
                if (codeType == SimpleServingsLibrary.Shared.Code.CodeTypes.Tag && dependsOn == 191)
                {
                    commentVal = CodeValue.Substring(0, CodeValue.IndexOf(" Cuisine"));
                }
                else
                {
                    commentVal = Comment;
                }
                bool IsEdit = SimpleServingsLibrary.Shared.Code.UpdateCode(codeID, CodeValue, commentVal, dependsOn, code.CodeOrder, staffID);
                if (IsEdit == true)
                {
                    //remove old dependencies
                    SimpleServingsLibrary.Shared.CodeDependency.RemoveCodeDependenciesByCodeID(codeID);
                    //add new ones
                    SimpleServingsLibrary.Shared.CodeDependency codeDependency = new CodeDependency();
                    foreach (object dependsOnCode in DependsOn)
                    {
                        codeDependency.CodeID = codeID;
                        codeDependency.Comment = Comment;
                        codeDependency.DependsOnCodeID = Convert.ToInt32(dependsOnCode);
                        codeDependency.CreatedBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
                        codeDependency.AddCodeDependency();
                    }
                    //remove old rule associations
                    SimpleServingsLibrary.Shared.RuleCodeAssociation.RemoveRuleCodeAssociationsByCodeID(codeID);

                    //add new ones

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
                    lblMsg.Text = "Code successfully updated.";
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
                lblMsg.Text = ex.Message;
            }
        }

        protected void cbDependsOnCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            int indexOfL = Convert.ToInt32(Session["indexOfL"].ToString());
            int i = 0;

            foreach (ListItem li in cbDependsOnCode.Items)
            {
                if (i != indexOfL && li.Selected)
                {
                    indexOfL = i;
                    cbDependsOnCode.ClearSelection();
                    li.Selected = true;

                    Session["indexOfL"] = i;

                }
                i++;
            }


        }




    }
}