using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace SimpleServings.UI.UDC.SimpleServings.Recipe
{
    public partial class RecipeImage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //GetImageFromDirectory();
            }            
        }

        public void GetImageFromDirectory()
        {
            try
            {
                string pathName = ConfigurationManager.AppSettings["RecipeImagePath"];            
                string fullPath = Server.MapPath(pathName);
                string[] array1 = Directory.GetFiles(fullPath,"*.jpg");
                RecipeImages images = new RecipeImages();
                foreach (string path in array1)
	            {	            
                    RecipeImg image = new RecipeImg();
                    string imageName = path.Replace(fullPath,"");
                    image.ImagePath = pathName + imageName;
                    image.ImageName = imageName;
                    images.Add(image);
	            }

                this.rptRecipeImg.DataSource = images;
                this.rptRecipeImg.DataBind();
            }
            catch {}
        }

        public string GetSelectedRecipeImage()
        {
            foreach (RepeaterItem rptitem in rptRecipeImg.Items)
            {
                RadioButton rb = (RadioButton)rptitem.FindControl("rbButton");
                if (rb.Checked)
                {
                    Label lbl = (Label)rptitem.FindControl("lblImgName");
                    return lbl.Text;
                }
            }
            return "1.jpg";  //"001.jpg";
        }

        public void SetSelectedRecipeImage(string recipeImgName)
        {
            foreach (RepeaterItem rptitem in rptRecipeImg.Items)
            {
                Label lbl = (Label)rptitem.FindControl("lblImgName");
                
                if (lbl.Text == recipeImgName)
                {                   
                    RadioButton rb = (RadioButton)rptitem.FindControl("rbButton");
                    rb.Checked = true;
                    break;
                }
            }            
        }

        public void ClearSelectedRecipeIamge()
        {
            foreach (RepeaterItem rptitem in rptRecipeImg.Items)
            {
                RadioButton rb = (RadioButton)rptitem.FindControl("rbButton");
                rb.Checked = false;
            } 
        }

        protected void rptRecipeImg_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
            RadioButton rd = (RadioButton)e.Item.FindControl("rbButton");
            string script = "SetSingleRadioButton('"+rd.ClientID+"',this)" ;
            rd.Attributes.Add("onclick", script);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearSelectedRecipeIamge();
        }

        protected void lnkBtnClear_Click(object sender, EventArgs e)
        {
            ClearSelectedRecipeIamge();
        }
    }    

    public class RecipeImg
    {
        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }
    }

    public class RecipeImages : List<RecipeImg> { }
}

