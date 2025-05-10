using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.Queries
{
    public class GetYearlyTrendsQuery : IRequest<List<YearlyTrend>>
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public GetYearlyTrendsQuery(int startYear, int endYear)
        {
            StartYear = startYear;
            EndYear = endYear;
        }
    }
}
