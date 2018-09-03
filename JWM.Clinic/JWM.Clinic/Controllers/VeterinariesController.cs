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
using JWM.Services.Comum;

namespace JWM.Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinariesController : ControllerBase
    {
        //private readonly Contexto _context;
        //private readonly IMapper _mapper;
        private readonly IServiceVeterinary _serviceVeterinary;

        public VeterinariesController(IServiceVeterinary serviceVeterinary)
        {
            _serviceVeterinary = serviceVeterinary;
            
        }

        // GET: api/Veterinaries
        [HttpGet]
        public IEnumerable<Veterinary> GetVeterinaries()
        {
            //return _context.Veterinaries;
            return _serviceVeterinary.Selection();
        }

        // GET: api/Veterinaries/5
        [HttpGet("{id}")]
        public IActionResult GetVeterinary([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var veterinary = await _context.Veterinaries.FindAsync(id);
            var veterinary = _serviceVeterinary.SelectionToId(id);

            if (veterinary == null)
            {
                return NotFound();
            }

            return Ok(veterinary);
        }

        // PUT: api/Veterinaries/5
        [HttpPut("{id}")]
        public IActionResult PutVeterinary([FromRoute] long id, [FromBody] Veterinary veterinary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veterinary.Id)
            {
                return BadRequest();
            }

            //_context.Entry(veterinary).State = EntityState.Modified;
            _serviceVeterinary.Change(veterinary);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!VeterinaryExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Veterinaries
        [HttpPost]
        public IActionResult PostVeterinary([FromBody] Veterinary veterinary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Veterinaries.Add(veterinary);
            //await _context.SaveChangesAsync();
            _serviceVeterinary.Insert(veterinary);

            return CreatedAtAction("GetVeterinary", new { id = veterinary.Id }, veterinary);
        }

        // DELETE: api/Veterinaries/5
        [HttpDelete("{id}")]
        public IActionResult DeleteVeterinary([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var veterinary = await _context.Veterinaries.FindAsync(id);
            var veterinary = _serviceVeterinary.SelectionToId(id);
            if (veterinary == null)
            {
                return NotFound();
            }

            //_context.Veterinaries.Remove(veterinary);
            //await _context.SaveChangesAsync();
            _serviceVeterinary.Delete(veterinary);

            return Ok(veterinary);
        }

       
        [Route("VeterinaryExists/{id}")]
        [HttpGet]
        public IActionResult VeterinaryExists([FromRoute] long id)
        {
            //return _context.Animals.Any(e => e.Id == id);
            bool exists = _serviceVeterinary.Exists(id);
            return Ok(exists);
        }
    }
}