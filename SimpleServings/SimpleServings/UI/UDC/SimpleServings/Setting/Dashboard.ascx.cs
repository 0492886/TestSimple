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
using System.Reflection;


namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class Dashboard : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public void InitializeControl(int userGroupID)
        {
            try
            {
                SimpleServingsLibrary.Shared.Links links = SimpleServingsLibrary.Shared.Link.GetLinksByCategoryAndUserGroup(SimpleServingsLibrary.Shared.GlobalEnum.LinkCategory_Main,userGroupID);
                PopRepeater(links);
            }
            catch(Exception)
            {
                PopRepeater(null);
            }
        }
        public void PopRepeater(SimpleServingsLibrary.Shared.Links links)
        {
            try
            {
                if (links == null) throw new Exception();
                dlLinks.DataSource = links;
                dlLinks.DataBind();
                PopCounts();
            }
            catch
            {
                dlLinks.DataSource = null;
                dlLinks.DataBind();
            }
        }
  

        private void ForceLogin(string url)
        {
            if (Session["UserObject"] == null)
            {
                Response.Redirect("Login.aspx?RedirectURL=" + url);
            }
            else
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                Response.Redirect(url + "?UserName=" + staff.UserName);
            }
        }

        protected void lnkbHyperlink_Click(object sender, EventArgs e)
        {
            int linkType = Convert.ToInt32(((LinkButton)sender).CommandName);
            if (linkType == SimpleServingsLibrary.Shared.GlobalEnum.LinkType_External)
            {
                // External Application
                ForceLogin(((LinkButton)sender).CommandArgument);
            }
            else
            {
                // Internal Application
                Response.Redirect(((LinkButton)sender).CommandArgument);
            }
        }
        

        //protected void dlLinks_ItemDataBound(object sender, DataListItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        int linkID = Convert.ToInt32(((Label)e.Item.FindControl("lblLinkID")).Text);
        //        SimpleServingsLibrary.Shared.Link link  = new SimpleServingsLibrary.Shared.Link(linkID);
        //        string className = link.ClassType;
        //        string description = link.Description;
        //        int count = GetCount(className, description);
        //        if (count < 1)
        //        {
        //            ((Label)e.Item.FindControl("lblCount")).Visible = false;
                    
        //        }
        //        else if (count < 100)
        //        {
        //            ((Label)e.Item.FindControl("lblCount")).Text = count.ToString();
        //        }
        //        else
        //        {
        //            ((Label)e.Item.FindControl("lblCount")).Text = "99+";
        //        }
        //    }

        //}
       
        //protected void LazyLoadTimer_Tick(object sender, EventArgs e)
        //{
        //    PopCounts();
        //    LazyLoadTimer.Enabled = false;
        //}

        public void PopCounts()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            
            foreach (DataListItem item in dlLinks.Items)
            {
                
                //string description = ((LinkButton)item.FindControl("lnkbHyperlink")).Text;
                string argument = ((LinkButton)item.FindControl("lnkbHyperlink")).CommandArgument;
                int count= GetCount(argument, staff.StaffID);
                
               if (count > 0)
                    {
                        ((Label)item.FindControl("lblCount")).Visible = true;
                        if (count < 100)
                        {
                            ((Label)item.FindControl("lblCount")).Text = count.ToString();
                        }
                        else
                        {
                            ((Label)item.FindControl("lblCount")).Text = "99+";
                        }
                    }
            }
        }

        private int GetCount(string argument,int staffID)
        {
            
            int count = 0;

           
            

            


            return count;
        }
                   
    }
}