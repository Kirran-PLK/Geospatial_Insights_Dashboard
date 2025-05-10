using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.DTOs
{
    public class GeoMapInsight
    {
        public string? CityName { get; set; }
        public decimal? CityLat { get; set; }
        public decimal? CityLng { get; set; }

        public int? Intensity { get; set; }
        public int? Likelihood { get; set; }
        public int? Relevance { get; set; }

        public string? Title { get; set; }
        public string? Impact { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }

        public string? RegionName { get; set; }
        public string? CountryName { get; set; }
    }

}
