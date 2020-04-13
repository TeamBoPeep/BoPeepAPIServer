using APIBackEnd.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.Interface
{
    public interface IActivityManager
    {
        //create
        Task<ActivitiesDTO> CreateActivity(Activities activities);
        //read
        Task<Activities> GetActivity(int ID);
        //readAll
        Task<List<Activities>> GetAllActivities();
        //update
        Task UpdateActivities();
        //delete
        Task DeleteActivities(int ID);

    }
}
