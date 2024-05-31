using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IUsersRepository
{
    Task<User> CreateUserAsync(User user);
    Task<bool> UserExistsByEmailAsync(string email);
    Task<bool> UserExistsByUsernameAsync(string username);
    Task<User> GetUserByEmailAsync(string email);
}