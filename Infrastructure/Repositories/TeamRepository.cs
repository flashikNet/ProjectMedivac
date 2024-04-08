using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TeamRepository : IRepository<Team>
    {
        private DbSet<Team> _teams;
        public TeamRepository(IdentityContext Db)
        {
            _teams = Db.Teams;
        }

        public void Create(Team item)
        {
            _teams.Add(item);
        }

        public void Delete(uint id)
        {
            var team = _teams.Find(id);
            if (team != null)
            {
                _teams.Remove(team);
            }
        }

        public IEnumerable<Team> GetAll()
        {
            return _teams;
        }

        public async Task<Team> GetAsync(uint id)
        {
            return await _teams.FindAsync(id);
        }

        public void UpdateAsync(Team item)
        {
            var oldTeam = _teams.Find(item.Id);
            if (oldTeam != null)
            {
                oldTeam.Name = item.Name;
                oldTeam.Description = item.Description;
                oldTeam.Users = item.Users;
            }

        }


    }
}
