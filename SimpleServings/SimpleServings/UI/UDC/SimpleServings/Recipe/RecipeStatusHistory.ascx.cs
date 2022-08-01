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
using SimpleServingsLibrary.Shared;


namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class RecipeStatusHistory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
            }
            catch (ApplicationException ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
            if (!Page.IsPostBack)
            {
                if (Request["CaseID"] != null)
                {
                    int caseID = Convert.ToInt32(Request["CaseID"].ToString());
                    PopGrid(caseID);
                }
            }
        }
        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
              
        public void PopGrid(int recipeID)
        {
            try
            {
                PopGrid(SimpleServingsLibrary.Recipe.RecipeStatusHistory.GetRecipeStatusHistoryByRecipeID(recipeID));
            }
            catch
            {
                PopGrid(null);
            }
        }

        private void PopGrid(SimpleServingsLibrary.Recipe.RecipeStatusHistories queues)
        {
            try
            {
                if (queues == null)
                    throw new Exception();
                this.gvStatusHistory.DataSource = queues;
                this.gvStatusHistory.DataBind();
                //this.lblCount.ForeColor = System.Drawing.Color.Green;
                //this.lblCount.Text = string.Format("{0} status(es) found", queues.Count);

            }
            catch
            {
                this.gvStatusHistory.DataSource = null;
                this.gvStatusHistory.DataBind();
                //this.lblCount.ForeColor = System.Drawing.Color.Red;
                //this.lblCount.Text = "No status history";

            }
        }
    }
}