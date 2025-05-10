using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.DTOs
{
    public class RegionCountryInsightStatsDto
    {
        public string GroupName { get; set; } // Region name or Country name
        public int InsightCount { get; set; }
        public double TotalIntensity { get; set; }
        public double TotalLikelihood { get; set; }
        public double TotalRelevance { get; set; }
    }

}
