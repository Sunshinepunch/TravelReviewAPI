using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}