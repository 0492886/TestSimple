using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleServingsLibrary.Shared;
using System.Data.SqlClient;


namespace SimpleServingsLibrary.SupplierRelationship
{
    public class DietType
    {
        public DietType() { }


        private int _contractID;
        public int ContractID
        {
            get { return _contractID; }
            set { _contractID = value; }
        }

        private int _dietTypeID;
        public int DietTypeID
        {
            get { return _dietTypeID; }
            set { _dietTypeID = value; }
        }


        public string DietTypeText
        {
            get { return Code.DecodeCode(DietTypeID); }
        }


        public static DietTypes PopDietType(SqlDataReader dr)
        {
            using (dr)
            {
                DietTypes DTS = new DietTypes();
                while (dr.Read())
                {
                    DietType DT = new DietType();
                    DT.ContractID = Convert.ToInt32(dr["ContractID"]);
                    DT.DietTypeID = Convert.ToInt32(dr["DietTypeID"]);
                    DTS.Add(DT);
                }

                return DTS;
            }        
        }

        public void AddDietType(int contractID, int dietTypeID)
        {           
            DietTypeDB.AddDietType(contractID, dietTypeID);
        }

        public static void DeleteDietTypesByContractID(int contractID)
        {
            DietTypeDB.DeleteDietTypesByContractID(contractID);
 
        }


        public static DietTypes GetDietTypesByContractID(int contractID)
        {
            return PopDietType(DietTypeDB.GetDietTypeByContractID(contractID));
 
        }


    }

    public class DietTypes : List<DietType> { }

}
