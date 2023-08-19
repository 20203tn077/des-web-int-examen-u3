namespace ApiExamen.Models;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string RecommendedDose { get; set; } = null!;
    public string AdministrationMethod { get; set; } = null!;
    public string Indications { get; set; } = null!;
}