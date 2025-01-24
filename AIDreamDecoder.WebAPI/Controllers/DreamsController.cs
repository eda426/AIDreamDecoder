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
        private readonly ILogger<DreamsController> _logger;

        public DreamsController(IDreamService dreamService, ILogger<DreamsController> logger)
        {
            _dreamService = dreamService;
            _logger = logger;
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
            {
                _logger.LogWarning($"Dream with ID {id} not found.");
                return NotFound();
            }
               
            return Ok(dream);

        }

        [HttpPost]
        public async Task<IActionResult> AddDream([FromBody] CreateDreamRequestDto dreamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dreamId = await _dreamService.AddDreamAsync(new DreamDto
            {
                Id = Guid.NewGuid(),
                Description = dreamDto.DreamDescription,
                UserId = dreamDto.UserId // UserId ekleniyor
            });

            return CreatedAtAction(nameof(GetDream), new { id = dreamId, description =dreamDto.DreamDescription}, dreamDto);
        }

        [HttpPost("{userId}/dreams/transaction")]
        public async Task<IActionResult> AddDreamWithTransaction(Guid userId, [FromBody] DreamDto dreamDto)
        {
            try
            {
                var dreamId = await _dreamService.AddDreamWithUserTransactionAsync(userId, dreamDto);
                return Ok(new { DreamId = dreamId, Message = "Dream added with transaction successfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding dream with transaction for user {UserId}", userId);
                return BadRequest(new { Error = ex.Message });
            }
        }

        // PUT: api/Dream/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDream(Guid id, [FromBody] UpdateDreamRequestDto updateDto)
        {
            if (id != updateDto.DreamId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var dream = await _dreamService.GetDreamByIdAsync(id);
            if (dream == null)
            {
                return NotFound();
            }

            await _dreamService.UpdateDreamAsync(new DreamDto
            {
                Id = updateDto.DreamId,
                Description = updateDto.UpdatedDescription,
                UserId = dream.UserId // UserId korunuyor
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDream(Guid id)
        {
            var result = await _dreamService.DeleteDreamAsync(id);
            if (!result)
               {
            _logger.LogWarning($"Dream with ID {id} not found.");
            return NotFound();
        }
            return NoContent();
        }
    }
}
