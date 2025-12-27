namespace F1_Fantasy_API.Models.Entites;

public class Race
{
    public int RaceId { get; set; }
    public int Season { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CircuitName { get; set; } = string.Empty;
    public int Laps { get; set; }
    public DateTime Date { get; set; }
    
    // Navigation properties
    public List<DriverRaceResult> DriverRaceResults { get; set; } = new();
    public List<DriverSelection> DriverSelections { get; set; } = new();
    public List<ConstructorSelection> ConstructorSelections { get; set; } = new();
}
