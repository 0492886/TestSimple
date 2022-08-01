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

using log4net;
using log4net.Config;


namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class ViewStaffDetails : System.Web.UI.UserControl
    {
        private static readonly ILog log = LogManager.GetLogger("AppManager");

        static ViewStaffDetails()
        {
            XmlConfigurator.Configure();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int StaffID
        {
            get 
            {
                if (ViewState["StaffID"] != null)
                    return Convert.ToInt32(ViewState["StaffID"]);
                else
                    return 0;
            }
            set 
            {
                ViewState["StaffID"] = value;
                lblStaffID.Text = Convert.ToString(value);
            }
        }

        //public void GetStaffID()
        //{
        //    hlEditGeneralInfo.NavigateUrl = "./Page/MyZone.aspx?Control=EditStaff&StaffID="+ StaffID + "&EditPart=EditGeneralInfo";
        //}

        public void PopStaffControl(int staffID,int groupID)
        {
            ViewGeneralInfo1.PopGeneralInfo(staffID);
            ViewAccountInfo1.PopAccounInfo(staffID);
            ViewComments1.PopComments(staffID);
            ViewModulePermissions1.PopPermissions(staffID, groupID);
            ViewStaffAccessLevel1.InitializeControl(staffID);
            hlEditStaffAccessLevel.NavigateUrl = ResolveUrl(string.Format("~/UI/Page/SimpleServings/Staff/AddStaffAccessLevel.aspx?StaffID={0}", staffID));
            //ViewCasePermissions1.InitializeControl(staffID, true);
           
            lblStaffID.Text = Convert.ToString(staffID);
            ViewState["StaffID"] = staffID;
            
            hlEditGeneralInfo.NavigateUrl = "../../../Page/MyZone.aspx?Control=EditStaff&StaffID=" + staffID + "&EditPart=EditGeneralInfo";
            //TO DO
            hlEditAccountInfo.NavigateUrl = "../../../Page/MyZone.aspx?Control=EditStaff&StaffID=" + staffID + "&EditPart=EditAccountInfo";
            hlEditModulePermissions.NavigateUrl = "../../../Page/MyZone.aspx?Control=EditStaff&StaffID=" + staffID + "&EditPart=EditModulePermissions"+"&GroupID="+groupID;
            hlAddComments.NavigateUrl = "../../../Page/MyZone.aspx?Control=EditStaff&StaffID=" + staffID + "&EditPart=AddComments";
            SimpleServingsLibrary.Shared.Staff user = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
            lnkBDeactivateStaff.Visible = user.IsAdmin && staff.IsActive;
            lnkBActivateStaff.Visible = user.IsAdmin && !staff.IsActive;
            lnkBLockStaff.Visible = user.IsAdmin && staff.IsActive & !staff.IsLocked;
            lnkBUnlockStaff.Visible = user.IsAdmin && staff.IsActive & staff.IsLocked; 
        }

        protected void lnkEditGeneralInfo_Click(object sender, EventArgs e)
        {
            string editPart = SimpleServings.Staff.EditStaffControl.EditStaffPart.EditGeneralInfo;
            Response.Redirect("../Page/MyZone.aspx?Control=EditStaff&StaffID=" + Convert.ToInt32(lblStaffID.Text) + "&EditPart=" + editPart);
        }

        protected void lbEditAccountInfo_Click(object sender, EventArgs e)
        {
            string editPart = SimpleServings.Staff.EditStaffControl.EditStaffPart.EditAccountInfo;
            Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
        }

        protected void lbEditModulePermissions_Click(object sender, EventArgs e)
        {
            string editPart = SimpleServings.Staff.EditStaffControl.EditStaffPart.EditModulePermissions;
            Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
        }

        protected void lbCasePermission_Click(object sender, EventArgs e)
        {
            string editPart = SimpleServings.Staff.EditStaffControl.EditStaffPart.EditCasePermissions;
            Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
                   
        }

        protected void lbEditCaseLoad_Click(object sender, EventArgs e)
        {
            string editPart = SimpleServings.Staff.EditStaffControl.EditStaffPart.EditCaseLoadAssignment;
            Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
        }

        protected void lbAddComment_Click(object sender, EventArgs e)
        {
            string editPart = SimpleServings.Staff.EditStaffControl.EditStaffPart.AddComments;
            Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
        }
        protected void lnkBDeactivateStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/MyZone.aspx?Control=DeactivateStaff&StaffID={0}",Convert.ToInt32(lblStaffID.Text)));
        }

        protected void lnkBActivateStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/MyZone.aspx?Control=ActivateStaff&StaffID={0}", Convert.ToInt32(lblStaffID.Text)));

        }

        protected void lnkBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/MyZone.aspx?Control=ManageStaff"));
        }

        #region lock/unlock staff
        protected void lnkBLockStaff_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff tStaff = new SimpleServingsLibrary.Shared.Staff(Convert.ToInt32(lblStaffID.Text));

                if (tStaff == null) throw new Exception("Error processing current staff request");
                if (tStaff.IsLocked) throw new Exception("Current staff account is already locked!");

                //SimpleServingsLibrary.Shared.Staff.LockStaffByStaffID(Convert.ToInt32(lblStaffID.Text));
                if (tStaff.Lock())
                {
                    Response.Redirect(string.Format("~/UI/Page/MyZone.aspx?Control=ManageStaff"));
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                log.Error("LockStaff Error", ex);

                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + HttpUtility.HtmlEncode(ex.Message) + "');", true);
            }
        }

        protected void lnkBUnlockStaff_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff tStaff = new SimpleServingsLibrary.Shared.Staff(Convert.ToInt32(lblStaffID.Text));

                if (tStaff == null) throw new Exception("Error processing current staff request");
                if (!tStaff.IsLocked) throw new Exception("Current staff account is already unlocked!");

                //SimpleServingsLibrary.Shared.Staff.UnlockStaffByStaffID(Convert.ToInt32(lblStaffID.Text));
                if (tStaff.Unlock())
                {
                    Response.Redirect(string.Format("~/UI/Page/MyZone.aspx?Control=ManageStaff"));
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                log.Error("UnlockStaff Error", ex);

                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + HttpUtility.HtmlEncode(ex.Message) + "');", true);
            }
        }
        #endregion

    }
}