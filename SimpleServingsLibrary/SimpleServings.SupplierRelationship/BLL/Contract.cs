using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.SupplierRelationship
{
    public class Contract
    {
        private int _contractID;
        public int ContractID
        {
            get { return _contractID; }
            set { _contractID = value; }
        }
        
        private string _contractName;
        public string ContractName
        {
            get { return _contractName; }
            set { _contractName = value; }
        }
        
        private string _contractNumber;
        public string ContractNumber
        {
            get { return _contractNumber; }
            set { _contractNumber = value; }
        }
        
        private int _contractType;
        public int ContractType
        {
            get { return _contractType; }
            set { _contractType = value; }
        }

        private int _dietTypeId;
        public int DietTypeID
        {
            get { return _dietTypeId; }
            set { _dietTypeId = value; }
        }


        public string ContractTypeName
        {
            get { return Code.DecodeCode(ContractType); }
        }

        private int _sponsorID;
        public int SponsorID
        {
            get { return _sponsorID; }
            set { _sponsorID = value; }
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

        private int _assignedTo;
        public int AssignedTo
        {
            get { return _assignedTo; }
            set { _assignedTo = value; }
        }

        public string AssignedToText
        {
            get { return Staff.GetStaffNameByStaffID(AssignedTo); }
        }

        public string SponsorName
        {
            get 
            {
                Sponsor s = Sponsor.GetSponsorByID(SponsorID);
                return s.SponsorName;
            }
        }

        private Caterers _catererList = null;
        public Caterers CatererList
        {
            get 
            {
                if (_catererList == null)
                {
                    _catererList = Caterer.GetCatererByContractID(this.ContractID);
                }
                return _catererList;
            }
            set { _catererList = value; }
        }

        private Meals _mealServedList = null;
        public Meals MealServedList
        {
            get
            {
                if (_mealServedList == null)
                {
                    _mealServedList = Meal.GetMealByContractID(this.ContractID);
                }
                return _mealServedList;
            }
            set { _mealServedList = value; }
        }

        private DietTypes _dietTypesList;
        public DietTypes DietTypesList
        {
            get
            {
                _dietTypesList = DietType.GetDietTypesByContractID(this.ContractID);
                return _dietTypesList;
            }

            set 
            {
                _dietTypesList = value;
            }
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

        public Contract()
        {
            _contactPerson = new Person();
        }

        private static Contract PopContract(SqlDataReader dr)
        {
            using (dr)
            {
                Contract c = new Contract();

                if (dr.Read())
                {
                    c.ContractID = Convert.ToInt32(dr["ContractID"]);
                    c.ContractName = dr["ContractName"].ToString();
                    c.ContractNumber = dr["ContractNumber"].ToString();
                    c.ContractType = Convert.ToInt32(dr["ContractType"]);
                    c.SponsorID = Convert.ToInt32(dr["SponsorID"]);
                    c.SponsorAddress = dr["SponsorAddress"].ToString();
                    c.ContactPersonID = Convert.ToInt32(dr["ContactPersonID"]);
                    c.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    c.CreatedOn = dr["CreatedOn"].ToString();
                    c.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    c.AssignedTo = Convert.ToInt32(dr["AssignedTo"]); 
                }

                return c;
            }
        }

        private static Contracts PopContracts(SqlDataReader dr)
        {
            using (dr)
            {
                Contracts cs = new Contracts();

                while (dr.Read())
                {
                    Contract c = new Contract();

                    c.ContractID = Convert.ToInt32(dr["ContractID"]);
                    c.ContractName = dr["ContractName"].ToString();
                    c.ContractNumber = dr["ContractNumber"].ToString();
                    c.ContractType = Convert.ToInt32(dr["ContractType"]);
                    c.SponsorID = Convert.ToInt32(dr["SponsorID"]);
                    c.SponsorAddress = dr["SponsorAddress"].ToString();
                    c.ContactPersonID = Convert.ToInt32(dr["ContactPersonID"]);
                    c.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    c.CreatedOn = dr["CreatedOn"].ToString();
                    c.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    c.AssignedTo = Convert.ToInt32(dr["AssignedTo"]); 
                    cs.Add(c);
                }

                return cs;
            }
        }

        private static void Validate(string contractName, string contractNumber, int contractType, int sponsorID, bool add)
        {
            StringBuilder sb = new StringBuilder();

            if (contractName.Trim() == string.Empty)
            {
                sb.AppendLine("*Contract Name cannot be empty <br>");
            }

            if (contractNumber.Trim() == string.Empty)
            {
                sb.AppendLine("*Contract Number cannot be empty <br>");
            }
            else
            {
                if (add == true && ExistContractNumber(contractNumber.Trim()))
                {
                    sb.AppendLine(string.Format("*Contract Number {0} has existed <br>", contractNumber.Trim()));
                }
            }

            if (contractType == 0)
            {
                sb.AppendLine("*You must select a contract type <br>");
            }

            if (sponsorID == 0)
            {
                sb.AppendLine("*You must select choose a sponsor <br>");
            }

            if (sb.ToString() != string.Empty)
            {
                throw new Exception(sb.ToString());
            }
        }

        private static void AddContractCaterer(int contractID, Caterers catererList)
        {
            RemoveContractCatererByContractID(contractID);

            foreach (Caterer c in catererList)
            {
                AddContractCaterer(contractID, c.CatererID);
            }
        }

        private static void AddContractMealServed(int contractID, Meals ms)
        {
            Meal.RemoveMealByContractID(contractID);

            foreach (Meal m in ms)
            {
                m.AddMeal(contractID);
            }
        }

        private static void AddContractDietType(int contractID, DietTypes dtList)
        {
            DietType.DeleteDietTypesByContractID(contractID);

            foreach (DietType d in dtList)
            {
                d.AddDietType(contractID, d.DietTypeID);            
 
            }

        }


        private static void AddContractCaterer(int contractID, int catererID)
        {
            ContractDB.AddContractCaterer(contractID, catererID);
        }

        private static bool ExistContractNumber(string contractNumber)
        {
            Contract c = GetContractByContractNumber(contractNumber);
            if (c.ContractNumber == contractNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int AddContract(string contractName, string contractNumber, int contractType, int sponsorID, string sponsorAddress, int contactPersonID, int createdBy, Caterers catererList, Meals mealList,DietTypes dtList, int assignedTo)
        {
            Validate(contractName, contractNumber, contractType, sponsorID, true);
            int contractID = ContractDB.AddContract(contractName, contractNumber, contractType, sponsorID, sponsorAddress, contactPersonID, createdBy, assignedTo);
            AddContractCaterer(contractID, catererList);
            AddContractMealServed(contractID, mealList);
            AddContractDietType(contractID, dtList);

            return contractID;
        }
        
        public static int AddContractTemp(string contractName, string contractNumber, int contractType, int sponsorID, string sponsorAddress, int contactPersonID, int createdBy, string phoneNumber, string sponsorCode, int assignedTo)
        {
            Validate(contractName, contractNumber, contractType, sponsorID, true);
            int contractID = ContractDB.AddContractTemp(contractName, contractNumber, contractType, sponsorID, sponsorAddress, contactPersonID, createdBy, phoneNumber, sponsorCode, assignedTo);
            
            return contractID;
        }

        public static Contract GetContractByID(int contractID)
        {
            return PopContract(ContractDB.GetContractByID(contractID));
        }

        public static Contract GetContractByContractNumber(string contractNumber)
        {
            return PopContract(ContractDB.GetContractByContractNumber(contractNumber));
        }

        public static Contracts GetContractBySponsorID(int sponsorID)
        {
            return PopContracts(ContractDB.GetContractBySponsorID(sponsorID));
        }

        public static Contracts GetContractByCatererID(int catererID)
        {
            return PopContracts(ContractDB.GetContractByCatererID(catererID));
        }

        public static Contracts GetContractAll()
        {
            return PopContracts(ContractDB.GetContractAll());
        }
        public static Contracts GetContractsByStaffIDAndContractType(int staffID, int contractType)
        {
            return PopContracts(ContractDB.GetContractsByStaffID(staffID,contractType));
        }

        /// <summary>
        /// This Method returns contracts list for given staffID, ContractType, DietTypeID and MealTypeID
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="contractType"></param>
        /// <param name="DietTypeID"></param>
        /// <param name="MealTypeID"></param>
        /// <returns>Contracts</returns>
        public static Contracts GetContractsByStaffIDContractTypeDietType(int staffID, int contractType, int DietTypeID, int MealTypeID)
        {
            return PopContracts(ContractDB.GetContractsByStaffIDContractTypeDietType(staffID, contractType, DietTypeID, MealTypeID));
        }

        public static void EditContractByID(int contractID, string contractName, string contractNumber, int contractType, int sponsorID, string sponsorAddress, int contactPersonID, Caterers catererList, Meals mealList,DietTypes dtList, int  assignedTo)
        {
            Validate(contractName, contractNumber, contractType, sponsorID, false);
            ContractDB.EditContractByID(contractID, contractName, contractNumber, contractType, sponsorID, sponsorAddress, contactPersonID, assignedTo);
            AddContractCaterer(contractID, catererList);
            AddContractMealServed(contractID, mealList);
            AddContractDietType(contractID, dtList);
        }

        public static void RemoveContractByID(int contractID)
        {
            ContractDB.RemoveContractByID(contractID);
        }

        private static void RemoveContractCatererByContractIDAndCatererID(int contractID, int catererID)
        {
            ContractDB.RemoveContractCatererByContractIDAndCatererID(contractID, catererID);
        }

        private static void RemoveContractCatererByContractID(int contractID)
        {
            ContractDB.RemoveContractCatererByContractID(contractID);
        }
    }

    public class Contracts : List<Contract> { }
}
