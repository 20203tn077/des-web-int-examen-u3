using ApiExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { 
    }
    
    // Patients
    public DbSet<Patient>? Patients{ get; set;}
    
    
    // Owners
    public DbSet<Owner>? Owners {get; set;}
    
    // Medicines
}