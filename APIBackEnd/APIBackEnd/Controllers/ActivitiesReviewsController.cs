using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBackEnd.Data;
using APIBackEnd.Models;

/// <summary>
/// controllers for the review pages, linking the backend to the frontend
/// </summary>
namespace APIBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesReviewsController : ControllerBase
    {
        private readonly BoPeepDbContext _context;
        
        /// <summary>
        /// Database context
        /// </summary>
        /// <param name="context">database</param>
        public ActivitiesReviewsController(BoPeepDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivitiesReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivitiesReviews>>> GetActivitiesReviews()
        {
            return await _context.ActivitiesReviews.ToListAsync();
        }

        // POST: api/ActivitiesReviews
        /// <summary>
        /// Creating the ActivitiesReviews row to link activities to reviews
        /// </summary>
        /// <param name="activitiesReviews">activitiesreviews ids</param>
        [HttpPost]
        public async Task<ActionResult<ActivitiesReviews>> PostActivitiesReviews(ActivitiesReviews activitiesReviews)
        {
            _context.ActivitiesReviews.Add(activitiesReviews);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActivitiesReviewsExists(activitiesReviews.ReviewsID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActivitiesReviews", new { id = activitiesReviews.ReviewsID }, activitiesReviews);
        }

        // DELETE: api/ActivitiesReviews/5
        /// <summary>
        /// Deleting the activitiesreviews row
        /// </summary>
        /// <param name="id">id of row to delete</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivitiesReviews>> DeleteActivitiesReviews(int id)
        {
            var activitiesReviews = await _context.ActivitiesReviews.FindAsync(id);
            if (activitiesReviews == null)
            {
                return NotFound();
            }

            _context.ActivitiesReviews.Remove(activitiesReviews);
            await _context.SaveChangesAsync();

            return activitiesReviews;
        }

        /// <summary>
        /// Check if the activitiesreview row exist
        /// </summary>
        /// <param name="id">checking this row</param>
        private bool ActivitiesReviewsExists(int id)
        {
            return _context.ActivitiesReviews.Any(e => e.ReviewsID == id);
        }
    }
}
