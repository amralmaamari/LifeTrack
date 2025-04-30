using System.Diagnostics.Metrics;
using LifeTrackDB_Business;
using LifeTrackDL;
using Microsoft.AspNetCore.Mvc;

namespace LifeTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : Controller
    {
        [HttpGet("getMeasurements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<MeasurementsDTO>> GetAllMeasurements()
        {
            List<MeasurementsDTO> measurementList = clsMeasurements.GetAllMeasurements();

            if (measurementList == null)
            {
                return NotFound(new { success = true, message = "There is no Measurements" });
            }
            return Ok(new { success = true, data = measurementList });
        }
    }
}
