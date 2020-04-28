using System;

namespace Checkpoint4_V2
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public String Name { get; set; }
        public Country Country { get; set; }
    }
}