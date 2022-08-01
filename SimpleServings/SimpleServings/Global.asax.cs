using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using log4net;
using log4net.Config;

namespace SimpleServings
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger("AppManager");

        protected void Application_Start(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
            log.Info("SimpleServings started.");

            Server.ScriptTimeout = 3600;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            log.Error(string.Format("SimpleServings application error: {0}\nlocation: {1}\n", ex.Message, Request.Url), ex);
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{
        //
        //}

        //protected void Session_End(object sender, EventArgs e)
        //{
        //
        //}
    }
}