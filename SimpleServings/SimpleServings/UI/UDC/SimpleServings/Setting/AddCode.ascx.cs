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
using System.Drawing;

using System.Web.Services;
using AjaxControlToolkit;


namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class AddCode : System.Web.UI.UserControl
    {
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
        public int DependsOn
        {
            get { return Convert.ToInt32(ddlDependsOnCode.SelectedValue); }
        }
        public string DependsOnType
        { get { return ddlDependsOnType.SelectedItem.ToString(); } }
        public string CodeType
        { get { return ddlCodeType.SelectedItem.ToString(); } }
        public int CreatedBy
        { get { return Convert.ToInt32(lblCreatedBy.Text); } }
        #endregion

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
            
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        public void PopCodeData(string codeType)
        {
            lblMsg.Text = "";
            txtComment.Text = "";
            txtCodeValue.Text = "";
            lblCreatedBy.Text = ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID.ToString();
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
                ddlDependsOnCode.DataSource = SimpleServingsLibrary.Shared.Code.GetCodesByUserGroupCodes();
                ddlDependsOnCode.DataValueField = "CodeID";
                ddlDependsOnCode.DataTextField = "CodeDescription";
                ddlDependsOnCode.DataBind();
            }
            catch { }
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
                ddlDependsOnCode.DataSource = SimpleServingsLibrary.Shared.Code.GetCodesByTypeAndUserGroup((Code.CodeTypes)Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes),codeType), userGroup);
                ddlDependsOnCode.DataValueField = "CodeID";
                ddlDependsOnCode.DataTextField = "CodeDescription";
                ddlDependsOnCode.DataBind();
            }
            catch { }
        }
    }
}