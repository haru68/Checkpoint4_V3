using System;

namespace Checkpoint4_V2
{
    public partial class Address
    {
        public Guid AddressId { get; set; }
        public Int16 StreetNumber { get; set; }
        public String StreetName { get; set; }
        public City City { get; set; }
    }
}