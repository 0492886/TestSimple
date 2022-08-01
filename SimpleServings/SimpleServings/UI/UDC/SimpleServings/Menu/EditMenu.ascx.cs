using SimpleServingsLibrary.Menu;
using SimpleServingsLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class EditMenu : System.Web.UI.UserControl
    {

        int menutypeID = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int menuID = 0;
                if (Request["MenuID"] != null)
                {
                    Int32.TryParse(Request["MenuID"].ToString(), out menuID);
                }
                lblMenuID.Text = menuID.ToString();

                try
                {
                    ApplyPermissions();
                    PopDropDowns(menuID);
                }

                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }

                if (menutypeID == GlobalEnum.SampleMenu)
                {
                    divCycleSection.Visible = false;
                    //ddlContract.Enabled = false;
                    divSelectCont.Visible = false;
                    divContractGrid.Visible = false;

                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MenuType", "var menuTypeID=" + menutypeID.ToString() + ";", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MenuType", "var menuTypeID=" + ViewState["MenuTypeID"].ToString() + ";", true);
                lblMsg.Text = "";
 
            }
            
            

        }
       
       
        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.MenuModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void PopDropDowns(int menuID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            
                menu.GetMenuByMenuID(menuID);
                menutypeID = menu.MenuTypeID;
                ViewState["MenuTypeID"] = menu.MenuTypeID;
                ViewState["DietType&ProgramType"] = menu.DietTypeID.ToString() + "," + menu.ContractTypeID.ToString();
                       
                if (menu.MenuStatus != GlobalEnum.MenuStatus_Draft & menu.MenuStatus != GlobalEnum.MenuStatus_SampleMenuIncomplete)
                {
                    this.pnPage.Visible = false;
                    throw new ApplicationException("You are not allowed to access this page");
                }
                txtMenuName.Text = menu.MenuName;
                if (staff.UserGroup != 1)
                {
                    txtMenuName.Enabled = false;
                }


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

                ucContractList.PopSelectedContracts(menu.ContractsIDs);

                //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlDietType, Code.CodeTypes.DietType, staff.UserGroup, menu.DietTypeID.ToString());
                SimpleServingsLibrary.Shared.Utility.GetDietTypeCodesByStaffID(ddlDietType, staff.StaffID, menu.DietTypeID.ToString());
                //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlMealType, Code.CodeTypes.MealServedType, staff.UserGroup, menu.MealServedTypeID.ToString());    
   
                SimpleServingsLibrary.Shared.Utility.GetMenuCycles(ddlCycle, Code.CodeTypes.Cycle, staff.UserGroup, menu.CycleID.ToString());

                GetCycleDates();
                //try
                //{
                //    SimpleServingsLibrary.Shared.Codes days = SimpleServingsLibrary.Shared.Code.GetCodesByType(Code.CodeTypes.DayOfWeek);
                //    cblDays.DataSource = days;
                //    cblDays.DataTextField = "CodeDescription";
                //    cblDays.DataValueField = "CodeID";
                //    cblDays.DataBind();
                //}
                //catch
                //{
                //    cblDays.DataSource = null;
                //    cblDays.DataBind();
                //}
            

        }




        private void GetValuesFromControls(ref SimpleServingsLibrary.Menu.Menu menu)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");


            int contractTypeID = 0;
            Int32.TryParse(ddlContract.SelectedValue, out contractTypeID);
            menu.ContractTypeID = contractTypeID;
            //int mealServedType = 0;
            //Int32.TryParse(ddlMealType.SelectedValue, out mealServedType);
            //menu.MealServedTypeID = mealServedType;
            int cycleID = 0;
            Int32.TryParse(ddlCycle.SelectedValue, out cycleID);
            menu.CycleID = cycleID;

            int dietTypeID = 0;
            Int32.TryParse(ddlDietType.SelectedValue, out dietTypeID);
            menu.DietTypeID = dietTypeID;

            //int mealServedType = 0;
            //Int32.TryParse(ddlMealType.SelectedValue, out mealServedType);
            //menu.MealServedTypeID = mealServedType;

            menu.StartDate = txtStartDate.Text.Trim();
            menu.EndDate = txtEndDate.Text.Trim();           
            menu.CreatedBy = staff.StaffID;
            //menu.MenuName = ValidateMenuName(HttpUtility.HtmlEncode(txtMenuName.Text.Trim()));
            menu.MenuName = SimpleServingsLibrary.Menu.Menu.ValidateMenuName(HttpUtility.HtmlEncode(txtMenuName.Text.Trim()));
        }

        //private string ValidateMenuName(string menuNameInput)
        //{            
        //    if (menuNameInput.Contains("&lt;b&gt;"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;b&gt;"));
        //    if (menuNameInput.Contains("<b>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<b>"));
        //    if (menuNameInput.Contains("\u003Cb\u003E"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cb\u003E"));
        //    if (menuNameInput.Contains("<br>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<br>"));
        //    if (menuNameInput.Contains("&lt;i&gt;"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;i&gt;"));
        //    if (menuNameInput.Contains("<i>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<i>"));
        //    if (menuNameInput.Contains("\u003Ci\u003E"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ci\u003E"));
        //    if (menuNameInput.Contains("&lt;script&gt;"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;script&gt;"));
        //    if (menuNameInput.Contains("<script>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<script>"));
        //    if (menuNameInput.Contains("\u003Cscript\u003E"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cscript\u003E"));
        //    if (menuNameInput.Contains("&lt;iframe&gt;"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;iframe&gt;"));
        //    if (menuNameInput.Contains("<iframe>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<iframe>"));
        //    if (menuNameInput.Contains("\u003Ciframe\u003E"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ciframe\u003E"));
        //    if (menuNameInput.Contains("&lt;frame&gt;"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;frame&gt;"));
        //    if (menuNameInput.Contains("<frame>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<frame>"));
        //    if (menuNameInput.Contains("\u003Cframe\u003E"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cframe\u003E"));

        //    if (menuNameInput.Contains("&lt;a&gt;"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;a&gt;"));
        //    if (menuNameInput.Contains("<a>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<a>"));
        //    if (menuNameInput.Contains("\u003Ca\u003E"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ca\u003E"));
        //    if (menuNameInput.ToLower().Contains("&lt;img&gt;"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;img&gt;"));
        //    if (menuNameInput.ToLower().Contains("<img>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<img>"));
        //    if (menuNameInput.Contains("\u003Cimg\u003E") || menuNameInput.Contains("\u003CIMG\u003E"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cimg\u003E"));

        //    if (menuNameInput.Contains("&lt;!--#include"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;!--#include"));
        //    if (menuNameInput.Contains("<!--#include"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<!--#include"));
        //    if (menuNameInput.Contains("\u003C!--#include"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003C!--#include"));

        //    if (menuNameInput.ToLower().Contains("&lt;style&gt;"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;style&gt;"));
        //    if (menuNameInput.ToLower().Contains("<style>"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "<style>"));
        //    if (menuNameInput.Contains("\u003Cstyle\u003E") || menuNameInput.Contains("\u003CSTYLE\u003E"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cstyle\u003E"));

        //    if (menuNameInput.Contains("|echo"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "|echo"));

        //    if (menuNameInput.ToLower().Contains("javascript:"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "javascript:"));
        //    if (menuNameInput.ToLower().Contains("src="))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "src="));
        //    if (menuNameInput.ToLower().Contains("file="))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "file="));
        //    if (menuNameInput.ToLower().Contains("@import"))
        //        throw new Exception(string.Format("Invalid characters detected ...{0}...", "@import"));

        //    StringBuilder sb = new StringBuilder(menuNameInput);

        //    sb.Replace("\u003C", string.Empty);
        //    sb.Replace("\u003E", string.Empty);
        //    sb.Replace("\u0028", string.Empty);
        //    sb.Replace("\u0029", string.Empty);
        //    sb.Replace("&quot;", string.Empty);
        //    sb.Replace("&lt;", string.Empty);
        //    sb.Replace("&gt;", string.Empty);
        //    sb.Replace(";", string.Empty);

        //    return sb.ToString();
        //}

        private bool SaveMenu()
        {
            bool edited = false;            
            try
            {
                //ValidateDaysOfService();
                int menuID = 0;
                Int32.TryParse(lblMenuID.Text, out menuID);
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                menu.GetMenuByMenuID(menuID);

                int contractTypeID = menu.ContractTypeID;
                int dietTypeID = menu.DietTypeID;

                GetValuesFromControls(ref menu);

                List<int> selectedContractIDs = new List<int>();
                selectedContractIDs = ucContractList.getCurrentContratcList();

                if (contractTypeID != menu.ContractTypeID || dietTypeID != menu.DietTypeID)
                {                    
                    if (selectedContractIDs.Count < 1 && menu.MenuTypeID != GlobalEnum.SampleMenu)
                    {
                        lblMsg.Text = "*Associated contracts must be changed, If Program Type/ Diet Type is changed!!";                        
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        return false;
                    }               
 
                }

                menu.ContractsIDs = selectedContractIDs;
                edited = menu.EditMenu();
                //SimpleServingsLibrary.Menu.MenuDay day = new SimpleServingsLibrary.Menu.MenuDay();
                //int dayOfWeekID = 0;

                //foreach (ListItem cb in cblDays.Items)
                //{
                //    if (cb.Selected)
                //    {
                //        day.MenuID = menuID;
                //        Int32.TryParse(cb.Value, out dayOfWeekID);
                //        day.DayOfWeekID = dayOfWeekID;
                //        day.AddMenuDay();
                //    }
                //}

               
                lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
                lblMsg.Text = "Menu successfully saved";
                lblMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
            return edited;
        }

       
       

        protected void btnEditMenu_Click(object sender, EventArgs e)
        {
            bool edited = false;
            edited = SaveMenu();
            if (edited)
            {
                string url = ResolveUrl("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID=" + lblMenuID.Text);
                Response.Redirect(url);
            }

        }

        protected void ddlCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCycleDates();
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
            catch { }
        }

        //protected void ddlContract_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    panelInfoMsg.Visible = true;
        //    ModalPopupExtender1.Show();


        //}

        protected void btnSelectcontract_Click(object sender, EventArgs e)
        {
            PopContractGrid();
            ajaxModalPopup.Show();

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            List<int> Ids = new List<int>();
            Ids = ucContractGrid.GetSelectedContractIDs();
            ucContractList.PopSelectedContracts(Ids);
            ajaxModalPopup.Hide();
            divContractGrid.Visible = true;
            lblMsg.Text = "";
        }


        private void PopContractGrid()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            try
            {

                List<int> selectedContractIDs = new List<int>();
                selectedContractIDs = ucContractList.getCurrentContratcList();

                int ContractTypeID = 0;
                Int32.TryParse(ddlContract.SelectedValue, out ContractTypeID);

                int dietTypeID = 0;
                Int32.TryParse(ddlDietType.SelectedValue, out dietTypeID);

                int mealTypeID = 0;
                //Int32.TryParse(ddlMealType.SelectedValue, out mealTypeID);

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

        protected void ddlDietType_SelectedIndexChanged(object sender, EventArgs e)
        {
            menutypeID = Convert.ToInt32(ViewState["MenuTypeID"]);
            string[] vals = ViewState["DietType&ProgramType"].ToString().Split(',');

            if (menutypeID != GlobalEnum.SampleMenu)
            {
                //Response.Write("<script>alert('Associated Contracts must be changed, If Program Type/ Diet Type is changed!!');</script>");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Confirm", "ConfirmDietOrProgramTypeChange()", true);
                
                string confrimValue = Request.Form["confirmChanges"];
                if (confrimValue != "Yes")
                {
                    ddlDietType.ClearSelection();
                    ddlDietType.SelectedValue = vals[0].ToString();
                    //ddlContract.ClearSelection();
                    //ddlContract.SelectedValue = vals[1].ToString();

                }
                else
                {
                    ucContractList.PopGrid(null);
                }
            }

        }

        protected void ddlContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            menutypeID = Convert.ToInt32(ViewState["MenuTypeID"]);
            string[] vals = ViewState["DietType&ProgramType"].ToString().Split(',');

            if (menutypeID != GlobalEnum.SampleMenu)
            {
                string confrimValue = Request.Form["confirmChanges"];
                if (confrimValue != "Yes")
                {
                    ddlContract.ClearSelection();
                    ddlContract.SelectedValue = vals[1].ToString(); 
                }
                else
                {
                    ucContractList.PopGrid(null);
                }
            }
        }


        protected void btnCancelFrom_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID=" + Request["MenuID"].ToString());

        }



        //protected void btnOK_Click(object sender, EventArgs e)
        //{
        //    ModalPopupExtender1.Hide();
        //    divSelectCont.Visible = true;
        //}


    }
}