using F1_Fantasy_API.Models.Dtos.UserDtos;
using F1_Fantasy_API.Services;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserDto>> GetUserByIdAsync(string id);

        Task<Result<IEnumerable<UserDto>>> GetUsersAsync();
    }
}
