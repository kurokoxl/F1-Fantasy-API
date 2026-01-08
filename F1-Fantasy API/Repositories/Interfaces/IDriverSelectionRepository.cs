using F1_Fantasy_API.Models.Entites;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public interface IDriverSelectionRepository : IRepository<DriverSelection>
    {
        Task<Team> CheckTeam(string userId);
        Task<int> CountTeam(Team team);
    }
}