using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private DbSet<Game> _games;
        public GameRepository(IdentityContext Db)
        {
            _games = Db.Games;
        }

        public void Create(Game item)
        {
            _games.Add(item);
        }

        public void Delete(uint id)
        {
            var team = _games.Find(id);
            if (team != null)
            {
                _games.Remove(team);
            }
        }

        public IEnumerable<Game> GetAll()
        {
            return _games;
        }

        public async Task<Game> GetAsync(uint id)
        {
            return await _games.FindAsync(id);
        }

        public void UpdateAsync(Game item)
        {
            throw new NotImplementedException();
        }
    }
}
