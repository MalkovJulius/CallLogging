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
        public async Task<ActionResult<IEnumerable<ConferenceDto>>> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllConferencesAsync());
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<ConferenceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConferenceDto>> GetAsync(int id)
        {
            try
            {
                var instance = await _service.GetConferenceByIdAsync(id);
                return instance == null ? NotFound() : Ok(instance);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<ConferenceController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ConferenceDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("dto object is null");

                await _service.CreateConferenceAsync(dto);
                return CreatedAtAction(nameof(CreateAsync), null);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<ConferenceController>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ConferenceDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("dto object is null");

                await _service.UpdateConferenceAsync(dto);
                return NoContent();
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<ConferenceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteConferenceAsync(id);
                return NoContent();
            }            
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
