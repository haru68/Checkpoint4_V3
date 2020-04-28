

namespace Checkpoint4_V2
{
    public class Price
    {
        public int AdultPrice { get => 15; }
        public int ChildPrice { get => 10; }

        public static Price GetPrice()
        {
            return new Price();
        }
    }
}
