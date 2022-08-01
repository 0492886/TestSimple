using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class DFTAContactList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplyPermissions();
                PopContactList();
            }
        }

        private void PopContactList()
        {
            SimpleServingsLibrary.Shared.Staffs staffList = SimpleServingsLibrary.Shared.Staff.GetStaffContactList();
            if (staffList != null)
            {
                //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + staffList.Count + "');", true);
                gvStaffContacts.DataSource = staffList;
                gvStaffContacts.DataBind();

                Session["StaffContactList"] = staffList;
            }
            else
            {
                gvStaffContacts.DataSource = null;
                gvStaffContacts.DataBind();

                Session["StaffContactList"] = new SimpleServingsLibrary.Shared.Staffs();
            }
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff != null && staff.IsAdmin)
            {
                pnlContactAddEdit.Visible = true;
                gvStaffContacts.Columns[4].Visible = true;
                gvStaffContacts.Columns[5].Visible = true;
                gvStaffContacts.Columns[6].Visible = true;
                gvStaffContacts.CssClass = "tableStyle";
                lnkBtnSaveOrder.Visible = true;
            }
            else
            {
                pnlContactAddEdit.Visible = false;
                gvStaffContacts.Columns[4].Visible = false;
                gvStaffContacts.Columns[5].Visible = false;
                gvStaffContacts.Columns[6].Visible = false;
                gvStaffContacts.CssClass = "DatagridStyle";
                lnkBtnSaveOrder.Visible = false;
            }
        }

        protected void gvStaffContacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hl = (HyperLink)e.Row.FindControl("hlEmail");
                if (hl != null)
                {
                    hl.NavigateUrl = string.Format("mailto:{0}&Subject=Simple Servings", hl.Text.Trim());
                }
            }
        }

        protected void gvStaffContacts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStaffContacts.EditIndex = e.NewEditIndex;
            PopContactList();
        }

        protected void gvStaffContacts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStaffContacts.EditIndex = -1;
            PopContactList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //if (this.IsValid)
            //{
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null || !staff.IsAdmin) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");

            try
            {
                int contactID = 0;
                contactID = SimpleServingsLibrary.Shared.Staff.AddStaffContact(txtContactFName.Text.Trim(), txtContactLName.Text.Trim(), txtContactTitle.Text.Trim(),
                    txtContactWorkPhone.Text.Trim(), txtContactEmail.Text.Trim(), staff.StaffID, 0);
                if (contactID != null && contactID > 0)
                {
                    txtContactFName.Text = txtContactLName.Text = txtContactTitle.Text = txtContactWorkPhone.Text = txtContactEmail.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
            }

            PopContactList();
            //}
        }

        public void SaveSortOrder()
        {
            //System.Diagnostics.Debugger.Launch();
            string ctrlClientName = "ctl00$containerhome$DFTAContactList1";
            string ctrlClientID = ctrlClientName.Replace("$", "_");

            string hiddenOrderClientName = ctrlClientName + "$hiddenOrder";
            string hiddenOrderClientID = ctrlClientID + "_hiddenOrder";

            string hiddenOrderValue = Request[hiddenOrderClientName].ToString();

            if (hiddenOrderValue != null && hiddenOrderValue != string.Empty)
            {
                string[] orders = hiddenOrderValue.Replace(ctrlClientID + "_gvStaffContacts[]=", "").Remove(0, 1).Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

                SimpleServingsLibrary.Shared.Staffs rss = (SimpleServingsLibrary.Shared.Staffs)Session["StaffContactList"];
                SimpleServingsLibrary.Shared.Staffs reorderRss = new SimpleServingsLibrary.Shared.Staffs();
                for (int j = 0; j < orders.Length; j++)
                {
                    int index = Convert.ToInt32(orders[j]) - 1;
                    reorderRss.Add(rss[index]);
                }

                for (int k = 0; k < reorderRss.Count; k++)
                {
                    ((SimpleServingsLibrary.Shared.Staff)reorderRss[k]).UpdateStaffOrder(k + 1);
                }

                Session["StaffContactList"] = reorderRss;
            }
        }

        protected void gvStaffContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int contactID = Convert.ToInt32(gvStaffContacts.DataKeys[e.RowIndex].Value);
                SimpleServingsLibrary.Shared.Staff.RemoveStaffContactByID(contactID);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
            }

            PopContactList();

        }

        protected void gvStaffContacts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string firstName = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditFName")).Text.Trim();
                string lastName = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditLName")).Text.Trim();
                string title = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditTitle")).Text.Trim();
                string workPhone = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditWorkPhone")).Text.Trim();
                string email = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditEmail")).Text.Trim();

                int contactID = Convert.ToInt32(gvStaffContacts.DataKeys[e.RowIndex].Value);

                SimpleServingsLibrary.Shared.Staff.EditStaffContact(firstName, lastName, title, workPhone, email, contactID);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
            }

            gvStaffContacts.EditIndex = -1;
            PopContactList();
        }

        protected void lnkBtnSaveOrder_Click(object sender, EventArgs e)
        {
            SaveSortOrder();
            PopContactList();
        }
    }
}