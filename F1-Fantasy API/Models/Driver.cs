namespace F1_Fantasy_API.Models;

public class Driver
{
    public int DriverId { get; set; }
    public int ConstructorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    
    // Navigation properties
    public Constructor? Constructor { get; set; }
    public List<DriverSelection> DriverSelections { get; set; } = new();
    public List<DriverRaceResult> DriverRaceResults { get; set; } = new();
}
