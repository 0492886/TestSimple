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
using SimpleServings.UI.UDC.SimpleServings.Setting;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class CodeList : System.Web.UI.UserControl
    {
        public int NewPageIndex
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["NewPageIndex"];
                if (o == null)
                    return 0; // default page index of 0
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["NewPageIndex"] = value;
            }
        }

        public void PopCode()
        {
            try
            {
                ApplyPermissions();
                if (!Page.IsPostBack)
                {
                    PopDropDownList();
                    PopDescription();
                }
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
                lnkBtnReoderCode.Visible = false;
                hlInsertCode.Visible = false;
                hlAddRule.Visible = false;
                hlViewRules.Visible = false;
                panelReorder.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        private void PopDropDownList()
        {
            try
            {
                ddlCodeType.DataSource = SimpleServingsLibrary.Shared.Code.GetAllCodeType();
                ddlCodeType.DataTextField = "CodeType";
                ddlCodeType.DataBind();
                SimpleServingsLibrary.Shared.Code.CodeTypes codeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), ddlCodeType.SelectedItem.ToString());
                lblCodeType.Text = codeType.ToString();
                hlInsertCode.NavigateUrl = "~/UI/Page/SimpleServings/Setting/InsertCode.aspx?CodeType=" + lblCodeType.Text;
                hlAddRule.NavigateUrl = "~/UI/Page/SimpleServings/Setting/AddRule.aspx?";
                hlViewRules.NavigateUrl = "~/UI/Page/SimpleServings/Setting/ViewAllRules.aspx?";

                // add Categories when CodeType select "Tag"
                ddlCategories.DataSource = SimpleServingsLibrary.Shared.Code.GetCodesByType(SimpleServingsLibrary.Shared.Code.CodeTypes.Categories);
                ddlCategories.DataTextField = "CodeDescription";
                ddlCategories.DataValueField = "CodeID";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("All", "0"));
            }
            catch

            { }

        }
        private void PopDescription()
        {
            try
            {
                SimpleServingsLibrary.Shared.Code.CodeTypes codeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), ddlCodeType.SelectedItem.ToString());
                ReorderCodeValue1.CodeType = codeType.ToString();
                lblCodeType.Text = codeType.ToString();
                hlInsertCode.NavigateUrl = "~/UI/Page/SimpleServings/Setting/InsertCode.aspx?CodeType=" + lblCodeType.Text;
                hlAddRule.NavigateUrl = "~/UI/Page/SimpleServings/Setting/AddRule.aspx?";
                hlViewRules.NavigateUrl = "~/UI/Page/SimpleServings/Setting/ViewAllRules.aspx?";
                SimpleServingsLibrary.Shared.Codes codes = SimpleServingsLibrary.Shared.Code.GetCodesByType(codeType, !cbDeactiveCodes.Checked);
                ReorderCodeValue1.PopReorderCodeValue(codeType);
                PopGrid(codes);
            }
            catch
            {
                gvCodeDescription.DataSource = null;
                gvCodeDescription.DataBind();

                ReorderCodeValue1.ClearReorderList();
            }

        }

        private void PopDescription_Tag()
        {
            try { 
            int Category = Convert.ToInt32(ddlCategories.SelectedValue.ToString());
            SimpleServingsLibrary.Shared.Codes codes = SimpleServingsLibrary.Shared.Code.GetCodesByType_Tag(Category, !cbDeactiveCodes.Checked);

            PopGrid(codes);
            
        }
        catch 
            {
                gvCodeDescription.DataSource = null;
                gvCodeDescription.DataBind();

                ReorderCodeValue1.ClearReorderList();
            }
        }


    private void PopGrid(SimpleServingsLibrary.Shared.Codes codes)
        {
            gvCodeDescription.DataSource = codes;
            Session["Codes"] = codes;
            gvCodeDescription.DataBind();
        }
       

        protected void ddlCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCodeType.SelectedValue == "Tag" )
            {
                lblCategories.Visible = true;
                ddlCategories.Visible = true;
                
            }
            else
            {
                lblCategories.Visible = false;
                ddlCategories.Visible = false;
            }

            
            UserGroupList1.UserGroupPanel.Visible = false;
            PopDescription();
        }

        protected void lnkBtnClose_Click(object sender, EventArgs e)
        {
            if (Session["CodeDescription"] != null)
            {
                SimpleServingsLibrary.Shared.Code.CodeTypes codeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), ReorderCodeValue1.CodeType);

                SimpleServingsLibrary.Shared.Codes codes = (SimpleServingsLibrary.Shared.Codes)Session["CodeDescription"];

                int order = 1;
                foreach (SimpleServingsLibrary.Shared.Code code in codes)
                {
                    SimpleServingsLibrary.Shared.Code.SaveCodeValueOrderList(codeType, code.CodeID, order);
                    order++;
                }
            }
            modalPopupReorder.Hide();
            PopDescription();
            Session["CodeDescription"] = null;
        }
   
        protected void gvCodeDescription_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
                PopDescription();
                gvCodeDescription.PageIndex = e.NewPageIndex;
                NewPageIndex = e.NewPageIndex;
                gvCodeDescription.DataBind();
            
        }

        protected void cbDeactiveCodes_CheckedChanged(object sender, EventArgs e)
        {
            if (ddlCodeType.SelectedValue == "Tag" && ddlCategories.SelectedIndex > 0)
            {
                PopDescription_Tag();
            }
            else
            {
                PopDescription();
            }
            
        }

        protected void lnkBtnRemove_Click(object sender, EventArgs e)
        {
            
            int  codeID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                try
                {
                    SimpleServingsLibrary.Shared.Code.DeactivateCode(codeID, HelpClasses.AppHelper.GetCurrentUser().StaffID);
                    //SimpleServingsLibrary.Shared.Code.DeactivateCode(codeID, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
                    UserGroupList1.Visible = false;
                    if (ddlCodeType.SelectedValue == "Tag" && ddlCategories.SelectedIndex > 0)
                    {
                        PopDescription_Tag();
                    }
                    else
                    {
                        PopDescription(); 
                    }
                                      
                }
                catch { }
            

        }

        protected void lnkBtnActivate_Click(object sender, EventArgs e)
        {

            int codeID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                try
                {
                    SimpleServingsLibrary.Shared.Code.ActivateCode(codeID, HelpClasses.AppHelper.GetCurrentUser().StaffID);
                    //SimpleServingsLibrary.Shared.Code.ActivateCode(codeID, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
                    UserGroupList1.Visible = false;
                    if (ddlCodeType.SelectedValue == "Tag" && ddlCategories.SelectedIndex > 0)
                    {
                        PopDescription_Tag();
                    }
                    else
                    {
                        PopDescription();
                    }
                    
                }
                catch { }
        }

        protected void lnkBtnExclude_Click(object sender, EventArgs e)
        {
            int codeID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
             lblCodeID.Text = codeID.ToString();
             UserGroupList1.Visible = true;
             UserGroupList1.PopUserGroup(codeID);

        }

        protected bool CanDelete()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            return SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Delete);
        }

        protected bool CanAdd()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            return SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add);
        }
        protected bool CanEdit()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            return SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit);
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopDescription_Tag();
        }
    }
}