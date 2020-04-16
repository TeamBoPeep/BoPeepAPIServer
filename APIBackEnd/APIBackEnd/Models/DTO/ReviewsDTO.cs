using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.DTO
{
    /// <summary>
    /// DTO of reviews table
    /// </summary>
    public class ReviewsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// This is to create instance of ActivitiesReview row when reviews are written
        /// </summary>
        public int ActivityID { get; set; }

    }
}
