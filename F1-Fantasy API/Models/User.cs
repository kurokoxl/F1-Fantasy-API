namespace F1_Fantasy_API.Models;

public class User
{
    public string UserId { get; set; } = string.Empty;
    public int Balance { get; set; }
    
    // Navigation property
    public Team? Team { get; set; }
}
