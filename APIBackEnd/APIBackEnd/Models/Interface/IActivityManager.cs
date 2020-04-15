using APIBackEnd.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.Interface
{
    public interface IActivityManager
    {
        Task<List<ReviewsDTO>> GetReviewsById(int ID);
        Task<List<TagDTO>> GetTagbyActivityID(int Id);
        //create
        Task<ActivitiesDTO> CreateActivity(ActivitiesDTO activities);
        //read
        Task<ActivitiesDTO> GetActivity(int ID);
        //readAll
        Task<List<ActivitiesDTO>> GetAllActivities();
        //update
        Task UpdateActivities(Activities activities);
        //delete
        Task DeleteActivities(int ID);

    }
}
