using Microsoft.AspNetCore.Mvc;
using F1_Fantasy_API.Services.Interfaces;
using F1_Fantasy_API.Models.Dtos.RaceDtos;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [HttpPost]
        public async Task<IActionResult> AddRace([FromBody]CreateRaceDto createDto)
        {
            var result = await _raceService.AddRaceAsync(createDto);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return CreatedSuccess<RaceDto>(nameof(GetRace),new { id = result.Value.RaceId },result.Value,"Successfully created new race");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRace(int id,[FromBody]UpdateRaceDto updateDto)
        {
            var result = await _raceService.UpdateRaceAsync(id, updateDto);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return Success<RaceDto>(result.Value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var result = await _raceService.DeleteRace(id);
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            return Success<bool>(result.Value,"Deleted successfully");
        }
    }
}
