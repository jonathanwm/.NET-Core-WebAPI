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
using JWM.Clinic.API.ViewModels;

namespace JWM.Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandbooksController : ControllerBase
    {
        //private readonly Contexto _context;
        private readonly IMapper _mapper;
        private readonly IServiceHandbook _serviceHandbook;

        public HandbooksController(IMapper mapper, IServiceHandbook serviceHandbook)
        {
            _mapper = mapper;
            _serviceHandbook = serviceHandbook;
        }

        // GET: api/Handbooks
        [HttpGet]
        public IEnumerable<HandbookExibicaoViewModel> GetHandbooks()
        {

            //_mapper.Map<TypeIWantToMapTo>(originalObject);
            var prontuarios = _serviceHandbook.Selection();
            var teste = _mapper.Map<List<HandbookExibicaoViewModel>>(prontuarios);
            return _mapper.Map<List<HandbookExibicaoViewModel>>(_serviceHandbook.Selection());
                
        }

        // GET: api/Handbooks/5
        [HttpGet("{id}")]
        public IActionResult GetHandbook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var handbook = await _context.Handbooks.FindAsync(id);
            var prontuario = _serviceHandbook.SelectionToId(id);
            var teste = _mapper.Map<HandbookExibicaoViewModel>(prontuario);
            var handbook = _mapper.Map<HandbookExibicaoViewModel>(_serviceHandbook.SelectionToId(id));


            if (handbook == null)
            {
                return NotFound();
            }

            return Ok(handbook);
        }

        // PUT: api/Handbooks/5
        [HttpPut("{id}")]
        public IActionResult PutHandbook([FromRoute] long id, [FromBody] HandbookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            TimeSpan hour = TimeSpan.Parse(viewModel.Hour);
            Handbook handbook = Mapper.Map<Handbook>(viewModel);
            handbook.Date = handbook.Date.Add(hour);
            _serviceHandbook.Change(handbook);
            //TimeSpan hora = TimeSpan.Parse(viewModel.Hora);
            //Prontuario prontuario = Mapper.Map<ProntuarioViewModel, Prontuario>(viewModel);
            //prontuario.Data = prontuario.Data.Add(hora);
            //repositorioProntuarios.Alterar(prontuario);
            //.Entry(handbook).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!HandbookExists(id))
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

        // POST: api/Handbooks
        [HttpPost]
        public IActionResult PostHandbook([FromBody] HandbookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            TimeSpan hour = TimeSpan.Parse(viewModel.Hour);
            Handbook handbook = _mapper.Map<Handbook>(viewModel);
            handbook.Date = handbook.Date.Add(hour);
            _serviceHandbook.Insert(handbook);
            //_context.Handbooks.Add(handbook);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetHandbook", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/Handbooks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHandbook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var handbook = _serviceHandbook.SelectionToId(id);
            if (handbook == null)
            {
                return NotFound();
            }

            _serviceHandbook.Delete(handbook);
            //_context.Handbooks.Remove(handbook);
            //await _context.SaveChangesAsync();

            return Ok(handbook);
        }

        [Route("HandbookExists/{id}")]
        [HttpGet]
        public IActionResult HandbookExists([FromRoute] long id)
        {
            //return _context.Animals.Any(e => e.Id == id);
            bool exists = _serviceHandbook.Exists(id);
            return Ok(exists);
        }
    }
}