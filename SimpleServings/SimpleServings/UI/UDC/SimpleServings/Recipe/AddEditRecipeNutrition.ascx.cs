using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using SimpleServingsLibrary.RecipeSupplement;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.IO;


namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{

    public partial class AddEditRecipeNutrition : System.Web.UI.UserControl
    {
        private int CreatedBy
        {
            get { return ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).StaffID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void PopNutrition(int recipeID)
        {
            PopGrid(recipeID);
        }

        public void PopGrid(int recipeID)
        {
            RecipeNutritions rns = RecipeNutrition.GetRecipeNutritionByRecipeID(recipeID);


            rns = generateOutLook(rns);
            dlRecipeNutrition.DataSource = rns;
            dlRecipeNutrition.DataBind();
        }

        public RecipeNutritions generateOutLook(RecipeNutritions rns)
        {
            RecipeNutritions temp1 = new RecipeNutritions();
            RecipeNutritions temp2 = new RecipeNutritions();

            foreach (RecipeNutrition rn in rns)
            {
                if (rn.Orders != 0)
                {
                    if (rn.Orders <= 45) //44
                    {
                        temp1.Add(rn);
                    }
                    else
                    {
                        temp2.Add(rn);
                    }
                }
            }
            RecipeNutritions totalItems = new RecipeNutritions();
            for (int i = 0; i < temp1.Count; i++)
            {
                totalItems.Add(temp1[i]);
                totalItems.Add(temp2[i]);
            }

            return totalItems;
        }
        public void SaveNutrition(int recipeID)
        {
            if (dlRecipeNutrition.Items.Count > 0)
            {
                for (int i = 0; i < dlRecipeNutrition.Items.Count; i++)
                {
                    DataListItem item = dlRecipeNutrition.Items[i];


                    int nutritionID = Convert.ToInt32(((Label)item.FindControl("lblNutritionID")).Text);
                    int nutrientID = Convert.ToInt32(((Label)item.FindControl("lblNutrientID")).Text);
                    string value = ((TextBox)item.FindControl("txtValue")).Text.Trim();
                    int percentage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(((TextBox)item.FindControl("txtPercentage")).Text)));

                    if (value != string.Empty)
                    {
                        if (nutritionID > 0)
                        {
                            RecipeNutrition.EditRecipeNutritionByID(nutritionID, value, percentage);
                        }
                        else
                        {
                            RecipeNutrition.AddRecipeNutrition(nutrientID, recipeID, value, percentage, CreatedBy);
                        }
                    }
                }
            }
        }

        public bool HasItems()
        {
            if (dlRecipeNutrition.Items.Count > 0)
            {
                for (int i = 0; i < dlRecipeNutrition.Items.Count; i++)
                {
                    DataListItem item = dlRecipeNutrition.Items[i];

                    string value = ((TextBox)item.FindControl("txtValue")).Text.Trim();

                    if (value != string.Empty)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Validate()
        {
            StringBuilder sb = new StringBuilder();

            if (dlRecipeNutrition.Items.Count > 0)
            {
                for (int i = 0; i < dlRecipeNutrition.Items.Count; i++)
                {
                    DataListItem item = dlRecipeNutrition.Items[i];
                    string value = ((TextBox)item.FindControl("txtValue")).Text.Trim();
                    
                    if (value != string.Empty)
                    {
                        double numValue;
                        if (double.TryParse(value, out numValue) == false)
                        {
                            string nutrientName = ((Label)item.FindControl("lblNutrientName")).Text.Trim();
                            sb.AppendLine(string.Format("{0}: {1} is not a valid number", nutrientName, value));
                        }
                    }
                }
            }

            if (sb.ToString().Trim() != string.Empty)
            {
                throw new Exception(sb.ToString());
            }

            return true;

        }

        //excel part begin from here
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuNutrients.HasFile)
            {
                //string FileName = Path.GetFileName(fuNutrients.PostedFile.FileName);

                string Extension = Path.GetExtension(fuNutrients.PostedFile.FileName);
                string FileName = System.IO.Path.GetRandomFileName() + Extension;

                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];


                string FilePath = Server.MapPath(FolderPath + FileName);

                fuNutrients.SaveAs(FilePath);

                Import_To_Grid(FilePath, Extension);
            }
        }

        public string GetExcelConStr(string FilePath, string Extension)
        {
            string excelConStr = "";

            switch (Extension)
            {

                case ".xls": //Excel 97-03

                    excelConStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;

                case ".xlsx": //Excel 07
                    excelConStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;

                    break;

            }
            return excelConStr;
        }

        private void Import_To_Grid(string FilePath, string Extension)
        {
            string tempExcelConStr = GetExcelConStr(FilePath, Extension);
            if (tempExcelConStr == "" || tempExcelConStr == null)
            {
                fileError.Visible = true;
                return;
            }

            string excelConStr = String.Format(tempExcelConStr, FilePath, 1);
            OleDbConnection connExcel = new OleDbConnection(excelConStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;



            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();



            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            setGridView(FilePath, dt);
        }

        public void setGridView(string FilePath, DataTable dt)
        {
            //create invisible GridView
            GridView tempGridView1 = new GridView();
            //Bind Data to GridView

            tempGridView1.Caption = Path.GetFileName(FilePath);
            tempGridView1.DataSource = dt;
            tempGridView1.DataBind();
            File.Delete(FilePath);
            conDataListItem(tempGridView1);
        }

        public void conDataListItem(GridView tempGridView1)
        {
            foreach (DataListItem item in dlRecipeNutrition.Items)
            {
                getViewInfo(tempGridView1, item);
 
            }

        }

        public void getViewInfo(GridView GridView1, DataListItem item)
        {
           
            for (int i = 4; i < GridView1.Rows.Count; i++)
            {
                string nutrientName1 = GridView1.Rows[i].Cells[0].Text.Trim();
                double nutrientValue1 = 0;
                double percentage1 = 0;
                string nutrientName2 = GridView1.Rows[i].Cells[7].Text.Trim();
                double nutrientValue2 = 0;
                double percentage2 = 0;
                string lblNutrientName = (((Label)item.FindControl("lblNutrientName")).Text.Trim());
                if (nutrientName1 != null && nutrientName1 != "" && nutrientName1 != "&nbsp;")
                {
                    if (GridView1.Rows[i].Cells[2].Text.Trim() != null && GridView1.Rows[i].Cells[2].Text.Trim() != "" && GridView1.Rows[i].Cells[2].Text.Trim() != "&nbsp;")
                    {
                        nutrientValue1 = Convert.ToDouble(GridView1.Rows[i].Cells[2].Text.Trim());
                        if (GridView1.Rows[i].Cells[5].Text.Trim() != null && GridView1.Rows[i].Cells[5].Text.Trim() != "" && GridView1.Rows[i].Cells[5].Text.Trim() != "&nbsp;" && GridView1.Rows[i].Cells[5].Text.Trim() !="Value" )
                        {
                            if (GridView1.Rows[i].Cells[14].Text.Trim().Contains("%"))
                            {
                                int percentageIndex = GridView1.Rows[i].Cells[5].Text.LastIndexOf("%");
                                string localCellText = GridView1.Rows[i].Cells[5].Text;
                                localCellText = localCellText.Remove(percentageIndex);
                                percentage1 = Convert.ToDouble(localCellText); 
                            }
                            else
                            {
                                percentage1 = Convert.ToDouble(GridView1.Rows[i].Cells[5].Text.Trim()) * 100;
                            }
                        }
                        if (this.setResult(lblNutrientName, nutrientValue1, percentage1, nutrientName1, item))
                        {
                            return;
                        }
                    }
                    else 
                    {
                        if (this.setResult(lblNutrientName, nutrientValue1, percentage1, nutrientName1, item))
                        {
                            return;
                        }
                    }
                }

                if (nutrientName2 != null && nutrientName2 != null && nutrientName2 != null && nutrientName2 != "" && nutrientName2 != "&nbsp;")
                {
                    if (GridView1.Rows[i].Cells[11].Text.Trim() != null && GridView1.Rows[i].Cells[11].Text.Trim() != "" && GridView1.Rows[i].Cells[11].Text.Trim() != "&nbsp;" && GridView1.Rows[i].Cells[11].Text.Trim() !="Value")
                    {
                        nutrientValue2 = Convert.ToDouble(GridView1.Rows[i].Cells[11].Text.Trim());
                        if (GridView1.Rows[i].Cells[11].Text.Trim() != null && GridView1.Rows[i].Cells[14].Text.Trim() != "&nbsp;")
                        {
                            if (GridView1.Rows[i].Cells[14].Text.Trim().Contains("%"))
                            {
                                int percentageIndex = GridView1.Rows[i].Cells[14].Text.LastIndexOf("%");
                                string localCellText = GridView1.Rows[i].Cells[14].Text;
                                localCellText = localCellText.Remove(percentageIndex);
                                percentage2 = Convert.ToDouble(localCellText);
                            }
                            else
                            {
                                percentage2 = Convert.ToDouble(GridView1.Rows[i].Cells[14].Text.Trim()) * 100;
                            }
                        }
                        if (setResult(lblNutrientName, nutrientValue2, percentage2, nutrientName2, item))
                        {
                            return;
                        }
                        else
                        {
                            if (setResult(lblNutrientName, nutrientValue2, percentage2, nutrientName2, item))
                            {
                                return;
                            }
                        }
                    }
                }
             }

            ((TextBox)item.FindControl("txtValue")).Text = 0 + "";
            ((TextBox)item.FindControl("txtPercentage")).Text = 0 + "";
        }

        public bool setResult(string lblNutrientName,  double nutrientValue, double percentage, string nutrientName, DataListItem item)
        {
            bool returnValue = false;
            if (lblNutrientName.Equals(nutrientName, StringComparison.InvariantCultureIgnoreCase))
            {
                ((TextBox)item.FindControl("txtValue")).Text = nutrientValue + "";
                ((TextBox)item.FindControl("txtPercentage")).Text = percentage + "";
                returnValue = true;
            }

            return returnValue;
        }
    }
}