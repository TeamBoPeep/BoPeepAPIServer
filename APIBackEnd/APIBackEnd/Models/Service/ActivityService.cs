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
    public class ActivityService : IActivityManager
    {
        /// <summary>
        /// Allows us to inject our database into this service
        /// </summary>
        private BoPeepDbContext _context;
        private IReviewManager _reviewContext;

        public ActivityService(BoPeepDbContext context, IReviewManager reviewContext)
        {
            _context = context;
            _reviewContext = reviewContext;

            
        }
        /// <summary>
        /// Allows us to create the activities as well as utilize our DTOs to normalize the data
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>

        public async Task<ActivitiesDTO> CreateActivity(ActivitiesDTO activitiesDTO)
        {
            int total = _context.Activities.Count();
            int upvote = _context.Activities.Where(x => x.Rate == (Rate)1)
                                            .Count();
            activitiesDTO.Rating = (upvote / total * 5);

            Activities activities = new Activities()
            {
                Title = activitiesDTO.Title,
                Location = Enum.Parse<Location>(activitiesDTO.Location),
                Description = activitiesDTO.Description,
                Rate = (Rate)activitiesDTO.Rate,
                Rating = activitiesDTO.Rating, 
                ExternalLink = activitiesDTO.ExternalLink != null ? activitiesDTO.ExternalLink : "",
                ImageUrl = activitiesDTO.ImageUrl != null ? activitiesDTO.ImageUrl : ""
            };
            _context.Add(activities);
            await _context.SaveChangesAsync();
            return activitiesDTO;
        }
        //used to remove an activity
        public async Task DeleteActivities(int ID)
        {
            var activities = await _context.Activities.FindAsync(ID);

            _context.Remove(activities);

            await _context.SaveChangesAsync();
        }
        //used to retrieve an activity by it's ID
        public  async Task<ActivitiesDTO> GetActivity(int ID)
        {
            var Activity = await _context.Activities.FindAsync(ID);
            ActivitiesDTO dTO = ConvertToDTO(Activity);
            dTO.Reviews = await GetReviewsById(ID);
            return dTO;
        }
        //Used to get all the activities in the table
        public async Task<List<ActivitiesDTO>> GetAllActivities()
        {

            List<ActivitiesDTO> aDTO = new List<ActivitiesDTO>();
            List<Activities> activities = await _context.Activities.ToListAsync();
            foreach (var item in activities)
            {
                ActivitiesDTO dTO = ConvertToDTO(item);
                aDTO.Add(dTO);
                
            }
            return aDTO;
        }

        public async Task<List<ReviewsDTO>> GetReviewsById(int ID)
        {
            var reviews = await _context.ActivitiesReviews.Where(x => x.ActivitiesID == ID)
                                                .ToListAsync();
            List<ReviewsDTO> rDTOList = new List<ReviewsDTO>();
            foreach (var item in reviews)
            {

                ReviewsDTO review = await _reviewContext.GetReviews(item.ReviewsID);
                rDTOList.Add(review);

            }
            return rDTOList;
        }

        //changes an activity already in the table (name, description, tags)
        public async Task UpdateActivities(Activities activities)
        {
            _context.Update(activities);
            await _context.SaveChangesAsync();
        }
        private ActivitiesDTO ConvertToDTO(Activities activities)
        {
            ActivitiesDTO aDTO = new ActivitiesDTO()
            {
                ID = activities.ID,
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
