using AutoMapper;
using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Models.Dtos.RaceResultsDto;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;
using System.Diagnostics;

namespace F1_Fantasy_API.Services
{
    public class DriverRaceResultService : IDriverRaceResultRaceResultService
    {
        private readonly IDriverRaceResultRepository _driverResultRepositroy;
        private readonly IMapper _mapper;
        private static readonly Dictionary<int, int> PositionPoints = new()
            {
                { 1, 25 }, { 2, 18 }, { 3, 15 }, { 4, 12 }, { 5, 10 },
                { 6, 8 },  { 7, 6 },  { 8, 4 },  { 9, 2 },  { 10, 1 }
            };
        public DriverRaceResultService(IDriverRaceResultRepository driverRaceResultRepository, IMapper mapper)
        {
            _driverResultRepositroy = driverRaceResultRepository;
            _mapper = mapper;
        }

        public async Task<Result<DriverRaceResultDto>> UpsertDriverRaceResultAsync(CreateDriverRaceResultDto createDto)
        {
            //check if the race is finished yet
            if (await _driverResultRepositroy.CheckRaceInProgress(createDto.RaceId) == false)
                return Result<DriverRaceResultDto>.Failure("Race not in progress yet or doesn't exisist");

             bool isPositionTaken = await _driverResultRepositroy.AnyAsync(r =>
                r.RaceId == createDto.RaceId &&
                r.Position == createDto.Position &&
                r.DriverId != createDto.DriverId);

            if (isPositionTaken)
            {
                return Result<DriverRaceResultDto>.Failure($"Position {createDto.Position} is already assigned to another driver in this race.");
            }

            int points = PositionPoints.TryGetValue
            (createDto.Position, out int basePoints) ? basePoints : 0;

            var existingResult = await _driverResultRepositroy.FindDriverResult(createDto.DriverId, createDto.RaceId);

            //if exists: update
            if (existingResult != null)
            {
                _mapper.Map(createDto, existingResult);
                existingResult.Points = points;
            }
            //if doesn't exist: create
            else
            {
                existingResult = _mapper.Map<DriverRaceResult>(createDto);
                existingResult.Points = points;
                await _driverResultRepositroy.AddAsync(existingResult);
            }

            await _driverResultRepositroy.SaveChangesAsync();
            
           //map then return success
            return Result<DriverRaceResultDto>.Success
                (_mapper.Map<DriverRaceResultDto>(existingResult));

        }

        public async Task<Result<bool>> DeleteDriverRaceResult(int driverId,int raceId)
        {
            var DriverResult = await _driverResultRepositroy.FindDriverResult(driverId, raceId);
            if (DriverResult == null)
                return Result<bool>.Failure("Driver's Race result doesn't exist");

            _driverResultRepositroy.Delete(DriverResult);
            await _driverResultRepositroy.SaveChangesAsync();

            return Result<bool>.Success(true);
        }

        public async Task<Result<DriverRaceResultDto>> GetResultByIdAsync(int driverId,int raceId)
        {
            var driverResult = await _driverResultRepositroy.FindDriverResult(driverId, raceId);

            if (driverResult == null)
                return Result<DriverRaceResultDto>.Failure("Driver's race result doesn't exist");

            return Result<DriverRaceResultDto>.Success
                (_mapper.Map<DriverRaceResultDto>(driverResult));
        }

        public async Task<Result<IEnumerable<DriverRaceResultDto>>> GetAllResultsAsync()
        {
            return Result<IEnumerable<DriverRaceResultDto>>
                        .Success(_mapper.Map<
                            IEnumerable<DriverRaceResultDto>>(await _driverResultRepositroy.GetAllAsync())
                        );
        }

        public async Task<Result<IEnumerable<DriverRaceResultDto>>> GetAllRaceResults(int raceId)
        {
            return Result<IEnumerable<DriverRaceResultDto>>
                  .Success(_mapper.Map<
                      IEnumerable<DriverRaceResultDto>>(await _driverResultRepositroy.GetAllRaceResults(raceId))
                  );
        }
    }
}
