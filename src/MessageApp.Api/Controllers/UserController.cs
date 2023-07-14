using MessageApp.Application.Common.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;

        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok( await _identityService.GetUser());
        }
    }
}
