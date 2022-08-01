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
    public partial class FacesActivityList : System.Web.UI.UserControl
    {
        private string ImageDelete = "~/UI/Imgs/ActivityIconSystem/ActivityRemove.gif";
        private string ImageAdd = "~/UI/Imgs/ActivityIconSystem/ActivityAdd.gif";
        private string ImageEdit = "~/UI/Imgs/ActivityIconSystem/ActivityEdit.gif";
        private string ImageAssign = "~/UI/Imgs/ActivityIconSystem/ActivityAssign.gif";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["StaffAll"] = Session["StaffID"];               
            }
        }
        private void PopLogsType(int staffID, int logsType)
        {
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroup(ddlLogType,
                  SimpleServingsLibrary.Shared.Code.CodeTypes.Module, staffID, logsType.ToString());
            try
            {
                ddlStaffMember.DataSource = SimpleServingsLibrary.Shared.Staff.GetStaffsByManagedBy(Session["StaffAll"].ToString());
                ddlStaffMember.DataTextField = "FullName";
                ddlStaffMember.DataValueField = "StaffID";
                ddlStaffMember.DataBind();
                ddlStaffMember.Items.Insert(0, new ListItem("All", "0"));
                try
                {
                    if (staffID != 0)
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
        //public void PopLogListByStaffID(int staffID)
        //{
        //    Session["StaffID"] = staffID;
        //    try
        //    {
        //        PopLogList(Faces.Shared.Logger.GetLogsByStaffID(staffID));

        //    }
        //    catch
        //    {
        //        rpActivity.DataSource = null;
        //        rpActivity.DataBind();
        //        lblMsg.Text = "no logs found";
        //    }
        //}

        public void PopLogListByStaffIDAndLogsTypeAndCaseID(int staffID, int logsType, int caseID)
        {

            Session["StaffID"] = staffID;
            Session["LogCaseID"] = caseID;
            if (Session["StaffAll"] == null)
                Session["StaffAll"] = Session["StaffID"];  
            PopLogsType(staffID, logsType);

            try
            {
                if (!cbDate.Checked)
                {
                    PopLogList(SimpleServingsLibrary.Shared.Logger.GetLogsByStaffIDAndLogsTypeAndCaseID(staffID, logsType, caseID));
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
                    PopLogList(SimpleServingsLibrary.Shared.Logger.GetTodaysLogsByStaffIDAndLogsTypeAndCaseID(staffID, logsType, caseID));
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
        public void PopLogListForLastAndCaseID(int days, int caseID)
        {
            try
            {
                PopLogList(SimpleServingsLibrary.Shared.Logger.GetLogsForLastAndCaseID(days, caseID));
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
                lblMsg.Text = string.Format("{0} activity logs found", logs.Count);
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
                int caseID = Convert.ToInt32(((Label)e.Item.FindControl("lblCaseID")).Text);
                int clientID = Convert.ToInt32(((Label)e.Item.FindControl("lblClientID")).Text);
                string createdOn = ((Label)e.Item.FindControl("lblCreatedOn")).Text;

                Label lbl = (Label)e.Item.FindControl("lblAction");
                if (caseID != 0)
                {
                    lbl.Text = string.Format(@"{0} <b>{1}</b> for <b>{2}</b> on {3}",
                        SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(createdBy),
                        actionTaken,
"",                        createdOn);
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
            PopLogListByStaffIDAndLogsTypeAndCaseID(Convert.ToInt32(Session["StaffID"]), Convert.ToInt32(ddlLogType.SelectedValue), Convert.ToInt32(Session["LogCaseID"]));
        }

        protected void cbDate_CheckedChanged(object sender, EventArgs e)
        {
            PopLogListByStaffIDAndLogsTypeAndCaseID(Convert.ToInt32(Session["StaffID"]), Convert.ToInt32(ddlLogType.SelectedValue), Convert.ToInt32(Session["LogCaseID"]));
        }

        protected void ddlStaffMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStaffMember.SelectedValue.ToString() != "0" && ddlStaffMember.SelectedValue.ToString() != null
                && ddlStaffMember.SelectedValue.ToString() != "")
                PopLogListByStaffIDAndLogsTypeAndCaseID(Convert.ToInt32(ddlStaffMember.SelectedValue.ToString()), Convert.ToInt32(ddlLogType.SelectedValue), Convert.ToInt32(Session["LogCaseID"]));
            else
                PopLogListByStaffIDAndLogsTypeAndCaseID(Convert.ToInt32(Session["StaffAll"]), Convert.ToInt32(ddlLogType.SelectedValue),Convert.ToInt32(Session["LogCaseID"]));
        }

    }
}