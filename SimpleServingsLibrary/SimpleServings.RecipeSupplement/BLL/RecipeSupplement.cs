using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.RecipeSupplement
{
    public class RecipeSupplement
    {
        private int _recipeSupplementID;
        public int RecipeSupplementID
        {
            get { return _recipeSupplementID; }
            set { _recipeSupplementID = value; }
        }
        
        private int _recipeID;
        public int RecipeID
        {
            get { return _recipeID; }
            set { _recipeID = value; }
        }
        
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string DescriptionSyntax
        {
            get { return Symbol.FormatToSyntax(Description); }
        }

        public string DesriptionHtml
        {
            get { return Symbol.FormatToHtml(Description); }
        }

        public string DescriptionInOrder
        {
            get
            {
                if (RecipeSupType == GlobalEnum.RecipeSupType_Directions)
                {
                    return string.Format("{0}. {1}", Orders, DesriptionHtml);
                }
                else
                {
                    return DesriptionHtml;
                }
            }
        }

        private int _recipeSupType;
        public int RecipeSupType
        {
            get { return _recipeSupType; }
            set { _recipeSupType = value; }
        }
        
        private int _orders;
        public int Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        
        private int _createdBy;
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        
        private string _createdOn;
        public string CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
        
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public RecipeSupplement() { }

        public RecipeSupplement(int recipeSupplementID, string description, int recipeSupType, int orders, int createdBy)
        {
            _recipeSupplementID = recipeSupplementID;
            _description = description;
            _recipeSupType = recipeSupType;
            _orders = orders;
            _createdBy = createdBy;
        }

        private static RecipeSupplement PopRecipeSupplement(SqlDataReader dr)
        {
            using (dr)
            {
                RecipeSupplement rs = new RecipeSupplement();

                if (dr.Read())
                {
                    rs.RecipeSupplementID = Convert.ToInt32(dr["RecipeSupplementID"]);
                    rs.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    rs.Description = dr["Description"].ToString();
                    rs.RecipeSupType = Convert.ToInt32(dr["RecipeSupType"]);
                    rs.Orders = Convert.ToInt32(dr["Orders"]);
                    rs.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    rs.CreatedOn = dr["CreatedOn"].ToString();
                    rs.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return rs;
            }
        }

        private static RecipeSupplements PopRecipeSupplementList(SqlDataReader dr)
        {
            using (dr)
            {
                RecipeSupplements rsList = new RecipeSupplements();

                while (dr.Read())
                {
                    RecipeSupplement rs = new RecipeSupplement();

                    rs.RecipeSupplementID = Convert.ToInt32(dr["RecipeSupplementID"]);
                    rs.RecipeID = Convert.ToInt32(dr["RecipeID"]);
                    rs.Description = dr["Description"].ToString();
                    rs.RecipeSupType = Convert.ToInt32(dr["RecipeSupType"]);
                    rs.Orders = Convert.ToInt32(dr["Orders"]);
                    rs.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    rs.CreatedOn = dr["CreatedOn"].ToString();
                    rs.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    rsList.Add(rs);
                }
                
                return rsList;
            }
        }

        public void AddRecipeSupplement(int recipeID)
        {
            AddRecipeSupplment(recipeID, DescriptionSyntax, RecipeSupType, Orders, CreatedBy);
        }

        public void AddRecipeSupplement(int recipeID, int orders)
        {
            AddRecipeSupplment(recipeID, DescriptionSyntax, RecipeSupType, orders, CreatedBy);
        }

        public static void AddRecipeSupplment(int recipeID, string description, int recipeSupType, int orders, int createdBy)
        {
            RecipeSupplementDB.AddRecipeSupplement(recipeID, description, recipeSupType, orders, createdBy);
        }

        public static RecipeSupplements GetRecipeSupplementsByRecipeIDAndType(int recipeID, int recipeSupType)
        {
            return PopRecipeSupplementList(RecipeSupplementDB.GetRecipeSupplementsByRecipeIDAndType(recipeID, recipeSupType));
        }

        

        public static void RemoveRecipeSupplementByID(int recipeID)
        {
            RecipeSupplementDB.RemoveRecipeSupplementByID(recipeID);
        }

        public static void RemoveRecipeSupplementByRecipeIDAndType(int recipeID, int recipeSupType)
        {
            RecipeSupplementDB.RemoveRecipeSupplementByRecipeIDAndType(recipeID, recipeSupType);
        }

        public void EditRecipeSupplementOrderByID(int orders)
        {
            EditRecipeSupplementOrderByID(RecipeSupplementID, orders);
        }

        public static void EditRecipeSupplementOrderByID(int recipeSupplementID, int orders)
        {
            RecipeSupplementDB.EditRecipeSupplementOrderByID(recipeSupplementID, orders);
        }

    }

    public class RecipeSupplements : List<RecipeSupplement> { }

    #region Recipe Supplement Codes
    //added 1-26-2016
    public class RecipeSuppCode
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        private int _recipeSupplementID;
        public int RecipeSupplementID
        {
            get { return _recipeSupplementID; }
            set { _recipeSupplementID = value; }
        }

        private int _codeId;
        public int CodeId
        {
            get { return _codeId; }
            set { _codeId = value; }
        }

        private int _suppTypeId;
        public int SuppTypeID
        {
            get { return _suppTypeId; }
            set { _suppTypeId = value; }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _createdBy;
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        private string _createdOn;
        public string CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        private bool _isMatch;
        public bool IsMatch
        {
            get { return _isMatch; }
            set { _isMatch = value; }
        }

        public RecipeSuppCode(int recipeSuppType)
        {
            this.SuppTypeID = recipeSuppType;
        }

        private static RecipeSuppCode PopRecipeSuppCode(SqlDataReader dr, int suppTypeId)
        {
            using (dr)
            {
                RecipeSuppCode rsc = new RecipeSuppCode(suppTypeId);

                if (dr.Read())
                {
                    rsc.IsSelected = Convert.ToBoolean(dr["IsSelected"]);
                    rsc.RecipeSupplementID = Convert.ToInt32(dr["RecipeSupplementID"]);
                    rsc.CodeId = Convert.ToInt32(dr["CodeID"]);
                    rsc.Type = dr["CodeType"].ToString();
                    rsc.Description = dr["CodeDescription"].ToString();
                    rsc.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    rsc.CreatedOn = dr["CreatedOn"].ToString();
                    rsc.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    rsc.IsMatch = Convert.ToBoolean(dr["IsMatch"]);
                }

                return rsc;
            }
        }

        private static RecipeSuppCodes PopRecipeSuppCodeList(SqlDataReader dr, int suppTypeId)
        {
            using (dr)
            {
                RecipeSuppCodes rsList = new RecipeSuppCodes();

                while (dr.Read())
                {
                    RecipeSuppCode rsc = new RecipeSuppCode(suppTypeId);

                    rsc.IsSelected = Convert.ToBoolean(dr["IsSelected"]);
                    rsc.RecipeSupplementID = Convert.ToInt32(dr["RecipeSupplementID"]);
                    rsc.CodeId = Convert.ToInt32(dr["CodeID"]);
                    rsc.Type = dr["CodeType"].ToString();
                    rsc.Description = dr["CodeDescription"].ToString();
                    rsc.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    rsc.CreatedOn = dr["CreatedOn"].ToString();
                    rsc.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    rsc.IsMatch = Convert.ToBoolean(dr["IsMatch"]);

                    rsList.Add(rsc);
                }

                return rsList;
            }
        }

        public static RecipeSuppCodes GetRecipeSuppCodesByRecipeType(int recipeID, int recipeSupType)
        {
            return PopRecipeSuppCodeList(RecipeSupplementDB.GetRecipeSuppCodesByRecipeIDAndType(recipeID, recipeSupType), recipeSupType);
        }

    }
    //added 1-26-2016
    public class RecipeSuppCodes : List<RecipeSuppCode> { }
    #endregion

}
