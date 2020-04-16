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

/// <summary>
/// controllers for API, linking the backend to front.
/// </summary>
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
        /// <summary>
        /// Get route for activities
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivitiesDTO>>> GetActivities() => await _context.GetAllActivities();

        // GET: api/Activities/5
        /// <summary>
        /// Getting the specific activity
        /// </summary>
        /// <param name="id">id of the activity</param>
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
        /// <summary>
        /// Updating the activity
        /// </summary>
        /// <param name="id">specific activity</param>
        /// <param name="activities">activity to update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task PutActivities(int id, Activities activities)
        {              
            await _context.UpdateActivities(activities);
        }

        // POST: api/Activities
        /// <summary>
        /// Creating a activity using this route
        /// </summary>
        /// <param name="activities">activity that will be created</param>
        [HttpPost]
        public async Task<ActionResult<Activities>> PostActivities(ActivitiesDTO activities)
        {
            var activity = await _context.CreateActivity(activities);

            return CreatedAtAction("GetActivities", new { id = activity.ID }, activity);
        }

        // DELETE: api/Activities/5
        /// <summary>
        /// Deleting the activity
        /// </summary>
        /// <param name="id">id of activity to delete</param>
        [HttpDelete("{id}")]
        public async Task DeleteActivities(int id)
        {
            await _context.DeleteActivities(id);
        }

    }
}
