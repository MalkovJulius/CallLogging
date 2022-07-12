using CallLogging.Dtos;
using CallLogging.Services.PhoneNumberService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        public readonly IPhoneNumberService _service;
        public PhoneNumberController(IPhoneNumberService service)
        {
            _service = service;
        }

        // GET: api/<PhoneNumberController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneNumberDto>>> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllPhoneNumbersAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<PhoneNumberController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumberDto>> GetAsync(int id)
        {
            try
            {
                var instance = await _service.GetPhoneNumberByIdAsync(id);
                return instance == null ? NotFound() : Ok(instance);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<PhoneNumberController>
        [HttpPost]
        public async Task<ActionResult> CreateAsync(PhoneNumberDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("dto object is null");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _service.CreatePhoneNumberAsync(dto);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<PhoneNumberController>
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(PhoneNumberDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("dto object is null");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _service.UpdatePhoneNumberAsync(dto);
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

        // DELETE api/<PhoneNumberController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeletePhoneNumberAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
