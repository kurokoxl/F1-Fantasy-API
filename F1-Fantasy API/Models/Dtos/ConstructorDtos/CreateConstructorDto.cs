using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.ConstructorDtos
{
    public class CreateConstructorDto 
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }

}
