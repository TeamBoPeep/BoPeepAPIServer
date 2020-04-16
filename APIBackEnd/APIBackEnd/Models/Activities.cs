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
        public double Rating { get; set; }
        public Location Location { get; set; }
        public string ExternalLink { get; set; }
        public string ImageUrl { get; set; }

        //navigation properties
        public List<ActivitiesReviews> ActivitiesReviews = new List<ActivitiesReviews>();

        public List<TagActivity> TagActivity = new List<TagActivity>();
    }

    /// <summary>
    /// Enum for location 
    /// </summary>
    public enum Location
    {
        indoor = 0, 
        outdoor = 1,
        both = 2,
        na = 3
    }


}
