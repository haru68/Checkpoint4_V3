using System;
using Nancy.Hosting.Self;


namespace Checkpoint4_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            DbPopulator populator = new DbPopulator();
            populator.Populate();

            HostConfiguration hostConfiguration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true },
            };
            using (var host = new NancyHost(hostConfiguration, new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
                host.Stop();
            }
        }
    }
}
