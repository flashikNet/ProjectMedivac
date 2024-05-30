using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamWarController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Captain")]
        public IActionResult Create()
        {
            return Ok();
        }
    }
}
