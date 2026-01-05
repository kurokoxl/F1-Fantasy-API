using AutoMapper;
using F1_Fantasy_API.Models.Dtos.ConstructorDtos;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;

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

        public Task<Result<bool>> DeleteConstructor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ConstructorDto>> GetConstructorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ConstructorDto>>> GetConstructorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<ConstructorDto>> UpdateConstructorAsync(int id, UpdateConstructorDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
