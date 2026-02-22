using AutoMapper;
using F1_Fantasy_API.Models.Dtos.DriverSelectionDto;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;

namespace F1_Fantasy_API.Services
{
    public class DriverSelectionService : IDriverSelectionService   
    {
        private readonly IDriverSelectionRepository _driverSelectionRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IRaceRepository _raceRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DriverSelectionService(
            IDriverSelectionRepository driverSelectionRepository,
            ITeamRepository teamRepository,
            IMapper mapper,
            IRaceRepository raceRepository,
            IUserRepository userRepository,
            IDriverRepository driverRepository)
        {
            _driverSelectionRepository = driverSelectionRepository;
            _teamRepository = teamRepository;
            _raceRepository = raceRepository;
            _userRepository = userRepository;
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<Result<DriverSelectionDto>> AddDriverSelectionAsync(CreateDriverSelectionDto createDto, string userId)
        {
            //No Team?
            var team = await _teamRepository.GetTeamByUserIdAsync(userId);
            if (team == null)
            {
                return Result<DriverSelectionDto>.Failure("Team doesn't exist");
            }

            //Team full?
            if (team.DriverSelections.Count >= 2)
                return Result<DriverSelectionDto>.Failure("Can't select more than 2 drivers");

            //Duplicate driver?
            var exists = team.DriverSelections.Any(ds => ds.DriverId == createDto.DriverId);
            if (exists)
            {
                return Result<DriverSelectionDto>.Failure("This driver is already in your team.");
            }

            //Open Race?
            if (await _raceRepository.ValidateRaceStatus()  == false)
            {
                return Result<DriverSelectionDto>.Failure("There's no open race at the moment please check races list");
            }
            

            var driver = await _driverRepository.GetByIdAsync(createDto.DriverId);

            //driver exisits?
            if (driver == null)
                return Result<DriverSelectionDto>.Failure("Driver not found.");


            var user = await _userRepository.GetByIdAsync(userId);

            //User balance?
            if (driver.Price > user.Balance)
                return Result<DriverSelectionDto>.Failure("Insufficient balance");
           
            user.Balance -= driver.Price;
           
            var driverSelection = _mapper.Map<DriverSelection>(createDto);
            driverSelection.TeamId = team.TeamId;

            await _driverSelectionRepository.AddAsync(driverSelection);
            await _driverSelectionRepository.SaveChangesAsync();

            return Result<DriverSelectionDto>.Success(_mapper.Map<DriverSelectionDto>(driverSelection));


        }


        public async  Task<Result<bool>> DeleteDriverSelection(int driverID, string userId)
        {
            var team = await _teamRepository.GetTeamByUserIdAsync(userId);
            if (team == null)
            {
                return Result<bool>.Failure("Team doesn't exist");
            }
            //Open Race?
            if (await _raceRepository.ValidateRaceStatus() == false)
            {
                return Result<bool>.Failure("There's no open race at the moment please check races list");
            }

            var driver = await _driverRepository.GetByIdAsync(driverID);

            //driver exisits?
            if (driver == null)
                return Result<bool>.Failure("Driver not found.");

            var user = await _userRepository.GetByIdAsync(userId);

            user.Balance += driver.Price;

            var driverSelection = await _driverSelectionRepository.GetByIdAsync(team.TeamId, driver.DriverId);

            //driver selected?
            if (driverSelection == null)
                return Result<bool>.Failure("Driver isn't selected in your team");

            _driverSelectionRepository.Delete(driverSelection);
            await _driverRepository.SaveChangesAsync();
            return Result<bool>.Success(true);
        }



        public async Task<Result<DriverSelectionDto>> GetDriverSelectionByIdAsync(int driverId, string userId)
        {
            var team = await _teamRepository.GetTeamByUserIdAsync(userId);
            if (team == null)
            {
                return Result<DriverSelectionDto>.Failure("Team doesn't exist");
            }
            var driverSelection = await  _driverSelectionRepository.GetByIdAsync(team.TeamId,driverId);

            if (driverSelection == null)
                return Result<DriverSelectionDto>.Failure("Driver isn't selected in your team");


            return Result<DriverSelectionDto>.Success(_mapper.Map<DriverSelectionDto>(driverSelection));
        }

        public async Task<Result<IEnumerable<DriverSelectionDto>>> GetDriverSelectionsAsync(string userId)
        {
            var team = await _teamRepository.GetTeamByUserIdAsync(userId);
            if (team == null)
            {
                return Result<IEnumerable<DriverSelectionDto>>.Failure("Team doesn't exist");
            }
            var driverSelections = await _driverSelectionRepository.GetAllAsync(team.TeamId);

            if (driverSelections == null)
                return Result<IEnumerable<DriverSelectionDto>>.Failure("Driver isn't selected in your team");


            return Result<IEnumerable<DriverSelectionDto>>.Success(_mapper.Map<IEnumerable<DriverSelectionDto>>(driverSelections));
        }

        public async Task<Result<DriverSelectionDto>> UpdateDriverSelectionAsync(int oldDriverId, UpdateDriverSelectionDto updateDto, string userId)
        {
            using var transaction = await _driverSelectionRepository.BeginTransactionAsync();

            try
            {
                var team = await _teamRepository.GetTeamByUserIdAsync(userId);
                var oldDriver = await _driverRepository.GetByIdAsync(oldDriverId);
                var newDriver = await _driverRepository.GetByIdAsync(updateDto.DriverId);
                var user = await _userRepository.GetByIdAsync(userId);

                // 3. Validations
                if (team == null) return Result<DriverSelectionDto>.Failure("Team doesn't exist");
                if (oldDriver == null || newDriver == null) return Result<DriverSelectionDto>.Failure("Driver(s) not found.");

                if (!await _raceRepository.ValidateRaceStatus())
                    return Result<DriverSelectionDto>.Failure("Market is locked.");

                var existingSelection = await _driverSelectionRepository.GetByIdAsync(team.TeamId, oldDriverId);
                if (existingSelection == null)
                    return Result<DriverSelectionDto>.Failure("The driver to be replaced is not in your team.");


                int swapCost = newDriver.Price - oldDriver.Price;

                if (user.Balance < swapCost)
                    return Result<DriverSelectionDto>.Failure("Insufficient balance to complete this swap.");

                user.Balance -= swapCost; 

                _driverSelectionRepository.Delete(existingSelection);

                var newSelection = new DriverSelection
                {
                    TeamId = team.TeamId,
                    DriverId = newDriver.DriverId
                };

                await _driverSelectionRepository.AddAsync(newSelection);

                await _driverSelectionRepository.SaveChangesAsync();
                await transaction.CommitAsync();

                return Result<DriverSelectionDto>.Success(_mapper.Map<DriverSelectionDto>(newSelection));
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return Result<DriverSelectionDto>.Failure("An error occurred during the driver swap.");
            }
        }



    }
}
