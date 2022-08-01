using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace SimpleServingsLibrary.Shared
{
    public class Site
    {
        //public const int ADMIN = 2;
        //public const int SERVICELINE = 999924;
        //public const int HPU = 999139;
        
        //public Site() { }
        //public Site(int siteID)
        //{
        //    GetSiteBySiteID(siteID);
        //}
        

        //#region Private Fields
        //private int siteID;
        //private string siteName;
        //private int siteCode;
        //private string factorsSiteCode;
        //private string streetAddress;
        //private string city;
        //private string zip;
        //private int state;
        //private string phone;
        //private string fax;
        //private int boroID;
        //private int createdBy;
        //private string createdOn;
        //private bool isActive;
        //#endregion

        //#region Public Properties
        //public int SiteID
        //{
        //    get { return siteID; }
        //    set { siteID = value; }
        //}
        //public string SiteName
        //{
        //    get { return siteName; }
        //    set { siteName = value; }
        //}
        //public int SiteCode
        //{
        //    get { return siteCode; }
        //    set { siteCode = value; }
        //}        
        //public string FactorsSiteCode
        //{
        //    get { return factorsSiteCode; }
        //    set { factorsSiteCode = value; }
        //}
        //public string StreetAddress
        //{
        //    get { return streetAddress; }
        //    set { streetAddress = value; }
        //}
        //public string City
        //{
        //    get { return city; }
        //    set { city = value; }
        //}
        //public string Zip
        //{
        //    get { return zip; }
        //    set { zip = value; }
        //}
        //public int State
        //{
        //    get { return state; }
        //    set { state = value; }
        //}
        //public string Phone
        //{
        //    get { return phone; }
        //    set { phone = value; }
        //}
        //public string Fax
        //{
        //    get { return fax; }
        //    set { fax = value; }
        //}
        //public int BoroID
        //{
        //    get { return boroID; }
        //    set { boroID = value; }
        //}
        //public string BoroghText
        //{
        //    get { return Code.DecodeCode(BoroID); }
        //}
        //public string FullAddress
        //{
        //    get { return StreetAddress +", "+ BoroghText +" " + zip; }
        //}
        //public int CreatedBy
        //{
        //    get { return createdBy; }
        //    set { createdBy = value; }
        //}
        //public string CreatedByText
        //{
        //    get { return Staff.GetStaffNameByStaffID(Convert.ToInt32(CreatedBy)); }
        //}  
        //public string CreatedOn
        //{
        //    get { return createdOn; }
        //    set { createdOn = value; }
        //}
        //public bool IsActive
        //{
        //    get { return isActive; }
        //    set { isActive = value; }
        //}
        //public string IsActiveText
        //{
        //    get
        //    {
        //        if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "true")
        //            return "Yes";
        //        else if (isActive.ToString() != null && isActive.ToString().Trim().ToLower() == "false")
        //            return "No";
        //        else
        //            return isActive.ToString();
        //    }
        //}
        //#endregion

        //#region Private Functions
        //private void PopSite(SqlDataReader dr)
        //{
        //    using (dr)
        //    {
        //        if (dr.Read())
        //        {
        //            SiteID = Convert.ToInt32(dr["SiteID"]);
        //            SiteName = Convert.ToString(dr["SiteName"]);
        //            SiteCode = Convert.ToInt32(dr["SiteCode"]);
        //            FactorsSiteCode = Convert.ToString(dr["FactorsSiteCode"]);
        //            StreetAddress = Convert.ToString(dr["StreetAddress"]);
        //            City = Convert.ToString(dr["City"]);
        //            Zip = Convert.ToString(dr["Zip"]);
        //            State = Convert.ToInt32(dr["State"]);
        //            Phone = Convert.ToString(dr["Phone"]);
        //            BoroID = Convert.ToInt32(dr["BoroID"]);
        //            CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
        //            CreatedOn = dr["CreatedOn"].ToString();
        //            IsActive = Convert.ToBoolean(dr["IsActive"]);
        //        }
        //    }
        //}
        //private static Sites PopSites(SqlDataReader dr)
        //{
        //    Sites sites = new Sites();
        //    Site site;
        //    using (dr)
        //    {
        //        while (dr.Read())
        //        {
        //            site = new Site();
        //            site.SiteID = Convert.ToInt32(dr["SiteID"]);
        //            site.SiteName = Convert.ToString(dr["SiteName"]);
        //            site.SiteCode = Convert.ToInt32(dr["SiteCode"]);
        //            site.FactorsSiteCode = Convert.ToString(dr["FactorsSiteCode"]);
        //            site.StreetAddress = Convert.ToString(dr["StreetAddress"]);
        //            site.City = Convert.ToString(dr["City"]);
        //            site.Zip = Convert.ToString(dr["Zip"]);
        //            site.State = Convert.ToInt32(dr["State"]);
        //            site.Phone = Convert.ToString(dr["Phone"]);
        //            site.BoroID = Convert.ToInt32(dr["BoroID"]);
        //            site.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
        //            site.CreatedOn = dr["CreatedOn"].ToString();
        //            site.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            sites.Add(site);
        //        }
        //    }
        //    return sites;
        //}
        //private void ValidateSite()
        //{
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        ArrayList values = new ArrayList(new Object[] { IsActive, SiteCode, SiteName, CreatedBy });
        //        ArrayList fieldNames = new ArrayList(new string[] { "Is Active", "Site Code", "Site Name", "Created By" });
        //        sb.Append(Validation.AreNotEmpty(values, fieldNames));

        //        if (sb.Length != 0)
        //            throw new Exception(sb.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public static DateTime SiteHashDate;

        //public static Hashtable SiteList = GetSiteList();

        //private static Hashtable GetSiteList()
        //{
           
        //        Hashtable ht = new Hashtable();
        //        try
        //        {
        //            SqlDataReader dr = SiteDB.GetAllSites();
        //            using (dr)
        //            {
        //                while (dr.Read())
        //                {
        //                    ht.Add(Convert.ToInt32(dr["SiteCode"]), dr["SiteName"].ToString());
        //                }
        //            }
        //            SiteHashDate = DateTime.Now;
        //        }
        //        catch { }
        //        return ht;
            
        //}
        //#endregion

        //#region Public Methods

        //public int AddSite()
        //{
        //    ValidateSite();
        //    int siteID = SiteDB.AddSite(SiteName,
        //        SiteCode,
        //        FactorsSiteCode,
        //        StreetAddress,
        //        City,
        //        Zip,
        //        State,
        //        Phone,
        //        Fax,
        //        BoroID,
        //        CreatedBy);
        //    SiteList.Add(SiteCode, SiteName);
        //    return siteID;
        //}
        //public  void GetSiteBySiteID(int siteID)
        //{
        //    PopSite(SiteDB.GetSiteBySiteID(siteID));
        //}
        //public  void GetSiteBySiteCode(int siteCode)
        //{
        //    PopSite(SiteDB.GetSiteBySiteCode(siteCode));
        //}
        //public string GetSiteByFactorsSiteCode(string siteCode)
        //{
        //    return SiteDB.GetSiteByFactorsSiteCode(siteCode);
        //}
        //public static int GetTransferSiteCodeByZipCode(string zipCode)
        //{
        //    return SiteDB.GetTransferSiteCodeByZipCode(zipCode);
        //}
        //public static string GetZipCodeBySiteCode(string siteCode)
        //{
        //    return SiteDB.GetZipCodeBySiteCode(siteCode);
        //}
        ////public static string GetSiteNameBySiteCode(int siteCode)
        ////{
        ////    return SiteDB.GetSiteNameBySiteCode(siteCode);
        ////}

        //public static Sites GetAllSites()
        //{
        //    return PopSites(SiteDB.GetAllSites());
        //}
        //public bool EditSite()
        //{
        //    ValidateSite();
        //    return SiteDB.EditSite(SiteID,
        //                            SiteName,
        //                            SiteCode,
        //                            FactorsSiteCode,
        //                            StreetAddress,
        //                            City,
        //                            Zip,
        //                            State,
        //                            Phone,
        //                            Fax,
        //                            IsActive,
        //                            BoroID);
        //}
        //public static string GetSiteNameBySiteCode(int siteCode)
        //{

        //    try
        //    {
        //        if (siteCode == 0)
        //            return String.Empty;
        //        else
        //        {
        //            //check if hashtable has expired
        //            TimeSpan span = DateTime.Now.Subtract(SiteHashDate);
        //            int refreshTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["HashSpanInHours"]);
        //            TimeSpan refreshTimeSpan = new TimeSpan(refreshTime, 0, 0);// new TimeSpan(h,mn,s)

        //            if (span >refreshTimeSpan)
        //            { SiteList = GetSiteList(); }
        //            return SiteList[siteCode].ToString();
        //        }
        //    }
        //    catch
        //    {
        //        return String.Empty;
        //    }
        //}
        
        
       

        //#endregion
    }
    public class Sites : ArrayList { }
}

