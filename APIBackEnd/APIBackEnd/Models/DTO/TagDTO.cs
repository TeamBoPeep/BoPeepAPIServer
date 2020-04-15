using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Models.DTO
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Names { get; set; }

        public List<ActivitiesDTO> ActivitiesDTOs = new List<ActivitiesDTO>();
    }
}
