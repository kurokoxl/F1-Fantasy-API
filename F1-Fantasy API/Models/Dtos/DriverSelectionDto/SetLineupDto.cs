using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.DriverSelectionDto
{
    public class SetLineupDto
    {
        [Required]
        public int RaceId { get; set; }

        [Required]
        public List<int> DriverIds { get; set; } = new();

        //public int ConstructorId { get; set; }
        public int TurboDriverId { get; set; }
    }
}