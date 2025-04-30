using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTrackDL.Model
{
   public class ChallengeDTOS
    {
        public class NewChallengeDTO
        {
            public int UserID { get; set; }
            public int ArticleID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int DurationTimes { get; set; }
            public int MeasurementID { get; set; }
            public int TimesPerDay { get; set; }
            public string[] Alerts { get; set; }


        }



        public class UpdateChallengeDTO
        {
            public int ChallengeID { get; set; }
            public int UserID { get; set; }
            public int ArticleID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int DurationTimes { get; set; }
            public int MeasurementID { get; set; }
            public int TimesPerDay { get; set; }
            public string[] Alerts { get; set; }

        }

        public class AlertDTO
        {
            public int AlertID { get; set; }
            public DateTime DateAndTime { get; set; }
            public bool IsCompleted { get; set; }
        }

        public class ChallengeTaskDTO
        {
            public int ChallengeID { get; set; }
            public int ArticleID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int DurationTimes { get; set; }
            public int TimesPerDay { get; set; }
            public int TaskID { get; set; }
            public int MeasurementID { get; set; }

            // JSON field to deserialize into AlertDTO[]
            public List<AlertDTO> Alerts { get; set; }
        }


    }
}
