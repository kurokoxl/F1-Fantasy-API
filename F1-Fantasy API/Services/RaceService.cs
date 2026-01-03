using AutoMapper;
using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services;
using Microsoft.VisualStudio.Services.TestManagement.TestPlanning.WebApi;
using System.Collections.Generic;

internal class RaceService : IRaceService
{
    private readonly IRaceRepository _raceRepository;
    private readonly IMapper _mapper;
    public RaceService(IRaceRepository raceRepository, IMapper mapper)
    {
        _raceRepository = raceRepository;
        _mapper = mapper;
    }
    public async Task<Result<RaceDto>> AddRaceAsync(CreateRaceDto createDto)
    {
        var validation = await ValidateRaceLogicAsync(createDto.Season,createDto.Date);
        if (!validation.IsSuccess) return Result<RaceDto>.Failure(validation.Error);

        var race = _mapper.Map<Race>(createDto);
        await _raceRepository.AddAsync(race);

        bool isSaved = await _raceRepository.SaveChangesAsync();
        if (!isSaved)
            return Result<RaceDto>.Failure("Failed to save changes");

        return Result<RaceDto>.Success(_mapper.Map<RaceDto>(race));

    }

    public async Task<Result<bool>> DeleteRace(int id)
    {
        var race = await _raceRepository.GetByIdAsync(id);
        if (race == null)
            return Result<bool>.Failure("Race doesn't exisit");

         _raceRepository.Delete(race);

         bool isSaved = await _raceRepository.SaveChangesAsync();
        if (!isSaved)
            return Result<bool>.Failure("Failed to save changes");

        return Result<bool>.Success(true);
    }

    public async Task<Result<RaceDto>> GetRaceByIdAsync(int id)
    {
        return Result<RaceDto>
            .Success(_mapper.Map<RaceDto>
            (await _raceRepository.GetByIdAsync(id))
            );
    }

    public async Task<Result<IEnumerable<RaceDto>>> GetRacesAsync()
    {
        return Result<IEnumerable<RaceDto>>
            .Success(_mapper.Map<
                IEnumerable<RaceDto>>(await _raceRepository.GetAllAsync())
                );
    }

    public async Task<Result<RaceDto>> UpdateRaceAsync(int id,UpdateRaceDto updateDto)
    {
        //validate

        if (id != updateDto.RaceId)
            return Result<RaceDto>.Failure("Id mismatch");

        var validation = await ValidateRaceLogicAsync(updateDto.Season, updateDto.Date);
        if (!validation.IsSuccess) return Result<RaceDto>.Failure(validation.Error);

        //get old race from db
        var dbrace = await _raceRepository.GetByIdAsync(id);
        if (dbrace == null)
            return Result<RaceDto>.Failure("Race dosen't exsist");

        //update it
        var race = _mapper.Map(updateDto, dbrace);
        bool isSaved = await _raceRepository.SaveChangesAsync();
        if (!isSaved)
            return Result<RaceDto>.Failure("Failed to save changes");

        //return result
        var racedto = _mapper.Map<RaceDto>(race);
        return Result<RaceDto>.Success(racedto);
    }

    private async Task<Result<bool>> ValidateRaceLogicAsync(int season, DateTime raceDate, int? excludeRaceId = null)
    {
        // 1. Year Integrity
        if (raceDate.Year != season)
        {
            return Result<bool>.Failure($"Year Mismatch: Season is {season} but Date is {raceDate.Year}.");
        }

        // 2. Future Date (Based on current time: 2026)
        if (raceDate < DateTime.UtcNow)
        {
            return Result<bool>.Failure("Timeline Error: Race date must be in the future.");
        }

        // 3. Duplicate Date Check
        var races = await _raceRepository.GetAllAsync();
        bool dateExists = races.Any(r => r.Date.Date == raceDate.Date && r.RaceId != excludeRaceId);

        if (dateExists)
        {
            return Result<bool>.Failure($"Schedule Conflict: A race already exists on {raceDate.ToShortDateString()}.");
        }

        return Result<bool>.Success(true);
    }
}