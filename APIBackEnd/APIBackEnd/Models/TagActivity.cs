﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models
{
    /// <summary>
    /// TagActivity model for table PURE JOIN TABLE
    /// </summary>
    public class TagActivity
    {
        public int ActivitiesId { get; set; }
        public int TagId { get; set; }

        // Navigation properties
        public Activities Activities { get; set; }
        public Tag Tag { get; set; }

    }
}
