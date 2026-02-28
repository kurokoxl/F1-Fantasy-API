namespace F1_Fantasy_API.Models.Entites;

public class Team
{
    public int TeamId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int TotalPoints { get; set; }
    public int ? ConstructorId { get; set; }
    
    // Navigation properties
    public User? User { get; set; }
    public Constructor? Constructor { get; set; }
    public List<DriverSelection> DriverSelections { get; set; } = new();
}
