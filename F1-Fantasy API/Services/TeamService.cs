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

        public TeamService(ITeamRepository teamRepository, IMapper mapper,IRaceRepository raceRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _raceRepository = raceRepository;
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


    }
}
