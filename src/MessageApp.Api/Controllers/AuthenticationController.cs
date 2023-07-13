using MessageApp.Application.Common.Contracts;
using MessageApp.Application.Common.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public AuthenticationController(IIdentityService identityService)
        {
            _identityService = identityService;

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            return Ok(await _identityService.Login(loginRequest));
        }
        
    }
}
