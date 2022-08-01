using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;


namespace SimpleServingsLibrary.Shared
{
    public class Link
    {
        #region Constructors
        public Link()
        { }
        public Link(int linkID)
        {
            GetLinkByLinkID(linkID);
        }
        #endregion


        #region Private Fields

        private int linkID;
        private string hyperlink;
        private int linkType;
        private int category;
        private string description;
        private bool isActive;
        private int createdBy;
        private string createdOn;
        private string comment;
        private string iconLink;
        private string classType;

        #endregion

        #region Public Properties

        public int LinkID
        {
            get { return linkID; }
            set { linkID = value; }
        }
        public string Hyperlink
        {
            get { return hyperlink; }
            set { hyperlink = value; }
        }
        public int LinkType
        {
            get { return linkType; }
            set { linkType = value; }
        }

        public string LinkTypeText
        {
            get { return Code.DecodeCode(LinkType); }
        }
        public int Category
        {
            get { return category; }
            set { category = value; }
        }

        public string CategoryText
        {
            get { return Code.DecodeCode(Category); }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public string IsActiveText
        {
            get
            {
                if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "true")
                    return "Yes";
                else if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "false")
                    return "No";
                else
                    return isActive.ToString();
            }
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
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public string IconLink
        {
            get { return iconLink; }
            set { iconLink = value; }
        }
        public string ClassType
        {
            get { return classType; }
            set { classType = value; }
        }

        #endregion

        #region Private Methods

        private void PopLink(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    LinkID = Convert.ToInt32(dr["LinkID"]);
                    Hyperlink = Convert.ToString(dr["HyperLink"]);
                    LinkType = Convert.ToInt32(dr["LinkType"]);
                    Category = Convert.ToInt32(dr["Category"]);
                    Description = Convert.ToString(dr["Description"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    Comment = Convert.ToString(dr["Comment"]);
                    IconLink = Convert.ToString(dr["IconLink"]);
                    ClassType = Convert.ToString(dr["ClassType"]);

                }
            }
        }

        private static Links PopLinks(SqlDataReader dr)
        {
            Links links = new Links();
            Link link;
            using (dr)
            {
                while (dr.Read())
                {
                    link = new Link();
                    link.LinkID = Convert.ToInt32(dr["LinkID"]);
                    link.Hyperlink = Convert.ToString(dr["HyperLink"]);
                    link.LinkType = Convert.ToInt32(dr["LinkType"]);
                    link.Category = Convert.ToInt32(dr["Category"]);
                    link.Description = Convert.ToString(dr["Description"]);
                    link.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    link.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                    link.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    link.Comment = Convert.ToString(dr["Comment"]);
                    link.IconLink = Convert.ToString(dr["IconLink"]);
                    link.ClassType = Convert.ToString(dr["ClassType"]);
                    links.Add(link);
                }
            }
            return links;

        }


        private void ValidateLink()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList values = new ArrayList(new Object[] { Hyperlink, LinkType, Category, IsActive, CreatedBy });
                ArrayList fieldNames = new ArrayList(new string[] { "Hyperlink", "LinkType", "Category", "IsActive", "CreatedBy" });
                sb.Append(Validation.AreNotEmpty(values, fieldNames));

                if (sb.Length != 0)
                    throw new Exception(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region Public Methods

        public int AddLink()
        {
            ValidateLink();
            return LinkDB.AddLink(Hyperlink, LinkType, Category, Description, CreatedBy, Comment, IconLink);
        }

        public bool EditLink()
        {
            ValidateLink();
            return LinkDB.EditLink(LinkID, Hyperlink, LinkType, Category, Description, CreatedBy, Comment, IconLink);
        }

        public void GetLinkByLinkID(int linkID)
        {
            PopLink(LinkDB.GetLinkByLinkID(linkID));
        }

        public static Links GetAllLinks()
        {
            return PopLinks(LinkDB.GetAllLinks());
        }

        public static Links GetLinksByUserGroup(int userGroupID)
        {
            return PopLinks(LinkDB.GetLinksByUserGroup(userGroupID));
        }

        public static Links GetLinksByLinkType(int linkType)
        {
            return PopLinks(LinkDB.GetLinksByLinkType(linkType));
        }

        public static Links GetLinksByLinkTypeAndUserGroup(int linkType, int userGroupID)
        {
            return PopLinks(LinkDB.GetLinksByLinkTypeAndUserGroup(linkType, userGroupID));
        }

        public static Links GetLinksByCategory(int category)
        {
            return PopLinks(LinkDB.GetLinksByCategory(category));
        }

        public static Links GetLinksByCategoryAndUserGroup(int category, int userGroupID)
        {
            return PopLinks(LinkDB.GetLinksByCategoryAndUserGroup(category, userGroupID));
        }

        #endregion


    }
    public class Links : ArrayList { }
}

