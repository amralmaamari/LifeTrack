using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTrackDL.Model
{
    class clsArticlesDTO
    {
    }

    public class GetArticleDTO
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GetArticleDTO(int ArticleID, string Title, string Description)
        {
            this.ArticleID = ArticleID;
            this.Title = Title;
            this.Description = Description;
        }
    }
}
