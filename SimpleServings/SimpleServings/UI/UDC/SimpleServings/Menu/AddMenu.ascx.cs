using SimpleServingsLibrary.Menu;
using SimpleServingsLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class AddMenu : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                ApplyPermissions();
                if (!Page.IsPostBack)
                {
                    PopDropDowns();
                    PopMenuName();
                    if (Request["MenuType"] != null)
                    {
                        string menuListType = Request["MenuType"].ToString();
                        switch (menuListType)
                        {
                            case "AddMenuUsingSample":
                                AddMenuUsingSampleMenu();
                                break;
                            case "SampleMenu":
                                AddSampleMenu();
                                break;
                            default:
                                //Code to add Blank Menu
                                break;
                        }
                    }
                }
                else
                {
                    // PopMenuName();   // if uncomment, txtMenuName can't write by user
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
            SimpleServingsLibrary.Shared.Staff staff = HelpClasses.AppHelper.GetCurrentUser();  //(SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        private void PopMenuName()
        {
            string contractNames = null;
            
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            List<int> selectedContractsId = ReturnSelectedContracts();

            if (selectedContractsId != null && staff != null && (staff.UserGroup == 1 || staff.UserGroup == 7 || staff.UserGroup == 8))
            {
                contractNames = "DFTA";
                txtMenuName.Enabled = true; //add
            }
            else
            {
                txtMenuName.Enabled = false; //add
                List<KeyValuePair<int, string>> selectedContracts = new List<KeyValuePair<int, string>>();
                selectedContracts = ucContractList.getCurrentContratcListName();
                // for Caterer
              if (selectedContracts.Count == 0 && (staff.UserGroup == 5 || staff.UserGroup == 9))
              {
                    SimpleServingsLibrary.SupplierRelationship.Caterer caterer = SimpleServingsLibrary.SupplierRelationship.Caterer.GetCatererByID(staff.SupplierID);
                    string catererName = caterer.CatererName;
                    contractNames += catererName;
                }
              else { //for contractor

                foreach (int contractId in selectedContractsId)
                {
                    
                    string catererName = SimpleServingsLibrary.Shared.Utility.GetCatererByContractID(contractId, staff.StaffID);  //get caterer name
                    if (!String.IsNullOrEmpty(catererName) && (staff.UserGroup == 5 || staff.UserGroup == 9))
                    {
                        if (contractNames == null || !contractNames.Contains(catererName))
                        {
                            //contractNames += (contractNames != null ? "," : "");
                                contractNames += (contractNames != null ? "," : "");
                                contractNames += catererName;
                        }
                    }
                    else
                    {
                        string contract = selectedContracts.First(kvp => kvp.Key == contractId).Value;
                        string contractEdited = contract.Replace("NEIGHBORHOOD SENIOR CENTER", "NSC")
        .Replace("NEIGHBORHOOD SENIOR CTR", "NSC")
        .Replace("NEIGHBORHOOD SR CITIZENS C", "NSC")
        .Replace("NEIGHBORHOOD SC", "NSC")
        .Replace("SENIOR CENTER", "NSC")
        .Replace("NEIGHBORHOOD CENTER", "NSC")
        .Replace("CENTER", "NSC")
        .Replace("ISLAND SENIOR CENTER", "ISC")
        .Replace("NSC", "NSC")
        .Replace("NEIGHBORHOOD SR CTR", "NSC")
        .Replace("NBH SR CTR", "NSC")
        .Replace("SR CTR", "NSC")
        .Replace("NC", "NSC")
        .Replace("NBH SR CTZ CTR", "NSC")
        .Replace("NEIGHBORHOOD SR CITIZENS CTR", "NSC")
        .Replace("NEIGHBORHOOD SENIOR", "NSC")
        .Replace("NEIGHBORHOOD SENIOR CENTE", "NSC")
        .Replace("NEIGHBORHOOD SENIOR CENT", "NSC")
        .Replace("NEIGHBORHOOD SR CT", "NSC")
        .Replace("NEIGHBR SC", "NSC")
        .Replace("NEIGHBORHOOD SENIOR CENTER", "NSC")
        .Replace("NBRHD SR CTR", "NSC")
        .Replace("NEIGHBORHOOD SENIOR CEN", "NSC")
        .Replace("NEIGHBRHD SC", "NSC")
        .Replace("SR.CTR", "NSC")
        .Replace("NBH SR CT", "NSC")
        .Replace("NEIGHNEIGHBORHOOD SENIOR CITIZENS CTR", "NSC")
        .Replace("BR SR CTR", "NSC");
                        if (!contractEdited.Contains("NSC")) {
                            var words = contract.Split();
                            contractEdited = words[0] + " " + ((words.Length >=2)? words[1] : "");
                         }
                        contractNames += (contractNames != null ? "," : "");
                        contractNames += contractEdited;
                    }
                }

              }


            }
            string cuisines = null;
            foreach (ListItem cb in cblCuisines.Items)
            {
                if (cb.Selected)
                {
                    //cuisines += (cuisines != null ? "," : "");
                    cuisines += (cuisines != null ? ", " : "");
                    cuisines += cb.Text;
                }
            }
            //cuisines = cuisines != null ? cuisines + "-Cuisines" + " " : "";
            cuisines = cuisines != null ? cuisines  + " " : "";
            contractNames = contractNames != null ? contractNames + " " : "";
            string CycleType = ddlCycle.SelectedValue != "0" ? ddlCycle.SelectedItem.Text + " " : "";
            string year = String.IsNullOrEmpty(txtEndDate.Text) ? "" : txtEndDate.Text.Substring(txtEndDate.Text.Length -4);
            string pgmType = Convert.ToInt32(ddlContract.SelectedValue) == 43 ? "CONG " : "HDML ";
            //string mealType = ddlMealType.SelectedValue != "0" ? ddlMealType.SelectedItem.Text + "-Menu" +" " : "";
            string mealType = ddlMealType.SelectedValue != "0" ? ddlMealType.SelectedItem.Text  + " " : "";
            string mealServedFormat = ddlMealServedFormat.SelectedValue !="0"? ddlMealServedFormat.SelectedItem.Text: "";
            //string dietType = ddlDietType.SelectedValue != "0" ? ddlDietType.SelectedItem.Text+" " : "";
            int daysCount = cblDays.Items.Cast<ListItem>().Count(li => li.Selected);
            string days = daysCount > 0 ? daysCount + " Days" : "";
            //txtMenuName.Text = contractNames + " " + pgmType + days + " " + mealType + " " + cuisines + " " + CycleType + " " + year;
            txtMenuName.Text = contractNames + " " + mealType + " " + mealServedFormat +" "+ cuisines + " " + CycleType + " " + year;

            txtMenuName.Attributes.Add("ReadOnly", "ReadOnly");  //Mandy add, user can't mantually input 
            txtMenuName.DataBind(); 

        }
        private void PopDropDowns()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");

            //try
            //{
            //    SimpleServingsLibrary.SupplierRelationship.Contracts contracts =
            //        SimpleServingsLibrary.SupplierRelationship.Contract.GetContractAll();
            //    ddlContract.DataSource = contracts;
            //    ddlContract.DataTextField = "ContractName";
            //    ddlContract.DataValueField = "ContractID";
            //    ddlContract.DataBind();
            //    ddlContract.Items.Insert(0, new ListItem("[Select]", "0"));
            //}
            //catch { }
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlContract, Code.CodeTypes.ContractType, staff.UserGroup, "");

            if (Request["MenuType"] != "SampleMenu")
            {
                foreach (ListItem i in ddlContract.Items)
                {
                    if (i.Value == GlobalEnum.ContractType_CongregateSlashHomeDelivered.ToString())
                    {
                        ddlContract.Items.Remove(i);
                        break;
                    }

                }
            }
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(cblCuisines,Code.CodeTypes.CuisineType, staff.UserGroup);
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndDependsOnAndUserGroup(ddlMealType, Code.CodeTypes.MealServedType, Convert.ToInt32(ddlContract.SelectedValue), staff.UserGroup, "");

            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlMealServedFormat, Code.CodeTypes.MealServedFormat, staff.UserGroup, "");  //add
            ddlMealServedFormat.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));

            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlDietType, Code.CodeTypes.DietType, staff.UserGroup, "");
            SimpleServingsLibrary.Shared.Utility.GetDietTypeCodesByStaffID(ddlDietType, staff.StaffID, "");
            SimpleServingsLibrary.Shared.Utility.GetMenuCycles(ddlCycle, Code.CodeTypes.Cycle, staff.UserGroup, "");
            GetCycleDates();
            ucContractList.PopGrid(null);
            //Session["Contracts"] = null;

            try
            {
                SimpleServingsLibrary.Shared.Codes days = SimpleServingsLibrary.Shared.Code.GetCodesByType(Code.CodeTypes.DayOfWeek);
                cblDays.DataSource = days;
                cblDays.DataTextField = "CodeDescription";
                cblDays.DataValueField = "CodeID";
                cblDays.DataBind();
                SimpleServingsLibrary.Shared.Codes cuisines = SimpleServingsLibrary.Shared.Code.GetCodesByTypeMenu(Code.CodeTypes.Tag); //Cuisines

                cblCuisines.DataSource = cuisines;
                cblCuisines.DataTextField = "Comment";
                cblCuisines.DataValueField = "CodeID";
                cblCuisines.DataBind();
                for (int i = cblCuisines.Items.Count - 1; i >= 0; i--)
                {
                    if (String.IsNullOrEmpty(cblCuisines.Items[i].Text))
                    {
                        cblCuisines.Items.RemoveAt(i);
                    }

                }
            }
            catch
            {
                cblDays.DataSource = null;
                cblDays.DataBind();
                cblCuisines.DataSource = null;
                cblCuisines.DataBind();

            }

        }

        protected void ddlContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndDependsOnAndUserGroup(ddlMealType, Code.CodeTypes.MealServedType, Convert.ToInt32(ddlContract.SelectedValue), staff.UserGroup, "");
                PopMenuName();
            }
            catch { }
        }

        private void GetValuesFromControls(ref SimpleServingsLibrary.Menu.Menu menu)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");

            int contractTypeID = 0;
            Int32.TryParse(ddlContract.SelectedValue, out contractTypeID);
            menu.ContractTypeID = contractTypeID;
            int mealServedType = 0;
            Int32.TryParse(ddlMealType.SelectedValue, out mealServedType);
            menu.MealServedTypeID = mealServedType;

            int dietTypeID = 0;
            Int32.TryParse(ddlDietType.SelectedValue, out dietTypeID);
            menu.DietTypeID = dietTypeID;

            int cycleID = 0;
            Int32.TryParse(ddlCycle.SelectedValue, out cycleID);
            menu.CycleID = cycleID;
            menu.StartDate = txtStartDate.Text.Trim();
            menu.EndDate = txtEndDate.Text.Trim();
            menu.CreatedBy = staff.StaffID;
            menu.MenuName = SimpleServingsLibrary.Menu.Menu.ValidateMenuName(HttpUtility.HtmlEncode(txtMenuName.Text.Trim()));
           

            int MealServedFormatID = 0;
            Int32.TryParse(ddlMealServedFormat.SelectedValue, out MealServedFormatID);
            menu.MealServedFormatID = MealServedFormatID;

        }


        private int SaveSampleMenu()
        {
            int menuid = 0;

            try
            {
                ValidateDaysOfService();
                ValidateMealServedFormat(); //add Mandy
                ValidateCuisine();  //add Mandy
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                GetValuesFromControls(ref menu);

                int contractTypeID = 0;
                Int32.TryParse(ddlContract.SelectedValue, out contractTypeID);
                menu.ContractTypeID = contractTypeID;
                menuid = menu.AddSampleMenu();

                // Add Days for the Menu
                AddMenuDays(menuid);

                //lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
                //lblMsg.Text = "Sample Menu successfully saved";
                //lblMsg.Visible = true;           

            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }

            return menuid;
        }
        //add new
        private void ValidateCuisine()
        {
            bool tagged = false;
            foreach (ListItem cb in cblCuisines.Items)
            {
                if (cb.Selected)
                {
                    tagged = true;
                    break;
                }
            }
            if (!tagged)
                throw new Exception("Recipe Tags are required!<br/>");
        }
        private int SaveMenu()
        {
            int menuID = 0;
            try
            {
                ValidateDaysOfService();
                ValidateMealServedFormat(); //add
                ValidateCuisine();
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                GetValuesFromControls(ref menu);

                List<int> selectedContractIDs = new List<int>();
                selectedContractIDs = ReturnSelectedContracts();
                menu.ContractsIDs = selectedContractIDs;
                menuID = menu.AddMenu();

                // Add Days for the Menu
                AddMenuDays(menuID);
                AddMenuCusine(menuID);

            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
            return menuID;
        }


        private int SaveMenuUsingSampleMenu()
        {
            // Get Selected Contracts
            List<int> selectedContractIDs = new List<int>();
            selectedContractIDs = ReturnSelectedContracts();
            if (selectedContractIDs.Count < 1)
            {
                //throw new Exception("Please Select at least one Contract!");
                lblMsg.Text = "*Please Select at least one Contract!";
                return 0;

            }

            // Get Selected Sample Menu
            int sampleMenuID = 0;
            sampleMenuID = ReturnSelectedSampleMenu();
            if (sampleMenuID == 0)
            {
                //throw new Exception("*Please select a Sample Menu!"); 
                lblMsg.Text = "*Please select a Sample Menu!";
                return 0;
            }

            ValidateDaysOfService();
            ValidateMealServedFormat(); //add Mandy
            
            ValidateCuisine();
            lblMsg.Text = "";
            // 1. Add Menu                         
            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            GetValuesFromControls(ref menu);
            menu.ContractsIDs = selectedContractIDs;
            menu.OriginalMenuID = sampleMenuID;
            int menuID = 0;
            menuID = menu.AddMenuUsingSample();

            // 2. Add number of days in Week before adding MenuItems so that only items for selected days will be duplicated
            List<int> selectedDays = new List<int>();
            selectedDays = AddMenuDays(menuID);


            //2. Add MenuItems from Sample menu 
            // Duplicate Menu Items 
            SimpleServingsLibrary.Menu.MenuItem.DuplicateMenuItems(sampleMenuID, menuID, false);
            AddMenuCusine(menuID);
            return menuID;
        }


        private List<int> ReturnSelectedContracts()
        {
            List<int> selectedContractIDs = new List<int>();
            selectedContractIDs = ucContractList.getCurrentContratcList();
            return selectedContractIDs;
        }

        //add new
        private List<int> ReturnSelectedCuisines()
        {
            List<int> selectedCuisineIDs = new List<int>();
            selectedCuisineIDs = ucContractList.getCurrentContratcList();
            return selectedCuisineIDs;
        }


        private int ReturnSelectedSampleMenu()
        {
            int sampleMenuID = 0;
            sampleMenuID = ucMenuGrid1.getSelectedSampleMenu();
            return sampleMenuID;
        }

        private void ValidateDaysOfService()
        {
            bool isSelected = false;
            foreach (ListItem cb in cblDays.Items)
            {
                if (cb.Selected)
                {
                    isSelected = true;
                    return;
                }
            }
            if (!isSelected)
                throw new Exception("Days Of Service Is Required!");
        }
        private void ValidateMealServedFormat()   //add
        {
            bool isSelect = false;
            if (ddlMealServedFormat.SelectedValue.ToString() != "0")
            {
                isSelect = true;
                return;
            }
            if (!isSelect)
                throw new Exception("Meal Served Format is Required");
        }
        public void AddSampleMenu()
        {
            SimpleServingsLibrary.Shared.Staff staff = HelpClasses.AppHelper.GetCurrentUser();  //(SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            lblAddMenuHeader.Text = "Add Sample Menu";
            
            ddlContract.SelectedValue = "131";
           // ddlContract.Enabled = false;

            //ddlSampleMenuProgramType.Visible = true;
            ddlCycle.ClearSelection();
            // Test code to add cycle, start date and end date to a sample menu
            ddlCycle.Items.Cast<ListItem>().Where(x => x.Text == "Fall/Winter").First().Selected = true;
            GetCycleDates();
            divCycleRange.Visible = false;
            ddlDietType.Enabled = true;
            divSelectCont.Visible = false;

        }


        private List<int> AddMenuDays(int menuID)
        {
            List<int> selecteddays = new List<int>();
            SimpleServingsLibrary.Menu.MenuDay day = new SimpleServingsLibrary.Menu.MenuDay();
            int dayOfWeekID = 0;

            foreach (ListItem cb in cblDays.Items)
            {
                if (cb.Selected)
                {
                    day.MenuID = menuID;
                    Int32.TryParse(cb.Value, out dayOfWeekID);
                    day.DayOfWeekID = dayOfWeekID;
                    day.AddMenuDay();

                    if (!selecteddays.Contains(dayOfWeekID))
                    {
                        selecteddays.Add(dayOfWeekID);
                    }
                }
            }

            return selecteddays;
        }

        //add new
        private void AddMenuCusine(int menuID)
        {

            try
            {
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                //Response.Redirect("~/UI/Page/login.aspx");          

                menu.CreatedBy = staff.StaffID;
                foreach (ListItem cb in cblCuisines.Items)
                {
                    if (cb.Selected)
                    {
                        //Cuisine.Add(Int32.Parse(cb.Value));
                        menu.AddCuisine(menuID, Int32.Parse(cb.Value));
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        private void AddMenuUsingSampleMenu()
        {
            SimpleServingsLibrary.Shared.Staff staff = HelpClasses.AppHelper.GetCurrentUser();  //(SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            // if creating a new menu from SampleMenu selected from View Menu screen
            if (Request["MenuID"] != null)
            {
                string menuid = Request["MenuID"].ToString();

                int menuID = 0;
                Int32.TryParse(menuid, out menuID);

                SimpleServingsLibrary.Menu.Menu _menu = new SimpleServingsLibrary.Menu.Menu();
                _menu.GetMenuByMenuID(menuID);

                SelectedSampleMenu(_menu, staff);
                ddlDietType.SelectedValue = _menu.DietTypeID.ToString();
                ddlDietType.Enabled = false;
                ddlMealType.ClearSelection();
                ddlMealType.SelectedValue = _menu.MealServedTypeID.ToString();
            }
            else
            {
                divSelectSample.Visible = true;
            }
        }

        //add new
        protected void ddlMealType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMenuName();
        }

        //add new
        protected void cblCuisines_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMenuName();
        }

        //add new
        protected void cblDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMenuName();
        }

        protected void ddlMealServedFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMenuName();
        }
        protected void ddlDietType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ucContractList.PopGrid(null);
            divContractGrid.Visible = false;

            divSampleMenuList.Visible = false;
            ucMenuGrid1.PopGrid(null);

            cblDays.ClearSelection();
            PopMenuName();
        }



        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            int menuID = 0;

            //ADD CODE TO CHECK IF THE DIET TYPE SELECTED HAS THRESHOLDS SET OR NOT

            //SimpleServingsLibrary.MenuThreshold.MenuThresholds menuThresholds = new SimpleServingsLibrary.MenuThreshold.MenuThresholds();
            //if (ddlDietType.SelectedIndex != 0)
            //{
            //    menuThresholds = SimpleServingsLibrary.MenuThreshold.MenuThreshold.GetMenuThresholdByMealServedType(Convert.ToInt32(ddlMealType.SelectedValue));

            //}

            if (Request["MenuType"] != null)
            {
                string menuListType = Request["MenuType"].ToString();
                switch (menuListType)
                {
                    case "AddMenuUsingSample":
                        //Create Regular Menu using Sample Menu
                        menuID = SaveMenuUsingSampleMenu(); //here
                        break;
                    case "SampleMenu":
                        //Add Sample Menu
                        menuID = SaveSampleMenu();
                        break;
                    default:
                        //Add Blank Menu
                        menuID = SaveMenu();
                        break;
                }
            }


            if (menuID > 0)
            {
                string url = ResolveUrl("~/UI/Page/SimpleServings/Menu/AddMenuItem.aspx?MenuID=" + menuID);
                Response.Redirect(url);
            }

        }
        
        protected void ddlCycle_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetCycleDates();
            PopMenuName();
        }

        //add new
        protected void txtEndDate_TextChanged(object sender, EventArgs e)
        {

            PopMenuName();
        }

        private void GetCycleDates()
        {
            int cycle = 0;
            Int32.TryParse(ddlCycle.SelectedValue, out cycle);

            try
            {
                SimpleServingsLibrary.Menu.MenuCycle mc = new MenuCycle();
                mc.GetMenuCycleByCycleId(cycle);
                txtStartDate.Text = mc.CycleStartDate;
                txtEndDate.Text = mc.CycleEndDate;
            }
            catch
            {
                txtStartDate.Text = String.Empty;
                txtEndDate.Text = String.Empty;
            }
        }

        protected void btnSelectcontract_Click(object sender, EventArgs e)
        {
            PopContractGrid();
            ajaxModalPopup.Show();
            PopMenuName();

        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            List<int> Ids = new List<int>();
            Ids = ucContractGrid.GetSelectedContractIDs();
            ucContractList.PopSelectedContracts(Ids);
            ajaxModalPopup.Hide();
            divContractGrid.Visible = true;
            lblMsg.Text = "";
            PopMenuName();
       
        }


        private void PopContractGrid()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            try
            {

                List<int> selectedContractIDs = new List<int>();
                //selectedContractIDs = ucContractGrid.GetSelectedContractIDs();

                selectedContractIDs = ucContractList.getCurrentContratcList();


                int ContractTypeID = 0;
                Int32.TryParse(ddlContract.SelectedValue, out ContractTypeID);

                int dietTypeID = 0;
                Int32.TryParse(ddlDietType.SelectedValue, out dietTypeID);

                int mealTypeID = 0;
                Int32.TryParse(ddlMealType.SelectedValue, out mealTypeID);

                SimpleServingsLibrary.SupplierRelationship.Contracts contracts =
                    SimpleServingsLibrary.SupplierRelationship.Contract.GetContractsByStaffIDContractTypeDietType(staff.StaffID, ContractTypeID, dietTypeID, mealTypeID);
                ucContractGrid.PopGrid(contracts);

                if (selectedContractIDs.Count > 0)
                {
                    ucContractGrid.CheckSelectedContractsonGird(selectedContractIDs);

                }
            }
            catch
            {
                ucContractGrid.PopGrid(null);

            }
        }

        private void PopViewSamplesGrid()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            SimpleServingsLibrary.Menu.Menus sampleMenus = new SimpleServingsLibrary.Menu.Menus();
            try
            {
                sampleMenus = SimpleServingsLibrary.Menu.Menu.GetSampleMenusByMenuStatus(staff.StaffID, GlobalEnum.MenuStatus_SampleMenuComplete);
            }
            catch
            {
            }

            // Get all sample menus and filter the list by the selected DietTypeID
            int dietTypeID = 0;
            Int32.TryParse(ddlDietType.SelectedValue, out dietTypeID);
            var menus = sampleMenus.Where(x => x.DietTypeID == dietTypeID);

            SimpleServingsLibrary.Menu.Menus _Menus = new SimpleServingsLibrary.Menu.Menus();
            menus.ToList().ForEach(x => { _Menus.Add(x); });


            ucMenuGrid.PopGrid(_Menus);
            ucMenuGrid.ViewSampleMenuGrid(true, staff.UserGroup, true);

            int selectedSampleMenuID = 0;
            selectedSampleMenuID = ucMenuGrid1.getSelectedSampleMenu();
            if (selectedSampleMenuID > 0)
            {
                ucMenuGrid.setCurrentSampleMenu(selectedSampleMenuID);

            }

        }

        private void SelectedSampleMenu(SimpleServingsLibrary.Menu.Menu SampleMenu, SimpleServingsLibrary.Shared.Staff staff)
        {
            SimpleServingsLibrary.Menu.Menus _Menus = new SimpleServingsLibrary.Menu.Menus();
            _Menus.Add(SampleMenu);

            ucMenuGrid1.PopGrid(_Menus);
            ucMenuGrid1.ViewSampleMenuGrid(true, staff.UserGroup, true);
            ucMenuGrid1.HideRadioButtonColumn();
            divSampleMenuList.Visible = true;

            SimpleServingsLibrary.Menu.MenuItems menuitems = new SimpleServingsLibrary.Menu.MenuItems();
            List<int> daysofWeek = new List<int>();
            daysofWeek = SimpleServingsLibrary.Menu.MenuItem.GetDaysOfWeekByMenuID(SampleMenu.MenuID);

            cblDays.ClearSelection();
            foreach (int i in daysofWeek)
            {
                cblDays.Items.FindByValue(i.ToString()).Selected = true;
            }

        }


        protected void btnSelectSampleMenu_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            int selectedMenuItem = ucMenuGrid.getSelectedSampleMenuItem();
            SimpleServingsLibrary.Menu.Menu _menu = new SimpleServingsLibrary.Menu.Menu();
            _menu.GetMenuByMenuID(selectedMenuItem);
            SelectedSampleMenu(_menu, staff);
            lblMsg.Text = "";
            
        }


        protected void lnkSelectSample_Click(object sender, EventArgs e)
        {

            PopViewSamplesGrid();
            ajaxPopupSampleMenu.Show();
        }







    }
}