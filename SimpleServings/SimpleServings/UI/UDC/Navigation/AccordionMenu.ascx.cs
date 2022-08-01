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
using System.Text;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.Navigation
{
    public partial class AccordionMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            this.ltAccordion.Text=RenderAccordion("my_menu", "sdmenu");
        }

        private string RenderAccordion(string name, string cssClass)
        {         
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<div id='{0}' class='{1}'>", name, cssClass));
            int userGroupID = HelpClasses.AppHelper.GetCurrentUser().UserGroup; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup;
            try
            {
               SimpleServingsLibrary.Shared.Codes codes =SimpleServingsLibrary.Shared.Code.GetCodesByTypeAndUserGroup(Code.CodeTypes.LinkCategory, userGroupID);
               foreach (SimpleServingsLibrary.Shared.Code code in codes)
                {
                    try
                    {
                        sb.Append(RenderAccordionElement(code.CodeDescription,SimpleServingsLibrary.Shared.Link.GetLinksByCategoryAndUserGroup(code.CodeID, userGroupID)));
                    }
                    catch { }
                }
            }
            catch { }
            sb.Append("</div>");
            return sb.ToString();
        }
        private string RenderAccordionElement(string headerTitle,SimpleServingsLibrary.Shared.Links links)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div>");
            sb.Append(RenderHeader(headerTitle));
            foreach (Link link in links)
            {
                sb.Append(RenderLink(link.Description, link.Hyperlink, link.LinkType));
            }
            sb.Append("</div>");
            return sb.ToString();
        }
        private string RenderHeader(string title)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<h2>");
            sb.Append(title);
            sb.Append("</h2>");
            return sb.ToString();
        }
        private string RenderLink(string name, string url, int linkType)
        {
            StringBuilder sb = new StringBuilder();
            if (linkType ==SimpleServingsLibrary.Shared.GlobalEnum.LinkType_External)
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                staff = HelpClasses.AppHelper.GetCurrentUser();  //(SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
                url += "?UserName=" + staff.UserName;
            }
            sb.Append(string.Format("<a href='{0}'>", url));
            sb.Append(name);     
            sb.Append("</a>");
            return sb.ToString();
        }
        private string RenderLink(string name, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<a href='{0}'>", url));
            sb.Append(name);
            sb.Append("</a>");
            return sb.ToString();
        }
        public void InitializeControl(int staffID)
        {
           
        }
       
    }
}