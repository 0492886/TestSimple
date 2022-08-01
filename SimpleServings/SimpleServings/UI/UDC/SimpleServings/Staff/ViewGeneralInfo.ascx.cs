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
    public partial class ViewGeneralInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopGeneralInfo(int staffID)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                staff.GetStaffByStaffID(staffID);
                PopStaff(staff);
            }
            catch
            {
                lblSummary.Text = string.Format("Could not load staff with staffID {0}", staffID);
            }
        }
        private void PopStaff(SimpleServingsLibrary.Shared.Staff staff)
        {
            lblFirstName.Text = staff.FirstName;
            lblLastName.Text = staff.LastName;
            //lblHomePhone.Text = staff.HomePhone;
            lblWorkPhone.Text = staff.WorkPhone;
            lblStreetAddres1.Text = staff.StreetAddress1;
            lblStreetAddres2.Text = staff.StreetAddress2;
            lblCity.Text = staff.City;
            lblState.Text = staff.StateText;
            lblZipCode.Text = staff.ZipCode;
            //lblSiteCode.Text = staff.SiteCodeText;
            //lblSiteName.Text = staff.SiteName;
            //lblSiteCode.Text = SimpleServingsLibrary.Shared.Code.DecodeCode(staff.SiteCode.ToString());
            lblFax.Text = staff.Fax;
            //lblManagedBy.Text = SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(staff.ManagedBy); ;
            SimpleServingsLibrary.Shared.Staff manager = new SimpleServingsLibrary.Shared.Staff();
            try
            {
                manager = new SimpleServingsLibrary.Shared.Staff(staff.ManagedBy);
                lnkBStaff.Text = manager.FullName;
                lnkBStaff.Attributes.Add("onclick", "javascript:window.open('" + string.Format(ResolveUrl("~/UI/Page/SimpleServings/Staff/StaffSnapshot.aspx?StaffID={0}"), manager.StaffID) + "','_blank','left=40,top=50,width=770,height=500,scrollbars=yes,resizable=yes');return false;");
            }
            catch (Exception)
            {
                lnkBStaff.Text = String.Empty;
            }
            //ProgramCD is Unit Code
            //lblProgramCD.Text = staff.UnitName;
            //string fieldDays;
            // fieldDays= FieldDay.GetFieldDaysAsString(staff.StaffID);
            // if (fieldDays == "")
            //     lblFieldDays.Text = "Not Applicable";
            // else
            //     lblFieldDays.Text = fieldDays;
        }
 
    }
}