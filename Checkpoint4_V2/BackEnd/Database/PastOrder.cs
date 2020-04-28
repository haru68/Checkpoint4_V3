using System;

namespace Checkpoint4_V2
{
    public partial class PastOrder
    {
        public Guid PastOrderId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public Tour Tour { get; set; }
        public int AdultNumber { get; set; }
        public int ChildrenNumber { get; set; }
    }
}