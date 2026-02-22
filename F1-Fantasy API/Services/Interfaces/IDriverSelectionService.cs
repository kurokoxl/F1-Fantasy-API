using F1_Fantasy_API.Models.Dtos.DriverSelectionDto;
using System.Threading.Tasks;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IDriverSelectionService
    {
        Task<Result<IEnumerable<DriverSelectionDto>>> GetDriverSelectionsAsync(string userId);
        Task<Result<DriverSelectionDto>> GetDriverSelectionByIdAsync(int driverId,string userId);
        Task<Result<DriverSelectionDto>> AddDriverSelectionAsync(CreateDriverSelectionDto createDto, string userId);


        Task<Result<DriverSelectionDto>> UpdateDriverSelectionAsync(int driverId, UpdateDriverSelectionDto updateDto, string userId);
        Task<Result<bool>> DeleteDriverSelection(int id, string userId);

        //Task<Result<IEnumerable<DriverSelectionDto>>> SetLineupAsync(SetLineupDto lineupDto, string userId);
        //Task<Result<IEnumerable<DriverSelectionDto>>> GetNextRaceSelections(string userId);
        //Task<Result<bool>> SetTurboDriverAsync(int driverId, int raceId, string userId);


    }
}
