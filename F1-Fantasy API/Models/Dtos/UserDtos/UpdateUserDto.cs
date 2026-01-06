using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        [Required]
        [Range(0,100)]
        public int Balance { get; set; }

    }
}
