using System.ComponentModel.DataAnnotations;

namespace F1_Fantasy_API.Models.Dtos.DriverSelectionDto
{
    public class CreateDriverSelectionDto
    {


        [Required]
        public int DriverId { get; set; }


    }
}
