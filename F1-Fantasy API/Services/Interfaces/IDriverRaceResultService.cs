using F1_Fantasy_API.Models.Dtos.RaceResultsDto;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IDriverRaceResultRaceResultService
    {
        Task<Result<IEnumerable<DriverRaceResultDto>>> GetAllResultsAsync();
        Task<Result<IEnumerable<DriverRaceResultDto>>> GetAllRaceResults(int raceId);
        Task<Result<DriverRaceResultDto>> GetResultByIdAsync(int driverId, int raceId);
        Task<Result<DriverRaceResultDto>> UpsertDriverRaceResultAsync(CreateDriverRaceResultDto createDto);
        Task<Result<bool>> DeleteDriverRaceResult(int driverId, int raceId);
    }
}
