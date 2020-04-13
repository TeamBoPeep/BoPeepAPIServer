using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.DTO
{
    public class ActivitiesDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Rate Rate { get; set; }
        public double Rating { get; set; }
        public Location Location { get; set; }
        public string ExternalLink { get; set; }

        //naviggation properties
        public List<Reviews> Reviews = new List<Reviews>();
        public List<Tag> Tag = new List<Tag>();

    }
}
