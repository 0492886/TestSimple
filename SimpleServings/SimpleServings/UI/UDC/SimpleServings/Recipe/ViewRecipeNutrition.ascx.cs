using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.RecipeSupplement;
using SimpleServingsLibrary.Recipe;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class ViewRecipeNutrition : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                try
                {
                    int recipeID = Convert.ToInt32(Request["RecipeID"]);
                    SimpleServingsLibrary.Recipe.Recipe r = new SimpleServingsLibrary.Recipe.Recipe();
                    r.GetRecipeByRecipeID(recipeID);

                    lblServingSize.Text = string.Format("{0} ({1})", r.ServingSize, r.PortionSize);
                }
                catch { }
            }
        }

        protected void lnkBtnShowMore_Click(object sender, EventArgs e)
        {
            SwapFromMoreToLess(false);
        }

        protected void lnkBtnShowLess_Click(object sender, EventArgs e)
        {
            SwapFromMoreToLess(true);
        }

        private void SwapFromMoreToLess(bool swap)
        {
            udcNutritionFacts.Visible = swap;
            lnkBtnShowMore.Visible = swap;

            udcNutritionAll.Visible = !swap;
            lnkBtnShowLess.Visible = !swap;
        }



    }
}