using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SimpleServingsLibrary.Shared;

namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class AddEditStaff : System.Web.UI.UserControl
    {
        public bool IsUsedInWizard
        {
            get { return btnAdd.Visible; }
            set { btnAdd.Visible = !value; }
        }
       
        //public int SiteCode
        //{
        //    get { return Convert.ToInt32(this.ddlSiteCode.SelectedValue); }
        //}
        public int State
        {
            get { return Convert.ToInt32(this.ddState.SelectedValue); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(!IsUsedInWizard)
                   InitiateControl();
               //try
               //{
               //    PopManagedBySite(Convert.ToInt32(ddlSiteCode.SelectedValue), Convert.ToInt32(ddlManagedBy.SelectedValue));
               //}
               //catch { }
            }
       }
        


        public void PopStaffByID(int staffID)
        {
            SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);
            //Session["SiteCode"] = staff.SiteCode; 
            PopDropDowns();
            this.SetValuesForControls(staff);
        }
        private void InitiateControl()
        {
            PopDropDowns();
            
            
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsUsedInWizard)   //string.IsNullOrEmpty(lblStaffID.Text))
            {
                if (AddStaff() != 0)
                {
                    if (Request["MyProfile"] == "MyProfile")
                    {
                        Response.Redirect("~/UI/Page/MyZone.aspx?Control=MyProfile&StaffID=" + Convert.ToInt32(lblStaffID.Text));
                    }
                    else
                    {
                        Response.Redirect("~/UI/Page/MyZone.aspx?Control=ViewStaff&StaffID=" + Convert.ToInt32(lblStaffID.Text));
                    }
                }
            }
            else
            {
                //if (UpdateStaff(Convert.ToInt32(lblStaffID.Text), ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID) != 0)
                if (UpdateStaff(Convert.ToInt32(lblStaffID.Text), HelpClasses.AppHelper.GetCurrentUser().StaffID) != 0)
                {
                    if (Request["MyProfile"] == "MyProfile")
                    {
                        Response.Redirect("~/UI/Page/MyZone.aspx?Control=MyProfile&StaffID=" + Convert.ToInt32(lblStaffID.Text));
                    }
                    else
                    {
                        Response.Redirect("~/UI/Page/MyZone.aspx?Control=ViewStaff&StaffID=" + Convert.ToInt32(lblStaffID.Text));
                    }
                }
            }

            

        }


        public int AddStaff()
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                GetValuesFromControls(ref staff);
                int staffID = staff.AddStaff();
                //SaveFieldDays(staffID, Convert.ToInt32(staff.CreatedBy));
                return staffID;
            }
            catch (Exception ex)
            {
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Text = ex.Message;
                lblSummary.Visible = true;
                return 0;
            }
        }

        public int UpdateStaff(int staffID, int createdBy)
        {
            try
            {
                lblSummary.Visible = false;
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff(staffID);

                
                    GetValuesFromControls(ref staff);
                    staff.EditStaff();
                    //SaveFieldDays(staffID, createdBy);
                    return staffID;
                
            }
            catch (Exception ex)
            {
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Text = ex.Message;
                lblSummary.Visible = true;
                return 0;
            }
        }
        public int AddStaff(string userName, string password, string email, int theme, int caseload, int userGroupID,int state)
        {
            try
            {
                SimpleServingsLibrary.Shared.Staff staff = new SimpleServingsLibrary.Shared.Staff();
                GetValuesFromControls(ref staff);
                staff.UserName = userName;
                staff.Password = password;
                staff.Email = email;
                
                //staff.CaseLoad = caseload;
                staff.UserGroup = userGroupID;
                staff.State = state;
                int staffID = staff.AddStaff();
                
                return staffID;

            }
            catch (Exception ex)
            {
                lblSummary.ForeColor = System.Drawing.Color.Red;
                lblSummary.Text = ex.Message;
                lblSummary.Visible = true;
                return 0;
            }
        }


       
        private void GetValuesFromControls(ref SimpleServingsLibrary.Shared.Staff staff)
        {
            
            staff.FirstName = Convert.ToString(txtFirstName.Text);
            staff.LastName = Convert.ToString(txtLastName.Text);
            staff.HomePhone = Convert.ToString(txtHomePhone.Text);
            staff.WorkPhone = Convert.ToString(txtWorkPhone.Text);
            staff.StreetAddress1 = Convert.ToString(txtStAddress1.Text);
            staff.StreetAddress2 = Convert.ToString(txtStAddress2.Text);

            staff.City = txtCity.Text;
            staff.ZipCode = Convert.ToString(txtZipCode.Text);
            //staff.SiteCode = Convert.ToInt32(ddlSiteCode.SelectedValue);
            staff.Fax = Convert.ToString(txtFax.Text);
            try
            {
                staff.ManagedBy = Convert.ToInt32(ddlManagedBy.SelectedValue);
            }
            catch { }
            staff.CreatedBy = HelpClasses.AppHelper.GetCurrentUser().StaffID; //((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).StaffID;
            staff.State = Convert.ToInt32(ddState.SelectedValue);
          

        }

       
        private void SetValuesForControls(SimpleServingsLibrary.Shared.Staff staff)
        {
            txtFirstName.Text=staff.FirstName ;
            txtLastName.Text=staff.LastName;
            txtHomePhone.Text = staff.HomePhone;
            txtWorkPhone.Text = staff.WorkPhone;
            txtStAddress1.Text=staff.StreetAddress1;
            txtStAddress2.Text=staff.StreetAddress2;
            txtCity.Text = staff.City;
            txtZipCode.Text=staff.ZipCode ;
            txtFax.Text = staff.Fax;
            lblStaffID.Text = staff.StaffID.ToString();
            
            try
            {
                (this.ddState.Items.FindByText(staff.StateText.ToString())).Selected = true;
            }
            catch { }
            
            
                
                try
                {
                    this.ddlManagedBy.Items.FindByValue(staff.ManagedBy.ToString()).Selected = true;
                }
                catch { }
            
           

            
            //lblCreatedBy.Text = SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(staff.CreatedBy); 
        }


        private void PopDropDowns()
        {
         
            PopManagedBy();
            SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddState, Code.CodeTypes.State, HelpClasses.AppHelper.GetCurrentUser().UserGroup, "");
            //SimpleServingsLibrary.Shared.Utility.GetCodesByTypeAndUserGroupSelect(ddState, Code.CodeTypes.State, ((SimpleServingsLibrary.Shared.Staff)Session["UserObject"]).UserGroup, "");
            
        }
        private void PopManagedBy()
        {
            try
            {
                ddlManagedBy.DataSource = SimpleServingsLibrary.Shared.Staff.GetStaffByUserGroup(SimpleServingsLibrary.Shared.UserGroup.DFTASUP);
                ddlManagedBy.DataTextField = "FullName";
                ddlManagedBy.DataValueField = "StaffID";
                ddlManagedBy.DataBind();
                ddlManagedBy.Items.Insert(0, new ListItem("[Select]", "0"));
            }
            catch 
            {
                ddlManagedBy.DataSource = null;
                ddlManagedBy.DataBind();
                ddlManagedBy.Items.Insert(0, new ListItem("[Select]", "0"));
            }

        }
       
       

        

        
    }
}