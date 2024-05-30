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
    public class DuelRepository : IRepository<Duel>
    {
        private DbSet<Duel> _duels;
        public DuelRepository(IdentityContext Db)
        {
            _duels = Db.Duels;
        }

        public void Create(Duel item)
        {
            _duels.Add(item);
        }

        public void Delete(uint id)
        {
            var team = _duels.Find(id);
            if (team != null)
            {
                _duels.Remove(team);
            }
        }

        public IEnumerable<Duel> GetAll()
        {
            return _duels;
        }

        public async Task<Duel> GetAsync(uint id)
        {
            return await _duels.FindAsync(id);
        }

        public void UpdateAsync(Duel item)
        {
            throw new NotImplementedException();
        }
    }
}
