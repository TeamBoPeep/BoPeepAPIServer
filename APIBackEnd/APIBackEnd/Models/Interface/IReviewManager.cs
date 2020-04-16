using APIBackEnd.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.Interface
{
    public interface IReviewManager
    {
        //create
        Task<ReviewsDTO> CreateReviews(ReviewsDTO reviewDTO);
        //read
        Task<ReviewsDTO> GetReviews(int ID);
        //readAll
        Task<List<ReviewsDTO>> GetAllReviews();
        //update
        Task UpdateReviews(Reviews reviews);
        //delete
        Task DeleteReviews(int ID);

    }
}
