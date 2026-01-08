using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;

namespace F1_Fantasy_API.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


}
