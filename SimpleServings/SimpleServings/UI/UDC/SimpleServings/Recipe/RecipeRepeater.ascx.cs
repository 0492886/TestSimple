using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class RecipeRepeater : System.Web.UI.UserControl
    {

        public bool ShowCheckBox
        {
            get;
            set;
        }
        public List<int> GetSelectedRecipeIDs()
        {
            List<int> recipeIDs = new List<int> { };
            int recipeID = 0;
            foreach (RepeaterItem item in rptRecipes.Items)
            {
                if ((item.FindControl("cbCheck") as CheckBox).Checked)
                {
                    Int32.TryParse((item.FindControl("lblRecipeID") as Label).Text, out recipeID);
                    recipeIDs.Add(recipeID);
                    
                }
            }
            return recipeIDs;
        }
       
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
                //this.lblCount.ForeColor = System.Drawing.Color.Red;
                //this.lblCount.Text = "No rules found";
            }
        }
        protected SimpleServingsLibrary.Recipe.RecipeTags GetRecipeTagsByRecipeID(Object objRecipeID)
        {
            int recipeID = 0;
            Int32.TryParse(objRecipeID.ToString(), out recipeID);
            return SimpleServingsLibrary.Recipe.RecipeTag.GetRecipeTagsByRecipeID(recipeID);
        }

        protected void rptRecipes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblRecipeID = e.Item.FindControl("lblRecipeID") as Label;
                int recipeID = 0;
                Int32.TryParse(lblRecipeID.Text, out recipeID);
                NutritionCalorie nc = e.Item.FindControl("NutritionCalorie1") as NutritionCalorie;
                nc.PopContent(recipeID);
                CheckBox cbCheck = e.Item.FindControl("cbCheck") as CheckBox;
                cbCheck.Visible = ShowCheckBox;
            }
        }

        
       
    }
}