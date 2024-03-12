using System;
using System.Collections.Generic;
using System.Text;

namespace WAZ_Assessment.Models
{
    public class PlatformDummy
    {
        public int id { get; set; }
        public string uniqueName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime lastUpdate { get; set; }
        public WellDummy well { get; set; }
    }
}
