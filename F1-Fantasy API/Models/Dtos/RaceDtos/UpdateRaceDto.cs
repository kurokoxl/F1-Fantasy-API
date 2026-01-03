using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.RaceDtos
{
    public class UpdateRaceDto
    {
        [Required]
        public int RaceId { get; set; }
        [Required]
        public int Season { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CircuitName { get; set; }
        [Required]
        [Range(1, 500)]
        public int Laps { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}