using System;
using System.Collections;
using System.Web.Security;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using log4net;
using log4net.Config;

namespace SimpleServings.UI.Page
{
	/// <summary>
	/// Summary description for login1.
	/// </summary>
	public partial class login : System.Web.UI.Page
	{
        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    Page.ViewStateUserKey = Session.SessionID; //string.Format("{0}_{1}", Session.SessionID, Guid.NewGuid().ToString());
        //}

        protected System.Web.UI.WebControls.Label Label1;

        private static readonly ILog log = LogManager.GetLogger("AppManager");

        #region Set Anti CSRF Token as per OWASP.org (Comment out this region when debugging - uncomment when deploying/checkin to TFS)
        //private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        //private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        //private string _antiXsrfTokenValue;
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    // The code below helps to protect against XSRF attacks
        //    var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        //    Guid? requestCookieGuidValue = null;
        //    if (requestCookie != null)
        //    {
        //        requestCookieGuidValue = new Guid(requestCookie.Value);
        //    }

        //    if (requestCookie != null && requestCookieGuidValue != null)
        //    {
        //        // Use the Anti-XSRF token from the cookie
        //        _antiXsrfTokenValue = requestCookie.Value;
        //        Page.ViewStateUserKey = _antiXsrfTokenValue;
        //    }
        //    else
        //    {
        //        // Generate a new Anti-XSRF token and save to the cookie
        //        _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
        //        Page.ViewStateUserKey = _antiXsrfTokenValue;
        //        var responseCookie = new HttpCookie(AntiXsrfTokenKey)
        //        {
        //            HttpOnly = true,
        //            Value = _antiXsrfTokenValue,
        //            Secure = true,
        //        };
        //        if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
        //        {
        //            responseCookie.Secure = true;
        //        }
        //        Response.Cookies.Set(responseCookie);
        //    }
        //    Page.PreLoad += login_Page_PreLoad;

        //}

        //protected void login_Page_PreLoad(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        // Set Anti-XSRF token
        //        ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
        //        //ViewState[AntiXsrfUserNameKey] = (Session["UserObject"] != null) ? ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserName : String.Empty;
        //        ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        //    }
        //    else
        //    {
        //        // Validate the Anti-XSRF token
        //        //var _antisfrUserName = (Session["UserObject"] != null) ? ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserName : String.Empty;

        //        //if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue ||
        //        //    (string)ViewState[AntiXsrfUserNameKey] != _antisfrUserName)
        //        if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue ||
        //           (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
        //        {
        //            throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
        //        }
        //    }
        //}
        #endregion

        static login()
        {
            XmlConfigurator.Configure();
        }

		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    LogSession("Request from " + Request.UrlReferrer.ToString());
                }
                else
                {
                    CleanUpOldSessions();
                }

                lblErrorMsg.Visible = false;

                //the user is redirected from Juniper
                //try
                //{
                //    CheckUserName();
                //}
                //catch (Exception ex)
                //{
                //    lblErrorMsg.Text = ex.Message;
                //    lblErrorMsg.Visible = true;
                //}
            }

            if (Page != null)
            {
                Page.RegisterRequiresViewStateEncryption();
            }
            SimpleServingsLibrary.Shared.Utility.SetFocus(this.Page, this.txtUserName);
            SimpleServingsLibrary.Shared.Utility.SetDefaultButton(Page, this.txtUserName, this.btnLogin);


		}

		protected void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                Button btnLogin = sender as Button;
                if (btnLogin != null && btnLogin.ID == "btnLogin" && btnLogin.CommandName == "Login")
                {
                    //if (SimpleServingsLibrary.Shared.Staff.IsUserLocked(txtUserName.Text))
                    //{
                    //    lblErrorMsg.Text = "The account has been locked due to too many login attempts.  Contact <a href=mailto:" + System.Configuration.ConfigurationManager.AppSettings["AdminEmail"] + "> SimpleServings technical support </a> to unlock the account.";
                    //    lblErrorMsg.Visible = true;
                    //}
                    //else
                    String strUserName = new SimpleServingsLibrary.Shared.Staff().GetUserNameByEmail(txtUserName.Text);

                    if (String.IsNullOrEmpty(strUserName) == true)
                    {
                        log.Error("Please check your email address. If you have enter correct email then please contact DFTA Application Support at dftaappsupport@aging.nyc.gov");
                        lblErrorMsg.Visible = true;
                    }
                    else
                    {

                        if (new SimpleServingsLibrary.Shared.Staff().ValidateLogin(strUserName, txtPassword.Text))
                        {
                            SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();

                            if (SimpleServingsLibrary.Shared.Staff.Authenticate(strUserName))
                            {
                                staff.GetStaffByUserName(strUserName);
                                HelpClasses.AppHelper.SetUser(staff);
                                LogSession(string.Format("({0}) - Login successful", staff.UserName));
                                Response.Redirect("~/UI/Page/Home.aspx", false);
                            }
                            else
                            {
                                log.Error("btnLogin_Click failed: User Name missing from the table");

                                lblErrorMsg.Text = "Error Logging In. Please contact DFTA Application Support at dftaappsupport@aging.nyc.gov";
                                lblErrorMsg.Visible = true;
                            }




                        }
                        else
                        {
                            log.Error("btnLogin_Click failed: Incorrect username and/or password.");

                            lblErrorMsg.Text = "Incorrect username and/or password.";
                            lblErrorMsg.Visible = true;
                        }
                    }


                    //if (SimpleServingsLibrary.Shared.Staff.Authenticate(txtUserName.Text, txtPassword.Text))
                    //{

                    //    SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                    //    staff.GetStaffByUserNameAndPassword(txtUserName.Text, txtPassword.Text);

                    //    //Session["UserObject"] = staff;
                    //    HelpClasses.AppHelper.SetUser(staff);
                    //    //staff.SetLoginDate();

                    //    if (staff.ForcePasswordChange)
                    //    {
                    //        LogSession(string.Format("({0}) - Redirecting to ForcePasswordChange.aspx", staff.UserName));

                    //        int staffID = staff.StaffID;
                    //        //Session["UserObject"] = null;
                    //        //Response.Redirect("~/UI/Page/SimpleServings/Staff/ForcePasswordChange.aspx?StaffID=" + staff.StaffID,false);
                    //        Response.Redirect(string.Format("~/UI/Page/landingPage.aspx?type=ForcePasswordChange&StaffID={0}", staff.StaffID), false);
                    //    }
                    //    else
                    //    {
                    //        LogSession(string.Format("({0}) - Login successful", staff.UserName));

                    //        Response.Redirect("~/UI/Page/Home.aspx", false);
                    //    }

                    //}
                    //else
                    //{
                    //    log.Error("btnLogin_Click failed: Incorrect username and/or password.");

                    //    lblErrorMsg.Text = "Incorrect username and/or password.";
                    //    lblErrorMsg.Visible = true;
                    //    //Response.Redirect("~/UI/Page/Login.aspx",false);
                    //}
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("btnLogin_Click failed: {0}", ex.Message), ex);
                
                lblErrorMsg.Text = ex.Message;
                lblErrorMsg.Visible = true;
            }
        }

        protected void lnkPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/SimpleServings/Staff/ForgotPassword.aspx");
        }

        //check if user is locked
        private void CheckUserName()
        {
            string userName = Request["UserName"];
            if (!string.IsNullOrEmpty(userName))
            {
                txtUserName.Text = userName;
                if (SimpleServingsLibrary.Shared.Staff.IsUserLocked(txtUserName.Text))
                {
                    lblErrorMsg.Text = "The account has been locked due to too many login attempts.  Contact <a href=mailto:" + System.Configuration.ConfigurationManager.AppSettings["AdminEmail"] + "> SimpleServings technical support </a> to unlock the account.";
                    lblErrorMsg.Visible = true;
                }
            }
        }

        private void CleanUpOldSessions()
        {
            HelpClasses.AppHelper.CleanUpOldSessions();
        //    Session["UserObject"] = null;
        //    Session.Abandon();

        //    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddYears(-30);
        //    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }

        private static void LogSession(string message)
        {
            var sessionCookie = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"];
            if (sessionCookie != null)
            {
                //Session["ASP.NET_SessionId"] = sessionCookie.Value;
                log.Info(string.Format("(login.aspx) - {0} {1}SessionId: {2}", message, Environment.NewLine, sessionCookie.Value));
            }
        }

	}
}
