using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    /// <summary>
    /// Review model table 
    /// </summary>
    public class Reviews
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Rate Rate { get; set; }
        //navigation property

        public List<ActivitiesReviews> ActivitiesReviews = new List<ActivitiesReviews>();
        //public UserNames UserNames { get; set; }
    }

    /// <summary>
    /// Enum for Rating
    /// </summary>
    public enum Rate
    {
        upvote = 0,
        downvote = 1,
        Null = 2
    }
}
