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
        private ITagManager _tagContext;

        /// <summary>
        /// The constructor that is keeping all of the implementation
        /// </summary>
        /// <param name="context">from the database</param>
        /// <param name="reviewContext">from IReviewManger interface</param>
        /// <param name="tagContext">from ITagManager interface</param>
        public ActivityService(BoPeepDbContext context, IReviewManager reviewContext, ITagManager tagContext)
        {
            _context = context;
            _reviewContext = reviewContext;
            _tagContext = tagContext;

        }

        /// <summary>
        /// Allows us to create the activities as well as utilize our DTOs to normalize the data
        /// </summary>
        /// <param name="activities">The DTO object that is being passed in from front end</param>
        public async Task<ActivitiesDTO> CreateActivity(ActivitiesDTO activitiesDTO)
        {
            List<TagDTO> tDTOList = activitiesDTO.Tags;

            double total = _context.Activities.Count();

            double upvote = _context.Activities.Where(x => x.Rate == (Rate)1)
                                            .Count();
            activitiesDTO.Rating = (upvote / total * 5);

            // Creating a object that will be stored in database
            Activities activities = new Activities()
            {
                Title = activitiesDTO.Title,
                Location = activitiesDTO.Location != null ? Enum.Parse<Location>(activitiesDTO.Location) : (Location)3 ,
                Description = activitiesDTO.Description,
                Rate = (Rate)activitiesDTO.Rate,
                Rating = activitiesDTO.Rating, 
                ExternalLink = activitiesDTO.ExternalLink != null ? activitiesDTO.ExternalLink : "",
                ImageUrl = activitiesDTO.ImageUrl != null ? activitiesDTO.ImageUrl : "",
            };

            _context.Activities.Add(activities);
            await _context.SaveChangesAsync();

            /// Calling a method that will link Activities and Tag
            await CreateTaskActivityByID(tDTOList);

            return activitiesDTO;
        }

        /// <summary>
        /// Linking the activities and tags together in this join table
        /// </summary>
        /// <param name="tDTOList"></param>
        /// <returns></returns>
        public async Task CreateTaskActivityByID(List<TagDTO> tDTOList)
        {
            int lastActivity = await _context.Activities.OrderByDescending(x => x.ID).Select(x => x.ID).FirstAsync();
            TagActivity tagActivity = new TagActivity();

            for (int i = 0; i < tDTOList.Count; i++)
            {
                tagActivity.ActivitiesId = lastActivity;
                tagActivity.TagId = tDTOList[i].ID;

                _context.TagActivity.Add(tagActivity);
                await _context.SaveChangesAsync();

            }
        }

        /// <summary>
        /// used to remove an activity
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task DeleteActivities(int ID)
        {
            var activities = await _context.Activities.FindAsync(ID);

            _context.Remove(activities);

            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// used to retrieve an activity by it's ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<ActivitiesDTO> GetActivity(int ID)
        {
            var Activity = await _context.Activities.FindAsync(ID);
            ActivitiesDTO dTO = ConvertToDTO(Activity);
            dTO.Reviews = await GetReviewsById(ID);
            dTO.TagDTO = await GetTagbyActivityID(ID);
            return dTO;
        }


        /// <summary>
        /// Used to get all the activities in the table
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Getting the reviews using the ID of Activities
        /// </summary>
        /// <param name="ID">Activities ID</param>
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


        /// <summary>
        /// changes an activity already in the table (name, description, tags)
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public async Task UpdateActivities(Activities activities)
        {
            _context.Update(activities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Getting the Tag by activities ID
        /// </summary>
        /// <param name="Id">activities ID</param>
        public async Task<List<TagDTO>> GetTagbyActivityID(int Id)
        {
            List<TagActivity> tActList = new List<TagActivity>();
            tActList = await _context.TagActivity.Where(x => x.ActivitiesId == Id)
                                                       .ToListAsync();
            List<TagDTO> aDTO = new List<TagDTO>();
            foreach (var item in tActList)
            {
                TagDTO dTO = await _tagContext.GetTag(item.TagId);
                aDTO.Add(dTO);

            }
            return aDTO;
        }

        /// <summary>
        /// Converting Activities to DTO
        /// </summary>
        /// <param name="activities">Activities object</param>
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
                Rating = activities.Rating,
                ImageUrl = activities.ImageUrl
            };
            return aDTO;
        }
    }
}
