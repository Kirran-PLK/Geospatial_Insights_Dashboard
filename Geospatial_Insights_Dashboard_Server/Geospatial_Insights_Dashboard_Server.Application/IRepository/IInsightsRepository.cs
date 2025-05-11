using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using Geospatial_Insights_Dashboard_Server.Domain.Entities;

namespace Geospatial_Insights_Dashboard_Server.Application.IRepository
{
    public interface IInsightsRepository
    {
        Task<IEnumerable<Insights>> GetAllInsightsAsync();
        Task<List<Insights>> GetInsightsWithGeoDataAsync(CancellationToken cancellationToken);
        Task<List<(int Year, double Intensity, double Likelihood, double Relevance)>> GetYearlyTrendsAsync(int startYear, int endYear, CancellationToken cancellationToken);
        Task<List<RegionCountryInsightStats>> GetInsightsGroupedByRegionOrCountryAsync(string groupBy, int? year, int? topicId, int? sectorId, CancellationToken cancellationToken);
        Task<List<TopicInsightCount>> GetInsightCountsByTopicAsync(int? regionId, int? year, CancellationToken cancellationToken);


    }
}
