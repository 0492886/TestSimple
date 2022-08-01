using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.RecipeSupplement;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class ViewRecipeIngredient : System.Web.UI.UserControl
    {
        private bool _showArrow;
        //private bool _showCheck;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region public properties
        [Category("ShowArrow")]
        [DefaultValue(true)]
        public bool ShowArrow
        {
            get { return _showArrow; }
            set { _showArrow = value; }
        }

        //[Category("ShowCheck")]
        //[DefaultValue(true)]
        //public bool ShowCheck
        //{
        //    get { return _showCheck; }
        //    set { _showCheck = value; }
        //}
        
        #endregion

        public void PopGrid(int recipeID)
        {
            RecipeIngredients ris = RecipeIngredient.GetRecipeIngredientByRecipeID(recipeID);
            gvRecipeIngredient.DataSource = ris;
            gvRecipeIngredient.DataBind();
        }
    }
}