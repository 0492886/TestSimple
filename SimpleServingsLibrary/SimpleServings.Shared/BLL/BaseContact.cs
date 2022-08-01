using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleServingsLibrary.Shared
{
    [Serializable]
    public abstract class BaseContact
    {
        #region Private Fields

        private int contactID;
        private string contactName;
        private bool isActive;
        private string streetAddress;
        private string aptNumber;
        private string city;
        private int state;
        private string zipCode;
        private string phone1;
        private string phone2;
        private string fax;
        private string email;
        private string webSiteURL;
      
        private string createdOn;
        private int createdBy;
        private int removedBy;
        private string removedOn;

      
        private string endDate;
       


        #endregion

        #region Public Properties

        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }
       
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public string IsActiveText
        {
            get
            {
                if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "true")
                    return "Yes";
                else if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "false")
                    return "No";
                else
                    return isActive.ToString();
            }
        }
       
        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }
        public string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }
        public string AptNumber
        {
            get { return aptNumber; }
            set { aptNumber = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        public string StateText
        {
            get { return Code.DecodeCode(State); }
        }
        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
        public string FullAddress
        {
            get { return StreetAddress + " " + ((AptNumber == "") ? "" : AptNumber + ", ") + "<br>" + City + " " + StateText + " " + ZipCode; }
        }
        public string PartAddress
        {
            get { return City + ", " + StateText + " " + ZipCode; }
        }
        public string Phone1
        {
            get
            {
                try
                {
                    string phone = Regex.Replace(phone1, "\\D", "");
                    if (phone.Length > 10)
                        return string.Format("({0}) {1}-{2}x{3}",
                              phone.Substring(0, 3),
                              phone.Substring(3, 3),
                              phone.Substring(6, 4),
                              phone.Substring(10));
                    else
                        return string.Format("({0}) {1}-{2}",
                         phone.Substring(0, 3),
                         phone.Substring(3, 3),
                         phone.Substring(6));

                }
                catch { return phone1; }
            }
            set { phone1 = value; }
        }
        public string Phone2
        {
            get
            {
                try
                {
                    string phone = Regex.Replace(phone2, "\\D", "");
                    if (phone.Length > 10)
                        return string.Format("({0}) {1}-{2}x{3}",
                              phone.Substring(0, 3),
                              phone.Substring(3, 3),
                              phone.Substring(6, 4),
                              phone.Substring(10));
                    else
                        return string.Format("({0}) {1}-{2}",
                         phone.Substring(0, 3),
                         phone.Substring(3, 3),
                         phone.Substring(6));
                }
                catch { return phone2; }
            }
            set { phone2 = value; }
        }
        public string Fax
        {
            get
            {
                try
                {
                    string fax1 = Regex.Replace(fax, "\\D", "");

                    return string.Format("({0}) {1}-{2}",
                          fax1.Substring(0, 3),
                          fax1.Substring(3, 3),
                          fax1.Substring(6));
                }
                catch { return fax; }
            }
            set { fax = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string WebSiteURL
        {
            get { return webSiteURL; }
            set { webSiteURL = value; }
        }
        
        public string CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        public string CreatedByText
        {
            get { return Staff.GetStaffNameByStaffID(CreatedBy); }
        }

        public int RemovedBy
        {
            get { return removedBy; }
            set { removedBy = value; }
        }
        public string RemovedOn
        {
            get { return removedOn; }
            set { removedOn = value; }
        }
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        #endregion


    }
}
