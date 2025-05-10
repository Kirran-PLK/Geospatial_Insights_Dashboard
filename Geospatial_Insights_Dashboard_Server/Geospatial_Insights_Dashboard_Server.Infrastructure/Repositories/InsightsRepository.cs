
using Geospatial_Insights_Dashboard_Server.Application.IRepository;
using Geospatial_Insights_Dashboard_Server.Domain.Entities;
using Geospatial_Insights_Dashboard_Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Infrastructure.Repositories
{
    public class InsightsRepository : IInsightsRepository
    {
        private readonly AppDbContext _context;

        public InsightsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Insights>> GetAllInsightsAsync()
        {
            return await _context.Insights.ToListAsync();
        }


    }
    

}
