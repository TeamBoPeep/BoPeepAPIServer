using APIBackEnd.Data;
using APIBackEnd.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.Service
{
    public class TagServices : ITagManager
    {
        private BoPeepDbContext _context;

        public TagServices(BoPeepDbContext context)
        {
            _context = context;
        }


    }
}
