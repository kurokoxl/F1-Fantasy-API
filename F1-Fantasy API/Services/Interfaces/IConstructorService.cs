using F1_Fantasy_API.Models.Dtos.ConstructorDtos;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IConstructorService
    {
        Task<Result<IEnumerable<ConstructorDto>>> GetConstructorsAsync();
        Task<Result<ConstructorDto>> GetConstructorByIdAsync(int id);
        Task<Result<ConstructorDto>> AddConstructorAsync(CreateConstructorDto createDto);
        Task<Result<ConstructorDto>> UpdateConstructorAsync(int id, UpdateConstructorDto updateDto);
        Task<Result<bool>> DeleteConstructor(int id);
    }
}
