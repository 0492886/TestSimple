using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Menu
{
    public partial class MenuThresholdGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public void PopGrid(SimpleServingsLibrary.MenuThreshold.MenuThresholds menuthresholds)
        {
            if (menuthresholds != null)
            {
                this.gvMenusthreshold.DataSource = menuthresholds;
                this.gvMenusthreshold.DataBind();
                this.lblCount.ForeColor = Color.Green;
                this.lblCount.Text = menuthresholds.Count + " record(s) found";
            }
            else
            {
                this.gvMenusthreshold.DataSource = null;
                this.gvMenusthreshold.DataBind();
                this.lblCount.ForeColor = Color.Red;
                this.lblCount.Text = "No record found";
            }
        }

         protected void lnkBtnRemove_Click(object sender, EventArgs e)
         {
             try
             {
                 int ThresholdID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                 SimpleServingsLibrary.MenuThreshold.MenuThreshold.DeactivateMenuThreshold(ThresholdID);

                 string[] str = lblCount.Text.Split(',');

                 SimpleServingsLibrary.MenuThreshold.MenuThresholds menuthresholds = new SimpleServingsLibrary.MenuThreshold.MenuThresholds();
                 menuthresholds = SimpleServingsLibrary.MenuThreshold.MenuThreshold.GetMenuThresholdsByTypes(Convert.ToInt32(str[0].ToString()),
                     Convert.ToInt32(str[1].ToString()), Convert.ToInt32(str[2].ToString()), Convert.ToInt32(str[3].ToString()));
                 PopGrid(menuthresholds);

             }
             catch (Exception ex)
             {
                 this.lblCount.Text = ex.Message;
                 this.lblCount.ForeColor = Color.Red;
 
             }



         }


         public void setThresholdParameters(string commaSepList)
         {
             lblCount.Text = commaSepList;
             lblCount.Visible = false;
 
         }

    }
}