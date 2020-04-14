using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBackEnd.Data;
using APIBackEnd.Models;
using APIBackEnd.Models.Interface;
using APIBackEnd.Models.DTO;

namespace APIBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityManager _context;

        public ActivitiesController(IActivityManager context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivitiesDTO>>> GetActivities() => await _context.GetAllActivities();

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivitiesDTO>> GetActivities(int id)
        {
            var activities = await _context.GetActivity(id);


            if (activities == null)
            {
                return NotFound();
            }

            return activities;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task PutActivities(int id, Activities activities)
        {              
            await _context.UpdateActivities(activities);
        }

        // POST: api/Activities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Activities>> PostActivities(Activities activities)
        {
            await _context.CreateActivity(activities);

            return CreatedAtAction("GetActivities", new { id = activities.ID }, activities);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task DeleteActivities(int id)
        {
            await _context.DeleteActivities(id);
        }

    }
}
