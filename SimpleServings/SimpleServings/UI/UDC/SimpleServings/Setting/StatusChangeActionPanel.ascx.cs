using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class StatusChangeActionPanel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Initialization(int keyID, SimpleServingsLibrary.Shared.Code.CodeTypes codeType)
        {            
            lblKeyID.Text = keyID.ToString();
            PopStatusList(keyID, codeType);
        }

        private void PopStatusList(int keyID, SimpleServingsLibrary.Shared.Code.CodeTypes codeType)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            try {                                
                SimpleServingsLibrary.Shared.Codes codes = SimpleServingsLibrary.Shared.Code.GetCodesByTypeAndUserGroup(codeType, staff.UserGroup);
                SimpleServingsLibrary.Shared.Codes ShortCodeList = GetShortCodelist(codes);
                dlStatusList.DataSource = ShortCodeList;
                dlStatusList.DataBind();
            }
            catch {
                dlStatusList.DataSource = null;
                dlStatusList.DataBind();
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No Records(s) found.";
            }
        }

        private SimpleServingsLibrary.Shared.Codes GetShortCodelist(SimpleServingsLibrary.Shared.Codes codes)
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"] ?? HelpClasses.AppHelper.GetCurrentUser();
            if (staff == null) Response.Redirect("~/UI/Page/landingPage.aspx?type=LogInOut"); 
            //Response.Redirect("~/UI/Page/login.aspx");
            SimpleServingsLibrary.Shared.Codes shortCodes = new SimpleServingsLibrary.Shared.Codes();            
            foreach (SimpleServingsLibrary.Shared.Code code in codes)
            {
                string msg = "";
                if (SimpleServingsLibrary.Shared.Rule.SatisfyRules(code.CodeID, Convert.ToInt32(lblKeyID.Text), staff.StaffID, ref msg,code.CodeID))
                    shortCodes.Add(code);   
            }
            return shortCodes;
        }

        
        protected void dlStatusList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            int codeID = Convert.ToInt32(((Label)e.Item.FindControl("lblStatusID")).Text);
            string url = string.Format("~/UI/Page/SimpleServings/Setting/StatusChangeSubmission.aspx?KeyID={0}&StatusID={1}",Convert.ToInt32(lblKeyID.Text),codeID);
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
                System.Web.UI.WebControls.HyperLink hlstatus =(System.Web.UI.WebControls.HyperLink)e.Item.FindControl("hlStatus");
                hlstatus.NavigateUrl = url;
            }
        }        
    }
}