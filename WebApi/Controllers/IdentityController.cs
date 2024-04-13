using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [ProducesResponseType<SignResp>(200)]
        public IActionResult SignIn([FromQuery]SignInReq loginData)
        {
            var response = _service.SignIn(loginData);
            if(response is null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("signUp")]
        [ProducesResponseType<SignResp>(200)]
        public async Task<IActionResult> SignUp(SignUpReq userDTO)
        {
            return Ok(_service.SignUp(userDTO));
        }

        [HttpGet]
        [Route("delete")]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            var id = uint.Parse( User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _service.Delete(id);
            return Ok();
        }
    }
}
