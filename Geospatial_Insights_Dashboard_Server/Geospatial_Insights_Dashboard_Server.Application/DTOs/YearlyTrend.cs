using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.DTOs
{
    public class YearlyTrend
    {
        public int Year { get; set; }
        public double? AvgIntensity { get; set; }
        public double? AvgLikelihood { get; set; }
        public double? AvgRelevance { get; set; }
    }

}
