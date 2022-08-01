using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using log4net;
using log4net.Config;

namespace SimpleServings.UI.Page
{
    public partial class Recipe : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger("AppManager");

        static Recipe()
        {
            XmlConfigurator.Configure();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null) LogSession("Request from " + Request.UrlReferrer.ToString());

                PopFeaturedRecipe();
                PopCategoryandTags();
            }
        }


        private void PopCategoryandTags()
        {
            try
            {

                SimpleServingsLibrary.Shared.ManageCategoriesandTagsList CategoryList = SimpleServingsLibrary.Shared.ManageCategoriesandTags.GetAllCategoriesandTags();

                List<string> Categories = new List<string>();
                foreach (var item in CategoryList)
                {
                    if (!Categories.Contains(item.CategoryName))
                    {
                        Categories.Add(item.CategoryName);
                    }
                }

                rpCategories.DataSource = Categories;
                rpCategories.DataBind();

                for (int i = 0; i < rpCategories.Items.Count; i++)
                {
                    var h1 = new System.Web.UI.HtmlControls.HtmlGenericControl("h1");
                    h1 = (System.Web.UI.HtmlControls.HtmlGenericControl)rpCategories.Items[i].FindControl("rpHeader");
                    CheckBoxList cbl = (CheckBoxList)rpCategories.Items[i].FindControl("cbTags");

                    List<TagDetail> TagsList = new List<TagDetail>();
                    foreach (var item in CategoryList)
                    {
                        if (h1.InnerText == item.CategoryName)
                        {
                            TagDetail Tag = new TagDetail();
                            Tag.TagName = item.TagName;
                            Tag.TagId = item.TagID;
                            TagsList.Add(Tag);
                        }
                    }

                    cbl.DataSource = TagsList;
                    cbl.DataTextField = "TagName";
                    cbl.DataValueField = "TagID";
                    cbl.DataBind();

                    //foreach (ListItem item in cbl.Items)
                    //{
                    //    item.Attributes.CssStyle.Add("border", "1px solid red");
                    //}

                    

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
 
            }
 
            
            

        }



        //08-01-2016
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

                //lblFeaturedRecipe.Text = recipe.RecipeName;
                //imgFeaturedRecipe.ImageUrl = @"~\UI\images\" + imageFile;
                //ViewRecipeIngredient1.PopGrid(recipe.RecipeID);
                //hlkViewMore.NavigateUrl = ResolveUrl("~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=" + recipe.RecipeID); 
                //"~/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=" + recipe.RecipeID;
                
            }
            catch
            {

                //lblFeaturedRecipe.Text = "Chickpea Salad with Tomatoes and Parsley";
                //imgFeaturedRecipe.ImageUrl = @"~\UI\images\bigos8.jpg";
                //ViewRecipeIngredient1.PopGrid(1407);
                //hlkViewMore.NavigateUrl = ResolveUrl("~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=1407"); 
                //"~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=1407";
            }
            //imgFeaturedRecipe.ToolTip = "Featured Recipe";
        }

        private void LogSession(string message)
        {
            var sessionCookie = Request.Cookies["ASP.NET_SessionId"];
            if (sessionCookie != null)
            {
                //Session["ASP.NET_SessionId"] = sessionCookie.Value;
                log.Info(string.Format("(Recipe.aspx) - {0} {1}SessionId: {2}", message, Environment.NewLine, sessionCookie.Value));
            }
        }

        protected void defaultButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");


            string searchText = txtsearch.Value;
            //string searchText = txtsearch.Text.ToString();
            //searchText = searchText.Replace("\n", "").Replace("\r", "");
            List<int> selectedTags = new List<int>();
            lblsearchMsg.Text = "Selected Tags: ";
            for(int i =0; i < rpCategories.Items.Count; i++)
            {
                CheckBoxList cbTags = (CheckBoxList)rpCategories.Items[i].FindControl("cbTags");
                
                foreach(ListItem item in cbTags.Items)
                {
                    if (item.Selected == true)
                    {
                        int tagID = 0;
                        Int32.TryParse(item.Value, out tagID);
                        selectedTags.Add(tagID);
                        lblsearchMsg.Text += item.Text;
                        lblsearchMsg.Text += " &#8250; ";
                    }
                
                }
            }
            try
            {
                SimpleServingsLibrary.Recipe.Recipes recipes = new SimpleServingsLibrary.Recipe.Recipes();
                recipes = SimpleServingsLibrary.Recipe.Recipe.GetRecipesforTagsSearch(selectedTags, searchText, staff.StaffID );
                RecipeGrid1.PopGridForRecipeHome(recipes); 
                int tmp = lblsearchMsg.Text.Length;
                lblsearchMsg.Text = lblsearchMsg.Text.Remove(tmp - 1, 1);                
                lblsearchMsg.CssClass = "tagz";
                
                
            }
            catch (Exception ex)
            {
                RecipeGrid1.PopGridForRecipeHome(null);
                lblsearchMsg.Text = "No Recipes Found!";
                lblsearchMsg.CssClass = "errorMsg";
 
            }
            
        }
    }


    class TagDetail
    {
        public string TagName { get; set; }
        public int TagId { get; set; }
    }

}