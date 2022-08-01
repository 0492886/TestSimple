using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;


namespace SimpleServings.UI.UDC.SimpleServings.Reports
{
    public partial class ucCountMenusWithCycleIdByRecipeIDParameter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            ApplyPermissions();

            if (!IsPostBack)
            {
                try
                {
                    SimpleServingsLibrary.Shared.Reports reports = new SimpleServingsLibrary.Shared.Reports();
                    reports = SimpleServingsLibrary.Shared.Report.GetRecipesForCountMenusbyCycleRecipeIDReport();

                    ddlRecipeID.DataSource = reports;
                    ddlRecipeID.DataTextField = "RecipeIDRecipeName";
                    ddlRecipeID.DataValueField = "RecipeID";
                    ddlRecipeID.DataBind();
                    ddlRecipeID.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
                }
                catch { }
            }


        }


        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ReportModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        protected void ddlRecipeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCycleID.Items.Clear();
            ddlRecipeView.Items.Clear();
            tbStartDate.Text = "";
            tbEndDate.Text = "";

            int recipeID = 0;
            Int32.TryParse(ddlRecipeID.SelectedValue, out recipeID) ;
            SimpleServingsLibrary.Shared.Reports reports = new SimpleServingsLibrary.Shared.Reports();
            reports = SimpleServingsLibrary.Shared.Report.GetRecipeViews(recipeID);
            ddlRecipeView.DataSource = reports;
            ddlRecipeView.DataTextField = "Rec_Viewname";
            ddlRecipeView.DataValueField = "RecipeView";
            ddlRecipeView.DataBind();
            ddlRecipeView.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));

        }

        protected void ddlRecipeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCycleID.Items.Clear();
            tbStartDate.Text = "";
            tbEndDate.Text = "";
            ListItem ls = new ListItem() { Text = "[Select]", Value = GlobalEnum.EmptyCode.ToString() };
            ddlRecipeView.Items.Remove(ls);

            int recipeID = 0;
            int recipeView = 0;
            Int32.TryParse(ddlRecipeID.SelectedValue, out recipeID);
            Int32.TryParse(ddlRecipeView.SelectedValue, out recipeView);

            SimpleServingsLibrary.Shared.Reports reports = new SimpleServingsLibrary.Shared.Reports();
            reports = SimpleServingsLibrary.Shared.Report.GetCycleIDbyRecipeIDAndRecipeView(recipeID, recipeView);
            ddlCycleID.DataSource = reports;
            ddlCycleID.DataTextField = "season";
            ddlCycleID.DataValueField = "CycleID";
            ddlCycleID.DataBind();
            ddlCycleID.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));

        }



        public void GetReportParameters(out int RecipeID, out int RecipeView, out int CycleID, out DateTime StartDate, out DateTime EndDate)
        {
            Int32.TryParse(ddlRecipeID.SelectedValue, out RecipeID);
            Int32.TryParse(ddlRecipeView.SelectedValue, out RecipeView);
            Int32.TryParse(ddlCycleID.SelectedValue, out CycleID);
            DateTime.TryParse(tbStartDate.Text, out StartDate);
            DateTime.TryParse(tbEndDate.Text, out EndDate); 
        }
    }
}