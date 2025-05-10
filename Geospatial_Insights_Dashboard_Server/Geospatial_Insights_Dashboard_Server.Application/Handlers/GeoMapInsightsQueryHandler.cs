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
    public class GeoMapInsightsQueryHandler : IRequestHandler<GeoMapInsightsQuery, List<GeoMapInsight>>
    {
        private readonly IInsightsRepository _repository;

        public GeoMapInsightsQueryHandler(IInsightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GeoMapInsight>> Handle(GeoMapInsightsQuery request, CancellationToken cancellationToken)
        {
            var insights = await _repository.GetInsightsWithGeoDataAsync(cancellationToken);

            var result = insights.Select(i => new GeoMapInsight
            {
                CityName = i.City?.CityName,
                CityLat = i.City?.Citylat,
                CityLng = i.City?.Citylng,

                Intensity = i.Intensity,
                Likelihood = i.Likelihood,
                Relevance = i.Relevance,

                Title = i.Title,
                Impact = i.Impact,
                StartYear = i.StartYear,
                EndYear = i.EndYear,

                CountryName = i.Country?.CountryName,
                RegionName = i.Region?.RegionName
            }).ToList();

            return result;
        }
    }
}
