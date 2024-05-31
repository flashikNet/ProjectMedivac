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

    public async Task<Team> GetTeamById(Guid id)
    {
        return await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<bool> UpdateTeamMembers(Guid teamId, List<User> members)
    {
        var update = Builders<Team>.Update.Set(t => t.Members, members);
        var result = await _mongoCollection.UpdateOneAsync(t => t.Id == teamId, update);
        return result.ModifiedCount > 0;
    }

}