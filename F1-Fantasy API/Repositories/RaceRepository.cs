using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace F1_Fantasy_API.Repositories
{
    public class RaceRepository : Repository<Race>, IRaceRepository
    {
        public RaceRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<Race> GetRaceWithDriverResult(int raceId)
        {
            return await _context.Races.Include(r => r.DriverRaceResults).FirstOrDefaultAsync(r=>r.RaceId==raceId);
        }

        public async Task<bool> ValidateRaceResults(int raceId)
        {
            if (await _context.DriverRaceResults.CountAsync(dr => dr.RaceId == raceId) != 20)
                return false;
            return true;
        }

        public async Task<bool> ValidateRaceStatus()
        {
            if (await _context.Races.AnyAsync(r => r.Status == Models.Entites.RaceStatus.Open))
            {
                return true;
            }
            return false;
        }
    }
}

