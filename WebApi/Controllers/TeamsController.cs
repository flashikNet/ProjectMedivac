using System.Security.Claims;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class TeamsController : BaseApiController
{
    private readonly ITeamsRepository _teamsRepository;
    private readonly IUsersRepository _usersRepository;

    public TeamsController(ITeamsRepository teamsRepository, IUsersRepository usersRepository)
    {
        _teamsRepository = teamsRepository;
        _usersRepository = usersRepository;
    }

    [HttpPost("teams/createTeam")]
    public async Task<ActionResult<Team>> CreateTeam([FromBody] Team team)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized("User not found");
        }
    
        var user = await _usersRepository.GetUserByIdAsync(Guid.Parse(userId));
        if (user == null)
        {
            return Unauthorized("User not found.");
        }
        
        var teamModel = await _teamsRepository.CreateTeam(team);
        
        var updateTeamResult = await _usersRepository.UpdateUserTeam(Guid.Parse(userId), teamModel);
        if (!updateTeamResult)
        {
            return StatusCode(500, "Failed to update user's team.");
        }
        
        var updatedUser = await _usersRepository.ReturnUpdatedUserRoleAsync(user.Id, Roles.Captain);
        if (updatedUser == null)
        {
            return StatusCode(500, "Failed to update user's role.");
        }
        
        teamModel.Members ??= new List<User>();
        teamModel.Members.Add(updatedUser);
        
        var updateTeamMembersResult = await _teamsRepository.UpdateTeamMembers(teamModel.Id, teamModel.Members);
        if (!updateTeamMembersResult)
        {
            return StatusCode(500, "Failed to update team members.");
        }
    
        return CreatedAtAction(nameof(GetTeamById), new { id = teamModel.Id }, teamModel);
    }


    [HttpGet("teams")]
    public async Task<List<Team>> GetAllTeams()
    {
        var teams = await _teamsRepository.GetAllTeams();
        return teams;
    }

    [HttpGet("teams/{id}")]
    public async Task<ActionResult<Team>> GetTeamById(Guid id)
    {
        var team = await _teamsRepository.GetTeamById(id);
        
        if (team == null)
        {
            return NotFound("Team not found.");
        }

        return team;
    }

    [HttpPost("teams/invite")]
    public async Task<ActionResult> InviteUser([FromBody] Guid inviteeId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized("User not found.");
        }

        var captain = await _usersRepository.GetUserByIdAsync(Guid.Parse(userId));
        if (captain == null || captain.Role != Roles.Captain || captain.Team == null)
        {
            return Unauthorized("User is not a captain of a team.");
        }

        var invitee = await _usersRepository.GetUserByIdAsync(inviteeId);
        if (invitee == null)
        {
            return NotFound("Invitee not found.");
        }

        var invite = new TeamInvite
        {
            Id = Guid.NewGuid(),
            TeamId = captain.Team.Id,
            InvitedBy = captain.Id,
            InviteDate = DateTime.UtcNow,
            Accepted = false
        };

        var result = await _usersRepository.AddTeamInviteAsync(inviteeId, invite);
        if (!result)
        {
            return StatusCode(500, "Failed to send invite.");
        }

        return Ok("Invite sent.");
    }
    
    [HttpPost("teams/acceptInvite")]
    public async Task<ActionResult> AcceptInvite([FromBody] Guid inviteId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized("User not found.");
        }

        var user = await _usersRepository.GetUserByIdAsync(Guid.Parse(userId));
        if (user == null)
        {
            return Unauthorized("User not found.");
        }

        var result = await _usersRepository.AcceptTeamInviteAsync(Guid.Parse(userId), inviteId);
        if (!result)
        {
            return StatusCode(500, "Failed to accept invite.");
        }

        return Ok("Invite accepted successfully.");
    }
}