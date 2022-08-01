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
    public partial class EditLink : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    if (Request["LinkID"] != null)
                    {
                        lblLinkID.Text = Request["LinkID"].ToString();
                        PopLinkData(Convert.ToInt32(lblLinkID.Text));
                    }
                }

                catch (ApplicationException ex)
                {

                    lblMsg.ForeColor = System.Drawing.Color.Red;

                    lblMsg.Text = ex.Message;

                }
            }

        }

        private void PopLinkData(int linkID)
        {
            PopDropDowns();
            SimpleServingsLibrary.Shared.Link link = new SimpleServingsLibrary.Shared.Link(linkID);
            txtHyperlink.Text = link.Hyperlink;
            txtDescription.Text = link.Description;
            txtIconLink.Text = link.IconLink;
            txtComment.Text = link.Comment;
        }

        private void PopDropDowns()
        {
            try
            {
                int userGroupID = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
                SimpleServingsLibrary.Shared.Link link = new SimpleServingsLibrary.Shared.Link(Convert.ToInt32(lblLinkID.Text));
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlLinkType, SimpleServingsLibrary.Shared.Code.CodeTypes.LinkType, userGroupID, link.LinkType.ToString());
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndDependsOnAndUserGroup(ddlLinkCategory, SimpleServingsLibrary.Shared.Code.CodeTypes.LinkCategory, Convert.ToInt32(ddlLinkType.SelectedValue),userGroupID, link.Category.ToString());
            }
            catch (Exception ex)
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


        protected void btnEditLink_Click(object sender, EventArgs e)
        {
            UpdateLink();
        }

        private void GetValuesFromControls(ref SimpleServingsLibrary.Shared.Link link)
        {
            link.Category = Convert.ToInt32(ddlLinkCategory.SelectedValue);
            link.LinkType = Convert.ToInt32(ddlLinkType.SelectedValue);
            link.Hyperlink = txtHyperlink.Text;
            link.Description = txtDescription.Text;
            link.IconLink = txtIconLink.Text ;
            link.Comment=txtComment.Text;
        }

        private void UpdateLink()
        {
            try
            {
                int linkID = Convert.ToInt32(lblLinkID.Text);
                SimpleServingsLibrary.Shared.Link link = new SimpleServingsLibrary.Shared.Link(linkID);
                GetValuesFromControls(ref link);
                link.EditLink();
                lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
                lblMsg.Text = "changes successfully saved";
                lblMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
           
        }

        protected void ddlLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userGroupID = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndDependsOnAndUserGroup(ddlLinkCategory, SimpleServingsLibrary.Shared.Code.CodeTypes.LinkCategory, Convert.ToInt32(ddlLinkType.SelectedValue), userGroupID, "");
        }

        protected void lnkBLinkList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/myZone.aspx?Control=ManageLinks");
        }        
    }
}