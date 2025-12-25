namespace F1_Fantasy_API.Models;

public class DriverSelection
{
    public int RaceId { get; set; }
    public int TeamId { get; set; }
    public int DriverId { get; set; }
    public bool IsTurbo { get; set; }
    
    // Navigation properties
    public Team? Team { get; set; }
    public Driver? Driver { get; set; }
    public Race? Race { get; set; }
}
