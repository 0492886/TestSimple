using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class ManageCategoriesandTags : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
 
            }
            lblMsg.Text = "";
            if (!IsPostBack)
            {
                PopTags();
            }

        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx"); 
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        


        private void PopTags()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlCategories, Code.CodeTypes.Categories, staff.UserGroup, "");
           
            SimpleServingsLibrary.Shared.Codes tags = SimpleServingsLibrary.Shared.Code.GetCodesByType(Code.CodeTypes.Tag);
            cblTags.DataSource = tags;
            cblTags.DataTextField = "CodeDescription";
            cblTags.DataValueField = "CodeID";
            cblTags.DataBind();

            int defaultCatID = 0;
            Int32.TryParse(ddlCategories.Items[0].Value, out defaultCatID);
            
            ManageCategoriesandTagsList tagList = new ManageCategoriesandTagsList();
            tagList = SimpleServingsLibrary.Shared.ManageCategoriesandTags.GetTagsByCategoryID(defaultCatID);

            foreach (var item in tagList)
            {
                cblTags.Items.FindByValue(item.TagID.ToString()).Selected = true;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            int catValue = 0;
            int.TryParse(ddlCategories.SelectedValue, out catValue);

            List<int> selTags = new List<int>();
             
            foreach (ListItem item in cblTags.Items)
            {
                if (item.Selected == true)
                    selTags.Add(Convert.ToInt32(item.Value));                
            }
            try
            {
                SimpleServingsLibrary.Shared.ManageCategoriesandTags.SaveTagsForCategory(catValue, selTags, staff.StaffID);
            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            lblMsg.Text = "Changes Saved Succefully!";
            lblMsg.ForeColor = System.Drawing.Color.Green;

        }

        protected void cblTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PopTags();
            cblTags.ClearSelection();
            int CategoryID = 0;
            Int32.TryParse(ddlCategories.SelectedValue, out CategoryID);

            ManageCategoriesandTagsList tagList = new ManageCategoriesandTagsList();
            tagList = SimpleServingsLibrary.Shared.ManageCategoriesandTags.GetTagsByCategoryID(CategoryID);
            foreach (var item in tagList)
            {
                cblTags.Items.FindByValue(item.TagID.ToString()).Selected = true;
            }

        }
    }
}