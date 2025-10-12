using BusinessLogic.Dtos;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallsController : ControllerBase
    {
        private readonly HallServices _hallService;

        public HallsController(HallServices hallService)
        {
            _hallService = hallService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHalls()
        {
            var halls = await _hallService.GetAllHallsAsync();
            return Ok(halls);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHallById(int id)
        {
            var hall = await _hallService.GetHallByIdAsync(id);
            if (hall == null)
                return NotFound(new { message = $"Hall with id {id} not found." });

            return Ok(hall);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHall([FromBody] CreateHallDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hall = await _hallService.CreateHallAsync(dto);
            return CreatedAtAction(nameof(GetHallById), new { id = hall.Id }, hall);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHall(int id, [FromBody] CreateHallDTO dto)
        {
            var updatedHall = await _hallService.UpdateHallAsync(id, dto);
            if (updatedHall == null)
                return NotFound(new { message = $"Hall with id {id} not found." });

            return Ok(updatedHall);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHall(int id)
        {
            var deleted = await _hallService.DeleteHallAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Hall with id {id} not found." });

            return NoContent();
        }
    }
}
