using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.RecipeSupplement;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class ViewRecipeSupplement : System.Web.UI.UserControl
    {
        private int _recipeSupplementType;
        public int RecipeSupplementType
        {
            get { return _recipeSupplementType; }
            set { _recipeSupplementType = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopGrid(int recipeID)
        {
            RecipeSupplements rss = RecipeSupplement.GetRecipeSupplementsByRecipeIDAndType(recipeID, RecipeSupplementType);
            gvRecipeSupplement.DataSource = rss;
            gvRecipeSupplement.DataBind();
        }
    }
}