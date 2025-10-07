using Microsoft.AspNetCore.Mvc;
using CinemaAppDb.Data;
using CinemaAppDb.Data.Entities;


namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly CinemaDbContext ctx;

        public FilmController(CinemaDbContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var items = ctx.Films.ToList();

            return Ok(items);
        }
        [HttpGet()]
        public IActionResult Get(int id)
        {
            if (id < 0)
                return BadRequest("Id can not be negative!");

            var item = ctx.Films.Find(id);

            if (item == null)
                return NotFound("Film not found!");

            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(Film model)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            model.id = 0;

            ctx.Films.Add(model);
            ctx.SaveChanges();

            return CreatedAtAction(nameof(Get), new { Id = model.id }, model);
        }

        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage);
        }
    }
}
