using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.ConstructorDtos
{
    public class UpdateConstructorDto
    {
        [Required]
        public int ConstructorId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }

}
