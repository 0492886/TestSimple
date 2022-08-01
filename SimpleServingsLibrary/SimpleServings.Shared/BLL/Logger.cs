using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;


namespace SimpleServingsLibrary.Shared
{
    public class Logger
    {
        private int _loggerID;
        private int _fhID;
        //private int _clientID;
        private int _createdBy;
        private string _createdOn;
        private int _moduleID;
        private string _actionTaken;
        private int _referenceID;


        public int LoggerID
        {
            get { return _loggerID; }
            set { _loggerID = value; }
        }
        public int FHID
        {
            get { return _fhID; }
            set { _fhID = value; }
        }
        //public int ClientID
        //{
        //    get { return _clientID; }
        //    set { _clientID = value; }
        //}
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
      
        public string CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
        public int ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }
        public string ModuleName
        {
            get { return Code.DecodeCode(_moduleID); }
        }
        public string ActionTaken
        {
            get { return _actionTaken; }
            set { _actionTaken = value; }
        }
        public int ReferenceID
        {
            get { return _referenceID; }
            set { _referenceID = value; }
        }
        public string LogURL
        {
            get 
            {
                try
                {
                    return string.Format("{0}={1}&FHID={2}",((Code)Code.GetCodesByTypeAndDependsOn(Code.CodeTypes.ModuleViewURL, ModuleID)[0]).CodeDescription, ReferenceID,FHID);
                }
                catch 
                {
                    return "";
                }
            }
        }
        
        private static Loggers PopLogs(SqlDataReader dr)
        {
            Loggers loggers = new Loggers();
            Logger logger;
            while (dr.Read())
            {
                logger = new Logger();
                logger.LoggerID = Convert.ToInt32(dr["LoggerID"]);
                logger.FHID = Convert.ToInt32(dr["FHID"]);
                //logger.ClientID = Convert.ToInt32(dr["ClientID"]);
                logger.ReferenceID = Convert.ToInt32(dr["ReferenceID"]);
                logger.ModuleID = Convert.ToInt32(dr["ModuleID"]);
                logger.ActionTaken = dr["ActionTaken"].ToString();
                logger.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
                logger.CreatedOn = dr["CreatedOn"].ToString();
                loggers.Add(logger);
            }
            dr.Close();
            return loggers;
        }
        
        public static bool AddLog(int fhID,int referenceID,int moduleID,string actionTaken,int createdBy)
        {
            return LoggerDB.AddLog(fhID, referenceID, moduleID, actionTaken, createdBy);
        }

        public static Loggers GetLogsByStaffID(int staffID)
        {
            return PopLogs(LoggerDB.GetLogsByStaffID(staffID));
        }

        public static Loggers GetLogsByStaffIDAndLogsType(int staffID, int logsType)
        {
            return PopLogs(LoggerDB.GetLogsByStaffIDAndLogsType(staffID, logsType));
        }
        public static Loggers GetTodaysLogsByStaffIDAndLogsType(int staffID, int logsType)
        {
            return PopLogs(LoggerDB.GetTodaysLogsByStaffIDAndLogsType(staffID, logsType));
        }

        public static Loggers GetLogsByStaffIDAndLogsTypeAndCaseID(int staffID, int logsType, int caseID)
        {
            return PopLogs(LoggerDB.GetLogsByStaffIDAndLogsTypeAndCaseID(staffID, logsType, caseID));
        }
        public static Loggers GetTodaysLogsByStaffIDAndLogsTypeAndCaseID(int staffID, int logsType,int caseID)
        {
            return PopLogs(LoggerDB.GetTodaysLogsByStaffIDAndLogsTypeAndCaseID(staffID, logsType, caseID));
        }

        public static Loggers GetLogsForLast(int days)
        {
            return PopLogs(LoggerDB.GetLogsForLast(days));
        }
        public static Loggers GetLogsForLastAndCaseID(int days, int caseID)
        {
            return PopLogs(LoggerDB.GetLogsForLastAndCaseID(days, caseID));
        }

       

    }
    public class Loggers : ArrayList
    { }
}
