
namespace Checkpoint4_V2
{
    public static class AddressFactory
    {
        public static Address Get(short streetNumber, string streetName, City city)
        {
            Address address;
            if (Address.IsInDb(streetNumber, streetName, city))
            {
                address = AddressLoader.Load(streetNumber, streetName, city);
            }
            else
            {
                address = AddressFactory.Create(streetNumber, streetName, city);
                address.RecordInDb();
            }
            return address;
        }

        private static Address Create(short streetNumber, string streetName, City city)
        {
            Address address = new Address();
            address.StreetName = streetName;
            address.StreetNumber = streetNumber;
            address.City = city;
            return address;
        }
    }
}
