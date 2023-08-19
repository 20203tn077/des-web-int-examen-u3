using System.Net;
using ApiExamen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicineController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MedicineController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var medicines = _context.Medicines;
        if (medicines == null || !medicines.Any()) return NoContent();
        return Ok(medicines);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Show(int id)
    {
        var medicine = await _context.Medicines!.FindAsync(id);
        if (medicine == null) return NotFound();
        return Ok(medicine);
    }

    [HttpPost]
    public async Task<HttpStatusCode> Store([FromBody] Medicine medicine)
    {
        _context.Add(medicine);
        await _context.SaveChangesAsync();
        return HttpStatusCode.Created;
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Medicine medicine)
    {
        var entity = await _context.Medicines!.FindAsync(medicine.Id);
        if (entity == null) return NotFound();
        entity.Id = medicine.Id;
        entity.Name = medicine.Name;
        entity.Description = medicine.Description;
        entity.RecommendedDose = medicine.RecommendedDose;
        entity.AdministrationMethod = medicine.AdministrationMethod;
        entity.Indications = medicine.Indications;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Destroy(int id)
    {
        var medicine = await _context.Medicines!.FindAsync(id);
        if (medicine == null) return NotFound();
        _context.Medicines.Remove(medicine);
        await _context.SaveChangesAsync();
        return Ok();
    }
}