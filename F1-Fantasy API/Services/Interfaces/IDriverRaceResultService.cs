using F1_Fantasy_API.Models.Dtos.DriverRaceResultDtos;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IDriverRaceResultRaceResultService
    {
        Task<Result<IEnumerable<DriverRaceResultDto>>> GetDriverRaceResultsAsync();
        Task<Result<DriverRaceResultDto>> GetDriverRaceResultByIdAsync(int id);
        Task<Result<DriverRaceResultDto>> AddDriverRaceResultAsync(CreateDriverRaceResultDto createDto);
        Task<Result<DriverRaceResultDto>> UpdateDriverRaceResultAsync(int id, UpdateDriverRaceResultDto updateDto);
        Task<Result<bool>> DeleteDriverRaceResult(int id);
    }
}
