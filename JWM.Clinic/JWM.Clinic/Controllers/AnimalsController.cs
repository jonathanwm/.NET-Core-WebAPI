using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;
using JWM.Services.Comum;
using AutoMapper;

namespace JWM.Clinic.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        //private readonly Contexto _context;
        private readonly IServiceAnimal _serviceAnimal;

        public AnimalsController(IServiceAnimal serviceAnimal)
        {

            _serviceAnimal = serviceAnimal;

        }

        // GET: api/Animals
        [HttpGet]
        public IEnumerable<Animal> GetAnimals()
        {
            //return _context.Animals;
            return _serviceAnimal.Selection();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public IActionResult GetAnimal([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var animal = await _context.Animals.FindAsync(id);
            var animal = _serviceAnimal.SelectionToId(id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // PUT: api/Animals/5
        [HttpPut("{id}")]
        public IActionResult PutAnimal([FromRoute] long id, [FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.Id)
            {
                return BadRequest();
            }

            _serviceAnimal.Change(animal);
            //_context.Entry(animal).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AnimalExists(id))
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

        // POST: api/Animals
        [HttpPost]
        public IActionResult PostAnimal([FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _serviceAnimal.Insert(animal);
            //_context.Animals.Add(animal);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var animal = await _context.Animals.FindAsync(id);
            var animal = _serviceAnimal.SelectionToId(id);
            if (animal == null)
            {
                return NotFound();
            }

            //_context.Animals.Remove(animal);
            //await _context.SaveChangesAsync();
            _serviceAnimal.Delete(animal);

            return Ok(animal);
        }

        //[Route("api/[controller]/AnimalExists")]
        //[HttpGet(Name = "AnimalExists")]
        [Route("AnimalExists/{id}")]
        [HttpGet]
        public IActionResult AnimalExists([FromRoute] long id)
        {
            //return _context.Animals.Any(e => e.Id == id);
            bool exists = _serviceAnimal.Exists(id);
            return Ok(exists);
        }
    }
}