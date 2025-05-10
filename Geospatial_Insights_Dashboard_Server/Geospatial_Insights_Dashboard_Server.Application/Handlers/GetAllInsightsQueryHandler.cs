using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using Geospatial_Insights_Dashboard_Server.Application.IRepository;
using Geospatial_Insights_Dashboard_Server.Application.Queries;
using MediatR;

namespace Geospatial_Insights_Dashboard_Server.Application.Handlers
{
    public class GetAllInsightsQueryHandler : IRequestHandler<GetAllInsightsQuery, List<InsightsDto>>
    {
        private readonly IInsightsRepository _repository;

        public GetAllInsightsQueryHandler(IInsightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<InsightsDto>> Handle(GetAllInsightsQuery request, CancellationToken cancellationToken)
        {
            var insights = await _repository.GetAllInsightsAsync();

            return insights.Select(i => new InsightsDto
            {
                InsightId = i.InsightId,
                Title = i.Title,
                Url = i.Url,
                Impact = i.Impact,
                Likelihood = i.Likelihood,
                Intensity = i.Intensity,
                Added = i.Added,
                Published = i.Published,
                StartYear = i.StartYear,
                EndYear = i.EndYear,
                Relevance = i.Relevance,
                SectorId = i.SectorId,
                TopicId = i.TopicId,
                SwotId = i.SwotId,
                PestleId = i.PestleId,
                RegionId = i.RegionId,
                CountryId = i.CountryId,
                CityId = i.CityId
            }).ToList();
        }
    }
}
