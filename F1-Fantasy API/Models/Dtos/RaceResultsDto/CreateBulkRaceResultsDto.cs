using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.RaceResultsDto
{
    /// <summary>
    /// Used to submit all driver results for a single race in one request.
    /// </summary>
    public class CreateBulkRaceResultsDto
    {
        [Required]
        public int RaceId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one result must be provided.")]
        public List<BulkResultEntryDto> Results { get; set; } = new();
    }

    public class BulkResultEntryDto
    {
        [Required]
        public int DriverId { get; set; }

        [Required]
        [Range(1, 20)]
        public int Position { get; set; }
    }
}
