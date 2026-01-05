using F1_Fantasy_API.Models.Entites;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public interface IDriverRaceResultRepository : IRepository<DriverRaceResult>
    {
        Task<DriverRaceResult> FindDriverResult(int driverId, int raceId);
        Task<bool> CheckRaceComplete(int raceId);
    }
}
