using Domain.Entities;
using Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly IMongoCollection<User> _mongoCollection;

    public UsersRepository(IMongoCollection<User> mongoCollection)
    {
        _mongoCollection = mongoCollection;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await _mongoCollection.InsertOneAsync(user);
        return user;
    }
    
    public async Task<bool> UserExistsByEmailAsync(string email)
    {
        var filter = Builders<User>.Filter.Eq(u => u.SignInInfo.Email, email);
        var count = await _mongoCollection.CountDocumentsAsync(filter);
        return count > 0;
    }

    public async Task<bool> UserExistsByUsernameAsync(string username)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Username, username);
        var count = await _mongoCollection.CountDocumentsAsync(filter);
        return count > 0;
    }
    
    public async Task<User> GetUserByEmailAsync(string email)
    {
        var filter = Builders<User>.Filter.Eq(u => u.SignInInfo.Email, email);
        return await _mongoCollection.Find(filter).FirstOrDefaultAsync();
    }
}