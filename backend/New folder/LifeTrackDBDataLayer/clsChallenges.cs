
            using System;
            using System.Data;
            using Microsoft.Data.SqlClient;

            
             namespace LifeTrackDBDataAccessLayer
             {
                
                public class ChallengesDTO
                {
                    	 public int ChallengeID  {get; set;}
	 public int ArticleID  {get; set;}
	 public string Title  {get; set;}
	 public string Description  {get; set;}
	 public int DurationTimes  {get; set;}
	 public int TimesPerDay  {get; set;}
	 public DateTime StartDate  {get; set;}
	 public DateTime EndDate  {get; set;}
	 public DateTime CreatedAt  {get; set;}
	 public DateTime UpdatedAt  {get; set;}
	 public int UserID  {get; set;}
            
                    
            public ChallengesDTO( int  ChallengeID,  int  ArticleID,  string  Title,  string  Description,  int  DurationTimes,  int  TimesPerDay,  DateTime  StartDate,  DateTime  EndDate,  DateTime  CreatedAt,  DateTime  UpdatedAt,  int  UserID){
this.ChallengeID = ChallengeID ;
this.ArticleID = ArticleID ;
this.Title = Title ;
this.Description = Description ;
this.DurationTimes = DurationTimes ;
this.TimesPerDay = TimesPerDay ;
this.StartDate = StartDate ;
this.EndDate = EndDate ;
this.CreatedAt = CreatedAt ;
this.UpdatedAt = UpdatedAt ;
this.UserID = UserID ;   
                }
                }
                
                
                 public  class clsChallengesData
                 {
                           
                          public static List<ChallengesDTO> GetAllChallenges()
{

            List<ChallengesDTO> challengesList = new List<ChallengesDTO>();
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) {
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
                                						 ChallengeID:(int)reader ["ChallengeID"] ,
						 ArticleID:(int)reader ["ArticleID"] ,
						 Title:(string)reader ["Title"] ,
						 Description:(string)reader ["Description"] ,
						 DurationTimes:(int)reader ["DurationTimes"] ,
						 TimesPerDay:(int)reader ["TimesPerDay"] ,
						 StartDate:(DateTime)reader ["StartDate"] ,
						 EndDate:(DateTime)reader ["EndDate"] ,
						 CreatedAt:(DateTime)reader ["CreatedAt"] ,
						 UpdatedAt:(DateTime)reader ["UpdatedAt"] ,
						 UserID:(int)reader ["UserID"] ,

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
                        };
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
                            return  new ChallengesDTO(

                            						 ChallengeID:(int)reader ["ChallengeID"],
						 ArticleID:(int)reader ["ArticleID"],
						 Title:(string)reader ["Title"],
						 Description:(string)reader ["Description"],
						 DurationTimes:(int)reader ["DurationTimes"],
						 TimesPerDay:(int)reader ["TimesPerDay"],
						 StartDate:(DateTime)reader ["StartDate"],
						 EndDate:(DateTime)reader ["EndDate"],
						 CreatedAt:(DateTime)reader ["CreatedAt"],
						 UpdatedAt:(DateTime)reader ["UpdatedAt"],
						 UserID:(int)reader ["UserID"],

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

            Nullable<int> rowAffected  = null;
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

            Nullable<int> rowAffected  = null;
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

                        
                 }
             } 
                
            
             