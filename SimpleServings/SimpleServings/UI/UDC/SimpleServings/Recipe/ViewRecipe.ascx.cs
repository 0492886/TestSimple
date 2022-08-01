using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SimpleServingsLibrary.Shared;
using SimpleServingsLibrary.RecipeSupplement;
using SimpleServingsLibrary.Recipe;

using AjaxControlToolkit;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class ViewRecipe : System.Web.UI.UserControl
   {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
                int recipeID = 0;
                lblMsg.Text = String.Empty;
                if (!Page.IsPostBack)
                {

                    if (Request["RecipeID"] != null)
                    {
                        Int32.TryParse(Request["RecipeID"].ToString(), out recipeID);
                        lblRecipeID.Text = recipeID.ToString();
                        SetLink(recipeID);
                        PopRecipe(recipeID);
                        PopIngredients(recipeID);
                        PopRecipeSupplements(recipeID);
                        //PopRecipeNutrition(recipeID);
                        PopNotes(recipeID);
                        PopRecipeStatusActionPanel(recipeID);
                        PopFavoriteLink();
                        PopDeactivateLink();
                        PopRecipeHistory(recipeID);

                    }
                    
                }
            }
            catch (ApplicationException ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }


        }

        private void SetLink(int recipeID)
        {
            //string path = ConfigurationManager.AppSettings["PrintRecipeURL"] + "RecipeID=" + recipeID;
            //lnkPrintRecipe.HRef = path; 
        }

        protected void lnkPrintRecipe_Click(object sender, EventArgs e)
        {
            int RecipeID = 0;
            Int32.TryParse(Request["RecipeID"].ToString(), out RecipeID);


            Response.Redirect("~/UI/Page/SimpleServings/Reports/ViewRecipeReport.aspx?RecipeID=" + RecipeID);
        }

        private void PopRecipeStatusActionPanel(int recipeID)
        {
            StatusChangeActionPanel1.Initialization(recipeID, SimpleServingsLibrary.Shared.Code.CodeTypes.RecipeStatus);
        }
        //private void PopRecipeNutrition(int recipeID)
        //{
        //    ViewRecipeNutrition1.PopAllNutrition(recipeID);
        //}

        private void PopIngredients(int recipeID)
        {
            ViewRecipeIngredient1.PopGrid(recipeID);
        }

        private void PopRecipeSupplements(int recipeID)
        {
            ViewRecipeSupplement1.PopGrid(recipeID);
            ViewRecipeSupplement2.PopGrid(recipeID);
            ViewRecipeSupplement3.PopGrid(recipeID);
        }

        private void PopRecipeRating(int recipeID)
        {
            //System.Diagnostics.Debugger.Launch();

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            Rating1.MaxRating = Convert.ToInt32(ConfigurationManager.AppSettings["RecipeMaxRating"]);
            try
            {
                Rating1.CurrentRating = SimpleServingsLibrary.Recipe.Recipe.GetRecipeRatingByID(recipeID, staff.StaffID);
                if (Rating1.CurrentRating > 0) lblRating.Text = "you have rated this recipe";
            }
            catch
            {
                Rating1.CurrentRating = 0;

                //lblMsg.ForeColor = System.Drawing.Color.Red;
                //lblMsg.Text = ex.Message;
            }

            pnlRating.Visible = true;
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

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                hlEdit.Visible = false;
                this.lnkBtnDeactivate.Visible = false;
                this.lnkBtnReactivate.Visible = false;
            }

            if (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.CATERER || staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.CONTRACT || staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.SPONSOR)
            {
                divUpdateInfo.Visible = false;
            }

        }

        private void PopNotes(int recipeID)
        {
            NoteHistory1.PopProgressNotes(recipeID, GlobalEnum.NoteType_Recipe, 0);
            //AddProgressNote1.InitializeControl(recipeID, GlobalEnum.NoteType_Recipe);
            //AddProgressNote1.IsUsedInWizard = true;
            //AddProgressNote1.ReferenceID = recipeID;
        }

        private void PopRecipeHistory(int recipeID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 

            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                divrcpHistory.Visible = false;
            }
            else
            {
                ucRecipeStatusHistory.PopGrid(recipeID); 
            }

 
        }
      
        private void PopRecipe(int recipeID)
        {
            hlEditStatus.NavigateUrl = string.Format("~/UI/Page/SimpleServings/Recipe/EditRecipeStatus.aspx?RecipeID={0}", recipeID);
            hlEdit.NavigateUrl = string.Format("~/UI/Page/SimpleServings/Recipe/EditRecipe.aspx?RecipeID={0}", recipeID);
            SimpleServingsLibrary.Recipe.Recipe recipe = new SimpleServingsLibrary.Recipe.Recipe();
            try
            {
                recipe.GetRecipeByRecipeID(recipeID);

                // If recipe is approved hide "Action Available" panel
                divRcpStatusAction.Visible = recipe.RecipeStatus == GlobalEnum.RecipeStatus_Approved ? false : true; 

                lblRecipeView.Text = recipe.RecipeViewText;
                if (recipe.RecipeView == GlobalEnum.RecipeView_SponsorPrivate)
                {
                    pnSponsor.Visible = true;
                    try
                    {
                        SimpleServingsLibrary.SupplierRelationship.Sponsor sp =
                        SimpleServingsLibrary.SupplierRelationship.Sponsor.GetSponsorByID(recipe.SupplierID);
                        lblSponsor.Text = sp.SponsorName;
                    }
                    catch { }

                }
                if (recipe.RecipeView == GlobalEnum.RecipeView_CatererPrivate)
                {
                    pnCaterer.Visible = true;
                    try
                    {
                        SimpleServingsLibrary.SupplierRelationship.Caterer cat =
                        SimpleServingsLibrary.SupplierRelationship.Caterer.GetCatererByID(recipe.SupplierID);
                        lblCaterer.Text = cat.CatererName;

                    }
                    catch { }
                    
                }
                int contributedBy = recipe.ContributorTypeID;
                
                if (contributedBy == GlobalEnum.ContributorType_Contract)
                {

                    try
                    {
                        SimpleServingsLibrary.SupplierRelationship.Contract contract =
                        SimpleServingsLibrary.SupplierRelationship.Contract.GetContractByID(recipe.ContributorID);
                        lblContributor.Text = contract.ContractName;

                    }
                    catch { }
                }
                else if (contributedBy == GlobalEnum.ContributorType_Caterer)
                {

                    try
                    {
                        SimpleServingsLibrary.SupplierRelationship.Caterer caterer =
                        SimpleServingsLibrary.SupplierRelationship.Caterer.GetCatererByID(recipe.ContributorID);
                        lblContributor.Text = caterer.CatererName;

                    }
                    catch { }
                }
            
                lblRecipeName.Text = recipe.RecipeName;
                lblYield.Text= recipe.Yield;
                lblServingSize.Text = recipe.ServingSize;
                lblPortionSize.Text = recipe.PortionSize;
                lblRecipeID.Text = recipe.RecipeID.ToString();
                lblActiveStatus.Text = recipe.ActiveStatus;
                lblRecipeApprovalSatus.Text = recipe.RecipeStatusText;
                lblLastUpdatedBy.Text = recipe.LastUpdatedByText;
                lblLastUpdatedOn.Text = recipe.LastUpdatedOn;

                string imgFilePath = ConfigurationManager.AppSettings["RecipeImagePath"] + recipe.RecipeImageName;
                bool exists = File.Exists(Server.MapPath(imgFilePath));

                if (exists)
                {
                    imgRecipe.ImageUrl = imgFilePath;
                    imgRecipe.Visible = true;
                }
                else
                {
                    imgRecipe.Visible = false;
                }

                SimpleServingsLibrary.Recipe.RecipeTags tags = SimpleServingsLibrary.Recipe.RecipeTag.GetRecipeTagsByRecipeID(recipeID);
                rptTags.DataSource = tags;
                rptTags.DataBind();

                List<string> cats = new List<string>();
                tags.ForEach(x=> cats.Add(x.CategoryName));
                
                cats = cats.Distinct().ToList();
                rpCategory.DataSource = cats;
                rpCategory.DataBind();

                if (hlEdit.Visible)
                {
                    if (recipe.IsActive)
                    {
                        lnkBtnDeactivate.Visible = true;
                        lnkBtnReactivate.Visible = false;
                    }
                    else
                    {
                        lnkBtnDeactivate.Visible = false;
                        lnkBtnReactivate.Visible = true;
                    }
                }

                //recipe rating
                if (recipe.IsActive)
                {
                    PopRecipeRating(recipeID);
                    //pnlRating.Visible = false;
                }
                else
                {
                    pnlRating.Visible = false;
                }
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int recipeID = Convert.ToInt32(lblRecipeID.Text);
            //((Label)AddProgressNote1.FindControl("lblNoteID")).Text = string.Empty;//this is to avoid editing the previously added note.
            //AddProgressNote1.AddNote();
            //AddProgressNote1.TxtNote = string.Empty; //this resets the textBox
            PopNotes(recipeID);//this updates NoteHistory control.
        }

        protected void lnkBtnFavorite_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            int recipeID = Convert.ToInt32(Request["RecipeID"]);
            RecipeFavorite.UpdateReciepFavorite(recipeID, staff.StaffID, lnkBtnFavorite.Text);
            PopFavoriteLink();
        }

        private void PopFavoriteLink()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            int recipeID = Convert.ToInt32(Request["RecipeID"]);

            RecipeFavorite rf = RecipeFavorite.GetRecipeFavoritesByRecipeIDAndStaffID(recipeID, staff.StaffID);
            if (rf.IsActive)
            {
                lnkBtnFavorite.Text = RecipeFavorite.RemoveText;
            }
            else
            {
                lnkBtnFavorite.Text = RecipeFavorite.AddText;
            }
        }

        private void PopDeactivateLink()
        {
            lnkBtnDeactivate.Attributes.Add("OnClick", "Javascript: return confirm('Do you want to delete this recipe?');");
        }

        protected void lnkBtnDeactivate_Command(object sender, CommandEventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 

            if (e.CommandName == "Delete")
            {
                int recipeID = Convert.ToInt32(Request["RecipeID"]);
                SimpleServingsLibrary.Recipe.Recipe.Deactivate(recipeID, staff.StaffID);
                PopRecipe(recipeID);
            }
            else if (e.CommandName == "Reactivate")
            {
                int recipeID = Convert.ToInt32(Request["RecipeID"]);
                //reactivate recipe
                SimpleServingsLibrary.Recipe.Recipe.Activate(recipeID);
                PopRecipe(recipeID);
            }
        }
        protected void lnkScale_Click(object sender, EventArgs e)
        {
            int recipeID = 0;
            Int32.TryParse(lblRecipeID.Text, out recipeID);
            int scaleTo = 0;
            Int32.TryParse(txtScaleTo.Text, out scaleTo);

            string url = ResolveClientUrl(string.Format("~/UI/Page/SimpleServings/Recipe/ScaledIngredient.aspx?RecipeID={0}&ScaleTo={1}", recipeID, scaleTo));
            //Response.Redirect(string.Format("~/UI/Page/SimpleServings/Recipe/ScaledIngredient.aspx?RecipeID={0}&ScaleTo={1}", recipeID, scaleTo));
            ScriptManager.RegisterStartupScript(this, typeof(string), "OpenWindow", "window.open('" + url + "');", true);            
        }

        protected void Rating1_Changed(object sender, RatingEventArgs e)
        {
            Rating rating = (Rating)sender;
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            try
            {
                if (!pnlRating.Visible) throw new Exception("invalid operation");

                int recipeID = Convert.ToInt32(Request["RecipeID"]);
                SimpleServingsLibrary.Recipe.Recipe.AddRecipeRating(recipeID, staff.StaffID, rating.CurrentRating);
                lblRating.Text = "you have updated your recipe rating";
            }
            catch { }
        }

    }
}