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

namespace SimpleServings.UI.UDC.SimpleServings.Setting
{
    public partial class ReorderCodeValue : System.Web.UI.UserControl
    {
        public string CodeType
        {
            get { return lblCodeType.Text; }
            set { lblCodeType.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SimpleServingsLibrary.Shared.Code.CodeTypes codeType = (SimpleServingsLibrary.Shared.Code.CodeTypes)SimpleServingsLibrary.Shared.Code.DecodeCodeTpe(typeof(SimpleServingsLibrary.Shared.Code.CodeTypes), CodeType);
                PopReorderCodeValue(codeType);
            }
            catch { }
        }

        public void PopReorderCodeValue(SimpleServingsLibrary.Shared.Code.CodeTypes codeType)
        {
            SimpleServingsLibrary.Shared.Codes codes = new SimpleServingsLibrary.Shared.Codes();
            if (GetCachedReorderList() == null)
            {
                codes = SimpleServingsLibrary.Shared.Code.GetCodesByType(codeType);
            }
            else 
            {
                codes = GetCachedReorderList();    
            }

            reorderListAjax.DataSource = codes;
            reorderListAjax.DataBind();
        }

        public void ClearReorderList()
        {
            reorderListAjax.DataSource = null;
            reorderListAjax.DataBind();
        }

        protected void reorderListAjax_ItemReorder(object sender, AjaxControlToolkit.ReorderListItemReorderEventArgs e)
        {
            SimpleServingsLibrary.Shared.Codes codes = (SimpleServingsLibrary.Shared.Codes)reorderListAjax.DataSource;
            Session["CodeDescription"] = codes;
        }

        private SimpleServingsLibrary.Shared.Codes GetCachedReorderList()
        {
            return (SimpleServingsLibrary.Shared.Codes)Session["CodeDescription"];
        }
    }
}