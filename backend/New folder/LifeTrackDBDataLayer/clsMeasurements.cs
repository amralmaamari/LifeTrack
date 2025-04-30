
            using System;
            using System.Data;
            using Microsoft.Data.SqlClient;

            
             namespace LifeTrackDBDataAccessLayer
             {
                
                public class MeasurementsDTO
                {
                    	 public int MeasurementID  {get; set;}
	 public string Title  {get; set;}
            
                    
            public MeasurementsDTO( int  MeasurementID,  string  Title){
this.MeasurementID = MeasurementID ;
this.Title = Title ;   
                }
                }
                
                
                 public  class clsMeasurementsData
                 {
                           
                          public static List<MeasurementsDTO> GetAllMeasurements()
{

            List<MeasurementsDTO> measurementsList = new List<MeasurementsDTO>();
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) {
               connection.Open();

            string Query = "select * From FN_GetAllMeasurements()";
            try
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var measurements = new MeasurementsDTO(
                                						 MeasurementID:(int)reader ["MeasurementID"] ,
						 Title:(string)reader ["Title"] ,

                            );

                            measurementsList.Add(measurements);
                        }
                    }

                }
            }
            catch (Exception ex) { }

            return measurementsList;
            }
               
           
}


                          public static Nullable<int> AddNewMeasurements(MeasurementsDTO measurements)
{

            Nullable<int> NewMeasurementsID = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewMeasurements", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                       						command.Parameters.AddWithValue("@Title", measurements.Title);
;
                        SqlParameter outputIdParam = new SqlParameter("@MeasurementID", SqlDbType.Int);
                        {
                            outputIdParam.Direction = ParameterDirection.Output;
                        };
                        command.Parameters.Add(outputIdParam);
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            NewMeasurementsID = Convert.ToInt32(outputIdParam.Value);
                        }

                    }
                }
                catch (Exception ex) { }

                return NewMeasurementsID;
            }
            
        
}
 

                          public static MeasurementsDTO GetMeasurementsInfoByID(int MeasurementID)
{

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
               
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetMeasurementsInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@MeasurementID", MeasurementID);


                using (SqlDataReader reader = command.ExecuteReader())
                 {
                     if (reader.Read())
                     {
                            return  new MeasurementsDTO(

                            						 MeasurementID:(int)reader ["MeasurementID"],
						 Title:(string)reader ["Title"],

                            );
                        
                     }
                 }

                    }
                }
                catch (Exception ex) { }

                return null;
            }
            
        
}


                          public static bool UpdateMeasurements(MeasurementsDTO measurements)
{

            Nullable<int> rowAffected  = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

               
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateMeasurementsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@MeasurementID", measurements.MeasurementID);
						command.Parameters.AddWithValue("@Title", measurements.Title);
;
                        rowAffected = command.ExecuteNonQuery();

                        

                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }
            
        
}


                          public static bool DeleteMeasurements(int MeasurementID)
{

            Nullable<int> rowAffected  = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteMeasurements", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@MeasurementID", MeasurementID);

                        rowAffected = command.ExecuteNonQuery();

                        

                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }
            
        
}

                        
                 }
             } 
                
            
             