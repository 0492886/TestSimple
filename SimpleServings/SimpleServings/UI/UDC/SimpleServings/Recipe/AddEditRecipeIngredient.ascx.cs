using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using SimpleServingsLibrary.Shared;
using SimpleServingsLibrary.RecipeSupplement;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class AddEditRecipeIngredient : System.Web.UI.UserControl
    {

        private String ReturnPageName()
        {
            string returnPageName = null;
            String addOrderStr = (String)Request["ctl00$containerhome$AddRecipe1$AddEditRecipeIngredient1$hiddenOrder"];
            String editOrderStr = (String)Request["ctl00$containerhome$EditRecipe1$AddEditRecipeIngredient1$hiddenOrder"];
            if (addOrderStr != null)
            {
                returnPageName = "AddRecipe1";
            }
            else if (editOrderStr != null)
            {
                returnPageName = "EditRecipe1";
            }
            return returnPageName;
        }

        public String[] SortRecipeIngredient()
        {
            //ctl00_containerhome_EditRecipe1_AddEditRecipeSupplement1_hiddenOrder
            string pageName = ReturnPageName();
            String orderStr = (String)Request["ctl00$containerhome$" + pageName + "$AddEditRecipeIngredient1$hiddenOrder"];


            if (orderStr == null || orderStr.Equals(""))
                return null;
            //ctl00_containerhome_EditRecipe1_AddEditRecipeIngredient1_gvRecipeIngredient[]=
            if (orderStr.Contains("ctl00") == true) // Added my kamlesh since id gets changed.
            {
                orderStr = orderStr.Replace("ctl00_containerhome_" + pageName + "_AddEditRecipeIngredient1_gvRecipeIngredient[]=", "");
            }
            else
            {
                orderStr = orderStr.Replace("containerhome_" + pageName + "_AddEditRecipeIngredient1_gvRecipeIngredient[]=", "");
            }
            
            //if you have header, please uncomment out the following statement
            orderStr = orderStr.Remove(0, 1);
         
            Char[] separator = { '&' };
            String[] order = orderStr.Split(separator, StringSplitOptions.RemoveEmptyEntries);
           
            RecipeIngredients data2 = new RecipeIngredients();
            RecipeIngredients data1 = GetRecipeIngredients();
            if (data2 == null)
                return null;
            for (int i = 0; i < order.Length; i++)
            {
                //data2.Add(data1[int.Parse(order[i])]);
                //if you have header, please use the following statement to replace the above one.

         
                data2.Add(data1[int.Parse(order[i]) - 1]);

   
            }
            InitSession(data2);
            return null;
        }

        private int CreatedBy
        {
            get { return ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).StaffID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                PopMeasureUnit();
            }
        }

        private void PopMeasureUnit(DropDownList ddlMeasureUnit)
        {
            Utility.GetCodesByTypeAndUserGroupSelect(ddlMeasureUnit, Code.CodeTypes.IngredientMeasureUnit, ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).UserGroup, "");
        }

        private void PopMeasureUnit()
        {
            Utility.GetCodesByTypeAndUserGroupSelect(ddlMeasureUnit, Code.CodeTypes.IngredientMeasureUnit, ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).UserGroup, "");
        }

        private void PopGrid(RecipeIngredients ris)
        {
            gvRecipeIngredient.DataSource = ris;
            gvRecipeIngredient.DataBind();
        }

        private void PopGrid()
        {
            PopGrid(GetRecipeIngredients());
        }

        private void AddIngredient(string quantity)
        {
            RecipeIngredients ris = GetRecipeIngredients();
            ris.Add(new RecipeIngredient(GetIngredientID(), quantity, Convert.ToInt32(ddlMeasureUnit.SelectedItem.Value), txtDescription.Text.Trim(), CreatedBy));
            InitSession(ris);
            PopGrid(ris);
            ClearBox();
        }

        private void RemoveIngredient(int ingredientID)
        {
            RecipeIngredients ris = GetRecipeIngredients();
            foreach (RecipeIngredient ri in ris)
            {
                if (ri.IngredientID == ingredientID)
                {
                    ris.Remove(ri);
                    break;
                }
            }
            InitSession(ris);
        }

        private void InitSession(RecipeIngredients ris)
        {
            Session["Ingredients"] = ris;
        }

        public void ClearSession()
        {
            Session["Ingredients"] = null;
        }

        private void ClearBox()
        {
            txtQuantity.Text = string.Empty;
            txtDescription.Text = string.Empty;
            PopMeasureUnit();
        }

        private RecipeIngredients GetRecipeIngredients()
        {
            if (Session["Ingredients"] == null)
            {
                Session["Ingredients"] = new RecipeIngredients();
            }

            return (RecipeIngredients)(Session["Ingredients"]);
        }

        private int GetIngredientID()
        {
            RecipeIngredients ris = GetRecipeIngredients();
            if (ris.Count == 0 || ris[ris.Count - 1].IngredientID > 0)
            {
                return -1;
            }
            else
            {
                return ris[ris.Count - 1].IngredientID - 1;
            }
        }

        private bool IsNumberOrFraction(string value)
        {
            Regex reg = new Regex(@"(^[+]?([.]\d+|\d+([.]\d+)?)$)|(^[0-9]*\s*[0-9]+\/[0-9]+$)");
            if (value.Contains(@"/"))
            {
                string[] quantityArray = value.Split(new string[] { @"/" }, StringSplitOptions.RemoveEmptyEntries);
                string denominator = quantityArray[quantityArray.Length - 1];
                Regex regZero = new Regex(@"^0+$");
                if (regZero.IsMatch(denominator))
                {
                    return false;
                }
            }
            return reg.IsMatch(value);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SortRecipeIngredient();
            if (IsNumberOrFraction(txtQuantity.Text.Trim()))
            {
                AddIngredient(txtQuantity.Text.Trim());
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = string.Format("Quantity: {0} is not valid decimal or fraction number", txtQuantity.Text.Trim());
            }
        }

        protected void gvRecipeSupplement_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnRemove = (LinkButton)e.Row.FindControl("lnkBtnRemove");
                if (btnRemove != null)
                {
                    btnRemove.Attributes.Add("OnClick", "Javascript: return confirm('Do you want to delete this ingredient?');");
                }


                DropDownList ddlMeasureUnit = e.Row.FindControl("ddlEditMeasureUnit") as DropDownList;
                if (ddlMeasureUnit != null)
                {
                    PopMeasureUnit(ddlMeasureUnit);
                    string measureUnit = DataBinder.Eval(e.Row.DataItem, "MeasureUnit").ToString();
                    ddlMeasureUnit.Items.FindByValue(measureUnit).Selected = true;
                }
            }
        }

        public void PopGrid(int recipeID)
        {
            RecipeIngredients ris = RecipeIngredient.GetRecipeIngredientByRecipeID(recipeID);
            InitSession(ris);
            PopGrid(ris);
        }

        public void SaveIngredient(int recipeID)
        {
            SortRecipeIngredient();
            RecipeIngredient.RemoveRecipeIngredientByRecipeID(recipeID);
            RecipeIngredients ris = GetRecipeIngredients();

            foreach (RecipeIngredient ri in ris)
            {
                ri.AddRecipeIngredient(recipeID);
            }
            
        }

        public bool HasItems()
        {
            RecipeIngredients ris = GetRecipeIngredients();

            if (ris.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void gvRecipeIngredient_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRecipeIngredient.EditIndex = e.NewEditIndex;
            PopGrid();
        }

        protected void gvRecipeIngredient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ingredientID = Convert.ToInt32(gvRecipeIngredient.DataKeys[e.RowIndex].Value);
            RemoveIngredient(ingredientID);
            PopGrid();
        }

        protected void gvRecipeIngredient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRecipeIngredient.EditIndex = -1;
            lblMsg.Text = "";
            PopGrid();
        }

        protected void gvRecipeIngredient_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ingredientID = Convert.ToInt32(gvRecipeIngredient.DataKeys[e.RowIndex].Value);
            DropDownList ddlEditMeasureUnit = gvRecipeIngredient.Rows[e.RowIndex].FindControl("ddlEditMeasureUnit") as DropDownList;
            int measureUnit = Convert.ToInt32(ddlEditMeasureUnit.SelectedItem.Value);
            string description = ((TextBox)gvRecipeIngredient.Rows[e.RowIndex].FindControl("txtEditDescription")).Text.Trim();
            string quantity = ((TextBox)gvRecipeIngredient.Rows[e.RowIndex].FindControl("txtEditQuantity")).Text.Trim();
            
            if (IsNumberOrFraction(quantity))
            {
                RecipeIngredient ri = new RecipeIngredient(ingredientID, quantity, measureUnit, description, CreatedBy);
                UpdateRecipeIngredient(ri);
                lblMsg.Text = "";

                gvRecipeIngredient.EditIndex = -1;
                PopGrid();
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = string.Format("Quantity: {0} is not valid decimal or fraction number", quantity);
            }
        }

        private void UpdateRecipeIngredient(RecipeIngredient ri)
        {
            RecipeIngredients ris = GetRecipeIngredients();

            for (int i = 0; i < ris.Count; i++)
            {
                if (ris[i].IngredientID == ri.IngredientID)
                {
                    ris[i] = ri;
                    InitSession(ris);
                    break;
                }
            }
        }

        protected void lnkBtnSaveOrder_Click(object sender, EventArgs e)
        {
            SortRecipeIngredient();
            PopGrid();
        }
    }
}