using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.SupplierRelationship
{
    internal class ContactPersonDB
    {
        internal static int AddContactPerson(string firstName, string lastName, string address, string phone, string email, int createdBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_ContactPerson");

                db.AddInParameter(cmd, "@FirstName", System.Data.DbType.String, firstName);
                db.AddInParameter(cmd, "@LastName", System.Data.DbType.String, lastName);
                db.AddInParameter(cmd, "@Address", System.Data.DbType.String, address);
                db.AddInParameter(cmd, "@Phone", System.Data.DbType.String, phone);
                db.AddInParameter(cmd, "@Email", System.Data.DbType.String, email);
                db.AddInParameter(cmd, "@CreatedBy", System.Data.DbType.Int32, createdBy);

                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static SqlDataReader GetContactPersonByID(int contactPersonID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Select_ContactPerson_By_ID");

                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);

                return (SqlDataReader)db.ExecuteReader(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void EditContactPersonByID(int contactPersonID, string firstName, string lastName, string address, string phone, string email)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_ContactPerson_By_ID");

                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);
                db.AddInParameter(cmd, "@FirstName", System.Data.DbType.String, firstName);
                db.AddInParameter(cmd, "@LastName", System.Data.DbType.String, lastName);
                db.AddInParameter(cmd, "@Address", System.Data.DbType.String, address);
                db.AddInParameter(cmd, "@Phone", System.Data.DbType.String, phone);
                db.AddInParameter(cmd, "@Email", System.Data.DbType.String, email);
                

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void RemoveContactPersonByID(int contactPersonID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Delete_ContactPerson_By_ID");

                db.AddInParameter(cmd, "@ContactPersonID", System.Data.DbType.Int32, contactPersonID);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
