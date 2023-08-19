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
    public DbSet<Owner>? Owners {get; set;}
    
    // Medicines
}