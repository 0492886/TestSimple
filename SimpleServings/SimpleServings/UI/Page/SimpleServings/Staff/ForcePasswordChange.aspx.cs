using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using log4net;
using log4net.Config;

namespace SimpleServings.UI.Page.SimpleServings.Staff
{
    public partial class ForcePasswordChange : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger("AppManager");

        static ForcePasswordChange()
        {
            XmlConfigurator.Configure();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null) LogSession("Request from " + Request.UrlReferrer.ToString());
                LogSession(Request.Url.ToString());

                // Uncomment to add internal password security for users passing through via Juniper
                //string from = Request["from"];
                //if (!string.IsNullOrEmpty(from) && from.ToLower() == "juniper")
                //{
                //    LoadStaffAccountInfo();
                //}
                //else
                //{
                    if (Request.UrlReferrer == null || (!Request.UrlReferrer.ToString().ToLower().Contains("landingpage") && !Request.UrlReferrer.ToString().ToLower().Contains("login") && !Request.UrlReferrer.ToString().ToLower().Contains("home")))
                    {
                        SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                        if (staff == null || (staff.StaffID.ToString() != Request["StaffID"] && !staff.IsAdmin) || (staff.StaffID.ToString() == Request["StaffID"] && !staff.ForcePasswordChange))
                            Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                        //Response.Redirect("~/UI/Page/login.aspx");
                    }

                    if (Request["StaffID"] != null && Request["StaffID"].ToString() != "")
                    {
                        LoadStaffAccountInfo();
                    }
                    else
                    {
                        SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                        if (staff == null || !staff.IsAdmin) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

                        CleanUpOldSessions();
                    }
                //}
            }
        }

        private void LoadStaffAccountInfo()
        {
            CleanUpOldSessions();

            LogSession("Loading staff account info");

            AddEditAccountInfo1.PopStaffAccountInfo(Convert.ToInt32(Request["StaffID"].ToString()));
        }

        private void LogSession(string message)
        {
            var sessionCookie = Request.Cookies["ASP.NET_SessionId"];
            if (sessionCookie != null)
            {
                //Session["ASP.NET_SessionId"] = sessionCookie.Value;
                log.Info(string.Format("(ForcePasswordChange.aspx) - {0} {1}SessionId: {2}", message, Environment.NewLine, sessionCookie.Value));
            }
        }

        private void CleanUpOldSessions()
        {
            HelpClasses.AppHelper.CleanUpOldSessions();
        //    Session["UserObject"] = null;
        //    Session.Abandon();

        //    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddYears(-30);
        //    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        //    //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", "") { Secure = true });
        }
    }
}
