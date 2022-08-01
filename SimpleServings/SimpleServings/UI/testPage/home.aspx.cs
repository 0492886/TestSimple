using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.testPage
{
    public partial class home : System.Web.UI.Page
    {
        //Set Anti CSRF Token as per OWASP.org
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid? requestCookieGuidValue = null;
            if (requestCookie != null)
            {
                requestCookieGuidValue = new Guid(requestCookie.Value);
            }

            if (requestCookie != null && requestCookieGuidValue != null)
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;
                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue,
                    Secure = true,
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }
            Page.PreLoad += homeT_Page_PreLoad;

        }

        protected void homeT_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                //ViewState[AntiXsrfUserNameKey] = (Session["UserObject"] != null) ? ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserName : String.Empty;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                //var _antisfrUserName = (Session["UserObject"] != null) ? ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserName : String.Empty;

                //if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue ||
                //    (string)ViewState[AntiXsrfUserNameKey] != _antisfrUserName)
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue ||
                   (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}