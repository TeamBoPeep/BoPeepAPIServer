using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    public class Activities
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Rate Rate { get; set; }
        public double Rating { get; set; }
        public Location Location { get; set; }
        public string ExternalLink { get; set; }
        public string ImageUrl { get; set; }

        //naviggation properties
        public List<ActivitiesReviews> ActivitiesReviews = new List<ActivitiesReviews>();

        public List<TagActivity> TagActivity = new List<TagActivity>();


    }
    public enum Location
    {
        Indoor = 0, 
        Outdoor = 1,
        Both = 2
    }
    public enum Rate
    {
        UpVote = 1,
        DownVote = 0,
        Null = 2
    }
}
