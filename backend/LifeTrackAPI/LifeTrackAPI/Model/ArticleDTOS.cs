using LifeTrackBL;
using LifeTrackDL;

namespace LifeTrackAPI.Model
{
    public class ArticleDTOS
    {

        public  class NewArticleDTO
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int UserID { get; set; }

           

           
        }


        public class UpdateArticleDTO
        {
            public int ArticleID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }



        }

    }
}
