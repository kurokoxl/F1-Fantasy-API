using F1_Fantasy_API.Models.Entites;

namespace F1_Fantasy_API.Repositories.Interfaces
{
    public interface IRaceRepository : IRepository<Race>
    {
        //
        Task<bool> ValidateRaceStatus();
        Task<bool> ValidateRaceResults(int raceId);
        Task<Race> GetRaceWithDriverResult(int RaceId);
        Task<Race> GetNextOpenRace();
    }
}
