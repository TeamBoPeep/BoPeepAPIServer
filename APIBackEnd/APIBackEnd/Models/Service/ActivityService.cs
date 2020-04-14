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
        /// <summary>
        /// Allows us to inject our database into this service
        /// </summary>
        private BoPeepDbContext _context;

        public ActivityService(BoPeepDbContext context)
        {
            _context = context;
            
        }
        /// <summary>
        /// Allows us to create the activities as well as utilize our DTOs to normalize the data
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>

        public async Task<ActivitiesDTO> CreateActivity(Activities activities)
        {
            int total = _context.Activities.Count();
            int upvote = _context.Activities.Where(x => x.Rate == (Rate)1)
                                            .Count();
            activities.Rating = (upvote / total * 100);
            var ActivitiesDTO = ConvertToDTO(activities);
            _context.Add(activities);
            await _context.SaveChangesAsync();
            return ActivitiesDTO;
        }
        //used to remove an activity
        public Task DeleteActivities(int ID)
        {
            throw new NotImplementedException();
        }
        //used to retrieve an activity by it's ID
        public Task<Activities> GetActivity(int ID)
        {
            throw new NotImplementedException();
        }
        //Used to get all the activities in the table
        public Task<List<Activities>> GetAllActivities()
        {
            throw new NotImplementedException();
        }

        //changes an activity already in the table (name, description, tags)
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
                Location = activities.Location.ToString(),
                Rate = Convert.ToInt32(activities.Rate),
                ExternalLink = activities.ExternalLink,
                Rating = activities.Rating
            };
            return aDTO;
        }
    }
}
