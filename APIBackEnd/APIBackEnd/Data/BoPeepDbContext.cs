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

        /// <summary>
        ///  This lies where our composite keys are constituted and seeded data are added
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagActivity>().HasKey(x => new { x.ActivitiesId, x.TagId });
            modelBuilder.Entity<ActivitiesReviews>().HasKey(x => new { x.ReviewsID, x.ActivitiesID });
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
                ExternalLink = "https://www.wta.org/?gclid=CjwKCAjwvtX0BRAFEiwAGWJyZJMy_TIYVTxTlNY1u8DtYnwh-hfOyaf4tLByYfEdTrqNR2JbN8hk5xoC2-4QAvD_BwE",
                ImageUrl = "https://photos.app.goo.gl/PXCJFTwwt1FhF8USA"
            },
            new Activities
            {
                ID = 2,
                Title = "Bird watching",
                Description = "A chance to enjoy nature without movement, also good to enjoy with your cat",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = (Location)1,
                ExternalLink = "https://www.seattleaudubon.org/sas/getinvolved/gobirding.aspx",
                ImageUrl = "https://photos.app.goo.gl/sU8uy8dU5GMWbr5K7"
            },
            new Activities
            {
                ID = 3,
                Title = "Dog/cat walking",
                Description = "Better than a hike! You've got companion to help you stop and smell the roses",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://photos.app.goo.gl/Q5ZuBaUcJXeFJ6bW8"
            },
            new Activities
            {
                ID = 4,
                Title = "Gardening",
                Description = "grow veggies, flowers and fruit",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://photos.app.goo.gl/PGfKPx3LPi2yUQTD8"
            },
            new Activities
            {
                ID = 5,
                Title = "Dumpster Diving",
                Description = "Get a nice bite to eat, for free!",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://photos.app.goo.gl/QCVaJvDjofFcBVRQ8"
            },
            new Activities
            {
                ID = 6,
                Title = "Games",
                Description = "Time to slay dragons and drink mead",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://photos.app.goo.gl/i77msdULDKig3JLGA"
            },
            new Activities
            {
                ID = 7,
                Title = "Exercise",
                Description = "Blood pumping and brain working",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://photos.app.goo.gl/tkKyaR6y1of14itm7"
            },
            new Activities
            {
                ID = 8,
                Title = "Learning",
                Description = "Art, cooking or C#, the options are endless",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://photos.app.goo.gl/hfNskNLt85WBjCoU7"
            },
            new Activities
            {
                ID = 9,
                Title = "Terrariums",
                Description = "Aloe, succulents and anything else your cat won't eat",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "http://serpadesign.com/",
                ImageUrl = "https://photos.app.goo.gl/Ek1Vvfb87hcy5fKZ7"
            },
            new Activities
            {
                ID = 10,
                Title = "Facetime/video calls",
                Description = "be social while social distancing",
                Rate = (Rate)1,
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://photos.app.goo.gl/icHoVn4wBi6B7HmZ9"
            }
            );

         modelBuilder.Entity<Tag>().HasData(
            //Dummy data for out Tag table
            new Tag
            {
                ID = 1,
                Names = "Flora/fauna"
            },
            new Tag
            {
                ID = 2,
                Names = "Exercise"
            },
            new Tag
            {
                ID = 3,
                Names = "Games"
            },
            new Tag
            {
                ID = 4,
                Names = "Social"
            },
            new Tag
            {
                ID = 5,
                Names = "Pets"
            },
            new Tag
            {
                ID = 6,
                Names = "Arts&Crafts"
            },
            new Tag
            {
                ID = 7,
                Names = "Self care"
            },
            new Tag
            {
                ID = 8,
                Names = "Online"
            },
            new Tag
            {
                ID = 9,
                Names = "Productive"
            },
            new Tag
            {
                ID = 10,
                Names = "Baking/Cooking"
            }
            );

        }

        /// <summary>
        /// Sets of model that will be added to the database
        /// </summary>
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Reviews> Reviews { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet<TagActivity> TagActivity { get; set; }

        public DbSet<ActivitiesReviews> ActivitiesReviews { get; set; }


    }
}
