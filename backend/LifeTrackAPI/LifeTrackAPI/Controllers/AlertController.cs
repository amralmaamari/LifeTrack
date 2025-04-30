using LifeTrackBL;
using LifeTrackDB_Business;
using LifeTrackDL;
using Microsoft.AspNetCore.Mvc;
using static LifeTrackAPI.Model.AlertDTOS;
using static LifeTrackAPI.Model.ArticleDTOS;

namespace LifeTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : Controller
    {

        [HttpGet("{id}", Name = "getAlertById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAlertInfoById(int id)
        {
            if (id < 1)
            {
                return BadRequest(new { success = false, message = $"Not accepted ID " });
            }


            clsAlerts alertDTO = clsAlerts.GetAlertsInfoByID(id);

            if (alertDTO == null)
            {
                return NotFound(new { success = false, message = $"Alert with  AlertID not found." });
            }


            var challengetDTO = alertDTO.TaskInfo.ChallengesInfo;

            if (challengetDTO == null)
            {
                return NotFound(new { success = false, message = $"Challenge with  ChallengeID not found." });
            }


            //here i stopped make it to work
            GetAlertInfoDTO getAlertInfo = new GetAlertInfoDTO
            {
                AlertId = alertDTO.AlertID,
                TaskId = alertDTO.TaskID,
                MeasurementID = alertDTO.MeasurementID,
                ScoreMeasurement = alertDTO.ScoreMeasurement,
                Notice = alertDTO.Notice,
                DateAndTime = alertDTO.DateAndTime,
                IsCompleted = alertDTO.IsCompleted,
                Title = challengetDTO.Title,
                Description = challengetDTO.Description

            };
            if (getAlertInfo != null)
            {
                return Ok(new { success = true, data = getAlertInfo });
            }
            return Conflict(new { success = false, message = $"Article with ID {id} could not be found due to a conflict." });

        }


        [HttpPut("{id}", Name = "updateAlert")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateAlert(int id, [FromBody] UpdateAlertDTO updateAlertDTO)
        {
            // Validate the incoming DTO
            if (updateAlertDTO == null || id != updateAlertDTO.AlertId)
            {
                return BadRequest(new { success = false, message = "Alert data is invalid." });
            }

            // Find the existing entity
            var existingAlert = clsAlerts.GetAlertsInfoByID(updateAlertDTO.AlertId);
            if (existingAlert == null)
            {
                return NotFound(new { success = false, message = $"No Alert found with ID {updateAlertDTO.AlertId}" });
            }



            // Update properties using reflection
            existingAlert.ScoreMeasurement = updateAlertDTO.ScoreMeasurement;
            existingAlert.Notice = updateAlertDTO.Notice;
            existingAlert.IsCompleted = updateAlertDTO.IsCompleted;


            // Save the changes
            if (existingAlert.Save())
            {
                return Ok(new { success = true, data = existingAlert }); // Return the updated entity

            }

            return Conflict(new { success = false, message = $"Alert with ID {id} could not be update due to a conflict." });
        }

    }
}
