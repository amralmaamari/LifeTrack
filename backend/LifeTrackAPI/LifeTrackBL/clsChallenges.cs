
using System;
using System.Data;
using System.Data.SqlClient;
using LifeTrackDL;
using static LifeTrackDL.Model.ChallengeDTOS;

namespace LifeTrackDB_Business
{
    public class clsChallenges
    {


        public enum enMode { AddNew = 0, Update = 1 }
        public static enMode Mode = enMode.AddNew;

        public ChallengesDTO challengesDTO
        {
            get
            {
                return new ChallengesDTO(
              this.ChallengeID,
              this.ArticleID,
              this.Title,
              this.Description,
              this.DurationTimes,
              this.TimesPerDay,
              this.StartDate,
              this.EndDate,
              this.CreatedAt,
              this.UpdatedAt,
              this.UserID

               );
            }
        }


        public int ChallengeID { get; set; }
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationTimes { get; set; }
        public int TimesPerDay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserID { get; set; }


        public clsChallenges()
        {
            this.ChallengeID = -1;

            this.ArticleID = -1;

            this.Title = "";

            this.Description = "";

            this.DurationTimes = -1;

            this.TimesPerDay = -1;

            this.StartDate = DateTime.Now;

            this.EndDate = DateTime.Now;

            this.CreatedAt = DateTime.Now;

            this.UpdatedAt = DateTime.Now;

            this.UserID = -1;

            Mode = enMode.AddNew;
        }

        public clsChallenges(ChallengesDTO challenges, enMode mode = enMode.AddNew)
        {

            this.ChallengeID = challenges.ChallengeID;

            this.ArticleID = challenges.ArticleID;

            this.Title = challenges.Title;

            this.Description = challenges.Description;

            this.DurationTimes = challenges.DurationTimes;

            this.TimesPerDay = challenges.TimesPerDay;

            this.StartDate = challenges.StartDate;

            this.EndDate = challenges.EndDate;

            this.CreatedAt = challenges.CreatedAt;

            this.UpdatedAt = challenges.UpdatedAt;

            this.UserID = challenges.UserID;

            Mode = mode;
        }
        public static List<ChallengesDTO> GetAllChallenges()
        {
            return clsChallengesData.GetAllChallenges();

        }

        public static Nullable<int> AddChallengeWithTaskAndAlerts(NewChallengeDTO newChallenge)
        {
            return clsChallengesData.AddChallengeWithTaskAndAlerts(newChallenge);
        }
        public static List<ChallengeTaskDTO> GetTodayTasksWithAlerts()
        {
            return clsChallengesData.GetTodayTasksWithAlerts();
        }
        public static clsChallenges GetChallengesInfoByID(int ChallengeID)
        {
            ChallengesDTO challengesDTO = clsChallengesData.GetChallengesInfoByID(ChallengeID);

            if (challengesDTO != null)
            {
                return new clsChallenges(challengesDTO, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewChallenges()
        {

            this.ChallengeID = (int)clsChallengesData.AddNewChallenges(this.challengesDTO);
            return (this.ChallengeID != -1);

        }

        private bool _UpdateChallenges()
        {

            return (clsChallengesData.UpdateChallenges(this.challengesDTO));
        }

        public bool Save()
        {

            if (Mode == enMode.AddNew)
            {
                if (_AddNewChallenges())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return _UpdateChallenges();
            }

        }

        public static bool DeleteChallenges(int ChallengeID)
        {
            return clsChallengesData.DeleteChallenges(ChallengeID);

        }



    }
}


