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

namespace SimpleServings.UI.Page.SimpleServings.Staff
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
                //if (staff != null && staff.IsAdmin)
                //{
                //    var sessionCookie = Request.Cookies["ASP.NET_SessionId"];
                //    if (sessionCookie != null)
                //    {
                //        ScriptManager.RegisterClientScriptBlock(Page, GetType(), Guid.NewGuid().ToString(), "alert('SessionId: " + sessionCookie.Value + "');", true);
                //    }
                //}

                //if (Request.UrlReferrer == null || Request.UrlReferrer.Host.ToLower() != Request.Url.Host.ToLower())
                //{
                //    Response.Redirect("~/UI/Page/Login.aspx");
                //}
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {           
            SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
            try
            {
                staff.GetStaffByEmail(txtEmail.Text.Trim());
                if (staff.IsLocked)
                {
                    lblMsg.Text = "The account associated with the email address you've entered has been locked due to too many login attempts.  Contact <a href=mailto:" + System.Configuration.ConfigurationManager.AppSettings["AdminEmail"] + "> SimpleServings technical support </a> to unlock the account. ";
                }
                else
                {
                    staff.Password = SimpleServingsLibrary.Shared.Staff.GeneratePassword();
                    staff.ForcePasswordChange = true;
                    staff.EditStaff();
                    //SimpleServingsLibrary.Shared.Mailer.SendMail(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"], staff.Email, staff);
                    lblMsg.Text = "We will send your username and password to your email address. If you don’t receive any email from us, Contact <a href=mailto:" + System.Configuration.ConfigurationManager.AppSettings["AdminEmail"] + "> SimpleServings technical support </a> to look up your account. ";
                }
            }
            catch { lblMsg.Text = "We cannot find an account with that email address. Please contact <a href=mailto:" + System.Configuration.ConfigurationManager.AppSettings["AdminEmail"] + "> SimpleServings technical support </a> to look up your account. "; }
            
        }
    }
}
