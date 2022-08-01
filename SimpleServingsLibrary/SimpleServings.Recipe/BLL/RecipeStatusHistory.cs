using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace SimpleServingsLibrary.Recipe
{
    public class RecipeStatusHistory
    {


        #region Public Properties

        public int RecipeStatusHistoryID
        {
            get;
            set;
        }

        public int RecipeID
        {
            get;
            set;
        }

        public int StatusID
        {
            get;
            set;
        }

        public string StatusText
        {
            get { return SimpleServingsLibrary.Shared.Code.DecodeCode(StatusID); }
        }



        public string StatusDate
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string CreatedOn
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }

        public string CreatedByText
        {
            get { return SimpleServingsLibrary.Shared.Staff.GetStaffNameByStaffID(CreatedBy); }
        }



        #endregion

        #region Private Methods

        private void PopCaseStatusHistory(SqlDataReader dr)
        {
            if (dr.Read())
            {
                RecipeStatusHistoryID = Convert.ToInt32(dr["RecipeStatusHistoryID"]);
                RecipeID = Convert.ToInt32(dr["RecipeID"]);
                StatusID = Convert.ToInt32(dr["StatusID"]);
                StatusDate = Convert.ToString(dr["StatusDate"]);
                Comments = Convert.ToString(dr["Comments"]);
                CreatedOn = Convert.ToString(dr["CreatedOn"]);
                CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            }
            dr.Close();
        }

        private static RecipeStatusHistories PopCaseStatusHistories(SqlDataReader dr)
        {
            RecipeStatusHistories statuses = new RecipeStatusHistories();
            RecipeStatusHistory recipeStatus;
            while (dr.Read())
            {
                recipeStatus = new RecipeStatusHistory();
                recipeStatus.RecipeStatusHistoryID = Convert.ToInt32(dr["RecipeStatusHistoryID"]);
                recipeStatus.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                recipeStatus.StatusID = Convert.ToInt32(dr["StatusID"]);
                recipeStatus.StatusDate = Convert.ToString(dr["StatusDate"]);
                recipeStatus.Comments = Convert.ToString(dr["Comments"]);
                recipeStatus.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                recipeStatus.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                statuses.Add(recipeStatus);
            }
            dr.Close();
            return statuses;
        }
        #endregion

        # region Public Methods

        public static RecipeStatusHistories GetRecipeStatusHistoryByRecipeID(int recipeID)
        {
            return PopCaseStatusHistories(RecipeStatusHistoryDB.GetRecipeStatusHistoryByRecipeID(recipeID));
        }

        #endregion


    }
    public class RecipeStatusHistories : List<RecipeStatusHistory> { }
}

