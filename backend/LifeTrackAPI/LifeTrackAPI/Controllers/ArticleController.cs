using LifeTrackBL;
using LifeTrackDB_Business;
using LifeTrackDL;
using LifeTrackDL.Model;
using Microsoft.AspNetCore.Mvc;
using static LifeTrackAPI.Model.ArticleDTOS;

namespace LifeTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddNewArticle([FromBody] NewArticleDTO newArticleDTO)
        {

            if (newArticleDTO == null)
            {
                return BadRequest(new { success = false, message = "Invalid Article data." });
            }

            ArticlesDTO dto = new ArticlesDTO(-1, newArticleDTO.Title, newArticleDTO.Description, newArticleDTO.UserID, DateTime.Now, DateTime.Now);

            clsArticles article = new clsArticles(dto, clsArticles.enMode.AddNew);
            article.Save();

            if (article.ArticleID <= 0)
            {
                return BadRequest(new { success = false, message = "Article could not be created." });
            }

            //var token = _jwtTokenService.GenerateToken(person.PersonID);

            // return CreatedAtRoute("RegisterPerson", new { success = true, token });
            //return CreatedAtRoute("GetPersonById", new { id = user.UserID }, user);
            return Ok(new { success = true, data = article });


        }



        [HttpPut("{id}", Name = "updateArticle")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateArticle(int id, [FromBody] UpdateArticleDTO updateArticleDTO)
        {
            // Validate the incoming DTO
            if (updateArticleDTO == null || id != updateArticleDTO.ArticleID)
            {
                return BadRequest(new { success = false, message = "Article data is invalid." });
            }

            // Find the existing entity
            var existingArticle = clsArticles.GetArticlesInfoByID(updateArticleDTO.ArticleID);
            if (existingArticle == null)
            {
                return NotFound(new { success = false, message = $"No Article found with ID {updateArticleDTO.ArticleID}" });
            }



            // Update properties using reflection
            existingArticle.Title = updateArticleDTO.Title;
            existingArticle.Description = updateArticleDTO.Description;


            // Save the changes
            if (existingArticle.Save())
            {
                return Ok(new { success = true, data = existingArticle }); // Return the updated entity

            }

            return Conflict(new { success = false, message = $"Article with ID {id} could not be update due to a conflict." });
        }


        [HttpGet("getArticles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ArticlesDTO>> GetAllArticles()
        {
            List<ArticlesDTO> articleList = clsArticles.GetAllArticles();

            if (articleList == null)
            {
                return NotFound(new { success = true, message = "There is no Articles" });
            }
            return Ok(new { success = true, data = articleList });
        }



        [HttpGet("{id}", Name = "getArticleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetArticleById(int id)
        {
            if (id < 1)
            {
                return BadRequest(new { success = false, message = $"Not accepted ID " });
            }


            var articleDTO = clsArticles.GetArticlesInfoByID(id);

            if (articleDTO == null)
            {
                return NotFound(new { success = false, message = $"Article with  ArticleID not found." });
            }


            if (articleDTO.ArticleID != 0)
            {
                return Ok(new { success = true, data = articleDTO });
            }
            return Conflict(new { success = false, message = $"Article with ID {id} could not be found due to a conflict." });

        }


    }
}
