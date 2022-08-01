using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

using log4net;
using log4net.Config;

namespace SimpleServings.UI.Page.SimpleServings.Recipe
{
    public partial class RecipeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
        }

        private static readonly ILog log = LogManager.GetLogger("AppManager");

        static RecipeList()
        {
            XmlConfigurator.Configure();
        }

        //protected void lnkLogOut_Click(object sender, EventArgs e)
        //{
        //    Session["UserObject"] = null;
        //    Session.Abandon();
        //    Response.Redirect("~/UI/Page/Home.aspx");
        //}

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null)
            {
                LogSession("Redirecting to Login.aspx");
                Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                //Response.Redirect("~/UI/Page/login.aspx");
            }

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                hlAddRecipe.Visible = false;
            }
        }

        private void LogSession(string message)
        {
            var sessionCookie = Request.Cookies["ASP.NET_SessionId"];
            if (sessionCookie != null)
            {
                //Session["ASP.NET_SessionId"] = sessionCookie.Value;
                log.Info(string.Format("(RecipeList.aspx) - {0} {1}SessionId: {2}", message, Environment.NewLine, sessionCookie.Value));
            }
        }
        
    }
}