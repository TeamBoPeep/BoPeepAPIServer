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

        public TagsController(ITagManager context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDTO>>> GetTag() => await _context.GetAllTags();



        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagDTO>> GetTag(int id) => await _context.GetTag(id);


        // PUT: api/Tags/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task PutTag(int id, Tag tag) => await _context.UpdateTag(tag);


        // POST: api/Tags
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(TagDTO tagDTO)
        {
            await _context.CreateTag(tagDTO);
            return CreatedAtAction("GetTag", new { id = tagDTO.Id }, tagDTO);

        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task DeleteTag(int id) => await _context.DeleteTag(id);
    }
}
