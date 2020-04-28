using System.Linq;

namespace Checkpoint4_V2
{
    public static class CityLoader
    {
        public static City Load(string cityName, string postalCode)
        {
            City city;
            using (var context = new CircusContext())
            {
                city = (from c in context.Cities
                          where c.Name == cityName && c.PostalCode == postalCode
                          select c).FirstOrDefault();
            }
            return city;
        }
    }
}
