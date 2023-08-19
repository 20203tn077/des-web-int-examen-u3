namespace ApiExamen.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null !;
        public string Species { get; set; } = null !;
        public string Race { get; set; } = null !;
        public double Weight { get; set; }
        public DateTime Birthday { get; set; }
    }
}