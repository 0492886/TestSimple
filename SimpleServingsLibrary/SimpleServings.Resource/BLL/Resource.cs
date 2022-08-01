using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SimpleServingsLibrary.Resource
{
    [Serializable]
    public class Resource: IEquatable<Resource>
    {
        public int ID { get; set; }
        public string ResourceText { get; set; }
        public string ResourceUrl { get; set; }
        public int ResourceType { get; set; }
        public string ResourceTypeText { get; set; }


        #region Private Methods

        private void PopResource(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    ID = Convert.ToInt32(dr["ID"]);
                    ResourceText = Convert.ToString(dr["ResourceText"]);
                    ResourceUrl = Convert.ToString(dr["ResourceUrl"]);
                    ResourceType = Convert.ToInt32(dr["ResourceType"]);
                    ResourceTypeText = Convert.ToString(dr["ResourceTypeText"]);
                }
            }
        }

        private static Resources PopResources(SqlDataReader dr)
        {
            Resources resources = new Resources();
            Resource resource;
            using (dr)
            {
                while (dr.Read())
                {
                    resource = new Resource();
                    resource.ID = Convert.ToInt32(dr["ID"]);
                    resource.ResourceText = Convert.ToString(dr["ResourceText"]);
                    resource.ResourceUrl = Convert.ToString(dr["ResourceUrl"]);
                    resource.ResourceType = Convert.ToInt32(dr["ResourceType"]);
                    resource.ResourceTypeText = Convert.ToString(dr["ResourceTypeText"]);

                    resources.Add(resource);
                }
            }
            return resources;

        }

        #endregion

        #region Public Methods

        public int AddResource()
        {
            return ResourceDB.AddResource(ResourceText, ResourceUrl,ResourceType);
        }
        public static bool RemoveResource(int id)
        {
            return ResourceDB.RemoveResource(id);
        }
        public static Resources GetAll()
        {
            return PopResources(ResourceDB.GetAll());
        }
        public void GetResourceById(int id)
        {
             PopResource(ResourceDB.GetResourceById(id));
        }
        public static Resources GetResourcesByType(int resourceType)
        {
            return PopResources(ResourceDB.GetResourcesByType(resourceType));
        }

        #endregion



        public bool Equals(Resource other)
        {
            return (this.ID == other.ID);
        }
    }
    [Serializable]
    public class Resources : List<Resource>
    {
       
    }
}
