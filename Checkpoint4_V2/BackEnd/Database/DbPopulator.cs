using System;
using System.Collections.Generic;

namespace Checkpoint4_V2
{
    public class DbPopulator
    {
        private readonly CircusContext _context;

        public DbPopulator()
        {
            _context = new CircusContext();
        }

        public void Populate()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            List<Address> addresses = PopulateLocations();
            List<Star> stars = Stars();
            List<User> users = Users(addresses);
            List<Performance> performances = Performances(stars);
            List<Tour> tours = Tours(addresses, performances);
            Orders(users, tours);
            _context.SaveChanges();
            Console.WriteLine("DB populisation terminated");
        }

        private List<Address> PopulateLocations()
        {
            List<Country> countries = Countries();
            List<Region> regions = Regions(countries);
            List<City> cities = Cities(regions);
            List<Address> addresses = Addresses(cities);
            return addresses;
        }

        private  List<Country> Countries()
        {
            Country france = new Country() { Name = "France" };
            Country liechtenstein = new Country() { Name = "Liechtenstein" };
            List<Country> countries = new List<Country>() { france, liechtenstein };
            _context.AddRange(countries);
            return countries;
        }

        private List<Region> Regions(List<Country> countries)
        {
            int i = 0;
            List<Region> regions = new List<Region>();
            countries.ForEach(c =>
            {
                Region region1 = new Region() { Country = c, Name = $"Region {i}" };
                i += 1;
                regions.Add(region1);
                Region region2 = new Region() { Country = c, Name = $"Region {i}" };
                i += 1;
                regions.Add(region2);
            });
            _context.AddRange(regions);
            return regions;
        }

        private List<City> Cities(List<Region> regions)
        {
            List<City> cities = new List<City>();
            int i = 0;
            regions.ForEach(r =>
            {
                City city1 = new City() { PostalCode = $"950{i}", Region = r, Name = $"City{i}" };
                cities.Add(city1);
                i += 1;
                City city2 = new City() { PostalCode = $"950{i}", Region = r, Name = $"City{i}" };
                cities.Add(city2);
                i += 1;
            });
            _context.AddRange(cities);
            return cities;
        }

        private List<Address> Addresses(List<City> cities)
        {
            List<Address> addresses = new List<Address>();
            short i = 0;
            cities.ForEach(c =>
            {
                Address address1 = new Address() { City = c, StreetName = "Street name", StreetNumber = i };
                i += 1;
                addresses.Add(address1);
                Address address2 = new Address() { City = c, StreetName = "Street name", StreetNumber = i };
                i += 1;
                addresses.Add(address2);
            });
            _context.AddRange(addresses);
            return addresses;
        }

        private List<Star> Stars()
        {
            List<Star> stars = new List<Star>();
            Random randomGenerator = new Random();
            for(int i=0; i<5; i++)
            {
                Star star = new Star()
                {
                    Birthday = (DateTime.Now - TimeSpan.FromDays(randomGenerator.Next(9125, 29220))), 
                    FamilyName = "Smith",
                    FirstName = "John",
                    Biography = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                                "labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut ",
                    Picture = $@".\Front_Picture\Star{i}.jpg"
                };
                stars.Add(star);
            }
            _context.AddRange(stars);
            return stars;
        }

        private List<User> Users(List<Address> addresses)
        {
            List<User> users = new List<User>();
            Random randomGenerator = new Random();
            for (int i = 0; i<16; i++)
            {
                User user = new User()
                {
                    Birthday = (DateTime.Now - TimeSpan.FromDays(randomGenerator.Next(6570, 29220))),
                    Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", // mdp = 1234 crypté SHA 256
                    Login = $"user{i}",
                    Address = addresses[i]
                };
                users.Add(user);
                i += 1;
            }
            _context.AddRange(users);
            return users;
        }

        private List<Performance> Performances(List<Star> stars)
        {
            List<Performance> performances = new List<Performance>();
            List<Star> laughStars = new List<Star>() { stars[0], stars[1] };
            Performance laugh = new Performance() { Category = "Laugh", Name = "Clowns en folie", Stars = laughStars, Picture = @".\Front_Picture\Laugh.jpg",
                                                    Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore" +
                                                    " et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea " +
                                                    "commodo consequat. "};
            List <Star> dreamStars = new List<Star>() { stars[2], stars[3] };
            Performance dream = new Performance() { Category = "Dream", Name = "Le dragon magique", Stars = dreamStars, Picture = @".\Front_Picture\Dream.jpg",
                                                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore" +
                                                    " et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea " +
                                                    "commodo consequat. "
            };
            List<Star> marvelStars = new List<Star>() { stars[4] };
            Performance marvelAt = new Performance() { Category = "MarvelAt", Name = "Boule de feu transperce le ciel", Stars = marvelStars, Picture = @".\Front_Picture\MarvelAt.jpg",
                                                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore" +
                                                    " et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea " +
                                                    "commodo consequat. "
            };

            performances.Add(laugh);
            performances.Add(dream);
            performances.Add(marvelAt);
            _context.AddRange(performances);
            return performances;
        }

        private List<Tour> Tours(List<Address> addresses, List<Performance> performances)
        {
            List<Tour> tours = new List<Tour>();
            Random randomGenerator = new Random();
            performances.ForEach(p =>
            {
                for(int i =0; i < 3; i++)
                {
                    Tour tour = new Tour()
                    {
                        Date = DateTime.Now + TimeSpan.FromDays(randomGenerator.Next(30, 365)),
                        Place = addresses[randomGenerator.Next(0, 16)],
                        Performance = p,
                        AvailableSeats = 1500
                    };
                    tours.Add(tour);
                }
            });
            _context.AddRange(tours);
            return tours;
        }

        private void Orders(List<User> users, List<Tour> tours)
        {
            List<PastOrder> orders = new List<PastOrder>();
            Random randomGenerator = new Random();
            users.ForEach(u =>
            {
                double amount = Math.Round(randomGenerator.NextDouble() * 50);
                PastOrder order = new PastOrder()
                {
                    Amount = amount,
                    Tour = tours[randomGenerator.Next(0, tours.Count)],
                    User = u,
                    Date = DateTime.Now - TimeSpan.FromDays(randomGenerator.Next(15, 100))
                };
                orders.Add(order);
            });
            _context.AddRange(orders);
        }
    }
}
