using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace F1_Fantasy_API.Repositories
{
    public class DriverSelectionRepository : Repository<DriverSelection>, IDriverSelectionRepository
    {
        public DriverSelectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Team> CheckTeam(string userId)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.UserId == userId);
            return team;
        }

        public async Task<int> CountTeam(int teamId,string userId,int raceId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
