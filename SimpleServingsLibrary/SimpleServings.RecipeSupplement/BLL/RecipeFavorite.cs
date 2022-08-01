using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.RecipeSupplement
{
    public class RecipeFavorite
    {
        private int _favoriteID;
        public int FavoriteID
        {
            get { return _favoriteID; }
            set { _favoriteID = value; }
        }
        
        private int _recipeID;
        public int RecipeID
        {
            get { return _recipeID; }
            set { _recipeID = value; }
        }
        
        private int _staffID;
        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }
        
        private string _CreatedOn;
        public string CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }
        
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public static string AddText = "Add to my favorite";
        public static string RemoveText = "Remove from my favorite";

        private static RecipeFavorite PopFavorite(SqlDataReader dr)
        {
            using (dr)
            {
                RecipeFavorite rf = new RecipeFavorite();

                if (dr.Read())
                {
                    rf.FavoriteID = Convert.ToInt32(dr["FavoriteID"]);
                    rf.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    rf.StaffID = Convert.ToInt32(dr["StaffID"]);
                    rf.CreatedOn = dr["CreatedOn"].ToString();
                    rf.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return rf;
            }
        }

        private static RecipeFavoirtes PopFavorites(SqlDataReader dr)
        {
            using (dr)
            {
                RecipeFavoirtes rfs = new RecipeFavoirtes();

                while (dr.Read())
                {
                    RecipeFavorite rf = new RecipeFavorite();

                    rf.FavoriteID = Convert.ToInt32(dr["FavoriteID"]);
                    rf.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    rf.StaffID = Convert.ToInt32(dr["StaffID"]);
                    rf.CreatedOn = dr["CreatedOn"].ToString();
                    rf.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    rfs.Add(rf);
                }

                return rfs;
            }
        }

        public static void UpdateReciepFavorite(int recipeID, int staffID, string actionText)
        {
            if (actionText == AddText)
            {
                RecipeFavoriteDB.UpdateRecipeFavorite(recipeID, staffID, true);
            }
            else
            {
                RecipeFavoriteDB.UpdateRecipeFavorite(recipeID, staffID, false);
            }
        }

        public static RecipeFavoirtes GetRecipeFavoritesByStaffID(int staffID)
        {
            return PopFavorites(RecipeFavoriteDB.SelectRecipeFavoriteByStaffID(staffID));
        }

        public static RecipeFavorite GetRecipeFavoritesByRecipeIDAndStaffID(int recipeID, int staffID)
        {
            return PopFavorite(RecipeFavoriteDB.SelectRecipeFavoriteByRecipeIDAndStaffID(recipeID, staffID));
        }
        
    }

    public class RecipeFavoirtes : List<RecipeFavorite> { }
}
