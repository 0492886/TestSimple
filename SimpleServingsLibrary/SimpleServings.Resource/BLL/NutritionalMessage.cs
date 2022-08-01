using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SimpleServingsLibrary.Resource
{
    public class NutritionalMessage
    {
        public int ID { get; set; }
        public string MessageTitle { get; set; }
        public string MessageFile { get; set; }
        public string MessageContent { get; set; }
        public int CreatedBy { get; set; }

        #region private methods
        private void PopMessage(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    ID = Convert.ToInt32(dr["ID"]);
                    MessageTitle = Convert.ToString(dr["MessageTitle"]);
                    MessageFile = Convert.ToString(dr["MessageFile"]);

                    if (dr["MessageContent"] != DBNull.Value)
                    {
                        MessageContent = Convert.ToString(dr["MessageContent"]);
                    }

                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                }
            }
        }
        #endregion

        #region public methods
        public void GetNutritionalMessage()
        {
            PopMessage(ResourceDB.GetNutritionalMessage());
        }

        #region methods for homepage content - nutrition message
        public static void AddNutritionalMessage(string nutrMsgTitle, string nutrMsgFile, string nutrMsgContent, int staffId)
        {
            ResourceDB.AddNutritionalMessage(nutrMsgTitle, nutrMsgFile, nutrMsgContent, staffId);
        }
        public static string GetNutritionalMessageTitle()
        {
            string messageTitle = null;
            using (SqlDataReader dr = ResourceDB.GetNutritionalMessage())
            {
                if (dr.Read())
                {
                    if (dr["MessageTitle"] != DBNull.Value)
                    {
                        messageTitle = Convert.ToString(dr["MessageTitle"]);
                    }
                }
            }

            return messageTitle;
        }
        public static string GetNutritionalMessageFile()
        {
            string messageFile = null;
            using (SqlDataReader dr = ResourceDB.GetNutritionalMessage())
            {
                if (dr.Read())
                {
                    if (dr["MessageFile"] != DBNull.Value)
                    {
                        messageFile = Convert.ToString(dr["MessageFile"]);
                    }
                }
            }

            return messageFile;
        }
        public static string GetNutritionalMessageContent()
        {
            string messageContent = null;
            using (SqlDataReader dr = ResourceDB.GetNutritionalMessage())
            {
                if (dr.Read())
                {
                    if (dr["MessageContent"] != DBNull.Value)
                    {
                        messageContent = Convert.ToString(dr["MessageContent"]);
                    }
                }
            }
            return messageContent;
        }
        #endregion

        #endregion
    }
}
