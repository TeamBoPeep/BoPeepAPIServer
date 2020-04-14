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

        public ReviewsService(BoPeepDbContext context)
        {
            _context = context;
        }
        public async Task<ReviewsDTO> CreateReviews(Reviews reviews)
        {
            ReviewsDTO rDTO = ConvertToDTO(reviews);
            _context.Add(reviews);
            await _context.SaveChangesAsync();
            return rDTO;
        }

        public async Task DeleteReviews(int ID)
        {
            var reviews = await _context.Reviews.FindAsync(ID);
            _context.Remove(reviews);
            await _context.SaveChangesAsync();
         
        }

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

        public async Task<ReviewsDTO> GetReviews(int ID)
        {
            var review = await _context.Reviews.FindAsync(ID);
            ReviewsDTO rDTO = ConvertToDTO(review);
            return rDTO;
        }


        public async Task UpdateReviews(Reviews reviews)
        {
            _context.Update(reviews);
            await _context.SaveChangesAsync();
        }
        private ReviewsDTO ConvertToDTO(Reviews reviews)
        {
            ReviewsDTO rDTO = new ReviewsDTO()
            {
                Id = reviews.Id,
                Description = reviews.Description,
                Name = reviews.Name
            };
            return rDTO;
        }
    }
}
