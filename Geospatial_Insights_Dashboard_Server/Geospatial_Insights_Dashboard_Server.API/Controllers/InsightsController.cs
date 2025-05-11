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

        [HttpGet("geo-map")]
        public async Task<IActionResult> GetGeoMapInsights()
        {
            var result = await _mediator.Send(new GeoMapInsightsQuery());
            return Ok(result);
        }

        [HttpGet("yearly-trends")]
        public async Task<IActionResult> GetYearlyTrends([FromQuery] int startYear, [FromQuery] int endYear)
        {
            if (startYear > endYear)
            {
                return BadRequest("Start year must be less than or equal to end year.");
            }

            var result = await _mediator.Send(new GetYearlyTrendsQuery(startYear, endYear));
            return Ok(result);
        }

        [HttpGet("by-region-country")]
        public async Task<IActionResult> GetInsightsByRegionCountry([FromQuery] string groupBy = "region", [FromQuery] int? year = null, [FromQuery] int? topicId = null, [FromQuery] int? sectorId = null)
        {
            var query = new InsightsByRegionCountryQuery
            {
                GroupBy = groupBy,
                Year = year,
                TopicId = topicId,
                SectorId = sectorId
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("by-topic")]
        public async Task<IActionResult> GetInsightsByTopic([FromQuery] int? regionId, [FromQuery] int? year)
        {
            var query = new InsightsByTopicQuery
            {
                RegionId = regionId,
                Year = year
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("bubble-chart-data")]
        public async Task<IActionResult> GetBubbleChartData([FromQuery] int? regionId, [FromQuery] int? countryId, [FromQuery] int? topicId, [FromQuery] int? year)
        {
            var result = await _mediator.Send(new BubbleChartInsightsQuery
            {
                RegionId = regionId,
                CountryId = countryId,
                TopicId = topicId,
                Year = year
            });

            return Ok(result);
        }



    }
}
