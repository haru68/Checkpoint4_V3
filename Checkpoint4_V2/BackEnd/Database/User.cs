using System;

namespace Checkpoint4_V2
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
    }
}
