using AutoMapper;
using F1_Fantasy_API.Models.Dtos.DriverSelectionDto;
using F1_Fantasy_API.Models.Dtos.TeamDtos;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;

namespace F1_Fantasy_API.Services
{
    public class TeamService : ITeamService
    {

        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IRaceRepository _raceRepository;
        private readonly IConstructorRepository _constructoRepository;

        public TeamService(ITeamRepository teamRepository, IMapper mapper,IRaceRepository raceRepository, IConstructorRepository constructorRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _raceRepository = raceRepository;
            _constructoRepository = constructorRepository;
        }

        public async Task<Result<TeamDto>> GetTeamByIdAsync(int id)
        {
            var team =await _teamRepository.GetByIdAsync(id);

            if (team == null)
                return Result<TeamDto>.Failure("Team doesn't exisit");


            return Result<TeamDto>.Success(_mapper.Map<TeamDto>(team));
        }
        public async Task<Result<TeamDto>> GetMyTeam (string UserId)
        {
            var team = await _teamRepository.GetTeamByUserIdAsync(UserId);

            if (team == null)
                return Result<TeamDto>.Failure("Team doesn't exisit");


            return Result<TeamDto>.Success(_mapper.Map<TeamDto>(team));
        }
        public async Task<Result<IEnumerable<TeamDto>>> GetTeamsAsync()
        {
            var teams = await _teamRepository.GetAllAsync();

            if (teams == null)
                return Result<IEnumerable<TeamDto>>.Failure("No teams yet");


            return Result<IEnumerable<TeamDto>>.Success(_mapper.Map<IEnumerable<TeamDto>>(teams));
        }


        public async Task<Result<TeamDto>> UpdateTeamAsync(string userId, UpdateTeamDto updateDto)
        {
            if (await _raceRepository.ValidateRaceStatus() == false)
            {
                return Result<TeamDto>.Failure("Can't modify the team while all races are locked please check races list");
            }
            var team = await _teamRepository.GetTeamByUserIdAsync(userId);

            if (team == null)
                return Result<TeamDto>.Failure("Team doesn't exisit");

            _mapper.Map(updateDto, team);
            await _teamRepository.SaveChangesAsync();

            return Result<TeamDto>.Success(_mapper.Map<TeamDto>(team));
        }
        //public async void CalculateTeamPoints(int raceId)
        //{

        //   var race = await _raceRepository.GetByIdAsync(raceId);//include teams
        //    //include?
        //    var teams = await _teamRepository.GetAllAsync();//incudes all
        //    foreach(var team in teams)
        //    {
        //        //get driver race result
        //        foreach (var selection in team.DriverSelections)
        //        {
        //           var raceResult=race.DriverRaceResults.FirstOrDefault(drs=>drs.DriverId==selection.DriverId);
        //           team.TotalPoints += raceResult.Points;
        //        }
        //        var constructor = await _constructoRepository.GetByIdAsync(team.ConstructorId);
        //        foreach (var driver in constructor.Drivers)
        //        {
        //            var raceResult = race.DriverRaceResults.FirstOrDefault(drs => drs.DriverId == driver.DriverId);

        //            team.TotalPoints += raceResult.Points;
        //        }
        //    }
        //    return;
        //}
        public async Task CalculateTeamPoints(int raceId)
        {
            var race = await _raceRepository.GetRaceWithDriverResult(raceId);
            //if (race == null || race.DriverRaceResults == null) return;

            var resultsLookup = race.DriverRaceResults
                .ToDictionary(r => r.DriverId, r => r.Points);

            var teams = await _teamRepository.GetAllAsync();

            foreach (var team in teams)
            {
                int pointsGained = 0;

                foreach (var selection in team.DriverSelections)
                {
                    if (resultsLookup.TryGetValue(selection.DriverId, out int p))
                        pointsGained += p;
                }

                if (team.Constructor != null)
                {
                    foreach (var driver in team.Constructor.Drivers)
                    {
                        if (resultsLookup.TryGetValue(driver.DriverId, out int cp))
                            pointsGained += cp;
                    }
                }

                team.TotalPoints += pointsGained;
            }

            // 3. Save all team point updates in one batch
            await _teamRepository.SaveChangesAsync();
        }
    }
}
