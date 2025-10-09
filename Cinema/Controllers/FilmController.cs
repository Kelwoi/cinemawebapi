using Microsoft.AspNetCore.Mvc;
using CinemaAppDb.Data;
using CinemaAppDb.Data.Entities;
using BusinessLogic;
using BusinessLogic.Dtos;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;


namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly CinemaDbContext ctx;
        private readonly IFilmsService Filmservices;

        public FilmController(CinemaDbContext ctx, IFilmsService filmsService)
        {
            this.ctx = ctx;
            this.Filmservices = filmsService;
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
        public IActionResult Create([FromBody] CreateFilmDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            var result = Filmservices.Create(model);

            // 201
            return CreatedAtAction(
                nameof(Get),            // The action to get a single product
                new { id = result.Id }, // Route values for that action
                result                  // Response body
            );
        }

        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage);
        }
    }
}
