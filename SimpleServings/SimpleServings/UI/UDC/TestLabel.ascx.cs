using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC
{
    public partial class TestLabel : System.Web.UI.UserControl
    {
        private int _recipeSupplementType;
        public int RecipeSupplementType
        {
            get { return _recipeSupplementType; }
            set { _recipeSupplementType = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int x = 0;
                x = this.RecipeSupplementType;
                if (x == 20)
                {
                    /*AutocompleteDescription1.BehaviorID = "AutoCompleteEx";
                    AjaxControlToolkit.AutoCompleteExtender au1 =new AjaxControlToolkit.AutoCompleteExtender();
                    au1.BehaviorID = "txtDescription1";
                    au1.TargetControlID = "txtDescription";
                    au1.ID = "des1";
                    au1.ServicePath = "../../AutoCompleteService.asmx";
                    au1.ServiceMethod = "GetRecipeSupplimentAutocomplete";
                    au1.MinimumPrefixLength = 3;
                    au1.CompletionInterval = 1000;
                    au1.EnableCaching = true;
                    au1.CompletionSetCount = 15;*/
                }
                else if (x == 21) {
                    /*AutocompleteDescription1.BehaviorID = "AutoCompleteEx1";
                    AjaxControlToolkit.AutoCompleteExtender au2 =new AjaxControlToolkit.AutoCompleteExtender();
                    
                    au2.BehaviorID = "txtDescription2";
                    au2.TargetControlID = "txtDescription";
                    au2.ID = "des2";
                    au2.ServicePath = "../../AutoCompleteService.asmx";
                    au2.ServiceMethod = "GetRecipeSupplimentAutocomplete";
                    au2.MinimumPrefixLength = 3;
                    au2.CompletionInterval = 1000;
                    au2.EnableCaching = true;
                    au2.CompletionSetCount = 15;*/
                }
             
            }
        }
    }
}