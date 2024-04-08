using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private DbSet<User> _users;
        public UserRepository(IdentityContext Db){
            _users =  Db.Users;
        }

        public void Create(User item)
        {
            _users.Add(item);
        }

        public void Delete(uint id)
        {
            var user = _users.Find(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public async Task<User> GetAsync(uint id)
        {
            return await _users.FindAsync(id);
        }

        public void UpdateAsync(User item)
        {
            var oldUser = _users.Find(item.Id);
            if (oldUser != null)
            {
                oldUser.Name = item.Name;
                oldUser.Status = item.Status;
                oldUser.Race = item.Race;
                oldUser.Role = item.Role;
                oldUser.Email = item.Email;
                oldUser.BattleNetAccount = item.BattleNetAccount;
                oldUser.Password = item.Password;
                oldUser.Team = item.Team;
                oldUser.MMR = item.MMR;
            }

        }
    }
}
