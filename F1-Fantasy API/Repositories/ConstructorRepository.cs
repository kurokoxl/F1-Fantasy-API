using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Dtos.ConstructorDtos;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.TeamFoundation.Common;

namespace F1_Fantasy_API.Repositories
{
    public class ConstructorRepository : Repository<Constructor>, IConstructorRepository
    {
        public ConstructorRepository(ApplicationDbContext context) : base(context)
        {
     
        }

        public async Task<bool> CheckName(string name, int? constructorId = null)
        {
            return await _context.Constructors
                .AnyAsync(c => c.Name == name && (constructorId == null || c.ConstructorId != constructorId));
        }

        public async Task<int> CheckNumber()
        {
          return await _context.Constructors.CountAsync();
        }
        public async Task<bool> CheckDrivers(int constructorId)
        {
           return await _context.Drivers
                .AnyAsync(d => d.ConstructorId == constructorId);
        }
    }
}
