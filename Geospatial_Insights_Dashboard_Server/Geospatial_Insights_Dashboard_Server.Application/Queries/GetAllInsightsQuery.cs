using Geospatial_Insights_Dashboard_Server.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.Queries
{
    public class GetAllInsightsQuery : IRequest<IEnumerable<Insights>>
    {
    }
}
