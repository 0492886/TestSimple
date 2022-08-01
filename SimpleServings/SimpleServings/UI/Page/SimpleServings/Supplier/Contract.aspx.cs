using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.Page.SimpleServings.Supplier
{
    public partial class Contract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Action"] == null)
            {
                UI.UDC.SimpleServings.Supplier.ListContract control = (UI.UDC.SimpleServings.Supplier.ListContract)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ListContract.ascx");
                //Session["Contracts"] = "All";
                ctrlPlaceHolder.Controls.Clear();
                ctrlPlaceHolder.Controls.Add(control);
            }
            else
            {
                if (Request["Action"] == "List")
                {
                    UI.UDC.SimpleServings.Supplier.ListContract control = (UI.UDC.SimpleServings.Supplier.ListContract)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ListContract.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "View")
                {
                    UI.UDC.SimpleServings.Supplier.ViewContract control = (UI.UDC.SimpleServings.Supplier.ViewContract)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ViewContract.ascx");
                    //Session["Contracts"] = "All";
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "Edit")
                {
                    UI.UDC.SimpleServings.Supplier.AddEditContract control = (UI.UDC.SimpleServings.Supplier.AddEditContract)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/AddEditContract.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "Add")
                {
                    UI.UDC.SimpleServings.Supplier.AddEditContract control = (UI.UDC.SimpleServings.Supplier.AddEditContract)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/AddEditContract.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }
            }
        }
    }
}