using Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITeamService
    {
        public Task<uint> CreateTeamAsync(CreateTeamReq req, uint captainId);

        public Task DeleteTeamAsync(uint captainId);
    }
}
