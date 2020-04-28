using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint4_V2
{
    public static class CityFactory
    {
        public static City Create(Region region)
        {
            City city = new City();
            city.Region = region;
            return city;
        }

        public static City Get(string cityName, string postalCode, Region region)
        {
            City city;
            if (City.IsInDb(cityName, postalCode))
            {
                city = CityLoader.Load(cityName, postalCode);
            }
            else
            {
                city = CityFactory.Create(region);
                city.RecordInDb();
            }
            return city;
        }
    }
}
