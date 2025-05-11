using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using Geospatial_Insights_Dashboard_Server.Domain.Entities;

namespace Geospatial_Insights_Dashboard_Server.Application.IRepository
{
    public interface IInsightsRepository
    {
        Task<IEnumerable<Insight>> GetAllInsightsAsync();
        Task<List<Insight>> GetInsightsWithGeoDataAsync(CancellationToken cancellationToken);
        Task<List<(int Year, double Intensity, double Likelihood, double Relevance)>> GetYearlyTrendsAsync(int startYear, int endYear, CancellationToken cancellationToken);
        Task<List<RegionCountryInsightStats>> GetInsightsGroupedByRegionOrCountryAsync(string groupBy, int? year, int? topicId, int? sectorId, CancellationToken cancellationToken);
        Task<List<TopicInsightCount>> GetInsightCountsByTopicAsync(int? regionId, int? year, CancellationToken cancellationToken);
        Task<List<BubbleChartInsight>> GetBubbleChartDataAsync(int? regionId, int? countryId, int? topicId, int? year, CancellationToken cancellationToken);
        Task<FiltersMetadata> GetFiltersMetadataAsync(CancellationToken cancellationToken);


    }
}
