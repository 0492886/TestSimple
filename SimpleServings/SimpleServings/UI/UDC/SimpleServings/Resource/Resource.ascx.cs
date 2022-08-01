using SimpleServingsLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Resource
{
    public partial class Resource : System.Web.UI.UserControl
    {
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = System.Security.Principal.WindowsIdentity.GetCurrent().User;
            var userName = user.Translate(typeof(System.Security.Principal.NTAccount));
            hidden.Value = userName.ToString();
            lblMsg.Visible = false;
            if (!Page.IsPostBack)
            {
                ApplyPermissions();
                PopDropDowns();
                PopResources();
            }
        }

        private void PopDropDowns()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlType, Code.CodeTypes.ResourceType, staff.UserGroup, "");
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(ddlTypeFilter, Code.CodeTypes.ResourceType, staff.UserGroup, "");

        }
        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");

            this.pnManageResources.Visible = (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN);
                    //|| staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.DFTASUP;               
            
        }

        private void PopResources()
        {
            SimpleServingsLibrary.Resource.Resources resources = new SimpleServingsLibrary.Resource.Resources();
            
            int resourceType = 0;
            Int32.TryParse(ddlTypeFilter.SelectedValue, out resourceType);
            
            try
            {
                resources = SimpleServingsLibrary.Resource.Resource.GetResourcesByType(resourceType);
                ResourceList1.PopResources(resources);
                ResourceList1.PopResourcesGrid(resources);
            }
            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtName.Text.Trim()))
                    throw new Exception("Please enter a title for this resource");
                string resourceFolder = ConfigurationManager.AppSettings["ResourceFolder"];
                string resourceURL = "";
                if (fileUpload.HasFile)
                {
                   
                    resourceURL = resourceFolder + "/" + fileUpload.FileName;
                    fileUpload.SaveAs(Server.MapPath(resourceURL));
                    SimpleServingsLibrary.Resource.Resource resource = new SimpleServingsLibrary.Resource.Resource();
                    resource.ResourceText = txtName.Text.Trim();
                    resource.ResourceUrl = resourceURL;
                    int resourceType = 0;
                    Int32.TryParse(ddlType.SelectedValue, out resourceType);
                    resource.ResourceType = resourceType;
                    resource.AddResource();
                    txtName.Text = "";
                    PopResources();
                }
                else
                    throw new Exception("Please select a file for this resource");
            }
            catch(Exception ex)
            {
                txtName.Text = "";
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
        }

        protected void fileUpload_DataBinding(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) txtName.Text = fileUpload.FileName;
        }

        protected void ddlTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopResources();
        }
    }
}