using AZ.Core.DTOs;
using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.IProviders;
using Microsoft.AspNetCore.Mvc;

namespace AZ.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly ITimeZoneProvider _timezoneProvider;

        public AuthController(IAuthRepository authRepo, ITimeZoneProvider timezoneProvider)
        {
            _authRepo = authRepo;
            _timezoneProvider = timezoneProvider;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var success = await _authRepo.RegisterAsync(request);
            if (!success) return BadRequest("Đăng ký thất bại. Email hoặc tên người dùng đã tồn tại.");

            return Ok("Đăng ký thành công. Vui lòng đăng nhập.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var timezone = _timezoneProvider.GetTimeZoneId();
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var userAgent = Request.Headers["User-Agent"].ToString();

            var response = await _authRepo.LoginAsync(request, ipAddress, userAgent, timezone);

            if (response == null) return Unauthorized("Sai thông tin đăng nhập.");
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            var response = await _authRepo.RefreshTokenAsync(refreshToken);
            if (response == null) return Unauthorized("Refresh token không hợp lệ.");

            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string refreshToken)
        {
            var result = await _authRepo.LogoutAsync(refreshToken);
            if (!result) return BadRequest("Không thể đăng xuất.");

            return Ok("Đăng xuất thành công.");
        }
    }

}
