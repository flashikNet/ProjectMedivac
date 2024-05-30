using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Team> Teams { get; set; }
        public IRepository<User> Users { get; set; }
        public IRepository<Invite> Invites { get; set; }
        public IRepository<Game> Games { get; set; }
        public IRepository<Duel> Duels { get; set; }

        private IdentityContext _db;
        public UnitOfWork(IdentityContext identityContext) {
            _db = identityContext;
            Users = new UserRepository(_db);
            Teams = new TeamRepository(_db);
            Invites = new InviteRepository(_db);
            Games = new GameRepository(_db);
            Duels = new DuelRepository(_db);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
