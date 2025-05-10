
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

        public async Task<List<RegionCountryInsightStatsDto>> GetInsightsGroupedByRegionOrCountryAsync(string groupBy, int? year, int? topicId, int? sectorId, CancellationToken cancellationToken)
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

            IQueryable<RegionCountryInsightStatsDto> grouped = groupBy.ToLower() switch
            {
                "country" => insights
                    .Where(i => i.Country != null)
                    .GroupBy(i => i.Country.CountryName)
                    .Select(g => new RegionCountryInsightStatsDto
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
                    .Select(g => new RegionCountryInsightStatsDto
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





    }


}
