using AutoMapper;
using F1_Fantasy_API.Models.Dtos.DriverSelectionDto;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;

namespace F1_Fantasy_API.Services
{
    public class DriverSelectionService : IDriverSelectionService   
    {
        private readonly IDriverSelectionRepository _driverSelectionRepository;
        private readonly IMapper _mapper;
        public DriverSelectionService(IDriverSelectionRepository driverSelectionRepository, IMapper mapper)
        {
            _driverSelectionRepository = driverSelectionRepository;
            _mapper = mapper;
        }

        public async Task<Result<DriverSelectionDto>> AddDriverSelectionAsync(CreateDriverSelectionDto createDto, string userId)
        {
            //var team = await _driverSelectionRepository.CheckTeam(userId) == null;
            //if (team==null)
            //{
            //    return Result<DriverSelectionDto>.Failure("Team doesn't exisit");
            //}
            //_driverSelectionRepository.CountTeam(team);
            throw new NotImplementedException();
        }

  
        public Task<Result<bool>> DeleteDriverSelection(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteDriverSelection(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DriverSelectionDto>> GetDriverSelectionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DriverSelectionDto>> GetDriverSelectionByIdAsync(int driverId, string userId, int raceId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<DriverSelectionDto>>> GetDriverSelectionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<DriverSelectionDto>>> GetNextRaceSelections(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<DriverSelectionDto>>> SetLineupAsync(SetLineupDto lineupDto, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> SetTurboDriverAsync(int driverId, int raceId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DriverSelectionDto>> UpdateDriverSelectionAsync(int id, UpdateDriverSelectionDto updateDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DriverSelectionDto>> UpdateDriverSelectionAsync(int id, UpdateDriverSelectionDto updateDto, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
