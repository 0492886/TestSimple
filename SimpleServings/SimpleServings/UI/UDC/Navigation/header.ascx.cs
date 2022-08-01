namespace SimpleServings.UI.UDC.Navigation
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
    using SimpleServingsLibrary.Shared;

	/// <summary>
	///		Summary description for header.
	/// </summary>
	public partial class header : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlAnchor lnkLogOff;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                hlkLogInOut.Text = (staff == null) ? "Log In" : "Log Out";
                //lnkBLogInOut.Text = (staff == null) ? "Log In" : "Log Out";
            }

            hlHome.NavigateUrl = ResolveUrl("~/UI/Page/Home.aspx");
            hlkLogInOut.NavigateUrl = ResolveUrl("~/UI/Page/landingPage.aspx?type=LogInOut");

            //ApplyPermissions();
        }

        protected void lnkLogOff_Click(object sender, EventArgs e)
        {
            
            Session.Abandon();
            Response.Redirect(@"../../../../UI/Page/home.aspx");

        }
        protected void lnkBLogOff_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/Login.aspx", false);
        }

        //private void CleanUpOldSessions()
        //{
        //    HelpClasses.AppHelper.CleanUpOldSessions();
        //}

        //private void ApplyPermissions()
        //{
        //    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
        //    if (staff == null) Response.Redirect("~/UI/Page/login.aspx");
        //    if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Add))
        //    {
        //        lnkAddRecipe.Visible = false;
        //    }
        //}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
	
		}

       
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>

		#endregion
	}
}
