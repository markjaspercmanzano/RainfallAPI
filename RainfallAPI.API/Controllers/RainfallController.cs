using MediatR;
using Microsoft.AspNetCore.Mvc;
using RainfallAPI.Application.Queries.GetRainfallReadingQuery;
using RainfallAPI.Domain.Models.Errors;
using RainfallAPI.Domain.Models.RainfallReadings;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RainfallAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <description></description>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Operations relating to rainfall")]
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
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <returns></returns>
        /// <response code="200">A list of rainfall readings successfully retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No readings found for the specified stationId</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("id/{stationId}/readings")]
        [SwaggerOperation(
            Summary = "Get rainfall readings by station Id",
            Description = "Retrieve the latest readings for the specified stationId",
            OperationId = "get-rainfall",
            Tags = new[] { "Rainfall" })]
        [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetRainfallReadings([FromRoute] string stationId, 
            [FromQuery, Range(1, 100)] int? count = 10)
        {
            var response = await _mediator.Send(new GetRainfallReadingQuery { StationId = stationId, Count = count });

            if (response.ErrorResponses != null && response.ErrorResponses.Errors.Count > 0)
            {
                return BadRequest(response.ErrorResponses);
            }

            if (response.RainfallReadings.Readings.Count == 0)
            {
                return NotFound(response.ErrorResponses);
            }

            return Ok(response.RainfallReadings);
        }
        #endregion
    }
}
