using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SimpleServings.UI;



namespace SimpleServings.UI.Page
{
    /// <summary>
    /// Summary description for MyZone.
    /// </summary>
    public partial class MyZone : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (Session["UserObject"] == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
            //Response.Redirect("~/UI/Page/login.aspx");
           

            if (Request["Control"] != null && Request["Control"].Trim() != "")
            {
                PHMyZone.Controls.Clear();

                #region Setting
                if (Request["Control"].Trim() == "Setting")
                {
                    UDC.SimpleServings.Setting.CodeList setting = (UDC.SimpleServings.Setting.CodeList)Page.LoadControl("../UDC/SimpleServings/Setting/CodeList.ascx");
                    PHMyZone.Controls.Add(setting);
                    setting.PopCode();
                }
                else if (Request["Control"].Trim() == "SettingsLinks")
                {
                    PHMyZone.Controls.Clear();
                    UDC.SimpleServings.Setting.SettingsLinks settingsLinks = (UDC.SimpleServings.Setting.SettingsLinks)Page.LoadControl("../UDC/SimpleServings/Setting/SettingsLinks.ascx");
                    PHMyZone.Controls.Add(settingsLinks);
                }
                else if (Request["Control"].Trim() == "UserGroupList")
                {
                    if (Request["CodeID"] != null && Request["CodeID"] != "")
                    {
                        int codeID = Convert.ToInt32(Request["CodeID"].ToString());
                        UDC.SimpleServings.Setting.UserGroupList list = (UDC.SimpleServings.Setting.UserGroupList)Page.LoadControl("../UDC/SimpleServings/Setting/UserGroupList.ascx");
                        PHMyZone.Controls.Add(list);
                        list.PopUserGroup(codeID);
                    }

                }
                else if (Request["Control"].Trim() == "Dashboard")
                {

                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                    //Response.Redirect("~/UI/Page/login.aspx");
                    PHMyZone.Controls.Clear();
                    UDC.SimpleServings.Setting.Dashboard dashboard = (UDC.SimpleServings.Setting.Dashboard)Page.LoadControl("../UDC/SimpleServings/Setting/Dashboard.ascx");
                    PHMyZone.Controls.Add(dashboard);
                    if (!Page.IsPostBack)
                        dashboard.InitializeControl(staff.UserGroup);

                }
                else if (Request["Control"].Trim() == "ManageLinks")
                {
                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                    //Response.Redirect("~/UI/Page/login.aspx");
                    int staffID = staff.StaffID;
                    UDC.SimpleServings.Setting.ViewLinks links = (UDC.SimpleServings.Setting.ViewLinks)Page.LoadControl("../UDC/SimpleServings/Setting/ViewLinks.ascx");
                    PHMyZone.Controls.Add(links);
                    if (!Page.IsPostBack)
                        links.InitializeControl(staffID);
                }
                else if (Request["Control"].Trim() == "MenuCycle")
                {
                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                    //Response.Redirect("~/UI/Page/login.aspx");
                    int staffID = staff.StaffID;
                    UDC.SimpleServings.Setting.ViewCycle viewcycles = (UDC.SimpleServings.Setting.ViewCycle)Page.LoadControl("../UDC/SimpleServings/Setting/ViewCycle.ascx");
                    PHMyZone.Controls.Add(viewcycles);                   
                }
                else if (Request["Control"].Trim() == "NutritionalAnalysis")
                {
                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                    //Response.Redirect("~/UI/Page/login.aspx");
                    int staffID = staff.StaffID;
                    UDC.SimpleServings.Menu.MenuThresholdByMealType menuthresholdmealtype = (UDC.SimpleServings.Menu.MenuThresholdByMealType)Page.LoadControl("../UDC/SimpleServings/Menu/MenuThresholdByMealType.ascx");
                    PHMyZone.Controls.Add(menuthresholdmealtype);                   
                }
                else if (Request["Control"].Trim() == "EditLink")
                {
                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                    //Response.Redirect("~/UI/Page/login.aspx");
                    UDC.SimpleServings.Setting.EditLink edLink = (UDC.SimpleServings.Setting.EditLink)Page.LoadControl("../UDC/SimpleServings/Setting/EditLink.ascx");
                    PHMyZone.Controls.Add(edLink);

                }
                else if (Request["Control"].Trim() == "AddLink")
                {
                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
                    //Response.Redirect("~/UI/Page/login.aspx");
                    UDC.SimpleServings.Setting.AddLink addLink = (UDC.SimpleServings.Setting.AddLink)Page.LoadControl("../UDC/SimpleServings/Setting/AddLink.ascx");
                    PHMyZone.Controls.Add(addLink);
                }
                else if (Request["Control"].Trim() == "ManageCategoriesandTags")
                {
                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                    //Response.Redirect("~/UI/Page/login.aspx");
                    UDC.SimpleServings.Setting.ManageCategoriesandTags tagMgmt = (UDC.SimpleServings.Setting.ManageCategoriesandTags)Page.LoadControl("../UDC/SimpleServings/Setting/ManageCategoriesandTags.ascx");
                    PHMyZone.Controls.Add(tagMgmt);
                }


                #endregion




                #region UserGroup
                else if (Request["Control"].Trim() == "UserGroup")
                {
                    UDC.SimpleServings.UserGroup.UserGroupList userGroupList = (UDC.SimpleServings.UserGroup.UserGroupList)Page.LoadControl("../UDC/SimpleServings/UserGroup/UserGroupList.ascx");
                    PHMyZone.Controls.Add(userGroupList);
                    userGroupList.PopUserGroups();
                }
                else if (Request["Control"].Trim() == "EditUserGroup")
                {
                    if (!string.IsNullOrEmpty(Request["UserGroupID"]))
                    {
                        UDC.SimpleServings.UserGroup.EditUserGroup editUG = (UDC.SimpleServings.UserGroup.EditUserGroup)Page.LoadControl("../UDC/SimpleServings/UserGroup/EditUserGroup.ascx");
                        PHMyZone.Controls.Add(editUG);
                        editUG.PopUserGroup(Convert.ToInt32(Request["UserGroupID"].ToString()));
                    }
                }
                else if (Request["Control"].Trim() == "RemoveUserGroup")
                {
                    if (!string.IsNullOrEmpty(Request["UserGroupID"]))
                    {
                        UDC.SimpleServings.UserGroup.RemoveUserGroup removeUG = (UDC.SimpleServings.UserGroup.RemoveUserGroup)Page.LoadControl("../UDC/SimpleServings/UserGroup/RemoveUserGroup.ascx");
                        PHMyZone.Controls.Add(removeUG);
                        removeUG.InitializeControl(Convert.ToInt32(Request["UserGroupID"].ToString()));
                    }
                }
                else if (Request["Control"].Trim() == "AddUserGroup")
                {
                    UDC.SimpleServings.UserGroup.AddUserGroup addUG = (UDC.SimpleServings.UserGroup.AddUserGroup)Page.LoadControl("../UDC/SimpleServings/UserGroup/AddUserGroup.ascx");
                    PHMyZone.Controls.Add(addUG);
                    addUG.InitializeControl();
                }
                else if (Request["Control"].Trim() == "UserList")
                {
                    UDC.SimpleServings.UserGroup.UserList userList = (UDC.SimpleServings.UserGroup.UserList)Page.LoadControl("../UDC/SimpleServings/UserGroup/UserList.ascx");
                    PHMyZone.Controls.Add(userList);
                    //userList.InitializeControl();
                }
                else if (Request["Control"].Trim() == "EditSiteContent")
                {
                    UDC.SimpleServings.Setting.EditSiteContent editSiteContent = (UDC.SimpleServings.Setting.EditSiteContent)Page.LoadControl("../UDC/SimpleServings/Setting/EditSiteContent.ascx");
                    PHMyZone.Controls.Add(editSiteContent);
                }


                #endregion


                #region My Profile
                else if (Request["Control"].Trim() == "MyProfile")
                {
                    SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                    if (Request["StaffID"] != null && Request["StaffID"] != "")
                    {
                        staff.GetStaffByStaffID(Convert.ToInt32(Request["StaffID"]));
                    }
                    else
                    {
                        staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    }
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                    //Response.Redirect("~/UI/Page/login.aspx");

                    //if (Session["UserObject"]!= null && ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup != SimpleServingsLibrary.Shared.UserGroup.ADMIN)
                    if (HelpClasses.AppHelper.GetCurrentUser() != null && HelpClasses.AppHelper.GetCurrentUser().UserGroup != SimpleServingsLibrary.Shared.UserGroup.ADMIN)
                    {
                        PHMyZone.Controls.Clear();
                        UDC.SimpleServings.Staff.MyProfile myProfile = (UDC.SimpleServings.Staff.MyProfile)Page.LoadControl("../UDC/SimpleServings/Staff/MyProfile.ascx");
                        PHMyZone.Controls.Add(myProfile);
                        //if(!Page.IsPostBack)
                        myProfile.PopStaffControl(staff.StaffID, staff.UserGroup);
                        myProfile.StaffID = staff.StaffID;
                        myProfile.EnableViewState = true;
                    }
                    else
                    {
                        PHMyZone.Controls.Clear();
                        UDC.SimpleServings.Staff.ViewStaffDetails viewStaff = (UDC.SimpleServings.Staff.ViewStaffDetails)Page.LoadControl("../UDC/SimpleServings/Staff/ViewStaffDetails.ascx");
                        PHMyZone.Controls.Add(viewStaff);
                        //if(!Page.IsPostBack)
                        viewStaff.PopStaffControl(staff.StaffID, staff.UserGroup);
                        viewStaff.StaffID = staff.StaffID;
                        viewStaff.EnableViewState = true;
                    }
                }

                else if (Request["Control"].Trim() == "DeactivateStaff")
                {
                    if (Request["StaffID"] != null && Request["StaffID"].ToString() != "")
                    {

                        PHMyZone.Controls.Clear();
                        UDC.SimpleServings.Staff.DeactivateStaff deactivateStaff = (UDC.SimpleServings.Staff.DeactivateStaff)Page.LoadControl("../UDC/SimpleServings/Staff/DeactivateStaff.ascx");
                        PHMyZone.Controls.Add(deactivateStaff);
                        deactivateStaff.InitializeControl(Convert.ToInt32(Request["StaffID"].ToString()));
                        deactivateStaff.EnableViewState = true;
                    }
                }
                else if (Request["Control"].Trim() == "ActivateStaff")
                {
                    if (Request["StaffID"] != null && Request["StaffID"].ToString() != "")
                    {

                        PHMyZone.Controls.Clear();
                        UDC.SimpleServings.Staff.ActivateStaff activateStaff = (UDC.SimpleServings.Staff.ActivateStaff)Page.LoadControl("../UDC/SimpleServings/Staff/ActivateStaff.ascx");
                        PHMyZone.Controls.Add(activateStaff);
                        activateStaff.InitializeControl(Convert.ToInt32(Request["StaffID"].ToString()));
                        activateStaff.EnableViewState = true;
                    }
                }

                #endregion



                #region Staff
                else if (Request["Control"].Trim() == "ManageStaff")
                {
                    PHMyZone.Controls.Clear();
                    UDC.SimpleServings.Staff.ManageStaff manageStaff = (UDC.SimpleServings.Staff.ManageStaff)Page.LoadControl("../UDC/SimpleServings/Staff/ManageStaff.ascx");
                    PHMyZone.Controls.Add(manageStaff);
                    if (!Page.IsPostBack) manageStaff.InitializeControl();
                }


                else if (Request["Control"].Trim() == "ViewStaff" && !string.IsNullOrEmpty(Request["StaffID"]))
                {
                    int staffID = Convert.ToInt32(Request["StaffID"]);
                    SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
                    PHMyZone.Controls.Clear();
                    UDC.SimpleServings.Staff.ViewStaffDetails viewStaff = (UDC.SimpleServings.Staff.ViewStaffDetails)Page.LoadControl("../UDC/SimpleServings/Staff/ViewStaffDetails.ascx");
                    PHMyZone.Controls.Add(viewStaff);

                    viewStaff.PopStaffControl(staff.StaffID, staff.UserGroup);
                    viewStaff.StaffID = staff.StaffID;
                    viewStaff.EnableViewState = true;

                }

                else if (Request["Control"].Trim() == "EditStaff" && !string.IsNullOrEmpty(Request["StaffID"]) && !string.IsNullOrEmpty(Request["EditPart"]))
                {
                    PHMyZone.Controls.Clear();
                    UDC.SimpleServings.Staff.EditStaffControl editStaff = (UDC.SimpleServings.Staff.EditStaffControl)Page.LoadControl("../UDC/SimpleServings/Staff/EditStaffControl.ascx");
                    PHMyZone.Controls.Add(editStaff);
                    editStaff.InitializeControl(Convert.ToInt32(Request["StaffID"]), Request["EditPart"]);

                }
                else if (Request["Control"].Trim() == "MyStaff")
                {
                    PHMyZone.Controls.Clear();

                    UDC.SimpleServings.Staff.MyStaff myStaff = (UDC.SimpleServings.Staff.MyStaff)Page.LoadControl("../UDC/SimpleServings/Staff/MyStaff.ascx");

                    PHMyZone.Controls.Add(myStaff);
                    if (!Page.IsPostBack) myStaff.InitializeControl();
                }


                #endregion





                else //Load following controls for everybody
                {
                    SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
                    if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut");
                    //Response.Redirect("~/UI/Page/login.aspx");
                    PHMyZone.Controls.Clear();
                    UDC.SimpleServings.Setting.Dashboard dashboard = (UDC.SimpleServings.Setting.Dashboard)Page.LoadControl("../UDC/SimpleServings/Setting/Dashboard.ascx");
                    PHMyZone.Controls.Add(dashboard);
                    if (!Page.IsPostBack)
                    {
                        dashboard.InitializeControl(staff.UserGroup);
                    }

                }
            }
        }
        

    }
}