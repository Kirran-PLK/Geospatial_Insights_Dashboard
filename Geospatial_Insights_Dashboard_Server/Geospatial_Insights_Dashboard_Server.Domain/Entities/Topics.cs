using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geospatial_Insights_Dashboard_Server.Domain.Entities
{
    public class Topics
    {
        public int TopicId { get; set; }
        public string? TopicName { get; set; }

        public ICollection<Insights> Insights { get; set; } = new List<Insights>();
    }
}
