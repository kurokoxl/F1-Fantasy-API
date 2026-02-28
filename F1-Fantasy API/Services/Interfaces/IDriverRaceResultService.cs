using F1_Fantasy_API.Models.Dtos.RaceResultsDto;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IDriverRaceResultService
    {
        Task<Result<IEnumerable<DriverRaceResultDto>>> GetAllResultsAsync();
        Task<Result<IEnumerable<DriverRaceResultDto>>> GetAllRaceResults(int raceId);
        Task<Result<DriverRaceResultDto>> GetResultByIdAsync(int driverId, int raceId);
        Task<Result<DriverRaceResultDto>> UpsertDriverRaceResultAsync(CreateDriverRaceResultDto createDto);
        Task<Result<IEnumerable<DriverRaceResultDto>>> UpsertBulkRaceResultsAsync(CreateBulkRaceResultsDto bulkDto);
        Task<Result<bool>> DeleteDriverRaceResult(int driverId, int raceId);
    }
}
