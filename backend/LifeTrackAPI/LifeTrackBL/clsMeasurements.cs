
using System;
using System.Data;
using System.Data.SqlClient;
using LifeTrackDL;

namespace LifeTrackDB_Business
{
    public class clsMeasurements
    {


        public enum enMode { AddNew = 0, Update = 1 }
        public static enMode Mode = enMode.AddNew;

        public MeasurementsDTO measurementsDTO
        {
            get
            {
                return new MeasurementsDTO(
              this.MeasurementID,
              this.Title
        
               );
            }
        }

        public int MeasurementID { get; set; }
        public string Title { get; set; }


        public clsMeasurements()
        {
            this.MeasurementID = -1;

            this.Title = "";

            Mode = enMode.AddNew;
        }

        public clsMeasurements(MeasurementsDTO measurements, enMode mode = enMode.AddNew)
        {

            this.MeasurementID = measurements.MeasurementID;

            this.Title = measurements.Title;

            Mode = mode;
        }
        public static List<MeasurementsDTO> GetAllMeasurements()
        {
            return clsMeasurementsData.GetAllMeasurements();

        }


        public static clsMeasurements GetMeasurementsInfoByID(int MeasurementID)
        {
            MeasurementsDTO measurementsDTO = clsMeasurementsData.GetMeasurementsInfoByID(MeasurementID);

            if (measurementsDTO != null)
            {
                return new clsMeasurements(measurementsDTO, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewMeasurements()
        {

            this.MeasurementID = (int)clsMeasurementsData.AddNewMeasurements(this.measurementsDTO);
            return (this.MeasurementID != -1);

        }

        private bool _UpdateMeasurements()
        {

            return (clsMeasurementsData.UpdateMeasurements(this.measurementsDTO));
        }

        public bool Save()
        {

            if (Mode == enMode.AddNew)
            {
                if (_AddNewMeasurements())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return _UpdateMeasurements();
            }

        }

        public static bool DeleteMeasurements(int MeasurementID)
        {
            return clsMeasurementsData.DeleteMeasurements(MeasurementID);

        }



    }
}


