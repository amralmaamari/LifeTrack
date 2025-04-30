
            using System;
            using System.Data;
            using Microsoft.Data.SqlClient;

            
             namespace LifeTrackDBDataAccessLayer
             {
                
                public class UsersDTO
                {
                    	 public int UserID  {get; set;}
	 public string FullName  {get; set;}
	 public string Email  {get; set;}
	 public string Password  {get; set;}
	 public bool IsActive  {get; set;}
            
                    
            public UsersDTO( int  UserID,  string  FullName,  string  Email,  string  Password,  bool  IsActive){
this.UserID = UserID ;
this.FullName = FullName ;
this.Email = Email ;
this.Password = Password ;
this.IsActive = IsActive ;   
                }
                }
                
                
                 public  class clsUsersData
                 {
                           
                          public static List<UsersDTO> GetAllUsers()
{

            List<UsersDTO> usersList = new List<UsersDTO>();
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) {
               connection.Open();

            string Query = "select * From FN_GetAllUsers()";
            try
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var users = new UsersDTO(
                                						 UserID:(int)reader ["UserID"] ,
						 FullName:(string)reader ["FullName"] ,
						 Email:(string)reader ["Email"] ,
						 Password:(string)reader ["Password"] ,
						 IsActive:(bool)reader ["IsActive"] ,

                            );

                            usersList.Add(users);
                        }
                    }

                }
            }
            catch (Exception ex) { }

            return usersList;
            }
               
           
}


                          public static Nullable<int> AddNewUsers(UsersDTO users)
{

            Nullable<int> NewUsersID = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                       						command.Parameters.AddWithValue("@FullName", users.FullName);
						command.Parameters.AddWithValue("@Email", users.Email);
						command.Parameters.AddWithValue("@Password", users.Password);
						command.Parameters.AddWithValue("@IsActive", users.IsActive);
;
                        SqlParameter outputIdParam = new SqlParameter("@UserID", SqlDbType.Int);
                        {
                            outputIdParam.Direction = ParameterDirection.Output;
                        };
                        command.Parameters.Add(outputIdParam);
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            NewUsersID = Convert.ToInt32(outputIdParam.Value);
                        }

                    }
                }
                catch (Exception ex) { }

                return NewUsersID;
            }
            
        
}
 

                          public static UsersDTO GetUsersInfoByID(int UserID)
{

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
               
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUsersInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@UserID", UserID);


                using (SqlDataReader reader = command.ExecuteReader())
                 {
                     if (reader.Read())
                     {
                            return  new UsersDTO(

                            						 UserID:(int)reader ["UserID"],
						 FullName:(string)reader ["FullName"],
						 Email:(string)reader ["Email"],
						 Password:(string)reader ["Password"],
						 IsActive:(bool)reader ["IsActive"],

                            );
                        
                     }
                 }

                    }
                }
                catch (Exception ex) { }

                return null;
            }
            
        
}


                          public static bool UpdateUsers(UsersDTO users)
{

            Nullable<int> rowAffected  = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

               
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateUsersByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@UserID", users.UserID);
						command.Parameters.AddWithValue("@FullName", users.FullName);
						command.Parameters.AddWithValue("@Email", users.Email);
						command.Parameters.AddWithValue("@Password", users.Password);
						command.Parameters.AddWithValue("@IsActive", users.IsActive);
;
                        rowAffected = command.ExecuteNonQuery();

                        

                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }
            
        
}


                          public static bool DeleteUsers(int UserID)
{

            Nullable<int> rowAffected  = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteUsers", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@UserID", UserID);

                        rowAffected = command.ExecuteNonQuery();

                        

                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }
            
        
}

                        
                 }
             } 
                
            
             