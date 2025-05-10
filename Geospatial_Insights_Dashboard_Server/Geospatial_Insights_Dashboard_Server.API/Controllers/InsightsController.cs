using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using Geospatial_Insights_Dashboard_Server.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Geospatial_Insights_Dashboard_Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InsightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<InsightsDto>>> Get()
        {
            var result = await _mediator.Send(new GetAllInsightsQuery());
            return Ok(result);
        }

        [HttpGet("geo-map")]
        public async Task<IActionResult> GetGeoMapInsights()
        {
            var result = await _mediator.Send(new GeoMapInsightsQuery());
            return Ok(result);
        }
    }
}
