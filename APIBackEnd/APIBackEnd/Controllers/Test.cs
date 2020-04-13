using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Controllers
{
    [Route("api/hello")]
    [ApiController]

    public class Test
    {
        [HttpGet]
        public string Hello()
        {
            return "hello world";
        }
    }
}
