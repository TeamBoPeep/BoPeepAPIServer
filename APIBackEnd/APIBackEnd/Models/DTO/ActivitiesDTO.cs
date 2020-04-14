using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.DTO
{
    public class ActivitiesDTO
    {
        //helps shape the information of the activities table so the front end can utilize the data
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; } 
        // upvote = 1, downvote = 0, null = 2
        public double Rating { get; set; }
        public string Location { get; set; }
        public string ExternalLink { get; set; }
        public string ImageUrl { get; set; }


        //naviggation properties
        public List<Reviews> Reviews = new List<Reviews>();
        public List<Tag> Tag = new List<Tag>();

    }
}
