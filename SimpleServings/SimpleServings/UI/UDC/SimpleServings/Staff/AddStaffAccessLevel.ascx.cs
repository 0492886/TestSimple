using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;


namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class AddStaffAccessLevel : System.Web.UI.UserControl
    {
        public bool IsUsedInWizard
        {
            set 
            { 
                btnSave.Visible = !value;
                ddlUserGroupName.Enabled = value;
            }
            get { return !btnSave.Visible; }
        }
        public int UserGroupID
        {
            get { return Convert.ToInt32(this.ddlUserGroupName.SelectedValue); }
        }
        public int AccessLevel
        {   
		    get 
            { 
                int accessLevel=0;
                int.TryParse(ViewState["AccessLevel"].ToString(), out accessLevel);
                return accessLevel;
            }
            set { ViewState["AccessLevel"] = value; }
	
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopDropDowns();
                if (!IsUsedInWizard)
                {
                    try
                    {
                        ApplyPermissions();
                       
                        if (Request["StaffID"] != null)
                        {
                            int staffID = 0;
                            Int32.TryParse(Request["StaffID"].ToString(), out staffID);
                            InitializeControl(staffID);
                            hlGoBack.NavigateUrl = ResolveUrl(
                                string.Format("~/UI/Page/MyZone.aspx?Control=MyProfile&StaffID={0}", staffID));
                        }
                    }
                    catch (ApplicationException ex)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = ex.Message;
                    }
                }
            }
        }

        private void PopDropDowns()
        {
            try
            {
                SimpleServingsLibrary.Shared.UserGroups groups =
                    SimpleServingsLibrary.Shared.UserGroup.GetAllUserGroup();
                ddlUserGroupName.DataSource = groups;
                ddlUserGroupName.DataTextField = "UserGroupName";
                ddlUserGroupName.DataValueField = "UserGroupID";
                ddlUserGroupName.DataBind();
            }
            catch { }
            ddlUserGroupName.Items.Insert(0, new ListItem("[Select]", "0"));
            try
            {
                SimpleServingsLibrary.SupplierRelationship.Sponsors sponsors =
                    SimpleServingsLibrary.SupplierRelationship.Sponsor.GetSponsorAll();
                ddlSponsor.DataSource = sponsors;
                ddlSponsor.DataTextField = "SponsorName";
                ddlSponsor.DataValueField = "SponsorID";
                ddlSponsor.DataBind();
            }
            catch { }
            ddlSponsor.Items.Insert(0, new ListItem("[Select]", "0"));
            try
            {
                SimpleServingsLibrary.SupplierRelationship.Caterers caterers =
                    SimpleServingsLibrary.SupplierRelationship.Caterer.GetCatererAll();
                ddlCaterer.DataSource = caterers;
                ddlCaterer.DataTextField = "CatererName";
                ddlCaterer.DataValueField = "CatererID";
                ddlCaterer.DataBind();
            }
            catch { }
            ddlCaterer.Items.Insert(0, new ListItem("[Select]", "0"));
        }

        private void InitializeControl(int staffID)
        {                
            try
            {
                lblStaffID.Text = staffID.ToString();
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
                lblSatffName.Text = staff.FullName;
                SimpleServingsLibrary.Shared.UserGroup group = new SimpleServingsLibrary.Shared.UserGroup(staff.UserGroup);
                ViewModulePermissions1.PopPermissions(group.UserGroupID);
                lblGroupAccessLevel.Text = group.AccessLevel.ToString();
                lblGroupAccessLevelText.Text = group.AccessLevelText;
                AccessLevel = group.AccessLevel;
                
                try
                {
                    ddlUserGroupName.ClearSelection();
                    ddlUserGroupName.Items.FindByValue(staff.UserGroup.ToString()).Selected = true;
                }
                catch { }

                if (AccessLevel == GlobalEnum.AccessLevel_Sponsor)
                {
                    pnSponsor.Visible = true;
                    ddlSponsor.AutoPostBack = false;
                    pnCaterer.Visible = false;
                    pnContract.Visible = false;
                    try
                    {
                        ddlSponsor.ClearSelection();
                        ddlSponsor.Items.FindByValue(staff.SupplierID.ToString()).Selected = true;
                    }
                    catch { }
                }
                else if (AccessLevel == GlobalEnum.AccessLevel_Contract || AccessLevel == GlobalEnum.AccessLevel_CateringContract)
                {
                    pnSponsor.Visible = true;
                    pnCaterer.Visible = false;
                    pnContract.Visible = true;
                    try
                    {
                        ddlSponsor.ClearSelection();
                        ddlSponsor.Items.FindByValue(staff.SupplierID.ToString()).Selected = true;
                    }
                    catch { }
                }
                else if (AccessLevel == GlobalEnum.AccessLevel_Caterer)
                {
                    pnSponsor.Visible = false;
                    pnCaterer.Visible = true;
                    pnContract.Visible = true;
                    try
                    {
                        ddlCaterer.ClearSelection();
                        ddlCaterer.Items.FindByValue(staff.SupplierID.ToString()).Selected = true;
                    }
                    catch { }
                }

                else if (AccessLevel == GlobalEnum.AccessLevel_All)
                {
                    pnSponsor.Visible = false;
                    pnCaterer.Visible = false;
                    pnContract.Visible = false;
                    btnSave.Visible = false;
                }
               
                PopContractGrid();
                
               
               
            }
            catch { }
        }

        private void PopControls(int userGroupID)
        {
            try
            {
                SimpleServingsLibrary.Shared.UserGroup group = new SimpleServingsLibrary.Shared.UserGroup(userGroupID);
                lblGroupAccessLevel.Text = group.AccessLevel.ToString();
                lblGroupAccessLevelText.Text = group.AccessLevelText;
                AccessLevel = group.AccessLevel;
                ddlCaterer.ClearSelection();
                ddlSponsor.ClearSelection();
                if (AccessLevel == GlobalEnum.AccessLevel_Sponsor)
                {
                    pnSponsor.Visible = true;
                    ddlSponsor.AutoPostBack = false;
                    pnCaterer.Visible = false;
                    pnContract.Visible = false;
                }
                else if (AccessLevel == GlobalEnum.AccessLevel_Contract || AccessLevel == GlobalEnum.AccessLevel_CateringContract)
                {
                    pnSponsor.Visible = true;
                    pnCaterer.Visible = false;
                    pnContract.Visible = true;
                }
                else if (AccessLevel == GlobalEnum.AccessLevel_Caterer)
                {
                    pnSponsor.Visible = false;
                    pnCaterer.Visible = true;
                    pnContract.Visible = true;
                }

                else if (AccessLevel == GlobalEnum.AccessLevel_All)
                {
                    pnSponsor.Visible = false;
                    pnCaterer.Visible = false;
                    pnContract.Visible = false;
                    btnSave.Visible = false;
                }
                
                PopContractGrid();
            }
            catch { }
        }
        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }


        private void PopContractGrid()
        {
            int sponsorID = 0;
            int catererID = 0;
            int staffID = 0;
            Int32.TryParse(ddlSponsor.SelectedValue, out sponsorID);
            Int32.TryParse(ddlCaterer.SelectedValue, out catererID);
            Int32.TryParse(lblStaffID.Text, out staffID);
            if (AccessLevel == GlobalEnum.AccessLevel_CateringContract) PopContractGrid(0, 0);//show all contracts, not just sponsor's contracts
            else PopContractGrid(sponsorID, catererID);
            CheckContractGrid(staffID);
        }

        private void PopContractGrid(int sponsorID, int catererID)
        {
            if (sponsorID > 0)
            {
                try
                {
                    SimpleServingsLibrary.SupplierRelationship.Contracts contracts =
                        SimpleServingsLibrary.SupplierRelationship.Contract.GetContractBySponsorID(sponsorID);
                    ContractGrid1.PopGrid(contracts);
                }
                catch { }

            }
            else if (catererID > 0)
            {
                try
                {
                    SimpleServingsLibrary.SupplierRelationship.Contracts contracts =
                        SimpleServingsLibrary.SupplierRelationship.Contract.GetContractByCatererID(catererID);

                    ContractGrid1.PopGrid(contracts);

                }
                catch { }
            }
            else
            {

                try
                {
                    SimpleServingsLibrary.SupplierRelationship.Contracts contracts =
                        SimpleServingsLibrary.SupplierRelationship.Contract.GetContractAll();

                    ContractGrid1.PopGrid(contracts);

                }
                catch { }

            }
        }
        private void CheckContractGrid(int staffID)
        {
            try
            {
                SimpleServingsLibrary.Shared.StaffContracts sc = SimpleServingsLibrary.Shared.StaffContract.GetStaffContractsByStaffID(staffID);
                foreach (SimpleServingsLibrary.Shared.StaffContract staffContract in sc)
                {
                    ContractGrid1.CheckBoxOnGrid(staffContract.ContractID);
                }
            }
            catch
            {

            }
        }

        protected void ddlSponsor_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopContractGrid();
        }       

        protected void ddlCaterer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopContractGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int staffID = 0;
            Int32.TryParse(lblStaffID.Text, out staffID);
            SaveStaffAccessLevel(staffID);
        }

        public void SaveStaffAccessLevel(int staffID)
        {
            lblStaffID.Text = staffID.ToString();
            int accessLevel = 0;
            Int32.TryParse(lblGroupAccessLevel.Text, out accessLevel);

            if (accessLevel == GlobalEnum.AccessLevel_Sponsor)
            {
                int sponsorID = 0;
                Int32.TryParse(ddlSponsor.SelectedValue, out sponsorID);
                UpdateSupplierID(sponsorID);

            }
            else if (accessLevel == GlobalEnum.AccessLevel_Contract || accessLevel == GlobalEnum.AccessLevel_CateringContract)
            {
                int sponsorID = 0;
                Int32.TryParse(ddlSponsor.SelectedValue, out sponsorID);
                UpdateSupplierID(sponsorID);
                SaveContractIDs();
            }
            else if (accessLevel == GlobalEnum.AccessLevel_Caterer)
            {
                int catererID = 0;
                Int32.TryParse(ddlCaterer.SelectedValue, out catererID);
                UpdateSupplierID(catererID);
                SaveContractIDs();
            }
           

        }

        private void SaveContractIDs()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            int selectedStaffID = 0;
            Int32.TryParse(lblStaffID.Text, out selectedStaffID);
            SimpleServingsLibrary.Shared.StaffContract.RemoveStaffContractsByStaffID(selectedStaffID);
            List<int> IDs = new List<int>();
            IDs = ContractGrid1.GetSelectedContractIDs();
            SimpleServingsLibrary.Shared.StaffContract sc = new StaffContract();
            sc.StaffID = selectedStaffID;
            sc.CreatedBy = staff.StaffID;
            foreach (int contractID in IDs)
            {
                sc.ContractID = contractID;
                sc.AddStaffContract();
            }
        }

       

        private void UpdateSupplierID(int supplierID)
        {
            try
            {
                int staffID = 0;
                Int32.TryParse(lblStaffID.Text, out staffID);
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
                staff.SupplierID = supplierID;
                staff.EditStaff();
            }
            catch { }
        }

        protected void ddlUserGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userGroupID=0;
            Int32.TryParse(ddlUserGroupName.SelectedValue, out userGroupID);
            ViewModulePermissions1.PopPermissions(userGroupID);
            PopControls(userGroupID);
        }
    }
}