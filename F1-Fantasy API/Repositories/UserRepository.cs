using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<User?> GetByIdAsync(string id)
        {
            // We include the Team so the user can see their budget and drivers
            return await _context.Users
                .Include(u => u.Team)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

    }
}
