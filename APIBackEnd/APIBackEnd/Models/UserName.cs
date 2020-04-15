using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    /// <summary>
    /// Model for our UserName Table possibly used in the future
    /// </summary>
    public class UserName
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Reviews> reviews = new List<Reviews>();
    }
}
