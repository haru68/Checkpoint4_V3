using Microsoft.EntityFrameworkCore;


namespace Checkpoint4_V2
{
    public class CircusContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PastOrder> PastOrders { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<User>  Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=WildCircus;Integrated Security=True; MultipleActiveResultSets=True");
        }

    }
}
