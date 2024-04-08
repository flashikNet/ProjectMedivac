using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApi.RequestModels;

namespace WebApi.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private IIdentityService _service;
        public IdentityController(IIdentityService service) 
        {
            _service = service;
        }

        [HttpGet]
        [Route("signIn")]
        [ProducesResponseType<string>(200)]
        public async Task<IActionResult> SignIn([FromQuery]SignInRequest loginData)
        {
            return Ok(_service.SignIn(loginData.Email, loginData.Password));
        }

        [HttpPost]
        [Route("signUp")]
        [ProducesResponseType<string>(200)]
        public async Task<IActionResult> SignUp(User user)
        {
            return Ok(_service.SignUp(user));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetData()
        {
            return Ok(DateTime.Now);
        }
        //[HttpGet]
        //[Route("signOut")]
        //[ProducesResponseType(200)]
        //public Task<IActionResult> SignOut()
        //{

        //}
    }
}
