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

namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class ProfileGrid : System.Web.UI.UserControl
    {
        public bool ViewDetails
        {
            set { gvStaffList.Columns[9].Visible = value; }
        }
        public void PopGrid(SimpleServingsLibrary.Shared.Staffs staffList)
        {
            if (staffList != null && staffList.Count > 0)
            {
                gvStaffList.DataSource = staffList;
                Session["StaffList"] = staffList;
                gvStaffList.DataBind();
                this.lblMsg.Text = string.Format("{0} staff member(s) found", staffList.Count);
            }
            else
            {
                ClearGrid();
            }
        }
        public void ClearGrid()
        {
            gvStaffList.DataSource = null;
            gvStaffList.DataBind();
            this.lblMsg.Text = String.Empty;
        }

        public bool ShowDetailsColumn
        {
            set { this.gvStaffList.Columns[9].Visible = value; }
        }
        public bool ShowSelectionColumn
        {
            set { this.gvStaffList.Columns[0].Visible = value; }
        }

        public int GetSelectedStaffID()
        {

            foreach (GridViewRow row in gvStaffList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rbSelect = (RadioButton)row.FindControl("rbSelect");
                    if (rbSelect.Checked)
                    {
                        return Convert.ToInt32(row.Cells[1].Text);
                    }
                }
            }
            return 0;

        }

        protected void rbSelect_CheckedChanged(object sender, EventArgs e)
        {
            ClearGridSelections();
            RadioButton selectedBtn = (RadioButton)sender;
            selectedBtn.Checked = true;
        }

        private void ClearGridSelections()
        {
            //Clear All Radio Button Choices From Prior
            foreach (GridViewRow GridRow in gvStaffList.Rows)
            {
                if (GridRow.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rbSelect =
                         (RadioButton)GridRow.FindControl("rbSelect");
                    rbSelect.Checked = false;
                }
            }
        }

        //grid paging event
        protected void gvStaffList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["StaffList"] != null)
            {
                SimpleServingsLibrary.Shared.Staffs staffList = (SimpleServingsLibrary.Shared.Staffs)Session["StaffList"];
                PopGrid(staffList);
                gvStaffList.PageIndex = e.NewPageIndex;
                gvStaffList.DataBind();
            }

        }
    }
}