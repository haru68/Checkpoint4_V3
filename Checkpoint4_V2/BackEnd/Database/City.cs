using System;

namespace Checkpoint4_V2
{
    public partial class City
    {
        public Guid CityId { get; set; }
        public String Name { get; set; }
        public String PostalCode { get; set; }
        public Region Region { get; set; }
    }
}