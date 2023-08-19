using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ApiExamen.Models;
namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        //retornar una respuesta
        //[HttpGet("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listPatients = await _context.Patients!.ToListAsync();
            if (listPatients == null || listPatients.Count == 0)
            {
                return NoContent();

            }
            return Ok(listPatients);
        }

        [HttpPost]
        public async Task<HttpStatusCode> Store([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(patient);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(int id)
        {
            var patient = await _context.Patients!.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpDelete]
        public async Task<IActionResult> Destroy(int id)
        {
            var patient = await _context.Patients!.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id,[FromBody] Patient patient){
            if(patient==null || patient.Id !=id){
                return BadRequest();
            }
            var entity = await _context.Patients!.FindAsync(id);
            if(entity==null){
                return NotFound();
            }
            entity.Name = patient.Name;
            entity.Species = patient.Species;
            entity.Race = patient.Race;
            entity.Weight = patient.Weight;
            entity.Birthday = patient.Birthday;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}