using Geospatial_Insights_Dashboard_Server.Domain.Entities;

namespace Geospatial_Insights_Dashboard_Server.Application.IRepository
{
    public interface IInsightsRepository
    {
        Task<IEnumerable<Insights>> GetAllInsightsAsync();
    }
}
