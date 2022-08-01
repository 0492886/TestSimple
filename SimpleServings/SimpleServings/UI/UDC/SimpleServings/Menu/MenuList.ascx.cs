using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuList : System.Web.UI.UserControl
    {
       
        private int CurrentMenus
        {
            get
            {
                object obj = ViewState["CurrentMenus"];
                if (obj == null)
                    return 1;
                else
                    return (int)obj;
            }

            set
            {
                ViewState["CurrentMenus"] = value;
            }

        }

        private int SampleMenuStatus{get;set;}


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request["CurrentMenus"] != null && Request["CurrentMenus"] == "2") // requested old menus
            //{

            //    hlCurrentMenus.Visible = true;
            //    hlOldMenus.Visible = false;
            //}
            //else
            //{ddlContractType.Datasource

            //    hlCurrentMenus.Visible = false;
            //    hlOldMenus.Visible = true;
            //}
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                   

                    if (Request["MenuType"] != null)
                    {
                        string menuListType = Request["MenuType"].ToString();
                        switch (menuListType)
                        {
                            //case "All":
                            //    PopGrid();
                             //   break;
                            case "MyMenus":
                                PopMymenu();                                
                                break;
                            case "MyDrafts":
                                PopMyDraft();                                
                                break;
                            case "ViewSamples":
                                SampleMenuStatus = GlobalEnum.MenuStatus_SampleMenuComplete;
                                PopViewSamples();                                
                                break;
                            default:
                                PopMymenu();
                                break;
                        }
                    }
                    //else PopGrid();
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
            else if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
            {
                hlAddMenu.Visible = false;
            }
        }

        private void PopDropDowns()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(ddlContractType, Code.CodeTypes.ContractType, staff.UserGroup, "");            
            SimpleServingsLibrary.Shared.Utility.GetCodesByType(ddlMenuStatus, Code.CodeTypes.MenuStatus, true, "");
           // ddlMenuStatus.Items.Remove(new ListItem("Draft", GlobalEnum.MenuStatus_Draft.ToString()));
            ddlMenuStatus.Items.Remove(new ListItem("Complete", GlobalEnum.MenuStatus_SampleMenuComplete.ToString()));
            ddlMenuStatus.Items.Remove(new ListItem("Incomplete", GlobalEnum.MenuStatus_SampleMenuIncomplete.ToString()));
            PopContractNameDropDown(staff.StaffID);
           
        }


        private void PopContractNameDropDown(int staffID)
        {
            try
            {
                SimpleServingsLibrary.SupplierRelationship.Contracts contracts = new SimpleServingsLibrary.SupplierRelationship.Contracts();
                contracts = SimpleServingsLibrary.SupplierRelationship.Contract.GetContractsByStaffIDAndContractType(staffID, 0);
                ddlContractType.DataSource = contracts;
                ddlContractType.DataTextField = "ContractName";
                ddlContractType.DataValueField = "ContractID";
                ddlContractType.DataBind();
                ddlContractType.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
            }
            catch { }
 
        }
       
       


        private void PopMymenu()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            pnMenuFilter.Visible = true;
            //if (staff.UserGroup != SimpleServingsLibrary.Shared.UserGroup.ADMIN && staff.UserGroup != SimpleServingsLibrary.Shared.UserGroup.DFTAUSER)
            //{
            //    btnSearch.Visible = false;
            //    txtName.Visible = false;
            //    lblSearch.Visible = false;
            //}
            PopDropDowns();
            PopMyMenuGrid();
        }

        private void PopMyMenuGrid()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");            
            int contractID = 0;
            Int32.TryParse(ddlContractType.SelectedValue, out contractID);
            int menuStatus = 0;
            Int32.TryParse(ddlMenuStatus.SelectedValue, out menuStatus);
            //Mandy add
            string menuText = "";
           // for spell check text box
            menuText = txtName.Text.ToString();
           //menuText = menuText.Replace("\n", "").Replace("\r", "");

            SimpleServingsLibrary.Menu.Menus menus = new SimpleServingsLibrary.Menu.Menus();
            
            try
            {
                menus = SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserIDContractIDpeMenuStatus_New(staff.StaffID,contractID,menuStatus,CurrentMenus, menuText);
            }
            catch { }
            MenuGrid1.PopGrid(menus);
            if (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN) MenuGrid1.ShowDeleteButton(true);
            else MenuGrid1.ShowDeleteButton(false);
            
        }


       
        private void PopMyDraft()
        {
            pnMenuFilter.Visible = true;
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");

            SimpleServingsLibrary.Menu.Menus menus = new SimpleServingsLibrary.Menu.Menus();

            int selContractID = 0;
            Int32.TryParse(ddlContractType.SelectedValue, out selContractID) ;

            try
            {
                if (selContractID != 0)
                {
                    menus = SimpleServingsLibrary.Menu.Menu.GetDraftMenusByContractIdStaffID(staff.StaffID, selContractID);
                }
                else
                {
                    menus = SimpleServingsLibrary.Menu.Menu.GetMenusByCreatedbyAndStatus(staff.StaffID, GlobalEnum.MenuStatus_Draft);
                    //menus = SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserIDContractIDpeMenuStatus(staff.StaffID,0,GlobalEnum.MenuStatus_Draft);
                }
            }
            catch { }
            MenuGrid1.PopGrid(menus);
            MenuGrid1.ShowDeleteButton(true);



            if (selContractID == 0)
            {
                PopContractNameDropDown(staff.StaffID);
                PopDropDownsforDraftMenus();
            }
        }
        
        private void PopDropDownsforDraftMenus()
        {
            lnkBCurrentOldMenus.Visible = false;
            lblMenuStatus.Visible = false;
            ddlMenuStatus.Visible = false;
        }


        #region SampleMenuGridCustomization

        private void PopDropDownsforSampleMenus()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            try
            {
                //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlDietType, Code.CodeTypes.DietType, staff.UserGroup, "");
                SimpleServingsLibrary.Shared.Utility.GetDietTypeCodesByStaffID(ddlDietType, staff.StaffID, "");
                ddlDietType.Items.Insert(0,"[Select]");
            }
            catch { }
        }

        private void PopViewSamplesGrid()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            SimpleServingsLibrary.Menu.Menus sampleMenus = new SimpleServingsLibrary.Menu.Menus();
            try
            {
                sampleMenus = SimpleServingsLibrary.Menu.Menu.GetSampleMenusByMenuStatus(staff.StaffID, SampleMenuStatus);
            }
            catch
            {
            }

            Session["SampleMenuList"] = sampleMenus; // Save menu list in session for Filtering
            //ViewState["MenuTypeID"] = sampleMenus;


            MenuGrid1.PopGrid(sampleMenus);
            if (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN) MenuGrid1.ShowDeleteButton(true);
            else MenuGrid1.ShowDeleteButton(false);
            MenuGrid1.ViewSampleMenuGrid(true, staff.UserGroup, false);            

        }

        private void PopViewSamples()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            // Enable link to show incomplete sample menus to Administrator/ DFTA Users/ DFTA Supervisor
            if (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN || staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.DFTAUSER || staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.DFTASUP)
            {
                cbIncompleteSampleMenu.Visible = true;
                cbIncompleteSampleMenu.Visible = true;
                hlAddSampleMenu.Visible = true;

            }


            //if (staff.UserGroup != 1 && staff.UserGroup != 7)
            //{
            //    btnSearch.Visible = false;
            //    txtName.Visible = false;
            //}
            pnMenuFilter.Visible = true;
            hlAddMenu.Visible = false;
            pnMenuFilter.Visible = false;
            lblMenuGridHeader.Text = "Sample Menu List";
            PopViewSamplesGrid();
            PopDropDownsforSampleMenus();
            pnSampleMenuDietTypeFilter.Visible = true;

        }


        protected void ddlDietType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Menu.Menus filteredMenuList = new SimpleServingsLibrary.Menu.Menus();
            try
            {
                
                if (ddlDietType.SelectedIndex != 0)
                {
                    int selectedDietType = 0;
                    int.TryParse(ddlDietType.SelectedValue, out selectedDietType);
                    var sampleMenus = ((SimpleServingsLibrary.Menu.Menus)Session["SampleMenuList"]).Where(x => x.DietTypeID == selectedDietType);
                    sampleMenus.ToList().ForEach(x => { filteredMenuList.Add(x); });
                }
                else
                {
                    var sampleMenus = ((SimpleServingsLibrary.Menu.Menus)Session["SampleMenuList"]);
                    sampleMenus.ToList().ForEach(x => { filteredMenuList.Add(x); });
                }
                
                MenuGrid1.PopGrid(filteredMenuList);
            }
            catch
            {
                MenuGrid1.PopGrid(null);
            }

        }
        #endregion

        protected void ddlMenuStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMyMenuGrid();
        }

        protected void ddlContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Request["MenuType"] != null)
            {
                string menuListType = Request["MenuType"].ToString();
                switch (menuListType)
                {
                    case "MyMenus":
                        PopMyMenuGrid();
                        break;
                    case "MyDrafts":
                        PopMyDraft();
                        break;
                    //case "ViewSamples":
                    //    SampleMenuStatus = GlobalEnum.MenuStatus_SampleMenuComplete;
                    //    PopViewSamples();
                    //    break;
                    default:
                        PopMymenu();
                        break;
                }
            }
            
        }

      


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                string menuSearch = txtName.Text;
                // take out the \n in spell textbox
                menuSearch = menuSearch.Replace("\n", "").Replace("\r", "");
                int numInt = 0;
                bool result = int.TryParse(menuSearch, out numInt);
                if (result == true)
                { 
                    int menuID = Convert.ToInt32(txtName.Text);
                    SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                    //menu.GetMenuByMenuID(menuID);
                    menu.GetMenuByMenuIDandStaffID(menuID, staff.StaffID);
                    SimpleServingsLibrary.Menu.Menus menus = new SimpleServingsLibrary.Menu.Menus();
                    menus.Add(menu);
                    MenuGrid1.PopGrid(menus);
                }
                else
                {
                    PopMyMenuGrid();
                }
                if (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN) MenuGrid1.ShowDeleteButton(true);
                else MenuGrid1.ShowDeleteButton(false);
                
            }
            catch {
                MenuGrid1.PopGrid(null);                
            }
        }


        protected void lnkBCurrentOldMenus_Click(object sender, EventArgs e)
        {
            CurrentMenus = (CurrentMenus + 1) % 2; 
            if (CurrentMenus == 0)
            {
                lnkBCurrentOldMenus.Text = "Show me my current menus";
                lnkBCurrentOldMenus.CssClass = "current";
            }
            else
            {
                lnkBCurrentOldMenus.Text = "Show me my old menus";
                lnkBCurrentOldMenus.CssClass = "old";
            }
            PopMyMenuGrid();
        }

        protected void cbIncompleteSampleMenu_CheckedChanged(object sender, EventArgs e)
        {

            SampleMenuStatus = (cbIncompleteSampleMenu.Checked == true) ? GlobalEnum.MenuStatus_SampleMenuIncomplete : GlobalEnum.MenuStatus_SampleMenuComplete;
            PopViewSamples();
            
        }

        




    }
}