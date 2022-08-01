using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.Page
{
    public partial class TestEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testFunction(1);
        }

        public void testFunction(int ActionCode)
        {

            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx"); 

            Comment testComment = Comment.GetCommentByActionCode(ActionCode);
            testComment = Comment.GetReadlyForComment(testComment, staff);
            AssignStaffList();
            lblForm.Text = testComment.From;
            Literal1.Text = testComment.Text;
        }

        public void AssignStaffList()
        {
            try
            {
                ddlSendTo.DataSource = SimpleServingsLibrary.Shared.Staff.GetAllStaff(true);
                ddlSendTo.DataTextField = "FullName";
                ddlSendTo.DataValueField = "StaffID";
                ddlSendTo.DataBind();
                ddlSendTo.Items.Insert(0, new ListItem("[Select]", "0"));
            }
            catch
            {
                ddlSendTo.DataSource = null;
                ddlSendTo.DataBind();
                ddlSendTo.Items.Insert(0, new ListItem("[Select]", "0"));
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                txtMsgBox.Visible = true;
            }
            else
            {
                txtMsgBox.Visible = false;
            }
        }

    }
}