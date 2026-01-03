using AutoMapper;
using F1_Fantasy_API.Models.Dtos.DriverDtos;
using F1_Fantasy_API.Models.Entites;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;
using System.Transactions;

namespace F1_Fantasy_API.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<Result<DriverDto>> AddDriverAsync(CreateDriverDto createDto)
        {
            //Team is full
            var constructorDriversCount = await _driverRepository.GetCountByConstructorIdAsync(createDto.ConstructorId);
            if (constructorDriversCount >= 2)
                return Result<DriverDto>.Failure("Constructor team is full");

            var driver = _mapper.Map<Driver>(createDto);
            await _driverRepository.AddAsync(driver);

            bool isSaved = await _driverRepository.SaveChangesAsync();
            if (!isSaved)
                return Result<DriverDto>.Failure("Failed to save changes");
            return Result<DriverDto>.Success(_mapper.Map<DriverDto>(driver));
        }

        public async Task<Result<bool>> DeleteDriver(int id)
        {
            var driver = await _driverRepository.GetByIdAsync(id);
            if (driver == null)
                return Result<bool>.Failure("Driver doesn't exisit");

            _driverRepository.Delete(driver);

            bool isSaved = await _driverRepository.SaveChangesAsync();
            if (!isSaved)
                return Result<bool>.Failure("Failed to save changes");

            return Result<bool>.Success(true);
        }

        public async Task<Result<DriverDto>> GetDriverByIdAsync(int id)
        {
            return Result<DriverDto>
            .Success(_mapper.Map<DriverDto>
            (await _driverRepository.GetByIdAsync(id))
            );
        }

        public async Task<Result<IEnumerable<DriverDto>>> GetDriversAsync()
        {
            return Result<IEnumerable<DriverDto>>
            .Success(
                _mapper.Map<IEnumerable<DriverDto>>
                (await _driverRepository.GetAllAsync()));
        }

        public async Task<Result<DriverDto>> UpdateDriverAsync(int id, UpdateDriverDto updateDto)
        {
            if (id != updateDto.DriverId)
                return Result<DriverDto>.Failure("Id mismatch");
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {


                //get old driver from db
                var dbDriver = await _driverRepository.GetByIdAsync(id);
                if (dbDriver == null)
                    return Result<DriverDto>.Failure("Driver dosen't exsist");

                //update it
                var driver = _mapper.Map(updateDto, dbDriver);
                await _driverRepository.SaveChangesAsync();


                //count constructor team after update
                var constructorDriversCount = await _driverRepository.GetCountByConstructorIdAsync(updateDto.ConstructorId);
                if (constructorDriversCount > 2)
                    return Result<DriverDto>.Failure("Constructor team is full");

                //return result
                scope.Complete();
                var driverDto = _mapper.Map<DriverDto>(driver);
                return Result<DriverDto>.Success(driverDto);
            }

        }
    }
}
