using F1_Fantasy_API.Models.Dtos.DriverDtos;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IDriverService
    {
        Task<Result<IEnumerable<DriverDto>>> GetDriversAsync();
        Task<Result<DriverDto>> GetDriverByIdAsync(int id);
        Task<Result<DriverDto>> AddDriverAsync(CreateDriverDto createDto);
        Task<Result<DriverDto>> UpdateDriverAsync(int id, UpdateDriverDto updateDto);
        Task<Result<bool>> DeleteDriver(int id);
    }
}
