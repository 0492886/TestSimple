using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Shared
{
    public class StaffNote
    {

        #region private fields
        private int noteID;
        private string note;
        private int contractID;
        private int createdBy;
        private string createdOn;
        private int targetStaffID;
        private bool isRead;
        private bool isActive;

        #endregion

        #region Public properties
        
        public int NoteID
        {
            get { return noteID; }
            set { noteID = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public int ContractID
        {
            get { return contractID; }
            set { contractID = value; }
        }

        public int TargetStaffID
        {
            get { return targetStaffID; }
            set { targetStaffID = value; }
        }
        public string TargetStaffIDText
        {
            get
            {
                try
                {
                    return Staff.GetStaffNameByStaffID(TargetStaffID);
                }
                catch
                {
                    return String.Empty;
                }

            }

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
            get
            {
                try
                {
                    return Staff.GetStaffNameByStaffID(CreatedBy);
                }
                catch
                {
                    return String.Empty;
                }

            }
        }

        public bool IsRead
        {
            get { return isRead; }
            set { isRead = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        
        
        
        
        #endregion 

        #region private methods

       private void PopStaffNote(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    NoteID = Convert.ToInt32(dr["NoteID"]);
                    Note = dr["Note"].ToString();
                    ContractID = Convert.ToInt32(dr["ContractID"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = dr["CreatedOn"].ToString();
                    TargetStaffID = Convert.ToInt32(dr["TargetStaffID"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    IsRead = Convert.ToBoolean(dr["IsRead"]);

                }
            }
        }

       private static StaffNoteList PopStaffNoteList(SqlDataReader dr)
        {
            StaffNoteList staffNoteList = new StaffNoteList();
            StaffNote staffNote;
            using (dr)
            {
                while (dr.Read())
                {
                    staffNote = new StaffNote();
                    staffNote.NoteID = Convert.ToInt32(dr["NoteID"]);
                    staffNote.Note = dr["Note"].ToString();
                    staffNote.ContractID = Convert.ToInt32(dr["ContractID"]);
                    staffNote.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    staffNote.CreatedOn = dr["CreatedOn"].ToString();
                    staffNote.TargetStaffID = Convert.ToInt32(dr["TargetStaffID"]);
                    staffNote.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    staffNote.IsRead = Convert.ToBoolean(dr["IsRead"]);
                    staffNoteList.Add(staffNote);
                }
            }
            return staffNoteList;
        }


        

        #endregion

        #region Public Methods

        public int AddStaffNote()
        {
            return StaffNoteDB.AddStaffNote( Note,ContractID,CreatedBy,TargetStaffID);
        }

        public static void MarkAsRead(int targetStaffID)
        {
            StaffNoteDB.MarkAsRead(targetStaffID);
        }
        public static void MarkNoteAsRead(int noteID)
        {
            StaffNoteDB.MarkNoteAsRead(noteID);
        }

        public static StaffNoteList GetAllStaffNotesByStaffID(int targetStaffID,bool showEntire)
        {
            return PopStaffNoteList(StaffNoteDB.GetAllStaffNotesByStaffID(targetStaffID,showEntire));
        }

        public static StaffNoteList GetNewStaffNotesByStaffID(int targetStaffID, bool showEntire)
        {
            return PopStaffNoteList(StaffNoteDB.GetNewStaffNotesByStaffID(targetStaffID,showEntire));
        }





        
        #endregion

        

    }
    public class StaffNoteList : ArrayList
    { }

}


