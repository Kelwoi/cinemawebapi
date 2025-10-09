using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessions = await _sessionService.GetAllSessionsAsync();
            return Ok(sessions);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {
            var session = await _sessionService.GetSessionByIdAsync(id);
            if (session == null)
                return NotFound(new { message = $"Session with id {id} not found." });

            return Ok(session);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] CreateSessionDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdSession = await _sessionService.CreateSessionAsync(dto);
                return CreatedAtAction(nameof(GetSessionById),
                    new { id = createdSession.Id }, createdSession);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, [FromBody] CreateSessionDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _sessionService.UpdateSessionAsync(id, dto);
            if (updated == null)
                return NotFound(new { message = $"Session with id {id} not found." });

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var deleted = await _sessionService.DeleteSessionAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Session with id {id} not found." });

            return NoContent();
        }
    }
}
