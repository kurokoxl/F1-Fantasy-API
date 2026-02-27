using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.DriverSelectionDto
{
    /// <summary>
    /// Used to select both drivers for a team in a single request.
    /// </summary>
    public class CreateDriversSelectionDto
    {
        [Required]
        public int DriverOneId { get; set; }

        [Required]
        public int DriverTwoId { get; set; }
    }
}
