using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Shared
{
    public class StaffContract
    {  

        public int StaffContractID
        {
            get;
            set;
        }

        public int StaffID
        {
            get;
            set;
        }

        public int ContractID
        {
            get;
            set;
        }
        public string CreatedOn
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public string CreatedByText
        {
            get;
            set;
        }
        public string  ContractName
        {get;set;}
       
         public string    ContractNumber
        { get; set; }


        private static StaffContracts PopStaffContracts(SqlDataReader dr)
        {
            StaffContracts staffContracts = new StaffContracts();
            StaffContract staffContract;
            while (dr.Read())
            {
                staffContract = new StaffContract();
                staffContract.StaffContractID = Convert.ToInt32(dr["StaffContractID"]);
                staffContract.ContractID = Convert.ToInt32(dr["ContractID"]);
                staffContract.StaffID = Convert.ToInt32(dr["StaffID"]);
                staffContract.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                staffContract.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                staffContract.CreatedByText = Convert.ToString(dr["CreatedByText"]);
                staffContract.ContractName = Convert.ToString(dr["ContractName"]);
                staffContract.ContractNumber = Convert.ToString(dr["ContractNumber"]);
                staffContracts.Add(staffContract);
            }
            dr.Close();
            return staffContracts;
        }

        private static List<int> PopStaffIdsByContractIds(SqlDataReader dr)
        {
            List<int> staffIds = new List<int>();
            while (dr.Read())
            {
                staffIds.Add(Convert.ToInt32(dr["StaffId"]));
            }
            dr.Close();
            return staffIds;
        
        }

        public int AddStaffContract()
        {
            return StaffContractDB.AddStaffContract(StaffID, ContractID, CreatedBy);
        }
        public static bool RemoveStaffContractsByStaffID(int staffID)
        {
            return StaffContractDB.RemoveStaffContractsByStaffID(staffID);
        }

        public static StaffContracts GetStaffContractsByStaffID(int staffID)
        {
            return PopStaffContracts(StaffContractDB.GetStaffContractsByStaffID(staffID));
        }

        public static List<int> GetStaffIdsByContractID(int contractID)
        {
            return PopStaffIdsByContractIds(StaffContractDB.GetStaffIdsByContractID(contractID));
        }
    }

    public class StaffContracts : List<StaffContract>
    { 
    
    }
}
