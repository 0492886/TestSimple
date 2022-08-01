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
    public partial class StaffSnapshot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                if (Request["StaffID"]!= null)
                {
                    PopStaffSnapshot(Convert.ToInt32(Request["StaffID"].ToString()));
                }
            }
        }

       
        
        public void PopStaffSnapshot(int staffID)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                staff.GetStaffByStaffID(staffID);
                PopSnapshot(staff);

            }
            catch
            {
                lblMsg.Text = string.Format("Could not load staff with staffID {0}", staffID);

            }

        }
        private void PopSnapshot(SimpleServingsLibrary.Shared.Staff staff)
        {
            lblFullName.Text = staff.FullName;
            //lblSite.Text = staff.SiteName;
            lblUnit.Text = staff.UnitName;
            //try
            //{
            //    SimpleServingsLibrary.Shared.Caseloads loads = SimpleServingsLibrary.Shared.Caseload.GetCaseloadsByStaffID(staff.StaffID);
            //    foreach (SimpleServingsLibrary.Shared.Caseload load in loads)
            //    {
            //        lblCaseLoad.Text += load.CaseloadNumber + " ";
            //    }
            //}
            //catch { lblCaseLoad.Text = String.Empty; }
            lblCaseLoad.Text = String.Empty;
            lblTelephone.Text = staff.Phone2;
            lblFax.Text = staff.Fax;
            lblEmail.Text = staff.Email;
            int supervisorID = staff.ManagedBy;
            try
            {
                SimpleServingsLibrary.Shared.Staff supervisor = new SimpleServingsLibrary.Shared.Staff(supervisorID);
                lblSupFullName.Text = supervisor.FullName;
                //lblSupSite.Text = supervisor.SiteName;
                lblSupTelephone.Text = supervisor.Phone2;
                lblSupFax.Text = supervisor.Fax;
                lblSupEmail.Text = supervisor.Email;
            }
            catch { }
            
        }
    }
}