using System.Security.Claims;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class DuelController : BaseApiController
{
    private readonly IUsersRepository _userRepository;
    private readonly IDuelsRepository _duelRepository;

    public DuelController(IUsersRepository userRepository, IDuelsRepository duelRepository)
    {
        _userRepository = userRepository;
        _duelRepository = duelRepository;
    }

    // Метод для отправки приглашения на дуэль
    [HttpPost("duels/invite")]
    public async Task<ActionResult> InviteUserToDuel([FromBody] Guid inviteeId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized("User not found.");
        }

        var inviter = await _userRepository.GetUserByIdAsync(Guid.Parse(userId));
        if (inviter == null)
        {
            return Unauthorized("User not found.");
        }

        var invitee = await _userRepository.GetUserByIdAsync(inviteeId);
        if (invitee == null)
        {
            return NotFound("Invitee not found.");
        }

        var duel = new Duel
        {
            Id = Guid.NewGuid(),
            TeamA = inviter.Team,
            TeamB = invitee.Team
        };

        await _duelRepository.CreateDuelAsync(duel);

        var invite = new DuelInvite
        {
            Id = Guid.NewGuid(),
            InvitedBy = inviter.Id,
            InviteDate = DateTime.UtcNow,
            Accepted = false
        };

        var result = await _userRepository.AddDuelInviteAsync(inviteeId, invite);
        if (!result)
        {
            return StatusCode(500, "Failed to send duel invite.");
        }

        return Ok("Duel invite sent successfully.");
    }
    
    [HttpPost("duels/acceptInvite")]
    public async Task<ActionResult> AcceptDuelInvite([FromBody] Guid inviteId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized("User not found.");
        }

        var user = await _userRepository.GetUserByIdAsync(Guid.Parse(userId));
        if (user == null)
        {
            return Unauthorized("User not found.");
        }

        var result = await _userRepository.AcceptDuelInviteAsync(Guid.Parse(userId), inviteId);
        if (!result)
        {
            return StatusCode(500, "Failed to accept duel invite.");
        }

        return Ok("Duel invite accepted successfully.");
    }
}