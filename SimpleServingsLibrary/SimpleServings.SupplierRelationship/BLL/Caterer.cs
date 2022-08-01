using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.SupplierRelationship
{
    public class Caterer
    {
        private int _catererID;
        public int CatererID
        {
            get { return _catererID; }
            set { _catererID = value; }
        }

        private int _contractID;
        public int ContractID
        {
            get { return _contractID; }
            set { _contractID = value; }
        }

        private string _catererName;
        public string CatererName
        {
            get { return _catererName; }
            set { _catererName = value; }
        }
        
        private string _catererAddress;
        public string CatererAddress
        {
            get { return _catererAddress; }
            set { _catererAddress = value; }
        }
        
        private int _contactPersonID;
        public int ContactPersonID
        {
            get { return _contactPersonID; }
            set { _contactPersonID = value; }
        }

        private int _createdBy;
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        public string CreatedByText
        {
            get { return Staff.GetStaffNameByStaffID(CreatedBy); }
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

        private Person _contactPerson;
        public Person ContactPerson
        {
            get
            {
                if (_contactPerson.ContactPersonID != this.ContactPersonID)
                {
                    _contactPerson = Person.GetContactPersonByID(this.ContactPersonID);
                }

                return _contactPerson;
            }
            set { _contactPerson = value; }
        }

        public Caterer()
        {
            _contactPerson = new Person();
        }

        public Caterer(int catererID)
        {
            _contactPerson = new Person();
            _catererID = catererID;
        }

        private static Caterer PopCaterer(SqlDataReader dr)
        {
            using (dr)
            {
                Caterer c = new Caterer();

                if (dr.Read())
                {
                    c.CatererID = Convert.ToInt32(dr["CatererID"]);
                    c.CatererName = dr["CatererName"].ToString();
                    c.CatererAddress = dr["CatererAddress"].ToString();
                    c.ContactPersonID = Convert.ToInt32(dr["ContactPersonID"]);
                    c.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    c.CreatedOn = dr["CreatedOn"].ToString();
                    c.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return c;
            }
        }

        private static Caterers PopCaterers(SqlDataReader dr)
        {
            using (dr)
            {
                Caterers cs = new Caterers();

                while (dr.Read())
                {
                    Caterer c = new Caterer();

                    c.CatererID = Convert.ToInt32(dr["CatererID"]);
                    c.CatererName = dr["CatererName"].ToString();
                    c.CatererAddress = dr["CatererAddress"].ToString();
                    c.ContactPersonID = Convert.ToInt32(dr["ContactPersonID"]);
                    c.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    c.CreatedOn = dr["CreatedOn"].ToString();
                    c.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    cs.Add(c);
                }

                return cs;
            }
        }

        public static int AddCaterer(string catererName, string catererAddress, int contactPersonID, int createdBy)
        {
            return CatererDB.AddCaterer(catererName, catererAddress, contactPersonID, createdBy);    
        }

        public static Caterers GetCatererByContractID(int contractID)
        {
            return PopCaterers(CatererDB.GetCatererByContractID(contractID));
        }

        public static Caterers GetCatererAll()
        {
            return PopCaterers(CatererDB.GetCatererAll());
        }

        public static Caterer GetCatererByID(int catererID)
        {
            return PopCaterer(CatererDB.GetCatererByID(catererID));
        }

        public static void EditCatererByID(int catererID, string catererName, string catererAddress, int contactPersonID)
        {
            CatererDB.EditCatererByID(catererID, catererName, catererAddress, contactPersonID);
        }

        public static void RemoveCatererByID(int catererID)
        {
            CatererDB.RemoveCatererByID(catererID);
        }
    }

    public class Caterers : List<Caterer> {}
}
