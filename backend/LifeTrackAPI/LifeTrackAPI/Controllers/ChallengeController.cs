using LifeTrackBL;
using LifeTrackDB_Business;
using LifeTrackDL;
using LifeTrackDL.Model;
using Microsoft.AspNetCore.Mvc;
using static LifeTrackAPI.Model.ArticleDTOS;
using static LifeTrackDL.Model.ChallengeDTOS;
namespace LifeTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : Controller
    {
        [HttpGet("today-with-alerts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ArticlesDTO>> GetTodayTasksWithAlerts()
        {
            List<ChallengeTaskDTO> challengeList =clsChallenges.GetTodayTasksWithAlerts();

            if (challengeList == null)
            {
                return NotFound(new { success = true, message = "There is no Challenge" });
            }
            return Ok(new { success = true, data = challengeList });
        }


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddNewChallenge([FromBody] NewChallengeDTO newChallenge)
        {

            if (newChallenge == null)
            {
                return BadRequest(new { success = false, message = "Invalid Challenge data." });
            }
            var challenge = clsChallenges.AddChallengeWithTaskAndAlerts(newChallenge);

            
            if (challenge != null)
            {
                return Ok(new { success = true, data = new { challengeID = challenge } });


            }

            return BadRequest(new { success = false, message = "Challenge could not be created." });


        }


    //    [HttpPut("{id}", Name = "updateChallenge")]
    //    //[Authorize]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    public ActionResult UpdateChallenge(int id, [FromBody] UpdateArticleDTO updateArticleDTO)
    //    {
    //        // Validate the incoming DTO
    //        if (updateArticleDTO == null || id != updateArticleDTO.ArticleID)
    //        {
    //            return BadRequest(new { success = false, message = "Article data is invalid." });
    //        }

    //        // Find the existing entity
    //        var existingArticle = clsArticles.GetArticlesInfoByID(updateArticleDTO.ArticleID);
    //        if (existingArticle == null)
    //        {
    //            return NotFound(new { success = false, message = $"No Article found with ID {updateArticleDTO.ArticleID}" });
    //        }



    //        // Update properties using reflection
    //        existingArticle.Title = updateArticleDTO.Title;
    //        existingArticle.Description = updateArticleDTO.Description;


    //        // Save the changes
    //        if (existingArticle.Save())
    //        {
    //            return Ok(new { success = true, data = existingArticle }); // Return the updated entity

    //        }

    //        return Conflict(new { success = false, message = $"Article with ID {id} could not be update due to a conflict." });
    //    }

    }
}
