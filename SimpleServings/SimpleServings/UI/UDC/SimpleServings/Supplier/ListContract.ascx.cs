using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.SupplierRelationship;
using SimpleServingsLibrary.Shared;
using SimpleServings.UI.Page.SimpleServings.Menu;

namespace SimpleServings.UI.UDC.SimpleServings.Supplier
{
    public partial class ListContract : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ApplyPermissions();
            //PopAllContract();

            //if (Session["Contracts"] != null)
            //{
            //    string contracts = Session["Contracts"].ToString();

            //    switch (contracts)
            //    {

            //        case "All":
            //            //PopAllContract();
            //            break;
            //        case "selected":
            //            //PopSelectedContracts();
            //            break;
            //        default:
            //            //PopAllContract();
            //            break;

            //    }
            //}


            if (Request["Contracts"] == "All")
            {
                PopAllContract();
 
           }

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

        public void PopAllContract()
        {
            ApplyPermissions();
            Contracts cs = Contract.GetContractAll();
            PopGrid(cs);
        }

        public void PopSelectedContracts(List<int> IDs)
        {
            //Session["Contracts"] = "selected";
            Contracts modifiedList = new Contracts();
            lnkBtnAdd.Visible = false;
            lblTitle.Text = "Selected Contract List";
            Contracts cs = Contract.GetContractAll();
                      

            foreach (var i in cs)
            {
                if (IDs.Contains(i.ContractID))
                    modifiedList.Add(i);
            }
            
            PopGrid(modifiedList);
            gvContract.Columns[7].Visible = false;
 
        }


        public List<int> getCurrentContratcList()
        {
            List<int> cList = new List<int>();

            foreach (GridViewRow row in gvContract.Rows)
            {
                int contractID = 0;
                Int32.TryParse((row.FindControl("lblContractID") as Label).Text, out contractID);
                cList.Add(contractID);
            }

            return cList;
 
        }

        public List<KeyValuePair<int,string>> getCurrentContratcListName()
        {
            var cList = new List<KeyValuePair<int,string>>();

            foreach (GridViewRow row in gvContract.Rows)
            {
                int contractId = Int32.Parse((row.FindControl("lblContractID") as Label).Text);
                string contractName = (row.FindControl("lblContractName") as Label).Text;
                cList.Add(new KeyValuePair<int,string>(contractId,contractName));
            }

            return cList;

        }

        public void PopGrid(Contracts cs)
        {
            if (cs != null)
            {
                gvContract.DataSource = cs;
                gvContract.DataBind();
            }
            else 
            {
                gvContract.DataSource = null;
                gvContract.DataBind();

            }
        }

        protected void gvContract_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Action=View&ContractID={0}", e.CommandArgument.ToString()));
            }
        }

        protected void lnkBtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Action=Add"));
        }
    }
}