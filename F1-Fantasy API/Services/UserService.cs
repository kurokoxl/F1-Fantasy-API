using AutoMapper;
using F1_Fantasy_API.Models.Dtos.UserDtos;
using F1_Fantasy_API.Repositories;
using F1_Fantasy_API.Repositories.Interfaces;
using F1_Fantasy_API.Services.Interfaces;

namespace F1_Fantasy_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Result<UserDto>> GetUserByIdAsync(string id)
        {

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return Result<UserDto>.Failure($"User with ID {id} was not found.");
            }

            return Result<UserDto>.Success(_mapper.Map<UserDto>(user));
        }

        public async Task<Result<IEnumerable<UserDto>>> GetUsersAsync()
        {
            return Result<IEnumerable<UserDto>>
                             .Success(
                                 _mapper.Map<IEnumerable<UserDto>>
                                 (await _userRepository.GetAllAsync()));
        }
    }
}
