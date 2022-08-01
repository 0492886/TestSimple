using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Shared
{
   public class ManageCategoriesandTags
    {
       public int CategoryTagID { get; set; }
       public int CategoryID { get; set; }
       public int TagID { get; set; }
       public bool IsActive { get; set; }
       public string CreatedOn { get; set; }
       public int CreatedBy { get; set; }
       public int RemovedBy { get; set; }
       public string RemovedOn { get; set; }

       public string CategoryName { get; set; }
       public string TagName { get; set; }


       private void PopCategoryandTags(SqlDataReader dr)
       {
           using (dr)
           {
               if (dr.Read())
               {
                   CategoryTagID = Convert.ToInt32(dr["CategoryTagID"]);
                   CategoryID = Convert.ToInt32(dr["CategoryID"]);
                   TagID = Convert.ToInt32(dr["TagID"]);
                   IsActive = Convert.ToBoolean(dr["IsActive"]);
                   CreatedOn = Convert.ToString(dr["CreatedOn"]);
                   CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                   RemovedOn = Convert.ToString(dr["RemovedOn"]);
                   RemovedBy = Convert.ToInt32(dr["RemovedBy"]);
               }
               dr.Close();
           }
       }


       private static ManageCategoriesandTagsList PopCategoriesandTags(SqlDataReader dr)
       {
           ManageCategoriesandTagsList CategoryTagslist = new ManageCategoriesandTagsList();
           ManageCategoriesandTags CategoryTags;
           using (dr)
           {
               while (dr.Read())
               {
                   CategoryTags = new ManageCategoriesandTags();
                  // CategoryTags.CategoryTagID = Convert.ToInt32(dr["CategoryTagID"]);
                   CategoryTags.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                   CategoryTags.TagID = Convert.ToInt32(dr["TagID"]);
                   CategoryTags.IsActive = Convert.ToBoolean(dr["IsActive"]);
                   CategoryTags.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                   CategoryTags.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                   CategoryTags.RemovedOn = Convert.ToString(dr["RemovedOn"]);
                   CategoryTags.RemovedBy = Convert.ToInt32(dr["RemovedBy"]);

                   CategoryTags.CategoryName = Convert.ToString(dr["CategoryName"]);
                   CategoryTags.TagName = Convert.ToString(dr["TagName"]);
                   
                   CategoryTagslist.Add(CategoryTags);
               }
           }
           dr.Close();
           return CategoryTagslist;
       }


       /// <summary>
       /// Returns Associated Tags for the supplied Category ID
       /// </summary>
       /// <param name="CategoryID"></param>
       /// <returns></returns>
       public static ManageCategoriesandTagsList GetTagsByCategoryID(int CategoryID)
       {
           return PopCategoriesandTags(ManageCategoriesandTagsDB.GetTagsByCategoryID(CategoryID));
       }


       /// <summary>
       /// Save Associated Tags for the supplied Category ID 
       /// </summary>
       /// <param name="CategoryID"></param>
       /// <param name="Tags"></param>
       /// <param name="StaffID"></param>
       public static void SaveTagsForCategory(int CategoryID, List<int> Tags, int StaffID)
       {
           ManageCategoriesandTagsDB.SaveTagsForCategory(CategoryID, Tags, StaffID);
 
       }

       public static ManageCategoriesandTagsList GetAllCategoriesandTags()
       {
           return PopCategoriesandTags(ManageCategoriesandTagsDB.GetAllCategoriesandTags());
 
       }









    }

    public class ManageCategoriesandTagsList : List<ManageCategoriesandTags> { }
}
