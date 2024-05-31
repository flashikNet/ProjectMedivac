using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class TeamsController : BaseApiController
{
    private readonly ITeamsRepository _teamsRepository;

    public TeamsController(ITeamsRepository teamsRepository)
    {
        _teamsRepository = teamsRepository;
    }

    [HttpPost("createTeam")]
    public async Task<ActionResult<Team>> CreateTeam([FromBody] Team team)
    {
        var teamModel = await _teamsRepository.CreateTeam(team);
        return teamModel;
    }

    [HttpGet("teams")]
    public async Task<List<Team>> GetAllTeams()
    {
        var teams = await _teamsRepository.GetAllTeams();
        return teams;
    }
}