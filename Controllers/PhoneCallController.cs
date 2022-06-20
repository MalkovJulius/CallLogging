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
        public async Task<IEnumerable<PhoneCallDto>> GetAll()
        {
            return await _service.GetAllPhoneCallsAsync();
        }

        // GET api/<PhoneCallController>/5
        [HttpGet("{id}")]
        public async Task<PhoneCallDto> Get(int id)
        {
            return await _service.GetPhoneNumberByIdAsync(id);
        }

        // POST api/<PhoneCallController>
        [HttpPost]
        public async Task Create(PhoneCallDto dto)
        {
            await _service.CreatePhoneCallAsync(dto);
        }

        // PUT api/<PhoneCallController>
        [HttpPut]
        public async Task Update(PhoneCallDto dto)
        {
            await _service.UpdatePhoneCallAsync(dto);
        }

        // DELETE api/<PhoneCallController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeletePhoneCallAsync(id);
        }
    }
}
