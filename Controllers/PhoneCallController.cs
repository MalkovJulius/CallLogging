using CallLogging.Dtos;
using CallLogging.Services.PhoneCallService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneCallController : ControllerBase
    {
        public readonly IPhoneCallService _service;
        public PhoneCallController(IPhoneCallService service)
        {
            _service = service;
        }

        // GET: api/<PhoneCallController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneCallDto>>> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllPhoneCallsAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<PhoneCallController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneCallDto>> GetAsync(int id)
        {
            try
            {
                var instance = await _service.GetPhoneCallByIdAsync(id);
                return instance == null ? NotFound() : Ok(instance);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<PhoneCallController>
        [HttpPost]
        public async Task<ActionResult> CreateAsync(PhoneCallDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("dto object is null");

                await _service.CreatePhoneCallAsync(dto);
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

        // PUT api/<PhoneCallController>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(PhoneCallDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("dto object is null");

                await _service.UpdatePhoneCallAsync(dto);
                return NoContent();
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

        // DELETE api/<PhoneCallController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeletePhoneCallAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
