using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ITeamsRepository
{
    Task<List<Team>> GetAllTeams();
    Task<Team> CreateTeam(Team team);
    Task<Team> GetTeamById(Guid id);
    Task<bool> UpdateTeamMembers(Guid teamId, List<User> members);
}