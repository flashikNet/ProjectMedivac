using Application.Models.Requests;
using Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInviteService
    {
        public void Accept(uint Id);
        public void Refuse(uint Id);
        public Task<SendInviteResp> SendAsync(SendInviteReq req);
        public GetInvitesResp[] GetInvites(uint Id);
    }
}
