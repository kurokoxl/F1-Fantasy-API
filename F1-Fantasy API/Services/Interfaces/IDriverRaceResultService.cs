using F1_Fantasy_API.Models.Dtos.RaceResultsDto;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IDriverRaceResultRaceResultService
    {
        Task<Result<IEnumerable<DriverRaceResultDto>>> GetDriverRaceResultsAsync();
        Task<Result<DriverRaceResultDto>> GetDriverRaceResultByIdAsync(int driverId, int raceId);
        Task<Result<DriverRaceResultDto>> UpsertDriverRaceResultAsync(CreateDriverRaceResultDto createDto);
        Task<Result<bool>> DeleteDriverRaceResult(int driverId, int raceId);
    }
}
