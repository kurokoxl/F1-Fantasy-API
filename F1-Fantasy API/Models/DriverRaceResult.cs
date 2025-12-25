namespace F1_Fantasy_API.Models;

public class DriverRaceResult
{
    public int DriverId { get; set; }
    public int RaceId { get; set; }
    public int Position { get; set; }
    public int Points { get; set; }
    
    // Navigation properties
    public Driver? Driver { get; set; }
    public Race? Race { get; set; }
}
