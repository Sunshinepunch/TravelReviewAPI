using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Models
{
    public class TravelContext : DbContext
    {

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Destination> Destinations { get; set;}

        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseLazyLoadingProxies();
            }


        protected override void OnModelCreating(ModelBuilder builder)
            {
            builder.Entity<Review>()
            .HasData(
            new Review { ReviewId = 1, Rating = 4, Comment = "Great Parks but the birds seem angry!", DestinationId = 1},
            new Review { ReviewId = 2, Rating = 1 , Comment = "Don't like beans", DestinationId = 2},
            new Review { ReviewId = 3, Rating = 5, Comment = "A gorgeous man proposed to me with a ring", DestinationId = 3 },
            new Review { ReviewId = 4, Rating = 3, Comment = "No wheelchair ramps", DestinationId = 4},
            new Review { ReviewId = 5, Rating = 3, Comment = "Lonely", DestinationId = 5 }
            );
            builder.Entity<Destination>()
            .HasData(
            new Destination { DestinationId = 1, Name = "Jurassic World"},
            new Destination { DestinationId = 2, Name = "Chicago"},
            new Destination { DestinationId = 3, Name = "Rivendell"},
            new Destination { DestinationId = 4, Name = "Hogwarts"},
            new Destination { DestinationId = 5, Name = "My Bathroom"}
            );

            }
    }
}

