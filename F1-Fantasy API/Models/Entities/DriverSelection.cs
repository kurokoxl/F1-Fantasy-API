namespace F1_Fantasy_API.Models.Entites;

public class DriverSelection
{
    public int TeamId { get; set; }
    public int DriverId { get; set; }
    
    // Navigation properties
    public Team? Team { get; set; }
    public Driver? Driver { get; set; }
    public Race? Race { get; set; }
}
