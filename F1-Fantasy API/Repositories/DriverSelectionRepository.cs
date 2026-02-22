using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace F1_Fantasy_API.Repositories
{
    public class DriverSelectionRepository : Repository<DriverSelection>, IDriverSelectionRepository
    {
        public DriverSelectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<DriverSelection?> GetByIdAsync(int teamId, int driverId)
        {
            return await _context.DriverSelections
                .Include(ds => ds.Driver)
                .FirstOrDefaultAsync(r => r.TeamId == teamId && r.DriverId == driverId);
        }

        public async Task<IEnumerable<DriverSelection>> GetAllAsync(int teamId)
        {
            return await _context.DriverSelections.AsNoTracking()
                .Include(ds => ds.Driver)
                .Where(ds => ds.TeamId == teamId)
                .ToListAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
