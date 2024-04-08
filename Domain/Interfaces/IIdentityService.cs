using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIdentityService
    {
        public string SignUp(User user);
        public string SignIn(string email,  string password);
        public void SignOut();
        public void Delete(uint id);
    }
}
