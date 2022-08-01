using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.Page
{
    public partial class dashboardmain : System.Web.UI.MasterPage
    {
        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    Page.ViewStateUserKey = Session.SessionID; //string.Format("{0}_{1}", Session.SessionID, Guid.NewGuid().ToString());
        //}

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
        //    Page.PreLoad += master_Page_PreLoad;

        //}
        //protected void master_Page_PreLoad(object sender, EventArgs e)
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

        //Event added by kam on 11/15/2017 it is commented because we do not need this. This is not the good practise However origianl code us ctl100 this code will force to use ctl100
        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    this.ID = "ctl00";
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Response.Headers["Server"] != null)
                    HttpContext.Current.Response.Headers.Remove("Server");
            }

            Page.Header.DataBind();
            
            //Response.Write("Time: " + System.DateTime.Now.ToLongTimeString() + "<br />");

            ////foreach (string key in Session.Keys)
            ////{
            ////    Response.Write(key + " - " + Session[key] + "<br />");
            ////}
            //Response.Write("UserSession" + " - " + Session["UserObject"] + "<br />");
            //SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            //if (staff != null)
            //    Response.Write("Name" + " - " + staff.FullName + "<br />");
            //Response.Write("processID: " + System.Diagnostics.Process.GetCurrentProcess().Id + "<br />");
            //Response.Write("processName: " + System.Diagnostics.Process.GetCurrentProcess().ProcessName + "<br />");
            
            
        }
    }
}