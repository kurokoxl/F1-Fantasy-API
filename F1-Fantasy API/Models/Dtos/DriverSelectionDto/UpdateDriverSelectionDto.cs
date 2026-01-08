using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.DriverSelectionDto
{
    public class UpdateDriverSelectionDto
    {
        [Required]
        public int RaceId { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int DriverId { get; set; }
        [Required]
        public bool IsTurbo { get; set; }
    }
}
