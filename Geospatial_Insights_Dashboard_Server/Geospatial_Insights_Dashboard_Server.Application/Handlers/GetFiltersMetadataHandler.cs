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
    public class GetFiltersMetadataHandler : IRequestHandler<GetFiltersMetadataQuery, FiltersMetadata>
    {
        private readonly IInsightsRepository _repository;

        public GetFiltersMetadataHandler(IInsightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<FiltersMetadata> Handle(GetFiltersMetadataQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetFiltersMetadataAsync(cancellationToken);
        }
    }

}
