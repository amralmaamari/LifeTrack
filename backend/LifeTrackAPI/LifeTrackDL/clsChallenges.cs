
using System;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static LifeTrackDL.Model.ChallengeDTOS;


namespace LifeTrackDL
{

    public class ChallengesDTO
    {
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


        public ChallengesDTO(int ChallengeID, int ArticleID, string Title, string Description, int DurationTimes, int TimesPerDay, DateTime StartDate, DateTime EndDate, DateTime CreatedAt, DateTime UpdatedAt, int UserID)
        {
            this.ChallengeID = ChallengeID;
            this.ArticleID = ArticleID;
            this.Title = Title;
            this.Description = Description;
            this.DurationTimes = DurationTimes;
            this.TimesPerDay = TimesPerDay;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.UserID = UserID;
        }
    }


    public class clsChallengesData
    {

        public static List<ChallengesDTO> GetAllChallenges()
        {

            List<ChallengesDTO> challengesList = new List<ChallengesDTO>();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                string Query = "select * From FN_GetAllChallenges()";
                try
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                var challenges = new ChallengesDTO(
                                                             ChallengeID: (int)reader["ChallengeID"],
                             ArticleID: (int)reader["ArticleID"],
                             Title: (string)reader["Title"],
                             Description: (string)reader["Description"],
                             DurationTimes: (int)reader["DurationTimes"],
                             TimesPerDay: (int)reader["TimesPerDay"],
                             StartDate: (DateTime)reader["StartDate"],
                             EndDate: (DateTime)reader["EndDate"],
                             CreatedAt: (DateTime)reader["CreatedAt"],
                             UpdatedAt: (DateTime)reader["UpdatedAt"],
                             UserID: (int)reader["UserID"]
    

                                );

                                challengesList.Add(challenges);
                            }
                        }

                    }
                }
                catch (Exception ex) { }

                return challengesList;
            }


        }


        public static Nullable<int> AddNewChallenges(ChallengesDTO challenges)
        {

            Nullable<int> NewChallengesID = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();


                try
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewChallenges", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ArticleID", challenges.ArticleID);
                        command.Parameters.AddWithValue("@Title", challenges.Title);
                        command.Parameters.AddWithValue("@Description", challenges.Description);
                        command.Parameters.AddWithValue("@DurationTimes", challenges.DurationTimes);
                        command.Parameters.AddWithValue("@TimesPerDay", challenges.TimesPerDay);
                        command.Parameters.AddWithValue("@StartDate", challenges.StartDate);
                        command.Parameters.AddWithValue("@EndDate", challenges.EndDate);
                        command.Parameters.AddWithValue("@CreatedAt", challenges.CreatedAt);
                        command.Parameters.AddWithValue("@UpdatedAt", challenges.UpdatedAt);
                        command.Parameters.AddWithValue("@UserID", challenges.UserID);
                        ;
                        SqlParameter outputIdParam = new SqlParameter("@ChallengeID", SqlDbType.Int);
                        {
                            outputIdParam.Direction = ParameterDirection.Output;
                        }
                        ;
                        command.Parameters.Add(outputIdParam);
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            NewChallengesID = Convert.ToInt32(outputIdParam.Value);
                        }

                    }
                }
                catch (Exception ex) { }

                return NewChallengesID;
            }


        }


        public static ChallengesDTO GetChallengesInfoByID(int ChallengeID)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();



                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetChallengesInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ChallengeID", ChallengeID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ChallengesDTO(

                                                         ChallengeID: (int)reader["ChallengeID"],
                             ArticleID: (int)reader["ArticleID"],
                             Title: (string)reader["Title"],
                             Description: (string)reader["Description"],
                             DurationTimes: (int)reader["DurationTimes"],
                             TimesPerDay: (int)reader["TimesPerDay"],
                             StartDate: (DateTime)reader["StartDate"],
                             EndDate: (DateTime)reader["EndDate"],
                             CreatedAt: (DateTime)reader["CreatedAt"],
                             UpdatedAt: (DateTime)reader["UpdatedAt"],
                             UserID: (int)reader["UserID"]
    

                                );

                            }
                        }

                    }
                }
                catch (Exception ex) { }

                return null;
            }


        }


        public static bool UpdateChallenges(ChallengesDTO challenges)
        {

            Nullable<int> rowAffected = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();


                try
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateChallengesByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ChallengeID", challenges.ChallengeID);
                        command.Parameters.AddWithValue("@ArticleID", challenges.ArticleID);
                        command.Parameters.AddWithValue("@Title", challenges.Title);
                        command.Parameters.AddWithValue("@Description", challenges.Description);
                        command.Parameters.AddWithValue("@DurationTimes", challenges.DurationTimes);
                        command.Parameters.AddWithValue("@TimesPerDay", challenges.TimesPerDay);
                        command.Parameters.AddWithValue("@StartDate", challenges.StartDate);
                        command.Parameters.AddWithValue("@EndDate", challenges.EndDate);
                        command.Parameters.AddWithValue("@CreatedAt", challenges.CreatedAt);
                        command.Parameters.AddWithValue("@UpdatedAt", challenges.UpdatedAt);
                        command.Parameters.AddWithValue("@UserID", challenges.UserID);
                        ;
                        rowAffected = command.ExecuteNonQuery();



                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }


        }


        public static bool DeleteChallenges(int ChallengeID)
        {

            Nullable<int> rowAffected = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();


                try
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteChallenges", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ChallengeID", ChallengeID);

                        rowAffected = command.ExecuteNonQuery();



                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }


        }


        public static Nullable<int> AddChallengeWithTaskAndAlerts(NewChallengeDTO newChallenge)
        {

            Nullable<int> NewChallengeID = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();


                try
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewChallenges", connection, transaction))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ArticleID", newChallenge.ArticleID);
                        command.Parameters.AddWithValue("@Title", newChallenge.Title);
                        command.Parameters.AddWithValue("@Description", newChallenge.Description);
                        command.Parameters.AddWithValue("@DurationTimes", newChallenge.DurationTimes);
                        command.Parameters.AddWithValue("@TimesPerDay", newChallenge.TimesPerDay);
                        command.Parameters.AddWithValue("@StartDate", newChallenge.StartDate);
                        command.Parameters.AddWithValue("@EndDate", newChallenge.EndDate);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        command.Parameters.AddWithValue("@UserID", newChallenge.UserID);

                        SqlParameter outputIdParam = new SqlParameter("@ChallengeID", SqlDbType.Int);
                        {
                            outputIdParam.Direction = ParameterDirection.Output;
                        }

                        command.Parameters.Add(outputIdParam);
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            NewChallengeID = Convert.ToInt32(outputIdParam.Value);
                        }
                        else
                        {
                            throw new Exception("Failed to retrieve ChallengeID");

                        }

                    }

                    int durationDays = (newChallenge.EndDate - newChallenge.StartDate).Days + 1;

                    for (int d = 0; d < durationDays; d++)
                    {
                        DateTime currentDate = newChallenge.StartDate.AddDays(d);

                        // أضف المهمة
                        TasksDTO task = new TasksDTO
                        {
                            ChallengeID = (int)NewChallengeID,
                            IsCompleted = false,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        };

                        int? taskId = clsTasksData.AddNewTasks(task, connection, transaction);
                        if (taskId == null)
                            throw new Exception("Failed to add task");

                        // أضف التنبيهات (عادةً واحد أو أكثر حسب المرسل)
                        foreach (var alertTime in newChallenge.Alerts)
                        {
                            DateTime timeOnly = DateTime.Parse(alertTime);
                            DateTime fullDateTime = new DateTime(
                                currentDate.Year,
                                currentDate.Month,
                                currentDate.Day,
                                timeOnly.Hour,
                                timeOnly.Minute,
                                timeOnly.Second
                            );

                            AlertsDTO alert = new AlertsDTO
                            {
                                TaskID = taskId.Value,
                                MeasurementID = newChallenge.MeasurementID,
                                ScoreMeasurement = "",
                                Notice = "",
                                DateAndTime = fullDateTime,
                                IsCompleted = true
                            };

                            int? alertId = clsAlertsData.AddNewAlerts(alert, connection, transaction);

                            if (alertId == null)
                                throw new Exception("Failed to insert alert.");
                        }
                    
                
                }




                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // ⛔ هذا ضروري
                    NewChallengeID = null;
                    // ممكن تضيف تسجيل خطأ هنا لو حبيت
                }

                return NewChallengeID;
            }


        }


        public static List<ChallengeTaskDTO> GetTodayTasksWithAlerts()
        {

             List<ChallengeTaskDTO> tasks = new List<ChallengeTaskDTO>();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                string Query = "select * From FN_GetTodayTasksWithAlerts()";
                try
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChallengeTaskDTO task = new ChallengeTaskDTO
                                {
                                    ChallengeID = Convert.ToInt32(reader["ChallengeID"]),
                                    ArticleID = Convert.ToInt32(reader["ArticleID"]),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    DurationTimes = Convert.ToInt32(reader["DurationTimes"]),
                                    TimesPerDay = Convert.ToInt32(reader["TimesPerDay"]),
                                    TaskID = Convert.ToInt32(reader["TaskID"]),
                                    MeasurementID = Convert.ToInt32(reader["MeasurementID"]),
                                    Alerts = JsonSerializer.Deserialize<List<AlertDTO>>(reader["AlertsJson"].ToString())
                                };

                                tasks.Add(task);
                            }
                        }
                    }
                }
                catch (Exception ex) { }

                return tasks;
            }


        }


    }
}


