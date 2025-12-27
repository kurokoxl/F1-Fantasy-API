using Microsoft.AspNetCore.Identity;

namespace F1_Fantasy_API.Models.Entites;

public class User : IdentityUser
{
    public int Balance { get; set; }
    
    // Navigation property
    public Team? Team { get; set; }
}
