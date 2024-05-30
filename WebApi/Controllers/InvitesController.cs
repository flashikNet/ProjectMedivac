using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class InvitesController : ControllerBase
    {
        private readonly IInviteService _service;
        public InvitesController( IInviteService service) 
        {
            _service = service;
        }

        [HttpGet]
        [Route("getInvites")]
        [ProducesResponseType<GetInvitesResp>(200)]
        public IActionResult GetInvites()
        {
            var id = uint.Parse( User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var res = _service.GetInvites(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("SendInvite")]
        [ProducesResponseType<SendInviteResp>(200)]
        [Authorize(Roles ="Captain")]
        public async Task<IActionResult> SendInviteAsync(SendInviteReq req)
        {
            var res = await _service.SendAsync(req);
            return Ok(res);
        }

        [HttpGet]
        [Route("refuseInvite")]
        [ProducesResponseType(200)]
        public IActionResult Refuse(uint id)
        {
            _service.Refuse(id);
            return Ok();
        }

        [HttpGet]
        [Route("aceptInvite")]
        [ProducesResponseType(200)]
        public IActionResult Accept(uint id)
        {
            _service.Accept(id);
            return Ok();
        }
    }
}
