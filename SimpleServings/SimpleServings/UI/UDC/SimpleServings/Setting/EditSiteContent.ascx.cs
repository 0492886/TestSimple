using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class EditSiteContent : System.Web.UI.UserControl
    {
        #region properties
        private string CurrentWelcomeMessage
        {
            get { return (ViewState["CurrentWelcomeMessage"] != null) ? (string)ViewState["CurrentWelcomeMessage"] : null; }
            set { ViewState["CurrentWelcomeMessage"] = value; }
        }
        private string CurrentNutritionalMessage
        {
            get { return (ViewState["CurrentNutritionalMessage"] != null) ? (string)ViewState["CurrentNutritionalMessage"] : null; }
            set { ViewState["CurrentNutritionalMessage"] = value; }
        }
        private string CurrentNutritionalTitle
        {
            get { return (ViewState["CurrentNutritionalTitle"] != null) ? (string)ViewState["CurrentNutritionalTitle"] : null; }
            set { ViewState["CurrentNutritionalTitle"] = value; }
        }
        private int CurrentRecipe
        {
            get { return (ViewState["CurrentRecipe"] != null) ? Convert.ToInt32(ViewState["CurrentRecipe"]) : -1; }
            set { ViewState["CurrentRecipe"] = value; }
        }

        private string NewWelcomeMessage
        {
            get { return (ViewState["NewWelcomeMessage"] != null) ? (string)ViewState["NewWelcomeMessage"] : null; }
            set { ViewState["NewWelcomeMessage"] = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplyPermissions();
            }
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null || !staff.IsAdmin)
            {
                pnPage.Visible = false;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "You are not allowed to access this page!";
            }
            else
            {
                pnWelcomeMessage.Visible = pnNutritionalMessage.Visible = false;
                pnFeaturedRecipe.Visible = true;

                PopRecipeSearchRepeater();
                PopFeaturedRecipe();

                lnkFeaturedRecipe.Style["font-style"] = "italic";
                lnkFeaturedRecipe.Style["font-weight"] = "bold";
            }
        }

        private void PopWelcomeMessage()
        {
            try
            {
                //ftbWelcomeMessage.UpdateToolbar = true;
                SimpleServingsLibrary.Resource.WelcomeMessage message = new SimpleServingsLibrary.Resource.WelcomeMessage();
                message.GetWelcomeMessage();

                string imageFile = message.ImageFile;
                if (string.IsNullOrEmpty(imageFile)) throw new Exception();
                string messageContent = message.Message;
                if (string.IsNullOrEmpty(messageContent)) throw new Exception();

                lblWelcomeImage.Text = "Current Image File: " + imageFile;
                lblWelcomeImage.Style["color"] = "black";
                lblWelcomeImage.Style["font-style"] = "italic";
                lblWelcomeImage.Style["font-size"] = "xx-small";

                this.CurrentWelcomeMessage = messageContent;
                txtWelcomeMessage.Text = this.CurrentWelcomeMessage.Replace("<br/>", "\n");

                //txtWelcomeMessage.Style["readonly"] = "readonly";
                //txtWelcomeMessage.CssClass = "msgDisabled";
                //txtWelcomeMessage.Attributes["placeholder"] = null;
                
                NewWelcomeMessage = null;
            }
            catch
            {
                this.CurrentWelcomeMessage = "Welcome to Simple Servings, a web-based menu application for congregate and home-delivered meal providers. This application allows users to view healthy recipes and menus, as well as develop menus that meet city, state and federal nutrition requirements. Simple Servings is the primary vehicle for the menu submission and approval process between contractors and DFTA Nutritional Services. The Intuitive Selections feature simplifies the overall process by notifying meal providers when menus meet all nutrition requirements. Simple Servings has replaced the paper menu submission process and drastically reduces the time spent on menu development, submission and approval. We hope this application simplifies and improves the menu creation process for you.";
                //ckeWelcomeMessage.Text = this.CurrentWelcomeMessage;
                NewWelcomeMessage = null;
            }
        }

        private void PopNutritionalMessage()
        {
            try
            {
                //SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                //if (staff == null || !staff.IsAdmin)
                //{
                //    throw new Exception("null");
                //}
                //else
                //{
                    SimpleServingsLibrary.Resource.NutritionalMessage message = new SimpleServingsLibrary.Resource.NutritionalMessage();
                    message.GetNutritionalMessage();

                    string messageTitle = message.MessageTitle;
                    if (string.IsNullOrEmpty(messageTitle)) throw new Exception();
                    string messageFile = message.MessageFile;
                    if (string.IsNullOrEmpty(messageFile)) throw new Exception();
                    string messageContent = message.MessageContent;
                    if (string.IsNullOrEmpty(messageContent)) throw new Exception();

                    this.CurrentNutritionalTitle = messageTitle;
                    txtNutritionalMessage.Text = this.CurrentNutritionalTitle;

                    lblMsgFile.Text = string.Format("Current Print File:&nbsp;<a target='_blank' style='font-size: xx-small;' href='../PDF/{0}'>{0}</a>", messageFile);
                    lblMsgFile.Style["color"] = "black";
                    lblMsgFile.Style["font-style"] = "italic";
                    lblMsgFile.Style["font-size"] = "xx-small";
                    //hlkNutritionalMessage.NavigateUrl = "../PDF/" + messageFile;

                    //ftbNutritionalMessage.UpdateToolbar = true;
                    
                    this.CurrentNutritionalMessage = messageContent;
                    ckeNutritionalMessage.Text = this.CurrentNutritionalMessage;
                    
                    //ckeNutritionalMessage.ReadOnly = true;
                    //ftbNutritionalMessage.Text = this.CurrentNutritionalMessage;
                    //ftbNutritionalMessage.Text = HttpUtility.HtmlDecode(messageContent);
            //    }
            }
            catch
            {
                this.CurrentNutritionalTitle = "Drink Water This Summer";
                txtNutritionalMessage.Text = this.CurrentNutritionalTitle;
                this.CurrentNutritionalMessage = "<p>Like vitamins and minerals, water is important for our health. Often though, its importance can be overlooked. Water is vital for survival, so be sure to drink up this summer.</p><br><p>Like vitamins and minerals, water is important for our health. Often though, its importance can be overlooked. Water is vital for survival, so be sure to drink up this summer.</p><br><p>If you do not drink enough fluids, you can become dehydrated. Water is the ideal fluid to drink because it is naturally free of sugar and calories.</p><br><p>Think water is boring? Try these tips:<ul><li class='li5'>Flavor your water with fresh herbs, citrus, cucumber slices or berries</li><li class='li5'>Drink seltzer</li><li class='li5'>Add a small spash of 100% juice</li></ul><p></p>";
                ckeNutritionalMessage.Text = this.CurrentNutritionalMessage;
                //pnPage.Visible = false;
                //lblMsg.Text = "you are not authorized to access this page";
            }
        }

        private void PopRecipeSearchRepeater()
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                if (staff == null)
                {
                    throw new Exception("invalid");
                }
                else
                {
                    //RecipeSearchList1.Visible = true;
                    //RecipeSearchRepeater1.PopRepeater(SimpleServingsLibrary.Recipe.Recipe.Get(staff.StaffID, 1));
                    ddlRecipe.Visible = true;
                    SimpleServingsLibrary.Recipe.Recipes recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staff.StaffID, 0, string.Empty, SimpleServingsLibrary.Shared.GlobalEnum.RecipeStatus_Approved, 0, 1);

                    var list = from recipe in recipes
                               select new
                               {
                                   TextField = string.Format("{0} - {1} | {2}", recipe.RecipeID, recipe.RecipeName, recipe.RecipeViewText),
                                   ValueField = recipe.RecipeID,
                                   //Tooltip = recipe.RecipeViewText
                               };

                    ddlRecipe.DataSource = list;
                    ddlRecipe.DataTextField = "TextField";
                    ddlRecipe.DataValueField = "ValueField";
                    ddlRecipe.DataBind();
                }
            }
            catch
            {
                //pnPage.Visible = false;
                lblMsg.Text = "error loading recipe list";
            }
        }

        private void PopFeaturedRecipe()
        {
            try
            {
                //SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                //if (staff == null || !staff.IsAdmin)
                //{
                //    throw new Exception("null");
                //}
                //else
                //{
                    string recipeFile = SimpleServingsLibrary.Recipe.Recipe.GetFeaturedRecipePrintFile();
                    if (string.IsNullOrEmpty(recipeFile)) throw new Exception();
                    string imageFile = SimpleServingsLibrary.Recipe.Recipe.GetFeaturedRecipeImage();
                    if (string.IsNullOrEmpty(imageFile)) throw new Exception();

                    SimpleServingsLibrary.Recipe.Recipe recipe = new SimpleServingsLibrary.Recipe.Recipe();
                    recipe.GetFeaturedRecipe();
                    if (recipe.RecipeID == 0) throw new Exception();

                    foreach (ListItem item in ddlRecipe.Items)
                    {
                        try
                        {
                            if (Convert.ToInt32(item.Value) == recipe.RecipeID)
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    lblRecipePrintFile.Text = string.Format("Current Print File:&nbsp;<a target='_blank' style='font-size: xx-small;' href='../PDF/{0}'>{0}</a>", recipeFile);
                    lblRecipePrintFile.Style["color"] = "black";
                    lblRecipePrintFile.Style["font-style"] = "italic";
                    lblRecipePrintFile.Style["font-size"] = "xx-small";                  

                    lblRecipeImage.Text = "Current Image File: " + imageFile;
                    lblRecipeImage.Style["color"] = "black";
                    lblRecipeImage.Style["font-style"] = "italic";
                    lblRecipeImage.Style["font-size"] = "xx-small";

                    imgFeaturedRecipe.ImageUrl = string.Format(@"{0}", System.Configuration.ConfigurationManager.AppSettings["ImageFilePath"]) + imageFile;

                    CurrentRecipe = recipe.RecipeID;
                //}
            }
            catch
            {
                //pnPage.Visible = false;
                //lblMsg.Text = "you are not authorized to access this page";
            }
            
        }

        protected void lkBtn_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LinkButton))
            {

                if (((LinkButton)sender).CommandName == "WelcomeMessage")
                {
                    PopWelcomeMessage();

                    pnFeaturedRecipe.Visible = pnNutritionalMessage.Visible = ckeNutritionalMessage.Visible = false;
                    pnWelcomeMessage.Visible = true;
                    //ftbWelcomeMessage.Visible = true;

                }
                else if (((LinkButton)sender).CommandName == "FeaturedRecipe")
                {
                    PopRecipeSearchRepeater();
                    PopFeaturedRecipe();

                    //ftbWelcomeMessage.Visible = false;
                    //ftbNutritionalMessage.Visible = false;
                    pnWelcomeMessage.Visible = pnNutritionalMessage.Visible = false;
                    pnFeaturedRecipe.Visible = true;
                }
                else if (((LinkButton)sender).CommandName == "NutritionalMessage")
                {
                    PopNutritionalMessage();

                    pnWelcomeMessage.Visible = false;
                    pnFeaturedRecipe.Visible = false;
                    pnNutritionalMessage.Visible = true;
                    ckeNutritionalMessage.Visible = true;
                    ckeNutritionalMessage.Toolbar = "Basic";
                    //ftbNutritionalMessage.Visible = true;
                }
            }
            else if (sender.GetType() == typeof(Button))
            {
                if (((Button)sender).CommandName == "WelcomeMessage")
                {
                    PopWelcomeMessage();

                    pnFeaturedRecipe.Visible = pnNutritionalMessage.Visible = ckeNutritionalMessage.Visible = false;

                    lnkWelcomeMessage.Style["font-style"] = "italic";
                    lnkWelcomeMessage.Style["font-weight"] = "bold";
                    //lnkInsertCode.OnClientClick = "return false;";
                    //lnkInsertCode.Visible = false;

                    pnWelcomeMessage.Visible = true;

                    lnkFeaturedRecipe.Style["font-style"] = lnkNutritionalMessage.Style["font-style"] = "normal";
                    lnkFeaturedRecipe.Style["font-weight"] = lnkNutritionalMessage.Style["font-weight"] = "normal";
                    //lnkAddRule.Visible = lnkViewRules.Visible = true;
                    //ftbWelcomeMessage.Visible = true;
                    //cbWelcomeMessage.Checked = true;

                }
                else if (((Button)sender).CommandName == "FeaturedRecipe")
                {
                    PopRecipeSearchRepeater();
                    PopFeaturedRecipe();

                    //ftbWelcomeMessage.Visible = false;
                    ckeNutritionalMessage.Visible = false;
                    pnWelcomeMessage.Visible = pnNutritionalMessage.Visible = false;

                    lnkFeaturedRecipe.Style["font-style"] = "italic";
                    lnkFeaturedRecipe.Style["font-weight"] = "bold";
                    //lnkAddRule.OnClientClick = "return false;";
                    //lnkAddRule.Enabled = false;
                    //lnkAddRule.Visible = false;

                    pnFeaturedRecipe.Visible = true;

                    lnkWelcomeMessage.Style["font-style"] = lnkNutritionalMessage.Style["font-style"] = "normal";
                    lnkWelcomeMessage.Style["font-weight"] = lnkNutritionalMessage.Style["font-weight"] = "normal";
                    //lnkInsertCode.Enabled = lnkViewRules.Enabled = true;
                    //lnkInsertCode.Visible = lnkViewRules.Visible = true;
                }
                else if (((Button)sender).CommandName == "NutritionalMessage")
                {
                    PopNutritionalMessage();

                    pnWelcomeMessage.Visible = pnFeaturedRecipe.Visible = false;

                    lnkNutritionalMessage.Style["font-style"] = "italic";
                    lnkNutritionalMessage.Style["font-weight"] = "bold";
                    //lnkViewRules.OnClientClick = "return false;";
                    //lnkViewRules.Enabled = false;
                    //lnkViewRules.Visible = false;

                    pnNutritionalMessage.Visible = true;
                    ckeNutritionalMessage.Visible = true;
                    ckeNutritionalMessage.Toolbar = "Basic";

                    lnkFeaturedRecipe.Style["font-style"] = lnkWelcomeMessage.Style["font-style"] = "normal";
                    lnkFeaturedRecipe.Style["font-weight"] = lnkWelcomeMessage.Style["font-weight"] = "normal";
                    //lnkAddRule.Enabled = lnkInsertCode.Enabled = true;
                    //lnkAddRule.Visible = lnkInsertCode.Visible = true;
                    //cbNutritionalMessage.Checked = true;
                }
            }

        }

        protected void ddlRecipe_DataBound(object sender, EventArgs e)
        {
            DropDownList ddlRecipe = (DropDownList)sender;
            foreach (ListItem item in ddlRecipe.Items)
            {
                item.Attributes["title"] = item.Text.Split('|')[1].Trim();
                item.Text = item.Text.Replace("| ", " (") + ")";
            }

            ddlRecipe.Items.Insert(0, new ListItem("[Select]"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debugger.Launch();
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null || !staff.IsAdmin) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            try
            {
                if (((Button)sender).ID == "btnSubmit")
                {
                    int recipeId = 0;
                    Int32.TryParse(ddlRecipe.SelectedValue, out recipeId);

                    if (recipeId == 0) throw new Exception("recipe selection is required");
                    //else if (Int32.Equals(recipeId, CurrentRecipe)) throw new Exception("nothing to change");
                    else if (!fuRecipeImage.HasFile) throw new Exception("recipe image file is required");
                    else if (!SimpleServingsLibrary.Shared.Validation.IsImageFile(fuRecipeImage.FileName)) throw new Exception("Only .jpg, .jpeg, .gif and .png files allowed");
                    else if (!fuRecipePrintFile.HasFile) throw new Exception("recipe print file is required");
                    else if (!SimpleServingsLibrary.Shared.Validation.IsPdfFile(fuRecipePrintFile.FileName)) throw new Exception("Only .pdf files allowed");

                    string recipeImageFile = null, recipePrintFile = null;

                    var imagesFolder = string.Format(@"{0}", System.Configuration.ConfigurationManager.AppSettings["ImageFilePath"]);
                    fuRecipeImage.SaveAs(Server.MapPath(imagesFolder + Path.GetFileName(fuRecipeImage.FileName)));
                    recipeImageFile = fuRecipeImage.FileName;

                    var pdfsFolder = string.Format(@"{0}", System.Configuration.ConfigurationManager.AppSettings["PdfFilePath"]);
                    fuRecipePrintFile.SaveAs(Server.MapPath(pdfsFolder + Path.GetFileName(fuRecipePrintFile.FileName)));
                    recipePrintFile = fuRecipePrintFile.FileName;

                    SimpleServingsLibrary.Recipe.Recipe.AddFeaturedRecipe(recipeId, recipeImageFile, recipePrintFile, staff.StaffID);

                    PopRecipeSearchRepeater();
                    PopFeaturedRecipe();

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('featured recipe updated');", true);

                }
                else if (((Button)sender).ID == "btnSubmit1")
                {
                    //debugging
                    string htmlStr = null;
                    if (!string.IsNullOrEmpty(hdnNutritionalMessage.Value) && cbNutritionalMessage.Checked)
                    {
                        //if (string.Equals(CurrentNutritionalMessage.Trim(), hdnNutritionalMessage.Value.Trim(), StringComparison.CurrentCultureIgnoreCase)) throw new Exception("nothing to change");
                        htmlStr = hdnNutritionalMessage.Value;
                    }

                    if (string.IsNullOrEmpty(txtNutritionalMessage.Text)) throw new Exception("nutritional message title required");
                    //else if (string.Equals(CurrentNutritionalTitle.Trim(), txtNutritionalMessage.Text.Trim(), StringComparison.CurrentCultureIgnoreCase)) throw new Exception("nothing to change");
                    else if (!fuMessage.HasFile) throw new Exception("nutritional message print file required");
                    else if (!SimpleServingsLibrary.Shared.Validation.IsPdfFile(fuMessage.FileName)) throw new Exception("Only .pdf files allowed");
                    else if (string.IsNullOrEmpty(htmlStr)) throw new Exception("nutritional message web content required");

                    var pdfsFolder = string.Format(@"{0}", System.Configuration.ConfigurationManager.AppSettings["PdfFilePath"]);
                    fuMessage.SaveAs(Server.MapPath(pdfsFolder + Path.GetFileName(fuMessage.FileName)));

                    if (!cbNutritionalMessage.Checked)
                    {
                        SimpleServingsLibrary.Resource.NutritionalMessage.AddNutritionalMessage(txtNutritionalMessage.Text.Trim(), fuMessage.FileName, this.CurrentNutritionalMessage, staff.StaffID);
                    }
                    else
                    {
                        SimpleServingsLibrary.Resource.NutritionalMessage.AddNutritionalMessage(txtNutritionalMessage.Text.Trim(), fuMessage.FileName, htmlStr, staff.StaffID);
                    }
                    //this.CurrentNutritionalMessage = htmlStr;
                    PopNutritionalMessage();

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('nutritional message updated');", true);
                }
                else if (((Button)sender).ID == "btnSubmit2")
                {
                    //debugging
                    if (Page.IsValid)
                    {
                        string htmlStr = null;
                        if (!string.IsNullOrEmpty(hdnWelcomeMessage.Value) && cbWelcomeMessage.Checked)
                        {
                            if (SimpleServingsLibrary.Shared.Validation.IsDirty(hdnWelcomeMessage.Value))
                            {
                                throw new Exception("Html tags not allowed");
                            }

                            //if (string.Equals(CurrentWelcomeMessage.Trim(), hdnWelcomeMessage.Value.Trim(), StringComparison.CurrentCultureIgnoreCase)) throw new Exception("nothing to change");
                            htmlStr = hdnWelcomeMessage.Value.Replace("\n", "<br/>");
                            //htmlStr = ftbWelcomeMessage.Xhtml;
                        }

                        //if (!fuWelcomeImage.HasFile) throw new Exception("welcome image file is required");
                        //else if (Path.GetExtension(fuWelcomeImage.FileName).ToLower() != ".jpg") throw new Exception("Only .jpg files allowed");
                        if (fuWelcomeImage.HasFile)
                        {
                            var imgFolder = string.Format(@"{0}", System.Configuration.ConfigurationManager.AppSettings["WelcomeImagePath"]);
                            var imgSavePath = Server.MapPath(imgFolder + "homeDFTA.jpg");
                            var imgBackupPath = Server.MapPath(imgFolder + "homeDFTA_bk" + Guid.NewGuid().ToString() + ".jpg");


                            if (File.Exists(imgSavePath))
                            {
                                lock (imgBackupPath)
                                {
                                    File.Copy(imgSavePath, imgBackupPath, true);
                                }
                            }

                            fuWelcomeImage.SaveAs(imgSavePath);
                        }

                        if (!cbWelcomeMessage.Checked)
                        {
                            SimpleServingsLibrary.Resource.WelcomeMessage.AddWelcomeMessage("homeDFTA.jpg", this.CurrentWelcomeMessage, staff.StaffID);
                        }
                        else
                        {
                            SimpleServingsLibrary.Resource.WelcomeMessage.AddWelcomeMessage("homeDFTA.jpg", htmlStr, staff.StaffID);
                        }
                        //this.CurrentWelcomeMessage = htmlStr;
                        PopWelcomeMessage();

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('welcome message updated');", true);
                    }
                }
                //Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
            }
        }

        protected void ftbWelcomeMessage_TextChanged(object sender, EventArgs e)
        {
            FreeTextBoxControls.FreeTextBox ftb = (FreeTextBoxControls.FreeTextBox)sender;
            NewWelcomeMessage = ftb.Text;
        }
        //10-27-2016 Server side validation html detection
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //System.Diagnostics.Debugger.Launch();
            bool isValid = true;
            if (txtWelcomeMessage.Text.Trim() == args.Value.Trim())
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(args.Value.Trim(), @"<[a-z][\s\S]*>"))
                {
                    btnSubmit2.CssClass = null;
                    btnSubmit2.Attributes.Remove("disabled");
                    btnSubmit2.Style.Remove("disabled");

                    isValid = true;
                }
                else
                {
                    btnSubmit2.CssClass = "disabled";
                    btnSubmit2.Attributes.Add("disabled", "disabled");
                    btnSubmit2.Style.Add("disabled", "disabled");

                    isValid = false;
                }
            }
            else
            {
                btnSubmit2.CssClass = null;
                btnSubmit2.Attributes.Remove("disabled");
                btnSubmit2.Style.Remove("disabled");

                isValid = true;
            }

            args.IsValid = isValid;
            return;
        }

        protected void CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).ID == "cbNutritionalMessage")
            {
                if (!((CheckBox)sender).Checked)
                {
                    ckeNutritionalMessage.ReadOnly = true;
                    ckeNutritionalMessage.CssClass = "msgDisabled";
                    ckeNutritionalMessage.Enabled = false;
                }
                else
                {
                    ckeNutritionalMessage.ReadOnly = false;
                    ckeNutritionalMessage.CssClass = null;
                    ckeNutritionalMessage.Enabled = true;
                }
            }
        }
    }
}