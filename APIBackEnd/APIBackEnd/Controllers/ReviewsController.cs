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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewManager _context;

        /// <summary>
        /// Constructor that implements IReviewManager
        /// </summary>
        public ReviewsController(IReviewManager context)
        {
            _context = context;
        }

        // GET: api/Reviews
        /// <summary>
        /// Getting all of the reviews in the dta base
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewsDTO>>> GetReviews() => await _context.GetAllReviews();



        // GET: api/Reviews/5
        /// <summary>
        /// Get route for Reviews 
        /// </summary>
        /// <param name="id">Id that is passed from route param</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewsDTO>> GetReviews(int id) => await _context.GetReviews(id);


        /// <summary>
        /// Updtate rout for reviews
        /// </summary>
        /// <param name="id">id that is being passed in</param>
        /// <param name="reviews">reviews that user trying to update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task PutReviews(int id, Reviews reviews) => await _context.UpdateReviews(reviews);


        // POST: api/Reviews
        /// <summary>
        /// Creating a reviews when this endroute is invoked
        /// </summary>
        /// <param name="reviews">reviews from the front end</param>
        [HttpPost]
        public async Task<ActionResult<Reviews>> PostReviews(ReviewsDTO reviews)
        {
            await _context.CreateReviews(reviews);

            return CreatedAtAction("GetReviews", new { id = reviews.Id }, reviews);
        }

        // DELETE: api/Reviews/5
        /// <summary>
        /// Delete route that will delete the review
        /// </summary>
        /// <param name="id">id of the review</param>
        [HttpDelete("{id}")]
        public async Task DeleteReviews(int id) => await _context.DeleteReviews(id);


    }
}
