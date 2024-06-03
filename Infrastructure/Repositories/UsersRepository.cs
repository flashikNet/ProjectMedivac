using Domain.Entities;
using Domain.Enums;
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

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        return await _mongoCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();
    }

    public async Task<User> ReturnUpdatedUserRoleAsync(Guid userId, Roles role)
    {
        var update = Builders<User>.Update.Set(u => u.Role, role);
        await _mongoCollection.UpdateOneAsync(u => u.Id == userId, update);
        var updatedUser = await _mongoCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();

        return updatedUser;
    }

    public async Task<bool> UpdateUserTeam(Guid userId, Team team)
    {
        var update = Builders<User>.Update.Set(u => u.Team, team);
        var result = await _mongoCollection.UpdateOneAsync(u => u.Id == userId, update);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> AddTeamInviteAsync(Guid userId, TeamInvite invite)
    {
        var user = await _mongoCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();

        if (user.Invites == null)
        {
            user.Invites = new List<TeamInvite>();
        }

        user.Invites.Add(invite);

        var update = Builders<User>.Update.Set(u => u.Invites, user.Invites);
        var result = await _mongoCollection.UpdateOneAsync(u => u.Id == userId, update);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> AcceptTeamInviteAsync(Guid userId, Guid inviteId)
    {
        var user = await _mongoCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();

        if (user?.Invites == null)
        {
            return false;
        }

        var invite = user.Invites.FirstOrDefault(i => i.Id == inviteId);
        if (invite == null)
        {
            return false;
        }

        var teamId = invite.TeamId;

        var update = Builders<User>.Update
            .PullFilter(u => u.Invites, i => i.Id == inviteId)
            .Set(u => u.Team, new Team { Id = teamId })
            .Set(u => u.Role, Roles.Player);

        var result = await _mongoCollection.UpdateOneAsync(u => u.Id == userId, update);
        return result.ModifiedCount > 0;
    }
    
    public async Task<bool> AddDuelInviteAsync(Guid userId, DuelInvite invite)
    {
        var update = Builders<User>.Update.AddToSet(u => u.DuelInvites, invite);
        var result = await _mongoCollection.UpdateOneAsync(u => u.Id == userId, update);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> AcceptDuelInviteAsync(Guid userId, Guid inviteId)
    {
        var user = await _mongoCollection.Find(u => u.Id == userId).FirstOrDefaultAsync();

        if (user?.DuelInvites == null)
        {
            return false;
        }

        var invite = user.DuelInvites.FirstOrDefault(i => i.Id == inviteId);
        if (invite == null)
        {
            return false;
        }

        var duelId = invite.Id;

        var update = Builders<User>.Update
            .PullFilter(u => u.DuelInvites, i => i.Id == inviteId)
            .Set(u => u.CurrentDuel, new Duel { Id = duelId });

        var result = await _mongoCollection.UpdateOneAsync(u => u.Id == userId, update);
        return result.ModifiedCount > 0;
    }



    public async Task<Guid> GetUserTeam(Guid userId)
    {
        var user = GetUserByIdAsync(userId);
        return user.Result.Team.Id;
    }
}
