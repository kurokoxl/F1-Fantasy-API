using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace F1_Fantasy_API.Repositories
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {

        public DriverRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> GetCountByConstructorIdAsync(int constructorId)
        {
            return await _context.Drivers.CountAsync(d => d.ConstructorId == constructorId);
        }


    }
}
