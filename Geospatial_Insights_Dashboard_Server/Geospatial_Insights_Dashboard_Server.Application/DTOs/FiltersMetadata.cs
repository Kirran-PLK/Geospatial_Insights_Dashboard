using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Application.DTOs
{
    public class FiltersMetadata
    {
        public List<string> Topics { get; set; }
        public List<string> Sectors { get; set; }
        public List<string> Swot { get; set; }
        public List<string> Pestle { get; set; }
        public List<string> Regions { get; set; }
        public List<string> Countries { get; set; }
        public List<string> Cities { get; set; }
        public List<int> StartYears { get; set; }
        public List<int> EndYears { get; set; }
    }

}
