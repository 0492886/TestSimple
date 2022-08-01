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
    public partial class ViewSponsor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            PopSponsor(Convert.ToInt32(Request["SponsorID"]));
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

        public void PopSponsor(int sponsorID)
        {
            Sponsor s = Sponsor.GetSponsorByID(sponsorID);
            PopSponsor(s);
            ctrlViewPerson.PopContactPerson(s.ContactPersonID);
        }

        private void PopSponsor(Sponsor s)
        {
            lblSponsorName.Text = s.SponsorName;
            lblSponsorAddress.Text = s.SponsorAddress;
            lblSponsorID.Text = s.SponsorID.ToString();
        }

        protected void lnkBtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx?Action=Edit&SponsorID={0}", lblSponsorID.Text));
        }

        protected void lnkBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx?Action=List"));
        }

        private void PopDeactivateLink()
        {
            lnkBtnDeactivate.Attributes.Add("OnClick", "Javascript: return confirm('Do you want to remove this contract?');");
        }

        protected void lnkBtnDeactivate_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int sponsorID = Convert.ToInt32(Request["SponsorID"]);
                SimpleServingsLibrary.SupplierRelationship.Sponsor.RemoveSponsorByID(sponsorID);
                Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx?Action=List"));
            }
        }
    }
}