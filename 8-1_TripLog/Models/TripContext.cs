/*
 Virginia Villalobos
 COP4813.0M1
 TripContext.cs

 TripContext links the Trip class to the Trip database, seeding data in the meantime
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _8_1_TripLog.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        public DbSet<Trip> Trips
        {
            get;
            set;
        }


        //Seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "New York",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Accomodation = "The Inn",
                    AccomodationPhone = "1231112222",
                    AccomodationEmail = "ny@hotel.com",
                    ThingsToDo1 = "Statue of Liberty",
                    ThingsToDo2 = "Yankees Game",
                    ThingsToDo3 = ""
                });
        }

    }
}
