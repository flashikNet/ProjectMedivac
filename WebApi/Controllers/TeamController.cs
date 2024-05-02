using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles ="Captain")]
        public async Task<IActionResult> DeleteTeam()
        {
            var id = uint.Parse( User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _service.DeleteTeamAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> CreateTeam(CreateTeamReq req)
        {
            var id = uint.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var teamId = await _service.CreateTeamAsync(req, id);
            return Ok(teamId);
        }
    }
}
