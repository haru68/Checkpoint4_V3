using System;
using System.Collections.Generic;

namespace Checkpoint4_V2
{
    public class Performance
    {
        public Guid PerformanceId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public List<Star> Stars { get; set; }
        public List<Tour> Tours { get; set; }
        public string Description { get; set; }
    }
}