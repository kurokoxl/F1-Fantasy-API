namespace F1_Fantasy_API.Models.Dtos.RaceDtos
{
    public class UpdateRaceDto
    {
        public int RaceId { get; set; }
        public int Season { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CircuitName { get; set; } = string.Empty;
        public int Laps { get; set; }
        public DateTime Date { get; set; }
    }
}