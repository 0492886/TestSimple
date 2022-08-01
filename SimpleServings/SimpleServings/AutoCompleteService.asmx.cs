using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using SimpleServingsLibrary.Shared;

namespace SimpleServings
{
    /// <summary>
    /// Summary description for AutoCompleteService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]        
    public class AutoCompleteService : System.Web.Services.WebService
    {        
        public AutoCompleteService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
        //This is test need to be modified
        [WebMethod(true)]
        public string[] GetRecipeSupplimentDirection(string prefixText, int count)
        {
            
            return null;
        }  
        [WebMethod(true)]
        public string[] GetRecipeSupplimentRecommendations(string prefixText, int count)
        {
            Codes codes = new Codes();
            codes = Code.GetCodesByTypeAndContext(Code.CodeTypes.RecipeSupplementRecommendations,prefixText);
            List<string> items = new List<string>();
            if (codes != null)
            {
                foreach (Code code in codes)
                    items.Add(code.CodeDescription);
            } else {
                items.Add("");
            }
            return items.ToArray();
        } 
        [WebMethod(true)]
        public string[] GetRecipeSupplimentRequirements(string prefixText, int count)
        {
            
            Codes codes = new Codes();
            codes = Code.GetCodesByTypeAndContext(Code.CodeTypes.RecipeSupplementRequirements,prefixText);
            List<string> items = new List<string>();
            if (codes != null)
            {
                foreach (Code code in codes)
                    items.Add(code.CodeDescription);
            } else {
                items.Add("");
            }
            return items.ToArray();
        } 
    }
}
