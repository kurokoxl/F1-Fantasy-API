using AutoMapper;
using F1_Fantasy_API.Models.Dtos.ConstructorDtos;
using F1_Fantasy_API.Models.Dtos.DriverDtos;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace F1_Fantasy_API.Services
{
    public class ConstructorService : IConstructorService
    {
        private readonly IConstructorRepository _constructorRepository;
        private readonly IMapper _mapper;
        public ConstructorService(IConstructorRepository constructorRepository,IMapper mapper)
        {
            _constructorRepository = constructorRepository;
            _mapper = mapper;
        }
        public async Task<Result<ConstructorDto>> AddConstructorAsync(CreateConstructorDto createDto)
        {
            //validate
            if (await _constructorRepository.CheckNumber() >=10)
            {
                return Result<ConstructorDto>.Failure("F1 Grid is full, Max 10 Teams.");
            }
            if (await _constructorRepository.CheckName(createDto.Name))
            {
                return Result<ConstructorDto>.Failure("A team with this name already exists.");
            }

            //else create 
            var constructor = _mapper.Map<Constructor>(createDto);
            await _constructorRepository.AddAsync(constructor);
            await _constructorRepository.SaveChangesAsync();

            return Result<ConstructorDto>.Success(_mapper.Map<ConstructorDto>(constructor));
        }
        public async Task<Result<bool>> DeleteConstructor(int id)
        {
            if (await _constructorRepository.CheckDrivers(id))
            {
                return Result<bool>.Failure("Can't delete constructor while there are drivers assigned to it.");
            }

            var constructor = await _constructorRepository.GetByIdAsync(id);
            if (constructor == null) return Result<bool>.Failure("Not found.");

            _constructorRepository.Delete(constructor);
            await _constructorRepository.SaveChangesAsync();

            return Result<bool>.Success(true);
        }

        public async Task<Result<ConstructorDto>> GetConstructorByIdAsync(int id)
        {
            var constructor = await _constructorRepository.GetByIdAsync(id);

            if (constructor == null)
            {
                return Result<ConstructorDto>.Failure($"Constructor with ID {id} was not found.");
            }

            return Result<ConstructorDto>.Success(_mapper.Map<ConstructorDto>(constructor));
        }

        public async Task<Result<IEnumerable<ConstructorDto>>> GetConstructorsAsync()
        {
            return Result<IEnumerable<ConstructorDto>>
                      .Success(
                          _mapper.Map<IEnumerable<ConstructorDto>>
                          (await _constructorRepository.GetAllAsync()));
        }

        public async Task<Result<ConstructorDto>> UpdateConstructorAsync(int id, UpdateConstructorDto updateDto)
        {
            if (updateDto.ConstructorId != id)
            {
                return Result<ConstructorDto>.Failure("Id mismatch");
            }
            if (await _constructorRepository.CheckName(updateDto.Name,updateDto.ConstructorId))
            {
                return Result<ConstructorDto>.Failure("A team with this name already exists.");
            }

            var constructor = await _constructorRepository.GetByIdAsync(id);
            _mapper.Map(updateDto, constructor);
            await _constructorRepository.SaveChangesAsync();

            return Result<ConstructorDto>.Success(_mapper.Map<ConstructorDto>(constructor));
        }
    }
}
