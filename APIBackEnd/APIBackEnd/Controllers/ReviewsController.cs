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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewsDTO>>> GetReviews() => await _context.GetAllReviews();



        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewsDTO>> GetReviews(int id) => await _context.GetReviews(id);


        // PUT: api/Reviews/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task PutReviews(int id, Reviews reviews) => await _context.UpdateReviews(reviews);


        // POST: api/Reviews
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Reviews>> PostReviews(Reviews reviews)
        {
            await _context.CreateReviews(reviews);

            return CreatedAtAction("GetReviews", new { id = reviews.Id }, reviews);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task DeleteReviews(int id) => await _context.DeleteReviews(id);


    }
}
