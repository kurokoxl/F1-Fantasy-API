using F1_Fantasy_API.Models.Dtos.TeamDtos;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface ITeamService
    {
        Task<Result<IEnumerable<TeamDto>>> GetTeamsAsync();
        Task<Result<TeamDto>> GetTeamByIdAsync(int id);
        Task<Result<TeamDto>> GetMyTeam(string userId);

        Task<Result<TeamDto>> UpdateTeamAsync(string userId, UpdateTeamDto updateDto);

        //Task<Result<TeamDto>> AddTeamAsync(CreateTeamDto createDto);

        //Task<Result<bool>> DeleteTeam(int id);
    }
}
