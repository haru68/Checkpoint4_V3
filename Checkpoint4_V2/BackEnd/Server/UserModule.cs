using System.Collections.Generic;
using Nancy;
using System.Linq;
using Newtonsoft.Json;

namespace Checkpoint4_V2
{
    public class UserModule : NancyModule
    {
        public CircusContext Context { get; set; }
        public UserModule()
        {
            Context = new CircusContext();

            Get("/User", parameters => GetCurrentUser());

            Get("/Performances", parameters => GetPerformances());

            Get("/Stars", parameters => GetStars());

            Post("/authentify/{UserName}/{Password}", parameters =>
            {
                string userName = parameters.UserName;
                string password = parameters.Password;

                UserSingleton.GetInstance.Init(userName, password);
                if(UserSingleton.GetInstance.User != null)
                {
                    var response = Response.AsJson(Nancy.HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    var response = Response.AsJson(Nancy.HttpStatusCode.Forbidden);
                    return response;
                }
            });

            Put("/Country/{Name}", parameters =>
            {
                string countryName = parameters.Name;
                bool isCountryRecorded = (from c in Context.Countries
                                          where c.Name == countryName
                                          select c).Any();
                if(!isCountryRecorded)
                {
                    Country country = new Country() { Name = countryName };
                    Context.Update(country);
                    Context.SaveChanges();
                    var response = Response.AsJson(Nancy.HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    var response = Response.AsJson(Nancy.HttpStatusCode.Forbidden);
                    return response;
                }
            });
        }
        
        private string GetCurrentUser()
        {
            string serializedUser;
            if(UserSingleton.GetInstance.IsAuthenticated)
            {
                User user = UserSingleton.GetInstance.User;
                serializedUser = JsonConvert.SerializeObject(user);
            }
            else
            {
                serializedUser = "None";
            }
            return serializedUser;
        }

        private string GetPerformances()
        {
            List<Performance> performances = (from p in Context.Performances
                                             select p).ToList();
            string serialized = JsonConvert.SerializeObject(performances);
            return serialized;
        }
        private object GetStars()
        {
            List<Star> stars = (from s in Context.Stars
                                select s).ToList();
            string serialized = JsonConvert.SerializeObject(stars);
            return serialized;
        }
    }
}
