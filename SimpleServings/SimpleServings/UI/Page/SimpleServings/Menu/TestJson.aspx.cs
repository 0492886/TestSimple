using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace SimpleServings.UI.Page.SimpleServings.Menu
{
    public partial class TestJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static User GetUserInfo(string name, string id)
        {
            
            User user = new User();
            user.LastName = name;
            int intid = 0;
            Int32.TryParse(id, out intid);
            user.UserID = intid;
            user.ListOfNumbers = new List<int> { 1, 3, 5, 7, 9 };
            return user;
        }

    }
    public class User
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public List<int> ListOfNumbers { get; set; }
    }
}