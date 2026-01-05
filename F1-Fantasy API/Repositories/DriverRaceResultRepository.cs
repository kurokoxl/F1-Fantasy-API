using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace F1_Fantasy_API.Repositories
{
    public class DriverRaceResultRepository : Repository<DriverRaceResult>, IDriverRaceResultRepository
    {
        public DriverRaceResultRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<bool> CheckRaceComplete(int raceId)
        {
            var race = await _context.Races.FirstOrDefaultAsync(r => r.RaceId == raceId);
                
            if (race == null || DateTime.UtcNow < race.Date.ToUniversalTime())
            {
                    return false;
            }
            return true;
        }

        public async Task<DriverRaceResult> FindDriverResult(int driverId, int raceId)
        {
          return await _context.DriverRaceResults.FirstOrDefaultAsync(r => r.DriverId == driverId && r.RaceId == raceId);
        }
      
    }
}
