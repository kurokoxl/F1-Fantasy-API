using F1_Fantasy_API.Models.Entites;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public interface IConstructorRepository : IRepository<Constructor>
    {
        Task<bool> CheckName(string name, int? constructorId = null);
        Task<int> CheckNumber();
        Task<bool> CheckDrivers(int constructorId);
    }
}
