using F1_Fantasy_API.Data;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;

namespace F1_Fantasy_API.Repositories
{
    public class DriverRaceResultRepository : Repository<DriverRaceResult>, IDriverRaceResultRepository
    {
        public DriverRaceResultRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
