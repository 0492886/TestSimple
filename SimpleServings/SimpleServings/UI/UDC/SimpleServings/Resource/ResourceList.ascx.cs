using SimpleServingsLibrary.Resource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Resource
{
    public partial class ResourceList : System.Web.UI.UserControl
    {

        private const string ASCENDING = "ASC";
        private const string DESCENDING = "DESC";
        SimpleServingsLibrary.Resource.Resources cachedResources;
        protected bool CanDelete
        {
            get
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                //Response.Redirect("~/UI/Page/login.aspx");
                return (staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN
                    //|| staff.UserGroup == SimpleServingsLibrary.Shared.UserGroup.DFTASUP
                    );
            }

        }


        public void PopResourcesGrid(SimpleServingsLibrary.Resource.Resources resources)
        {
            if (resources != null)
            {
                ViewState["Resources"] = resources;
                gvResources.DataSource = resources;
                gvResources.DataBind();
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            }
            else
            {
                gvResources.DataSource = null;
                gvResources.DataBind();
            }
        }


        public void PopResources(SimpleServingsLibrary.Resource.Resources resources)
        {
                ViewState["Resources"] = resources.OrderBy(r => r.ResourceText);
                dlResources.DataSource = resources.OrderBy(r => r.ResourceText);
                dlResources.DataBind();                
        }
        protected void dlResources_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int resourceID = 0;
            Int32.TryParse(e.CommandArgument.ToString(), out resourceID);
            try
            {
                SimpleServingsLibrary.Resource.Resource resource = new SimpleServingsLibrary.Resource.Resource();
                resource.GetResourceById(resourceID);
                string filePath = Server.MapPath(resource.ResourceUrl);
                SimpleServingsLibrary.Resource.Resource.RemoveResource(resourceID);
                //PopResources();
                cachedResources = Cache["Resources"] as Resources;
                cachedResources.Remove(resource);
                Cache["Resources"] = cachedResources;
                File.Delete(filePath);
                PopResources(cachedResources);
                PopResourcesGrid(cachedResources);

            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
        }

        protected void lnkBtnRemove_Click(object sender, EventArgs e)
        {
            int resourceID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            try
            {
                SimpleServingsLibrary.Resource.Resource resource = new SimpleServingsLibrary.Resource.Resource();
                resource.GetResourceById(resourceID);
                string filePath = Server.MapPath(resource.ResourceUrl);
                SimpleServingsLibrary.Resource.Resource.RemoveResource(resourceID);
                //PopResources();
                cachedResources = new Resources();

                
                cachedResources = (Resources)ViewState["Resources"];
                cachedResources.Remove(resource);
                //Cache["Resources"] = cachedResources;
                ViewState["Resources"] = cachedResources;
                File.Delete(filePath);
                PopResources(cachedResources);
                PopResourcesGrid(cachedResources);

            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
        }

        protected void gvResources_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }
        }

        private void SortGridView(string sortExpression, string direction)
        {
            Resources resc = (Resources)ViewState["Resources"];
            Resources OrderedResc = new Resources(); 

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                var OResc = ReturnListOrderByDESC(resc, sortExpression);
                OrderedResc = returnOrderedList(OResc);

            }
            else
            {
                var OResc = ReturnListOrderByASC(resc, sortExpression);
                OrderedResc = returnOrderedList(OResc);
            }

            ViewState["Resources"] = OrderedResc;
            gvResources.DataSource = OrderedResc;
            gvResources.DataBind();

        }

        private Resources returnOrderedList(List<SimpleServingsLibrary.Resource.Resource> OResc)
        {
            Resources OrderedResc = new Resources();
            foreach (SimpleServingsLibrary.Resource.Resource r in OResc)
            {
                OrderedResc.Add(r);
            }
            return OrderedResc;
        }

        private List<SimpleServingsLibrary.Resource.Resource> ReturnListOrderByDESC(Resources resc, string sortExpression)
        {
            List<SimpleServingsLibrary.Resource.Resource> OResc = new List<SimpleServingsLibrary.Resource.Resource>();
            if (sortExpression == "ResourceText")
            {
                OResc = resc.OrderByDescending(r => r.ResourceText).ThenBy(r => r.ResourceTypeText).ToList();
            }
            else if (sortExpression == "ResourceTypeText")
            {
                OResc = resc.OrderByDescending(r => r.ResourceTypeText).ThenBy(r => r.ResourceText).ToList();
            }
            else
            {
                OResc = resc.OrderByDescending(r => r.ResourceText).ToList(); 
            }

            return OResc;
 
        }

        private List<SimpleServingsLibrary.Resource.Resource> ReturnListOrderByASC(Resources resc, string sortExpression)
        {
            List<SimpleServingsLibrary.Resource.Resource> OResc = new List<SimpleServingsLibrary.Resource.Resource>();
            if (sortExpression == "ResourceText")
            {
                OResc = resc.OrderBy(r => r.ResourceText).ThenBy(r => r.ResourceTypeText).ToList();
            }
            else if (sortExpression == "ResourceTypeText")
            {
                OResc = resc.OrderBy(r => r.ResourceTypeText).ThenBy(r => r.ResourceText).ToList();
            }
            else
            {
                OResc = resc.OrderBy(r => r.ResourceText).ToList();
            }

            return OResc;

        }



        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Descending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }




    }
}