using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.DriverDtos
{
    public class CreateDriverDto
    {
        [Required]
        public int ConstructorId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range (1,100)]
        public int Price { get; set; }
    }
}
