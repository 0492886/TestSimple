using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace SimpleServingsLibrary.SupplierRelationship.Utility
{
    public class ExcelHelper
    {
        private static string Excel03CnnString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ToString();
        private static string Excel07CnnString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ToString();

        private string GetConnectionString(string fileExtension)
        {
            switch (fileExtension.ToUpper())
            {
                case ".XLS": //Excel 97-03
                    return Excel03CnnString; 

                case ".XLSX": //Excel 07
                    return Excel07CnnString;
                
                default:
                    throw new Exception("This is not a valid excel file");
            }
        }

        public DataTable GetDataTable(string filePath, string tableName)
        {
            string fileExtension = Path.GetExtension(filePath);
            string cnnString = GetConnectionString(fileExtension);
            
            //set the datasource file path in the connection string
            OleDbConnection cnn = new OleDbConnection(string.Format(cnnString, filePath, "Yes"));
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;

            cnn.Open();

            DataTable excelTableSchema = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetOneName = excelTableSchema.Rows[0]["TABLE_NAME"].ToString();
            cmd.CommandText = "Select * From [" + sheetOneName + "]";

            DataTable dt = new DataTable(tableName);
            OleDbDataAdapter oleAdapter = new OleDbDataAdapter(cmd);
            oleAdapter.Fill(dt);

            cnn.Close();
            
            return dt;
        }

        public bool IsExcelFile(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName).ToUpper();

            if (fileExtension == ".XLS" || fileExtension == ".XLSX")
            {
                return true;
            }

            return false;
        }


    }
}
