using AIDreamDecoder.Application.Common.Helpers;
using AIDreamDecoder.Application.Dtos.UserDtos;
using AIDreamDecoder.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIDreamDecoder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService  _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] UserRegistrationDto registrationDto)
        {
            try
            {
                var result = await _userService.RegisterAsync(registrationDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        /*[HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                var (user, token) = await _userService.LoginAsync(loginDto);
                return Ok(new { User = user, Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }*/ //UserDtoyu kaldırdık bir dtoya ihtiyacımız yok burada

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

