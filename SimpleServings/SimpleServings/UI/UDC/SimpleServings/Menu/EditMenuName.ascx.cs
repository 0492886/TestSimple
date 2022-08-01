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
    public partial class EditMenuName : System.Web.UI.UserControl
    {
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
                    PopMenuName(menuID);
                }

                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }
            
        }

        private void PopMenuName(int menuID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
            try
            {
                menu.GetMenuByMenuID(menuID);
                txtMenuName.Text = menu.MenuName;
                //The only users who should be able to edit menus when they are submitted to DFTA are DFTA users and admin. 
                var allowedUserGroups = new[] {SimpleServingsLibrary.Shared.UserGroup.ADMIN,
                                                SimpleServingsLibrary.Shared.UserGroup.DFTASUP,
                                                SimpleServingsLibrary.Shared.UserGroup.DFTAUSER};


                if (!(menu.MenuStatus != GlobalEnum.MenuStatus_SubmittedToDFTA || allowedUserGroups.Contains(staff.UserGroup)))

                if (
                    menu.MenuStatus == GlobalEnum.MenuStatus_Approved ||
                    !(menu.MenuStatus != GlobalEnum.MenuStatus_SubmittedToDFTA || allowedUserGroups.Contains(staff.UserGroup))
                    )                   
                    {
                        this.pnPage.Visible = false;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text="You are not allowed to access this page";
                    }
               
            }
            catch { }

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


        protected void btnEditMenuName_Click(object sender, EventArgs e)
        {
            bool edited = false;
            edited = SaveMenu();
            if (edited)
            {
                string url = ResolveUrl("~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID=" + lblMenuID.Text);
                Response.Redirect(url);
            }

        }

        //private string ValidateMenuName(string menuNameInput)
        //{
        //    StringBuilder sb = new StringBuilder(menuNameInput);
        //    sb.Replace("&lt;b&gt;", string.Empty);
        //    sb.Replace("&lt;/b&gt;", string.Empty);
        //    sb.Replace("&lt;i&gt;", string.Empty);
        //    sb.Replace("&lt;/i&gt;", string.Empty);
        //    sb.Replace("&lt;script&gt;", string.Empty);
        //    sb.Replace("&lt;/script&gt;", string.Empty);
        //    sb.Replace("<script>", string.Empty);
        //    sb.Replace("</script>", string.Empty);
        //    sb.Replace("\u003Cscript\u003E", string.Empty);
        //    sb.Replace("\u003C/script\u003E", string.Empty);
        //    sb.Replace("\u003C", string.Empty);
        //    sb.Replace("\u003E", string.Empty);
        //    sb.Replace("\u0028", string.Empty);
        //    sb.Replace("\u0029", string.Empty);
        //    sb.Replace("javascript:", string.Empty);
        //    sb.Replace("src=", string.Empty);
        //    sb.Replace("&lt;iframe&gt;", string.Empty);
        //    sb.Replace("&lt;iframe", string.Empty);
        //    sb.Replace("&lt;/iframe&gt;", string.Empty);
        //    sb.Replace("&lt;a&gt;", string.Empty);
        //    sb.Replace("&lt;a", string.Empty);
        //    sb.Replace("&lt;/a&gt;", string.Empty);
        //    sb.Replace("&lt;IMG&gt;", string.Empty);
        //    sb.Replace("&lt;IMG", string.Empty);
        //    sb.Replace("&lt;/IMG&gt;", string.Empty);
        //    sb.Replace("&lt;img&gt;", string.Empty);
        //    sb.Replace("&lt;img", string.Empty);
        //    sb.Replace("&lt;/img&gt;", string.Empty);
        //    sb.Replace("&lt;!--#include", string.Empty);
        //    sb.Replace("file=", string.Empty);
        //    sb.Replace("--&gt;", string.Empty);
        //    sb.Replace("&lt;STYLE&gt", string.Empty);
        //    sb.Replace("&lt;STYLE", string.Empty);
        //    sb.Replace("&lt;/STYLE&gt", string.Empty);
        //    sb.Replace("&lt;style&gt", string.Empty);
        //    sb.Replace("&lt;style", string.Empty);
        //    sb.Replace("&lt;/style&gt", string.Empty);
        //    sb.Replace("@import", string.Empty);
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
                int menuID = 0;
                Int32.TryParse(lblMenuID.Text, out menuID);
                SimpleServingsLibrary.Menu.Menu menu = new SimpleServingsLibrary.Menu.Menu();
                menu.GetMenuByMenuID(menuID);
                //menu.MenuName = ValidateMenuName(HttpUtility.HtmlEncode(txtMenuName.Text.Trim()));
                menu.MenuName = SimpleServingsLibrary.Menu.Menu.ValidateMenuName(HttpUtility.HtmlEncode(txtMenuName.Text.Trim()));
                edited = menu.EditMenuName();
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
    }
}