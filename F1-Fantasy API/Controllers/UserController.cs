using F1_Fantasy_API.Models.Dtos.UserDtos;
using F1_Fantasy_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1_Fantasy_API.Controllers;

[Authorize]
public class UserController : BaseApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetUsersAsync();
        return Success(result.Value);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _userService.GetUserByIdAsync(id);

        if (!result.IsSuccess)
            return NotFoundError<UserDto>(result.Error);

        return Success(result.Value);
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMyProfile()
    {
        if (string.IsNullOrEmpty(UserId))
            return BadRequestError<UserDto>("User not identified.");

        var result = await _userService.GetUserByIdAsync(UserId);

        if (!result.IsSuccess)
            return NotFoundError<UserDto>(result.Error);

        return Success(result.Value);
    }
}