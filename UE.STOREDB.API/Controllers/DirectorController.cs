using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDB.DOMAIN.Core.Entities;
using MovieDB.DOMAIN.Core.Interfaces;

namespace MovieDB.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorController(IDirectorRepository directorService)
        {
            _directorRepository = directorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var directors = await _directorRepository.GetAll();
            return Ok(directors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var director = await _directorRepository.GetById(id);
            if (director == null)
                return NotFound();

            return Ok(director);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Director director)
        {
            var result = await _directorRepository.Insert(director);
            if (!result) return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Director director)
        {
            if (id != director.Id) return BadRequest();
            var result = await _directorRepository.Update(director);
            if (!result) return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _directorRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }

    }
}
