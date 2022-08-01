using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SimpleServingsLibrary.Resource
{
    public class WelcomeMessage
    {
        public int ID { get; set; }
        public string ImageFile { get; set; }
        public string Message { get; set; }
        public int CreatedBy { get; set; }

        #region private methods
        private void PopMessage(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    ID = Convert.ToInt32(dr["ID"]);

                    if (dr["ImageFile"] != DBNull.Value)
                    {
                        ImageFile = Convert.ToString(dr["ImageFile"]);
                    }
                    if (dr["Message"] != DBNull.Value)
                    {
                        Message = Convert.ToString(dr["Message"]);
                    }

                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                }
            }
        }
        #endregion

        #region public methods

        public void GetWelcomeMessage()
        {
            PopMessage(ResourceDB.GetWelcomeMessage());
        }

        public static void AddWelcomeMessage(string imageFile, string message, int staffID)
        {
            ResourceDB.AddWelcomeMessage(imageFile, message, staffID);
        }

        public static string GetImageFile()
        {
            string imageFile = null;
            using (SqlDataReader dr = ResourceDB.GetWelcomeMessage())
            {
                if (dr.Read())
                {
                    if (dr["ImageFile"] != DBNull.Value)
                    {
                        imageFile = Convert.ToString(dr["ImageFile"]);
                    }
                }
            }

            return imageFile;
        }

        public static string GetMessageContent()
        {
            string message = null;
            using (SqlDataReader dr = ResourceDB.GetWelcomeMessage())
            {
                if (dr.Read())
                {
                    if (dr["Message"] != DBNull.Value)
                    {
                        message = Convert.ToString(dr["Message"]);
                    }
                }
            }

            return message;
        }
        #endregion

    }
}
