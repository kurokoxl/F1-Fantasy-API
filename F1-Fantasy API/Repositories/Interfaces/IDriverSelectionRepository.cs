using F1_Fantasy_API.Models.Entites;
using Microsoft.EntityFrameworkCore.Storage;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public interface IDriverSelectionRepository : IRepository<DriverSelection>
    {
        Task<DriverSelection?> GetByIdAsync(int teamId, int driverId);
        Task<IEnumerable<DriverSelection>> GetAllAsync(int teamId);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}