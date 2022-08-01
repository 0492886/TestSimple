using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.RecipeSupplement;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class ScaledIngredient : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["RecipeID"] != null && Request["ScaleTo"] != null)
            {
                int recipeID = Convert.ToInt32(Request["RecipeID"]);
                int scaleTo = Convert.ToInt32(Request["ScaleTo"]);
                PopContent(recipeID, scaleTo);
            }
        }

        private void PopContent(int recipeID, int scaleTo)
        {
            lblRecipeName.Text = SimpleServingsLibrary.Recipe.Recipe.GetRecipeNameByRecipeID(recipeID);
            lblScaleTo.Text = scaleTo.ToString();
            PopScaledRepeater(recipeID, scaleTo);
            directionGrid.PopGrid(recipeID);
            requirementGrid.PopGrid(recipeID);
        }

        private void PopScaledRepeater(int recipeID, int scaleTo)
        {
            try
            {
                List<string> scaledIngredients =
                    SimpleServingsLibrary.RecipeSupplement.IngredientScale.ScaleIngredients(recipeID, scaleTo);
                foreach (string scaledIngredient in scaledIngredients)
                {
                    ListItem item = new ListItem(scaledIngredient);
                    bltScaledIngredients.Items.Add(item);
                }

            }
            catch(Exception ex) 
            { 
                
            }
        }
    }
}