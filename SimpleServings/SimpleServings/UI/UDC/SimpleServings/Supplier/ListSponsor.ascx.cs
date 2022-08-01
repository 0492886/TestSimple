using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.SupplierRelationship;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Supplier
{
    public partial class ListSponsor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            PopAllSponsor();
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProviderModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                lnkBtnAdd.Visible = false;
            }
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "You are not allowed to access this page";
                
            }
        }

        public void PopAllSponsor()
        {
            Sponsors ss = Sponsor.GetSponsorAll();
            PopGrid(ss);
        }

        private void PopGrid(Sponsors ss)
        {
            gvSponsor.DataSource = ss;
            gvSponsor.DataBind();
        }

        protected void gvSponsor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx?Action=View&SponsorID={0}", e.CommandArgument.ToString()));
            }
        }

        protected void lnkBtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx?Action=Add"));
        }
    }
}