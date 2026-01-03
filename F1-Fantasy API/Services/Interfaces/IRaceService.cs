using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Services;

public interface IRaceService
{
    Task<Result<IEnumerable<RaceDto>>> GetRacesAsync();
    Task<Result<RaceDto>> GetRaceByIdAsync(int id);
    Task<Result<RaceDto>> AddRaceAsync(CreateRaceDto createDto);
    Task<Result<RaceDto>> UpdateRaceAsync(int id,UpdateRaceDto updateDto);
    Task<Result<bool>> DeleteRace(int id);

}