using ApiExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { 
    }
    
    // Patients
    
    
    // Owners
    
    
    // Medicines
}