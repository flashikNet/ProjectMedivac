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
    internal class InviteRepository : IRepository<Invite>
    {
        private DbSet<Invite> _invites;
        public InviteRepository(IdentityContext Db)
        {
            _invites = Db.Invites;
        }

        public void Create(Invite item)
        {
            _invites.Add(item);
        }

        public void Delete(uint id)
        {
            var team = _invites.Find(id);
            if (team != null)
            {
                _invites.Remove(team);
            }
        }

        public IEnumerable<Invite> GetAll()
        {
            return _invites;
        }

        public async Task<Invite> GetAsync(uint id)
        {
            return await _invites.FindAsync(id);
        }

        public void UpdateAsync(Invite item)
        {
            throw new NotImplementedException();
        }
    }
}
