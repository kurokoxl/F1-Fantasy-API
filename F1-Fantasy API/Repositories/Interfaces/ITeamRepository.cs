using F1_Fantasy_API.Models.Entites;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team?> GetTeamByUserIdAsync(string userId);
        Task<Team?> GetByIdAsync(int id);
        Task<IEnumerable<Team>> GetAllAsync();
        Task<(IEnumerable<Team> Items, int TotalCount)> GetLeaderboardAsync(int pageNumber, int pageSize);
    }
}
