using F1_Fantasy_API.Models.Entites;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(string id);

    }
}
