using F1_Fantasy_API.Models.Dtos.DriverSelectionDto;

namespace F1_Fantasy_API.Models.Dtos.TeamDtos
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int constructorId { get; set; }
        public string constructorName { get; set; }
        public List<DriverSelectionDto.DriverSelectionDto> DriverSelections { get; set; } = new List<DriverSelectionDto.DriverSelectionDto>();
        public int TotalPoints { get; set; }

    }
}
