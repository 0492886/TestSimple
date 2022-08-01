using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleServingsLibrary.Shared
{
    public class GlobalEnum
    {
        public const int EmptyCode=0;
        public const string DATABASENAME = "SimpleServingsCnnStr";

        #region Modules
        public const int RecipeModule = 11;
        public const int SettingModule = 12;
        public const int ProgressNoteModule = 19;
        public const int CodeModule = 50;
        public const int MenuModule = 77;
        public const int ProviderModule = 127;
        public const int ReportModule = 153;
        public const int SampleMenuModule = 188;


        //public const int LoggerModule = 0;
        //public const int CaseModule = 0;
        //public const int ClientModule = 0;
        //public const int UserGroupModule = 0;
        //public const int CaseNoteModule = 0;
          
        #endregion


        #region Note Types

        public const int NoteType_Recipe = 18;


        public const int NoteType_General = 0;
       
        public const int CaseNoteType = 0;
        public const int StaffNoteType = 0;
        
        #endregion

        #region MenuTypes
        public const int RegularMenu = 182;
        public const int SampleMenu = 183;
        #endregion


        #region DietTypes
        public const int RegularDietType = 181;         
        #endregion

        #region Module Permissions

        public const int ViewOnlyRole = 1;
        public const int EditOnlyRole = 2;
        public const int AddOnlyRole = 3;
        public const int AddEditRole = 4;
        public const int AddEditDeleteRole = 5;
        public const int NoPermission = 6;       
        #endregion

        #region Access Level

        public const int AccessLevel_Sponsor = 39;
        public const int AccessLevel_Contract = 40;
        public const int AccessLevel_Caterer = 41;
        public const int AccessLevel_All = 42;
        public const int AccessLevel_CateringContract = 156;

        #endregion


        #region Link Types

        public const int LinkType_Internal = 9;
        public const int LinkType_External = 10;

        #endregion

        #region Link categories

        public const int LinkCategory_Main = 7;
        public const int LinkCategory_Setting = 8;

        #endregion
        #region Recipe Status

        public const int RecipeStatus_Draft = 13;
        //public const int RecipeStatus_SubmittedForReview = 14;
        public const int RecipeStatus_Approved = 55;
        //public const int RecipeStatus_ReturnedForCorrection = 16;
       // public const int RecipeStatus_Rejected = 17;


        
        #endregion      

    

        #region Universal Type
        //public const int Universal_rule = 527;
        #endregion

        #region RecipeSupplementType

        public const int RecipeSupType_Directions = 20;
        public const int RecipeSupType_Recommendations = 21;
        public const int RecipeSupType_Requirements = 22;
        
        #endregion

        #region MenuThreshold

        public const int Equation_Between = 98;
        public const int Equation_GreaterOrEqual = 99;
        public const int Equation_LessOrEqual = 100;

        public const int Periodic_Daily = 101;
        public const int Periodic_Weekly = 102;

        #endregion

        #region RecipeView

        public const int RecipeView_Public = 33;
        public const int RecipeView_SponsorPrivate = 34;
        public const int RecipeView_CatererPrivate = 49;
        

        #endregion


        #region Menu Status
       

        public const int MenuStatus_Draft = 79;
        public const int MenuStatus_SubmittedToDFTA = 111;
        public const int MenuStatus_Approved = 95;
        public const int MenuStatus_SubmittedToContract = 108;
        public const int MenuStatus_SampleMenuComplete = 186;
        public const int MenuStatus_SampleMenuIncomplete = 187;
        
        #endregion      

        # region ContractType
        public const int ContractType_HomeDelivered = 44;
        public const int ContractType_CongregateSlashHomeDelivered = 131;


        #endregion

        #region ContributorType
        public const int ContributorType_Contract = 154;
        public const int ContributorType_Caterer = 155;
        #endregion

        #region ReportCategory
        public const int ReportCategory_Staff_Related = 158;
        #endregion

        //3-7-2016
        #region ReportType
        public const int ReportType_Admin_Related = 163;
        #endregion

        #region UserGroup
        public const int UserGroup_Addministrator = 1;
        #endregion




    }
}
