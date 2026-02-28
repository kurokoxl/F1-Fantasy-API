using F1_Fantasy_API.Models.Dtos.RaceResultsDto;
using F1_Fantasy_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1_Fantasy_API.Controllers;

public class DriverRaceResultController : BaseApiController
{
    private readonly IDriverRaceResultService _service;

    public DriverRaceResultController(IDriverRaceResultService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllResultsAsync();
        return Success(result.Value);
    }
    [HttpGet("{driverId}/{raceId}")]
    public async Task<IActionResult> GetById(int driverId, int raceId)
    {
        var result = await _service.GetResultByIdAsync(driverId, raceId);

        if (!result.IsSuccess)
            return NotFoundError<DriverRaceResultDto>(result.Error);

        return Success(result.Value);
    }
    [HttpGet("{raceId}")]
    public async Task<IActionResult> GetRaceResults(int raceId)
    {
        var result = await _service.GetAllRaceResults(raceId);
        return Success(result.Value);
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Upsert([FromBody] CreateDriverRaceResultDto createDto)
    {
        var result = await _service.UpsertDriverRaceResultAsync(createDto);

        if (!result.IsSuccess)
            return BadRequestError<DriverRaceResultDto>(result.Error);

        return CreatedSuccess(
            nameof(GetById),
            new { driverId = result.Value.DriverId, raceId = result.Value.RaceId },
            result.Value,
            "Race result processed successfully"
        );
    }

    [HttpPost("bulk")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpsertBulk([FromBody] CreateBulkRaceResultsDto bulkDto)
    {
        var result = await _service.UpsertBulkRaceResultsAsync(bulkDto);

        if (!result.IsSuccess)
            return BadRequestError<IEnumerable<DriverRaceResultDto>>(result.Error);

        return Success(result.Value, $"Successfully processed {result.Value.Count()} race results.");
    }

    [HttpPut("{driverId}/{raceId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int driverId, int raceId, [FromBody] CreateDriverRaceResultDto updateDto)
    {
        if (driverId != updateDto.DriverId || raceId != updateDto.RaceId)
        {
            return BadRequestError<DriverRaceResultDto>("URL IDs do not match the data provided.");
        }

        var result = await _service.UpsertDriverRaceResultAsync(updateDto);

        if (!result.IsSuccess)
            return BadRequestError<DriverRaceResultDto>(result.Error);

        return Success(result.Value, "Race result updated successfully");
    }

    [HttpDelete("{driverId}/{raceId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int driverId, int raceId)
    {
        var result = await _service.DeleteDriverRaceResult(driverId, raceId);

        if (!result.IsSuccess)
            return BadRequestError<bool>(result.Error);

        return Success(true, "Result deleted successfully");
    }
}
