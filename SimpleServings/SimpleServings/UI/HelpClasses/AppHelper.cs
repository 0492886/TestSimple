using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleServings.UI.HelpClasses
{
    public class AppHelper
    {
        private static SimpleServingsLibrary.Shared.Staff User
        {
            set
            {
                HttpContext.Current.Session["UserObject"] = value;
                HttpContext.Current.Session.Timeout = HttpContext.Current.Session.Timeout;
            }
            get
            {
                SimpleServingsLibrary.Shared.Staff _staff = (SimpleServingsLibrary.Shared.Staff) HttpContext.Current.Session["UserObject"];
                return _staff;
            }
        }

        internal static protected void CleanUpOldSessions()
        {
            //HttpContext.Current.Session["UserObject"] = null;
            HttpContext.Current.Session.Abandon();
            //HttpContext.Current.Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1);
            HttpCookie cookie = new HttpCookie("ASP.NET_SessionId","");
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        internal static protected void CleanUpApplicationState()
        {
            HttpContext.Current.Application.Lock();
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff) HttpContext.Current.Application["UserObject"];
            if (staff != null)
            {
                if (User != null) throw new Exception("application state and session state are out of sync!");

                User = staff;
                //Session["UserObject"] = staff;
                HttpContext.Current.Application["UserObject"] = null;
            }
            HttpContext.Current.Application.UnLock();

        }

        internal static protected void GetLoggedInUser(SimpleServingsLibrary.Shared.Staff user)
        {
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application["UserObject"] = user;
            HttpContext.Current.Application.UnLock();
        }

        internal static protected void SetUser(SimpleServingsLibrary.Shared.Staff user)
        {
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application["UserObject"] = user;
            HttpContext.Current.Application.UnLock();
        }

        internal static protected SimpleServingsLibrary.Shared.Staff GetCurrentUser()
        {
            CleanUpApplicationState();
            return User;
        }
    }
}