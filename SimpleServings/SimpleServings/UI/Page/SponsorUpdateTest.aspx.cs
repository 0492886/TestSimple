using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.SupplierRelationship;
using System.Data;
using System.IO;

namespace SimpleServings.UI.Page
{
    public partial class SponsorUpdateTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (fileUplaod.HasFile)
            {
                SimpleServingsLibrary.SupplierRelationship.Utility.ExcelHelper helper = new SimpleServingsLibrary.SupplierRelationship.Utility.ExcelHelper();

                if (helper.IsExcelFile(fileUplaod.PostedFile.FileName))
                {
                    string destFilePath = string.Empty;
                    
                    try
                    {
                        destFilePath = Server.MapPath("~/UI/Upload/") + Guid.NewGuid() + Path.GetExtension(fileUplaod.FileName);
                        //File.Copy(fileUplaod.PostedFile.FileName, destFilePath);
                        lock (destFilePath)
                        {
                            fileUplaod.SaveAs(destFilePath);
                        }
                        DataTable dt = helper.GetDataTable(destFilePath, "Sponsor");
                        //SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
                        Sponsor.AutoEditSponsor(3, dt);
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = ex.Message;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                    finally
                    {
                        File.Delete(destFilePath);
                    }
                }
            }
        }
    }
}