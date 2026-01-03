namespace F1_Fantasy_API.Models.Dtos.DriverDtos
{
    public class DriverDto
    {
        public int DriverId { get; set; }
        public int ConstructorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}