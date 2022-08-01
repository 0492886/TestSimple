using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.RecipeSupplement;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class NutritionAll : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopNutritionAll(Convert.ToInt32(Request["RecipeID"]));
        }

        private void PopDataList(RecipeNutritions rns)
        {
            dlRecipeNutrition.DataSource = rns;
            dlRecipeNutrition.DataBind();
        }

        public void PopNutritionAll(int recipeID)
        {
            RecipeNutritions rns = RecipeNutrition.GetRecipeNutritionFactsAllByRecipeID(recipeID);
            rns.AddCalorieFromFat();
            PopDataList(rns);
        }

        protected void dlRecipeNutrition_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int nutrientOrder = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Orders"));
                if (nutrientOrder == 2 || nutrientOrder == 20 || nutrientOrder == 27)
                {
                    Panel panelRegular = e.Item.FindControl("pnlRegular") as Panel;
                    Panel panelSpecial = e.Item.FindControl("pnlSpecial") as Panel;

                    panelRegular.Visible = false;
                    panelSpecial.Visible = true;
                }
            }
        }
    }
}