using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;
using AutoMapper;

namespace JWM.Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinariesController : ControllerBase
    {
        private readonly Contexto _context;
        private readonly IMapper _mapper;

        public VeterinariesController(Contexto context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Veterinaries
        [HttpGet]
        public IEnumerable<Veterinary> GetVeterinaries()
        {
            return _context.Veterinaries;
        }

        // GET: api/Veterinaries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeterinary([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var veterinary = await _context.Veterinaries.FindAsync(id);

            if (veterinary == null)
            {
                return NotFound();
            }

            return Ok(veterinary);
        }

        // PUT: api/Veterinaries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinary([FromRoute] long id, [FromBody] Veterinary veterinary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veterinary.Id)
            {
                return BadRequest();
            }

            _context.Entry(veterinary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinaryExists(id))
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

        // POST: api/Veterinaries
        [HttpPost]
        public async Task<IActionResult> PostVeterinary([FromBody] Veterinary veterinary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Veterinaries.Add(veterinary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeterinary", new { id = veterinary.Id }, veterinary);
        }

        // DELETE: api/Veterinaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinary([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var veterinary = await _context.Veterinaries.FindAsync(id);
            if (veterinary == null)
            {
                return NotFound();
            }

            _context.Veterinaries.Remove(veterinary);
            await _context.SaveChangesAsync();

            return Ok(veterinary);
        }

        private bool VeterinaryExists(long id)
        {
            return _context.Veterinaries.Any(e => e.Id == id);
        }
    }
}