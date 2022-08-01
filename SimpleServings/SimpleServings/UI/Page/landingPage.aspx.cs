using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using log4net;
using log4net.Config;
using System.Web.Services;

namespace SimpleServings.UI.Page
{
    public partial class landingPage : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger("AppManager");

        static landingPage()
        {
            XmlConfigurator.Configure();
        }

        [WebMethod]
        public static void ClearSession()
        {
            LogSession("Clearing Session");
            HelpClasses.AppHelper.CleanUpOldSessions();
        }

        [WebMethod]
        public static void NewSession()
        {
            HttpContext.Current.Session["x"] = 123;
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie("ABC", ""));
            LogSession("New Session");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (string.IsNullOrEmpty(Request["type"]))
                {
                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null || !staff.IsAdmin)
                    {
                        Response.Redirect("~/UI/Page/Home.aspx");
                    }
                }

                if (Request.UrlReferrer != null) LogSession("Request from " + Request.UrlReferrer.ToString());

                if (Request["type"] == "LogInOut")
                {
                    //CleanUpApplicationState();

                    CleanUpOldSessions();

                    LogSession("Redirecting to Login.aspx");

                    string userName = Request["UserName"];
                    if (!string.IsNullOrEmpty(userName))
                        Response.Redirect("~/UI/Page/Login.aspx?UserName=" + userName, false);
                    else
                        Response.Redirect("~/UI/Page/Login.aspx", false);
                }
                else if (Request["type"] == "ForcePasswordChange")
                {
                    //CleanUpApplicationState();

                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff != null && !staff.ForcePasswordChange && !staff.IsAdmin) Response.Redirect("~/UI/Page/login.aspx");

                    CleanUpOldSessions();

                    LogSession("Redirecting to ForcePasswordChange.aspx"); 

                    string staffId = Request["StaffID"];

                    //string from = Request["from"];
                    //if(!string.IsNullOrEmpty(from))
                    //    Response.Redirect(string.Format("~/UI/Page/SimpleServings/Staff/ForcePasswordChange.aspx?from={0}&StaffID={1}", from.Trim(), staffId), false);
                    //else
                    
                    Response.Redirect("~/UI/Page/SimpleServings/Staff/ForcePasswordChange.aspx?StaffID=" + staffId, false);
                }

            }
        }

        private static void LogSession(string message)
        {
            var sessionCookie = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"];
            if (sessionCookie != null)
            {
                //Session["ASP.NET_SessionId"] = sessionCookie.Value;
                log.Info(string.Format("(landingPage.aspx) - {0} {1}Request Type: {2} {3}SessionId: {4}",
                    message, Environment.NewLine, HttpContext.Current.Request["type"], Environment.NewLine, sessionCookie.Value));
            }
        }

        private void CleanUpApplicationState()
        {
            HelpClasses.AppHelper.CleanUpApplicationState();
        }

        private void CleanUpOldSessions()
        {
            HelpClasses.AppHelper.CleanUpOldSessions();
        }
    }
}