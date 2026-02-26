using AutoMapper;
using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;

namespace F1_Fantasy_API.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository _raceRepository;

        private readonly IMapper _mapper;
        private readonly ITeamService _teamService;
        public RaceService(IRaceRepository raceRepository, ITeamService teamService, IMapper mapper)
        {
            _raceRepository = raceRepository;
            _teamService = teamService;
            _mapper = mapper;
        }
        public async Task<Result<RaceDto>> AddRaceAsync(CreateRaceDto createDto)
        {
            var validation = await ValidateRaceLogicAsync(createDto.Season, RaceStatus.Locked, createDto.Date);
            if (!validation.IsSuccess) return Result<RaceDto>.Failure(validation.Error);

            var race = _mapper.Map<Race>(createDto);
            race.Status = RaceStatus.Locked;
            await _raceRepository.AddAsync(race);

            bool isSaved = await _raceRepository.SaveChangesAsync();
            if (!isSaved)
                return Result<RaceDto>.Failure("Failed to save changes");

            return Result<RaceDto>.Success(_mapper.Map<RaceDto>(race));

        }

        public async Task<Result<bool>> DeleteRace(int id)
        {
            var race = await _raceRepository.GetByIdAsync(id);
            if (race == null)
                return Result<bool>.Failure("Race doesn't exisit");

            _raceRepository.Delete(race);

            bool isSaved = await _raceRepository.SaveChangesAsync();
            if (!isSaved)
                return Result<bool>.Failure("Failed to save changes");

            return Result<bool>.Success(true);
        }

        public async Task<Result<RaceDto>> GetRaceByIdAsync(int id)
        {
            var race = await _raceRepository.GetByIdAsync(id);

            // 2. Explicit check for existence
            if (race == null)
            {
                return Result<RaceDto>.Failure($"Race with ID {id} was not found.");
            }

            return Result<RaceDto>.Success(_mapper.Map<RaceDto>(race));
        }

        public async Task<Result<IEnumerable<RaceDto>>> GetRacesAsync()
        {
            return Result<IEnumerable<RaceDto>>
                .Success(_mapper.Map<
                    IEnumerable<RaceDto>>(await _raceRepository.GetAllAsync())
                    );
        }

        public async Task<Result<RaceDto>> UpdateRaceAsync(int raceId, UpdateRaceDto updateDto)
        {
            //validate
            //get old race from db
            var dbrace = await _raceRepository.GetByIdAsync(raceId);
            if (dbrace == null)
                return Result<RaceDto>.Failure("Race dosen't exsist");

            if (raceId != updateDto.RaceId)
                return Result<RaceDto>.Failure("Id mismatch");

            var validation = await ValidateRaceLogicAsync(updateDto.Season, updateDto.Status, updateDto.Date, updateDto.RaceId);
            if (!validation.IsSuccess) 
                return Result<RaceDto>.Failure(validation.Error);

            //Validate race results 
            if (updateDto.Status == RaceStatus.Finished && !await _raceRepository.ValidateRaceResults(raceId))
                return Result<RaceDto>.Failure("Race results are incomplete");

            if (updateDto.Status == RaceStatus.Scored)
            {
                if (dbrace.Status != RaceStatus.Finished)
                    return Result<RaceDto>.Failure("Race isn't finished yet");
                await _teamService.CalculateTeamPoints(raceId);
            }
               

          

            //update it
            var race = _mapper.Map(updateDto, dbrace);
            await _raceRepository.SaveChangesAsync();
           

            //return result
            var racedto = _mapper.Map<RaceDto>(race);
            return Result<RaceDto>.Success(racedto);
        }
        private async Task<Result<bool>> ValidateRaceLogicAsync(int season, RaceStatus raceStatus, DateTime raceDate, int? excludeRaceId = null)
        {
            // 1. Year Integrity
            if (raceDate.Year != season)
            {
                return Result<bool>.Failure($"Year Mismatch: Season is {season} but Date is {raceDate.Year}.");
            }

            // 2. Future Date Check - Only for NEW races, not updates
            if (excludeRaceId == null && raceDate.Date < DateTime.UtcNow.Date)
            {
                return Result<bool>.Failure("Timeline Error: Race date must be in the future.");
            }

            // 3. Get all races for validation
            var races = await _raceRepository.GetAllAsync();

            // 4. Duplicate Date Check
            bool dateExists = races.Any(r => r.Date.Date == raceDate.Date && r.RaceId != excludeRaceId);
            if (dateExists)
            {
                return Result<bool>.Failure($"Schedule Conflict: A race already exists on {raceDate.ToShortDateString()}.");
            }

            // 5. Check race status - Only one race can be Open at a time
            if (raceStatus == RaceStatus.Open && races.Any(r => r.Status == RaceStatus.Open && r.RaceId != excludeRaceId))
            {
                return Result<bool>.Failure("There's already an open race. Only one race can be open at a time.");
            }

            return Result<bool>.Success(true);
        }

    }
}