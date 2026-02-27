using F1_Fantasy_API.Models.Dtos.DriverSelectionDto;
using F1_Fantasy_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1_Fantasy_API.Controllers
{
    public class DriverSelectionController : BaseApiController
    {
        private readonly IDriverSelectionService _driverSelectionService;
        public DriverSelectionController(IDriverSelectionService driverSelectionService)
        {
            _driverSelectionService = driverSelectionService;
        }
        [HttpPost("Me")]
        [Authorize]
        public async Task<IActionResult> SelectDriver([FromBody] CreateDriverSelectionDto createDto)
        {
            var result = await _driverSelectionService.AddDriverSelectionAsync(createDto, UserId);
            if (!result.IsSuccess)
                return BadRequestError<DriverSelectionDto>(result.Error);
            return CreatedSuccess<DriverSelectionDto>(nameof(GetDriverById)
                , new { driverId = result.Value.DriverId },result.Value, "Created successfully");

        }
        //admin
        [HttpGet("Me")]
        [Authorize]
        public async Task<IActionResult> GetDrivers()
        {
            var result = await _driverSelectionService.GetDriverSelectionsAsync(UserId);
            if (!result.IsSuccess)
                return BadRequestError<DriverSelectionDto>(result.Error);

            return Success<IEnumerable<DriverSelectionDto>>(result.Value);
                
        }
        //user
        [HttpGet("Me/{driverId}")]
        [Authorize]
        public async Task<IActionResult> GetDriverById(int driverId)
        {
            var result = await _driverSelectionService.GetDriverSelectionByIdAsync(driverId, UserId);
            if (!result.IsSuccess)
                return BadRequestError<DriverSelectionDto>(result.Error);

            return Success<DriverSelectionDto>(result.Value);

        }
        [HttpDelete("Me/{driverId}")]
        [Authorize]
        public async Task<IActionResult> DeleteDriverSelection(int driverId)
        {
            var result = await _driverSelectionService.DeleteDriverSelection(driverId, UserId);
            if (!result.IsSuccess)
                return BadRequestError<DriverSelectionDto>(result.Error);

            return Success<bool>(result.Value,"Deleted Successfully");
        }
        [HttpPut("Me/{driverId}")]
        [Authorize]
        public async Task<IActionResult> UpdateDriver(int driverId,[FromBody] UpdateDriverSelectionDto updateDto)
        {
            var result = await _driverSelectionService.UpdateDriverSelectionAsync(driverId, updateDto, UserId);
            if (!result.IsSuccess)
                return BadRequestError<DriverSelectionDto>(result.Error);
            return CreatedSuccess<DriverSelectionDto>(nameof(GetDriverById)
                , new { driverId = result.Value.DriverId }, result.Value, "Created successfully");

        }

    }
}

