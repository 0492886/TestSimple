using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Shared
{
    class StaffNoteDB
    {
        internal static int AddStaffNote(string note,int contractID,int createdBy,int targetStaffID)
        {
            int staffNoteID;
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_StaffNote");
                db.AddInParameter(cmd, "@note", DbType.String, note);
                db.AddInParameter(cmd, "@contractID", DbType.Int32, contractID);
                db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);
                
                db.AddInParameter(cmd, "@targetStaffID", DbType.Int32, targetStaffID);
       
                
                staffNoteID = Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return staffNoteID;
        }
        
        internal static void MarkAsRead(int targetStaffID)
        {
            
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand cmd = db.GetStoredProcCommand("Sp_Mark_As_Read");
                db.AddInParameter(cmd, "@targetStaffID", DbType.Int32, targetStaffID);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
  
        }

        internal static SqlDataReader GetAllStaffNotesByStaffID(int targetStaffID,bool showEntire)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllStaffNotesByStaffID");
            db.AddInParameter(cmd, "@targetStaffID", DbType.Int32, targetStaffID);
            db.AddInParameter(cmd, "@showEntire", DbType.Boolean, showEntire);

            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get_AllStaffNotesByStaffID did not return any record!");
            }
        }

        internal static SqlDataReader GetNewStaffNotesByStaffID(int targetStaffID,bool showEntire)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_NewStaffNotesByStaffID");
            db.AddInParameter(cmd, "@targetStaffID", DbType.Int32, targetStaffID);
            db.AddInParameter(cmd, "@showEntire", DbType.Boolean, showEntire);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get_NewStaffNotesByStaffID did not return any record!");
            }
        }



        internal static void MarkNoteAsRead(int noteID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand cmd = db.GetStoredProcCommand("Sp_MarkNote_As_Read");
                db.AddInParameter(cmd, "@noteID", DbType.Int32, noteID);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
