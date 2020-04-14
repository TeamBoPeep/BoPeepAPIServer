using APIBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Data
{
    public class BoPeepDbContext: DbContext
    {
        public BoPeepDbContext(DbContextOptions<BoPeepDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagActivity>().HasKey(x => new { x.ActivitiesId, x.TagId });
            modelBuilder.Entity<Activities>().HasData(
            //Dummy data for out Activities table
            new Activities
            {
                ID = 1,
                Title = "Hike/trails",
                Description = "A nice stroll outside to enjoy nature and fresh air",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 2,
                Title = "Bird watching",
                Description = "A chance to enjoy nature without movement, also good to enjoy with your cat",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 3,
                Title = "Dog/cat walking",
                Description = "Better than a hike! You've got companion to help you stop and smell the roses",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 4,
                Title = "Gardening",
                Description = "grow veggies, flowers and fruit",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 5,
                Title = "Dumpster Diving",
                Description = "Get a nice bite to eat, for free!",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 6,
                Title = "Games",
                Description = "Time to slay dragons and drink mead",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 7,
                Title = "Exercise",
                Description = "Blood pumping and brain working",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 8,
                Title = "Learning",
                Description = "Art, cooking or C#, the options are endless",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 9,
                Title = "Terrariums",
                Description = "Aloe, succulents and anything else your cat won't eat",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            },
            new Activities
            {
                ID = 10,
                Title = "Facetime/video calls",
                Description = "be social while social distancing",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A"
            }
            );
        }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Reviews> Reviews { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet<TagActivity> TagActivity { get; set; }

    }
}
