using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    public class ActivitiesReviews
    {
        public int ActivitiesID { get; set; }
        public int ReviewsID { get; set; }

        public Activities Activities { get; set; }
        public Reviews Reviews { get; set; }
    }
}
