using Domain.Entities;
using Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class TeamsRepository : ITeamsRepository
{
    private readonly IMongoCollection<Team> _mongoCollection;

    public TeamsRepository(IMongoCollection<Team> mongoCollection)
    {
        _mongoCollection = mongoCollection;
    }

    public async Task<List<Team>> GetAllTeams()
    {
        return await _mongoCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Team> CreateTeam(Team team)
    {
        await _mongoCollection.InsertOneAsync(team);
        return team;
    }
}