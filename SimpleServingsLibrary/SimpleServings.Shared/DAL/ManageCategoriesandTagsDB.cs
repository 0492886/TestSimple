using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.Shared
{
    public class ManageCategoriesandTagsDB
    {

        internal static SqlDataReader GetAllCategoriesandTags()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_GetAllCategoriesandTags");
                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
                if (dr.HasRows)
                {
                    return dr;
                }
                else
                {
                    throw new Exception("Sp_GetAllCategoriesandTags did not return a record!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
 
        }

        internal static SqlDataReader GetTagsByCategoryID(int CategoryID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_GetAllTagsForCategory");
                db.AddInParameter(cmd, "@CategoryID", DbType.Int32, CategoryID);
                SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

                if (dr.HasRows)
                {
                    return dr;
                }
                else
                {
                    return dr; //throw new Exception("Procedure did not return a record!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        internal static void SaveTagsForCategory(int CategoryID, List<int> Tags, int StaffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_SaveTagsForCategory");
                db.AddInParameter(cmd, "@CategoryID", DbType.Int32, CategoryID);
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, StaffID);

                var table = new DataTable();
                table.Columns.Add("TagIDs", typeof(string));
                
                foreach (int i in Tags)
                {
                    table.Rows.Add(i);
                    
                }

                SqlParameter sp = new SqlParameter();
                sp.SqlDbType = SqlDbType.Structured;
                sp.ParameterName = "@Tags";
                sp.Value = table;
                cmd.Parameters.Add(sp);


                db.ExecuteScalar(cmd);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }

        }














    }
}
