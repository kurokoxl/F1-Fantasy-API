using F1_Fantasy_API.Models.DTOs.AuthDtos;

namespace F1_Fantasy_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto model);
        Task<AuthResponseDto> LoginAsync(LoginDto model);
    }
}
