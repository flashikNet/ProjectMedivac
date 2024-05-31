using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Interfaces;

public interface IUsersRepository
{
    Task<User> CreateUserAsync(User user);
    Task<bool> UserExistsByEmailAsync(string email);
    Task<bool> UserExistsByUsernameAsync(string username);
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(Guid userId);
    Task<User> ReturnUpdatedUserRoleAsync(Guid userId, Roles role);
    Task<bool> UpdateUserTeam(Guid userId, Team team);
    Task<bool> AddTeamInviteAsync(Guid userId, TeamInvite invite);
    Task<bool> AcceptTeamInviteAsync(Guid userId, Guid inviteId);
}