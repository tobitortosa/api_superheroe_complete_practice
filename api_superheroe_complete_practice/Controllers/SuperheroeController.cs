using api_superheroe_complete_practice.Services.SuperheroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace api_superheroe_complete_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroeController : ControllerBase
    {
        private readonly ISuperheroeService _superheroeService;

        public SuperheroeController(ISuperheroeService superheroeService)
        {
            _superheroeService = superheroeService;
        }

        [HttpGet] //Si el atributo no esta, swagger no lo lee
        public async Task<ActionResult<List<Superheroe>>> GetAll()
        {
            var res = await _superheroeService.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superheroe>> GetById(int id)
        {
            var res = await _superheroeService.GetById(id);
            if (res is null)
                return NotFound($"None superheroe finded with id: {id}");
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Superheroe>> Add([FromBody] Superheroe super)
        {
            var res = await _superheroeService.Add(super);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Superheroe>> Update(int id, [FromBody] Superheroe request)
        {
            var res = await _superheroeService.Update(id, request);
            if (res is null)
                return NotFound($"None superheroe finded with id: {id}");
            return Ok(res);
        }

        [HttpDelete("{id}")] 
        public async Task<ActionResult<List<Superheroe>>> Delete(int id)
        {
            var res = await _superheroeService.Delete(id);
            if (res is null)
                return NotFound($"None superheroe finded with id: {id}");
            return Ok(res);
        }
    }
}
