using Application.Interfaces;
using Application.Models.Requests;
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
    internal class TeamService : ITeamService
    {
        private IUnitOfWork _unitOfWork;
        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<uint> CreateTeamAsync(CreateTeamReq req, uint captainId)
        {
            var captain = await _unitOfWork.Users.GetAsync(captainId);
            var team = new Team() 
            {
                Name = req.Name,
                Description = req.Description,
            };
            team.Users.Add(captain);
            _unitOfWork.Teams.Create(team);
            captain.Role = Roles.Captain;
            _unitOfWork.Commit();
            return team.Id;
        }

        public async Task DeleteTeamAsync(uint captainId)
        {
            var captain = await _unitOfWork.Users.GetAsync(captainId);
            _unitOfWork.Teams.Delete(captain.Team.Id);
            captain.Role = Roles.User;
            _unitOfWork.Commit();
        }
    }
}
