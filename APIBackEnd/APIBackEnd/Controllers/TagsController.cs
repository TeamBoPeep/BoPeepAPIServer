using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBackEnd.Data;
using APIBackEnd.Models;
using APIBackEnd.Models.Interface;
using APIBackEnd.Models.DTO;

namespace APIBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagManager _context;

        /// <summary>
        /// Contructor that will take our interface to use it as context
        /// </summary>
        /// <param name="context">ITagManger interface</param>
        public TagsController(ITagManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Get route for our tags
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDTO>>> GetTag() => await _context.GetAllTags();



        /// <summary>
        /// Get route for our a tag
        /// </summary>
        /// <param name="id">takes in the param id</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<TagDTO>> GetTag(int id) => await _context.GetTag(id);


        /// <summary>
        /// Update the tag
        /// </summary>
        /// <param name="tag">tag that will be used to update the database</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task PutTag(int id, Tag tag) => await _context.UpdateTag(tag);


        /// <summary>
        /// Post method that will create a tag
        /// </summary>
        /// <param name="tagDTO">tag dto from front end</param>
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(TagDTO tagDTO)
        {
            await _context.CreateTag(tagDTO);
            return CreatedAtAction("GetTag", new { id = tagDTO.ID }, tagDTO);

        }

        /// <summary>
        /// Delete method that will delete specific tag that is passed in as ID
        /// </summary>
        /// <param name="id">id that is in the route</param>
        [HttpDelete("{id}")]
        public async Task DeleteTag(int id) => await _context.DeleteTag(id);
    }
}
