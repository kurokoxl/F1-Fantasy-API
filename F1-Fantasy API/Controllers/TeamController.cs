using F1_Fantasy_API.Models.Dtos.TeamDtos;
using F1_Fantasy_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1_Fantasy_API.Controllers
{
    public class TeamController : BaseApiController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var result = await _teamService.GetTeamsAsync();

            if (!result.IsSuccess)
                return BadRequestError<IEnumerable<TeamDto>>(result.Error);

            return Success(result.Value);
        }
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMyTeam()
        {
            var result = await _teamService.GetMyTeam(UserId);

            if (!result.IsSuccess)
                return BadRequestError<IEnumerable<TeamDto>>(result.Error);

            return Success(result.Value);
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var result = await _teamService.GetTeamByIdAsync(id);

            if (!result.IsSuccess)
                return NotFoundError<TeamDto>(result.Error);

            return Success(result.Value);
        }

        // PUT: api/Team/5
        [Authorize] 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamDto updateDto)
        {

            var result = await _teamService.UpdateTeamAsync(UserId, updateDto);

            if (!result.IsSuccess)
                return BadRequestError<TeamDto>(result.Error);

            return Success(result.Value, "Team updated successfully");
        }
        [HttpGet("Leaderboard")]
        public async Task<IActionResult> GetLeaderBoard([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _teamService.GetLeaderboardAsnyc(pageNumber, pageSize);

            if (!result.IsSuccess)
                return BadRequestError<TeamDto>(result.Error);

            // Unpack the tuple values
            var (teams, totalCount) = result.Value;

            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            Response.Headers.Add("X-Page-Number", pageNumber.ToString());

            return Success(teams);
        }
    }
}