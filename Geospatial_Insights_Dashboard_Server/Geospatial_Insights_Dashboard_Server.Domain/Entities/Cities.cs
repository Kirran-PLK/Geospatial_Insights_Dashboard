using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Domain.Entities
{
    public class Cities
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public decimal? Citylng { get; set; }
        public decimal? Citylat { get; set; }
        public int? CountryId { get; set; }
    }
}
