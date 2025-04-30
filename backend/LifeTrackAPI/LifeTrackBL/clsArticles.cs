
using System;
using System.Data;
using System.Data.SqlClient;
using LifeTrackDL;
using LifeTrackDL.Model;

namespace LifeTrackBL
{
    public class clsArticles
    {


        public enum enMode { AddNew = 0, Update = 1 }
        public static enMode Mode = enMode.AddNew;

        public ArticlesDTO articlesDTO
        {
            get
            {
                return new ArticlesDTO(
              this.ArticleID,
              this.Title,
              this.Description,
              this.UserID,
              this.CreatedAt,
              this.UpdatedAt
        
               );
            }
        }

        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public clsArticles()
        {
            this.ArticleID = -1;

            this.Title = "";

            this.Description = "";

            this.UserID = -1;

            this.CreatedAt = DateTime.Now;

            this.UpdatedAt = DateTime.Now;

            Mode = enMode.AddNew;
        }

     

        public clsArticles(ArticlesDTO articles, enMode mode = enMode.AddNew)
        {

            this.ArticleID = articles.ArticleID;

            this.Title = articles.Title;

            this.Description = articles.Description;

            this.UserID = articles.UserID;

            this.CreatedAt = articles.CreatedAt;

            this.UpdatedAt = articles.UpdatedAt;

            Mode = mode;
        }
        public static List<ArticlesDTO> GetAllArticles()
        {
            return clsArticlesData.GetAllArticles();

        }


        public static clsArticles GetArticlesInfoByID(int ArticleID)
        {
            ArticlesDTO articlesDTO = clsArticlesData.GetArticlesInfoByID(ArticleID);

            if (articlesDTO != null)
            {
                return new clsArticles(articlesDTO, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewArticles()
        {

            this.ArticleID = (int)clsArticlesData.AddNewArticles(this.articlesDTO);
            return (this.ArticleID != -1);

        }

        private bool _UpdateArticles()
        {

            return (clsArticlesData.UpdateArticles(this.articlesDTO));
        }

        public bool Save()
        {

            if (Mode == enMode.AddNew)
            {
                if (_AddNewArticles())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return _UpdateArticles();
            }

        }

        public static bool DeleteArticles(int ArticleID)
        {
            return clsArticlesData.DeleteArticles(ArticleID);

        }



    }
}


