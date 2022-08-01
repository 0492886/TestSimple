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
    public partial class AddEditRecipeSupplementCheckList : System.Web.UI.UserControl
    {
        private int _recipeSupplementType;
        public int RecipeSupplementType
        {
            get { return _recipeSupplementType; }
            set
            {
                _recipeSupplementType = value;
                this.hiddenType.Value = value.ToString();
            }
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
                //PopAutoCompleteFunction();
                InitLV();
            }
        }

        private void InitLV()
        {
            RecipeSuppCodes rcs = RecipeSuppCode.GetRecipeSuppCodesByRecipeType(RecipeID, RecipeSupplementType);
            InitSession(rcs);
            BindLV(GetRecipeSuppCodes());
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

        #region old logic
        //updated 1-28-2016
        //public void SaveSortOrder()
        //{
        //    string pageName = GetPageName();

        //    string ctrlClientName = "ctl00$containerhome$" + pageName + "$AddEditRecipeSupplement";
        //    string ctrlClientID = ctrlClientName.Replace("$", "_");
        //    for (int i = 1; i <= 3; i++)
        //    {
        //        string hiddenOrderClientName = ctrlClientName + i + "$hiddenOrder";
        //        string hiddenOrderClientID = ctrlClientID + i + "_hiddenOrder";

        //        string hiddenOrderValue = Request[hiddenOrderClientName].ToString();
        //        string hiddenTypeClientName = ctrlClientName + i + "$hiddenType";

        //        if (hiddenOrderValue != null && hiddenOrderValue != string.Empty)
        //        {
        //            hiddenOrderValue = hiddenOrderValue.Replace(ctrlClientID + i + "_gvRecipeSupplement[]=", "");

        //            string[] orders =  (hiddenOrderValue[0] == '[') ? hiddenOrderValue.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries) :
        //                hiddenOrderValue.Remove(0, 1).Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
        //            string supplementType = Request[hiddenTypeClientName].ToString();

        //            RecipeSupplements rss = (RecipeSupplements)Session["RecipeSupplement" + supplementType];
        //            //RecipeSuppCodes rcs = (RecipeSuppCodes)Session["RecipeSupplement" + supplementType + "_codes"];

        //            RecipeSupplements reorderRss = new RecipeSupplements();
        //            //RecipeSuppCodes reorderRcs = new RecipeSuppCodes();

        //            for (int j = 0; j < orders.Length; j++)
        //            {
        //                int index = (orders[j].Contains("[]=")) ? Convert.ToInt32(orders[j].Replace("[]=", "")) - 1 : Convert.ToInt32(orders[j]) - 1;
        //                if (index >= 0)
        //                {
        //                    reorderRss.Add(rss[index]);
        //                    //reorderRcs.Add(rcs[index]);
        //                }

        //            }

        //            Session["RecipeSupplement" + supplementType] = reorderRss;
        //            //Session["RecipeSupplement" + supplementType + "_codes"] = reorderRcs;
        //        }
        //    }

        //}

        #endregion

        private void InitSession(RecipeSupplements rss)
        {
            Session[SessionName] = rss;
        }

        //added 1-26-2016
        private void InitSession(RecipeSuppCodes rcs)
        {
            Session[SessionName + "_codes"] = rcs;
        }

        //updated 1-26-2016
        public void ClearSession()
        {
            Session[SessionName] = null;
            Session[SessionName + "_codes"] = null;
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

        //added 1-26-2016
        private RecipeSuppCodes GetRecipeSuppCodes()
        {
            if (Session[SessionName + "_codes"] == null)
            {
                Session[SessionName + "_codes"] = new RecipeSuppCodes();
            }
            return (RecipeSuppCodes)Session[SessionName + "_codes"];
        }

        //updated 1-26-2016
        private void PopGrid()
        {
            //PopGrid(GetRecipeSupplements());
            BindLV(GetRecipeSuppCodes());
        }

        private void BindLV(RecipeSuppCodes rcs)
        {
            lvRecipeSuppCode.DataSource = rcs;
            lvRecipeSuppCode.DataBind();
        }

        //updated 1-28-2016
        public void PopGrid(int recipeID)
        {

            RecipeSupplements rss = RecipeSupplement.GetRecipeSupplementsByRecipeIDAndType(recipeID, RecipeSupplementType);
            InitSession(rss);

            //PopGrid(rss);

            RecipeSuppCodes rcs = RecipeSuppCode.GetRecipeSuppCodesByRecipeType(recipeID, RecipeSupplementType);
            InitSession(rcs);
            BindLV(rcs);
            //PopulateLV();
        }
        //added 1-26-2016
        private void SaveRecipeSuppCodes()
        {
            RecipeSupplements rss = GetRecipeSupplements();

            if (lvRecipeSuppCode.Items != null && lvRecipeSuppCode.Items.Count > 0)
            {
                int createdBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;

                foreach (ListViewDataItem item in lvRecipeSuppCode.Items)
                {
                    CheckBox chkSupplementItem = item.FindControl("chkSupplementItem") as CheckBox;
                    Label lblDescription = item.FindControl("lblSupplementDescription") as Label;
                    HiddenField hdnRecipeSupplementID = item.FindControl("hdnRecipeSupplementID") as HiddenField;

                    if (hdnRecipeSupplementID.Value == "0" && chkSupplementItem.Checked)
                    {
                        rss.Add(new RecipeSupplement(GetRecipeSupplementID(), lblDescription.Text, RecipeSupplementType, 0, createdBy));
                    }
                    else if (hdnRecipeSupplementID.Value != "0" && !chkSupplementItem.Checked)
                    {
                        RecipeSupplement rs = rss.Where(r => r.RecipeSupplementID.ToString() == hdnRecipeSupplementID.Value && r.RecipeSupType == RecipeSupplementType).SingleOrDefault();
                        if (rs != null) rss.Remove(rs);
                        //RemoveRecipeSupplement(Convert.ToInt32(hdnRecipeSupplementID.Value));
                    }
                }

                InitSession(rss);
            }

        }
        //updated 1-26-2016
        public void SaveRecipeSupplement(int recipeID)
        {
            RecipeSupplement.RemoveRecipeSupplementByRecipeIDAndType(recipeID, RecipeSupplementType);
            RecipeSupplements rss = GetRecipeSupplements();

            SaveRecipeSuppCodes();

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

        private void UpdateRecipeSupplement(int recipeSupplementID, string description)
        {
            RecipeSupplements rss = GetRecipeSupplements();

            for (int i = 0; i < rss.Count; i++)
            {
                if (rss[i].RecipeSupplementID == recipeSupplementID)
                {
                    rss[i].Description = description;
                    InitSession(rss);
                    break;
                }

            }
        }
    }
}