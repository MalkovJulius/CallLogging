using CallLogging.Dtos;
using CallLogging.Services.ContactService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllContactsAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> Get(int id)
        {
            try
            {
                var instance = await _service.GetContactByIdAsync(id);
                return instance == null ? NotFound() : Ok(instance);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<ActionResult> Create(ContactDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("dto object is null");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _service.CreateContactAsync(dto);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<ContactController>
        [HttpPut]
        public async Task<ActionResult> Update(ContactDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("dto object is null");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _service.UpdateContactAsync(dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteContactAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
