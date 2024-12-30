using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIDreamDecoder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetProtectedData()
        {
            return Ok("Bu veri yalnızca yetkili kullanıcılar içindir.");
        }
    }
}
//JWT token doğrulamasını test etmek için bir korunan endpoint 