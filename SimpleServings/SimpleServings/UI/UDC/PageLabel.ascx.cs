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

namespace SimpleServings.UI.UDC
{
    public partial class PageLabel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulatePageLabel();

            }

        }

        private void PopulatePageLabel()
        {
            if (Request["FairHearingID"] != null)
            {

                int FairHearingID = 0;
                Int32.TryParse(Request["FairHearingID"].ToString(), out FairHearingID);
                AddStaffNote1.InitializeControl(FairHearingID);
            }
        }
    }
}