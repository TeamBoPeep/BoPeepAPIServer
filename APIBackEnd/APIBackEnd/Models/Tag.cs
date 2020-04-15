using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    /// <summary>
    /// Tag schema that will create a table
    /// </summary>
    public class Tag
    {
        public int ID { get; set; }
        public string Names { get; set; }

        public List<TagActivity> TagActivities = new List<TagActivity>();

    }
}
