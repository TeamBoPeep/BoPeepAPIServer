using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    public class UserName
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Reviews> reviews = new List<Reviews>();
    }
}
