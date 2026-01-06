using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;

namespace F1_Fantasy_API.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(string id);

    }
}
