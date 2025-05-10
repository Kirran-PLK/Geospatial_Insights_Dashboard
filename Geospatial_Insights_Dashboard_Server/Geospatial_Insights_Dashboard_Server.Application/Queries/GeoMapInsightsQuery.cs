using Geospatial_Insights_Dashboard_Server.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.Queries
{
    public class GeoMapInsightsQuery : IRequest<List<GeoMapInsightDto>>
    {
        // No parameters needed for now
    }
}
