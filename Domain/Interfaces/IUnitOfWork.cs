using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Team> Teams {get; set;}
        public IRepository<User> Users { get; set; }

        public void Commit();
    }
}
