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

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class CodeView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
            
            if (!Page.IsPostBack)
            {
                if (Request["CodeID"] != null)
                {
                    PopCode(Convert.ToInt32(Request["CodeID"]));
                }
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
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.SettingModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.View))
            {
                this.pnPage.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }
        public void PopCode(int codeID)
        {
            SimpleServingsLibrary.Shared.Code Code = new SimpleServingsLibrary.Shared.Code();
            Code.GetCodeByCodeID(codeID);
            lblCodeID.Text = Code.CodeID.ToString();
            lblCodeType.Text = Code.CodeType.ToString();
            lblCodeValue.Text = Code.CodeDescription;
            lblComment.Text = Code.Comment;
            try
            {
                lblCreatedBy.Text = SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(Code.CreatedBy);
            }
            catch { }
            lblCreatedOn.Text = Code.CreatedOn;
        }
    }
}