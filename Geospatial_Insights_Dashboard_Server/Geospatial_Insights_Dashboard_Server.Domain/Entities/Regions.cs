using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Domain.Entities
{
    public class Regions
    {
        public int RegionId { get; set; }
        public string? RegionName { get; set; }

        public ICollection<Countries> Countries { get; set; } = new List<Countries>();
        public ICollection<Insights> Insights { get; set; } = new List<Insights>();
    }
}
