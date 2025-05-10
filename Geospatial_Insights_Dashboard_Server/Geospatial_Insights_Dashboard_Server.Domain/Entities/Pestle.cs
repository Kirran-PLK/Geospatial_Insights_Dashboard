using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Domain.Entities
{
    public class Pestle
    {
        public int PestleId { get; set; }
        public string? PestleDescription { get; set; }
        public ICollection<Insights> Insights { get; set; } = new List<Insights>();
    }
}
