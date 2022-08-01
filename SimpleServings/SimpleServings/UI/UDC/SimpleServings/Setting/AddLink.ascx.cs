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
    public partial class AddLink : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    PopDropDowns();
                }

                catch (ApplicationException ex)
                {

                    lblMsg.ForeColor = System.Drawing.Color.Red;

                    lblMsg.Text = ex.Message;

                }
            }

        }

        private void PopDropDowns()
        {
            int userGroupID = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlLinkType, SimpleServingsLibrary.Shared.Code.CodeTypes.LinkType, userGroupID, "0");
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndDependsOnAndUserGroup(ddlLinkCategory, SimpleServingsLibrary.Shared.Code.CodeTypes.LinkCategory, Convert.ToInt32(ddlLinkType.SelectedValue), userGroupID, "0");
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                lnkbViewLinks.Visible = false;
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }            
        }


        protected void btnAddLink_Click(object sender, EventArgs e)
        {
            SaveLink();
        }

        private void GetValuesFromControls(ref SimpleServingsLibrary.Shared.Link link)
        {
            link.Category = Convert.ToInt32(ddlLinkCategory.SelectedValue);
            link.LinkType = Convert.ToInt32(ddlLinkType.SelectedValue);
            link.Hyperlink = txtHyperlink.Text;
            link.Description = txtDescription.Text;
            link.IconLink = txtIconLink.Text;
            link.Comment = txtComment.Text;
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            link.CreatedBy = staff.StaffID;
        }

        private int SaveLink()
        {
            int linkID = 0;
            try
            {
                SimpleServingsLibrary.Shared.Link link = new SimpleServingsLibrary.Shared.Link();
                GetValuesFromControls(ref link);
                linkID = link.AddLink();
                lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
                lblMsg.Text = "Link successfully saved";
                lblMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
            return linkID;
        }

        protected void ddlLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userGroupID = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndDependsOnAndUserGroup(ddlLinkCategory, SimpleServingsLibrary.Shared.Code.CodeTypes.LinkCategory, Convert.ToInt32(ddlLinkType.SelectedValue), userGroupID, "0");
        }

        protected void lnkbViewLinks_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/myzone.aspx?Control=ManageLinks");
        }
    }
}