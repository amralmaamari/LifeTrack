
            using System;
            using System.Data;
            using Microsoft.Data.SqlClient;

            
             namespace LifeTrackDBDataAccessLayer
             {
                
                public class TasksDTO
                {
                    	 public int TaskID  {get; set;}
	 public int ChallengeID  {get; set;}
	 public bool IsCompleted  {get; set;}
	 public DateTime CreatedAt  {get; set;}
	 public DateTime UpdatedAt  {get; set;}
            
                    
            public TasksDTO( int  TaskID,  int  ChallengeID,  bool  IsCompleted,  DateTime  CreatedAt,  DateTime  UpdatedAt){
this.TaskID = TaskID ;
this.ChallengeID = ChallengeID ;
this.IsCompleted = IsCompleted ;
this.CreatedAt = CreatedAt ;
this.UpdatedAt = UpdatedAt ;   
                }
                }
                
                
                 public  class clsTasksData
                 {
                           
                          public static List<TasksDTO> GetAllTasks()
{

            List<TasksDTO> tasksList = new List<TasksDTO>();
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) {
               connection.Open();

            string Query = "select * From FN_GetAllTasks()";
            try
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var tasks = new TasksDTO(
                                						 TaskID:(int)reader ["TaskID"] ,
						 ChallengeID:(int)reader ["ChallengeID"] ,
						 IsCompleted:(bool)reader ["IsCompleted"] ,
						 CreatedAt:(DateTime)reader ["CreatedAt"] ,
						 UpdatedAt:(DateTime)reader ["UpdatedAt"] ,

                            );

                            tasksList.Add(tasks);
                        }
                    }

                }
            }
            catch (Exception ex) { }

            return tasksList;
            }
               
           
}


                          public static Nullable<int> AddNewTasks(TasksDTO tasks)
{

            Nullable<int> NewTasksID = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewTasks", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                       						command.Parameters.AddWithValue("@ChallengeID", tasks.ChallengeID);
						command.Parameters.AddWithValue("@IsCompleted", tasks.IsCompleted);
						command.Parameters.AddWithValue("@CreatedAt", tasks.CreatedAt);
						command.Parameters.AddWithValue("@UpdatedAt", tasks.UpdatedAt);
;
                        SqlParameter outputIdParam = new SqlParameter("@TaskID", SqlDbType.Int);
                        {
                            outputIdParam.Direction = ParameterDirection.Output;
                        };
                        command.Parameters.Add(outputIdParam);
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            NewTasksID = Convert.ToInt32(outputIdParam.Value);
                        }

                    }
                }
                catch (Exception ex) { }

                return NewTasksID;
            }
            
        
}
 

                          public static TasksDTO GetTasksInfoByID(int TaskID)
{

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
               
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetTasksInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@TaskID", TaskID);


                using (SqlDataReader reader = command.ExecuteReader())
                 {
                     if (reader.Read())
                     {
                            return  new TasksDTO(

                            						 TaskID:(int)reader ["TaskID"],
						 ChallengeID:(int)reader ["ChallengeID"],
						 IsCompleted:(bool)reader ["IsCompleted"],
						 CreatedAt:(DateTime)reader ["CreatedAt"],
						 UpdatedAt:(DateTime)reader ["UpdatedAt"],

                            );
                        
                     }
                 }

                    }
                }
                catch (Exception ex) { }

                return null;
            }
            
        
}


                          public static bool UpdateTasks(TasksDTO tasks)
{

            Nullable<int> rowAffected  = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

               
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateTasksByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@TaskID", tasks.TaskID);
						command.Parameters.AddWithValue("@ChallengeID", tasks.ChallengeID);
						command.Parameters.AddWithValue("@IsCompleted", tasks.IsCompleted);
						command.Parameters.AddWithValue("@CreatedAt", tasks.CreatedAt);
						command.Parameters.AddWithValue("@UpdatedAt", tasks.UpdatedAt);
;
                        rowAffected = command.ExecuteNonQuery();

                        

                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }
            
        
}


                          public static bool DeleteTasks(int TaskID)
{

            Nullable<int> rowAffected  = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteTasks", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@TaskID", TaskID);

                        rowAffected = command.ExecuteNonQuery();

                        

                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }
            
        
}

                        
                 }
             } 
                
            
             