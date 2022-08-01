using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;



namespace SimpleServingsLibrary.Shared
{
    class ProgressNoteDB
    {
        public static SqlDataReader GetProgressNoteByNoteID(int noteID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ProgressNote_By_NoteID");
            db.AddInParameter(cmd, "@NoteID", DbType.Int32, noteID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetProgressNoteByNoteID didn't return a record");
            }
        }

        //public static int AddDraft
        //(
        //    int caseID, 
        //    int limitToClientID, 
        //    bool isDraft,
        //    bool isActive, 
        //    string createdOn, 
        //    string createdBy, 
        //    string removedOn, 
        //    string removedBy,
        //    int noteType, 
        //    int noteReferenceID, 
        //    string noteDescription
        //)
        //{
        //    //Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
        //    //DbConnection cnn = db.CreateConnection();
        //    //cnn.ConnectionString = ConfigurationSettings.AppSettings[GlobalEnum.DATABASENAME];
        //    //DbCommand cmd = db.GetStoredProcCommand("Sp_Add_ProgressNote_Draft");
        //    try
        //    {
        //        return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings[GlobalEnum.DATABASENAME], "Sp_Add_ProgressNote_Draft", caseID, limitToClientID, isDraft,
        //                isActive, createdOn, createdBy, removedOn, removedBy, noteType, noteReferenceID, noteDescription));
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

        //public static int AddDraft
        //(
        //    int caseID,
        //    int limitToClientID,
        //    bool isDraft,
        //    bool isActive,
        //    string createdOn,
        //    string createdBy,
        //    string removedOn,
        //    string removedBy,
        //    int noteType,
        //    int noteReferenceID,
        //    string noteDescription
        //)
        //{
        //    Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
        //    DbCommand cmd = db.GetStoredProcCommand("Sp_Add_ProgressNote_Draft");
        //    try
        //    {
        //        db.AddInParameter(cmd, "@CaseID", DbType.Int32, caseID);
        //        db.AddInParameter(cmd, "@LimitToClientID", DbType.Int32, limitToClientID);
        //        db.AddInParameter(cmd, "@IsDraft", DbType.Boolean, isDraft);
        //        db.AddInParameter(cmd, "@IsActive", DbType.Boolean, isActive);
        //        db.AddInParameter(cmd, "@CreatedOn", DbType.String, createdOn);
        //        db.AddInParameter(cmd, "@CreatedBy", DbType.String, createdBy);
        //        db.AddInParameter(cmd, "@RemovedOn", DbType.String, removedOn);
        //        db.AddInParameter(cmd, "@RemovedBy", DbType.String, removedBy);
        //        db.AddInParameter(cmd, "@NoteType", DbType.Int32, noteType);
        //        db.AddInParameter(cmd, "@NoteReferenceID", DbType.Int32, noteReferenceID);
        //        db.AddInParameter(cmd, "@NoteDescription", DbType.String, noteDescription);

        //        return Convert.ToInt32(db.ExecuteScalar(cmd));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

        public static bool SaveDraft(int noteID, string noteDescription)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Save_ProgressNote_Draft");

            try
            {
                db.AddInParameter(cmd, "@NoteID", DbType.Int32, noteID);
                db.AddInParameter(cmd, "@NoteDescription", DbType.String, noteDescription);

                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateDraft
        (
            int noteID, 
            bool isDraft,
            bool isActive, 
            string createdOn, 
            int createdBy, 
            string removedOn, 
            int removedBy,
            int noteType, 
            int noteReferenceID, 
            string noteDescription
        )
        {

            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Update_ProgressNote_Draft");
                cmd.CommandTimeout = 60;

                db.AddInParameter(cmd, "@NoteID", DbType.Int32, noteID);
                db.AddInParameter(cmd, "@IsDraft", DbType.Boolean, isDraft);
                db.AddInParameter(cmd, "@IsActive", DbType.Boolean, isActive);
                db.AddInParameter(cmd, "@CreatedOn", DbType.String, createdOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@RemovedOn", DbType.String, removedOn);
                db.AddInParameter(cmd, "@RemovedBy", DbType.Int32, removedBy);
                db.AddInParameter(cmd, "@NoteType", DbType.Int32, noteType);
                db.AddInParameter(cmd, "@NoteReferenceID", DbType.Int32, noteReferenceID);
                db.AddInParameter(cmd, "@NoteDescription", DbType.String, noteDescription);

                db.ExecuteNonQuery(cmd);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        


       

        public static int AddDraft( bool isDraft,
            int createdBy, int noteType, int noteReferenceID, string noteDescription)
        {
            int noteID = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Insert_ProgressNoteDraft");
                cmd.CommandTimeout = 60;

                
                db.AddInParameter(cmd, "@IsDraft", DbType.Boolean, isDraft);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, createdBy);
                db.AddInParameter(cmd, "@NoteType", DbType.Int32, noteType);
                db.AddInParameter(cmd, "@NoteReferenceID", DbType.Int32, noteReferenceID);
                db.AddInParameter(cmd, "@NoteDescription", DbType.String, noteDescription);

                noteID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return noteID;
        }
        internal static SqlDataReader GetProgressNotesByReferenceIDNoteType(int referenceID, int noteType, int noteLength)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_ProgressNotes_By_RefIDNoteType");

            db.AddInParameter(cmd, "@ReferenceID", DbType.Int32, referenceID);
            db.AddInParameter(cmd, "@NoteType", DbType.Int32, noteType);
            db.AddInParameter(cmd, "@NoteLength", DbType.Int32, noteLength);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("GetProgressNotesByReferenceIDNoteType did not return record!");
            }         
        }
        public static bool RemoveNoteByNoteID(int noteID, int removedBy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Remove_NoteByNoteID");

                db.AddInParameter(cmd, "@noteID", DbType.Int32, noteID);
                db.AddInParameter(cmd, "@removedBy", DbType.Int32, removedBy);

                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }       
                
        internal static SqlDataReader GetDraftsByCreatedBy(int createdBy, int noteDescriptionLength)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_DraftsByCreatedBy");
            db.AddInParameter(cmd, "@NoteDescriptionLength", DbType.Int32, noteDescriptionLength);
            db.AddInParameter(cmd, "@createdBy", DbType.Int32, createdBy);


            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);

            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Drafts By Created By didn't return a record");
            }
        }
       
    }
}
