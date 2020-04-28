using System;

namespace Checkpoint4_V2
{
    public partial class Tour
    {
        public Guid TourId { get; set; }
        public Performance Performance { get; set; }
        public DateTime Date { get; set; }
        public Address Place { get; set; }
        public int AvailableSeats { get; set; }
    }
}