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


namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class StaffSearchControl : System.Web.UI.UserControl
    {
        public void InitializeControl()
        {
            if (!Page.IsPostBack)
            {

                PopDropDowns();
                PopAllStaff();

            }
        }

        public void PopAllStaff()
        {
            try
            {
                int number = Convert.ToInt32(ConfigurationManager.AppSettings["GridPageSize"]);
                //this.StaffGrid1.PopGrid(SimpleServingsLibrary.Shared.Staff.GetRecentlyAddedStaff(number));
                this.StaffGrid1.PopGrid(SimpleServingsLibrary.Shared.Staff.GetAllStaff(true));
                this.lblMsg.Text = "Most Recently added Staff members";
            }
            catch(Exception ex)
            {
                this.lblMsg.Text =string.Format("could not load staff because {0}",ex.Message);
                this.StaffGrid1.ClearGrid();
            }
        }

        private void PopDropDowns()
        {
            SimpleServingsLibrary.Shared.UserGroups userGroups = SimpleServingsLibrary.Shared.UserGroup.GetAllUserGroup();
            ddlUserGroup.DataSource = userGroups;
            ddlUserGroup.DataValueField="UserGroupID";
            ddlUserGroup.DataTextField="UserGroupName";
            ddlUserGroup.DataBind();
            ddlUserGroup.Items.Insert(0, new ListItem("[All]", GlobalEnum.EmptyCode.ToString()));
            //SimpleServingsLibrary.Shared.Utility.GetAllSitesAll(ddlSite, "");
            
        }
        protected void btnFindByName_Click(object sender, EventArgs e)
        {
            lblMsg.Text = String.Empty;
            //txtCaseLoad.Text = String.Empty;
            //ddlSite.ClearSelection();
            //ddUnit.ClearSelection();
            ddlUserGroup.ClearSelection();
            try
            {

                if (String.IsNullOrEmpty(txtName.Text))
                    this.StaffGrid1.PopGrid(SimpleServingsLibrary.Shared.Staff.GetStaffByIsActive(!cbDeactiveStaff.Checked));
                else
                {

                    string[] segments;
                
                    segments = txtName.Text.Split(',');
                    if (segments.Length == 1)
                    {
                        segments = txtName.Text.Trim().Split(' ');
                        if (segments[0].Trim().ToString() == "")
                        {
                            segments[0] = "+";
                        }
                        if (segments.Length == 1)
                            this.StaffGrid1.PopGrid(SimpleServingsLibrary.Shared.Staff.GetStaffsBySearchName(segments[0].Trim().ToString(), "",!cbDeactiveStaff.Checked));
                        else
                            this.StaffGrid1.PopGrid(SimpleServingsLibrary.Shared.Staff.GetStaffsBySearchName(segments[0].Trim().ToString(), segments[1].Trim().ToString(), !cbDeactiveStaff.Checked));
                    }
                    else
                        this.StaffGrid1.PopGrid(SimpleServingsLibrary.Shared.Staff.GetStaffsBySearchName(segments[0].Trim().ToString(), segments[1].Trim().ToString(), !cbDeactiveStaff.Checked));
                }
            }

            catch
            {
                this.lblMsg.Text = string.Format("no staff member found with name [{0}]", txtName.Text);
                this.StaffGrid1.ClearGrid();
            }
            
        }


        

        public bool ShowDetailsColumn
        {
            set { this.StaffGrid1.ShowDetailsColumn = value; }
        }
        public bool ShowSelectionColumn
        {
            set { this.StaffGrid1.ShowSelectionColumn = value; }
        }

        public int GetSelectedStaffID()
        {
            return StaffGrid1.GetSelectedStaffID();
        }

        protected void ddlUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = String.Empty;
            //txtCaseLoad.Text = String.Empty;
            txtName.Text = String.Empty;
            //ddlSite.ClearSelection();
            //ddUnit.ClearSelection();
            try
            {
                if (ddlUserGroup.SelectedValue == GlobalEnum.EmptyCode.ToString())
                {
                    this.StaffGrid1.PopGrid(SimpleServingsLibrary.Shared.Staff.GetAllStaff(true));
                }
                else
                {
                    this.StaffGrid1.PopGrid(SimpleServingsLibrary.Shared.Staff.GetStaffByUserGroup(Convert.ToInt32(ddlUserGroup.SelectedValue)));
                }                
            }
            catch
            {
                this.lblMsg.Text = string.Format("no staff member found in user group [{0}]", ddlUserGroup.SelectedItem.Text);
                this.StaffGrid1.ClearGrid();
            }

        }

       
    }
}