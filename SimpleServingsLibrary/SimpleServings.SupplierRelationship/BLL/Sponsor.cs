using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;
using System.Data;

namespace SimpleServingsLibrary.SupplierRelationship
{
    public class Sponsor
    {
        private int _sponsorID;
        public int SponsorID
        {
            get { return _sponsorID; }
            set { _sponsorID = value; }
        }
        
        private string _sponsorName;
        public string SponsorName
        {
            get { return _sponsorName; }
            set { _sponsorName = value; }
        }
        
        private string _sponsorAddress;
        public string SponsorAddress
        {
            get { return _sponsorAddress; }
            set { _sponsorAddress = value; }
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

        public Sponsor()
        {
            _contactPerson = new Person();
        }

        private static Sponsor PopSponsor(SqlDataReader dr)
        {
            using (dr)
            {
                Sponsor s = new Sponsor();

                if (dr.Read())
                {
                    s.SponsorID = Convert.ToInt32(dr["SponsorID"]);
                    s.SponsorName = dr["SponsorName"].ToString();
                    s.SponsorAddress = dr["SponsorAddress"].ToString();
                    s.ContactPersonID = Convert.ToInt32(dr["ContactPersonID"]);
                    s.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    s.CreatedOn = dr["CreatedOn"].ToString();
                    s.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return s;
            }
        }

        private static Sponsors PopSponsors(SqlDataReader dr)
        {
            using (dr)
            {
                Sponsors ss = new Sponsors();

                while (dr.Read())
                {
                    Sponsor s = new Sponsor();

                    s.SponsorID = Convert.ToInt32(dr["SponsorID"]);
                    s.SponsorName = dr["SponsorName"].ToString();
                    s.SponsorAddress = dr["SponsorAddress"].ToString();
                    s.ContactPersonID = Convert.ToInt32(dr["ContactPersonID"]);
                    s.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    s.CreatedOn = dr["CreatedOn"].ToString();
                    s.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    ss.Add(s);
                }

                return ss;
            }
        }

        public static int AddSponsor(string sponsorName, string sponsorAddress, int contactPersonID, int createdBy)
        {
            return SponsorDB.AddSponsor(sponsorName, sponsorAddress, contactPersonID, createdBy);
        }

        public static int AddSponsorTemp(string sponsorName, string sponsorAddress, int contactPersonID, int createdBy, string phoneNumber, string sponsorCode)
        {
            return SponsorDB.AddSponsorTemp(sponsorName, sponsorAddress, contactPersonID, createdBy, phoneNumber, sponsorCode);
        }

        public static void EditSponsorByID(int sponsorID, string sponsorName, string sponsorAddress, int contactPersonID)
        {
            SponsorDB.EditSponsorByID(sponsorID, sponsorName, sponsorAddress, contactPersonID);
        }

        public static void RemoveSponsorByID(int sponsorID)
        {
            SponsorDB.RemoveSponsorByID(sponsorID);
        }

        public static Sponsors GetSponsorAll()
        {
            return PopSponsors(SponsorDB.GetSponsorAll());
        }

        public static Sponsor GetSponsorByID(int sponsorID)
        {
            return PopSponsor(SponsorDB.GetSponsorByID(sponsorID));
        }

        //--Auto Update Sponsor by importing excel file
        public static void AutoEditSponsor(int createdBy, DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                int sponsorID = Convert.ToInt32(row["SponsorID"]);
                string sponsorName = row["SponsorName"].ToString();
                string sponsorAddress = row["SponsorAddress"].ToString();
                int contactPersonID = Convert.ToInt32(row["ContactPersonID"]);

                SponsorDB.AutoEditSponsorByID(sponsorID, sponsorName, sponsorAddress, contactPersonID, createdBy);
            }
        }

    }

    public class Sponsors : List<Sponsor> { }
}
