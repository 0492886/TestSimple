using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class SubmitMenuToContracts : System.Web.UI.UserControl
    {
        public List<int> GetSelectedContractIDs()
        {
           return ContractGrid1.GetSelectedContractIDs();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    if (Request["MenuID"] != null)
                    {
                        int menuID = 0;
                        Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                        lblMenuID.Text = menuID.ToString();
                        PopGrid(menuID);  
                    }
                }

                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }

        }
        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }

        }
        private void PopGrid(int menuID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            try
            {
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                menu.GetMenuByMenuID(menuID);
                //SimpleServingsLibrary.SupplierRelationship.Contracts contracts =
                //    SimpleServingsLibrary.SupplierRelationship.Contract.GetContractsByStaffIDAndContractType(staff.StaffID, menu.ContractTypeID);
                SimpleServingsLibrary.SupplierRelationship.Contracts contracts =
                    SimpleServingsLibrary.SupplierRelationship.Contract.GetContractsByStaffIDContractTypeDietType(staff.StaffID, menu.ContractTypeID, menu.DietTypeID, menu.MealServedTypeID);

                ContractGrid1.PopGrid(contracts);
                ContractGrid1.CheckSelectedContractsonGird(menu.ContractsIDs);
            }
            catch 
            {
                //ContractGrid1.PopGrid(null);
            
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SubmitToContracts(GlobalEnum.MenuStatus_SubmittedToContract);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
         }

        public void SubmitToContracts(int menustatus, string customMessage = null)
        {
            string message = (string.IsNullOrEmpty(customMessage)) ? string.Empty : customMessage.Trim();

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            
            int originalMenuID = 0;
            Int32.TryParse(lblMenuID.Text, out originalMenuID);
            List<int> contractIDs = new List<int> { };
            contractIDs = ContractGrid1.GetSelectedContractIDs();
            int numContracts = contractIDs.Count;
            if (numContracts < 1)
                throw new Exception("Please select at least one contract");

            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            menu.GetMenuByMenuID(originalMenuID);

            // Compare the list of selected contracts and originally associated contracts
            // If there is a mis-match the original menu will remain in the draft status and create new menus for selected contracts
            List<int> originalContractIDs = new List<int>(menu.ContractsIDs);
            List<int> listCompare =  new List<int>(originalContractIDs.Except(contractIDs).ToList());

            if (listCompare.Count == 0)
            {
                SimpleServingsLibrary.Menu.Menu.UpdateMenu(originalMenuID, contractIDs[0]);
                menu.EditMenuStatus(menustatus, staff.StaffID, message);
                contractIDs.RemoveAt(0);
            }
                
            if (numContracts > 1 || listCompare.Count != 0)
            {
                // IF MULTIPLE CONTRACTS ARE SELCTED CREATE NEW MENU FOR EACH OTHER CONTRACT ID AND COPY MENU DETAILS, MENU HISTORY, MENU ITEMS AND MENU ITEM CHANGE HISTORY 
                SimpleServingsLibrary.Menu.Menu.SubmitToMultipleContracts(originalMenuID, contractIDs, staff.StaffID, message, menustatus);
                
                //for (int i = 1; i < numContracts; i++)
                //{
                //    int newMenuID = SimpleServingsLibrary.Menu.Menu.DuplicateMenu(originalMenuID, contractIDs[i]);
                //    SimpleServingsLibrary.Menu.MenuItem.DuplicateMenuItems(originalMenuID, newMenuID, true);
                //    menu.GetMenuByMenuID(newMenuID);
                //    menu.EditMenuStatus(menustatus, staff.StaffID, message);
                //}
            }
       }                
    }
        
}