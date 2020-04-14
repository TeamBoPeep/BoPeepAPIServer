using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.Interface
{
    interface ITagManager
    {
        Task<TagDTO> CreateTag(Tag tag);
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
