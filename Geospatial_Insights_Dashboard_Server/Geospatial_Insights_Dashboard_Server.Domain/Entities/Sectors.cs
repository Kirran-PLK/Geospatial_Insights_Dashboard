using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Domain.Entities
{
    public class Sectors
    {
        public int SectorId { get; set; }
        public string? SectorName { get; set; }

        public ICollection<Insights> Insights { get; set; } = new List<Insights>();

    }
}
