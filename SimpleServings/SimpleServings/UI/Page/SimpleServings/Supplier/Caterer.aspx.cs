using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.Page.SimpleServings.Supplier
{
    public partial class Caterer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Action"] == null)
            {
                UI.UDC.SimpleServings.Supplier.ListCaterer control = (UI.UDC.SimpleServings.Supplier.ListCaterer)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ListCaterer.ascx");
                ctrlPlaceHolder.Controls.Clear();
                ctrlPlaceHolder.Controls.Add(control);
            }
            else
            {
                if (Request["Action"] == "List")
                {
                    UI.UDC.SimpleServings.Supplier.ListCaterer control = (UI.UDC.SimpleServings.Supplier.ListCaterer)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ListCaterer.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "View")
                {
                    UI.UDC.SimpleServings.Supplier.ViewCaterer control = (UI.UDC.SimpleServings.Supplier.ViewCaterer)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/ViewCaterer.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "Edit")
                {
                    UI.UDC.SimpleServings.Supplier.AddEditCaterer control = (UI.UDC.SimpleServings.Supplier.AddEditCaterer)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/AddEditCaterer.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }

                if (Request["Action"] == "Add")
                {
                    UI.UDC.SimpleServings.Supplier.AddEditCaterer control = (UI.UDC.SimpleServings.Supplier.AddEditCaterer)Page.LoadControl("~/UI/UDC/SimpleServings/Supplier/AddEditCaterer.ascx");
                    ctrlPlaceHolder.Controls.Clear();
                    ctrlPlaceHolder.Controls.Add(control);
                }
            }
        }
    }
}