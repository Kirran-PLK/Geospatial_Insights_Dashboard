using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.DTOs
{
    public class BubbleChartInsight
    {
        public double? Likelihood { get; set; }  // X-axis
        public double? Intensity { get; set; }   // Y-axis
        public double? Relevance { get; set; }   // Bubble size
        public string Title { get; set; }
        public string Impact { get; set; }
        public int? StartYear { get; set; }
        public string RegionName { get; set; }   // Optional: For color
        public string CountryName { get; set; }  // Optional: For color
    }

}
