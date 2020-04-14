using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //navigation property
        public List<ActivitiesReviews> ActivitiesReviews = new List<ActivitiesReviews>();
        //public UserNames UserNames { get; set; }
    }

}
