using MediatR;
using Microsoft.AspNetCore.Mvc;
using RainfallAPI.Application.Queries.GetRainfallReadingQuery;

namespace RainfallAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Constructor
        /// <summary>
        /// </summary>
        /// <param name="mediator"></param>
        public RainfallController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Endpoints
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRainfallReadings([FromRoute] string stationId, [FromQuery] int? count)
        {
            var response = await _mediator.Send(new GetRainfallReadingQuery { StationId = stationId, Count = count });
            // to-do: implementation via mediator 
            // var response = new 
            return NotFound();
        }
        #endregion
    }
}
