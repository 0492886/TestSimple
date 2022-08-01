using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using log4net;
using log4net.Config;
using System.Text.RegularExpressions;

namespace SimpleServings.UI.Page
{
    public partial class HomeTest : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            //if (staff != null)
            //{
            //Page.ViewStateUserKey = Session.SessionID; //string.Format("{0}_{1}", Session.SessionID, Guid.NewGuid().ToString());
            //}
        }

        private static readonly ILog log = LogManager.GetLogger("AppManager");

        static HomeTest()
        {
            XmlConfigurator.Configure();
        }

        #region Set Anti CSRF Token as per OWASP.org
        ////Comment out this region when debugging - uncomment when deploying/checkin to TFS
        //private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        //private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        //private string _antiXsrfTokenValue;
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    // The code below helps to protect against XSRF attacks
        //    var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        //    Guid? requestCookieGuidValue = null;
        //    if (requestCookie != null)
        //    {
        //        requestCookieGuidValue = new Guid(requestCookie.Value);
        //    }

        ////    if (requestCookie != null && requestCookieGuidValue != null)
        ////    {
        ////        // Use the Anti-XSRF token from the cookie
        ////        _antiXsrfTokenValue = requestCookie.Value;
        ////        Page.ViewStateUserKey = _antiXsrfTokenValue;
        ////    }
        ////    else
        ////    {
        ////        // Generate a new Anti-XSRF token and save to the cookie
        ////        _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
        ////        Page.ViewStateUserKey = _antiXsrfTokenValue;
        ////        var responseCookie = new HttpCookie(AntiXsrfTokenKey)
        ////        {
        ////            HttpOnly = true,
        ////            Value = _antiXsrfTokenValue,
        ////            Secure = true,
        ////        };
        ////        if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
        ////        {
        ////            responseCookie.Secure = true;
        ////        }
        ////        Response.Cookies.Set(responseCookie);
        ////    }
        ////    Page.PreLoad += home_Page_PreLoad;

        //}

        //protected void home_Page_PreLoad(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        // Set Anti-XSRF token
        //        ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
        //        //ViewState[AntiXsrfUserNameKey] = (Session["UserObject"] != null) ? ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserName : String.Empty;
        //        ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        //    }
        //    else
        //    {
        //        // Validate the Anti-XSRF token
        //        //var _antisfrUserName = (Session["UserObject"] != null) ? ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserName : String.Empty;

        //        //if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue ||
        //        //    (string)ViewState[AntiXsrfUserNameKey] != _antisfrUserName)
        //        if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue ||
        //           (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
        //        {
        //            throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
        //        }
        //    }
        //}
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LogSession("Page Load");

                //CheckApplicationState();

                if (!string.IsNullOrEmpty(Request.Form["juid"]))
                    LoginUser(Request.Form["juid"]);

                //CheckPermissions();
                PopWelcomeMessage();
                PopFeaturedRecipe();
                PopNutritionalMessage();
                //PopEditControls();               
                
            }
        }

        private void LoginUser(string userName)
        {
            try{
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
               
                staff.GetStaffByUserName(userName);

                Session["UserObject"] = staff;
                //HelpClasses.AppHelper.GetLoggedInUser(staff);
                //staff.SetLoginDate();

                #region test logic
                if (staff.IsLocked)
                {
                    LogSession(string.Format("(uid={0}) Juniper login - locked account detected", userName));
                    //Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut&UserName=" + userName, false);
                }
                else if (staff.ForcePasswordChange)
                {
                    LogSession(string.Format("(uid={0}) Juniper login - password reset required detected", userName));
                //    Response.Redirect("~/UI/Page/landingPage.aspx?from=Juniper&type=ForcePasswordChange&StaffID=" + staff.StaffID.ToString(), false);
                }
                else
                {
                    LogSession(string.Format("(uid={0}) Juniper login", userName));
                }

                if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    LogSession(string.Format("User has AD credentials ({0})", HttpContext.Current.User.Identity.Name));
                }
                #endregion

                //if (staff.IsAdmin) pnlFeaturedRecipe.Visible = true;
            }
            catch
            {
                Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                //Response.Redirect("~/UI/Page/Login.aspx");
            }
            
        }

        private void LogSession(string message)
        {
            var sessionCookie = Request.Cookies["ASP.NET_SessionId"];
            if (sessionCookie != null)
            {
                //Session["ASP.NET_SessionId"] = sessionCookie.Value;
                log.Info(string.Format("(Home.aspx) - {0} {1}SessionId: {2}", message, Environment.NewLine, sessionCookie.Value));
            }
        }

        private void CheckApplicationState()
        {
            HelpClasses.AppHelper.CleanUpApplicationState();
            //Application.Lock();
            //SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Application["UserObject"];
            //if (staff != null)
            //{
            //    Session["UserObject"] = staff;
            //    Application["UserObject"] = null;
            //}
            //Application.UnLock();
        }

        #region load content methods
        private void PopWelcomeMessage()
        {
            try
            {
                lblDFTATitle.Text = SimpleServingsLibrary.Resource.WelcomeMessage.GetMessageContent();
                //hdnWelcomeMessage.Value = lblDFTATitle.Text;
            }
            catch
            {
                lblDFTATitle.Text = "Welcome to Simple Servings, a web-based menu application for congregate and home-delivered meal providers. This application allows users to view healthy recipes and menus, as well as develop menus that meet city, state and federal nutrition requirements. Simple Servings is the primary vehicle for the menu submission and approval process between contractors and DFTA Nutritional Services. The Intuitive Selections feature simplifies the overall process by notifying meal providers when menus meet all nutrition requirements. Simple Servings has replaced the paper menu submission process and drastically reduces the time spent on menu development, submission and approval. We hope this application simplifies and improves the menu creation process for you.";
                //hdnWelcomeMessage.Value = lblDFTATitle.Text;
            }
        }
        private void PopFeaturedRecipe()
        {
            try
            {
                string recipeFile = SimpleServingsLibrary.Recipe.Recipe.GetFeaturedRecipePrintFile();
                if (string.IsNullOrEmpty(recipeFile)) throw new Exception();
                string imageFile = SimpleServingsLibrary.Recipe.Recipe.GetFeaturedRecipeImage();
                if (string.IsNullOrEmpty(imageFile)) throw new Exception();

                SimpleServingsLibrary.Recipe.Recipe recipe = new SimpleServingsLibrary.Recipe.Recipe();
                recipe.GetFeaturedRecipe();
                if (recipe.RecipeID == 0) throw new Exception();

                hlkFeaturedRecipe.NavigateUrl = "../PDF/" + recipeFile;
                lblFeaturedRecipe.Text = recipe.RecipeName;
                imgFeaturedRecipe.ImageUrl = @"~\UI\images\" + imageFile;
                ViewRecipeIngredient1.PopGrid(recipe.RecipeID);
                
                hlkViewMore.NavigateUrl = "../Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=" + recipe.RecipeID;
            }
            catch
            {
                hlkFeaturedRecipe.NavigateUrl = "../PDF/July2016FeaturedRecipe.pdf";
                lblFeaturedRecipe.Text = "Chickpea Salad with Tomatoes and Parsley";
                imgFeaturedRecipe.ImageUrl = @"~\UI\images\bigos8.jpg";
                ViewRecipeIngredient1.PopGrid(1407);
                hlkViewMore.NavigateUrl = "../Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=1407";
            }
            imgFeaturedRecipe.ToolTip = "Featured Recipe";
        }
        private void PopNutritionalMessage()
        {
            try
            {
                SimpleServingsLibrary.Resource.NutritionalMessage message = new SimpleServingsLibrary.Resource.NutritionalMessage();
                message.GetNutritionalMessage();

                string messageTitle = message.MessageTitle; 
                if (string.IsNullOrEmpty(messageTitle)) throw new Exception();
                string messageFile = message.MessageFile;
                if (string.IsNullOrEmpty(messageFile)) throw new Exception();
                string messageContent = message.MessageContent;
                if (string.IsNullOrEmpty(messageContent)) throw new Exception();
                
                lblNutritionalMessage.Text = messageTitle;
                hlkNutritionalMessage.NavigateUrl = "../PDF/" + messageFile;

                lblNutritionalMessageText.Text = messageContent;

                //hdnMessageContent.Value = HttpUtility.HtmlEncode(messageContent);
                //lblNutritionalMessageText.Text = HttpUtility.HtmlDecode(hdnMessageContent.Value);
            }
            catch
            {
                lblNutritionalMessage.Text = "Drink Water This Summer";
                hlkNutritionalMessage.NavigateUrl = "../PDF/Homepage Content - Nutrition Message Summer 2016.pdf";

                string htmlString = HttpUtility.HtmlEncode("<p>"
                                                  + "Like vitamins and minerals, water is important for our health. Often though, its importance can be overlooked. Water is vital for survival, so be sure to drink up this summer."
                                                  + "</p>"
                                                  + "<br />"
                                                  + "<p>"
                                                  + "Like vitamins and minerals, water is important for our health. Often though, its importance can be overlooked. Water is vital for survival, so be sure to drink up this summer."
                                                  + "</p>"
                                                  + "<br />"
                                                  + "<p>"
                                                  + "If you do not drink enough fluids, you can become dehydrated. Water is the ideal fluid to drink because it is naturally free of sugar and calories."
                                                  + "</p>"
                                                  + "<br />"
                                                  + "<p>"
                                                  + "Think water is boring? Try these tips:"
                                                  + "<ul>"
                                                  + "<li class='li5'>Flavor your water with fresh herbs, citrus, cucumber slices or berries</li>"
                                                  + "<li class='li5'>Drink seltzer</li>"
                                                  + "<li class='li5'>Add a small spash of 100% juice</li>"
                                                  + "</ul>"
                                                  + "</p>");

                lblNutritionalMessageText.Text = HttpUtility.HtmlDecode(htmlString);
                
                //lblNutritionalMessageText.Text = HttpUtility.HtmlDecode(hdnMessageContent.Value);
            }
        }
        #endregion

        #region custom edit methods

        //private void CheckPermissions()
        //{
        //    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
        //    if (staff == null || !staff.IsAdmin || staff.UserName.ToLower().Trim() != "liu5046")
        //    {
        //        pnlEditWM.Style["display"] = "none";
        //        pnlEditRecipe.Style["display"] = "none";
        //        pnlEditMessage.Style["display"] = "none";
        //        pnlFeaturedRecipe.Style["display"] = "none";
        //        pnlNutritionalMessage.Style["display"] = "none";
        //    }
        //    else
        //    {
        //        pnlEditWM.Style["display"] = "block";
        //        LinkButton6.Style["display"] = "block";
        //        LinkButton7.Style["display"] = "none";

        //        pnlEditRecipe.Style["display"] = "block";
        //        lnkBtnEdit.Style["display"] = "block";
        //        lnkBtnCancel.Style["display"] = "none";

        //        pnlEditMessage.Style["display"] = "block";
        //        LinkButton1.Style["display"] = "block";
        //        LinkButton2.Style["display"] = "none";

        //        //pnlFeaturedRecipe.Style["display"] = "none";
        //        //pnlNutritionalMessage.Style["display"] = "none";

        //    }
        //}

        //private void PopRecipeSearchRepeater()
        //{
        //    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
        //    if (staff == null || !staff.IsAdmin)
        //    {
        //        //RecipeSearchList1.Visible = false;
        //        ddlRecipe.Visible = false;
        //    }
        //    else
        //    {
        //        //RecipeSearchList1.Visible = true;
        //        //RecipeSearchRepeater1.PopRepeater(SimpleServingsLibrary.Recipe.Recipe.Get(staff.StaffID, 1));
        //        ddlRecipe.Visible = true;
        //        SimpleServingsLibrary.Recipe.Recipes recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesByStaffIDAndRecipeName(staff.StaffID, 0, string.Empty, SimpleServingsLibrary.Shared.GlobalEnum.RecipeStatus_Approved, 0, 1);

        //        var list = from recipe in recipes
        //                   select new
        //                   {
        //                       TextField = string.Format("{0} - {1} | {2}", recipe.RecipeID, recipe.RecipeName, recipe.RecipeViewText),
        //                       ValueField = recipe.RecipeID,
        //                       //Tooltip = recipe.RecipeViewText
        //                   };

        //        ddlRecipe.DataSource = list;
        //        ddlRecipe.DataTextField = "TextField";
        //        ddlRecipe.DataValueField = "ValueField";
        //        ddlRecipe.DataBind();
        //    }
        //}
        //protected void ddlRecipe_DataBound(object sender, EventArgs e)
        //{
        //    DropDownList ddlRecipe = (DropDownList)sender;
        //    foreach (ListItem item in ddlRecipe.Items)
        //    {
        //        item.Attributes["title"] = item.Text.Split('|')[1].Trim();
        //        item.Text = item.Text.Replace("| ", " (") + ")";
        //    }

        //    ddlRecipe.Items.Insert(0, new ListItem("[Select]"));
        //}

        //08-03-2016
        //private void PopEditControls()
        //{
        //    PopRecipeSearchRepeater();
        //    txtMessageContent.CssClass = "msgDisabled";
        //    txtMessageContent.Text = lblNutritionalMessageText.Text;
        //    ckeNutritionalMessage.Text = lblNutritionalMessageText.Text; 
        //}

        //08-03-2016 - makes main content changes
        #region edit content prototype
        //protected void btUpload_Click(object sender, EventArgs e)
        //{
        //    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
        //    if (staff == null || !staff.IsAdmin) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

        //    try
        //    {
        //        Button btUpload = (Button)sender;
        //        if (btUpload.CommandName == "WelcomeMessage")
        //        {

        //            if (!string.IsNullOrEmpty(hdnWelcomeMessage.Value) && cbWelcomeMessage.Checked)
        //            {
        //                if (SimpleServingsLibrary.Shared.Validation.IsDirty(hdnWelcomeMessage.Value))
        //                {
        //                    throw new Exception("Html tags not allowed");
        //                }
        //                //htmlStr = ftbWelcomeMessage.Xhtml;
        //                //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('You have entered: \n" + HttpUtility.HtmlEncode(xHtmlStr) + "');", true);
        //            }

        //            if (!fupWelcomeImage.HasFile) throw new Exception("welcome image file is required");
        //            //else if (Path.GetExtension(fuWelcomeImage.FileName).ToLower() != ".jpg") throw new Exception("Only .jpg files allowed");

        //            var imgFolder = @"~\UI\assets\img\gallery\";
        //            var imgSavePath = Server.MapPath(imgFolder + "homeDFTA.jpg");
        //            var imgBackupPath = Server.MapPath(imgFolder + "homeDFTA_bk" + Guid.NewGuid().ToString() + ".jpg");


        //            if (System.IO.File.Exists(imgSavePath))
        //            {
        //                lock (imgBackupPath)
        //                {
        //                    System.IO.File.Copy(imgSavePath, imgBackupPath, true);
        //                }
        //            }

        //            fupWelcomeImage.SaveAs(imgSavePath);

        //            if (!cbWelcomeMessage.Checked)
        //            {
        //                SimpleServingsLibrary.Resource.WelcomeMessage.AddWelcomeMessage("homeDFTA.jpg", lblDFTATitle.Text.Trim(), staff.StaffID);
        //            }
        //            else
        //            {
        //                SimpleServingsLibrary.Resource.WelcomeMessage.AddWelcomeMessage("homeDFTA.jpg", hdnWelcomeMessage.Value.Trim(), staff.StaffID);
        //            }
        //        }
        //        else if (btUpload.CommandName == "UpdateRecipe")
        //        {                    
        //            int recipeId = 0;
        //            Int32.TryParse(ddlRecipe.SelectedValue, out recipeId);

        //            if (recipeId == 0) throw new Exception("recipe selection is required");
        //            else if (!fuRecipeImage.HasFile) throw new Exception("recipe image file is required");
        //            else if (!SimpleServingsLibrary.Shared.Validation.IsImageFile(fuRecipeImage.FileName)) throw new Exception("Only .jpg, .jpeg, .gif and .png files allowed");
        //            else if (!fuRecipePrintFile.HasFile) throw new Exception("recipe print file is required");
        //            else if (!SimpleServingsLibrary.Shared.Validation.IsPdfFile(fuRecipePrintFile.FileName)) throw new Exception("Only .pdf files allowed");

        //            string recipeImageFile = null, recipePrintFile = null;

        //            var imagesFolder = @"~\UI\images\";
        //            fuRecipeImage.SaveAs(Server.MapPath(imagesFolder + System.IO.Path.GetFileName(fuRecipeImage.FileName)));
        //            recipeImageFile = fuRecipeImage.FileName;

        //            var pdfsFolder = @"~\UI\PDF\";
        //            fuRecipePrintFile.SaveAs(Server.MapPath(pdfsFolder + System.IO.Path.GetFileName(fuRecipePrintFile.FileName)));
        //            recipePrintFile = fuRecipePrintFile.FileName;

        //            SimpleServingsLibrary.Recipe.Recipe.AddFeaturedRecipe(recipeId, recipeImageFile, recipePrintFile, staff.StaffID);

        //        }
        //        else if (btUpload.CommandName == "NutritionalMessage")
        //        {
        //            if (string.IsNullOrEmpty(txtNutritionalMessage.Text)) throw new Exception("nutritional message title required");
        //            else if (!fuMessage.HasFile) throw new Exception("nutritional message print file required");
        //            else if (!SimpleServingsLibrary.Shared.Validation.IsPdfFile(fuMessage.FileName)) throw new Exception("Only .pdf files allowed");
        //            else if (string.IsNullOrEmpty(hdnMessageContent.Value.Trim())) throw new Exception("nutritional message web content required");

        //            var pdfsFolder = @"~\UI\PDF\";
        //            fuMessage.SaveAs(Server.MapPath(pdfsFolder + System.IO.Path.GetFileName(fuMessage.FileName)));

        //            if (!cbMessageContent.Checked)
        //            {
        //                SimpleServingsLibrary.Resource.NutritionalMessage.AddNutritionalMessage(txtNutritionalMessage.Text.Trim(), fuMessage.FileName, lblNutritionalMessageText.Text.Trim(), staff.StaffID);
        //            }
        //            else
        //            {
        //                SimpleServingsLibrary.Resource.NutritionalMessage.AddNutritionalMessage(txtNutritionalMessage.Text.Trim(), fuMessage.FileName, hdnMessageContent.Value.Trim(), staff.StaffID);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
        //    }
        //    finally
        //    {
        //        //CheckPermissions();
        //        PopWelcomeMessage();
        //        PopFeaturedRecipe();
        //        PopNutritionalMessage();
        //        //PopRecipeSearchRepeater();
        //        PopEditControls();
        //    }
        //}
        #endregion

        #endregion custom edit methods
    }
}