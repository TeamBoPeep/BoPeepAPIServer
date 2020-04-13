using APIBackEnd.Data;
using APIBackEnd.Models.DTO;
using APIBackEnd.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.Service
{
    public class ActivityService : IActivityManager
    {
        private BoPeepDbContext _context;

        public ActivityService(BoPeepDbContext context)
        {
            _context = context;
            
        }
        public async Task<ActivitiesDTO> CreateActivity(Activities activities)
        {
            var ActivitiesDTO = ConvertToDTO(activities);
            _context.Add(activities);
            await _context.SaveChangesAsync();
            return ActivitiesDTO;


        }

        public Task DeleteActivities(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Activities> GetActivity(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Activities>> GetAllActivities()
        {
            throw new NotImplementedException();
        }

        public Task UpdateActivities()
        {
            throw new NotImplementedException();
        }
        private ActivitiesDTO ConvertToDTO(Activities activities)
        {
            ActivitiesDTO aDTO = new ActivitiesDTO()
            {
                Title = activities.Title,
                Description = activities.Description,
                Location = activities.Location,
                Rate = activities.Rate,
                ExternalLink = activities.ExternalLink,
                Rating = activities.Rating
            };
            return aDTO;
        }
    }
}
