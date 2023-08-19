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
    public class OwnerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OwnerController(ApplicationDbContext context)
        {
            _context = context;
        }
        //retornar una respuesta
        //[HttpGet("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listOwners = await _context.Owners!.ToListAsync();
            if (listOwners == null || listOwners.Count == 0)
            {
                return NoContent();

            }
            return Ok(listOwners);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(owner);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var owner = await _context.Owners!.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var owner = await _context.Owners!.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Owner owner){
            if(owner==null){
                return BadRequest();
            }
            var entity = await _context.Owners!.FindAsync(owner.Id);
            if(entity==null){
                return NotFound();
            }
            entity.Name = owner.Name;
            entity.LastName = owner.LastName;
            entity.Address = owner.Address;
            entity.Email = owner.Email;
            entity.PhoneNumber = owner.PhoneNumber;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}