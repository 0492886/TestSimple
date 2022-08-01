using System;
using System.Collections;
using System.Text;
using System.Data.SqlClient;



namespace SimpleServingsLibrary.Shared
{
    public class StaffComment 
    {
        private int _commentID;
        private int _staffID;
        private string _comment;
        private string _createdOn;
        private int _createdBy;

        public int CommentID
        {
            get { return _commentID; }
            set { _commentID = value; }
        }

        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public string CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        public string CreatedByText
        {
            get { return Staff.GetStaffNameByStaffID(Convert.ToInt32(CreatedBy)); }
        }

        public static int AddComment(int staffID,string comment,int createdBy)
        {
            return StaffCommentDB.AddComment(staffID,comment, createdBy);
        }

        public static StaffComments GetCommentsByStaffID(int staffID)
        {
            return PopComments(StaffCommentDB.GetCommentsByStaffID(staffID));
        }

        private static StaffComments PopComments(SqlDataReader dr)
        {
            StaffComments staffComments = new StaffComments();
            StaffComment staffComment;
            while (dr.Read())
            {
                staffComment = new StaffComment();
                staffComment.CommentID = Convert.ToInt32(dr["CommentID"]);
                staffComment.Comment = Convert.ToString(dr["Comment"]);
                staffComment.StaffID = Convert.ToInt32(dr["StaffID"]);
                staffComment.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                staffComment.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                
                staffComments.Add(staffComment);
            }
            dr.Close();
            return staffComments;
        }
    }

    public class StaffComments : ArrayList
    { 
    }
}