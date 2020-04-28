using System.Linq;

namespace Checkpoint4_V2
{
    public static class AddressLoader
    {
        public static Address Load(short streetNumber, string streetName, City city)
        {
            Address address;
            using (var context = new CircusContext())
            {
                address = (from a in context.Addresses
                           where a.City == city && a.StreetName == streetName && a.StreetNumber == streetNumber
                           select a).FirstOrDefault();
            }
            return address;
        }

        
    }
}
