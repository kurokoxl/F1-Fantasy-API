using F1_Fantasy_API.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public interface IDriverRepository : IRepository<Driver>
    {
        Task<int> GetCountByConstructorIdAsync(int constructorId);
    }
}
