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
    public class TagServices : ITagManager
    {
        private readonly BoPeepDbContext _context;

        /// <summary>
        /// Constructor that will be used to query database
        /// </summary>
        /// <param name="context">database context</param>
        public TagServices(BoPeepDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that will be used to create a Tag
        /// </summary>
        /// <param name="tagDTO">tag from frontend</param>
        /// <returns>tagDTO</returns>
        public async Task<TagDTO> CreateTag(TagDTO tagDTO)
        {
            Tag tag = new Tag()
            {
                ID = tagDTO.ID,
                Names = tagDTO.Name
            };
            _context.Add(tag);
            await _context.SaveChangesAsync();
            return tagDTO;
        }

        /// <summary>
        /// Deleting the tag from the database
        /// </summary>
        /// <param name="ID">id of </param>
        /// <returns></returns>
        public async Task DeleteTag(int ID)
        {
            var tag = await _context.Tag.FindAsync(ID);
            _context.Remove(tag);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Getting all the tags from database
        /// </summary>
        /// <returns>List of all the tags</returns>
        public async Task<List<TagDTO>> GetAllTags()
        {
            List<TagDTO> TagList = new List<TagDTO>();
            List<Tag> tags = await _context.Tag.ToListAsync();
            foreach (var item in tags)
            {
                TagDTO tagDTO = ConvertToDTO(item);
                TagList.Add(tagDTO);
               
            }
            return TagList;
        }

        /// <summary>
        /// Get tags by their ID
        /// </summary>
        /// <param name="ID">ID that is passed in the route</param>
        /// <returns>DTO tag</returns>
        public async Task<TagDTO> GetTag(int ID)
        {
            var tag = await _context.Tag.FindAsync(ID);
            TagDTO tDTO = ConvertToDTO(tag);
            return tDTO;
        }

        /// <summary>
        /// Update method that will take in tag and store it
        /// </summary>
        /// <param name="tag">Tag object from the front end</param>
        public async Task UpdateTag(Tag tag)
        {
            _context.Update(tag);
            await _context.SaveChangesAsync();

        }

        /// <summary>
        /// Converting tag to DTO
        /// </summary>
        /// <param name="tag">tag object</param>
        /// <returns>DTO tag object</returns>
        private TagDTO ConvertToDTO(Tag tag)
        {
            TagDTO tDTO = new TagDTO()
            {
                ID = tag.ID,
                Name = tag.Names
            };
            return tDTO;
        }
    }
}
