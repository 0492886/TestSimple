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
    public partial class AddEditContract : System.Web.UI.UserControl
    {
        private int CreatedBy
        {
            get { return ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).StaffID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
                PopAssignedTo();
                if (Request["ContractID"] != null && Request["ContractID"].ToString() != string.Empty)
                {
                    PopContract(Convert.ToInt32(Request["ContractID"]));
                }
                else
                {
                    PopContract(0);
                }
            }
            catch (ApplicationException ex)
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
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProviderModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                divContent.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void PopAssignedTo()
        {

            try
            {
                ddlAssignedTo.DataSource = SimpleServingsLibrary.Shared.Staff.GetAllDFTAUserAndAdmin();
                ddlAssignedTo.DataTextField = "FullName";
                ddlAssignedTo.DataValueField = "StaffID";
                ddlAssignedTo.DataBind();
                ddlAssignedTo.Items.Insert(0, new ListItem("[Select]", "0"));
            }
            catch (Exception ex)
            {
                ddlAssignedTo.DataSource = null;
                ddlAssignedTo.DataBind();
                ddlAssignedTo.Items.Insert(0, new ListItem("[Select]", "0"));
            }

        }

        public void PopContract(int contractID)
        {
            if (contractID != 0)
            {
                Contract c = Contract.GetContractByID(contractID);
                PopContract(c);
            }
            else
            {
                PopContract(null);
            }
        }

        public void SaveContract()
        {
            int contactPersonID = 0;
            if (ctrlContactPerson.HasItems())
            {
                contactPersonID = ctrlContactPerson.SaveContactPerson();
            }

            int contractID = Convert.ToInt32(lblContractID.Text.Trim());
            string contractName = txtContractName.Text.Trim();
            string contractNumber = txtContractNumber.Text.Trim();
            int contractType = Convert.ToInt32(ddlContractType.SelectedValue);
            int sponsorID = Convert.ToInt32(ddlSponsor.SelectedValue);
            string sponsorAddress = txtSponsorAddress.Text.Trim();
            int assignedTo = 0;
            try
            {
                assignedTo = Convert.ToInt32(ddlAssignedTo.SelectedValue);
            }
            catch { }
            Caterers cs = GetSelectedCaterers();
            Meals ms = GetSelectedMeals();

            DietTypes dt = GetSelectedDietTypes();

            if (contractID > 0)
            {
                Contract.EditContractByID(contractID, contractName, contractNumber, contractType, sponsorID, sponsorAddress, contactPersonID, cs, ms,dt, assignedTo);
            }
            else
            {
                contractID = Contract.AddContract(contractName, contractNumber, contractType, sponsorID, sponsorAddress, contactPersonID, CreatedBy, cs, ms,dt, assignedTo);
            }

            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Action=View&ContractID={0}", contractID));
        }

        private Caterers GetSelectedCaterers()
        {
            Caterers cs = new Caterers();
            
            foreach (ListItem item in cblCaterer.Items)
            {
                if (item.Selected == true)
                {
                    int catererID = Convert.ToInt32(item.Value);    
                    cs.Add(new Caterer(catererID));
                }
            }

            return cs;
        }

        private Meals GetSelectedMeals()
        {
            Meals ms = new Meals();

            foreach (ListItem item in cblMeal.Items)
            {
                if (item.Selected == true)
                {
                    int mealServedTypeID = Convert.ToInt32(item.Value);
                    ms.Add(new Meal(mealServedTypeID));
                }
            }

            return ms;
        }

        private DietTypes GetSelectedDietTypes()
        {
            DietTypes dt = new DietTypes();

            foreach(ListItem item in cblDietType.Items)
            {
                if (item.Selected == true)
                {
                    DietType d = new DietType();
                    d.DietTypeID = Convert.ToInt32(item.Value);                    
                    dt.Add(d); 
                }
            }

            return dt;
        }

        private void PopContract(Contract c)
        {
            if (c != null)
            {
                lblContractID.Text = c.ContractID.ToString();
                txtContractName.Text = c.ContractName;
                txtContractNumber.Text = c.ContractNumber;
                txtSponsorAddress.Text = c.SponsorAddress;
                PopContractType(c.ContractType);
                ctrlContactPerson.PopContactPerson(c.ContactPersonID);
                PopSponsor(c.SponsorID);
                PopCaterer(c.CatererList);
                PopMeal(c.MealServedList);
                PopDietType(c.DietTypesList);
                try
                {
                    this.ddlAssignedTo.Items.FindByValue(c.AssignedTo.ToString()).Selected = true;
                }
                catch { }
            }
            else
            {
                lblContractID.Text = "0";
                PopContractType(0);
                PopSponsor(0);
                PopCaterer(null);
                PopMeal(null);
                PopDietType(null);
            }
        }

        private void PopContractType(int contractType)
        {
            Utility.GetCodesByTypeAndUserGroupSelect(ddlContractType, Code.CodeTypes.ContractType, ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).UserGroup, "");
            if (contractType != 0)
            {
                ddlContractType.Items.FindByValue(contractType.ToString()).Selected = true;
            }
        }

        private void PopSponsor(int sponsorID)
        {
            Sponsors sponsorList = Sponsor.GetSponsorAll();
            ddlSponsor.DataSource = sponsorList;
            ddlSponsor.DataTextField = "SponsorName";
            ddlSponsor.DataValueField = "SponsorID";
            ddlSponsor.DataBind();
            ddlSponsor.Items.Insert(0, new ListItem("[Select]", "0"));

            if (sponsorID > 0)
            {
                for (int i = 0; i < ddlSponsor.Items.Count; i++)
                {
                    if (sponsorID == Convert.ToInt32(ddlSponsor.Items[i].Value))
                    {
                        ddlSponsor.Items[i].Selected = true;
                        break;
                    }
                }
            }
        }

        private void PopCaterer(Caterers cs)
        {
            Caterers catererList = Caterer.GetCatererAll();
            cblCaterer.DataSource = catererList;
            cblCaterer.DataTextField = "CatererName";
            cblCaterer.DataValueField = "CatererID";
            cblCaterer.DataBind();

            if (cs !=null && cs.Count > 0)
            {
                foreach (Caterer c in cs)
                {
                    for (int i = 0; i < cblCaterer.Items.Count; i++)
                    {
                        int catererID = Convert.ToInt32(cblCaterer.Items[i].Value);
                        if (c.CatererID == catererID)
                        {
                            cblCaterer.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        private void PopMeal(Meals ms)
        {
            Utility.GetCodesByTypeAndUserGroup(cblMeal, Code.CodeTypes.MealServedType, ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).UserGroup);
            if (ms != null)
            {
                foreach (Meal m in ms)
                {
                    cblMeal.Items.FindByValue(m.MealServedTypeID.ToString()).Selected = true;
                }
            }
        }

        private void PopDietType(DietTypes dt)
        {

            Utility.GetCodesByTypeAndUserGroup(cblDietType, Code.CodeTypes.DietType, ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).UserGroup);

            if (dt != null)
            {
                foreach (DietType d in dt)
                {
                    cblDietType.Items.FindByValue(d.DietTypeID.ToString()).Selected = true;

                    if (d.DietTypeID == GlobalEnum.RegularDietType)
                        cblDietType.Items.FindByValue(d.DietTypeID.ToString()).Enabled = false;  
                }
            }

        }
    

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveContract();

            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = string.Format(ex.Message);
            }
        }

        protected void lnkBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Action=List"));
        }
    }
}