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
    public partial class Comments : System.Web.UI.UserControl
    {
        public bool IsUsedInWizard
        {
            set { btnSave.Visible = !value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSummary.Text = "";
            if (Request["StaffID"] != null)
                lblStaffID.Text = Convert.ToString(Request["StaffID"]);
        }

        public int Save(int staffID, int createdBy)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtComment.Text))
                    return SimpleServingsLibrary.Shared.StaffComment.AddComment(staffID, txtComment.Text, createdBy);
                else return 0;
            }
            catch (Exception ex)
            {
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Text = ex.Message;
                lblSummary.Visible = true;
                return 0;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save(Convert.ToInt32(lblStaffID.Text), HelpClasses.AppHelper.GetCurrentUser().StaffID);
                //Save(Convert.ToInt32(lblStaffID.Text), ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
            }
            catch { }
            if (Request["MyProfile"] == "MyProfile")
            {
                Response.Redirect("~/UI/Page/MyZone.aspx?Control=MyProfile&StaffID=" + Convert.ToInt32(lblStaffID.Text));
            }
            else
            {
                Response.Redirect("~/UI/Page/MyZone.aspx?Control=ViewStaff&StaffID=" + Convert.ToInt32(lblStaffID.Text));
            }
        }
 
    }
}