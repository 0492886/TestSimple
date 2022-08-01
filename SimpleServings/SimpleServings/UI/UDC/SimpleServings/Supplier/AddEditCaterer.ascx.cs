using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.SupplierRelationship;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Supplier
{
    public partial class AddEditCaterer : System.Web.UI.UserControl
    {
        private int CreatedBy
        {
            get { return ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).StaffID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyPermissions();
                if (Request["CatererID"] != null && Request["CatererID"].ToString() != string.Empty)
                {
                    PopCaterer(Convert.ToInt32(Request["CatererID"]));
                }
                else
                {
                    PopCaterer(0);
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
            if (!SimpleServingsLibrary.Shared.Utility.IsAllowedOperation(GlobalEnum.ProviderModule, staff.StaffID, Convert.ToInt32(staff.UserGroup), ModulePermission.ModuleCheckType.Edit))
            {
                divContent.Visible = false;
                throw new ApplicationException("You are not allowed to access this page");
            }
        }

        public void PopCaterer(int catererID)
        {
            if (catererID != 0)
            {
                Caterer s = Caterer.GetCatererByID(catererID);
                PopCaterer(s);
            }
            else
            {
                lblCatererID.Text = catererID.ToString();
            }
        }

        private void PopCaterer(Caterer s)
        {
            txtCatererName.Text = s.CatererName;
            txtCatererAddress.Text = s.CatererAddress;
            lblCatererID.Text = s.CatererID.ToString();
            ctrlContactPerson.PopContactPerson(s.ContactPerson);
        }

        public void SaveCaterer()
        {
            int contactPersonID = 0;
            if (ctrlContactPerson.HasItems())
            {
                contactPersonID = ctrlContactPerson.SaveContactPerson();
            }

            int catererID = Convert.ToInt32(lblCatererID.Text.Trim());
            string CatererName = txtCatererName.Text.Trim();
            string CatererAddress = txtCatererAddress.Text.Trim();

            if (catererID > 0)
            {
                Caterer.EditCatererByID(catererID, CatererName, CatererAddress, contactPersonID);
            }
            else
            {
                catererID = Caterer.AddCaterer(CatererName, CatererAddress, contactPersonID, CreatedBy);
            }

            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Caterer.aspx?Action=View&CatererID={0}", catererID));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCatererName.Text.Trim() != string.Empty)
            {
                try
                {
                    SaveCaterer();

                }
                catch (Exception ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = string.Format(ex.Message);
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = string.Format("Caterer name is required");
            }
        }

        protected void lnkBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/UI/Page/SimpleServings/Supplier/Caterer.aspx?Action=List"));
        }
    }
}