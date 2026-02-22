using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace F1_Fantasy_API.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }

        private IQueryable<Team> GetTeamQuery() =>
            _context.Teams
            .Include(t => t.Constructor)
                .Include(t => t.DriverSelections)
                .ThenInclude(ds => ds.Driver);

        public async Task<Team?> GetTeamByUserIdAsync(string userId) =>
            await GetTeamQuery().FirstOrDefaultAsync(t => t.UserId == userId);

        public  async Task<Team?> GetByIdAsync(int id) =>
            await GetTeamQuery().FirstOrDefaultAsync(t => t.TeamId == id);

        public  async Task<IEnumerable<Team>> GetAllAsync() =>
            await GetTeamQuery().ToListAsync();
    }
}
