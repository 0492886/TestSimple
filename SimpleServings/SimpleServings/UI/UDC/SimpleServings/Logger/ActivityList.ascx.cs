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


namespace SimpleServings.UI.UDC.SimpleServings.Logger
{
    public partial class ActivityList : System.Web.UI.UserControl
    {
        private string ImageDelete = "~/UI/Imgs/ActivityIconSystem/ActivityRemove.gif";
        private string ImageAdd = "~/UI/Imgs/ActivityIconSystem/ActivityAdd.gif";
        private string ImageEdit = "~/UI/Imgs/ActivityIconSystem/ActivityEdit.gif";
        private string ImageAssign = "~/UI/Imgs/ActivityIconSystem/ActivityAssign.gif";

        public int UserID
        {
            get
            {
                object o = this.ViewState["_UserID"];
                if (o == null)
                    return 0;//
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_UserID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void IntializeControl(int staffID, int logsType)
        {
            UserID = staffID;
            try
            {
                SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(ddlLogType,
                      SimpleServingsLibrary.Shared.Code.CodeTypes.Module, HelpClasses.AppHelper.GetCurrentUser().UserGroup, logsType.ToString());

                //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(ddlLogType,
                //      SimpleServingsLibrary.Shared.Code.CodeTypes.Module, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup, logsType.ToString());
            }
            catch { }
            try
            {
                ddlStaffMember.DataSource = SimpleServingsLibrary.Shared.Staff.GetStaffHierarchyByStaffID(staffID);
                ddlStaffMember.DataTextField = "FullName";
                ddlStaffMember.DataValueField = "StaffID";
                ddlStaffMember.DataBind();
                if (ddlStaffMember.Items.Count > 1)
                ddlStaffMember.Items.Insert(0, new ListItem("All", "0"));
                try
                {
                    if (staffID != 0 )
                        ddlStaffMember.Items.FindByValue(staffID.ToString()).Selected = true;
                }
                catch { }
            }
            catch {
                ddlStaffMember.Items.Clear();
                ddlStaffMember.Items.Insert(0, new ListItem("All", "0"));
            }
            //Faces.Shared.FacesCode.GetCodesByType(FacesCode.CodeTypes.ModuleViewURL
        }
        public void PopLogListByStaffID(int staffID)
        {
            //Session["StaffID"] = staffID;            
            try
            {
                PopLogList(SimpleServingsLibrary.Shared.Logger.GetLogsByStaffID(staffID));

            }
            catch
            {
                rpActivity.DataSource = null;
                rpActivity.DataBind();
                lblMsg.Text = "no activity logs found";
            }
        }

        public void PopLogListByStaffIDAndLogsType(int userID,int staffID, int logsType)
        {
            
            //Session["StaffID"] = staffID;
            //if (Session["StaffAll"] == null)  Session["StaffAll"] = Session["StaffID"];  
            //PopLogsType(staffID, logsType);
            try
            {
                if (!cbDate.Checked)
                {
                    PopLogList(SimpleServingsLibrary.Shared.Logger.GetLogsByStaffIDAndLogsType(staffID, logsType));
                        for (int i = 0; i < rpActivity.Items.Count; i++)
                        {
                            Image image = ((Image)rpActivity.Items[i].FindControl("ImageItem"));
                            string actionTaken = ((Label)rpActivity.Items[i].FindControl("lblActionTaken")).Text;


                            if (actionTaken.ToLower().ToString().StartsWith("added") || actionTaken.ToLower().ToString().StartsWith("inserted") || actionTaken.ToLower().ToString().StartsWith("reinstated"))
                                image.ImageUrl = ImageAdd;
                            else if (actionTaken.ToLower().ToString().StartsWith("deleted") || actionTaken.ToLower().ToString().StartsWith("removed"))
                                image.ImageUrl = ImageDelete;
                            else if (actionTaken.ToLower().ToString().StartsWith("updated") || actionTaken.ToLower().ToString().StartsWith("edited") || actionTaken.ToLower().StartsWith("transferred") || actionTaken.ToLower().StartsWith("reassigned"))
                                image.ImageUrl = ImageEdit;
                            else if (actionTaken.ToLower().ToString().StartsWith("assigned"))
                                image.ImageUrl = ImageAssign;
                             
                        }
                }
                else
                {
                    PopLogList(SimpleServingsLibrary.Shared.Logger.GetTodaysLogsByStaffIDAndLogsType(staffID, logsType));
                    for (int i = 0; i < rpActivity.Items.Count; i++)
                    {
                        Image image = ((Image)rpActivity.Items[i].FindControl("ImageItem"));
                        string actionTaken = ((Label)rpActivity.Items[i].FindControl("lblActionTaken")).Text;


                        if (actionTaken.ToLower().ToString().StartsWith("added") || actionTaken.ToLower().ToString().StartsWith("inserted") || actionTaken.ToLower().ToString().StartsWith("reinstated"))
                            image.ImageUrl = ImageAdd;
                        else if (actionTaken.ToLower().ToString().StartsWith("deleted") || actionTaken.ToLower().ToString().StartsWith("removed"))
                            image.ImageUrl = ImageDelete;
                        else if (actionTaken.ToLower().ToString().StartsWith("updated") || actionTaken.ToLower().ToString().StartsWith("edited") || actionTaken.ToLower().StartsWith("transferred") || actionTaken.ToLower().StartsWith("reassigned"))
                            image.ImageUrl = ImageEdit;
                        else if (actionTaken.ToLower().ToString().StartsWith("assigned"))
                            image.ImageUrl = ImageAssign;
                    }
                }
            }
            catch 
            {
                rpActivity.DataSource = null;
                rpActivity.DataBind();
                lblMsg.Text = "no activity logs found";
            }
        }
        public void PopLogListForLast(int days)
        {
            try
            {
                PopLogList(SimpleServingsLibrary.Shared.Logger.GetLogsForLast(days));

                for (int i = 0; i < rpActivity.Items.Count; i++)
                {
                    Image image = ((Image)rpActivity.Items[i].FindControl("ImageItem"));
                    string actionTaken = ((Label)rpActivity.Items[i].FindControl("lblActionTaken")).Text;
                    if (actionTaken.ToLower().ToString().StartsWith("added") || actionTaken.ToLower().ToString().StartsWith("inserted") || actionTaken.ToLower().ToString().StartsWith("reinstated"))
                        image.ImageUrl = ImageAdd;
                    else if (actionTaken.ToLower().ToString().StartsWith("deleted") || actionTaken.ToLower().ToString().StartsWith("removed"))
                        image.ImageUrl = ImageDelete;
                    else if (actionTaken.ToLower().ToString().StartsWith("updated") || actionTaken.ToLower().ToString().StartsWith("edited") || actionTaken.ToLower().StartsWith("transferred") || actionTaken.ToLower().StartsWith("reassigned"))
                        image.ImageUrl = ImageEdit;
                    else if (actionTaken.ToLower().ToString().StartsWith("assigned"))
                        image.ImageUrl = ImageAssign;
                }
            }
            catch
            {
                rpActivity.DataSource = null;
                rpActivity.DataBind();
                lblMsg.Text = "no activity logs found";
            }
        }

        private void PopLogList(SimpleServingsLibrary.Shared.Loggers logs)
        {
            try
            {
                rpActivity.DataSource = logs;
                rpActivity.DataBind();
                lblMsg.Text = string.Format("{0} activity log(s) found", logs.Count);
            }
            catch 
            {
                rpActivity.DataSource = null;
                rpActivity.DataBind();
                lblMsg.Text = "no activity logs found";
            }
        }

        protected void rpActivity_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int createdBy = Convert.ToInt32(((Label)e.Item.FindControl("lblCreatedBy")).Text);
                string actionTaken = ((Label)e.Item.FindControl("lblActionTaken")).Text;
                int FairHearingID = Convert.ToInt32(((Label)e.Item.FindControl("lblFairHearingID")).Text);
                //int clientID = Convert.ToInt32(((Label)e.Item.FindControl("lblClientID")).Text);
                string createdOn = ((Label)e.Item.FindControl("lblCreatedOn")).Text;
            
                Label lbl = (Label)e.Item.FindControl("lblAction");

                if (FairHearingID != 0)
                {
                    lbl.Text = string.Format(@"{0} <b>{1}</b> for <b>{2}</b> on {3}",
                        SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(createdBy),
                        actionTaken,
                        "Case name goes here",
                        createdOn);
                }
                else
                {
                    lbl.Text = string.Format(@"{0} <b>{1}</b> on {2}",
                        SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(createdBy),
                        actionTaken,
                        createdOn);
                }
            }
        }

        protected void ddlLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopLogListByStaffIDAndLogsType(UserID,Convert.ToInt32(ddlStaffMember.SelectedValue), Convert.ToInt32(ddlLogType.SelectedValue));
        }

        protected void cbDate_CheckedChanged(object sender, EventArgs e)
        {
            PopLogListByStaffIDAndLogsType(UserID,Convert.ToInt32(ddlStaffMember.SelectedValue), Convert.ToInt32(ddlLogType.SelectedValue));
        }

        protected void ddlStaffMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopLogListByStaffIDAndLogsType(UserID,Convert.ToInt32(ddlStaffMember.SelectedValue), Convert.ToInt32(ddlLogType.SelectedValue));
        }
 
    }
}