using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Models.Entites;

internal interface IRaceService
{
    Task<IEnumerable<RaceDto>> GetRacesAsync();
    Task<RaceDto?> GetRaceByIdAsync(int id);
    Task<RaceDto?> AddRaceAsync(CreateRaceDto createDto);
    Task<RaceDto?> UpdateRaceAsync(int id,UpdateRaceDto updateDto);
    Task<bool> DeleteRace(int id);

}