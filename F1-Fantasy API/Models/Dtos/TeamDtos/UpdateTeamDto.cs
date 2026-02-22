using F1_Fantasy_API.Models.Dtos.ConstructorDtos;
using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.TeamDtos
{
    public class UpdateTeamDto
    {
        [Required]
        public string Name { get; set; } 
        public int? constructorId { get; set; }
    }
}
