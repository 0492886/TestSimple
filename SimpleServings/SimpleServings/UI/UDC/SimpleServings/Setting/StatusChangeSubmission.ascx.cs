using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class StatusChangeSubmission : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (!Page.IsPostBack)
            {
                PopDropDownList();               
            }
        }

        // delete //
        protected void testPage_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (!Page.IsPostBack)
            {
                PopDropDownList();
            }
        }
        //

        private void PopDropDownList()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (Request["StatusID"] != null)
            {     
                try
                {                                        
                    SimpleServingsLibrary.Shared.Code code = new SimpleServingsLibrary.Shared.Code();
                    code.GetCodeByCodeID(Convert.ToInt32(Request["StatusID"]));
                    
                    SimpleServingsLibrary.Shared.Code.CodeTypes deCodeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), code.CodeType);
                    SimpleServingsLibrary.Shared.Codes codes = SimpleServingsLibrary.Shared.Code.GetCodesByTypeAndUserGroup(deCodeType, staff.UserGroup);
                    SimpleServingsLibrary.Shared.Codes ShortCodeList = GetShortCodelist(codes);

                    ddlRecipeStatus.DataSource = ShortCodeList;
                    ddlRecipeStatus.DataTextField = "CodeDescription";
                    ddlRecipeStatus.DataValueField = "CodeID";
                    ddlRecipeStatus.DataBind();

                    ddlRecipeStatus.ClearSelection();
                    ddlRecipeStatus.Items.FindByValue(Request["StatusID"].ToString()).Selected = true;
                }
                catch { }
            }
        }
        
        private SimpleServingsLibrary.Shared.Codes GetShortCodelist(SimpleServingsLibrary.Shared.Codes codes)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            SimpleServingsLibrary.Shared.Codes shortCodes = new SimpleServingsLibrary.Shared.Codes();            
            foreach (SimpleServingsLibrary.Shared.Code code in codes)
            {
                string msg = "";
                if (SimpleServingsLibrary.Shared.Rule.SatisfyRules(code.CodeID, Convert.ToInt32(Request["KeyID"].ToString()), staff.StaffID, ref msg,code.CodeID))
                    shortCodes.Add(code);   
            }
            return shortCodes;
        }

        protected void btnEditRecipeStatus_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            int recipeID =0;
            Int32.TryParse(Request["KeyID"].ToString(), out recipeID);
            int recipeStatus = 0;
            Int32.TryParse(ddlRecipeStatus.SelectedValue, out recipeStatus);
            SimpleServingsLibrary.Recipe.Recipe recipe = new SimpleServingsLibrary.Recipe.Recipe();
            try
            {
                recipe.GetRecipeByRecipeID(recipeID);
                recipe.EditRecipeStatus(recipeStatus, staff.StaffID, txtCustomMessage.Text);
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Status changed successfully";
                btnEditRecipeStatus.Visible = false;
                string url = string.Format("~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID={0}",recipeID);
                Response.Redirect(url);      
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;            
            }
        }
    }
}