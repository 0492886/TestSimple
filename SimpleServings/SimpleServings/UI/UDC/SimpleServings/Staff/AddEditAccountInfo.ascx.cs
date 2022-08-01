using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SimpleServingsLibrary.Shared;

using log4net;
using log4net.Config;

namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class AddEditAccountInfo : System.Web.UI.UserControl
    {
        public bool IsUsedInWizard
        { 
            get { return btnSave.Visible; }
            set { btnSave.Visible = !value; }
        }
        public string UserName
        {
            get { return txtUserName.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
        }
        
        public string SummaryMsg
        {
            get { return lblSummary.Text; }
            set { lblSummary.Text = value; }
        }

        private static readonly ILog log = LogManager.GetLogger("AppManager");

        static AddEditAccountInfo()
        {
            XmlConfigurator.Configure();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    LogSession("Request from " + Request.Url.ToString());
                    ApplyPermissions();
                }
                catch (ApplicationException ex)
                {
                    lblSummary.ForeColor = System.Drawing.Color.Red;
                    lblSummary.Text = ex.Message;
                }
               
            }

        }
        private void ApplyPermissions()
        {
            LogSession("Request from " +  Request.Url.ToString());

            //if we're coming here from ForcePasswordChange, we don't have a userObject, so don't check, just allow!!!
            if (!Request.Url.ToString().ToLower().Contains("forcepassword"))
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                //Response.Redirect("~/UI/Page/login.aspx");
                //the user can always edit his/her own account info
                if (Request["StaffID"] != null && Convert.ToInt32(Request["StaffID"].ToString()) == staff.StaffID)
                    return;
                //only users with Add permission in UserGroupModule can edit other staff account info
                if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(SimpleServingsLibrary.Shared.GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
                {
                    this.pnPage.Visible = false;
                    throw new ApplicationException("You are not allowed to access this page");
                }
            }
        }

        private void LogSession(string message)
        {
            var sessionCookie = Request.Cookies["ASP.NET_SessionId"];
            if (sessionCookie != null)
            {
                //Session["ASP.NET_SessionId"] = sessionCookie.Value;
                log.Info(string.Format("(AddEditAccountInfo.ascx) - {0} {1}SessionId: {2}", message, Environment.NewLine, sessionCookie.Value));
            }
        }

        protected void Page_Init()
        {
            PopDropDown();
        }

        private void PopDropDown()
        {
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlTheme, SimpleServingsLibrary.Shared.Code.CodeTypes.Theme, 2, "");
            
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string password = SimpleServingsLibrary.Shared.Staff.GeneratePassword();

            this.txtPassword.Text = password;
            this.txtConfirmPassword.Text = password;
            
            //this.txtPassword.TextMode = TextBoxMode.Password;
            //this.txtConfirmPassword.TextMode = TextBoxMode.Password;

        }
        protected bool IsAdmin(int staffID)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
                return staff.IsAdmin;
            }
            catch
            {
                return false;
            }
        }

        public void PopStaffAccountInfo(int staffID)
        {
            lblStaffID.Text = staffID.ToString();

            //btnGenerate.Visible = IsAdmin(staffID);

            SimpleServingsLibrary.Shared.Staff staff=new SimpleServingsLibrary.Shared.Staff();
            staff.GetStaffByStaffID(staffID);
            txtUserName.Text = staff.UserName;
            txtUserName.ReadOnly = true;
            txtEmail.Text = staff.Email;
            //txtPassword.Text = staff.Password;
            //txtConfirmPassword.Text = staff.Password;
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddlTheme, SimpleServingsLibrary.Shared.Code.CodeTypes.Theme, 2, "");
            //try
            //{
            //    ddlTheme.Items.FindByValue(staff.Theme.ToString()).Selected = true;
            //}
            //catch
            //{
               
            //}
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsUsedInWizard)
                {
                    SaveForEdit(Convert.ToInt32(lblStaffID.Text));
                }
                else
                {
                    Save(Convert.ToInt32(lblStaffID.Text));
                }
                #region new user updating password
                if (Request.Url.ToString().ToLower().Contains("forcepassword"))
                {
                    LogSession("Saving new password");

                    int staffID = Convert.ToInt32(lblStaffID.Text);
                    SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
                    staff.SetForcePasswordChange(false);
                    Session["UserObject"] = staff;

                    LogSession("Redirecting to Home.aspx");

                    //Response.Redirect("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx");
                    Response.Redirect("~/UI/Page/Home.aspx");
                }
                #endregion

                if (Request["MyProfile"] == "MyProfile")
                {
                    Response.Redirect("~/UI/Page/MyZone.aspx?Control=MyProfile&StaffID=" + Convert.ToInt32(lblStaffID.Text));
                }
                else
                {
                    Response.Redirect("~/UI/Page/MyZone.aspx?Control=ViewStaff&StaffID=" + Convert.ToInt32(lblStaffID.Text));
                }

            }
            catch (Exception ex)
            {
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Text = ex.Message;
            }
            
            
        }
        public void SaveForEdit(int staffID)
        {
            
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                staff.GetStaffByStaffID(staffID);
                //staff.Password = ValidateInput(HttpUtility.HtmlEncode(txtPassword.Text));
                //staff.Theme = Convert.ToInt32(ddlTheme.SelectedValue);
                staff.Email = txtEmail.Text;
                
                    if (staff.EditStaff())
                        lblSummary.Text = "changes have been saved";

                    //SimpleServingsLibrary.Shared.Mailer.SendMail(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"], staff.Email, staff);

                
        }

        public void Save(int staffID)
        {
            if (!SimpleServingsLibrary.Shared.Staff.IsUserNameTaken(txtUserName.Text))
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                staff.GetStaffByStaffID(staffID);
                staff.UserName = txtUserName.Text;
              //  staff.Password = ValidateInput(HttpUtility.HtmlEncode(txtPassword.Text));
                //staff.Theme = Convert.ToInt32(ddlTheme.SelectedValue);
                staff.Email = txtEmail.Text;
                if (staff.EditStaff())
                    lblSummary.Text = "changes have been saved<br>";
                //SimpleServingsLibrary.Shared.Mailer.SendMail(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"], staff.Email, staff);

                
            }
            else
                lblSummary.Text = "selected User Name is already taken<br>";

        }

        private string ValidateInput(string input)
        {
            if (input.Contains("&lt;b&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;b&gt;"));
            if (input.Contains("<b>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<b>"));
            if (input.Contains("\u003Cb\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cb\u003E"));
            if (input.Contains("<br>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<br>"));
            if (input.Contains("&lt;i&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;i&gt;"));
            if (input.Contains("<i>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<i>"));
            if (input.Contains("\u003Ci\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ci\u003E"));
            if (input.Contains("&lt;script&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;script&gt;"));
            if (input.Contains("<script>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<script>"));
            if (input.Contains("\u003Cscript\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cscript\u003E"));
            if (input.Contains("&lt;iframe&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;iframe&gt;"));
            if (input.Contains("<iframe>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<iframe>"));
            if (input.Contains("\u003Ciframe\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ciframe\u003E"));
            if (input.Contains("&lt;frame&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;frame&gt;"));
            if (input.Contains("<frame>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<frame>"));
            if (input.Contains("\u003Cframe\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cframe\u003E"));

            if (input.Contains("&lt;a&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;a&gt;"));
            if (input.Contains("<a>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<a>"));
            if (input.Contains("\u003Ca\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ca\u003E"));
            if (input.ToLower().Contains("&lt;img&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;img&gt;"));
            if (input.ToLower().Contains("<img>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<img>"));
            if (input.Contains("\u003Cimg\u003E") || input.Contains("\u003CIMG\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cimg\u003E"));

            if (input.Contains("&lt;!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;!--#include"));
            if (input.Contains("<!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<!--#include"));
            if (input.Contains("\u003C!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003C!--#include"));

            if (input.ToLower().Contains("&lt;style&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;style&gt;"));
            if (input.ToLower().Contains("<style>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<style>"));
            if (input.Contains("\u003Cstyle\u003E") || input.Contains("\u003CSTYLE\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cstyle\u003E"));

            if (input.Contains("|echo"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "|echo"));

            if (input.ToLower().Contains("javascript:"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "javascript:"));
            if (input.ToLower().Contains("src="))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "src="));
            if (input.ToLower().Contains("file="))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "file="));
            if (input.ToLower().Contains("@import"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "@import"));

            StringBuilder sb = new StringBuilder(input);

            sb.Replace("\u003C", string.Empty);
            sb.Replace("\u003E", string.Empty);
            sb.Replace("\u0028", string.Empty);
            sb.Replace("\u0029", string.Empty);
            sb.Replace("&quot;", string.Empty);
            sb.Replace("&lt;", string.Empty);
            sb.Replace("&gt;", string.Empty);
            sb.Replace(";", string.Empty);

            return sb.ToString();
        }
    }
}