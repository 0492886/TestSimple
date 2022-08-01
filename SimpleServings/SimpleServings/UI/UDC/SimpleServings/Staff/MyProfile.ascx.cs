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

namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class MyProfile : System.Web.UI.UserControl
    {
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

        public void GetStaffID()
        {
            hlEditGeneralInfo.NavigateUrl = "./Page/MyZone.aspx?Control=EditStaff&StaffID=" + StaffID + "&EditPart=EditGeneralInfo";
        }

        public void PopStaffControl(int staffID, int groupID)
        {
            ViewGeneralInfo1.PopGeneralInfo(staffID);
            ViewAccountInfo1.PopAccounInfo(staffID);
            ViewComments1.PopComments(staffID);
            ViewModulePermissions1.PopPermissions(staffID, groupID);
            lblStaffID.Text = Convert.ToString(staffID);
            ViewState["StaffID"] = staffID;
           
                hlEditGeneralInfo.Visible = true;
                hlEditGeneralInfo.NavigateUrl = "../../../Page/MyZone.aspx?Control=EditStaff&StaffID=" + staffID + "&EditPart=EditGeneralInfo" + "&MyProfile=MyProfile";
           
            hlEditAccountInfo.NavigateUrl = "../../../Page/MyZone.aspx?Control=EditStaff&StaffID=" + staffID + "&EditPart=EditAccountInfo" + "&MyProfile=MyProfile";

            hlAddComments.NavigateUrl = "../../../Page/MyZone.aspx?Control=EditStaff&StaffID=" + staffID + "&EditPart=AddComments" + "&MyProfile=MyProfile"; 

        }

       

        //protected void lnkEditGeneralInfo_Click(object sender, EventArgs e)
        //{
        //    string editPart = SimpleServings.UI.UDC.SimpleServings.Staff.EditStaffControl.EditStaffPart.EditGeneralInfo;
        //    Response.Redirect("../Page/MyZone.aspx?Control=EditStaff&StaffID=" + Convert.ToInt32(lblStaffID.Text) + "&EditPart=" + editPart);
        //}

        //protected void lbEditAccountInfo_Click(object sender, EventArgs e)
        //{
        //    string editPart = SimpleServings.UI.UDC.SimpleServings.Staff.EditStaffControl.EditStaffPart.EditAccountInfo;
        //    Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
        //}

        //protected void lbEditModulePermissions_Click(object sender, EventArgs e)
        //{
        //    string editPart = SimpleServings.UI.UDC.SimpleServings.Staff.EditStaffControl.EditStaffPart.EditModulePermissions;
        //    Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
        //}

        //protected void lbCasePermission_Click(object sender, EventArgs e)
        //{
        //    string editPart = SimpleServings.UI.UDC.SimpleServings.Staff.EditStaffControl.EditStaffPart.EditCasePermissions;
        //    Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));

        //}

        //protected void lbEditCaseLoad_Click(object sender, EventArgs e)
        //{
        //    string editPart = SimpleServings.UI.UDC.SimpleServings.Staff.EditStaffControl.EditStaffPart.EditCaseLoadAssignment;
        //    Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
        //}

        //protected void lbAddComment_Click(object sender, EventArgs e)
        //{
        //    string editPart = SimpleServings.UI.UDC.SimpleServings.Staff.EditStaffControl.EditStaffPart.AddComments;
        //    Response.Redirect(string.Format("../Page/MyZone.aspx?Control=EditStaff&StaffID={0}&EditPart={1}", Convert.ToInt32(lblStaffID.Text), editPart));
        //}

    }
}