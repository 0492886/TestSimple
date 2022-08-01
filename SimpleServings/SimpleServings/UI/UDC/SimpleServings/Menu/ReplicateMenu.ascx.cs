using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class ReplicateMenu : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    PopDropDowns();
                    //ajaxModalPopup.Hide();
                    //pnlcontract.Visible = false;
                    int menuID = 0;
                    if (Request["MenuID"] != null)
                    {
                        Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                        PopMenu(menuID);                        
                        
                    }
                    PopMenuName(); //add Mandy
                }

                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }


          //  PopMenuName(); //if add this, can't write by hand in Menu name

        }


        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void PopDropDowns()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");

           

            SimpleServingsLibrary.Shared.Utility.GetMenuCycles(ddlCycle, Code.CodeTypes.Cycle, staff.UserGroup, "");
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlCycle, Code.CodeTypes.Cycle, staff.UserGroup, "0");
            GetCycleDates();

            //SimpleServingsLibrary.Shared.Codes cuisines = SimpleServingsLibrary.Shared.Code.GetCodesByType(Code.CodeTypes.Tag); //Cuisines
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
        private void PopMenu(int menuID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            try
            {
                menu.GetMenuByMenuID(menuID);
                //lblContract.Text = menu.ContractTypeName;
                //lblContractTypeID.Text = menu.ContractTypeID.ToString();
                ddlContract.SelectedValue = menu.ContractTypeID.ToString();
                //lblMealType.Text = menu.MealServedTypeIDText;
                //lblMealTypeID.Text = menu.MealServedTypeID.ToString();  //add Mandy
                lblMenuTypeID.Text = menu.MenuTypeID.ToString();

                //  add Mandy
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndDependsOnAndUserGroup(ddlMealType, Code.CodeTypes.MealServedType, Convert.ToInt32(menu.ContractTypeID.ToString()), staff.UserGroup, "");
                ddlMealType.SelectedValue = menu.MealServedTypeID.ToString(); //add Mandy

                if (menu.MenuTypeID == GlobalEnum.SampleMenu)
                {
                    ReplicateSampleMenu();

                }
                
                //txtMenuName.Text = menu.MenuName;    //       here is the name Mandy
                SimpleServingsLibrary.Menu.MenuDays days =
                    SimpleServingsLibrary.Menu.MenuDay.GetMenuDaysByMenuID(menuID);

                //rptDays.DataSource = days;
                //rptDays.DataBind();
                BindDaysinWeekCheckBoxList(menu.MenuID);

                //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlDietType, Code.CodeTypes.DietType, staff.UserGroup, "");
                SimpleServingsLibrary.Shared.Utility.GetDietTypeCodesByStaffID(ddlDietType, staff.StaffID, "");                
                ddlDietType.SelectedValue = menu.DietTypeID.ToString();
                //if (SimpleServingsLibrary.Menu.Menu.AreAllMenuWeeksComplete(menuID))
                //   btnSubmit.Enabled = true;

                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlContract, Code.CodeTypes.ContractType, staff.UserGroup, menu.ContractTypeID.ToString());
                if (menu.MenuTypeID != GlobalEnum.SampleMenu)
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


                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlMealServedFormat, Code.CodeTypes.MealServedFormat, staff.UserGroup, "");  //add
                ddlMealServedFormat.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));

            }
            catch
            { }
        }

        private void BindDaysinWeekCheckBoxList(int menuID)
        {
            SimpleServingsLibrary.Shared.Codes days = SimpleServingsLibrary.Shared.Code.GetCodesByType(Code.CodeTypes.DayOfWeek);
            cblDays.DataSource = days;
            cblDays.DataTextField = "CodeDescription";
            cblDays.DataValueField = "CodeID";
            cblDays.DataBind();

            List<int> daysofWeek = new List<int>();
            daysofWeek = SimpleServingsLibrary.Menu.MenuItem.GetDaysOfWeekByMenuID(menuID);

            foreach (int i in daysofWeek)
            {
                cblDays.Items.FindByValue(i.ToString()).Selected = true;
            }
 
        }



        private void GetValuesFromControls(ref SimpleServingsLibrary.Menu.Menu menu)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");          
            
            menu.CreatedBy = staff.StaffID;
            menu.MenuName = txtMenuName.Text.Trim();

            int contractTypeID = 0;
            //Int32.TryParse(lblContractTypeID.Text, out contractTypeID);
            Int32.TryParse(ddlContract.SelectedValue.ToString(), out contractTypeID);
            menu.ContractTypeID = contractTypeID;

            int mealServedType = 0;
           //  Int32.TryParse(lblMealTypeID.Text, out mealServedType);
           Int32.TryParse(ddlMealType.SelectedValue.ToString(), out mealServedType); //add Mandy
            menu.MealServedTypeID = mealServedType;

            int cycleID = 0;
            Int32.TryParse(ddlCycle.SelectedValue, out cycleID);
            menu.CycleID = cycleID;

            int dietTypeID = 0;
            Int32.TryParse(ddlDietType.SelectedValue, out dietTypeID);
            menu.DietTypeID = dietTypeID;

            menu.StartDate = txtStartDate.Text.Trim();
            menu.EndDate = txtEndDate.Text.Trim();
            menu.CreatedBy = staff.StaffID;
            menu.MenuName = txtMenuName.Text.Trim();

            int MealServedFormatID = 0;
            Int32.TryParse(ddlMealServedFormat.SelectedValue, out MealServedFormatID);
            menu.MealServedFormatID = MealServedFormatID;

        }

        private int SaveMenu(string NewWeekOrder)
        {
            int newMenuID = 0;
           
            try
            {
                 int originalMenuID = 0;
                 
                 if (Request["MenuID"] != null)
                 {
                     Int32.TryParse(Request["MenuID"].ToString(), out originalMenuID);


                     SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                     GetValuesFromControls(ref menu);

                     if(Convert.ToInt32(lblMenuTypeID.Text) != GlobalEnum.SampleMenu)
                     {
                         List<int> selectedContractIDs = new List<int>();
                         selectedContractIDs = ReturnSelectedContracts();

                        if (selectedContractIDs.Count < 1)                      //add Mandy
                        {
                            throw new Exception("Please Select at least one Contract!");

                        }
                        menu.ContractsIDs = selectedContractIDs;
                     }

                    ValidateMealServedFormat();
                    ValidateCuisine();
                    // 1. Replicate New Menu 
                    newMenuID = menu.ReplicateMenuNew(originalMenuID);

                     // 2. Add number of days in Week before adding MenuItems so that only items for selected days will be duplicated
                     SimpleServingsLibrary.Menu.MenuDay day = new SimpleServingsLibrary.Menu.MenuDay();
                     int dayOfWeekID = 0;

                     foreach (ListItem cb in cblDays.Items)
                     {
                         if (cb.Selected)
                         {
                             day.MenuID = newMenuID;
                             Int32.TryParse(cb.Value, out dayOfWeekID);
                             day.DayOfWeekID = dayOfWeekID;
                             day.AddMenuDay();
                         }
                     }

                     // Duplicate Menu Items 
                     SimpleServingsLibrary.Menu.MenuItem.DuplicateMenuItems(originalMenuID, newMenuID, false);

                     
                     // Swap Week Order for the replicated Menu 
                     if (cbSwapWeek.Checked == true  && (NewWeekOrder != "" || NewWeekOrder != string.Empty))
                     {
                         SimpleServingsLibrary.Menu.Menu.SwapWeeksForMenu(newMenuID, NewWeekOrder);                         
 
                     }



                     

                     //lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
                     //lblMsg.Text = "Menu successfully saved";
                     //lblMsg.Visible = true;
                 }
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
            return newMenuID;
        }

        private List<int> ReturnSelectedContracts()
        {
            List<int> selectedContractIDs = new List<int>();
            selectedContractIDs = ucContractList.getCurrentContratcList();

            //if (selectedContractIDs.Count < 1)   // put in SaveMenu(string NewWeekOrder)
            //{
            //    throw new Exception("Please Select at least one Contract!");

            //}

            return selectedContractIDs;
        }



        private void ReplicateSampleMenu()
        {
            ddlCycle.ClearSelection();
            // Code to add cycle, start date and end date to a sample menu
            ddlCycle.Items.Cast<ListItem>().Where(x => x.Text == "Fall/Winter").First().Selected = true;
            GetCycleDates();
            divCycleRange.Visible = false;
            divSelectCont.Visible = false;
 
        }


        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            int menuID = 0;

            bool allWeekSelected = true;
            string NewWeekOrder = "";
            if (cbSwapWeek.Checked == true)
            {
                NewWeekOrder = hdnWeek.Value;
                NewWeekOrder = NewWeekOrder.Replace(System.Environment.NewLine, ",").Replace(",,", ",").Replace("Week", "").Replace(" ","");
                //System.Text.RegularExpressions.Regex.Replace(NewWeekOrder,@"\s+","");

                for (int i = 1; i < 7; i++)
                {
                    if (!NewWeekOrder.Contains(i.ToString()))
                    {
                        lblMsg.Text = "Please drag and drop all Weeks!!";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        allWeekSelected = false;
                        break;
                    }
                    else
                    { 
                        allWeekSelected = true;
                    }
                }
            }

            if (allWeekSelected == true)
            {
                menuID = SaveMenu(NewWeekOrder);
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

        private void GetCycleDates()
        {
            int cycle = 0;
            Int32.TryParse(ddlCycle.SelectedValue, out cycle);

            try
            {
                SimpleServingsLibrary.Menu.MenuCycle mc = new SimpleServingsLibrary.Menu.MenuCycle();
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

        protected void ddlDietTypeContractType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ucContractList.PopGrid(null);
            divContractGrid.Visible = false;

            //divSampleMenuList.Visible = false;
            //ucMenuGrid1.PopGrid(null);
            //cblDays.ClearSelection();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            List<int> Ids = new List<int>();
            //ajaxModalPopup.Hide();
            Ids = ucContractGrid.GetSelectedContractIDs();
            ucContractList.PopSelectedContracts(Ids);
            divContractGrid.Visible = true;
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "$(function() {$('#dialog').dialog('close');});", true);
        }

        protected void btnSelectcontract_Click(object sender, EventArgs e)
        {
            PopContractGrid();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "$(function() {$('#dialog').dialog('open');});", true);
            //pnlcontract.Visible = true;
            //ajaxModalPopup.Show();

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
                //Int32.TryParse(lblContractTypeID.Text, out ContractTypeID);
                Int32.TryParse(ddlContract.SelectedValue.ToString(), out ContractTypeID);
                int dietTypeID = 0;
                Int32.TryParse(ddlDietType.SelectedValue, out dietTypeID);

                int mealTypeID = 0;
                //Int32.TryParse(lblMealTypeID.Text, out mealTypeID);

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

        protected void cbSwapWeek_CheckedChanged(object sender, EventArgs e)
        {
            bool ischecked = cbSwapWeek.Checked;
            divSwap.Visible = (ischecked? true : false);
            //divOriginalOrder.Visible = (ischecked ? true : false);
            //divNewWeek.Visible = (ischecked ? true : false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "$(function() {$('#dialog').dialog('close');});", true);
            //ajaxModalPopup.Hide();
            //pnlcontract.Visible = false;
        }

        protected void ddlMealType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMenuName();
        }

        protected void cblCuisines_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMenuName();
        }

        protected void ddlMealServedFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMenuName();
        }
        private void PopMenuName()
        {
            string contractNames = null;

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            List<int> selectedContractsId = ReturnSelectedContracts();

            if (selectedContractsId != null && staff != null && (staff.UserGroup == 1 || staff.UserGroup == 7 || staff.UserGroup == 8))           
            {
                int MenuID = Convert.ToInt32(Request["MenuID"].ToString());
                // replicate from caterer
                bool isCaterer = SimpleServingsLibrary.Shared.Utility.IsCatererByMenuID(MenuID);
                if (isCaterer == true)
                {
                    string catererName = SimpleServingsLibrary.Shared.Utility.GetCatererNameByMenuID(MenuID);
                    contractNames = catererName;
                }
                else
                {
                    contractNames = "DFTA";
                }
                
            }
            else
            {
                List<KeyValuePair<int, string>> selectedContracts = new List<KeyValuePair<int, string>>();
                selectedContracts = ucContractList.getCurrentContratcListName();
                foreach (int contractId in selectedContractsId)
                {

                    string catererName = SimpleServingsLibrary.Shared.Utility.GetCatererByContractID(contractId, staff.StaffID);
                    if (!String.IsNullOrEmpty(catererName))
                    {
                        if (contractNames == null || !contractNames.Contains(catererName))
                        {
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
                        if (!contractEdited.Contains("NSC"))
                        {
                            var words = contract.Split();
                            contractEdited = words[0] + " " + ((words.Length >= 2) ? words[1] : "");
                        }
                        contractNames += (contractNames != null ? "," : "");
                        contractNames += contractEdited;
                    }
                }
            }
            string cuisines = null;
            foreach (ListItem cb in cblCuisines.Items)
            {
                if (cb.Selected)
                {
                    cuisines += (cuisines != null ? "," : "");
                    cuisines += cb.Text;
                }
            }
            //cuisines = cuisines != null ? cuisines + "-Cuisines" + " " : "";
            cuisines = cuisines != null ? cuisines  + " " : "";
            contractNames = contractNames != null ? contractNames + " " : "";
            string CycleType = ddlCycle.SelectedValue != "0" ? ddlCycle.SelectedItem.Text + " " : "";
            string year = String.IsNullOrEmpty(txtEndDate.Text) ? "" : txtEndDate.Text.Substring(txtEndDate.Text.Length - 4);
            string pgmType = Convert.ToInt32(ddlContract.SelectedValue) == 43 ? "CONG " : "HDML ";
            //string mealType = ddlMealType.SelectedValue != "0" ? ddlMealType.SelectedItem.Text + "-Menu" + " " : "";
            string mealType = ddlMealType.SelectedValue != "0" ? ddlMealType.SelectedItem.Text  + " " : "";
            //string dietType = ddlDietType.SelectedValue != "0" ? ddlDietType.SelectedItem.Text+" " : "";

            string mealServedFormat = ddlMealServedFormat.SelectedValue != "0" ? ddlMealServedFormat.SelectedItem.Text : "";
            int daysCount = cblDays.Items.Cast<ListItem>().Count(li => li.Selected);
            string days = daysCount > 0 ? daysCount + " Days" : "";
            //txtMenuName.Text = contractNames + " " + pgmType + days + " " + mealType + " " + cuisines + " " + CycleType + " " + year;
           // txtMenuName.Text = contractNames + " " + mealType + " " + cuisines + " " + CycleType + " " + year;

            txtMenuName.Text = contractNames + " " + mealType + " " + mealServedFormat + " " + cuisines + " " + CycleType + " " + year;
            txtMenuName.DataBind();

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

    }
}