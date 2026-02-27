using F1_Fantasy_API.Models.Dtos.RaceDtos;
using F1_Fantasy_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace F1_Fantasy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : BaseApiController
    {
        private readonly IRaceService _raceService;
        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRaces()
        {
            var result = await _raceService.GetRacesAsync();
            if (!result.IsSuccess)
                return NotFoundError<RaceDto>(result.Error);
            return Success<IEnumerable<RaceDto>>(result.Value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRace(int id)
        {
            var result = await _raceService.GetRaceByIdAsync(id);
            if (!result.IsSuccess)
                return NotFoundError<RaceDto>(result.Error);
            return Success<RaceDto>(result.Value);
        }
        [HttpGet("NextRace")]
        public async Task<IActionResult> GetNextRace()
        {
            var result = await _raceService.GetNextOpenRace();
            if (!result.IsSuccess)
                return NotFoundError<RaceDto>(result.Error);
            return Success<RaceDto>(result.Value);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRace([FromBody]CreateRaceDto createDto)
        {
            var result = await _raceService.AddRaceAsync(createDto);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return CreatedSuccess<RaceDto>(nameof(GetRace),new { id = result.Value.RaceId },result.Value,"Successfully created new race");
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRace(int id,[FromBody]UpdateRaceDto updateDto)
        {
            var result = await _raceService.UpdateRaceAsync(id, updateDto);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return Success<RaceDto>(result.Value);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var result = await _raceService.DeleteRace(id);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return Success<bool>(result.Value,"Deleted successfully");
        }

    }
}
