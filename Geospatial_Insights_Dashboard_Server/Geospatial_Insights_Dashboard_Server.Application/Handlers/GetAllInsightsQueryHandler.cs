using Geospatial_Insights_Dashboard_Server.Application.IRepository;
using Geospatial_Insights_Dashboard_Server.Application.Queries;
using Geospatial_Insights_Dashboard_Server.Domain.Entities;
using MediatR;

namespace Geospatial_Insights_Dashboard_Server.Application.Handlers
{
    public class GetAllInsightsQueryHandler : IRequestHandler<GetAllInsightsQuery, IEnumerable<Insights>>
    {
        private readonly IInsightsRepository _repository;

        public GetAllInsightsQueryHandler(IInsightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Insights>> Handle(GetAllInsightsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllInsightsAsync();
        }
    }
}
