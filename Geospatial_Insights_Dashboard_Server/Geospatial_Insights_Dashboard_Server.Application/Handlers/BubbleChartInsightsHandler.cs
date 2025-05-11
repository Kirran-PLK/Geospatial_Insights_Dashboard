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
    public class BubbleChartInsightsHandler : IRequestHandler<BubbleChartInsightsQuery, List<BubbleChartInsight>>
    {
        private readonly IInsightsRepository _repository;

        public BubbleChartInsightsHandler(IInsightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BubbleChartInsight>> Handle(BubbleChartInsightsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetBubbleChartDataAsync(
                request.RegionId,
                request.CountryId,
                request.TopicId,
                request.Year,
                cancellationToken);
        }
    }

}
