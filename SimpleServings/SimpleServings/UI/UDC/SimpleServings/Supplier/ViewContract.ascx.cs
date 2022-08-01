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
    public partial class ViewContract : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            PopContract(Convert.ToInt32(Request["ContractID"]));
            PopDeactivateLink();
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProviderModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                lnkBtnEdit.Visible = false;
                this.lnkBtnDeactivate.Visible = false;
            }
        }

        public void PopContract(int ContractID)
        {
            Contract s = Contract.GetContractByID(ContractID);
            PopContract(s);
            ctrlViewPerson.PopContactPerson(s.ContactPersonID);
        }

        private void PopContract(Contract c)
        {
            lblContractName.Text = c.ContractName;
            lblContractNumber.Text = c.ContractNumber;
            lblContractTypeName.Text = c.ContractTypeName;
            lblSponsorName.Text = c.SponsorName;
            lblSponsorAddress.Text = c.SponsorAddress;
            PopCaterers(c.CatererList);
            PopMeals(c.MealServedList);
            PopDietTypes(c.DietTypesList);
            lblContractID.Text = c.ContractID.ToString();
            lblContractAssignedTo.Text = c.AssignedToText;
        }

        private void PopCaterers(Caterers cs)
        {
            dlCaterer.DataSource = cs;
            dlCaterer.DataBind();
        }

        private void PopMeals(Meals ms)
        {
            dlMeal.DataSource = ms;
            dlMeal.DataBind();
        }

        private void PopDietTypes(DietTypes DietTypesList)
        {
            dlDietType.DataSource = DietTypesList;
            dlDietType.DataBind();
        }
        protected void lnkBtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Action=Edit&ContractID={0}", lblContractID.Text));
        }

        protected void lnkBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Action=List"));
        }

        private void PopDeactivateLink()
        {
            lnkBtnDeactivate.Attributes.Add("OnClick", "Javascript: return confirm('Do you want to remove this contract?');");
        }

        protected void lnkBtnDeactivate_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int contractID = Convert.ToInt32(Request["ContractID"]);
                SimpleServingsLibrary.SupplierRelationship.Contract.RemoveContractByID(contractID);
                Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Action=List"));
            }
        }
    }
}