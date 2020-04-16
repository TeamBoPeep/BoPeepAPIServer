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

        // GET: api/ActivitiesReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivitiesReviews>> GetActivitiesReviews(int id)
        {
            var activitiesReviews = await _context.ActivitiesReviews.FindAsync(id);

            if (activitiesReviews == null)
            {
                return NotFound();
            }

            return activitiesReviews;
        }

        // PUT: api/ActivitiesReviews/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivitiesReviews(int id, ActivitiesReviews activitiesReviews)
        {
            if (id != activitiesReviews.ReviewsID)
            {
                return BadRequest();
            }

            _context.Entry(activitiesReviews).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitiesReviewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActivitiesReviews
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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

        private bool ActivitiesReviewsExists(int id)
        {
            return _context.ActivitiesReviews.Any(e => e.ReviewsID == id);
        }
    }
}
