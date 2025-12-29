using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.DTOs.AuthDtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
