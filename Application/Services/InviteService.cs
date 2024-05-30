using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class InviteService : IInviteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InviteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async void Accept(uint Id)
        {
            var invite = await _unitOfWork.Invites.GetAsync(Id);
            invite.Invited.Team = invite.Inviter.Team;
            invite.Invited.Role = Roles.Player;
            _unitOfWork.Invites.Delete(Id);
            _unitOfWork.Commit();
        }

        public GetInvitesResp[] GetInvites(uint Id)
        {
            var res = _unitOfWork.Invites.GetAll().Where(i => i.Invited.Id == Id).Select(i => new GetInvitesResp() 
            {
                Id = i.Id,
                InviterId = i.Inviter.Id,
                TeamId = i.Inviter.Team.Id,
                Content = i.Content
            }).ToArray();
            return res;
        }

        public void Refuse(uint Id)
        {
            _unitOfWork.Invites.Delete(Id);
            _unitOfWork.Commit();
        }

        public async Task<SendInviteResp> SendAsync(SendInviteReq req)
        {
            var inviter = await _unitOfWork.Users.GetAsync(req.InviterId);
            var invited = await _unitOfWork.Users.GetAsync(req.InvitedId);
            var invite = new Invite() 
            {
                Content = req.Content,
                Inviter = inviter,
                Invited = invited
            };
            _unitOfWork.Invites.Create(invite);
            _unitOfWork.Commit();
            return new() { Id = invite.Id };
        }
    }
}
