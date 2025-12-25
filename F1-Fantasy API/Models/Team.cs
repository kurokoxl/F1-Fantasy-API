namespace F1_Fantasy_API.Models;

public class Team
{
    public int TeamId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int TotalPoints { get; set; }
    
    // Navigation properties
    public User? User { get; set; }
    public List<DriverSelection> DriverSelections { get; set; } = new();
    public List<ConstructorSelection> ConstructorSelections { get; set; } = new();
}
