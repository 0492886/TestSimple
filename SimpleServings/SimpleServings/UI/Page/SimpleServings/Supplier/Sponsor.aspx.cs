using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.Page.SimpleServings.Supplier
{
    public partial class Sponsor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Action"] == null)
            {
                UI.UDC.SimpleServings.Supplier.ListSponsor control = (UI.UDC.SimpleServings.Supplier.ListSponsor)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ListSponsor.ascx");
                ctrlPlaceHolder.Controls.Clear();
                ctrlPlaceHolder.Controls.Add(control);
            }
            else
            {
                if (Request["Action"] == "List")
                {
                    UI.UDC.SimpleServings.Supplier.ListSponsor control = (UI.UDC.SimpleServings.Supplier.ListSponsor)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ListSponsor.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "View")
                {
                    UI.UDC.SimpleServings.Supplier.ViewSponsor control = (UI.UDC.SimpleServings.Supplier.ViewSponsor)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ViewSponsor.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "Edit")
                {
                    UI.UDC.SimpleServings.Supplier.AddEditSponsor control = (UI.UDC.SimpleServings.Supplier.AddEditSponsor)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/AddEditSponsor.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "Add")
                {
                    UI.UDC.SimpleServings.Supplier.AddEditSponsor control = (UI.UDC.SimpleServings.Supplier.AddEditSponsor)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/AddEditSponsor.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }
            }
        }
    }
}