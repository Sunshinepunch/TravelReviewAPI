using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Models
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Review>()
        .HasData(
        new Review { ReviewId = 1, Rating = 4, Comment = "Great Parks but the birds seem angry!",  Location = "Jurassic World" },
        new Review { ReviewId = 2, Rating = 1 , Comment = "Don't like beans",  Location = "Chicago" },
        new Review { ReviewId = 3, Rating = 5, Comment = "A gorgeous man proposed to me with a ring",  Location = "Rivendell" },
        new Review { ReviewId = 4, Rating = 3, Comment = "No wheelchair ramps",  Location = "Hogwarts" },
        new Review { ReviewId = 5, Rating = 3, Comment = "Lonely", Location = "My bathroom" }
        );
        }
    }
}