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
    public partial class CodeGrid : System.Web.UI.UserControl
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
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            const string cRefreshParent = "<script language='javascript'> window.opener.document.forms(0).submit(); </script>";

            const string cRefreshParentKey = "RefreshParentKey";


            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(cRefreshParentKey))
            {

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(),

                cRefreshParentKey, cRefreshParent);

            }
             */

        }
        public void PopGrid(SimpleServingsLibrary.Shared.Codes codes)
        {
            gvCodeDescription.DataSource = codes;
            Session["Codes"] = codes;
            gvCodeDescription.DataBind();
        }
       
        protected void lnkBtnRemove_Click(object sender, EventArgs e)
        {

            int codeID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            try
            {
                SimpleServingsLibrary.Shared.Code.DeactivateCode(codeID, HelpClasses.AppHelper.GetCurrentUser().StaffID);
                //SimpleServingsLibrary.Shared.Code.DeactivateCode(codeID, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
                SimpleServingsLibrary.Shared.Codes codes = (SimpleServingsLibrary.Shared.Codes)Session["Codes"];
                //Response.Redirect(Page.Request.Url.AbsolutePath);
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
                SimpleServingsLibrary.Shared.Codes codes = (SimpleServingsLibrary.Shared.Codes)Session["Codes"];
                
            }
            catch { }


        }

        protected void lnkBtnExclude_Click(object sender, EventArgs e)
        {
            int codeID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/UI/Page/Myzone.aspx?Control=UserGroupList&CodeID=" + codeID);

        }
        protected void gvCodeDescription_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SimpleServingsLibrary.Shared.Codes codes = (SimpleServingsLibrary.Shared.Codes)Session["Codes"];
            PopGrid(codes);
            gvCodeDescription.PageIndex = e.NewPageIndex;
            NewPageIndex = e.NewPageIndex;
            gvCodeDescription.DataBind();

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

    }
}