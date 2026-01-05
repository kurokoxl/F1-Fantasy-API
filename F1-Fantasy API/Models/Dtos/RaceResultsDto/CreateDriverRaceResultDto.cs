using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.RaceResultsDto
{
    public class CreateDriverRaceResultDto
    {
        [Required]
        public int DriverId { get; set; }

        [Required]
        public int RaceId { get; set; }

        [Required]
        [Range (1,20)]
        public int Position { get; set; }

    }
}
