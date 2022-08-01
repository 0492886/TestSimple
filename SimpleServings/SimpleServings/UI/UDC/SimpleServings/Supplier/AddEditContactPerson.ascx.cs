using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.SupplierRelationship;

namespace SimpleServings.UI.UDC.SimpleServings.Supplier
{
    public partial class AddEditContactPerson : System.Web.UI.UserControl
    {
        private int CreatedBy
        {
            get { return ((SimpleServingsLibrary.Shared.Staff)(Session["UserObject"])).StaffID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopContactPerson(int contactPersonID)
        {
            if (contactPersonID != 0)
            {
                Person p = Person.GetContactPersonByID(contactPersonID);
                PopContactPerson(p);
            }
        }

        public void PopContactPerson(Person p)
        {
            lblPersonID.Text = p.ContactPersonID.ToString();
            txtFirstName.Text = p.FirstName;
            txtLastName.Text = p.LastName;
            txtAddress.Text = p.Address;
            txtPhone.Text = p.Phone;
            txtEmail.Text = p.Email;
        }

        public int SaveContactPerson()
        {
            int contactPersonID = 0;
            if(lblPersonID.Text.Trim() != string.Empty)
            {
                contactPersonID = Convert.ToInt32(lblPersonID.Text.Trim());
            }
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (contactPersonID > 0)
            {
                Person.EditContactPersonByID(contactPersonID, firstName, lastName, address, phone, email);
                return contactPersonID;
            }
            else
            {
                return Person.AddContactPerson(firstName, lastName, address, phone, email, CreatedBy);
            }
        }

        public bool HasItems()
        {
            if (txtFirstName.Text.Trim() != string.Empty
                || txtLastName.Text.Trim() != string.Empty
                || txtAddress.Text.Trim() != string.Empty
                || txtPhone.Text.Trim() != string.Empty
                || txtEmail.Text.Trim() != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}