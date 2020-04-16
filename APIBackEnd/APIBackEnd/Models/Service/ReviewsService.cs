using APIBackEnd.Data;
using APIBackEnd.Models.DTO;
using APIBackEnd.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.Service
{
    public class ReviewsService : IReviewManager
    {
        private BoPeepDbContext _context;

        /// <summary>
        /// Constructor that will be used to query database
        /// </summary>
        /// <param name="context">database context</param>
        public ReviewsService(BoPeepDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add activityreview in a instance of review
        /// </summary>
        /// <param name="reviewDTO">review from front end</param>
        public async Task<ReviewsDTO> CreateReviews(ReviewsDTO reviewDTO)
        {
            Reviews reviews = new Reviews()
            {
                Id = reviewDTO.Id,
                Name = reviewDTO.Name,
                Description = reviewDTO.Description
            };
            _context.Add(reviews);
            await _context.SaveChangesAsync();

            await CreateActivityReviews(reviewDTO.ActivityID);

            return reviewDTO;

        }

        /// <summary>
        /// Creating activityreview table row as review is created
        /// </summary>
        /// <param name="ID">activity id</param>
        public async Task CreateActivityReviews(int ID)
        {
            int LastReviews = await _context.Reviews.OrderByDescending(x => x.Id).Select(x => x.Id).FirstAsync();
            ActivitiesReviews activitiesReviews = new ActivitiesReviews()
            {
                ActivitiesID = ID,
                ReviewsID = LastReviews
            };
            _context.ActivitiesReviews.Add(activitiesReviews);
            await _context.SaveChangesAsync();
        }
        
        /// <summary>
        /// To delete review route
        /// </summary>
        /// <param name="ID">Delete specific route parama</param>
        public async Task DeleteReviews(int ID)
        {
            var reviews = await _context.Reviews.FindAsync(ID);
            _context.Remove(reviews);
            await _context.SaveChangesAsync();
         
        }

        /// <summary>
        /// Get all of the reviews 
        /// </summary>
        public async Task<List<ReviewsDTO>> GetAllReviews()
        {
            List<ReviewsDTO> rDTOList = new List<ReviewsDTO>();
            List<Reviews> reviews = await _context.Reviews.ToListAsync();
            foreach (var item in reviews)
            {
                ReviewsDTO rDTO = ConvertToDTO(item);
                rDTOList.Add(rDTO);

            }
            return rDTOList;
        }

        /// <summary>
        /// Get reviews by specific user
        /// </summary>
        /// <param name="ID">Route param that user entered in</param>
        public async Task<ReviewsDTO> GetReviews(int ID)
        {
            var review = await _context.Reviews.FindAsync(ID);
            ReviewsDTO rDTO = ConvertToDTO(review);
            return rDTO;
        }

        /// <summary>
        /// Updating reviews
        /// </summary>
        /// <param name="reviews">review that is being updated</param>
        public async Task UpdateReviews(Reviews reviews)
        {
            _context.Update(reviews);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Converting DTO object from reviews to DTO
        /// </summary>
        /// <param name="reviews">Review that is being passed in from database</param>
        private ReviewsDTO ConvertToDTO(Reviews reviews)
        {
            ReviewsDTO rDTO = new ReviewsDTO()
            {
                Id = reviews.Id,
                Description = reviews.Description,
                Name = reviews.Name,
                ActivityID = 0
            };
            return rDTO;
        }
    }
}
