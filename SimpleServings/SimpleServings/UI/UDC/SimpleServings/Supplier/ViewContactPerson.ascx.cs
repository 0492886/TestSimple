using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleServingsLibrary.SupplierRelationship;

namespace SimpleServings.UI.UDC.SimpleServings.Supplier
{
    public partial class ViewContactPerson : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PopContactPerson(int contactPersonID)
        {
            Person p = Person.GetContactPersonByID(contactPersonID);
            PopContactPerson(p);
        }

        private void PopContactPerson(Person p)
        {
            lblPersonID.Text = p.ContactPersonID.ToString();
            lblFirstName.Text = p.FirstName;
            lblLastName.Text = p.LastName;
            lblAddress.Text = p.Address;
            lblPhone.Text = p.Phone;
            lblEmail.Text = p.Email;
        }

    }
}