using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class RecipeSearchRepeater : System.Web.UI.UserControl
    {
        
       

        public void PopRepeater(SimpleServingsLibrary.Recipe.Recipes recipes)
        {

            if (recipes != null)
            {
                this.rptRecipes.DataSource = recipes;
                this.rptRecipes.DataBind();

            }
            else
            {
                this.rptRecipes.DataSource = null;
                this.rptRecipes.DataBind();
                
            }
        }
   

      
    }
}