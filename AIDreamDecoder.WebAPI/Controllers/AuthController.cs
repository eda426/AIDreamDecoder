using AIDreamDecoder.Application.Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIDreamDecoder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Kullanıcı doğrulama işlemi yapılır (örnek olarak basit bir kontrol eklenmiştir).
            if (request.Username == "admin" && request.Password == "password")
            {
                var token = JwtTokenHelper.GenerateToken(
                    request.Username,
                    "SuperSecretKey",
                    "Issuer",
                    "Audience",
                    60); // Token süresi (dakika)

                return Ok(new { Token = token });
            }

            return Unauthorized("Geçersiz kullanıcı adı veya şifre.");
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

