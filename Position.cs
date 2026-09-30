namespace HV_prosjekt.Models;

public class Position
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
