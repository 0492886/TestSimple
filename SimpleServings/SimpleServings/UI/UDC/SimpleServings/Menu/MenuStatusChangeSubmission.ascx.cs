using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuStatusChangeSubmission : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (!Page.IsPostBack)
            {
                PopDropDownList();  
                PopMenuStatusHistory(Convert.ToInt32(Request["MenuID"]));

            }
        }

        private void PopMenuStatusHistory(int menuID)
        {
            try
            {
                SimpleServingsLibrary.Menu.MenuStatusHistories menustatushistories = new SimpleServingsLibrary.Menu.MenuStatusHistories();
                menustatushistories = SimpleServingsLibrary.Menu.MenuStatusHistory.GetMenuStatusHistoryByMenuID(menuID);
                MenuStatusHistoryGrid1.PopMenuStatusGrid(menustatushistories);            
            }
            catch { }
        }

        private void PopDropDownList()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (Request["StatusID"] != null)
            {     
                try
                {
                    SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                    menu.GetMenuByMenuID(Convert.ToInt32(Request["MenuID"].ToString()));
                    if (menu.MenuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_Draft)
                        pnlSubmitTocontract.Visible = true;
                    else pnlSubmitTocontract.Visible = false;

                    SimpleServingsLibrary.Shared.Code code = new SimpleServingsLibrary.Shared.Code();
                    code.GetCodeByCodeID(Convert.ToInt32(Request["StatusID"]));

                    if (menu.MenuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_Draft)
                        pnlSubmitTocontract.Visible = true;
                    else pnlSubmitTocontract.Visible = false;
                    
                    SimpleServingsLibrary.Shared.Code.CodeTypes deCodeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), code.CodeType);
                    SimpleServingsLibrary.Shared.Codes codes = SimpleServingsLibrary.Shared.Code.GetCodesByTypeAndUserGroup(deCodeType, staff.UserGroup);
                    SimpleServingsLibrary.Shared.Codes ShortCodeList = GetShortCodelist(codes);

                    ddlMenuStatus.DataSource = ShortCodeList;
                    ddlMenuStatus.DataTextField = "CodeDescription";
                    ddlMenuStatus.DataValueField = "CodeID";
                    ddlMenuStatus.DataBind();

                    ddlMenuStatus.ClearSelection();
                    ddlMenuStatus.Items.FindByValue(Request["StatusID"].ToString()).Selected = true;


                    if (menu.ContractNames != null && menu.MenuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_Draft)
                    {
                        dlContracts.DataSource = menu.ContractNames;
                        dlContracts.DataBind();
                    }
                    else
                    {
                        spanContractName.Visible = false;
                    }


                }
                catch { }
            }
        }
        
        private SimpleServingsLibrary.Shared.Codes GetShortCodelist(SimpleServingsLibrary.Shared.Codes codes)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            SimpleServingsLibrary.Shared.Codes shortCodes = new SimpleServingsLibrary.Shared.Codes();            
            foreach (SimpleServingsLibrary.Shared.Code code in codes)
            {
                string msg = "";
                if (SimpleServingsLibrary.Shared.Rule.SatisfyRules(code.CodeID, Convert.ToInt32(Request["MenuID"].ToString()), staff.StaffID, ref msg,code.CodeID))
                    shortCodes.Add(code);   
            }
            return shortCodes;
        }

        private void MarkSampleMenuCompleted(int menuStatus)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");

            int menuID = 0;
            Int32.TryParse(Request["MenuID"].ToString(), out menuID);

            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            try
            {
                menu.GetMenuByMenuID(menuID);

                string msg = "";
                if (!SimpleServingsLibrary.Shared.Rule.SatisfyRules(SimpleServingsLibrary.Shared.GlobalEnum.MenuModule, menuID, staff.StaffID, ref msg))
                {
                    lblMsg.Text = msg;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    throw new ApplicationException(msg);
                }

                menu.EditMenuStatus(menuStatus, staff.StaffID, txtCustomMessage.Text);
                string url = string.Format("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID={0}", menuID);
                Response.Redirect(url);
                
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }

 
        }

		private void SubmitToDFTA()
		{
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
				//Response.Redirect("~/UI/Page/login.aspx");
			int menuID = 0;
			Int32.TryParse(Request["MenuID"].ToString(), out menuID);
			int menuStatus = 0;
			Int32.TryParse(ddlMenuStatus.SelectedValue, out menuStatus);
			SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
			try
			{
                //System.Diagnostics.Debugger.Launch();
				menu.GetMenuByMenuID(menuID);

                string msg = "";
				if (!SimpleServingsLibrary.Shared.Rule.SatisfyRules(SimpleServingsLibrary.Shared.GlobalEnum.MenuModule, menuID, staff.StaffID, ref msg))
				{
					throw new Exception(msg);
				}

                if (menu.MenuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_Draft)
                {
                    // Change by Monika SubmitMenuToContracts1.SubmitToContracts(menuStatus, txtCustomMessage.Text);
                    //SubmitMenuToContracts1.SubmitToContracts(menuStatus);
                    SubmitMenuToContracts1.SubmitToContracts(menuStatus, txtCustomMessage.Text);
                }
                else
                {
                    menu.EditMenuStatus(menuStatus, staff.StaffID, txtCustomMessage.Text);
                }
				lblMsg.ForeColor = System.Drawing.Color.Green;
				lblMsg.Text = "Status changed successfully";
				btnEditMenuStatus.Visible = false;

				//begin Email part

                //List<int> contractIDs = new List<int> { };
                //contractIDs = SubmitMenuToContracts1.GetSelectedContractIDs();
                //SimpleServingsLibrary.Shared.Comment.SendEmail(menuStatus, menuID, staff.StaffID, contractIDs);

				//End Email part

				string url = string.Format("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID={0}", menuID);
				Response.Redirect(url);
			}
			catch (Exception ex)
			{
				lblMsg.ForeColor = System.Drawing.Color.Red;
				lblMsg.Text = ex.Message;
			}
		}

        protected void btnAgree_Click(object sender, EventArgs e)
		{
			SubmitToDFTA();
		}

        protected void btnEditMenuStatus_Click(object sender, EventArgs e)
        {
            int menuStatus = 0;
            Int32.TryParse(ddlMenuStatus.SelectedValue, out menuStatus);

            if (menuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_SampleMenuComplete || menuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_SampleMenuIncomplete)
            {
                // Mark Sample Menu as Complete/ Incomplete
                MarkSampleMenuCompleted(menuStatus);
            }
            else if (menuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_SubmittedToDFTA ||
                menuStatus == SimpleServingsLibrary.Shared.GlobalEnum.MenuStatus_SubmittedToContract)
            {
                ModalPopupExtender1.Show();
            }
            else
            {
                SubmitToDFTA();
            }
        }
    }
}