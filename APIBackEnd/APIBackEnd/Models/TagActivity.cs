using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    public class TagActivity
    {
        public int ActivitiesId { get; set; }
        public int TagId { get; set; }
        public Activities Activities { get; set; }
        public Tag Tag { get; set; }

    }
}
