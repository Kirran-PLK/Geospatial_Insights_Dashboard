using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Domain.Entities
{
    public class Swot
    {
        public int SwotId { get; set; }
        public string? SwotDescription { get; set; }
        public ICollection<Insights> Insights { get; set; } = new List<Insights>();
    }
}
