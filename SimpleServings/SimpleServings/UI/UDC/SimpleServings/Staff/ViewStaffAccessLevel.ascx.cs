using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class ViewStaffAccessLevel : System.Web.UI.UserControl
    {
       

       

        public void InitializeControl(int staffID)
        {
            try
            {
                lblStaffID.Text = staffID.ToString();
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
                
                SimpleServingsLibrary.Shared.UserGroup group = new SimpleServingsLibrary.Shared.UserGroup(staff.UserGroup);
                int accessLevel = group.AccessLevel;
                lblGroupAccessLevelText.Text = group.AccessLevelText;
                if (accessLevel == GlobalEnum.AccessLevel_Sponsor)
                {
                    pnSponsor.Visible = true;
                    pnCaterer.Visible = false;
                    pnContract.Visible = false;
                    SimpleServingsLibrary.SupplierRelationship.Sponsor sp =
                        SimpleServingsLibrary.SupplierRelationship.Sponsor.GetSponsorByID(staff.SupplierID);
                    lblSponsor.Text=sp.SponsorName.ToString(); 
                   
                }
                else if (accessLevel == GlobalEnum.AccessLevel_Contract || accessLevel == GlobalEnum.AccessLevel_CateringContract)
                {
                    pnSponsor.Visible = true;
                    pnCaterer.Visible = false;
                    pnContract.Visible = true;
                    SimpleServingsLibrary.SupplierRelationship.Sponsor sp =
                       SimpleServingsLibrary.SupplierRelationship.Sponsor.GetSponsorByID(staff.SupplierID);
                    lblSponsor.Text = sp.SponsorName; 
                   
                }
                else if (accessLevel == GlobalEnum.AccessLevel_Caterer)
                {
                    pnSponsor.Visible = false;
                    pnCaterer.Visible = true;
                    pnContract.Visible = true;
                    SimpleServingsLibrary.SupplierRelationship.Caterer caterer =
                       SimpleServingsLibrary.SupplierRelationship.Caterer.GetCatererByID(staff.SupplierID);
                    lblCaterer.Text = caterer.CatererName;
                }
               


                else
                {
                    pnSponsor.Visible = false;
                    pnCaterer.Visible = false;
                    pnContract.Visible = false;
                    
                }
                PopContractGrid(staffID);
            }
            catch { }
        }

        private void PopContractGrid(int staffID)
        {
            try
            {
                SimpleServingsLibrary.Shared.StaffContracts sc = SimpleServingsLibrary.Shared.StaffContract.GetStaffContractsByStaffID(staffID);
                gvContract.DataSource = sc;
                gvContract.DataBind();
                
            }
            catch
            {
                gvContract.DataSource = null;
                gvContract.DataBind();
            }
        }
        

       
    }
}