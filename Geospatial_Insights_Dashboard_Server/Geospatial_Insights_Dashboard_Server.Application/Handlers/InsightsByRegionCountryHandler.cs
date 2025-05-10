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
    public class InsightsByRegionCountryHandler : IRequestHandler<InsightsByRegionCountryQuery, List<RegionCountryInsightStats>>
    {
        private readonly IInsightsRepository _repository;

        public InsightsByRegionCountryHandler(IInsightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RegionCountryInsightStats>> Handle(
            InsightsByRegionCountryQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetInsightsGroupedByRegionOrCountryAsync(
                request.GroupBy,
                request.Year,
                request.TopicId,
                request.SectorId,
                cancellationToken);
        }
    }

}
