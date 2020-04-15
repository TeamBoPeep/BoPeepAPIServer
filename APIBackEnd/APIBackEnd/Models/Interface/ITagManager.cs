using APIBackEnd.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.Interface
{
    public interface ITagManager
    {
        Task<TagDTO> CreateTag(TagDTO tagDTO);
        //read
        Task<TagDTO> GetTag(int ID);
        //readAll
        Task<List<TagDTO>> GetAllTags();
        //update
        Task UpdateTag(Tag tag);
        //delete
        Task DeleteTag(int ID); 
    }

}
