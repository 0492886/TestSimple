using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Reports
{
    public partial class ucDailyMenuParameter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            ApplyPermissions();

            if (!IsPostBack)
            {

                //ddlMenuID.Enabled = false;
                try
                {
                    SimpleServingsLibrary.SupplierRelationship.Contracts contracts = new SimpleServingsLibrary.SupplierRelationship.Contracts();
                    contracts = SimpleServingsLibrary.SupplierRelationship.Contract.GetContractsByStaffIDAndContractType(staff.StaffID, 0);
                    ddlContractID.DataSource = contracts;
                    ddlContractID.DataTextField = "ContractName";
                    ddlContractID.DataValueField = "ContractID";
                    ddlContractID.DataBind();
                    ddlContractID.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
                }
                catch { }
            }

            string reportid = Request["reportID"];
            if (reportid == "18")
            {
                divYearMonth.Visible = false;
            }

        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ReportModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        protected void ddlContractID_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbDate.Text = "";
            ddlMenuID.Enabled = false;

            //SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            //if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //int contractID =0;
            //Int32.TryParse(ddlContractID.SelectedValue, out contractID);
            //Dictionary<string, string> menuList = new Dictionary<string, string>();
            //try
            //{
            //    SimpleServingsLibrary.Menu.Menus menus = SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserIDContractIDpeMenuStatus(staff.StaffID, contractID, GlobalEnum.MenuStatus_Approved, 1);
            //    foreach (SimpleServingsLibrary.Menu.Menu item in menus)
            //    {
            //        menuList.Add(item.MenuID.ToString(), item.MenuID.ToString() + "-" + item.MenuName);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Catch section left blank on purpose
            //}

            //try
            //{
            //    SimpleServingsLibrary.Menu.Menus oldmenus = SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserIDContractIDpeMenuStatus(staff.StaffID, contractID, GlobalEnum.MenuStatus_Approved, 0);
            //    foreach (SimpleServingsLibrary.Menu.Menu item in oldmenus)
            //    {
            //        menuList.Add(item.MenuID.ToString(), item.MenuID.ToString() + "-" + item.MenuName);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Catch section left blank on purpose

            //}

            //menuList.OrderByDescending(x => x.Value);

            //ddlMenuID.DataSource = menuList;
            //ddlMenuID.DataTextField = "Value";
            //ddlMenuID.DataValueField = "Key";
            //ddlMenuID.DataBind();
            //ddlMenuID.Enabled = true;

        }


        public void GetDailyMenuReportParameters(out int ContractID, out int MenuID, out string Date)
        {
            Int32.TryParse(ddlContractID.SelectedValue, out ContractID);
            Int32.TryParse(ddlMenuID.SelectedValue, out MenuID);
            Date = tbDate.Text;
 
        }

        protected void tbDate_TextChanged(object sender, EventArgs e)
        {
           
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            int contractID = 0;
            Int32.TryParse(ddlContractID.SelectedValue, out contractID);
            DateTime inputDate = Convert.ToDateTime(tbDate.Text);

            Dictionary<string, string> menuList = new Dictionary<string, string>();
            try
            {
                SimpleServingsLibrary.Menu.Menus menus = SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserIDContractIDpeMenuStatus(staff.StaffID, contractID, GlobalEnum.MenuStatus_Approved, 1, inputDate);
                foreach (SimpleServingsLibrary.Menu.Menu item in menus)
                {
                    menuList.Add(item.MenuID.ToString(), item.MenuID.ToString() + "-" + item.MenuName);
                }
            }
            catch (Exception ex)
            {
                // Catch section left blank on purpose
            }

            try
            {
                SimpleServingsLibrary.Menu.Menus oldmenus = SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserIDContractIDpeMenuStatus(staff.StaffID, contractID, GlobalEnum.MenuStatus_Approved, 0,inputDate);
                foreach (SimpleServingsLibrary.Menu.Menu item in oldmenus)
                {
                    menuList.Add(item.MenuID.ToString(), item.MenuID.ToString() + "-" + item.MenuName);
                }
            }
            catch (Exception ex)
            {
                // Catch section left blank on purpose

            }

            menuList.OrderByDescending(x => x.Value);

            ddlMenuID.DataSource = menuList;
            ddlMenuID.DataTextField = "Value";
            ddlMenuID.DataValueField = "Key";
            ddlMenuID.DataBind();
            ddlMenuID.Enabled = true;


        }
    }
}