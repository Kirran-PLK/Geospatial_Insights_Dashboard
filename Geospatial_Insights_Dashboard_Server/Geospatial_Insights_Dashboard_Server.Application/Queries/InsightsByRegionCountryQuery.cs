using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.Queries
{
    public class InsightsByRegionCountryQuery : IRequest<List<RegionCountryInsightStats>>
    {
        public string GroupBy { get; set; } = "region"; // Default is region
        public int? Year { get; set; }
        public int? TopicId { get; set; }
        public int? SectorId { get; set; }
    }

}
