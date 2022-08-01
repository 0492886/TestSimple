using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SimpleServings.UI.Page
{
    /// <summary>
    /// Summary description for AsynchronousSave
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AsynchronousSave : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string SaveInput(String input)
        {
            string StrInput = Server.HtmlEncode(input); if (!String.IsNullOrEmpty(StrInput))
            {

                string[] strFields = StrInput.Split('+');
                int field0, field2, field3;
                short field1;

                Int32.TryParse(strFields[0], out field0);
                Int32.TryParse(strFields[2], out field2);
                Int32.TryParse(strFields[3], out field3);



                short.TryParse(strFields[1], out field1);
                SaveMenuItem(field0, field1, field2, field3);
                // code to save all input values
                // savethese values to temp DB table, temp file or xml file

                //Display last saved values           

                return String.Format("Last saved in table: Rows {0} ,<br/> Last Saved Week: {1} <br/> Last saved draft: {2} at {3}.", strFields[0], strFields[1], strFields[2], DateTime.Now);

            }

            else
            {

                return ""; //if input values are empty..return empty string
            }

        }

        private void SaveMenuItem(int dayOfWeekID, short weekInCycle, int menuItemTypeID, int recipeID)
        {
            
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            //if (staff == null) Response.Redirect("~/UI/Page/login.aspx");


            int menuID = 0;
            //Int32.TryParse(lblMenuID.Text, out menuID);
            try
            {

                SimpleServingsLibrary.Menu.MenuItem menuItem = new SimpleServingsLibrary.Menu.MenuItem();
                menuItem.MenuID = menuID;
                menuItem.DayOfWeekID = dayOfWeekID;
                menuItem.WeekInCycle = weekInCycle;
                menuItem.MenuItemTypeID = menuItemTypeID;
                menuItem.CreatedBy = staff.StaffID;
                menuItem.RecipeID = recipeID;
                menuItem.AddMenuItem();

            }
            catch 
            {
                //lblMsg.ForeColor = System.Drawing.Color.Red;
                //lblMsg.Text = ex.Message;

            }
        }

    }
}
