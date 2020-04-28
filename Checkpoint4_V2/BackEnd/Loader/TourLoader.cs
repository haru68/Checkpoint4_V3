using System.Collections.Generic;
using System.Linq;

namespace Checkpoint4_V2
{
    public static class TourLoader
    {
        public static List<Tour> Load()
        {
            List<Tour> tours;
            using (var context = new CircusContext())
            {
                List<Tour> tempTours = (from t in context.Tours
                         select t).ToList();
                List<Performance> performances = (from p in context.Performances
                                                  select p).ToList();
                List<Address> addresses = (from a in context.Addresses
                                            select a).ToList();
                List<City> cities = (from c in context.Cities
                                     select c).ToList();
                List<Region> regions = (from r in context.Regions
                                        select r).ToList();
                List<Country> countries = (from c in context.Countries
                                           select c).ToList();
                tours = (from t in tempTours
                         join a in addresses on t.Place equals a
                         join c in cities on a.City equals c
                         join r in regions on c.Region equals r
                         join co in countries on r.Country equals co
                         join p in performances on t.Performance equals p
                         select t).ToList();
            }
            return tours;
        }


        public static List<Tour> Load(Performance performance)
        {
            List<Tour> tours;
            using (var context = new CircusContext())
            {
                List<Tour> tempTours = (from t in context.Tours
                                        where t.Performance == performance
                                        select t).ToList();
                
                List<Address> addresses = (from a in context.Addresses
                                           select a).ToList();
                List<City> cities = (from c in context.Cities
                                     select c).ToList();
                List<Region> regions = (from r in context.Regions
                                        select r).ToList();
                List<Country> countries = (from c in context.Countries
                                           select c).ToList();
                tours = (from t in tempTours
                         join a in addresses on t.Place equals a
                         join c in cities on a.City equals c
                         join r in regions on c.Region equals r
                         join co in countries on r.Country equals co
                         select t).ToList();
                tours.ForEach(t => t.Performance = performance);
            }
            return tours;
        }
    }
}
