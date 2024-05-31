using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ITeamsRepository
{
    Task<List<Team>> GetAllTeams();
    Task<Team> CreateTeam(Team team);
}