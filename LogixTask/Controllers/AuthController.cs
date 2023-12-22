using LogixTask.Domain.Login;
using LogixTask.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogixTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly IRegisterService _registerService;
        private readonly IRefreshTokenHandler _refreshToken;

        public AuthController(IAuthManager authManager, IRefreshTokenHandler refreshToken, IRegisterService registerService)
        {
            _authManager = authManager;
            _refreshToken = refreshToken;
            _registerService = registerService;
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var result = await _authManager.LoginAsync(request);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync(RegisterRequest request)
        {
            var result = await _registerService.RegisterAsync(request);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = new RefreshTokenRequest
            {
                ExpiredAccessToken = Request.Headers["Authorization"].ToString()
            };

            return Ok(await _refreshToken.RefreshTokenHandle(refreshToken));
        }
    }
}
