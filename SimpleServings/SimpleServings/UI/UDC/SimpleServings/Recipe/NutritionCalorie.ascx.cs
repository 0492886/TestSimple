using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.RecipeSupplement;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class NutritionCalorie : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopContent(int recipeID)
        {
            RecipeNutritions rns = RecipeNutrition.GetRecipeNutritionMainByRecipeID(recipeID);
            rptNutrition.DataSource = rns;
            rptNutrition.DataBind();
        }

    }
}