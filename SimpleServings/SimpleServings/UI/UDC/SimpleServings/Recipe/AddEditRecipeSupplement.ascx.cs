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
    public partial class AddEditRecipeSupplement : System.Web.UI.UserControl
    {
        private int _recipeSupplementType;
        public int RecipeSupplementType
        {
            get { return _recipeSupplementType; }
            set { _recipeSupplementType = value; this.hiddenType.Value = value.ToString(); }
        }

        public string AutoCompleteBehaviorID
        {
            get { return this.AutocompleteDescription1.BehaviorID ; }
            set { this.AutocompleteDescription1.BehaviorID=value; }
        }
        private int RecipeID
        {
            get 
            {
                if (Request["RecipeID"] != null)
                {
                    return Convert.ToInt32(Request["RecipeID"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        private string SessionName
        {
            get { return "RecipeSupplement" + RecipeSupplementType; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopAutoCompleteFunction();                
            }
        }

        private void PopAutoCompleteFunction()
        {
            //System.Diagnostics.Debugger.Launch();
            int recipeSupType =0;
            recipeSupType = RecipeSupplementType;
            if (recipeSupType == 20)
            {
                AutocompleteDescription1.BehaviorID = "AutoCompleteEx";
                AutocompleteDescription1.ServiceMethod = "GetRecipeSupplimentDirection";
            }
            else if (recipeSupType == 21)
            {
                AutocompleteDescription1.BehaviorID = "AutoCompleteEx1";
                AutocompleteDescription1.ServiceMethod = "GetRecipeSupplimentRecommendations";
            }
            else if (recipeSupType ==22)
            {
                AutocompleteDescription1.BehaviorID = "AutoCompleteEx2";
                AutocompleteDescription1.ServiceMethod = "GetRecipeSupplimentRequirements";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SaveSortOrder();
            AddRecipeSupplement();
        }

        private String GetPageName()
        {
            string returnPageName = null;


            String addOrderStr = (String)Request["ctl00$containerhome$AddRecipe1$AddEditRecipeSupplement1$hiddenOrder"];
            String editOrderStr = (String)Request["ctl00$containerhome$EditRecipe1$AddEditRecipeSupplement1$hiddenOrder"];
            
            if (addOrderStr != null)
            {
                returnPageName = "AddRecipe1";
            }

            if (editOrderStr != null)
            {
                returnPageName = "EditRecipe1";
            }

            return returnPageName;
        }

        public void SaveSortOrder()
        {
            string pageName = GetPageName();

            string ctrlClientName = "ctl00$containerhome$" + pageName + "$AddEditRecipeSupplement";  
      
            string ctrlClientID = ctrlClientName.Replace("$", "_");
            for (int i = 1; i <= 3; i++)
            {
                string hiddenOrderClientName = ctrlClientName + i + "$hiddenOrder";
                string hiddenOrderClientID = ctrlClientID + i + "_hiddenOrder";
                string hiddenOrderValue = "";
             
               //string hiddenOrderValue = Request[hiddenOrderClientName].ToString();  // Orginal Code
             
                if (!String.IsNullOrEmpty(Request[hiddenOrderClientName]))
                {
                    hiddenOrderValue = Request[hiddenOrderClientName].ToString(); // Modified Code 11/20/17 Kam
                
                }

                    

                string hiddenTypeClientName = ctrlClientName + i + "$hiddenType";

                if (hiddenOrderValue != null && hiddenOrderValue != string.Empty)
                {
                    

                    string[] orders;
                    
                    if (hiddenOrderValue.Contains("ctl00") == true) // Added my kamlesh since id gets changed.
                    {
                        orders = hiddenOrderValue.Replace(ctrlClientID + i + "_gvRecipeSupplement[]=", "").Remove(0, 1).Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                 
                        ctrlClientID = ctrlClientID.Remove(0, 6);
                        orders = hiddenOrderValue.Replace(ctrlClientID + i + "_gvRecipeSupplement[]=", "").Remove(0, 1).Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                 
                    string supplementType = Request[hiddenTypeClientName].ToString();

                    RecipeSupplements rss = (RecipeSupplements)Session["RecipeSupplement" + supplementType];
                    RecipeSupplements reorderRss = new RecipeSupplements();
                    for (int j = 0; j < orders.Length; j++)
                    {
                        try
                        {
                           
                            int index = Convert.ToInt32(orders[j]) - 1;
                            reorderRss.Add(rss[index]);
                        }
                        catch
                        {

                        }
                    }

                    Session["RecipeSupplement" + supplementType] = reorderRss;
                }
            }
            
        }

        protected void gvRecipeSupplement_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnRemove = (LinkButton)e.Row.FindControl("lnkBtnRemove");
                if (btnRemove != null)
                {
                    btnRemove.Attributes.Add("OnClick", "Javascript: return confirm('Do you want to delete this?');");
                }
            }
        }

        private void AddRecipeSupplement()
        {
            int createdBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
            if (txtDescription.Text.Trim() != string.Empty)
            {
                RecipeSupplements rss = GetRecipeSupplements();
                rss.Add(new RecipeSupplement(GetRecipeSupplementID(), txtDescription.Text.Trim(), RecipeSupplementType, 0, createdBy));
                InitSession(rss);
                PopGrid(rss);
            }
            txtDescription.Text = string.Empty;
        }

        private void RemoveRecipeSupplement(int recipeSupplementID)
        { 
            RecipeSupplements rss = GetRecipeSupplements();
            foreach (RecipeSupplement rs in rss)
            {
                if (rs.RecipeSupplementID == recipeSupplementID)
                {
                    rss.Remove(rs);
                    InitSession(rss);
                    break;
                }
                
            }
        }
              

        private void InitSession(RecipeSupplements rss)
        {
            Session[SessionName] = rss;
        }

        public void ClearSession()
        {
            Session[SessionName] = null;
        }

        private int GetRecipeSupplementID()
        {
            RecipeSupplements rss = GetRecipeSupplements();
            if (rss.Count == 0 || rss[rss.Count - 1].RecipeSupplementID > 0)
            {
                return -1;
            }
            else
            {
                return rss[rss.Count - 1].RecipeSupplementID - 1;
            }
        }

        private RecipeSupplements GetRecipeSupplements()
        {
            if (Session[SessionName] == null)
            {
                Session[SessionName] = new RecipeSupplements();
            }
            return (RecipeSupplements)Session[SessionName];
        }

        private void PopGrid()
        {
            PopGrid(GetRecipeSupplements());
        }

        private void PopGrid(RecipeSupplements rss)
        {
            gvRecipeSupplement.DataSource = rss;
            gvRecipeSupplement.DataBind();
        }

        public void PopGrid(int recipeID)
        {
            RecipeSupplements rss = RecipeSupplement.GetRecipeSupplementsByRecipeIDAndType(recipeID, RecipeSupplementType);
            InitSession(rss);
            PopGrid(rss);
        }

        public void SaveRecipeSupplement(int recipeID)
        {
            RecipeSupplement.RemoveRecipeSupplementByRecipeIDAndType(recipeID, RecipeSupplementType);
            RecipeSupplements rss = GetRecipeSupplements();

            if (rss.Count > 0)
            {
                for (int i = 0; i < rss.Count; i++)
                {
                    rss[i].AddRecipeSupplement(recipeID, i + 1);
                }
            }
        }

        public bool HasItems()
        {
            RecipeSupplements rss = GetRecipeSupplements();

            if (rss.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void gvRecipeSupplement_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRecipeSupplement.EditIndex = e.NewEditIndex;
            PopGrid();
        }

        protected void gvRecipeSupplement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int recipeSupplementID = Convert.ToInt32(gvRecipeSupplement.DataKeys[e.RowIndex].Value);
            RemoveRecipeSupplement(recipeSupplementID);
            PopGrid();
        }

        protected void gvRecipeSupplement_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRecipeSupplement.EditIndex = -1;
            PopGrid();
        }

        protected void gvRecipeSupplement_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int recipeSupplementID = Convert.ToInt32(gvRecipeSupplement.DataKeys[e.RowIndex].Value);
            string description = ((TextBox)gvRecipeSupplement.Rows[e.RowIndex].FindControl("txtEditDescription")).Text.Trim();
            UpdateRecipeSupplement(recipeSupplementID, description);
            gvRecipeSupplement.EditIndex = -1;
            PopGrid();
        }

        private void UpdateRecipeSupplement(int recipeSupplementID, string description)
        {
            RecipeSupplements rss = GetRecipeSupplements();

            for(int i=0; i < rss.Count; i++)
            {
                if (rss[i].RecipeSupplementID == recipeSupplementID)
                {
                    rss[i].Description = description;
                    InitSession(rss);
                    break;
                }

            }
        }

        protected void lnkBtnSaveOrder_Click(object sender, EventArgs e)
        {
            SaveSortOrder();
            PopGrid();
        }

    }
}