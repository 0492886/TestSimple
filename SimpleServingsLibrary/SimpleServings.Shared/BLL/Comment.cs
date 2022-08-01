using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Net.Mail;

using SimpleServingsLibrary.Shared;
using System.Configuration;

namespace SimpleServingsLibrary.Shared
{
    public class Comment
    {
         private static string SMTPServer
        {
            get { return ConfigurationManager.AppSettings["SmtpServer"]; }
        }
         private static string SENDER
         {
             get { return ConfigurationManager.AppSettings["AdminEmail"]; }
         }



        private int commentId;
        public int CommentId 
        {
            set { commentId = value; }
            get { return commentId;  }
        }

        private int actionCode;
        public int ActionCode 
        {
            set { actionCode = value; }
            get { return actionCode;  }
        }

        private string subject;
        public string Subject
        {
            set { subject = value; }
            get { return subject;  }
        }

        private string text;
        public string Text
        {
            set { text = value;  }
            get { return text;  }
        }

        private bool isActive;
        public bool IsActive
        {
            set { isActive = value; }
            get { return isActive; }
        }

        #region vary attribute
        //---------------------------------------- 
        // following content will vary 

        private string from;
        public string From
        {
            set { from = value; }
            get { return from;  }
        }

        private string to;
        public string To 
        {
            set { to = value; }
            get { return to; }
        }

        private bool includeText;
        public bool IncludeText
        {
            set { includeText = value; }
            get { return includeText;  }
        }
        #endregion

        internal static Comment PopComment(SqlDataReader dr)
        {
            Comment comment = new Comment();
            using (dr)
            {
                if (dr.Read())
                {
                    comment.commentId = Convert.ToInt32(dr["Id"]);
                    comment.actionCode = Convert.ToInt32(dr["ActionCode"]);
                    comment.Subject = Convert.ToString(dr["Subject"]);
                    comment.Text = Convert.ToString(dr["Text"]);
                    comment.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    //-------------------
                    //make it null because its cary attribute
                    comment.To = "";
                    comment.From = "";
                    comment.IncludeText = true;
                }
            }
            return comment;
        }

        internal static string PopStaffEmailByStaffId(SqlDataReader dr)
        {
            string email="";
            using (dr)
            {
                if (dr.Read())
                {
                    email = dr["Email"].ToString(); 
                }
            }
            return email;

        }

        public static Comment GetCommentByActionCode(int actionCode)
        {
            return PopComment(CommentDB.GetCommentByActionCode(actionCode));
        }

        public static Comment GetReadlyForComment(Comment comment, Staff staff)
        {
            comment.From = staff.LastName + ", " + staff.FirstName;
            comment.To = "Test2";
            comment.Text = comment.Text.Replace("@date", DateTime.Now.ToLongDateString());
            comment.Text = comment.Text.Replace("@from", comment.From);
            comment.Text = comment.Text.Replace("@to", comment.To);

            return comment;
        }
        public static string GetToByMenuID(int menuID, int menuStatus, List<int> contractIDs)
        {
            StringBuilder sb = new StringBuilder();
            string email;
            List<int> staffIds;
            if (menuStatus == GlobalEnum.MenuStatus_SubmittedToContract)
            {

                foreach(int contractID in contractIDs)
                {
                    // add in StaffContract StaffContractDB and a stored proc
                   //list of staffIDs StaffContract.GetStaffIdsByContractID(contractID);
                    staffIds = StaffContract.GetStaffIdsByContractID(contractID);
                    foreach (int staffId in staffIds)
                    {
                        
                        email = Staff.GetStaffEmailByStaffId(staffId);
                        sb.Append(email + ";");
                    }
                    //for each staffID in staffIds
                    // email = GetStaffMemberEmailByStaffID(staffID)
                    //sb.Append(email);
                }

            }
            else if (menuStatus == GlobalEnum.MenuStatus_SubmittedToDFTA)
            {
                 foreach(int contractID in contractIDs)
                {
                     email = GetAssignedToEmailByContracyID(contractID);
                     sb.Append(email);
                 }
            }
            return sb.ToString();
            //return "test@gmail.com";
        }

        public static bool SendEmail(int menuStatus, int menuID,int staffID, List<int> contractIDs)
        {
             try
            {
                string to = GetToByMenuID(menuID, menuStatus,contractIDs);
                string from;
                 // add in staff staffdb and stored proc
                from = SENDER;
                //from = Staff.GetStaffEmailByStaffId(staffID);
                SmtpClient client = new SmtpClient(SMTPServer);

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                if (!String.IsNullOrEmpty(to))
                {
                    string[] tos = to.Split(';');
                    foreach (string email in tos)
                    {
                        if (!String.IsNullOrEmpty(email))
                            message.Bcc.Add(email);
                    }
                }
                
               

                message.Subject = "New Menu Submitted";
                message.Body = "New Menu Submitted";

                message.IsBodyHtml = true;
               
                client.Send(message);
                return true;
            }
            catch
            {
                return false;
            }

        }

        //will return the Email of Contract.AssignedTo
        //tblContract----> AssignedTo--------->tblStaff------->email
        public static string GetAssignedToEmailByContracyID(int contractId)
        {
            //return CommentDB.GetAssignedToEmailByContracyID(contractID);
            return PopStaffEmailByStaffId(CommentDB.GetAssignedToEmailByContracyID(contractId));
        }

    }
}
