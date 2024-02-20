using Microsoft.AspNetCore.Mvc;
using RainfallAPI.Domain.Models;

namespace RainfallAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRainfallReadings([FromRoute] string stationId, [FromQuery] int? count)
        {
            // to-do: implementation via mediator 
            // var response = new 
            return NotFound();
        }
    }
}
