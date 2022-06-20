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
        public async Task<IEnumerable<PhoneNumberDto>> GetAll()
        {
            return await _service.GetAllPhoneNumbersAsync();
        }

        // GET api/<PhoneNumberController>/5
        [HttpGet("{id}")]
        public async Task<PhoneNumberDto> Get(int id)
        {
            return await _service.GetPhoneNumberByIdAsync(id);
        }

        // POST api/<PhoneNumberController>
        [HttpPost]
        public async Task Create(PhoneNumberDto dto)
        {
            await _service.CreatePhoneNumberAsync(dto);
        }

        // PUT api/<PhoneNumberController>
        [HttpPut]
        public async Task Update(PhoneNumberDto dto)
        {
            await _service.UpdatePhoneNumberAsync(dto);
        }

        // DELETE api/<PhoneNumberController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeletePhoneNumberAsync(id);
        }
    }
}
