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
    public partial class StaffWizard : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                wzStaff.ActiveStepIndex = 0;
            }
        }

        protected void wzStaff_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            //TODO: remove all 12 to Sessions["UserObject"] value
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            int createdBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
            //int staffID = AddEditStaff1.AddStaff(AddEditAccountInfo1.UserName, AddEditAccountInfo1.Password, AddEditAccountInfo1.Email, 0,0, ModulePermissions1.UserGroupID,AddEditStaff1.State);
            int staffID = AddEditStaff1.AddStaff(AddEditAccountInfo1.UserName, AddEditAccountInfo1.Password, AddEditAccountInfo1.Email, 0, 0, AddStaffAccessLevel1.UserGroupID, AddEditStaff1.State);
            if (staffID != 0)
            {
                //ModulePermissions1.SaveStaffPermissions(staffID);
                AddStaffAccessLevel1.SaveStaffAccessLevel(staffID);
                Comments1.Save(staffID, createdBy);
                EmailNewStaff(staffID);
                Response.Redirect("~/UI/Page/MyZone.aspx?Control=ViewStaff&StaffID=" + Convert.ToString(staffID));
            }
        }

        private void EmailNewStaff(int staffID)
        {
            SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
            //SimpleServingsLibrary.Shared.Mailer.SendMail(staff.Email, staff);
        }

        protected void wzStaff_ActiveStepChanged(object sender, EventArgs e)
        {
            if (this.wzStaff.ActiveStepIndex == 2)
            {
                if (SimpleServingsLibrary.Shared.Staff.IsUserNameTaken(this.AddEditAccountInfo1.UserName))
                {
                    AddEditAccountInfo1.SummaryMsg = "This User Name is already taken.";
                    this.wzStaff.ActiveStepIndex = 1;
                }
                if (SimpleServingsLibrary.Shared.Validation.IsNotEmpty(this.AddEditAccountInfo1.Password) && !SimpleServingsLibrary.Shared.Validation.IsValidPassword(this.AddEditAccountInfo1.Password))
                {
                    AddEditAccountInfo1.SummaryMsg = "Password must be at least 6 characters long with at least one number.";
                    this.wzStaff.ActiveStepIndex = 1;
                }
            }
            //if (wzStaff.ActiveStepIndex == 3) this.CaseLoadAssignment1.PopControl(AddEditStaff1.SiteCode);
           
        }

        protected void wzStaff_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
        }
    }
}