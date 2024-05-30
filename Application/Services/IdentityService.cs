using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Auth;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services
{
    internal class IdentityService : IIdentityService
    {
        private IUnitOfWork uow;
        public IdentityService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Delete(uint id)
        {
            uow.Users.Delete(id);
            uow.Commit();
        }

        public SignResp SignIn(SignInReq signInReq)
        {
            var email = signInReq.Email;
            var password = signInReq.Password;
            var user = uow.Users.GetAll().Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            if(user is null)
            {
                return null;
            }
            var jwt = GetToken(user);
            return new() { Id = user.Id, Token = jwt};
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }

        public SignResp SignUp(SignUpReq userDTO)
        {
            var user = new User()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = Roles.User,
                MMR = userDTO.MMR,
                Race = userDTO.Race,
                BattleNetAccount = userDTO.BattleNetAccount
            };
            uow.Users.Create(user);
            uow.Commit();
            var jwt = GetToken(user);
            return new() { Id = user.Id, Token = jwt };
        }

        private string GetToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("TeamId", user.Team?.Id.ToString() ?? "0")
            };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.Now.Add(TimeSpan.FromMinutes(10)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
