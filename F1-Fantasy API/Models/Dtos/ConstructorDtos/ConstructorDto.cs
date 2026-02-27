using F1_Fantasy_API.Models.Dtos.DriverDtos;

namespace F1_Fantasy_API.Models.Dtos.ConstructorDtos
{
    public class ConstructorDto
    {
        public int ConstructorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<DriverDto> Drivers { get; set; } = new();

    }
}
