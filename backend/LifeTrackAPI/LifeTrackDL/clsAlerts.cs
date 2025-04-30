
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace LifeTrackDL
{

    public class AlertsDTO
    {
        public int AlertID { get; set; }
        public int TaskID { get; set; }
        public int MeasurementID { get; set; }
        public string ScoreMeasurement { get; set; }
        public string?Notice { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool IsCompleted { get; set; }

        public AlertsDTO() { }
        public AlertsDTO(int AlertID, int TaskID, int MeasurementID, string ScoreMeasurement, string Notice, DateTime DateAndTime, bool IsCompleted)
        {
            this.AlertID = AlertID;
            this.TaskID = TaskID;
            this.MeasurementID = MeasurementID;
            this.ScoreMeasurement = ScoreMeasurement;
            this.Notice = Notice;
            this.DateAndTime = DateAndTime;
            this.IsCompleted = IsCompleted;
        }
    }


    public class clsAlertsData
    {

        public static List<AlertsDTO> GetAllAlerts()
        {

            List<AlertsDTO> alertsList = new List<AlertsDTO>();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                string Query = "select * From FN_GetAllAlerts()";
                try
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                var alerts = new AlertsDTO(
                              AlertID: (int)reader["AlertID"],
                              TaskID: (int)reader["TaskID"],
                              MeasurementID: (int)reader["MeasurementID"],
                              ScoreMeasurement: (string)reader["ScoreMeasurement"],
                              Notice: (string)reader["Notice"],
                              DateAndTime: (DateTime)reader["DateAndTime"],
                              IsCompleted: (bool)reader["IsCompleted"]


                                 );

                                alertsList.Add(alerts);
                            }
                        }

                    }
                }
                catch (Exception ex) { }

                return alertsList;
            }


        }


        public static Nullable<int> AddNewAlerts(AlertsDTO alerts)
        {

            Nullable<int> NewAlertsID = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();


                try
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewAlerts", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TaskID", alerts.TaskID);
                        command.Parameters.AddWithValue("@MeasurementID", alerts.MeasurementID);
                        command.Parameters.AddWithValue("@ScoreMeasurement", alerts.ScoreMeasurement);
                        command.Parameters.AddWithValue("@Notice", alerts.Notice);
                        command.Parameters.AddWithValue("@DateAndTime", alerts.DateAndTime);
                        command.Parameters.AddWithValue("@IsCompleted", alerts.IsCompleted);
                        ;
                        SqlParameter outputIdParam = new SqlParameter("@AlertID", SqlDbType.Int);
                        {
                            outputIdParam.Direction = ParameterDirection.Output;
                        }
                        ;
                        command.Parameters.Add(outputIdParam);
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            NewAlertsID = Convert.ToInt32(outputIdParam.Value);
                        }

                    }
                }
                catch (Exception ex) { }

                return NewAlertsID;
            }


        }

        public static Nullable<int> AddNewAlerts(AlertsDTO alerts, SqlConnection connection, SqlTransaction transaction)
        {
            Nullable<int> NewAlertsID = null;

            using (SqlCommand command = new SqlCommand("SP_AddNewAlerts", connection, transaction))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TaskID", alerts.TaskID);
                command.Parameters.AddWithValue("@MeasurementID", alerts.MeasurementID);
                command.Parameters.AddWithValue("@ScoreMeasurement", alerts.ScoreMeasurement);
                command.Parameters.AddWithValue("@Notice", alerts.Notice);
                command.Parameters.AddWithValue("@DateAndTime", alerts.DateAndTime);
                command.Parameters.AddWithValue("@IsCompleted", alerts.IsCompleted);

                SqlParameter outputIdParam = new SqlParameter("@AlertID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                command.ExecuteNonQuery();

                if (outputIdParam.Value != DBNull.Value)
                {
                    NewAlertsID = Convert.ToInt32(outputIdParam.Value);
                }
            }

            return NewAlertsID;
        }



        public static AlertsDTO GetAlertsInfoByID(int AlertID)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();



                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAlertsInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AlertID", AlertID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AlertsDTO(
                                 AlertID: (int)reader["AlertID"],
                                 TaskID: (int)reader["TaskID"],
                                 MeasurementID: reader["MeasurementID"] != DBNull.Value ? (int)reader["MeasurementID"] : 0,
                                 ScoreMeasurement: reader["ScoreMeasurement"] != DBNull.Value ? (string)reader["ScoreMeasurement"] : "",
                                 Notice: reader["Notice"] != DBNull.Value ? (string)reader["Notice"] : "",
                                 DateAndTime: reader["DateAndTime"] != DBNull.Value ? (DateTime)reader["DateAndTime"] : DateTime.Now,
                                 IsCompleted: reader["IsCompleted"] != DBNull.Value ? (bool)reader["IsCompleted"] : false
                            );



                            }
                        }

                    }
                }
                catch (Exception ex) { }

                return null;
            }


        }


        public static bool UpdateAlerts(AlertsDTO alerts)
        {

            Nullable<int> rowAffected = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();


                try
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateAlertsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AlertID", alerts.AlertID);
                        command.Parameters.AddWithValue("@TaskID", alerts.TaskID);
                        command.Parameters.AddWithValue("@MeasurementID", alerts.MeasurementID);
                        command.Parameters.AddWithValue("@ScoreMeasurement", alerts.ScoreMeasurement);
                        command.Parameters.AddWithValue("@Notice", alerts.Notice);
                        command.Parameters.AddWithValue("@DateAndTime", alerts.DateAndTime);
                        command.Parameters.AddWithValue("@IsCompleted", alerts.IsCompleted);
                        ;
                        rowAffected = command.ExecuteNonQuery();



                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }


        }


        public static bool DeleteAlerts(int AlertID)
        {

            Nullable<int> rowAffected = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();


                try
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteAlerts", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AlertID", AlertID);

                        rowAffected = command.ExecuteNonQuery();



                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }


        }


    }
}


