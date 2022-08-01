using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;




namespace SimpleServingsLibrary.Shared
{
    public class ProgressNote 
    {
        #region Private variables
        private int noteID;
        
        private bool isDraft;
        private bool isActive;
        private string createdOn;
        private int createdBy;
        private string removedOn;
        private int removedBy;
        private int noteType;
        private int noteReferenceID;
        private string noteDescription;
        #endregion

        #region Public properties
        public int NoteID
        {
            get { return noteID; }
            set { noteID = value; }
        }

       
        public bool IsDraft
        {
            get { return isDraft; }
            set { isDraft = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
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
        

        
        public string RemovedOn
        {
            get { return removedOn; }
            set { removedOn = value; }
        }
        public int RemovedBy
        {
            get { return removedBy; }
            set { removedBy = value; }
        }
        public int NoteType
        {
            get { return noteType; }
            set { noteType = value; }
        }
        public string NoteTypeText
        {
            get { return Code.DecodeCode(NoteType); }
        }
        public int NoteReferenceID
        {
            get { return noteReferenceID; }
            set { noteReferenceID = value; }
        }
        public string NoteDescription
        {
            get { return noteDescription; }
            set { noteDescription = value; }
        }
        #endregion


        #region Constructor
        public ProgressNote() { }

        public ProgressNote(int noteID)
        {
            FillProgressNoteByNoteID(noteID);
        }
        #endregion


        #region Private methods
        private void PopProgressNote(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    NoteID = Convert.ToInt32(dr["NoteID"]);
                    IsDraft = Convert.ToBoolean(dr["IsDraft"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    CreatedOn = dr["CreatedOn"].ToString();
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    RemovedOn = dr["RemovedOn"].ToString();
                    RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                    NoteType = Convert.ToInt32(dr["NoteType"]);
                    NoteReferenceID = Convert.ToInt32(dr["NoteReferenceID"]);
                    NoteDescription = dr["NoteDescription"].ToString();
                }
            }
                        
        }

        private static ProgressNotes PopProgressNotes(SqlDataReader dr)
        {
            ProgressNote note;
            ProgressNotes notes = new ProgressNotes();
            using (dr)
            {
                while (dr.Read())
                {
                    note = new ProgressNote();

                    note.NoteID = Convert.ToInt32(dr["NoteID"]);
                    note.IsDraft = Convert.ToBoolean(dr["IsDraft"]);
                    note.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    note.CreatedOn = dr["CreatedOn"].ToString();
                    note.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    note.RemovedOn = dr["RemovedOn"].ToString();
                    note.RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
                    note.NoteType = Convert.ToInt32(dr["NoteType"]);
                    note.NoteReferenceID = Convert.ToInt32(dr["NoteReferenceID"]);
                    note.NoteDescription = dr["NoteDescription"].ToString();

                    notes.Add(note);
                }
            }
            return notes;
        }

        private void FillProgressNoteByNoteID(int noteID)
        {
            PopProgressNote(ProgressNoteDB.GetProgressNoteByNoteID(noteID));
        }

        //private void ValidateNote()
        //{ 
        //    StringBuilder sb = new StringBuilder();

        //    if (!Validation.IsNotEmpty(FairHearingID.ToString()))
        //    {
        //        sb.Append("FairHearingID cannot be empty!" + "\n");
        //    }
        //    if (!Validation.IsInteger(FairHearingID.ToString()))
        //    {
        //        sb.Append("FairHearingID has to be a number!" + "\n");
        //    }
        //    if (Validation.IsNotEmpty(LimitToClientID.ToString()))
        //    {
        //        if (!Validation.IsInteger(LimitToClientID.ToString()))
        //        {
        //            sb.Append("LimitToClientID has to be a number!" + "\n");
        //        }
        //    }
        //    if (!Validation.IsNotEmpty(IsDraft.ToString()))
        //    {
        //        sb.Append("IsDraft cannot be empty!" + "\n");
        //    }
        //    if (!Validation.IsNotEmpty(IsActive.ToString()))
        //    {
        //        sb.Append("IsActive cannot be empty!" + "\n");
        //    }
        //    if (!Validation.IsNotEmpty(CreatedBy.ToString()))
        //    {
        //        sb.Append("CreatedBy cannot be empty!" + "\n");
        //    }
        //    if (!Validation.IsNotEmpty(NoteType.ToString()))
        //    {
        //        sb.Append("NoteType cannot be empty!" + "\n");
        //    }
        //    if (!Validation.IsInteger(NoteType.ToString()))
        //    {
        //        sb.Append("NoteType has to be a number!" + "\n");
        //    }
        //    if (!Validation.IsNotEmpty(NoteReferenceID.ToString()))
        //    {
        //        sb.Append("NoteReferenceID cannot be empty!" + "\n");
        //    }
        //    if (!Validation.IsInteger(NoteReferenceID.ToString()))
        //    {
        //        sb.Append("NoteReferenceID has to be a number!" + "\n");
        //    }
        //    if (!Validation.IsNotEmpty(NoteDescription.ToString()))
        //    {
        //        sb.Append("NoteDescription cannot be empty!" + "\n");
        //    }
        //    if( sb.Length != 0 )
        //    {
        //        throw new Exception(sb.ToString());
        //    }
        //}

        private void ValidateNote()
        {
            StringBuilder sb = new StringBuilder();

            //if(Validation.IsNotEmpty(FairHearingID.ToString())==false)
            //{
            //    sb.Append("*FairHearingID cannot be empty!" + "\n");
            //}

            //if(Validation.IsInteger(FairHearingID.ToString())==false)
            //{
            //    sb.Append("*FairHearingID should be an integer!" + "\n");
            //}
            //sometimes Limit to client is not required in other component(service plan...). 
            //sb.Append(Validation.ValidateRequired(LimitToClientID.ToString(), "Client selection", false));

            sb.Append(Validation.ValidateRequired(CreatedBy.ToString(), "Created By", true));

            sb.Append(Validation.ValidateRequired(NoteType.ToString(), "Note Type", false));

            sb.Append(Validation.ValidateRequired(NoteReferenceID.ToString(), "Note Reference ID", false));

            if (sb.Length != 0)
            {
                throw new Exception(sb.ToString());
            }
        }

        private bool IsDraftExisted()
        {
            //If ProgressNoteDB.GetProgressNoteByNoteID(noteID) return an exception,
            //the catch block will catch it and return false.
            //otherwise, it means ProgressNoteDB.GetProgressNoteByNoteID(noteID) go through,
            //and it will return true
            try
            {
                //because IsDraftExisted() is an instance method, so using the noteID here,
                //means we using the instance's property noteID
                ProgressNoteDB.GetProgressNoteByNoteID(noteID);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region Public instance methods
        public int AddNote()
        {
            int noteID = AddDraft();
            return noteID;
        }

        public int AddDraft()
        {
            
            string msg = String.Empty;
            //if (!Rule.SatisfyRules( CreatedBy, ref msg, new int[] { NoteType}))
            //    throw new ApplicationException(msg);
            ValidateNote();
            int noteID = ProgressNoteDB.AddDraft(  isDraft, createdBy,
                noteType, noteReferenceID, noteDescription);
            //Only log notes of type general
            //if (!isDraft && noteID>0 && noteType == GlobalEnum.NoteType_General)
            //    Logger.AddLog(NoteReferenceID, NoteID, GlobalEnum.CaseNoteModule, "Added a general note.", CreatedBy);
            return noteID;
        }

        private void UpdateDraft()
        {
            string msg = String.Empty;
            //if (!Rule.SatisfyRules( CreatedBy, ref msg, new int[] { NoteType}))
            //    throw new ApplicationException(msg);
            ValidateNote();

            ProgressNoteDB.UpdateDraft(noteID,  isDraft, isActive, createdOn, createdBy,
                removedOn, removedBy, noteType, noteReferenceID, noteDescription);
            //if (!isDraft && noteID > 0 && noteType == GlobalEnum.NoteType_General)
             //   Logger.AddLog(NoteReferenceID, noteID, GlobalEnum.CaseNoteModule, "Added a general note.", CreatedBy);
            
        }

        public bool Equals(ProgressNote note)
        {
            if (noteID != note.NoteID ||
                
                isDraft != note.IsDraft ||
                isActive != note.IsActive ||
                createdOn != note.CreatedOn ||
                createdBy != note.CreatedBy ||
                removedOn != note.RemovedOn ||
                removedBy != note.RemovedBy ||
                noteType != note.NoteType ||
                noteReferenceID != note.NoteReferenceID ||
                noteDescription != note.NoteDescription)
            {
                return false;
            }

            return true;
        }

        //public bool PublishDraft()
        //{
        //    isDraft = false;
        //    //Calling the UpdateDraft() method here will save all the changes the user maded
        //    //in the last second and also publish the draft as note
        //    return UpdateDraft();
        //}
        #endregion


        #region Public static methods

        //Non-static method can use static method, but static method has can use Non-static method
        //GetProgressNoteByNoteID should return an ProgressNote object, it shouldn't create and instance 
        //of ProgressNote and then call the GetProgressNoteByNoteID() method.
        public void GetProgressNoteByNoteID(int noteID)
        {

            PopProgressNote(ProgressNoteDB.GetProgressNoteByNoteID(noteID));
        }

        public int SaveDraft()
        {
            if (IsDraftExisted())
            {
                UpdateDraft();
                return noteID;
            }
            else
            {
                return AddDraft();
            }
        }

        /// <summary>
        /// return a list of progress note by FairHearingID
        /// </summary>
        /// <param name="FairHearingID">The ID of Fair Hearing </param>
        /// <param name="noteDescriptionLength">
        /// The number of characters returned in each note, 
        /// the whole note will return if its value less than or equal to 0
        /// </param>
        /// <returns>a list of progress notes</returns>
     

        public static ProgressNotes GetProgressNotesByReferenceIDNoteType(int referenceID, int noteType, int noteLength)
        {
            return PopProgressNotes(ProgressNoteDB.GetProgressNotesByReferenceIDNoteType(referenceID, noteType, noteLength));
        }

       

        /// <summary>
        /// return a list of note drafts by FairHearingID
        /// </summary>
        /// <param name="FairHearingID">The ID of Fair Hearing</param>
        /// <param name="noteDescriptionLength">
        /// The number of characters returned in each note, 
        /// the whole note will return if its value less than or equal to 0
        /// </param>
        /// <returns>a list of note drafts</returns>
        


       

        public static ProgressNotes GetDraftsByCreatedBy(int createdBy, int noteDescriptionLength)
        {
            return PopProgressNotes(ProgressNoteDB.GetDraftsByCreatedBy(createdBy,noteDescriptionLength));
        }

        

       
        public static bool RemoveNoteByNoteID(int noteID, int removedBy)
        {
            return ProgressNoteDB.RemoveNoteByNoteID(noteID, removedBy);
        }

        
        #endregion


        #region IMailable Members
        public string MailBody
        {
            get 
            {
                StringBuilder sb = new StringBuilder();
                //sb.Append(string.Format("Progress note body for Fair Hearing ID {0} <br>", FairHearingID));
                sb.Append(string.Format("Note ID: {0} <br>", NoteID));
                sb.Append(string.Format("Note Type is: {0} <br>", NoteTypeText));
                sb.Append(string.Format("Created On: {0} <br>", CreatedOn));
                sb.Append(string.Format("Note Text: {0} <br>", NoteDescription));

                return sb.ToString();
            }
        }

        public string MailSubject
        {
            get { return string.Empty; }
               //return string.Format("Progress note subject for FairHearingID {0}", FairHearingID); }
        }


        public string GetBody(string bodyHeader)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0} <br>", bodyHeader));
            sb.Append(MailBody);
            return sb.ToString();
        }

        public string GetSubject(string subjectHeader)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} ", subjectHeader));
            sb.Append(MailSubject);
            return sb.ToString();
        }
       


        #endregion

        


    }

    public class ProgressNotes : List<ProgressNote> { }
}
