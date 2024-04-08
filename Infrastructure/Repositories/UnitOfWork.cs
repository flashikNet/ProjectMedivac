using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Team> Teams { get; set; }
        public IRepository<User> Users { get; set; }
        private IdentityContext _db;
        public UnitOfWork(IdentityContext identityContext) {
            _db = identityContext;
            Users = new UserRepository(_db);
            Teams = new TeamRepository(_db);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
