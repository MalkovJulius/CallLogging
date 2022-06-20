using CallLogging.Dtos;
using CallLogging.Services.ConferenceService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        public readonly IConferenceService _service;
        public ConferenceController(IConferenceService service)
        {
            _service = service;
        }

        // GET: api/<ConferenceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConferenceDto>>> GetAll()
        {
            return Ok(await _service.GetAllConferencesAsync());
        }

        // GET api/<ConferenceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConferenceDto>> Get(int id)
        {
            var dto = await _service.GetConferenceByIdAsync(id);
            return dto == null ? NotFound() : Ok(dto);
        }

        // POST api/<ConferenceController>
        [HttpPost]
        public async Task<ActionResult> Create(ConferenceDto dto)
        {
            if (dto == null) return BadRequest("dto object is null");

            await _service.CreateConferenceAsync(dto);//get id from oblect
            return CreatedAtRoute(nameof(Get), new { Id = 1});
        }

        // PUT api/<ConferenceController>
        [HttpPut]
        public async Task<ActionResult> Update(ConferenceDto dto)
        {
            if (dto == null) return BadRequest("dto object is null");

            await _service.UpdateConferenceAsync(dto);//return value for correct request
            //if (instance == null) return NotFound();
            return NoContent();

        }

        // DELETE api/<ConferenceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteConferenceAsync(id);
            return NoContent();
        }
    }
}
