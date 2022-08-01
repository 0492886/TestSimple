using System;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
namespace SimpleServingsLibrary.Shared
{
    [Serializable]
    public class Staff : BaseContact
    {

        public Staff()
        {
        }
        public Staff(int staffID)
        {
            GetStaffByStaffID(staffID);
        }

        #region private fields
        private int staffID;
        private int siteCode;
        private string staffCode;
        private int managedBy;
        private int userGroup;
        private int unitID;
        private string userName;
        private string password;
        private string iPAddress;
        private string firstName;
        private string lastName;
        private bool forcePasswordChange;
        //private int accessLevel;
        private int supplierID;
        private bool isLocked;
        private int loginAttempt;
        //10-6-2016
        private string title;
        //11-3-2016
        private int titleCode;
        //10-25-2016
        private int contactID;


        #endregion

        #region public properties

        public int StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
       
        public string IPAddress
        {
            get { return iPAddress; }
            set { iPAddress = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value.Trim(); }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string FullName
        {
            get { return string.Format("{0}, {1}", LastName, FirstName); }
        }

        public string HomePhone
        {
            get { return Phone1; }
            set { Phone1 = value; }
        }
        public string WorkPhone
        {
            get { return Phone2; }
            set { Phone2 = value; }
        }
        public int ManagedBy
        {
            get { return managedBy; }
            set { managedBy = value; }
        }
        public int UnitID
        {
            get { return unitID; }
            set { unitID = value; }
        }
        public string UnitName
        {
            get { return Code.DecodeCode(UnitID); }
        }

        
        public string StreetAddress1
        {
            get { return StreetAddress; }
            set { StreetAddress = value; }
        }
        public string StreetAddress2
        {
            get { return AptNumber; }
            set { AptNumber = value; }
        }

        public string StaffCode
        {
            get { return staffCode; }
            set { staffCode = value; }
        }
        public int SiteCode
        {
            get { return siteCode; }
            set { siteCode = value; }
        }
        
        

        public string Password
        {
            get { return password; }
            set { password = value.Trim(); }
        }
        public int UserGroup
        {
            get { return userGroup; }
            set { userGroup = value; }
        }
        public string UserGroupText
        {
            get
            {
                return SimpleServingsLibrary.Shared.UserGroup.GetUserGroupNameByID(UserGroup);
            }
        }
       
        public int NoteType
        {
            get { return GlobalEnum.StaffNoteType; }
        }
        //public int AccessLevel
        //{
        //    get { return accessLevel; }
        //    set { accessLevel = value; }
        //}
        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }
       

        public string SupervisorName
        {

            get
            {
                try
                {
                    if (ManagedBy != 0 )
                    {
                        //check if hashtable has expired
                        TimeSpan span = DateTime.Now.Subtract(StaffHashDate);
                        int refreshTime = Convert.ToInt32(ConfigurationManager.AppSettings["HashSpanInHours"]);
                        TimeSpan refreshTimeSpan = new TimeSpan(refreshTime, 0, 0);// new TimeSpan(h,mn,s)
                        if (span >refreshTimeSpan)
                        { StaffList = GetStaffList(); }
                        return StaffList[ManagedBy].ToString();
                    }
                    else
                        return "";
                }
                catch
                {
                    return "";
                }
            }
        }

        public bool IsAdmin
        {
            get { return (UserGroup == SimpleServingsLibrary.Shared.UserGroup.ADMIN); }
        }

        public bool ForcePasswordChange
        {
            get { return forcePasswordChange; }
            set { forcePasswordChange = value; }
        }

        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }

        public int LoginAttempt
        {
            get { return loginAttempt; }
            set { loginAttempt = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        //11-3-2016
        public int TitleCode
        {
            get { return titleCode; }
            set { titleCode = value; }
        }
        //10-25-2016
        public int DFTAContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }

        public static Hashtable StaffList = GetStaffList();
        public static DateTime StaffHashDate;

        private static Hashtable GetStaffList()
        {
           
                Hashtable ht = new Hashtable();
                try
                {
                    SqlDataReader dr = StaffDB.GetAllStaff(true);
                    using (dr)
                    {
                        while (dr.Read())
                        {
                            ht.Add(Convert.ToInt32(dr["StaffID"]), string.Format("{1}, {0}", dr["FirstName"].ToString(), dr["LastName"].ToString()));
                        }
                    }
                    StaffHashDate = DateTime.Now;
                    
                }
                catch {}
                return ht;

          
        }
        #endregion

        #region private methods

        private static Staffs PopStaffs(SqlDataReader dr)
        {
            Staffs staffs = new Staffs();
            Staff staff;
            using (dr)
            {
                while (dr.Read())
                {
                    staff = new Staff();
                    //try
                    //{

                

                        staff.StaffID = Convert.ToInt32(dr["StaffID"]);
                        staff.FirstName = dr["FirstName"].ToString();
                        staff.LastName = dr["LastName"].ToString();
                        staff.HomePhone = dr["HomePhone"].ToString();
                        staff.WorkPhone = dr["WorkPhone"].ToString();
                        staff.StreetAddress1 = dr["StreetAddress1"].ToString();
                        staff.StreetAddress2 = dr["StreetAddress2"].ToString();
                        staff.City = Convert.ToString(dr["City"]);
                        staff.ZipCode = dr["ZipCode"].ToString();
                        staff.SiteCode = Convert.ToInt32(dr["SiteCode"]);
                        staff.StaffCode = dr["StaffCode"].ToString();
                        staff.Fax = dr["Fax"].ToString();
                        staff.ManagedBy = Convert.ToInt32(dr["ManagedBy"]);
                        staff.UserGroup = Convert.ToInt32(dr["UserGroup"]);
                        staff.UnitID = Convert.ToInt32(dr["ProgramCD"]);
                        staff.UserName = dr["UserName"].ToString();
                        staff.Password = dr["Password"].ToString();
                        staff.IPAddress = dr["IPAddress"].ToString();
                        staff.Email = dr["Email"].ToString();
                        staff.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                        staff.CreatedOn = dr["CreatedOn"].ToString();
                        //staff.AccessLevel = Convert.ToInt32(dr["AccessLevel"]);
                        staff.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        staff.State = Convert.ToInt32(dr["State"]);
                        staff.ForcePasswordChange = Convert.ToBoolean(dr["ForcePasswordChange"]);
                        staff.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        staff.IsLocked = (dr["IsLocked"] != null) ? Convert.ToBoolean(dr["IsLocked"]) : false;
                        staff.LoginAttempt = (dr["LoginAttempt"] != null) ? Convert.ToInt32(dr["LoginAttempt"]) : 0;
                        //10-06-2016
                        //dr["Title"] != System.DBNull.Value)
                        //{
                        //    staff.Title = dr["Title"].ToString();
                        //}
                        staffs.Add(staff);
                    //}
                    //catch
                    //{
                    //   var err = Convert.ToInt32(dr["StaffID"]);
                    //}
                }

            }
            return staffs;
        }

        private static string PopStaffEmailByStaffId(SqlDataReader dr)
        {
            string staffEmail = "";
            using (dr)
            {
                if (dr.Read())
                {
                    staffEmail = dr["Email"].ToString();

                }
                
            }
            return staffEmail;
            
        }

        private void PopStaff(SqlDataReader dr)
        {
            using (dr)
            {
                if (dr.Read())
                {
                    StaffID = Convert.ToInt32(dr["StaffID"]);
                    FirstName = dr["FirstName"].ToString();
                    LastName = dr["LastName"].ToString();
                    HomePhone = dr["HomePhone"].ToString();
                    WorkPhone = dr["WorkPhone"].ToString();
                    StreetAddress1 = dr["StreetAddress1"].ToString();
                    StreetAddress2 = dr["StreetAddress2"].ToString();
                    City = Convert.ToString(dr["City"]);
                    ZipCode = dr["ZipCode"].ToString();
                    SiteCode = Convert.ToInt32(dr["SiteCode"]);
                    StaffCode = dr["StaffCode"].ToString();
                    Fax = dr["Fax"].ToString();
                    ManagedBy = Convert.ToInt32(dr["ManagedBy"]);
                    UserGroup = Convert.ToInt32(dr["UserGroup"]);
                    UnitID = Convert.ToInt32(dr["ProgramCD"]);
                    UserName = dr["UserName"].ToString();
                    Password = dr["Password"].ToString();
                    IPAddress = dr["IPAddress"].ToString();
                    Email = dr["Email"].ToString();
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    CreatedOn = dr["CreatedOn"].ToString();
                    //AccessLevel = Convert.ToInt32(dr["AccessLevel"]);
                    SupplierID = Convert.ToInt32(dr["SupplierID"]);
                    State = Convert.ToInt32(dr["State"]);
                    ForcePasswordChange = Convert.ToBoolean(dr["ForcePasswordChange"]);
                    IsActive = Convert.ToBoolean(dr["IsActive"]);
                    IsLocked = (dr["IsLocked"] != null) ? Convert.ToBoolean(dr["IsLocked"]) : false;
                    LoginAttempt = (dr["LoginAttempt"] != null) ? Convert.ToInt32(dr["LoginAttempt"]) : 0;
                    //10-06-2016
                    //if (dr["Title"] != System.DBNull.Value)
                    //{
                    //    Title = dr["Title"].ToString();
                    //}
                }
            }
        }

        private void ValidateStaff()
        {
            StringBuilder sb = new StringBuilder();
            //Commented by Kamlesh on 10/11/2017 Password check is not required


            //ArrayList values = new ArrayList(new Object[] { FullName, UserName, Password, CreatedBy });
            //ArrayList fieldNames = new ArrayList(new string[] { "FullName", "UserName", "Password", "CreatedBy" });
            // Comments end here 10/11/2017 

            ArrayList values = new ArrayList(new Object[] { FullName, UserName,  CreatedBy });
            ArrayList fieldNames = new ArrayList(new string[] { "FullName", "UserName",  "CreatedBy" });
            sb.Append(Validation.AreNotEmpty(values, fieldNames));

            if (Validation.IsNotEmpty(Password) && !Validation.IsValidPassword(Password))
                sb.Append("Password must be at least 6 characters long with at least one number.<br>");
            if (Validation.IsNotEmpty(Email) && !Validation.IsValidEMail(Email))
                sb.Append("Invalid Email address!<br>");
            if (sb.Length != 0)
                throw new Exception(sb.ToString());

        }

        //11-03-2016
        private static Staffs PopStaffContactList(SqlDataReader dr)
        {
            Staffs staffs = new Staffs();
            Staff staff;
            using (dr)
            {
                while (dr.Read())
                {
                    staff = new Staff();

                    staff.StaffID = Convert.ToInt32(dr["StaffID"]);
                    staff.FirstName = dr["FirstName"].ToString();
                    staff.LastName = dr["LastName"].ToString();
                    staff.WorkPhone = dr["WorkPhone"].ToString();
                    staff.Title = dr["Title"].ToString();
                    staff.Email = dr["Email"].ToString();
                    staff.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                    staff.CreatedOn = dr["CreatedOn"].ToString();
                    //10-25-2016
                    if (dr["ID"] != null && dr["ID"] != System.DBNull.Value)
                    {
                        staff.DFTAContactID = Convert.ToInt32(dr["ID"]);
                    }
                    if (dr["TitleCode"] != null && dr["TitleCode"] != System.DBNull.Value)
                    {
                        staff.TitleCode = Convert.ToInt32(dr["TitleCode"]);
                    }
                    //staff.AccessLevel = Convert.ToInt32(dr["AccessLevel"]);
                    //if (dr["IsActive"] != System.DBNull.Value)
                    //{
                    //    staff.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    //}

                    staffs.Add(staff);
                }

            }
            return staffs;
        }
        
        #endregion

        #region Public Methods

        public int AddStaff()
        {
            ValidateStaff();

            int staffID = StaffDB.AddStaff(FirstName, LastName, HomePhone, WorkPhone, StreetAddress1, StreetAddress2, City, ZipCode, SiteCode, StaffCode, Fax, ManagedBy, UserGroup, UnitID, UserName, Password, IPAddress, Email, CreatedBy,
                SupplierID, State);
            StaffList.Add(staffID, FullName);
            //
            //EmailManagement.EmailLog emailLog = new EmailManagement.EmailLog();
            //emailLog.EmailableActionID = EmailManagement.EmailableAction.NEWSTAFF;
            //emailLog.Parameters = staffID.ToString();
            //emailLog.AddEmailLog();

            //
            
            return staffID;

        }

        public void GetStaffByStaffID(int staffID)
        {
            PopStaff(StaffDB.GetStaffByStaffID(staffID));
        }
       

        public bool EditStaff()
        {
            ValidateStaff();
           
            bool edited = false;
            edited = StaffDB.EditStaff(StaffID, FirstName, LastName, HomePhone, WorkPhone, StreetAddress1, StreetAddress2, City, ZipCode, SiteCode, StaffCode, Fax, ManagedBy, UserGroup, UnitID, UserName, Password, IPAddress, Email, 
                 SupplierID, State,ForcePasswordChange);
            if (edited)
            {
                //regenerate hashtable after edit
                StaffList = null;
                StaffList = GetStaffList();
                //
            }
            return edited;
        }

        public static bool DeactivateStaffByStaffID(int staffID)
        {
            return StaffDB.DeactivateStaffByStaffID(staffID);
        }
        public static bool ActivateStaffByStaffID(int staffID)
        {
            return StaffDB.ActivateStaffByStaffID(staffID);
        }

       
        //public static bool RemoveStaffByStaffID(int staffID, string removedBy, string removeReason)
        //{
        //    return StaffDB.RemoveStaff(staffID, removedBy, removeReason);
        //}

        //public static Staffs GetStaffsByUserGroup(string userGroup)  
        //{
        //    return PopStaffs(StaffDB.GetStaffsByUserGroup(userGroup));
        //}

        public static Staffs GetStaffsByManagedBy(string managedBy)
        {
            return PopStaffs(StaffDB.GetStaffsByManagedBy(managedBy));
        }

        public void GetStaffByEmail(string email)
        {
            PopStaff(StaffDB.GetStaffByEmail(email));
        }

        public String GetUserNameByEmail(string email)
        {
            PopStaff(StaffDB.GetStaffByEmail(email));
            return UserName.ToString();

        }

        public static Staffs GetAllStaff(bool activeOnly)
        {
            return PopStaffs(StaffDB.GetAllStaff(activeOnly));
        }
        public static Staffs GetStaffByIsActive(bool isActive)
        {
            return PopStaffs(StaffDB.GetStaffByIsActive(isActive));
        }

       


        public static Staffs GetRecentlyAddedStaff(int number)
        {
            return PopStaffs(StaffDB.GetRecentlyAddedStaff(number));
        }

       
        public static Staffs GetStaffByUserGroup(int userGroup)
        {
            return PopStaffs(StaffDB.GetStaffByUserGroup(userGroup));
        }

        
        public static Staffs GetAllDFTAUser()
        {
            return PopStaffs(StaffDB.GetAllDFTAUser());
        }

        public static Staffs GetAllDFTAUserAndAdmin()
        {
            return PopStaffs(StaffDB.GetAllDFTAUserAndAdmin());
        }

        public static bool UpdateUserGroup(int staffID, int userGroupID)
        {
            return StaffDB.UpdateUserGroup(staffID, userGroupID);
        }
       

        public static Staffs GetStaffsByName(string name)
        {
            return PopStaffs(StaffDB.GetStaffsByName(name));
        }
        public static Staffs GetStaffsBySearchName(string firstName, string lastName, bool isActive)
        {
            return PopStaffs(StaffDB.GetStaffsBySearchName(firstName, lastName,isActive));
        }

        
        public bool IsInStaffList(int managedBy)
        {
            return StaffDB.IsInStaffList(managedBy);
        }

        public static bool IsUserNameTaken(string userName)
        {
            return StaffDB.IsUserNameTaken(userName);
        }

        public static string GetStaffNameByStaffID(int staffID)
        {

            try
            {
                if (staffID == 0 || staffID == GlobalEnum.EmptyCode)
                    return String.Empty;
                else
                {
                    //check if hashtable has expired, regenerate it
                    TimeSpan span = DateTime.Now.Subtract(StaffHashDate);
                    int refreshTime = Convert.ToInt32(ConfigurationManager.AppSettings["HashSpanInHours"]);
                    TimeSpan refreshTimeSpan = new TimeSpan(refreshTime, 0, 0);// new TimeSpan(h,mn,s)

                    if (span>refreshTimeSpan)
                    { StaffList = GetStaffList(); }
                    //
                    return StaffList[staffID].ToString();
                }
            }
            catch
            {
                return String.Empty;
            }
        }



        public static string GeneratePassword()
        {
            return StaffDB.GeneratePassword();
        }

       
        public static bool Authenticate(string userName, string password)
        {
            return StaffDB.Authenticate(userName, password);
        }

        public static bool Authenticate(string userName)
        {
            return StaffDB.Authenticate(userName);
        }

        public void GetStaffByUserNameAndPassword(string userName, string password)
        {
            PopStaff(StaffDB.GetStaffByUserNameAndPassword(userName, password));
        }
        //

        public void GetStaffByUserName(string userName)
        {
            PopStaff(StaffDB.GetStaffByUserName(userName));
        }

        public bool SetForcePasswordChange(bool value)
        {
            return StaffDB.SetForcePasswordChange(value, StaffID);
        }


        public static string GetStaffEmailByStaffId(int staffId)
        {
            return PopStaffEmailByStaffId(StaffDB.GetStaffEmailByStaffId(staffId));
        }
       
        //return staff in user's hierarchy
        public static Staffs GetStaffHierarchyByStaffID(int staffID)
        {
            return PopStaffs(StaffDB.GetStaffHierarchyByStaffID(staffID));
        }

        public static bool IsUserLocked(string userName)
        {
            return StaffDB.IsUserLocked(userName);
        }

        public static bool LockStaffByStaffID(int staffId)
        {
            return StaffDB.LockStaffByStaffID(staffId);
        }

        public static bool UnlockStaffByStaffID(int staffId)
        {
            return StaffDB.UnlockStaffByStaffID(staffId);
        }

        public bool Lock()
        {
            return StaffDB.LockStaffByStaffID(this.StaffID);
        }

        public bool Unlock()
        {
            return StaffDB.UnlockStaffByStaffID(this.StaffID);
        }

        //log user last login date
        public void SetLoginDate()
        {
            StaffDB.SetLoginDate(this.StaffID);
        }

        public bool ValidateLogin(string username, string password)
        {
            PrincipalContext context = new PrincipalContext(ContextType.Domain, "dfta");
            return context.ValidateCredentials(username, password);
        }

        #region DFTA staff contact list
        //10-06-16
        public static Staffs GetStaffContactList()
        {
            return PopStaffContactList(StaffDB.GetDFTAStaffContactList());
        }
        //10-24-2016
        public static int AddStaffContact(string firstName, string lastName, string title, string workPhone, string email, int createdBy, int staffID = -1)
        {
            return StaffDB.AddDFTAStaffContact(firstName, lastName, title, workPhone, email, createdBy, staffID);
        }
        //11-03-2016
        public static int AddStaffContact(string firstName, string lastName, int titleCode, string workPhone, string email, int createdBy, int staffID = -1)
        {
            return StaffDB.AddDFTAStaffContact(firstName, lastName, titleCode, workPhone, email, createdBy, staffID);
        }
        //10-25-2016
        public static bool RemoveStaffContactByID(int contactID)
        {
            return StaffDB.RemoveDFTAStaffContactByID(contactID);
        }
        //10-25-2016
        public static bool EditStaffContact(string firstName, string lastName, string title, string workPhone, string email, int contactID)
        {
            return StaffDB.EditDFTAStaffContact(firstName, lastName, workPhone, title, email, contactID);
        }
        //11-03-2016
        public static bool EditStaffContact(string firstName, string lastName, int titleCode, string workPhone, string email, int contactID)
        {
            return StaffDB.EditDFTAStaffContact(firstName, lastName, workPhone, titleCode, email, contactID);
        }
        //10-25-2016
        public void UpdateStaffOrder(int order)
        {
            StaffDB.EditDFTAStaffContact(FirstName, LastName, WorkPhone, Title, Email, DFTAContactID, order);
        }
        #endregion

        #endregion

        #region IMailable Members

        public string MailBody
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You have been added to Simple Servings Database, below are your user name, password and a link to the application. <br>");
                sb.Append("If this is your initial login, you will be directed to choose a new password. <br>");
                sb.Append(string.Format("User Name: {0} <br>", UserName));
                sb.Append(string.Format("Password: {0} <br>", Password));
                string SimpleServingsURL = ConfigurationManager.AppSettings["SimpleServingsURL"].ToString();
                sb.Append("Click <a href=" + SimpleServingsURL + "> here </a>to login to Simple Servings");
                return sb.ToString();
            }
        }
        public string MailSubject
        {
            get { return "Your Simple Servings credentials"; }
        }

        public string GetBody(string bodyHeader)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0} <br>", bodyHeader));
            sb.Append(MailBody);
            return sb.ToString();
        }

        public string GetSubject(string subjectHeader)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} ", subjectHeader));
            sb.Append(MailSubject);
            return sb.ToString();
        }

        #endregion
    }
    [Serializable]
    public class Staffs : ArrayList
    {
        public enum StaffFields
        {
            StaffID,
            FullName,
            WorkPhone,
            SiteCode,
            StaffCode
        }

        public void Sort(StaffFields sortField, bool isAscending)
        {
            switch (sortField)
            {
                case StaffFields.StaffID:
                    base.Sort(new StaffIDComparer());
                    break;
                case StaffFields.FullName:
                    base.Sort(new FullNameComparer());
                    break;
                case StaffFields.WorkPhone:
                    base.Sort(new WorkPhoneComparer());
                    break;
                case StaffFields.SiteCode:
                    base.Sort(new SiteCodeComparer());
                    break;
                case StaffFields.StaffCode:
                    base.Sort(new StaffCodeComparer());
                    break;
            }

            if (!isAscending) base.Reverse();
        }
        private sealed class StaffIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Staff first = (Staff)x;
                Staff second = (Staff)y;
                return first.StaffID.CompareTo(second.StaffID);

            }
        }
        private sealed class FullNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Staff first = (Staff)x;
                Staff second = (Staff)y;
                return first.FullName.CompareTo(second.FullName);
            }
        }

        private sealed class WorkPhoneComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Staff first = (Staff)x;
                Staff second = (Staff)y;
                return first.WorkPhone.CompareTo(second.WorkPhone);

            }
        }

        private sealed class SiteCodeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Staff first = (Staff)x;
                Staff second = (Staff)y;
                return first.SiteCode.CompareTo(second.SiteCode);

            }
        }
        private sealed class StaffCodeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Staff first = (Staff)x;
                Staff second = (Staff)y;
                return first.StaffCode.CompareTo(second.StaffCode);

            }
        }

       
    }

}

