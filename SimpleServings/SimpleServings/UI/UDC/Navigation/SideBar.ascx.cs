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
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.Navigation
{
    public partial class SideBar : System.Web.UI.UserControl
    {
        //Display/Hide Check Boxes
        public bool ShowCheckBoxes
        {
            set
            {
                foreach (RepeaterItem item in rpLinks.Items)
                    (item.FindControl("cbSelected")).Visible = value;
            }
        }
        //Display/Hide Edit button
        public bool ShowEditButton
        {
            set
            {
                foreach (RepeaterItem item in rpLinks.Items)
                    (item.FindControl("lnkbEdit")).Visible = value;
            }
        }

        //Display/Hide Select All and Deselect All Buttons
        public bool ShowSelectAllButtons
        {
            set
            {
                lnkBtnSelectAll.Visible = value;
                lnkBtnDeselectAll.Visible = value;
            }
        }
        public string CssName
        {
            set { this.pnPage.CssClass = value; }
        }

        
        public void InitializeControl(int staffID)
        {
            SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
            try
            {
                SimpleServingsLibrary.Shared.Links links = SimpleServingsLibrary.Shared.Link.GetLinksByUserGroup(staff.UserGroup);
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
                rpLinks.DataSource = links;
                rpLinks.DataBind();
            }
            catch
            {
                rpLinks.DataSource = null;
                rpLinks.DataBind();
            }
        }

        protected void rpLinks_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            Label categoryLabel = (Label)e.Item.FindControl("lblCategory");
            string strval = categoryLabel.Text;
            string category = (string)ViewState["category"];
            if (category == strval)
            {
                categoryLabel.Visible = false;
                categoryLabel.Text = string.Empty;
            }
            else
            {
                category = strval;
                ViewState["category"] = category;
                categoryLabel.Visible = true;
                categoryLabel.Text = category;
            }
        }

        private void ForceLogin(string url)
        {
           
            if (Session["UserObject"] == null)
            {
                Response.Redirect("~/UI/Page/Login.aspx?");
            }
            else
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();

                staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                
                Response.Redirect(url + "?UserName=" + staff.UserName );
            }
        }

        protected void lnkbHyperlink_Click(object sender, EventArgs e)
        {
            int linkType = Convert.ToInt32(((LinkButton)sender).CommandName);
            if (linkType ==SimpleServingsLibrary.Shared.GlobalEnum.LinkType_External)
            {
                // External Application
                ForceLogin(((LinkButton)sender).CommandArgument);
            }
            else if (linkType ==SimpleServingsLibrary.Shared.GlobalEnum.LinkType_Internal)
            {
                // Internal Application
                Response.Redirect(ResolveUrl("~/UI/Page/" + ((LinkButton)sender).CommandArgument));
            }
            else
            {
                ((LinkButton)sender).OnClientClick += "aspnetForm.target ='_blank';";
                Response.Redirect(ResolveUrl(((LinkButton)sender).CommandArgument));
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Page/MyZone.aspx?Control=EditLink&LinkID=" + ((LinkButton)sender).CommandArgument);
        }

        // returns an ArrayList of LinkID corresponding to the selected rows
        public ArrayList GetSelectedLinks()
        {
            ArrayList linkIDs = new ArrayList();
            string linkID;
            foreach (RepeaterItem item in this.rpLinks.Items)
            {
                if (item.FindControl("cbSelected") != null)
                {
                    if (((CheckBox)item.FindControl("cbSelected")).Checked)
                    {
                        linkID = ((Label)item.FindControl("lblLinkID")).Text;
                        if (!linkIDs.Contains(linkID)) linkIDs.Add(linkID);
                    }
                }
            }
            return linkIDs;
        }

        // checks the checkBoxes corresponding to theSimpleServingsLibrary.Shared.Links passed as a parameter
        public void SelectLinks(SimpleServingsLibrary.Shared.Links links)
        {
            foreach (SimpleServingsLibrary.Shared.Link link in links)
            {
                foreach (RepeaterItem item in this.rpLinks.Items)
                {
                    if (link.LinkID == Convert.ToInt32(((Label)item.FindControl("lblLinkID")).Text))
                    {
                        ((CheckBox)item.FindControl("cbSelected")).Checked = true;
                        break;
                    }
                }
            }
        }

        //Updates UserGroupLinkPermissions for the given groupID from the selected links 
        public void Save(int groupID)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            int staffID = staff.StaffID;
           SimpleServingsLibrary.Shared.UserGroupLinkPermission.RemoveUserGroupLinkPermissionsByUserGroup(groupID);
            ArrayList linkIDs = GetSelectedLinks();
           SimpleServingsLibrary.Shared.UserGroupLinkPermission userGroupLP;
            foreach (string linkID in linkIDs)
            {
                userGroupLP = new UserGroupLinkPermission();
                userGroupLP.UserGroupID = groupID;
                userGroupLP.LinkID = Convert.ToInt32(linkID);
                userGroupLP.CreatedBy = staffID ;
                userGroupLP.AddUserGroupLinkPermission();
            }
        }

        //Displays all links and checks the checkboxes corresponding 
        //to the links that this groupID is allowed to view.
        public void PopRepeater(int groupID)
        {
            try
            {
               SimpleServingsLibrary.Shared.Links allLinks =SimpleServingsLibrary.Shared.Link.GetAllLinks();
                PopRepeater(allLinks);

               SimpleServingsLibrary.Shared.Links ugLinks =SimpleServingsLibrary.Shared.Link.GetLinksByUserGroup(groupID);
                SelectLinks(ugLinks);
            }
            catch { }
        }

        protected void lnkBtnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rpLinks.Items)
                ((CheckBox)item.FindControl("cbSelected")).Checked = true;
        }

        protected void lnkBtnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rpLinks.Items)
                ((CheckBox)item.FindControl("cbSelected")).Checked = false;
        }
    }
}