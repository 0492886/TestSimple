using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class LinkPermissionList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int userGroupID = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
                //int staffID = ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
                try
                {
                    LinkRepeater1.PopRepeater(SimpleServingsLibrary.Shared.Link.GetLinksByUserGroup(userGroupID));

                    //LinkRepeater1.InitializeControl(staffID);

                    LinkRepeater1.ShowCheckBoxes = false;
                }
                catch 
                {
                    LinkRepeater1.PopRepeater(null);
                }
            }
        }
      
    }
}