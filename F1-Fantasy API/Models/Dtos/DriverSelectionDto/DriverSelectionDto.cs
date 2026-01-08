namespace F1_Fantasy_API.Models.Dtos.DriverSelectionDto
{
    public class DriverSelectionDto
    {
        public int RaceId { get; set; }
        public int TeamId { get; set; }
        public int DriverId { get; set; }
        public bool IsTurbo { get; set; }
    }
}
