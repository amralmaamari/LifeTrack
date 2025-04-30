namespace LifeTrackAPI.Model
{
    public class AlertDTOS
    {
        public class GetAlertInfoDTO
        {
            //from Alerts
            public int AlertId { get; set; }
            public int TaskId { get; set; }
            public int MeasurementID { get; set; }
            public string ScoreMeasurement { get; set; }
            public string Notice { get; set; }
            public DateTime DateAndTime {  get; set; }
            public bool IsCompleted { get; set; }

            //from challange
            //from challange
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class UpdateAlertDTO
        {
            public int AlertId { get; set; }
            public string ScoreMeasurement { get; set; }
            public string Notice { get; set; }
            public bool IsCompleted { get; set; }
        }
    }
}
