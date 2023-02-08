using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext (DbContextOptions<MovieCollectionContext> options) : base (options)
        {
            // leave blank for now
        }
        public DbSet<MovieFormResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieFormResponse>().HasData(
               new MovieFormResponse
               {
                   RentalID = 1,
                   Category = "Suspense", 
                   Title = "Inception",
                   Year = "2010",
                   Director = "Christopher Nolan",
                   Rating = "PG-13",
                   Edited = false,
                   Notes = "My favorite movie!"
               },
               new MovieFormResponse
               {
                   RentalID = 2,
                   Category = "Action",
                   Title = "Age of Ultron",
                   Year = "2015",
                   Director = "Kevin Feige",
                   Rating = "PG-13",
                   Edited = false,
                   Notes = "Avengers are the best!"
               },
               new MovieFormResponse
               {
                   RentalID = 3,
                   Category = "Musical",
                   Title = "High School Musical 3: Senior Year",
                   Year = "2008",
                   Director = "Disney",
                   Rating = "PG",
                   Edited = false,
                   Notes = "The best ending!"
               }
           );
        }
    }
}
