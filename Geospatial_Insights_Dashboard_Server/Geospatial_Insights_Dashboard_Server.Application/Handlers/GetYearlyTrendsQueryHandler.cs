using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using Geospatial_Insights_Dashboard_Server.Application.IRepository;
using Geospatial_Insights_Dashboard_Server.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.Handlers
{
    public class GetYearlyTrendsQueryHandler : IRequestHandler<GetYearlyTrendsQuery, List<YearlyTrendDto>>
    {
        private readonly IInsightsRepository _insightsRepository;

        public GetYearlyTrendsQueryHandler(IInsightsRepository insightsRepository)
        {
            _insightsRepository = insightsRepository;
        }

        public async Task<List<YearlyTrendDto>> Handle(GetYearlyTrendsQuery request, CancellationToken cancellationToken)
        {
            var trends = await _insightsRepository.GetYearlyTrendsAsync(request.StartYear, request.EndYear, cancellationToken);

            return trends.Select(t => new YearlyTrendDto
            {
                Year = t.Year,
                AvgIntensity = t.Intensity,
                AvgLikelihood = t.Likelihood,
                AvgRelevance = t.Relevance
            }).ToList();
        }
    }
}
