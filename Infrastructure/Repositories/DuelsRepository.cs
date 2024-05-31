using Domain.Entities;
using Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class DuelsRepository : IDuelsRepository
{
    private readonly IMongoCollection<Duel> _mongoCollection;

    public DuelsRepository(IMongoCollection<Duel> mongoCollection)
    {
        _mongoCollection = mongoCollection;
    }

    public async Task CreateDuelAsync(Duel duel)
    {
        await _mongoCollection.InsertOneAsync(duel);
    }
}