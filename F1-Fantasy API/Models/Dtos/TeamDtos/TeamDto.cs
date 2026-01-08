namespace F1_Fantasy_API.Models.Dtos.TeamDtos
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int TotalPoints { get; set; }
    }
}
