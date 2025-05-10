using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Domain.Entities
{
    public class Countries
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public int RegionId { get; set; }
    }
}
