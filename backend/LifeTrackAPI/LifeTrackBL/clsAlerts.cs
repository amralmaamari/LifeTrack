
using System;
using System.Data;
using System.Data.SqlClient;
using LifeTrackDB_Business;
using LifeTrackDL;

namespace LifeTrackBL
{
    public class clsAlerts
    {


        public enum enMode { AddNew = 0, Update = 1 }
        public static enMode Mode = enMode.AddNew;

        public AlertsDTO alertsDTO
        {
            get
            {
                return new AlertsDTO(
              this.AlertID,
              this.TaskID,
              this.MeasurementID,
              this.ScoreMeasurement,
              this.Notice,
              this.DateAndTime,
              this.IsCompleted


               );
            }
        }


        public int AlertID { get; set; }
        public int TaskID { get; set; }
        public clsTasks TaskInfo { get; set; }
        public int MeasurementID { get; set; }
        public string ScoreMeasurement { get; set; }
        public string Notice { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool IsCompleted { get; set; }


        public clsAlerts()
        {
            this.AlertID = -1;

            this.TaskID = -1;

            this.MeasurementID = -1;

            this.ScoreMeasurement = "";

            this.Notice = "";

            this.DateAndTime = DateTime.Now;

            this.IsCompleted = false;

            Mode = enMode.AddNew;
        }

        public clsAlerts(AlertsDTO alerts, enMode mode = enMode.AddNew)
        {

            this.AlertID = alerts.AlertID;

            this.TaskID = alerts.TaskID;

            this.TaskInfo = clsTasks.GetTasksInfoByID(alerts.TaskID);

            this.MeasurementID = alerts.MeasurementID;

            this.ScoreMeasurement = alerts.ScoreMeasurement;

            this.Notice = alerts.Notice;

            this.DateAndTime = alerts.DateAndTime;

            this.IsCompleted = alerts.IsCompleted;

            Mode = mode;
        }
        public static List<AlertsDTO> GetAllAlerts()
        {
            return clsAlertsData.GetAllAlerts();

        }


        public static clsAlerts GetAlertsInfoByID(int AlertID)
        {
            AlertsDTO alertsDTO = clsAlertsData.GetAlertsInfoByID(AlertID);

            if (alertsDTO != null)
            {
                return new clsAlerts(alertsDTO, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewAlerts()
        {

            this.AlertID = (int)clsAlertsData.AddNewAlerts(this.alertsDTO);
            return (this.AlertID != -1);

        }

        private bool _UpdateAlerts()
        {

            return (clsAlertsData.UpdateAlerts(this.alertsDTO));
        }

        public bool Save()
        {

            if (Mode == enMode.AddNew)
            {
                if (_AddNewAlerts())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return _UpdateAlerts();
            }

        }

        public static bool DeleteAlerts(int AlertID)
        {
            return clsAlertsData.DeleteAlerts(AlertID);

        }



    }
}


