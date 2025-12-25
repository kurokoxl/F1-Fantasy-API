namespace F1_Fantasy_API.Models;

public class Constructor
{
    public int ConstructorId { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Navigation properties
    public List<Driver> Drivers { get; set; } = new();
    public List<ConstructorSelection> ConstructorSelections { get; set; } = new();
}
