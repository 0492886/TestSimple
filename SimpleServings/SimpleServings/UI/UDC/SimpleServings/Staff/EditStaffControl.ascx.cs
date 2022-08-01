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
    public partial class EditStaffControl : System.Web.UI.UserControl
    {
        public class EditStaffPart
        { 
            public const string EditGeneralInfo = "EditGeneralInfo";
            public const string EditAccountInfo = "EditAccountInfo";
            public const string EditModulePermissions = "EditModulePermissions";
            public const string EditCasePermissions = "EditCasePermissions";
            public const string EditCaseLoadAssignment = "EditCaseLoadAssignment";
            public const string AddComments = "AddComments";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public  void InitializeControl(int staffID,string editStaffPart)
        {
            
            SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
            lblStaffName.Text = staff.FullName.ToUpper();
            switch (editStaffPart)
            { 
                case EditStaffPart.EditGeneralInfo:
                    SimpleServings.Staff.AddEditStaff editGeneralInfo = (SimpleServings.Staff.AddEditStaff)Page.LoadControl("../UDC/SimpleServings/Staff/AddEditStaff.ascx");
                    LoadUserControl(editGeneralInfo);
                    editGeneralInfo.PopStaffByID(staffID);
                    break;
                case EditStaffPart.EditAccountInfo:
                    SimpleServings.Staff.AddEditAccountInfo addEditAccountInfo = (SimpleServings.Staff.AddEditAccountInfo)Page.LoadControl("../UDC/SimpleServings/Staff/AddEditAccountInfo.ascx");
                    LoadUserControl(addEditAccountInfo);
                    addEditAccountInfo.PopStaffAccountInfo(staffID);
                    break;
              
                case EditStaffPart.EditModulePermissions:
                    SimpleServings.Staff.ModulePermissions  editModulePermissions = (SimpleServings.Staff.ModulePermissions)Page.LoadControl("../UDC/SimpleServings/Staff/ModulePermissions.ascx");
                    LoadUserControl(editModulePermissions);
                    editModulePermissions.SetStaffPermissions(staffID);
                    break;
              
                case EditStaffPart.AddComments:
                    SimpleServings.Staff.Comments addComment = (SimpleServings.Staff.Comments)Page.LoadControl("../UDC/SimpleServings/Staff/Comments.ascx");
                    LoadUserControl(addComment);
                    addComment.Save(staffID, HelpClasses.AppHelper.GetCurrentUser().StaffID);
                    //addComment.Save(staffID, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID);
                    break;
                default:
                    break;
            }
        }
        private void LoadUserControl(UserControl control)
        {
            this.phEditStaff.Controls.Add(control);
        }
    }
}