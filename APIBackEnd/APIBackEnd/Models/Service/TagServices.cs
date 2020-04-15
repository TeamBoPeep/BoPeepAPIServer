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
        private BoPeepDbContext _context;

        public TagServices(BoPeepDbContext context)
        {
            _context = context;
        }

        public async Task<TagDTO> CreateTag(TagDTO tagDTO)
        {
            Tag tag = new Tag()
            {
                ID = tagDTO.Id,
                Names = tagDTO.Names
            };
            _context.Add(tag);
            await _context.SaveChangesAsync();
            return tagDTO;
        }

        public async Task DeleteTag(int ID)
        {
            var tag = await _context.Tag.FindAsync(ID);
            _context.Remove(tag);
            await _context.SaveChangesAsync();
        }

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

        public async Task<TagDTO> GetTag(int ID)
        {
            var tag = await _context.Tag.FindAsync(ID);
            TagDTO tDTO = ConvertToDTO(tag);
            return tDTO;
        }

        public async Task UpdateTag(Tag tag)
        {
            _context.Update(tag);
            await _context.SaveChangesAsync();

        }
        private TagDTO ConvertToDTO(Tag tag)
        {
            TagDTO tDTO = new TagDTO()
            {
                Id = tag.ID,
                Names = tag.Names
            };
            return tDTO;
        }
    }
}
