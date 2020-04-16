using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.DTO
{
    /// <summary>
    /// DTO for activities
    /// </summary>
    public class ActivitiesDTO
    {
        public int ID { get; set; }
        //helps shape the information of the activities table so the front end can utilize the data
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; } 
        // upvote = 1, downvote = 0, null = 2
        public double Rating { get; set; }
        public string Location { get; set; }
        public string ExternalLink { get; set; }
        public string ImageUrl { get; set; }

        
        /// <summary>
        ///  Lists of tag, reviews.
        /// </summary>
        public List<TagDTO> Tags = new List<TagDTO>();

        public List<ReviewsDTO> Reviews = new List<ReviewsDTO>();

        public List<TagDTO> TagDTO = new List<TagDTO>();

    }
}
