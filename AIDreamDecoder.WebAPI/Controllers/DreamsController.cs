using AIDreamDecoder.Application.Dtos.DreamDtos;
using AIDreamDecoder.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIDreamDecoder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DreamsController : ControllerBase
    {
        private readonly IDreamService _dreamService;

        public DreamsController(IDreamService dreamService)
        {
            _dreamService = dreamService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DreamDto>>> GetDreams()
        {
            var dreams = await _dreamService.GetDreamsAsync();
            return Ok(dreams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DreamDto>> GetDream(Guid id)
        {
            var dream = await _dreamService.GetDreamByIdAsync(id);
            if (dream == null)
                return NotFound();
            return Ok(dream);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDream([FromBody] DreamDto dreamDto)
        {
            var dreamId = await _dreamService.AddDreamAsync(dreamDto);
            return CreatedAtAction(nameof(GetDream), new { id = dreamId }, dreamId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDream(Guid id)
        {
            var result = await _dreamService.DeleteDreamAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
