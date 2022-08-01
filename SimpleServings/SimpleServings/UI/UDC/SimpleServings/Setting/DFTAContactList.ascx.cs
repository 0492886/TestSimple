using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using log4net;
using log4net.Config;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class DFTAContactList : System.Web.UI.UserControl
    {
        private static readonly ILog log = LogManager.GetLogger("AppManager");
        
        static DFTAContactList()
        {
            XmlConfigurator.Configure();
        }

        //public SimpleServingsLibrary.Shared.Staffs CurrentContacts
        //{
        //    get { return (ViewState["DFTAContactList"] != null) ? (SimpleServingsLibrary.Shared.Staffs)ViewState["DFTAContactList"] : null; }
        //    set { ViewState["DFTAContactList"] = value; }
        //}

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
            }
            else
            {
                gvStaffContacts.DataSource = null;
                gvStaffContacts.DataBind();
            }

            Session["DFTAContactList"] = staffList;
        }

        private void PopContactTitles()
        {
            SimpleServingsLibrary.Shared.Codes codes = SimpleServingsLibrary.Shared.Code.GetCodesByType(SimpleServingsLibrary.Shared.Code.CodeTypes.DFTAStaffTitle, true);
            if (codes != null && codes.Count > 0)
            {
                //((SimpleServingsLibrary.Shared.Code)codes[0]).
                foreach (SimpleServingsLibrary.Shared.Code code in codes)
                {
                    ddlContactTitle.Items.Add(new ListItem() { Text = code.CodeDescription.Trim(), Value = code.CodeID.ToString() });
                }
            }
            ddlContactTitle.Items.Insert(0, "[Select]");
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
                //gvStaffContacts.CssClass = "tableStyle";
                //lnkBtnSaveOrder.Visible = true;

                lblMsg.CssClass = "informNote";
                lblMsg.Text = "&nbsp;&nbsp;&nbsp;Instructions: <br />&nbsp;&nbsp;&nbsp; * Add new contacts to the list by entering information below.";
                //lblMsg.Text += "<br />&nbsp;&nbsp;&nbsp; * Reorder contacts in the list by drag and drop then clicking Save Order. ";
                lblMsg.Text += "<br />&nbsp;&nbsp;&nbsp; * Update and delete contacts from the list by using the Edit and Remove buttons";

                PopContactTitles();
            }
            else
            {
                pnlContactAddEdit.Visible = false;
                gvStaffContacts.Columns[4].Visible = false;
                gvStaffContacts.Columns[5].Visible = false;
                gvStaffContacts.Columns[6].Visible = false;
                //gvStaffContacts.CssClass = "DatagridStyle";
                //lnkBtnSaveOrder.Visible = false;
            }
        }

        protected void gvStaffContacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //System.Diagnostics.Debugger.Launch();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hl = (HyperLink)e.Row.FindControl("hlEmail");
                if (hl != null)
                {
                    hl.NavigateUrl = string.Format("mailto:{0}&Subject=Simple Servings", hl.Text.Trim());
                }

                //if (e.Row.RowState == DataControlRowState.Edit)
                //{
                    DropDownList ddlEditTitle = (DropDownList)e.Row.FindControl("ddlEditTitle");
                    if (ddlEditTitle != null)
                    {
                        SimpleServingsLibrary.Shared.Codes codes = SimpleServingsLibrary.Shared.Code.GetCodesByType(SimpleServingsLibrary.Shared.Code.CodeTypes.DFTAStaffTitle, true);
                        if (codes != null && codes.Count > 0)
                        {
                            //((SimpleServingsLibrary.Shared.Code)codes[0]).
                            foreach (SimpleServingsLibrary.Shared.Code code in codes)
                            {

                                if (string.Equals(DataBinder.Eval(e.Row.DataItem, "Title").ToString().Trim(), code.CodeDescription.Trim(), StringComparison.CurrentCultureIgnoreCase)
                                    || Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TitleCode")) == code.CodeID)
                                {
                                    ddlEditTitle.Items.Add(new ListItem() { Text = code.CodeDescription.Trim(), Value = code.CodeID.ToString(), Selected = true });
                                }
                                else
                                {
                                    ddlEditTitle.Items.Add(new ListItem() { Text = code.CodeDescription.Trim(), Value = code.CodeID.ToString(), Selected = false });
                                }
                            }
                        }
                        ddlEditTitle.Items.Insert(0, "[Select]");
                    }
                //}
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
            if (Page.IsValid)
            {
                SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();

                try
                {
                    int contactID = 0;
                    //contactID = SimpleServingsLibrary.Shared.Staff.AddStaffContact(txtContactFName.Text.Trim(), txtContactLName.Text.Trim(), txtContactTitle.Text.Trim(),
                    //    txtContactWorkPhone.Text.Trim(), txtContactEmail.Text.Trim(), staff.StaffID, 0);
                    contactID = SimpleServingsLibrary.Shared.Staff.AddStaffContact(txtContactFName.Text.Trim(), txtContactLName.Text.Trim(), Convert.ToInt32(ddlContactTitle.SelectedValue),
                        txtContactWorkPhone.Text.Trim(), txtContactEmail.Text.Trim(), staff.StaffID, 0);
                    if (contactID != null && contactID > 0)
                    {
                        txtContactFName.Text = txtContactLName.Text = txtContactTitle.Text = txtContactWorkPhone.Text = txtContactEmail.Text = string.Empty;
                        ddlContactTitle.SelectedIndex = -1;
                    }

                }
                catch (Exception ex)
                {
                    //lblMsg.ForeColor = System.Drawing.Color.Red;
                    //lblMsg.Text = "Error Adding Contact: " + ex.Message;
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Error Adding Contact: " + ex.Message + "');", true);
                }

                PopContactList();
            }
        }

        //public void SaveSortOrder()
        //{
        //    //string ctrlClientName = "ctl00$containerhome$DFTAContactList1";
        //    //string ctrlClientID = ctrlClientName.Replace("$", "_");

        //    //string hiddenOrderClientName = ctrlClientName + "$hiddenOrder";
        //    //string hiddenOrderClientID = ctrlClientID + "_hiddenOrder";            

        //    //string hiddenOrderValue = Request[hiddenOrderClientName].ToString();

        //    string ctrlClientID = hiddenOrder.ClientID;
        //    string hiddenOrderValue = hiddenOrder.Value.ToString();

        //    if (!string.IsNullOrEmpty(hiddenOrderValue))
        //    {
        //        if (!hiddenOrderValue.Contains("hiddenOrder"))
        //        {
        //            ctrlClientID = ctrlClientID.Replace("_hiddenOrder", "");
        //        }

        //        //string[] orders = hiddenOrderValue.Replace(ctrlClientID + "_gvStaffContacts[]=", "").Remove(0, 1).Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

        //        hiddenOrderValue = hiddenOrderValue.Replace(ctrlClientID + "_gvStaffContacts[]=", "");

        //        //log.Info(hiddenOrderValue.Trim());

        //        hiddenOrderValue = hiddenOrderValue.Remove(0, 2);

        //        log.Info(hiddenOrderValue.Trim());

        //        string[] orders = hiddenOrderValue.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

        //        SimpleServingsLibrary.Shared.Staffs rss = (SimpleServingsLibrary.Shared.Staffs)Session["DFTAContactList"];
        //        if (rss != null && rss.Count > 0)
        //        {
        //            SimpleServingsLibrary.Shared.Staffs reorderRss = new SimpleServingsLibrary.Shared.Staffs();
        //            for (int j = 0; j < orders.Length; j++)
        //            {
        //                int index = Convert.ToInt32(orders[j]) - 1;
        //                //int index = Convert.ToInt32(orders[j]);

        //                //log.InfoFormat("index = {0}, rssCount = {1}", index, rss.Count);
        //                if (index < 0)
        //                {
        //                    index = index + 1;
        //                    //throw new Exception("selected index is out range");
        //                }
        //                else if (index == rss.Count)
        //                {
        //                    index = index - 1;
        //                }

        //                if (!reorderRss.Contains((SimpleServingsLibrary.Shared.Staff)rss[index]))
        //                {
        //                    reorderRss.Add((SimpleServingsLibrary.Shared.Staff)rss[index]);                            
        //                }
        //            }

        //            for (int k = 0; k < reorderRss.Count; k++)
        //            {
        //                ((SimpleServingsLibrary.Shared.Staff)reorderRss[k]).UpdateStaffOrder(k + 1);
        //            }

        //            Session["DFTAContactList"] = reorderRss;
        //        }
        //    }
        //}
        protected void lnkBtnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveSortOrder();
            }
            catch (Exception ex)
            {
                //lblMsg.ForeColor = System.Drawing.Color.Red;
                //lblMsg.Text = "Error Saving Order: " + ex.Message;
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Error Saving Order: " + ex.Message + "');", true);

                log.Error("Error Saving Order: " + ex.Message, ex);
            }

            PopContactList();
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
                //lblMsg.ForeColor = System.Drawing.Color.Red;
                //lblMsg.Text = "Error Deleting Contact: " + ex.Message;
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(Error Deleting Contact: '" + ex.Message + "');", true);
            }

            PopContactList();

        }

        protected void gvStaffContacts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string firstName = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditFName")).Text.Trim();
                    string lastName = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditLName")).Text.Trim();
                    //string title = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditTitle")).Text.Trim();
                    int titleCode = Convert.ToInt32(((DropDownList)gvStaffContacts.Rows[e.RowIndex].FindControl("ddlEditTitle")).SelectedValue);
                    string workPhone = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditWorkPhone")).Text.Trim();
                    string email = ((TextBox)gvStaffContacts.Rows[e.RowIndex].FindControl("txtEditEmail")).Text.Trim();

                    int contactID = Convert.ToInt32(gvStaffContacts.DataKeys[e.RowIndex].Value);

                    //SimpleServingsLibrary.Shared.Staff.EditStaffContact(firstName, lastName, title, workPhone, email, contactID);
                    SimpleServingsLibrary.Shared.Staff.EditStaffContact(firstName, lastName, titleCode, workPhone, email, contactID);
                }
                catch (Exception ex)
                {
                    //lblMsg.ForeColor = System.Drawing.Color.Red;
                    //lblMsg.Text = "Error Updating Contact: " + ex.Message;
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Error Updating Contact: " + ex.Message + "');", true);
                }

                gvStaffContacts.EditIndex = -1;
                PopContactList();
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() == "[Select]")
            {
                args.IsValid = false;
            }
        }

        protected void ddlContactTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}