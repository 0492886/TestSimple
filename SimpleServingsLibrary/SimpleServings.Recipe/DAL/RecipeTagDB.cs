using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SimpleServingsLibrary.Shared;
using System.Data.Common;
using System.Data;

namespace SimpleServingsLibrary.Recipe
{
    class RecipeTagDB
    {

        internal static int AddRecipeTag(int recipeID, int tagID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddRecipeTag");
                db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
                db.AddInParameter(cmd, "@tagID", DbType.Int32, tagID);                
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal static void AddCategoryandTagForRecipe(int RecipeID, List<int> CategoryIDs, List<int> TagIDs, int StaffID)
        {

            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_AddRecipeTagCategory");
                db.AddInParameter(cmd, "@recipeID", DbType.Int32, RecipeID);
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, StaffID);

                var table = new DataTable();
                table.Columns.Add("TagIDs", typeof(string));
                foreach (int i in TagIDs)
                {
                    table.Rows.Add(i);
                }
                SqlParameter sp = new SqlParameter();
                sp.SqlDbType = SqlDbType.Structured;
                sp.ParameterName = "@Tags";
                sp.Value = table;
                cmd.Parameters.Add(sp);

                var table1 = new DataTable();
                table1.Columns.Add("CategoryIDs", typeof(string));
                foreach (int c in CategoryIDs)
                {
                    table1.Rows.Add(c);
                }
                SqlParameter sp1 = new SqlParameter();
                sp1.SqlDbType = SqlDbType.Structured;
                sp1.ParameterName = "@Categories";
                sp1.Value = table1;
                cmd.Parameters.Add(sp1);
                
                db.ExecuteScalar(cmd);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

 
        }

        internal static bool RemoveRecipeTagsByRecipeID(int recipeID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_RemoveRecipeTagsByRecipeID");
                db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static SqlDataReader GetRecipeTagByRecipeTagID(int recipeTagID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipeTagByRecipeTagID");
            db.AddInParameter(cmd, "@recipeTagID", DbType.Int32, recipeTagID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Recipe Tag By RecipeTagID did not return a record!");
            }
        }

        internal static SqlDataReader GetCategoriesandTagsByRecipeTID(int recipeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_CategoriesTagsByRecipeID");
            db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Procedure did not return a record!");
            }
        }

        //Mandy add
        internal static SqlDataReader GetTagIdByRecipeID(int recipeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_TagIdByRecipeID");
            db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Procedure did not return a record!");
            }
        }


        internal static SqlDataReader GetRecipeTagsByRecipeID(int recipeID)
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_RecipeTagsByRecipeID");
            db.AddInParameter(cmd, "@recipeID", DbType.Int32, recipeID);
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get Recipe Tags By RecipeID did not return a record!");
            }
        }

        internal static SqlDataReader GetAllRecipeTags()
        {
            Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
            DbCommand cmd = db.GetStoredProcCommand("Sp_Get_AllRecipeTags");
            SqlDataReader dr = (SqlDataReader)db.ExecuteReader(cmd);
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                throw new Exception("Get All Recipe Tags did not return a record!");
            }
        }

        internal static void AutoUpdateRecipeTags(int StaffID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(GlobalEnum.DATABASENAME);
                DbCommand cmd = db.GetStoredProcCommand("Sp_Auto_Update_RecipeTag");
                db.AddInParameter(cmd, "@StaffID", DbType.Int32, StaffID);
                db.ExecuteNonQuery(cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
