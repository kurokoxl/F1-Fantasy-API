namespace F1_Fantasy_API.Models.Entites;

public class ConstructorSelection
{
    public int TeamId { get; set; }
    public int RaceId { get; set; }
    public int ConstructorId { get; set; }
    
    // Navigation properties
    public Team? Team { get; set; }
    public Constructor? Constructor { get; set; }
    public Race? Race { get; set; }
}
