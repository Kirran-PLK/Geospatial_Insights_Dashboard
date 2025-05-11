
using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using Geospatial_Insights_Dashboard_Server.Application.IRepository;
using Geospatial_Insights_Dashboard_Server.Domain.Entities;
using Geospatial_Insights_Dashboard_Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Infrastructure.Repositories
{
    public class InsightsRepository : IInsightsRepository
    {
        private readonly AppDbContext _context;

        public InsightsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Insights>> GetAllInsightsAsync()
        {
            return await _context.Insights.ToListAsync();
        }

        public async Task<List<Insights>> GetInsightsWithGeoDataAsync(CancellationToken cancellationToken)
        {
            return await _context.Insights
                .Include(i => i.City)
                .Include(i => i.Country)
                .Include(i => i.Region)
                .Where(i => i.City != null && i.City.Citylat != null && i.City.Citylng != null)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<(int Year, double Intensity, double Likelihood, double Relevance)>> GetYearlyTrendsAsync(int startYear, int endYear, CancellationToken cancellationToken)
        {
            var result = await _context.Insights
                .Where(i => i.StartYear != null && i.StartYear >= startYear && i.StartYear <= endYear)
                .GroupBy(i => i.StartYear.Value)
                .Select(g => new
                {
                    Year = g.Key,
                    Intensity = g.Average(i => i.Intensity ?? 0),
                    Likelihood = g.Average(i => i.Likelihood ?? 0),
                    Relevance = g.Average(i => i.Relevance ?? 0)
                })
                .OrderBy(r => r.Year)
                .ToListAsync(cancellationToken); // Materializes the query

            // Map to tuple after query execution (in-memory)
            return result
                .Select(x => (x.Year, x.Intensity, x.Likelihood, x.Relevance))
                .ToList();
        }

        public async Task<List<RegionCountryInsightStats>> GetInsightsGroupedByRegionOrCountryAsync(string groupBy, int? year, int? topicId, int? sectorId, CancellationToken cancellationToken)
        {
            var insights = _context.Insights
                .Include(i => i.Region)
                .Include(i => i.Country)
                .AsQueryable();

            if (year.HasValue)
                insights = insights.Where(i => i.StartYear == year.Value);

            if (topicId.HasValue)
                insights = insights.Where(i => i.TopicId == topicId.Value);

            if (sectorId.HasValue)
                insights = insights.Where(i => i.SectorId == sectorId.Value);

            IQueryable<RegionCountryInsightStats> grouped = groupBy.ToLower() switch
            {
                "country" => insights
                    .Where(i => i.Country != null)
                    .GroupBy(i => i.Country.CountryName)
                    .Select(g => new RegionCountryInsightStats
                    {
                        GroupName = g.Key,
                        InsightCount = g.Count(),
                        TotalIntensity = g.Sum(x => x.Intensity ?? 0),
                        TotalLikelihood = g.Sum(x => x.Likelihood ?? 0),
                        TotalRelevance = g.Sum(x => x.Relevance ?? 0)
                    }),

                _ => insights
                    .Where(i => i.Region != null)
                    .GroupBy(i => i.Region.RegionName)
                    .Select(g => new RegionCountryInsightStats
                    {
                        GroupName = g.Key,
                        InsightCount = g.Count(),
                        TotalIntensity = g.Sum(x => x.Intensity ?? 0),
                        TotalLikelihood = g.Sum(x => x.Likelihood ?? 0),
                        TotalRelevance = g.Sum(x => x.Relevance ?? 0)
                    }),
            };

            return await grouped.OrderByDescending(g => g.InsightCount).ToListAsync(cancellationToken);
        }

        public async Task<List<TopicInsightCount>> GetInsightCountsByTopicAsync(int? regionId, int? year, CancellationToken cancellationToken)
        {
            var query = _context.Insights
                .Include(i => i.Topic)
                .AsQueryable();

            if (regionId.HasValue)
                query = query.Where(i => i.RegionId == regionId.Value);

            if (year.HasValue)
                query = query.Where(i => i.StartYear == year.Value);

            var result = await query
                .Where(i => i.Topic != null)
                .GroupBy(i => i.Topic.TopicName)
                .Select(g => new TopicInsightCount
                {
                    TopicName = g.Key,
                    InsightCount = g.Count()
                })
                .OrderByDescending(x => x.InsightCount)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<List<BubbleChartInsight>> GetBubbleChartDataAsync(int? regionId, int? countryId, int? topicId, int? year, CancellationToken cancellationToken)
        {
            var query = _context.Insights
                .Include(i => i.Region)
                .Include(i => i.Country)
                .AsQueryable();

            if (regionId.HasValue)
                query = query.Where(i => i.RegionId == regionId.Value);

            if (countryId.HasValue)
                query = query.Where(i => i.CountryId == countryId.Value);

            if (topicId.HasValue)
                query = query.Where(i => i.TopicId == topicId.Value);

            if (year.HasValue)
                query = query.Where(i => i.StartYear == year.Value);

            return await query
                .Select(i => new BubbleChartInsight
                {
                    Likelihood = i.Likelihood,
                    Intensity = i.Intensity,
                    Relevance = i.Relevance,
                    Title = i.Title,
                    Impact = i.Impact,
                    StartYear = i.StartYear,
                    RegionName = i.Region.RegionName,
                    CountryName = i.Country.CountryName
                })
                .Where(i => i.Likelihood.HasValue && i.Intensity.HasValue && i.Relevance.HasValue)
                .ToListAsync(cancellationToken);
        }

        public async Task<FiltersMetadata> GetFiltersMetadataAsync(CancellationToken cancellationToken)
        {
            var topics = await _context.Topics.Select(t => t.TopicName).Distinct().ToListAsync(cancellationToken);
            var sectors = await _context.Sectors.Select(s => s.SectorName).Distinct().ToListAsync(cancellationToken);
            var swot = await _context.Swot.Select(s => s.SwotDescription).Distinct().ToListAsync(cancellationToken);
            var pestle = await _context.Pestle.Select(p => p.PestleDescription).Distinct().ToListAsync(cancellationToken);
            var regions = await _context.Regions.Select(r => r.RegionName).Distinct().ToListAsync(cancellationToken);
            var countries = await _context.Countries.Select(c => c.CountryName).Distinct().ToListAsync(cancellationToken);
            var cities = await _context.Cities.Select(c => c.CityName).Distinct().ToListAsync(cancellationToken);
            var startYears = await _context.Insights
                .Where(i => i.StartYear.HasValue)
                .Select(i => i.StartYear.Value)
                .Distinct()
                .OrderBy(y => y)
                .ToListAsync(cancellationToken);
            var endYears = await _context.Insights
                .Where(i => i.EndYear.HasValue)
                .Select(i => i.EndYear.Value)
                .Distinct()
                .OrderBy(y => y)
                .ToListAsync(cancellationToken);

            return new FiltersMetadata
            {
                Topics = topics,
                Sectors = sectors,
                Swot = swot,
                Pestle = pestle,
                Regions = regions,
                Countries = countries,
                Cities = cities,
                StartYears = startYears,
                EndYears = endYears
            };
        }








    }


}
