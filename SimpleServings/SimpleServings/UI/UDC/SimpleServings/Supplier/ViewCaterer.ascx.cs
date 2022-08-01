using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.SupplierRelationship;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Supplier
{
    public partial class ViewCaterer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            PopCaterer(Convert.ToInt32(Request["CatererID"]));
            PopDeactivateLink();
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProviderModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                lnkBtnEdit.Visible = false;
                this.lnkBtnDeactivate.Visible = false;
            }
        }

        public void PopCaterer(int CatererID)
        {
            Caterer s = Caterer.GetCatererByID(CatererID);
            PopCaterer(s);
            ctrlViewPerson.PopContactPerson(s.ContactPersonID);
        }

        private void PopCaterer(Caterer s)
        {
            lblCatererName.Text = s.CatererName;
            lblCatererAddress.Text = s.CatererAddress;
            lblCatererID.Text = s.CatererID.ToString();
        }

        protected void lnkBtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Caterer.aspx?Action=Edit&CatererID={0}", lblCatererID.Text));
        }

        protected void lnkBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Caterer.aspx?Action=List"));
        }

        private void PopDeactivateLink()
        {
            lnkBtnDeactivate.Attributes.Add("OnClick", "Javascript: return confirm('Do you want to remove this caterer?');");
        }

        protected void lnkBtnDeactivate_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int catererID = Convert.ToInt32(Request["CatererID"]);
                SimpleServingsLibrary.SupplierRelationship.Caterer.RemoveCatererByID(catererID);
                Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Caterer.aspx?Action=List"));
            }
        }
    }
}