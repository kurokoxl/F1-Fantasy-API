using AutoMapper;
using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Repositories.Interfaces;

internal class RaceService : IRaceService
{
    private readonly IRaceRepository _raceRepository;
    private readonly IMapper _mapper;
    public Task<RaceDto?> AddRaceAsync(CreateRaceDto createDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRace(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RaceDto?> GetRaceByIdAsync(int id)
    {
        return _mapper.Map<RaceDto>(await _raceRepository.GetByIdAsync(id));
    }

    public async Task<IEnumerable<RaceDto>> GetRacesAsync()
    {
        return _mapper.Map<IEnumerable<RaceDto>>(await _raceRepository.GetAllAsync());
    }

    public Task<RaceDto?> UpdateRaceAsync(int id,UpdateRaceDto updateDto)
    {
        if (id != updateDto.RaceId)
            throw 
    }
}