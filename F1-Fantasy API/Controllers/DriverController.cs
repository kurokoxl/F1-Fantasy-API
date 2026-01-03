using F1_Fantasy_API.Models.Dtos.DriverDtos;
using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Services;
using F1_Fantasy_API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace F1_Fantasy_API.Controllers
{
    public class DriverController : BaseApiController
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDrivers()
        {
            var result =await _driverService.GetDriversAsync();
            if (!result.IsSuccess)
                return NotFoundError<RaceDto>(result.Error);
            return Success<IEnumerable<DriverDto>>(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            var result = await _driverService.GetDriverByIdAsync(id);
            if (!result.IsSuccess)
                return NotFoundError<RaceDto>(result.Error);
            return Success<DriverDto>(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody]CreateDriverDto createDto)
        {
            var result = await _driverService.AddDriverAsync(createDto);
            if(!result.IsSuccess)
                return BadRequest(result.Error);
            return CreatedSuccess<DriverDto>(nameof(GetDriverById), new { id = result.Value.DriverId }, result.Value, "Created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id ,[FromBody]UpdateDriverDto updateDto)
        {
            var result = await _driverService.UpdateDriverAsync(id,updateDto);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return Success<DriverDto>(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var result = await _driverService.DeleteDriver(id);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return Success<bool>(result.Value);
        }
    }
}
