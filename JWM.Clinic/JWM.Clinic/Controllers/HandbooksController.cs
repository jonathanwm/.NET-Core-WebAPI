using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;

namespace JWM.Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandbooksController : ControllerBase
    {
        private readonly Contexto _context;

        public HandbooksController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Handbooks
        [HttpGet]
        public IEnumerable<Handbook> GetHandbooks()
        {
            return _context.Handbooks;
        }

        // GET: api/Handbooks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHandbook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var handbook = await _context.Handbooks.FindAsync(id);

            if (handbook == null)
            {
                return NotFound();
            }

            return Ok(handbook);
        }

        // PUT: api/Handbooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHandbook([FromRoute] long id, [FromBody] Handbook handbook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != handbook.Id)
            {
                return BadRequest();
            }

            _context.Entry(handbook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HandbookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Handbooks
        [HttpPost]
        public async Task<IActionResult> PostHandbook([FromBody] Handbook handbook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Handbooks.Add(handbook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHandbook", new { id = handbook.Id }, handbook);
        }

        // DELETE: api/Handbooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHandbook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var handbook = await _context.Handbooks.FindAsync(id);
            if (handbook == null)
            {
                return NotFound();
            }

            _context.Handbooks.Remove(handbook);
            await _context.SaveChangesAsync();

            return Ok(handbook);
        }

        private bool HandbookExists(long id)
        {
            return _context.Handbooks.Any(e => e.Id == id);
        }
    }
}