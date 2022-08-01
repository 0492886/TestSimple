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
    public partial class AddEditSponsor : System.Web.UI.UserControl
    {
        private int CreatedBy
        {
            get { return ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).StaffID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
                if (Request["SponsorID"] != null && Request["SponsorID"].ToString() != string.Empty)
                {
                    PopSponsor(Convert.ToInt32(Request["SponsorID"]));
                }
                else
                {
                    PopSponsor(0);
                }
            }
            catch (ApplicationException ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = ex.Message;
            }
        }

        private void ApplyPermissions()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProviderModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                divContent.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        public void PopSponsor(int sponsorID)
        {
            if (sponsorID != 0)
            {
                Sponsor s = Sponsor.GetSponsorByID(sponsorID);
                PopSponsor(s);
            }
            else
            {
                lblSponsorID.Text = sponsorID.ToString();
            }
        }

        private void PopSponsor(Sponsor s)
        {
            txtSponsorName.Text = s.SponsorName;
            txtSponsorAddress.Text = s.SponsorAddress;
            lblSponsorID.Text = s.SponsorID.ToString();
            ctrlContactPerson.PopContactPerson(s.ContactPerson);
        }

        public void SaveSponsor()
        {
            int contactPersonID = 0;
            if (ctrlContactPerson.HasItems())
            {
                contactPersonID = ctrlContactPerson.SaveContactPerson();
            }

            int sponsorID = Convert.ToInt32(lblSponsorID.Text.Trim());
            string sponsorName = txtSponsorName.Text.Trim();
            string sponsorAddress = txtSponsorAddress.Text.Trim();

            if (sponsorID > 0)
            {
                Sponsor.EditSponsorByID(sponsorID, sponsorName, sponsorAddress, contactPersonID);
            }
            else
            {
                sponsorID = Sponsor.AddSponsor(sponsorName, sponsorAddress, contactPersonID, CreatedBy);
            }

            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx?Action=View&SponsorID={0}", sponsorID));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSponsorName.Text.Trim() != string.Empty)
            {
                try
                {
                    SaveSponsor();
                    
                }
                catch (Exception ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = string.Format(ex.Message);
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = string.Format("Sponsor name is required");
            }
        }

        protected void lnkBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx?Action=List"));
        }
    }
}