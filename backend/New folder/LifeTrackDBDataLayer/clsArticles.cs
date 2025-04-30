
            using System;
            using System.Data;
            using Microsoft.Data.SqlClient;

            
             namespace LifeTrackDBDataAccessLayer
             {
                
                public class ArticlesDTO
                {
                    	 public int ArticleID  {get; set;}
	 public string Title  {get; set;}
	 public string Description  {get; set;}
	 public int UserID  {get; set;}
	 public DateTime CreatedAt  {get; set;}
	 public DateTime UpdatedAt  {get; set;}
            
                    
            public ArticlesDTO( int  ArticleID,  string  Title,  string  Description,  int  UserID,  DateTime  CreatedAt,  DateTime  UpdatedAt){
this.ArticleID = ArticleID ;
this.Title = Title ;
this.Description = Description ;
this.UserID = UserID ;
this.CreatedAt = CreatedAt ;
this.UpdatedAt = UpdatedAt ;   
                }
                }
                
                
                 public  class clsArticlesData
                 {
                           
                          public static List<ArticlesDTO> GetAllArticles()
{

            List<ArticlesDTO> articlesList = new List<ArticlesDTO>();
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) {
               connection.Open();

            string Query = "select * From FN_GetAllArticles()";
            try
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var articles = new ArticlesDTO(
                                						 ArticleID:(int)reader ["ArticleID"] ,
						 Title:(string)reader ["Title"] ,
						 Description:(string)reader ["Description"] ,
						 UserID:(int)reader ["UserID"] ,
						 CreatedAt:(DateTime)reader ["CreatedAt"] ,
						 UpdatedAt:(DateTime)reader ["UpdatedAt"] ,

                            );

                            articlesList.Add(articles);
                        }
                    }

                }
            }
            catch (Exception ex) { }

            return articlesList;
            }
               
           
}


                          public static Nullable<int> AddNewArticles(ArticlesDTO articles)
{

            Nullable<int> NewArticlesID = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewArticles", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                       						command.Parameters.AddWithValue("@Title", articles.Title);
						command.Parameters.AddWithValue("@Description", articles.Description);
						command.Parameters.AddWithValue("@UserID", articles.UserID);
						command.Parameters.AddWithValue("@CreatedAt", articles.CreatedAt);
						command.Parameters.AddWithValue("@UpdatedAt", articles.UpdatedAt);
;
                        SqlParameter outputIdParam = new SqlParameter("@ArticleID", SqlDbType.Int);
                        {
                            outputIdParam.Direction = ParameterDirection.Output;
                        };
                        command.Parameters.Add(outputIdParam);
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                        {
                            NewArticlesID = Convert.ToInt32(outputIdParam.Value);
                        }

                    }
                }
                catch (Exception ex) { }

                return NewArticlesID;
            }
            
        
}
 

                          public static ArticlesDTO GetArticlesInfoByID(int ArticleID)
{

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
               
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_GetArticlesInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@ArticleID", ArticleID);


                using (SqlDataReader reader = command.ExecuteReader())
                 {
                     if (reader.Read())
                     {
                            return  new ArticlesDTO(

                            						 ArticleID:(int)reader ["ArticleID"],
						 Title:(string)reader ["Title"],
						 Description:(string)reader ["Description"],
						 UserID:(int)reader ["UserID"],
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


                          public static bool UpdateArticles(ArticlesDTO articles)
{

            Nullable<int> rowAffected  = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

               
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateArticlesByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@ArticleID", articles.ArticleID);
						command.Parameters.AddWithValue("@Title", articles.Title);
						command.Parameters.AddWithValue("@Description", articles.Description);
						command.Parameters.AddWithValue("@UserID", articles.UserID);
						command.Parameters.AddWithValue("@CreatedAt", articles.CreatedAt);
						command.Parameters.AddWithValue("@UpdatedAt", articles.UpdatedAt);
;
                        rowAffected = command.ExecuteNonQuery();

                        

                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }
            
        
}


                          public static bool DeleteArticles(int ArticleID)
{

            Nullable<int> rowAffected  = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                connection.Open();

                
                try
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteArticles", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                       						command.Parameters.AddWithValue("@ArticleID", ArticleID);

                        rowAffected = command.ExecuteNonQuery();

                        

                    }
                }
                catch (Exception ex) { }

                return (rowAffected != 0);
            }
            
        
}

                        
                 }
             } 
                
            
             