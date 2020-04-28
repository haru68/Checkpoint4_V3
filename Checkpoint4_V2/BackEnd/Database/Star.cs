using System;

namespace Checkpoint4_V2
{
    public class Star
    {
        public Guid StarId { get; set; }
        public String FamilyName { get; set; }
        public String FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public String Biography { get; set; }
        public String Picture { get; set; }
        public Performance Performance { get; set; }
    }
}