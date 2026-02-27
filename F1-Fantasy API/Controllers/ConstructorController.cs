using F1_Fantasy_API.Models.Dtos.ConstructorDtos;
using F1_Fantasy_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1_Fantasy_API.Controllers;

public class ConstructorController : BaseApiController
{
    private readonly IConstructorService _constructorService;

    public ConstructorController(IConstructorService constructorService)
    {
        _constructorService = constructorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _constructorService.GetConstructorsAsync();
        return Success(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _constructorService.GetConstructorByIdAsync(id);

        if (!result.IsSuccess)
            return NotFoundError<ConstructorDto>(result.Error);

        return Success(result.Value);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateConstructorDto createDto)
    {
        var result = await _constructorService.AddConstructorAsync(createDto);

        if (!result.IsSuccess)
            return BadRequestError<ConstructorDto>(result.Error);

        return CreatedSuccess(
            nameof(GetById),
            new { id = result.Value.ConstructorId },
            result.Value,
            "Constructor created successfully."
        );
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateConstructorDto updateDto)
    {
        var result = await _constructorService.UpdateConstructorAsync(id, updateDto);

        if (!result.IsSuccess)
            return BadRequestError<ConstructorDto>(result.Error);

        return Success(result.Value, "Constructor updated successfully.");
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _constructorService.DeleteConstructor(id);

        if (!result.IsSuccess)
            return BadRequestError<bool>(result.Error);

        return Success(true, "Constructor deleted successfully.");
    }
}