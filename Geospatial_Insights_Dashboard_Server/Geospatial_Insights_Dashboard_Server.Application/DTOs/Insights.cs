using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.DTOs
{
    public class InsightsDto
    {
        public int InsightId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Impact { get; set; }
        public int? Likelihood { get; set; }
        public int? Intensity { get; set; }
        public DateTime? Added { get; set; }
        public DateTime? Published { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public int? Relevance { get; set; }
        public int? SectorId { get; set; }
        public int? TopicId { get; set; }
        public int? SwotId { get; set; }
        public int? PestleId { get; set; }
        public int? RegionId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
    }
}
