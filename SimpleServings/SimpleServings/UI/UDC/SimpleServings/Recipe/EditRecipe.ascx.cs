using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;
using System.Text;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class EditRecipe : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ApplyPermissions();
                    
                    if (Request["RecipeID"] != null)
                    {
                        int recipeID = 0;
                        Int32.TryParse(Request["RecipeID"].ToString(), out recipeID);
                        lblRecipeID.Text = recipeID.ToString();
                        InitializeControls(recipeID);
                        PopRecipe(recipeID);
                        PopNotes(recipeID);
                    }
                   
                }

                catch (ApplicationException ex)
                {

                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }

        }
        private void PopNotes(int recipeID)
        {
           NoteHistory1.PopProgressNotes(recipeID, GlobalEnum.NoteType_Recipe, 0);

            AddProgressNote1.InitializeControl(recipeID, GlobalEnum.NoteType_Recipe);
            AddProgressNote1.IsUsedInWizard = true;
            AddProgressNote1.ReferenceID = recipeID;
        
        }

        private void PopRecipe(int recipeID)
        {
            SimpleServingsLibrary.Recipe.Recipe recipe = new SimpleServingsLibrary.Recipe.Recipe();
            try
            {
                recipe.GetRecipeByRecipeID(recipeID);

                ddlRecipeView.ClearSelection();
                try
                {
                    ddlRecipeView.Items.FindByValue(recipe.RecipeView.ToString()).Selected = true;
                }
                catch { }

                if (recipe.RecipeView == GlobalEnum.RecipeView_SponsorPrivate)
                {
                    pnSponsor.Visible = true;
                    ddlSponsor.ClearSelection();
                    try
                    {
                        ddlSponsor.Items.FindByValue(recipe.SupplierID.ToString()).Selected = true;
                    }
                    catch { }
                }
                if (recipe.RecipeView == GlobalEnum.RecipeView_CatererPrivate)
                {
                    pnCaterer.Visible = true;
                    ddlCaterer.ClearSelection();
                    try
                    {
                        ddlCaterer.Items.FindByValue(recipe.SupplierID.ToString()).Selected = true;
                    }
                    catch { }
                }

                ddlContributedBy.ClearSelection();
                try
                {
                    ddlContributedBy.Items.FindByValue(recipe.ContributorTypeID.ToString()).Selected = true;
                }
                catch { }
                PopContributer();


                ddlContributor.ClearSelection();
                try
                {
                    ddlContributor.Items.FindByValue(recipe.ContributorID.ToString()).Selected = true;
                }
                catch { }



                txtRecipeName.Text = recipe.RecipeName;
                txtYield.Text = recipe.Yield;
                txtServingSize.Text = recipe.ServingSize;
                txtPortionSize.Text = recipe.PortionSize;
                try
                {
                    RecipeImage1.GetImageFromDirectory();
                    RecipeImage1.SetSelectedRecipeImage(recipe.RecipeImageName);
                }
                catch { }
                //txtSKU.Text=recipe.SKU ;

                //Mandy add, if RecipeID has Categories (4 kinds, like Meal Components, Cuisines ), all the tag in that category are enable, otherwise not enable 
                List<int> intTaglist = SimpleServingsLibrary.Recipe.RecipeTag.GetTagIdByRecipeID(recipeID);

                foreach (ListItem item in cblTags.Items)
                {

                    if (intTaglist.Contains(Convert.ToInt32(item.Value)))
                        item.Enabled = true;
                    else
                        item.Enabled = false;
                }

                //SimpleServingsLibrary.Recipe.RecipeTags tags = SimpleServingsLibrary.Recipe.RecipeTag.GetRecipeTagsByRecipeID(recipeID);
                SimpleServingsLibrary.Recipe.RecipeTags tags = SimpleServingsLibrary.Recipe.RecipeTag.GetCategoriesandTagsByRecipeID(recipeID);

                try
                {

                    foreach (SimpleServingsLibrary.Recipe.RecipeTag tag in tags)
                    {
                        if (tag.CategoryID != 0)
                        {
                            cbCategories.Items.FindByValue(tag.CategoryID.ToString()).Selected = true;
                        }

                    }

                    foreach (SimpleServingsLibrary.Recipe.RecipeTag tag in tags)
                    {
                        if (tag.TagID != 0)
                        {
                            cblTags.Items.FindByValue(tag.TagID.ToString()).Selected = true;
                        }

                    }
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }



                //int tagID = 0;
                //foreach (ListItem cb in cblTags.Items)
                //{
                //    Int32.TryParse(cb.Value, out tagID);
                //    foreach(SimpleServingsLibrary.Recipe.RecipeTag tag in tags)
                //    {
                //        if (tag.TagID == tagID)
                //        {
                //            cb.Selected = true;
                //            break;
                //        }
                //    }
                //}
            }
            catch { }
            
        }

        private void InitializeControls(int recipeID)
        {
            AddEditRecipeSupplement1.ClearSession();
            AddEditRecipeSupplement2.ClearSession();
            AddEditRecipeSupplement3.ClearSession();
            AddEditRecipeIngredient1.ClearSession();

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");             

            try
            {
                SimpleServingsLibrary.Shared.Codes Categories = SimpleServingsLibrary.Shared.Code.GetCodesByType(Code.CodeTypes.Categories);
                cbCategories.DataSource = Categories;
                cbCategories.DataTextField = "CodeDescription";
                cbCategories.DataValueField = "CodeID";
                cbCategories.DataBind();


                SimpleServingsLibrary.Shared.Codes tags = SimpleServingsLibrary.Shared.Code.GetCodesByType(Code.CodeTypes.Tag);
                cblTags.DataSource = tags;
                cblTags.DataTextField = "CodeDescription";
                cblTags.DataValueField = "CodeID";
                cblTags.DataBind();

                //foreach (ListItem item in cblTags.Items)
                //{
                //    item.Enabled = false;
                //}

            }
            catch
            {
                cblTags.DataSource = null;
                cblTags.DataBind();
            }

            try
            {
                SimpleServingsLibrary.SupplierRelationship.Sponsors sponsors =
                SimpleServingsLibrary.SupplierRelationship.Sponsor.GetSponsorAll();
                ddlSponsor.DataSource = sponsors;
                ddlSponsor.DataTextField = "SponsorName";
                ddlSponsor.DataValueField = "SponsorID";
                ddlSponsor.DataBind();
                ddlSponsor.Items.Insert(0, new ListItem("[Select]", "0"));

            }
            catch { }
            try
            {
                SimpleServingsLibrary.SupplierRelationship.Caterers caterers =
                    SimpleServingsLibrary.SupplierRelationship.Caterer.GetCatererAll();
                ddlCaterer.DataSource = caterers;
                ddlCaterer.DataTextField = "CatererName";
                ddlCaterer.DataValueField = "CatererID";
                ddlCaterer.DataBind();
                ddlCaterer.Items.Insert(0, new ListItem("[Select]", "0"));

            }
            catch { }

            try
            {
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlContributedBy, Code.CodeTypes.ContributorType, staff.UserGroup, "");
            }
            catch { }

            



            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupNoSelectNoAll(ddlRecipeView, Code.CodeTypes.RecipeView, staff.UserGroup, "");

            AddEditRecipeIngredient1.PopGrid(recipeID);
            AddEditRecipeSupplement2.PopGrid(recipeID);
            AddEditRecipeSupplement1.PopGrid(recipeID);           
            AddEditRecipeSupplement3.PopGrid(recipeID);
            AddEditRecipeNutrition1.PopGrid(recipeID);
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.RecipeModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        private void GetValuesFromControls(ref SimpleServingsLibrary.Recipe.Recipe recipe)
        {
            int recipeView = 0;
            Int32.TryParse(ddlRecipeView.SelectedValue, out recipeView);
            recipe.RecipeView = recipeView;
            int supplierID = 0;
            if (recipeView == GlobalEnum.RecipeView_SponsorPrivate)
            {
                Int32.TryParse(ddlSponsor.SelectedValue, out supplierID);
            }
            if (recipeView == GlobalEnum.RecipeView_CatererPrivate)
            {
                Int32.TryParse(ddlCaterer.SelectedValue, out supplierID);
            }
            recipe.SupplierID = supplierID;
            int contributorTypeID = 0;
            Int32.TryParse(ddlContributedBy.SelectedValue, out contributorTypeID);
            recipe.ContributorTypeID = contributorTypeID;
            int contributorID = 0;
            Int32.TryParse(ddlContributor.SelectedValue, out contributorID);
            recipe.ContributorID = contributorID;
            recipe.RecipeName = ValidateRecipeName(HttpUtility.HtmlEncode(txtRecipeName.Text.Trim()));
            recipe.Yield =txtYield.Text;
            recipe.ServingSize = txtServingSize.Text;
            recipe.PortionSize = txtPortionSize.Text;
            recipe.RecipeImageName = RecipeImage1.GetSelectedRecipeImage();
            //recipe.SKU = txtSKU.Text;
        }

        private string ValidateRecipeName(string recipeNameInput)
        {
            if (recipeNameInput.Contains("&lt;b&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;b&gt;"));
            if (recipeNameInput.Contains("<b>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<b>"));
            if (recipeNameInput.Contains("\u003Cb\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cb\u003E"));
            if (recipeNameInput.Contains("<br>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<br>"));
            if (recipeNameInput.Contains("&lt;i&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;i&gt;"));
            if (recipeNameInput.Contains("<i>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<i>"));
            if (recipeNameInput.Contains("\u003Ci\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ci\u003E"));
            if (recipeNameInput.Contains("&lt;script&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;script&gt;"));
            if (recipeNameInput.Contains("<script>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<script>"));
            if (recipeNameInput.Contains("\u003Cscript\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cscript\u003E"));
            if (recipeNameInput.Contains("&lt;iframe&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;iframe&gt;"));
            if (recipeNameInput.Contains("<iframe>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<iframe>"));
            if (recipeNameInput.Contains("\u003Ciframe\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ciframe\u003E"));
            if (recipeNameInput.Contains("&lt;frame&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;frame&gt;"));
            if (recipeNameInput.Contains("<frame>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<frame>"));
            if (recipeNameInput.Contains("\u003Cframe\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cframe\u003E"));

            if (recipeNameInput.Contains("&lt;a&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;a&gt;"));
            if (recipeNameInput.Contains("<a>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<a>"));
            if (recipeNameInput.Contains("\u003Ca\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Ca\u003E"));
            if (recipeNameInput.ToLower().Contains("&lt;img&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;img&gt;"));
            if (recipeNameInput.ToLower().Contains("<img>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<img>"));
            if (recipeNameInput.Contains("\u003Cimg\u003E") || recipeNameInput.Contains("\u003CIMG\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cimg\u003E"));

            if (recipeNameInput.Contains("&lt;!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;!--#include"));
            if (recipeNameInput.Contains("<!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<!--#include"));
            if (recipeNameInput.Contains("\u003C!--#include"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003C!--#include"));

            if (recipeNameInput.ToLower().Contains("&lt;style&gt;"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "&lt;style&gt;"));
            if (recipeNameInput.ToLower().Contains("<style>"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "<style>"));
            if (recipeNameInput.Contains("\u003Cstyle\u003E") || recipeNameInput.Contains("\u003CSTYLE\u003E"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "\u003Cstyle\u003E"));

            if (recipeNameInput.Contains("|echo"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "|echo"));

            if (recipeNameInput.ToLower().Contains("javascript:"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "javascript:"));
            if (recipeNameInput.ToLower().Contains("src="))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "src="));
            if (recipeNameInput.ToLower().Contains("file="))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "file="));
            if (recipeNameInput.ToLower().Contains("@import"))
                throw new Exception(string.Format("Invalid characters detected ...{0}...", "@import"));

            StringBuilder sb = new StringBuilder(recipeNameInput);

            sb.Replace("\u003C", string.Empty); // Remove <
            sb.Replace("\u003E", string.Empty); // Remove >
            //sb.Replace("\u0028", string.Empty); // Remove (
            //sb.Replace("\u0029", string.Empty); // Remove )
            //sb.Replace("&quot;", string.Empty); // Remove "
            sb.Replace("&lt;", string.Empty); // Remove <
            sb.Replace("&gt;", string.Empty); // Remove >
            sb.Replace(";", string.Empty);

            return sb.ToString();
        }

        private void SaveRecipe()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 
            bool saved = false;
            StringBuilder sb = new StringBuilder();
            try
            {

                ValidateTags(sb);
                ValidateNutrients(sb);
                int recipeView = 0;
                Int32.TryParse(ddlRecipeView.SelectedValue, out recipeView);
                if (recipeView == GlobalEnum.RecipeView_Public)
                {
                    ValidateIngredients(sb);
                    ValidateDirections(sb);
                }
                if (sb.Length != 0)
                    throw new Exception(sb.ToString());                  
                int recipeID = 0;
                Int32.TryParse(lblRecipeID.Text, out recipeID);
                SimpleServingsLibrary.Recipe.Recipe recipe = new SimpleServingsLibrary.Recipe.Recipe();
                recipe.GetRecipeByRecipeID(recipeID);
                GetValuesFromControls(ref recipe);
                recipe.EditRecipe(staff.StaffID);

                SimpleServingsLibrary.Recipe.RecipeTag tag = new SimpleServingsLibrary.Recipe.RecipeTag();
                int tagID = 0;
                tag.RemoveRecipeTagsByRecipeID(recipeID);

                List<int> Categories = new List<int>();

                foreach (ListItem item in cbCategories.Items)
                {
                    if (item.Selected == true)
                        Categories.Add(Int32.Parse(item.Value));
                }

                List<int> Tags = new List<int>();

                foreach (ListItem cb in cblTags.Items)
                {
                    if (cb.Selected)
                    {
                        Tags.Add(Int32.Parse(cb.Value));
                    }
                }

                // Add Categories and Tags for Recipe 
                tag.AddCategoryandTagForRecipe(recipeID, Categories, Tags, staff.StaffID);

                
                
                
                
                //foreach (ListItem cb in cblTags.Items)
                //{
                //    if (cb.Selected)
                //    {
                //        tag.RecipeID = recipeID;
                //        Int32.TryParse(cb.Value, out tagID);
                //        tag.TagID = tagID;
                //        tag.AddRecipeTag();
                //    }
                //}










                AddEditRecipeIngredient1.SaveIngredient(recipeID);
                AddEditRecipeSupplement1.SaveSortOrder();
                AddEditRecipeSupplement1.SaveRecipeSupplement(recipeID);
                AddEditRecipeSupplement2.SaveRecipeSupplement(recipeID);
                AddEditRecipeSupplement3.SaveRecipeSupplement(recipeID);
                AddEditRecipeNutrition1.SaveNutrition(recipeID);
                AddProgressNote1.AddNote();
                saved = true;
           
            if (saved)
            {
                string url = ResolveUrl("~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=" + recipe.RecipeID);
                Response.Redirect(url);
            }
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
            
        }
        private void ValidateNutrients(StringBuilder sb)
        {
            if (!AddEditRecipeNutrition1.HasItems())
                sb.Append("Nutrients are required!<br/>");
            try
            {
                AddEditRecipeNutrition1.Validate();
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message);
            }

        }
        private void ValidateDirections(StringBuilder sb)
        {
            if (!AddEditRecipeSupplement1.HasItems())
                sb.Append("Directions are required!<br/>");
        }

        private void ValidateIngredients(StringBuilder sb)
        {
            if (!AddEditRecipeIngredient1.HasItems())
                sb.Append("Ingredients are required!<br/>");
        }

        private void ValidateTags(StringBuilder sb)
        {
            bool tagged = false;
            foreach (ListItem cb in cblTags.Items)
            {
                if (cb.Selected)
                {
                    tagged = true;
                    break;
                }
            }
            if (!tagged)
                sb.Append("Recipe Tags are required!<br/>");
        }

        protected void btnEditRecipe_Click(object sender, EventArgs e)
        {
            SaveRecipe();
        }

        protected void ddlRecipeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int recipeView = 0;
            Int32.TryParse(ddlRecipeView.SelectedValue, out recipeView);
            if (recipeView == GlobalEnum.RecipeView_SponsorPrivate)
            {
                pnSponsor.Visible = true;
                pnCaterer.Visible = false;
            }
            else if (recipeView == GlobalEnum.RecipeView_CatererPrivate)
            {
                pnSponsor.Visible = false;
                pnCaterer.Visible = true;
            }
            else
            {
                pnSponsor.Visible = false;
                pnCaterer.Visible = false;
            }
        }

        protected void ddlContributedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopContributer();

        }

        private void PopContributer()
        {
            int contributedBy = 0;
            Int32.TryParse(ddlContributedBy.SelectedValue, out contributedBy);
            if (contributedBy == GlobalEnum.ContributorType_Contract)
            {

                try
                {
                    SimpleServingsLibrary.SupplierRelationship.Contracts contracts =
                        SimpleServingsLibrary.SupplierRelationship.Contract.GetContractAll();
                    ddlContributor.DataSource = contracts;
                    ddlContributor.DataTextField = "ContractName";
                    ddlContributor.DataValueField = "ContractID";
                    ddlContributor.DataBind();
                    ddlContributor.Items.Insert(0, new ListItem("[Select]", "0"));

                }
                catch { }
            }
            else if (contributedBy == GlobalEnum.ContributorType_Caterer)
            {

                try
                {
                    SimpleServingsLibrary.SupplierRelationship.Caterers caterers =
                        SimpleServingsLibrary.SupplierRelationship.Caterer.GetCatererAll();
                    ddlContributor.DataSource = caterers;
                    ddlContributor.DataTextField = "CatererName";
                    ddlContributor.DataValueField = "CatererID";
                    ddlContributor.DataBind();
                    ddlContributor.Items.Insert(0, new ListItem("[Select]", "0"));

                }
                catch { }
            }
        }
        /*[System.Web.Services.WebMethod]
        public static void SaveMethod()
        {
            var tempObj = new EditRecipe();
            tempObj.SaveRecipe();
        }*/

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.RecipeImage1.ClearSelectedRecipeIamge();
        }



        protected void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

            CheckBoxList cbList = (CheckBoxList)sender;
            string[] control = Request.Form.Get("__EVENTTARGET").Split('$');
            int index = control.Length - 1;
            string selectedCategory = cbList.Items[Int32.Parse(control[index])].Value;


            int CategoryId = 0;
            Int32.TryParse(selectedCategory, out CategoryId);

            ManageCategoriesandTagsList tagList = new ManageCategoriesandTagsList();
            tagList = SimpleServingsLibrary.Shared.ManageCategoriesandTags.GetTagsByCategoryID(CategoryId);

            foreach (var item in tagList)
            {
                if (cbCategories.Items.FindByValue(CategoryId.ToString()).Selected == true)
                {
                    cblTags.Items.FindByValue(item.TagID.ToString()).Enabled = true;
                    cblTags.Items.FindByValue(item.TagID.ToString()).Attributes.Add("style", "background-color: aliceblue; font-weight:bold; color:green;");
                }
                else
                {
                    cblTags.Items.FindByValue(item.TagID.ToString()).Selected = false;
                    cblTags.Items.FindByValue(item.TagID.ToString()).Enabled = false;
                    cblTags.Items.FindByValue(item.TagID.ToString()).Attributes.Add("style", "background-color: transparent; font-weight: regular;");
                }
            }

        }




    }
}