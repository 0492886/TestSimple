using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.SupplierRelationship
{
    public class Person
    {
        private int _contactPersonID;
        public int ContactPersonID
        {
            get { return _contactPersonID; }
            set { _contactPersonID = value; }
        }
        
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _createdBy;
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        private string _createdOn;
        public string CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        private static Person PopContactPerson(SqlDataReader dr)
        {
            using (dr)
            {
                Person cp = new Person();

                if (dr.Read())
                {
                    cp.ContactPersonID = Convert.ToInt32(dr["ContactPersonID"]);
                    cp.FirstName = dr["FirstName"].ToString();
                    cp.LastName = dr["LastName"].ToString();
                    cp.Address = dr["Address"].ToString();
                    cp.Phone = dr["Phone"].ToString();
                    cp.Email = dr["Email"].ToString();
                    cp.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    cp.CreatedOn = dr["CreatedOn"].ToString();
                    cp.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return cp;
            }
        }

        private static PersonList PopContactPersons(SqlDataReader dr)
        {
            using (dr)
            {
                PersonList cps = new PersonList();

                while (dr.Read())
                {
                    Person cp = new Person();

                    cp.ContactPersonID = Convert.ToInt32(dr["ContactPersonID"]);
                    cp.FirstName = dr["FirstName"].ToString();
                    cp.LastName = dr["LastName"].ToString();
                    cp.Address = dr["Address"].ToString();
                    cp.Phone = dr["Phone"].ToString();
                    cp.Email = dr["Email"].ToString();
                    cp.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    cp.CreatedOn = dr["CreatedOn"].ToString();
                    cp.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    cps.Add(cp);
                }

                return cps;
            }
        }

        private static void ValidatePersonInfo(string phone, string email)
        {
            StringBuilder sb = new StringBuilder();

            if (phone.Trim() != string.Empty)
            {
                string result = Validation.ValidatePhoneNumber(phone, "Phone Number");
                if (result.Trim() != string.Empty)
                {
                    sb.AppendLine(result);
                }
            }

            if (email.Trim() != string.Empty)
            {
                string result = Validation.ValidateEmail(email, "Email");
                if (result.Trim() != string.Empty)
                {
                    sb.AppendLine(result);
                }
            }

            if (sb.ToString() != string.Empty)
            {
                throw new Exception(sb.ToString());
            }
        }

        public static int AddContactPerson(string firstName, string lastName, string address, string phone, string email, int createdBy)
        {
            ValidatePersonInfo(phone, email);
            return ContactPersonDB.AddContactPerson(firstName, lastName, address, phone, email, createdBy);
        }

        public static Person GetContactPersonByID(int contactPersonID)
        {
            return PopContactPerson(ContactPersonDB.GetContactPersonByID(contactPersonID));
        }

        public static void EditContactPersonByID(int contactPersonID, string firstName, string lastName, string address, string phone, string email)
        {
            ValidatePersonInfo(phone, email);
            ContactPersonDB.EditContactPersonByID(contactPersonID, firstName, lastName, address, phone, email);
        }

        public static void RemoveContactPersonByID(int contactPersonID)
        {
            ContactPersonDB.RemoveContactPersonByID(contactPersonID);
        }
    }

    public class PersonList : List<Person> { }
}
